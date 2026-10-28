$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) as std_diff_session FROM student WHERE branch_id = 6 AND SessionID <> 68"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
Write-Host "Students in branch 6 with SessionID <> 68:" $ds.Tables[0].Rows[0]["std_diff_session"]
$conn.Close()
