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

$feeInstance = [System.Activator]::CreateInstance($feeType)
$submitMethod = $feeType.GetMethod("submitfeeSingle")

Write-Host "About to invoke submitfeeSingle..."
try {
    $ret = $submitMethod.Invoke($feeInstance, @([double]3000.0, "1", $false, [DateTime]'2026-11-05', [DateTime]'2026-11-10', "1", "SCR001"))
    Write-Host "submitfeeSingle returned: $ret"
} catch {
    Write-Host "Exception: $($_.Exception.ToString())"
}
