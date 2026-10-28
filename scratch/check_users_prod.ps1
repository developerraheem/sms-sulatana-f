$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT u_id, branch_id, user_type FROM user_"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("user=" + $r["u_id"] + " | branch_id=" + $r["branch_id"] + " | user_type=" + $r["user_type"])
}
$conn.Close()
