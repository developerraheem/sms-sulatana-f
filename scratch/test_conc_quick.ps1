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

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "2")
$sidConc = "736"
$cidConc = "3"
$shiftConc = "Morning"
$secConc = "Male (A)"
$sessConc = "2"

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc';
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "1. Generating November for Student 736 (with concession)..."
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "11 2026", $shiftConc, $sidConc, 1, "11 2026", "2026-11-10", "1", "0", "Nov Conc", "2026-11-01", "2026-11-01", "2026-11-30", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novConcId = ""; $novConcRecv = 0
if ($r.Read()) {
    $novConcId = $r["FEE_MASTER_ID"].ToString()
    $novConcRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Nov Conc: ID=$novConcId, Recv=$novConcRecv"

Write-Host "2. Generating December for Student 736..."
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "12 2026", $shiftConc, $sidConc, 1, "12 2026", "2026-12-10", "1", "0", "Dec Conc", "2026-12-01", "2026-12-01", "2026-12-31", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decConcId = ""; $decConcRecv = 0
if ($r.Read()) {
    $decConcId = $r["FEE_MASTER_ID"].ToString()
    $decConcRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Dec Conc: ID=$decConcId, Recv=$decConcRecv (expected $( $novConcRecv * 2 ))"

# Post payment on December voucher that covers BOTH December fee and November arrears!
Write-Host "3. Posting payment on December voucher covering BOTH current fee and arrears..."
$submitMethod = $feeType.GetMethod("submitfeeSingle")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postBothRet = $submitMethod.Invoke($feeInstance, @($decConcRecv, $decConcId, $false, [DateTime]'2026-12-05', [DateTime]'2026-12-10', "1", "BT01"))
Write-Host "Post returned: $postBothRet"

# Generate January 2027 fee for student 736: verify January gets 0 arrears!
Write-Host "4. Generating January fee for Student 736..."
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "01 2027", $shiftConc, $sidConc, 1, "01 2027", "2027-01-10", "1", "0", "Jan Conc", "2027-01-01", "2027-01-01", "2027-01-31", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '01 2027'"
$r = $cmd.ExecuteReader()
$janConcId = ""; $janConcRecv = 0
if ($r.Read()) {
    $janConcId = $r["FEE_MASTER_ID"].ToString()
    $janConcRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Jan Conc: ID=$janConcId, Recv=$janConcRecv"

$cmd.CommandText = "SELECT count(*) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$janConcId' AND SessionID = '$sessConc' AND branch_id = '1' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$janArrearRowsCount = [int]$cmd.ExecuteScalar()
Write-Host "Jan Arrear Count: $janArrearRowsCount (expected 0), Jan Total = $janConcRecv (expected $novConcRecv)"

# Cleanup student 736
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc';
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()
Write-Host "Case 6 Test Complete!"
