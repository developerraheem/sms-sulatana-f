$testConnStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

# Override Settings.Default["sql_conn"]
$settingsType = $asm.GetType("School.Properties.Settings")
$settingsProp = $settingsType.GetProperty("Default")
$appSettings = $settingsProp.GetValue($null, $null)
$appSettings["sql_conn"] = $testConnStr

$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()

# Let's find a row in FEE_CLASS where ISMULTIPLY is 1 (True)
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT TOP 5 FEE_CLASS_ID, Fee_head_id, C_ID, AMOUNT, ACTIVE, ISMULTIPLY FROM FEE_CLASS WHERE ISMULTIPLY = 1"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Output "Rows with ISMULTIPLY=1:"
$dt | Format-Table -AutoSize | Out-String | Write-Output

$dsType = $asm.GetType("School.Report_DataSet_new")
$ds = [System.Activator]::CreateInstance($dsType)

$adapterType = $asm.GetType("School.Report_DataSet_newTableAdapters.Fee_Class_updateTableAdapter")
$adapter = [System.Activator]::CreateInstance($adapterType)

# Fill class of the first row
$testCid = [decimal]$dt.Rows[0]["C_ID"]
$testFcid = [decimal]$dt.Rows[0]["FEE_CLASS_ID"]
$adapter.Fill($ds.Fee_Class_update, $testCid)

$targetRow = $ds.Fee_Class_update.FindByFEE_CLASS_ID($testFcid)
Write-Output "Found target row: FEE_CLASS_ID=$($targetRow.FEE_CLASS_ID), Active=$($targetRow.ACTIVE), ISMULTIPLY=$($targetRow.ISMULTIPLY)"

# Toggle ACTIVE
$targetRow.ACTIVE = -not $targetRow.ACTIVE
Write-Output "Toggled ACTIVE to: $($targetRow.ACTIVE)"

try {
    $updated = $adapter.Update($ds.Fee_Class_update)
    Write-Output "Adapter Update result: $updated"
} catch {
    Write-Output "Adapter Update EXCEPTION: $($_.Exception.ToString())"
}

# Toggle it back
$targetRow.ACTIVE = -not $targetRow.ACTIVE
$updated2 = $adapter.Update($ds.Fee_Class_update)
Write-Output "Restored ACTIVE, result: $updated2"

$conn.Close()
