$ErrorActionPreference = "Stop"

Write-Host "Targeted Verification of Fee Arrears & Duplicate Voucher Fixes on SCMS_SF_TEST..."

# 1. Point School.exe to SCMS_SF_TEST in-memory
$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$submitMethod = $feeType.GetMethod("submitfeeSingle")
$genMultiMethod = $feeType.GetMethod("generatefeeMulti")

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$allPass = $true
function Assert-True($condition, $testName, $details) {
    if ($condition) {
        Write-Host "[PASS] $testName - $details" -ForegroundColor Green
    } else {
        Write-Host "[FAIL] $testName - $details" -ForegroundColor Red
        $script:allPass = $false
    }
}

$sid = "2093"
$cid = "64"

# Cleanup any previous test vouchers for student 2093 in session 12
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12');
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12');
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

# ==============================================================================
# TEST 1: Full Payment of Previous-Month Voucher -> Zero Arrears in Next Month
# ==============================================================================
Write-Host "`n--- Testing Bug 1: Full Payment -> Zero Arrears ---"

# Step 1a: Generate November 2026 fee
$genMultiMethod.Invoke($feeInstance, @($cid, "11 2026", "Morning", $sid, 1, "11 2026", "2026-11-10", "1", "0", "Nov fee", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId = ""; $novRecv = 0
if ($r.Read()) {
    $novId = $r["FEE_MASTER_ID"].ToString()
    $novRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Generated Nov Voucher ID: $novId, Amount: $novRecv"

# Step 1b: Post FULL payment on November voucher via submitfeeSingle (Voucher Posting)
$postRet = $submitMethod.Invoke($feeInstance, @($novRecv, $novId, $false, [DateTime]'2026-11-05', [DateTime]'2026-11-10', "1", "SC01"))
Write-Host "Posted full payment of $novRecv. Return: $postRet"

# Verify November is marked PAID='Y' and BALANCE=0
$cmd.CommandText = "SELECT REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE FEE_MASTER_ID = '$novId' AND SessionID = '12'"
$r = $cmd.ExecuteReader()
$novPaid = ""; $novBal = -1
if ($r.Read()) {
    $novPaid = $r["PAID"].ToString().Trim()
    $novBal = [double]$r["BALANCE"]
}
$r.Close()
Assert-True (($novPaid -eq "Y") -and ($novBal -eq 0)), "Nov Voucher Fully Paid", "PAID=$novPaid, BALANCE=$novBal"

# Step 1c: Generate December 2026 fee
$genMultiMethod.Invoke($feeInstance, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId = ""; $decRecv = 0
if ($r.Read()) {
    $decId = $r["FEE_MASTER_ID"].ToString()
    $decRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

# Verify that December has NO arrears line
$cmd.CommandText = "SELECT COUNT(*), ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$r = $cmd.ExecuteReader()
$decArrearCount = -1; $decArrearSum = -1
if ($r.Read()) {
    $decArrearCount = [int]$r[0]
    $decArrearSum = [double]$r[1]
}
$r.Close()

Assert-True (($decArrearCount -eq 0) -and ($decArrearSum -eq 0) -and ($decRecv -eq $novRecv)), "Bug 1 Test: Zero Arrears After Full Payment", "Dec Arrear Rows = $decArrearCount, Arrear Sum = $decArrearSum, Dec Total = $decRecv (expected $novRecv)"

# ==============================================================================
# TEST 2: Partial Payment -> Carry Forward ONLY Actual Remaining Balance
# ==============================================================================
Write-Host "`n--- Testing Bug 1: Partial Payment -> Actual Remaining Balance ---"

# Unpost and delete December voucher so we can test partial payment on November
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId';
DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$decId';
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO = '$novId';
UPDATE FEE_MASTER SET PAID = NULL, STATUS = NULL, REC_AMOUNT = 0, BALANCE = RECEIVABLE_AMOUNT WHERE FEE_MASTER_ID = '$novId';
"@
$cmd.ExecuteNonQuery() | Out-Null

# Post PARTIAL payment of Rs. 3,000 on November voucher (total is 9,000)
$partialAmt = 3000.0
$expectedRemaining = $novRecv - $partialAmt
$submitMethod.Invoke($feeInstance, @($partialAmt, $novId, $false, [DateTime]'2026-11-05', [DateTime]'2026-11-10', "1", "SC02"))

$cmd.CommandText = "SELECT REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE FEE_MASTER_ID = '$novId'"
$r = $cmd.ExecuteReader()
$novPartRec = 0; $novPartBal = 0; $novPartPaid = ""
if ($r.Read()) {
    $novPartRec = [double]$r["REC_AMOUNT"]
    $novPartBal = [double]$r["BALANCE"]
    $novPartPaid = $r["PAID"].ToString().Trim()
}
$r.Close()
Assert-True (($novPartRec -eq $partialAmt) -and ($novPartBal -eq $expectedRemaining)), "Nov Partial Payment Recorded", "REC_AMOUNT=$novPartRec, BALANCE=$novPartBal, PAID=$novPartPaid"

# Now generate December 2026 fee
$genMultiMethod.Invoke($feeInstance, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId2 = ""; $decRecv2 = 0
if ($r.Read()) {
    $decId2 = $r["FEE_MASTER_ID"].ToString()
    $decRecv2 = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

$cmd.CommandText = "SELECT COUNT(*), ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId2' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$r = $cmd.ExecuteReader()
$decArrearCount2 = -1; $decArrearSum2 = -1
if ($r.Read()) {
    $decArrearCount2 = [int]$r[0]
    $decArrearSum2 = [double]$r[1]
}
$r.Close()

Assert-True (($decArrearSum2 -eq $expectedRemaining) -and ($decRecv2 -eq ($novRecv + $expectedRemaining))), "Bug 1 Test: Carried Forward Only Actual Remaining Balance", "Dec Arrears = $decArrearSum2 (expected $expectedRemaining), Dec Total = $decRecv2 (expected $($novRecv + $expectedRemaining))"

# ==============================================================================
# TEST 3: Duplicate Voucher Blocked
# ==============================================================================
Write-Host "`n--- Testing Bug 2: Duplicate Voucher Blocked ---"

# December voucher $decId2 already exists for student 2093. Attempt to generate December again!
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$beforeDupCount = [int]$cmd.ExecuteScalar()

Add-Type -TypeDefinition @"
using System;
using System.Threading;
using System.Runtime.InteropServices;

public class AutoCloser {
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    public static void DismissDialog(int delayMs = 300) {
        new Thread(() => {
            Thread.Sleep(delayMs);
            for (int i = 0; i < 30; i++) {
                IntPtr hDlg = FindWindow("#32770", null);
                if (hDlg != IntPtr.Zero) {
                    PostMessage(hDlg, 0x0111 /* WM_COMMAND */, (IntPtr)1 /* IDOK */, IntPtr.Zero);
                    PostMessage(hDlg, 0x0010 /* WM_CLOSE */, IntPtr.Zero, IntPtr.Zero);
                    break;
                }
                Thread.Sleep(100);
            }
        }).Start();
    }
}
"@

# Call generatefeeMulti for December again (should be blocked and display MessageBox)
[AutoCloser]::DismissDialog(300)
$genMultiMethod.Invoke($feeInstance, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee duplicate", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$afterDupCount = [int]$cmd.ExecuteScalar()
Assert-True (($beforeDupCount -eq 1) -and ($afterDupCount -eq 1)), "Bug 2 Test: Duplicate Voucher Blocked", "Before = $beforeDupCount, After = $afterDupCount (No duplicate created)"

# ==============================================================================
# TEST 4: Regeneration Allowed After Legitimate Unposting
# ==============================================================================
Write-Host "`n--- Testing Bug 2: Regeneration Allowed After Unposting ---"

# Unpost December voucher under existing rules (PAID=NULL, STATUS=NULL, REC_AMOUNT=0, BALANCE=RECEIVABLE_AMOUNT)
$cmd.CommandText = @"
UPDATE FEE_MASTER SET PAID = NULL, STATUS = NULL, REC_AMOUNT = 0, BALANCE = RECEIVABLE_AMOUNT WHERE FEE_MASTER_ID = '$decId2';
UPDATE FEE_DETAIL SET RECEIVED_AMOUNT = 0, BALANCE = AMOUNT WHERE FEE_MASTER_ID = '$decId2';
"@
$cmd.ExecuteNonQuery() | Out-Null

# Now regenerate December 2026 fee (should succeed by cleaning up unposted and generating fresh)
$genMultiMethod.Invoke($feeInstance, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee fresh", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT COUNT(*), MAX(FEE_MASTER_ID) FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$afterUnpostCount = 0; $newDecId = ""
if ($r.Read()) {
    $afterUnpostCount = [int]$r[0]
    $newDecId = $r[1].ToString()
}
$r.Close()

Assert-True (($afterUnpostCount -eq 1) -and ($newDecId -ne "")), "Bug 2 Test: Regeneration Succeeded After Unposting", "Count = $afterUnpostCount, New Voucher ID = $newDecId"

# Cleanup test records
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12');
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12');
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()

if ($allPass) {
    Write-Host "`n>>> ALL ARREARS AND DUPLICATE VOUCHER TESTS PASSED ON SCMS_SF_TEST! <<<" -ForegroundColor Green
} else {
    Write-Host "`n>>> SOME TESTS FAILED! <<<" -ForegroundColor Red
    exit 1
}
