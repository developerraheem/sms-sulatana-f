$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 5 s.s_id, s.ADMISSION_NO, s.s_name, s.c_id, s.SHIFT, s.SECTION_ID, s.SessionID, s.branch_id FROM student s WHERE s.active='true' AND s.branch_id=1 ORDER BY s.s_id DESC"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "sid: $($r['s_id']) | adm: $($r['ADMISSION_NO']) | name: $($r['s_name']) | cid: $($r['c_id']) | shift: $($r['SHIFT']) | sec: $($r['SECTION_ID']) | sess: $($r['SessionID']) | br: $($r['branch_id'])"
}
$r.Close()
$con.Close()
