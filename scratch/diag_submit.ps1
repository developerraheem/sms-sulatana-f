$ErrorActionPreference = "Stop"
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$feeType = $asm.GetType("School._class.FEE")

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 1 FEE_MASTER_ID, s_id, FEE_MONTH FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId = ""
if ($r.Read()) { $novId = $r[0].ToString() }
$r.Close()
$con.Close()

Write-Host "Found Nov ID=$novId. Testing RecalculateStudentArrears directly..."
$feeInstance = [System.Activator]::CreateInstance($feeType)
$recalcMethod = $feeType.GetMethod("RecalculateStudentArrears")
$recalcMethod.Invoke($feeInstance, @("2093", "1", "12"))
Write-Host "RecalculateStudentArrears executed successfully!"
