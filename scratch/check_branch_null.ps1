$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = 'SELECT count(*) FROM Fee_Head WHERE branch_id IS NULL OR branch_id = 0'
Write-Output "Null or 0 branch_id in Fee_Head: $($cmd.ExecuteScalar())"
$conn.Close()
