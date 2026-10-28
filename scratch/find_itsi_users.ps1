$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT u_id, u_name, branch_id FROM user_ WHERE u_id LIKE '%ITSI%' OR u_name LIKE '%ITSI%'"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
$ds.Tables[0] | Format-Table
$conn.Close()
