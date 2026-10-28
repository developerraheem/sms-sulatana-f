$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sysType = $asm.GetType("SYSTEMSETTING")
$sysInst = [System.Activator]::CreateInstance($sysType)

# Check default database before change
$connBefore = $sysInst.db_connect()
Write-Host "Database before override: $($connBefore.Database)"

# Change ConfigurationManager ConnectionStrings["Sqlconn"] in memory via reflection
$csObj = [System.Configuration.ConfigurationManager]::ConnectionStrings["Sqlconn"]
$field = [System.Configuration.ConfigurationElement].GetField("_values", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)

# Or change the connectionString property directly if writable or through reflection
$propField = $csObj.GetType().GetField("_connectionString", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if ($propField) {
    $propField.SetValue($csObj, "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;")
} else {
    # Alternate reflection method on ConfigurationElement
    $bReadOnly = [System.Configuration.ConfigurationElement].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
    $bReadOnly.SetValue($csObj, $false)
    $csObj.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
}

$connAfter = $sysInst.db_connect()
Write-Host "Database after override:  $($connAfter.Database)"
