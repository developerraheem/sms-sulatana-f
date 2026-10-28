$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $connStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sysType = $asm.GetType("SYSTEMSETTING")
$sysInst = [System.Activator]::CreateInstance($sysType)
$dbConn = $sysInst.db_connect()
Write-Host "Connected DB: $($dbConn.Database)"
$dbConn.Close()

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "78")

try {
    Write-Host "Creating FEE instance..."
    $fee = New-Object School._class.FEE
    Write-Host "Calling generatefeeMulti..."
    $fee.generatefeeMulti("169", "09 2026", "Morning", "22659", 1, "09 2026", "10/10/2026", "1", "0", "Test voucher", "01/09/2026", "01/09/2026", "31/10/2026", "Female")
    Write-Host "generatefeeMulti completed successfully!"
} catch {
    Write-Host "Exception caught: $($_.Exception.ToString())"
}
