$testConnStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$settingsType = $asm.GetType("School.Properties.Settings")
$settingsProp = $settingsType.GetProperty("Default")
$appSettings = $settingsProp.GetValue($null, $null)
$appSettings["sql_conn"] = $testConnStr

$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()

$dsType = $asm.GetType("School.Report_DataSet_new")
$ds = [System.Activator]::CreateInstance($dsType)

$adapterType = $asm.GetType("School.Report_DataSet_newTableAdapters.Fee_Class_updateTableAdapter")
$adapter = [System.Activator]::CreateInstance($adapterType)

$mgrType = $asm.GetType("School.Report_DataSet_newTableAdapters.TableAdapterManager")
$mgr = [System.Activator]::CreateInstance($mgrType)
$mgr.Fee_Class_updateTableAdapter = $adapter

# Load class 169
$adapter.Fill($ds.Fee_Class_update, [decimal]169)
$targetRow = $ds.Fee_Class_update.FindByFEE_CLASS_ID([decimal]52375)
Write-Output "Initial Active: $($targetRow.ACTIVE)"

# Toggle to True
$targetRow.ACTIVE = $true
$res1 = $adapter.Update($ds.Fee_Class_update)
Write-Output "res1 (adapter.Update): $res1"

$res2 = $mgr.UpdateAll($ds)
Write-Output "res2 (mgr.UpdateAll): $res2"

# Now verify in DB
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT ACTIVE FROM FEE_CLASS WHERE FEE_CLASS_ID=52375"
Write-Output "DB value after Update: $($cmd.ExecuteScalar())"

$conn.Close()
