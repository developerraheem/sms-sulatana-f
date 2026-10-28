$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT c_id, c_name, branch_id FROM class WHERE c_name LIKE '%DIT%'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ($r["c_id"].ToString() + " : " + $r["c_name"].ToString() + " | branch=" + $r["branch_id"].ToString())
}
$conn.Close()
