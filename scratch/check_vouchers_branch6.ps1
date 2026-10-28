$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT TOP 20 * FROM FEE_MASTER WHERE branch_id = 6 AND SessionID = 68 ORDER BY FEE_MASTER_ID DESC"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
$ds.Tables[0] | Format-Table FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS
$conn.Close()
