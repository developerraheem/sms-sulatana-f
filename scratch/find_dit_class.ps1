$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM class WHERE c_name LIKE '%DIT%'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "Class: c_id=$($r['c_id']) c_name=$($r['c_name']) branch_id=$($r['branch_id'])"
}
$conn.Close()
