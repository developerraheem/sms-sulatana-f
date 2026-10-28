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

# Clean student 2093 session 12 records
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "--- SCENARIO 7: VOUCHER PRINTING & REPORT OUTPUT (TempDetail JOIN) ---"
# Generate November (unpaid Rs. 9,000)
$feeNov = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeNov, @($cid, "11 2026", "Morning", $sid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

# Generate December
$feeDec = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeDec, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '12 2026'"
$decId = $cmd.ExecuteScalar().ToString()

# Query TempDetail view for December voucher
$cmd.CommandText = @"
SELECT Fee_head, AMOUNT, SessionID, sort_id
FROM TempDetail
WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12'
ORDER BY sort_id
"@
$r = $cmd.ExecuteReader()
$viewRows = @()
while($r.Read()) {
    $viewRows += @{
        Head = $r["Fee_head"].ToString()
        Amount = [double]$r["AMOUNT"]
        Session = $r["SessionID"].ToString()
    }
}
$r.Close()

Write-Host "TempDetail view contents for December voucher ID $($decId):"
$arrearFound = $false
foreach ($vr in $viewRows) {
    Write-Host "  Head: '$($vr.Head)', Amount: $($vr.Amount)"
    if ($vr.Head -like "*ARREAR*") {
        $arrearFound = $true
        $arrearAmt = $vr.Amount
    }
}

Write-Host "`n--- SCENARIO 7 RESULTS ---"
Write-Host "Total View Lines: $($viewRows.Count)"
Write-Host "Arrears Line Found in Report View: $arrearFound (Amount = $arrearAmt)"

$pass = ($viewRows.Count -gt 0) -and $arrearFound -and ($arrearAmt -eq 9000)
if ($pass) {
    Write-Host "SCENARIO 7 RESULT: PASS - Arrears line item successfully joined and visible in TempDetail report view." -ForegroundColor Green
} else {
    Write-Host "SCENARIO 7 RESULT: FAIL" -ForegroundColor Red
}

$con.Close()
