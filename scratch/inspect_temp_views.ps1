$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()

$cmd.CommandText = "SELECT TABLE_NAME, TABLE_TYPE FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME IN ('Temp', 'TempDetail')"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
$dt | Format-Table -AutoSize | Out-String | Write-Host

$cmd.CommandText = "SELECT VIEW_DEFINITION FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'Temp'"
$viewDefTemp = $cmd.ExecuteScalar()
Write-Host "=== VIEW Temp ==="
Write-Host $viewDefTemp

$cmd.CommandText = "SELECT VIEW_DEFINITION FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME = 'TempDetail'"
$viewDefTempDetail = $cmd.ExecuteScalar()
Write-Host "=== VIEW TempDetail ==="
Write-Host $viewDefTempDetail

$conn.Close()
