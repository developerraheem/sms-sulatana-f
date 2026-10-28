$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT Fee_head_id, Fee_head, Category, branch_id FROM Fee_Head WHERE branch_id = 2 OR Fee_head_id IN ('67', '70', '71', '72')"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
$dt | Format-Table -AutoSize

$conn.Close()
