$ErrorActionPreference = "Stop"

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

Write-Host "--- SCENARIO 2: FULLY PAID NOVEMBER VOUCHER ---"
# Step 1: Generate November 2026
$feeInstance = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeInstance, @($cid, "11 2026", "Morning", $sid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId = ""; $novRecv = 0
if ($r.Read()) {
    $novId = $r["FEE_MASTER_ID"].ToString()
    $novRecv = [double]$r["RECEIVABLE_AMOUNT"]
    Write-Host "Step 1 - November Generated: ID=$novId, Receivable=$novRecv"
}
$r.Close()

# Step 2: Record FULL payment of Rs. 9,000 on November
$cmd.CommandText = "UPDATE FEE_MASTER SET REC_AMOUNT = '$novRecv', BALANCE = 0, PAID = 'Y', STATUS = 'Y' WHERE FEE_MASTER_ID = '$novId' AND SessionID = '12'"
$cmd.ExecuteNonQuery() | Out-Null
Write-Host "Step 2 - Recorded FULL payment: Paid=$novRecv, Balance=0, Status=PAID='Y'"

# Step 3: Generate December 2026 (fresh FEE instance matching UI)
$feeInstance = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeInstance, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

# Step 4: Inspect December voucher
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId = ""; $decRecv = 0
if ($r.Read()) {
    $decId = $r["FEE_MASTER_ID"].ToString()
    $decRecv = [double]$r["RECEIVABLE_AMOUNT"]
    Write-Host "Step 3 - December Generated: ID=$decId, Receivable=$decRecv"
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
$decArrearRows = 0
while($r.Read()) {
    Write-Host "  Detail: Head='$($r['Fee_head'])', Cat='$($r['Category'])', Amt=$($r['AMOUNT']), IsCurrent='$($r['ISCURRENT'])'"
    if ($r["Category"] -eq "ARREAR" -or $r["Fee_head"] -like "*ARREAR*") {
        $decArrearRows++
    }
}
$r.Close()

# Step 5: Check November status
$cmd.CommandText = "SELECT PAID, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$novId' AND SessionID = '12'"
$r = $cmd.ExecuteReader()
$novAfterPaid = ""; $novAfterBal = 0
if ($r.Read()) {
    $novAfterPaid = $r["PAID"].ToString()
    $novAfterBal = [double]$r["BALANCE"]
    Write-Host "Step 4 - November Status: PAID='$novAfterPaid', Balance=$novAfterBal"
}
$r.Close()

Write-Host "`n--- SCENARIO 2 RESULTS ---"
Write-Host "December Arrear Rows: $decArrearRows (expected 0)"
Write-Host "December Receivable:  $decRecv (expected $novRecv)"
Write-Host "November Status:      PAID='$novAfterPaid' (must remain 'Y')"

if ($decArrearRows -eq 0 -and $decRecv -eq $novRecv -and $novAfterPaid -eq "Y" -and $novAfterBal -eq 0) {
    Write-Host "SCENARIO 2 RESULT: PASS" -ForegroundColor Green
} else {
    Write-Host "SCENARIO 2 RESULT: FAIL" -ForegroundColor Red
}

$con.Close()
