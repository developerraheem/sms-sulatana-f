$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT s_id, s_name, f_name, c_id, branch_id, SessionID, SHIFT, SECTION_ID, active FROM student WHERE s_name LIKE '%AHEEM%'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "Student $($r['s_id']): Name='$($r['s_name'])' Father='$($r['f_name'])' Class=$($r['c_id']) Branch=$($r['branch_id']) Session=$($r['SessionID']) Shift=$($r['SHIFT']) Section=$($r['SECTION_ID']) Active=$($r['active'])"
}
$conn.Close()
