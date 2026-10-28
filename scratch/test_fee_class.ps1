$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='FEE_CLASS'"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-Table -AutoSize | Out-String | Write-Output

$cmd.CommandText = "SELECT TOP 20 fc.*, fh.Fee_head FROM FEE_CLASS fc JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fh.Fee_head LIKE '%ADMISSION%'"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
$dt2 | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
