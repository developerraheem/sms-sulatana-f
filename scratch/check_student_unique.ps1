$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT s_id, branch_id, COUNT(*) as cnt FROM student GROUP BY s_id, branch_id HAVING COUNT(*) > 1"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
Write-Host "Duplicate (s_id, branch_id) count:" $ds.Tables[0].Rows.Count
$conn.Close()
