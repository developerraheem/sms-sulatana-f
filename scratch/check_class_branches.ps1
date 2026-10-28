$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Class'"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-Table -AutoSize | Out-String | Write-Output

$cmd.CommandText = "SELECT TOP 10 * FROM Class"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
$dt2 | Format-Table -AutoSize | Out-String | Write-Output

$cmd.CommandText = "SELECT C_ID, count(distinct branch_id) as branch_count FROM FEE_CLASS GROUP BY C_ID HAVING count(distinct branch_id) > 1"
$dt3 = New-Object System.Data.DataTable
$da.Fill($dt3) | Out-Null
Write-Output "Classes with multiple branch_ids in FEE_CLASS: $($dt3.Rows.Count)"
$dt3 | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
