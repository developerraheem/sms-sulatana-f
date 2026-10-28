$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT branch_id, branch_name FROM Branch"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ($r["branch_id"].ToString() + " : " + $r["branch_name"].ToString())
}
$conn.Close()
