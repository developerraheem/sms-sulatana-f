$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT u_id, pw, branch_id, user_type FROM user_"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "User: u_id='$($r['u_id'])' branch_id='$($r['branch_id'])' user_type='$($r['user_type'])'"
}
$conn.Close()
