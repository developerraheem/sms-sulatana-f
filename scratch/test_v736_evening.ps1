$binPath = (Resolve-Path 'bin\Debug\School.exe').Path
$asm = [System.Reflection.Assembly]::LoadFrom($binPath)

$dsType = $asm.GetType('School.Report_DataSet_new')
$ds = [Activator]::CreateInstance($dsType)

$fhAdapterType = $asm.GetType('School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter')
$fhAdapter = [Activator]::CreateInstance($fhAdapterType)
$prop = $fhAdapterType.GetProperty('Connection', [System.Reflection.BindingFlags]'Instance,NonPublic,Public')
$conn = $prop.GetValue($fhAdapter, $null)
$conn.ConnectionString = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'

$table = $ds.Tables['FEE_HISTORY']
$fhAdapter.Fill($table, "161", "Evening", "07 2025", 49) | Out-Null
$v736 = $table.Select("FEE_MASTER_ID = 736")
Write-Host ("Voucher 736 (Evening Shift) retrieved: " + ($v736.Length -eq 1) + " (Count=" + $v736.Length + ")")
if ($v736.Length -gt 0) {
    Write-Host ("Student: " + $v736[0]["s_name"] + ", Class: " + $v736[0]["c_name"] + ", Due: " + $v736[0]["RECEIVABLE_AMOUNT"] + ", Bal: " + $v736[0]["BALANCE"])
}
