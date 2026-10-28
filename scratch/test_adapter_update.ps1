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

# Also check Settings.Default.sql_conn
$settingsType = $asm.GetType("School.Properties.Settings")
$settingsProp = $settingsType.GetProperty("Default")
$appSettings = $settingsProp.GetValue($null, $null)
$appSettings["sql_conn"] = $testConnStr

$dsType = $asm.GetType("School.Report_DataSet_new")
$ds = [System.Activator]::CreateInstance($dsType)

$adapterType = $asm.GetType("School.Report_DataSet_newTableAdapters.Fee_Class_updateTableAdapter")
$adapter = [System.Activator]::CreateInstance($adapterType)
$adapter.Connection = New-Object System.Data.SqlClient.SqlConnection($testConnStr)

$mgrType = $asm.GetType("School.Report_DataSet_newTableAdapters.TableAdapterManager")
$mgr = [System.Activator]::CreateInstance($mgrType)
$mgr.Fee_Class_updateTableAdapter = $adapter
$mgr.Connection = New-Object System.Data.SqlClient.SqlConnection($testConnStr)

# Let's find a class with ADMISSION FEE in SCMS_SF_TEST
# From our earlier query:
# FEE_CLASS_ID=11724, Fee_head_id=46, C_ID=35, AMOUNT=4000, ACTIVE=True, branch_id=11
$classId = [decimal]35
$filled = $adapter.Fill($ds.Fee_Class_update, $classId)
Write-Output "Filled $filled rows for class $classId"

foreach ($row in $ds.Fee_Class_update.Rows) {
    Write-Output "ID: $($row.FEE_CLASS_ID) | Head: $($row.Fee_head_id) | Type: $($row.TYPE) | Active: $($row.ACTIVE) | Multiply: $($row.ISMULTIPLY)"
}

# Now let's try toggling ACTIVE on row with FEE_CLASS_ID=11724
$targetRow = $ds.Fee_Class_update.FindByFEE_CLASS_ID([decimal]11724)
if ($targetRow) {
    Write-Output "Target row found! Current Active: $($targetRow.ACTIVE)"
    $targetRow.ACTIVE = -not $targetRow.ACTIVE
    Write-Output "Toggled Active to: $($targetRow.ACTIVE)"
    
    try {
        $updated = $mgr.UpdateAll($ds)
        Write-Output "UpdateAll result: $updated"
    } catch {
        Write-Output "Exception in UpdateAll: $($_.Exception.ToString())"
    }
}
