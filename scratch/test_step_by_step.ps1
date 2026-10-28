$ErrorActionPreference = "Stop"
Write-Host "1. Initializing in-memory connection override..."
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

Write-Host "2. Loading assembly..."
$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")
$sid1 = "2093"
$cid1 = "64"

Write-Host "3. Connecting to SQL and cleaning..."
$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()

Write-Host "4. Generating November..."
$genMulti = $feeType.GetMethod("generatefeeMulti")
$genMulti.Invoke($feeInstance, @($cid1, "11 2026", "Morning", $sid1, 1, "11 2026", "2026-11-10", "1", "0", "Nov fee", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

Write-Host "5. Checking November..."
$con.Open()
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId = ""
$novRecv = 0
if ($r.Read()) {
    $novId = $r["FEE_MASTER_ID"].ToString()
    $novRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
$con.Close()
Write-Host "Nov ID=$novId, Recv=$novRecv"

Write-Host "6. Generating December (new instance matching UI)..."
$feeInstance2 = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeInstance2, @($cid1, "12 2026", "Morning", $sid1, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

Write-Host "7. Checking December..."
$con.Open()
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId = ""; $decRecv = 0
if ($r.Read()) {
    $decId = $r["FEE_MASTER_ID"].ToString()
    $decRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
$con.Close()
Write-Host "Dec ID=$decId, Recv=$decRecv"

Write-Host "8. Calling submitfeeSingle for partial payment (3000)..."
$feeInstance3 = [System.Activator]::CreateInstance($feeType)
$submitMethod = $feeType.GetMethod("submitfeeSingle")
$ret = $submitMethod.Invoke($feeInstance3, @([double]3000.0, $novId, $false, [DateTime]'2026-11-05', [DateTime]'2026-11-10', "1", "SCR001"))
Write-Host "submitfeeSingle returned: $ret"

Write-Host "9. Checking December arrears after partial payment..."
$con.Open()
$cmd.CommandText = "SELECT Fee_head_id, AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "Dec Arrear Head = $($r['Fee_head_id']), Amount = $($r['AMOUNT'])"
}
$r.Close()
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$decId'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "Dec Master Recv = $($r['RECEIVABLE_AMOUNT']), Bal = $($r['BALANCE'])"
}
$r.Close()
$con.Close()

Write-Host "10. Step-by-step test finished successfully!"
