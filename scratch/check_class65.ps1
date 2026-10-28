$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT fc.*, fh.Fee_head, fh.Category FROM FEE_CLASS fc LEFT JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.c_id = 65"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
$dt | Format-Table -AutoSize

$conn.Close()
