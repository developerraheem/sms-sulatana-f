$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 10 s_id, branch_id, SessionID, c_id, SHIFT, SECTION_ID, active, CONCESSION_FEE FROM student WHERE active = 'true' AND CONCESSION_FEE > 0 ORDER BY branch_id, s_id"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "s_id: $($r['s_id']), branch: $($r['branch_id']), session: $($r['SessionID']), c_id: $($r['c_id']), shift: $($r['SHIFT']), sec: $($r['SECTION_ID']), conc: $($r['CONCESSION_FEE'])"
}
$r.Close()
$con.Close()
