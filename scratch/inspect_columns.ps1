$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$tables = @('student', 'class', 'FEE_MASTER', 'Sections', 'FEE_DETAIL')
foreach ($t in $tables) {
    Write-Output ("=== Table: $t ===")
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '$t'"
    $da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    $dt = New-Object System.Data.DataTable
    [void]$da.Fill($dt)
    $dt | Format-Table -AutoSize | Out-String | Write-Output
}
$conn.Close()
