$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT s_id, branch_id, SessionID, c_id, SHIFT, SECTION_ID, active, CONCESSION_FEE FROM student WHERE s_id = '2093'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "s_id:" $r["s_id"] "branch:" $r["branch_id"] "session:" $r["SessionID"] "c_id:" $r["c_id"] "shift:" $r["SHIFT"] "sec:" $r["SECTION_ID"] "active:" $r["active"] "conc:" $r["CONCESSION_FEE"]
}
$r.Close()
$con.Close()
