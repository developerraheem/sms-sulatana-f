$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT TOP 5 * FROM branch; SELECT TOP 5 * FROM Sessions"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
Write-Host "BRANCH:"
$ds.Tables[0] | Format-Table
Write-Host "SESSIONS:"
$ds.Tables[1] | Format-Table
$conn.Close()
