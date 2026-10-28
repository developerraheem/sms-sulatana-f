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

$sysType.GetField("branch_ID").SetValue($null, "6")
$sysType.GetField("sessionid").SetValue($null, "7")
$sid6 = "1816"
$cid6 = "43"
$shift6 = "Evening"
$sec6 = "Girls"
$sess6 = "7"

# Clean student 1816
$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6';
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "1. Generating November for Branch 6..."
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cid6, "11 2026", $shift6, $sid6, 1, "11 2026", "2026-11-10", "1", "0", "Nov B6", "2026-11-01", "2026-11-01", "2026-11-30", $sec6))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6' AND branch_id = '6' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId6 = ""; $novRecv6 = 0
if ($r.Read()) {
    $novId6 = $r["FEE_MASTER_ID"].ToString()
    $novRecv6 = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Nov B6: ID=$novId6, Recv=$novRecv6"

Write-Host "2. Generating December for Branch 6..."
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cid6, "12 2026", $shift6, $sid6, 1, "12 2026", "2026-12-10", "1", "0", "Dec B6", "2026-12-01", "2026-12-01", "2026-12-31", $sec6))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6' AND branch_id = '6' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId6 = ""; $decRecv6 = 0
if ($r.Read()) {
    $decId6 = $r["FEE_MASTER_ID"].ToString()
    $decRecv6 = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Dec B6: ID=$decId6, Recv=$decRecv6"

$cmd.CommandText = "SELECT Fee_head_id, AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6' AND ISCURRENT = 'N'"
$r = $cmd.ExecuteReader()
$decArrearAmt6 = 0; $decArrearHead6 = ""
if ($r.Read()) {
    $decArrearHead6 = $r["Fee_head_id"].ToString()
    $decArrearAmt6 = [double]$r["AMOUNT"]
}
$r.Close()
Write-Host "Dec B6 Arrears: Head=$decArrearHead6, Amount=$decArrearAmt6 (expected $novRecv6)"

# Partial payment of 1500
Write-Host "3. Posting partial payment of 1500 on Nov B6..."
$submitMethod = $feeType.GetMethod("submitfeeSingle")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postPartialRet = $submitMethod.Invoke($feeInstance, @([double]1500.0, $novId6, $false, [DateTime]'2026-11-05', [DateTime]'2026-11-10', "1", "B601"))

$cmd.CommandText = "SELECT AMOUNT, Fee_head_id FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6' AND (ISCURRENT = 'N' OR Fee_head_id = '103')"
$r = $cmd.ExecuteReader()
$decB6ArrearAfterPartial = 0; $decB6HeadAfterPartial = ""
if ($r.Read()) {
    $decB6ArrearAfterPartial = [double]$r["AMOUNT"]
    $decB6HeadAfterPartial = $r["Fee_head_id"].ToString()
}
$r.Close()
$expBal = $novRecv6 - 1500
Write-Host "Dec B6 Arrears after partial: Head=$decB6HeadAfterPartial, Amount=$decB6ArrearAfterPartial (expected $expBal)"

# Full payment
Write-Host "4. Posting full payment on Nov B6..."
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postFullRet = $submitMethod.Invoke($feeInstance, @([double]$novRecv6, $novId6, $false, [DateTime]'2026-11-09', [DateTime]'2026-11-10', "1", "B602"))

$cmd.CommandText = "SELECT count(*) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6' AND (ISCURRENT = 'N' OR Fee_head_id = '103')"
$b6ArrearCountAfterFull = [int]$cmd.ExecuteScalar()

$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6'"
$decB6RecvAfterFull = [double]$cmd.ExecuteScalar()

Write-Host "Dec B6 Arrears Count after full: $b6ArrearCountAfterFull (expected 0), Dec Total = $decB6RecvAfterFull (expected $novRecv6)"

# Cleanup student 1816
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6';
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()

Write-Host "Branch 6 Test Complete!"
