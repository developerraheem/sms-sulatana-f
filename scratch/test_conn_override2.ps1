$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
Write-Host "Count: $($settings.Count)"
$cs = $settings["Sqlconn"]
Write-Host "Type: $($cs.GetType().FullName)"

# Make collection editable
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
Write-Host "Collection read-only field: $($bReadOnlyField.Name)"
$bReadOnlyField.SetValue($settings, $false)

# Create new ConnectionStringSettings pointing to SCMS_SF_TEST
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;", "System.Data.SqlClient")

$settings.Remove("Sqlconn")
$settings.Add($newCs)

# Now check
$check = [System.Configuration.ConfigurationManager]::ConnectionStrings["Sqlconn"]
Write-Host "New connection string: $($check.ConnectionString)"

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$sysInst = [System.Activator]::CreateInstance($sysType)
$dbConn = $sysInst.db_connect()
Write-Host "Verified db_connect() database: $($dbConn.Database)"
$dbConn.Close()
