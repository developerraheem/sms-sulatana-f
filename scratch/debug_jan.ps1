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

$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "11 2026", $shiftConc, $sidConc, 1, "11 2026", "2026-11-10", "1", "0", "Nov Conc", "2026-11-01", "2026-11-01", "2026-11-30", $secConc))
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "12 2026", $shiftConc, $sidConc, 1, "12 2026", "2026-12-10", "1", "0", "Dec Conc", "2026-12-01", "2026-12-01", "2026-12-31", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decConcId = ""; $decConcRecv = 0
if ($r.Read()) {
    $decConcId = $r["FEE_MASTER_ID"].ToString()
    $decConcRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

# Post on December
$submitMethod = $feeType.GetMethod("submitfeeSingle")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$submitMethod.Invoke($feeInstance, @($decConcRecv, $decConcId, $false, [DateTime]'2026-12-05', [DateTime]'2026-12-10', "1", "BT01"))

# Check GetPreviousOutstandingArrears for Jan 2027
$outstanding = $feeType.GetMethod("GetPreviousOutstandingArrears").Invoke($feeInstance, @($sidConc, "01 2027", "", "1", $sessConc))
Write-Host "Outstanding arrears computed for Jan 2027: $outstanding"

# Generate Jan 2027
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "01 2027", $shiftConc, $sidConc, 1, "01 2027", "2027-01-10", "1", "0", "Jan Conc", "2027-01-01", "2027-01-01", "2027-01-31", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '01 2027'"
$r = $cmd.ExecuteReader()
$janId = ""; $janRecv = 0
if ($r.Read()) {
    $janId = $r["FEE_MASTER_ID"].ToString()
    $janRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Jan ID: $janId, Jan Recv: $janRecv"

$cmd.CommandText = "SELECT d.Fee_head_id, h.Fee_head, d.AMOUNT, d.ISCURRENT, d.BALANCE FROM FEE_DETAIL d LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID = '$janId' AND d.SessionID = '$sessConc'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "  Detail: Head=$($r['Fee_head_id']) ($($r['Fee_head'])) Amount=$($r['AMOUNT']) ISCURRENT=$($r['ISCURRENT'])"
}
$r.Close()

$con.Close()
