$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE branch_id = 6 AND SessionID = '68' AND s_name LIKE '%AHEEM%'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "Student $($r['s_id']): Name='$($r['s_name'])' c_id=$($r['c_id'])"
}
$conn.Close()
