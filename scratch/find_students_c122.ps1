$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE c_id = 122"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "Student $($r['s_id']): Name='$($r['s_name'])' Father='$($r['f_name'])' Section='$($r['SECTION_ID'])' Shift='$($r['SHIFT'])' SessionID='$($r['SessionID'])' Branch='$($r['branch_id'])' Active='$($r['active'])'"
}
$conn.Close()
