$ErrorActionPreference = "Stop"

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
$genMulti = $feeType.GetMethod("generatefeeMulti")

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$sid = "2093"
$cid = "64"

# Clean test student 2093 session 12 records
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "--- SCENARIO 1: PARTIALLY PAID NOVEMBER VOUCHER ---"
# Step 1: Generate November 2026
$genMulti.Invoke($feeInstance, @($cid, "11 2026", "Morning", $sid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

# Inspect November
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId = ""
$novRecv = 0
if ($r.Read()) {
    $novId = $r["FEE_MASTER_ID"].ToString()
    $novRecv = [double]$r["RECEIVABLE_AMOUNT"]
    Write-Host "Step 1 - November Generated: ID=$novId, Month=$($r['FEE_MONTH']), Receivable=$novRecv, Paid='$($r['PAID'])'"
}
$r.Close()

# Step 2: Record Partial Payment of Rs. 3,000 on November
$paidAmt = 3000.0
$remBal = $novRecv - $paidAmt
$cmd.CommandText = "UPDATE FEE_MASTER SET REC_AMOUNT = '$paidAmt', BALANCE = '$remBal', PAID = 'Y', STATUS = 'Y' WHERE FEE_MASTER_ID = '$novId' AND SessionID = '12'"
$cmd.ExecuteNonQuery() | Out-Null
Write-Host "Step 2 - Recorded partial payment: Paid=$paidAmt, Remaining Balance=$remBal, Status=PAID='Y'"

# Step 3: Generate December 2026 (instantiate new FEE matching UI form behavior)
$feeInstance = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeInstance, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

# Step 4: Inspect December voucher and carried arrears
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId = ""; $decRecv = 0; $decBal = 0
if ($r.Read()) {
    $decId = $r["FEE_MASTER_ID"].ToString()
    $decRecv = [double]$r["RECEIVABLE_AMOUNT"]
    $decBal = [double]$r["BALANCE"]
    Write-Host "Step 3 - December Generated: ID=$decId, Month=$($r['FEE_MONTH']), Receivable=$decRecv, Balance=$decBal"
}
$r.Close()

$cmd.CommandText = @"
SELECT d.FEE_DETAIL_ID, d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT
FROM FEE_DETAIL d
LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.FEE_MASTER_ID = '$decId' AND d.SessionID = '12'
ORDER BY d.FEE_DETAIL_ID
"@
$r = $cmd.ExecuteReader()
$decArrears = 0
while($r.Read()) {
    Write-Host "  Detail: Head='$($r['Fee_head'])', Cat='$($r['Category'])', Amt=$($r['AMOUNT']), IsCurrent='$($r['ISCURRENT'])'"
    if ($r["Category"] -eq "ARREAR" -or $r["Fee_head"] -like "*ARREAR*") {
        $decArrears = [double]$r["AMOUNT"]
    }
}
$r.Close()

# Step 5: Check November voucher PAID status after carry-forward
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE FEE_MASTER_ID = '$novId' AND SessionID = '12'"
$r = $cmd.ExecuteReader()
$novAfterPaid = ""
if ($r.Read()) {
    $novAfterPaid = $r["PAID"].ToString()
    Write-Host "Step 4 - November Status Check: PAID='$novAfterPaid' (must remain 'Y'), Balance=$($r['BALANCE'])"
}
$r.Close()

# Verification assessment
Write-Host "`n--- SCENARIO 1 RESULTS ---"
Write-Host "Expected Carried Arrears: $remBal"
Write-Host "Actual Carried Arrears:   $decArrears"
Write-Host "November Status:          PAID='$novAfterPaid'"

if ($decArrears -eq $remBal -and $novAfterPaid -eq "Y" -and $decRecv -eq ($novRecv + $remBal)) {
    Write-Host "SCENARIO 1 RESULT: PASS" -ForegroundColor Green
} else {
    Write-Host "SCENARIO 1 RESULT: FAIL" -ForegroundColor Red
}

$con.Close()
