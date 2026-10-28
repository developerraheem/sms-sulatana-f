$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT fc.C_ID, c.c_name, fc.Fee_head_id, fh.Fee_head, fh.Category, fc.AMOUNT, fc.branch_id " +
                   "FROM FEE_CLASS fc " +
                   "INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id " +
                   "INNER JOIN class c ON fc.C_ID = c.c_id " +
                   "WHERE fh.Category IN ('DISCOUNT', 'CONCESSION') OR fh.Fee_head LIKE '%CONCESSION%' " +
                   "ORDER BY fc.branch_id, fc.C_ID"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
$dt | Format-Table -AutoSize

$conn.Close()
