$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_CLASS WHERE C_ID = '80'"
Write-Host ("FEE_CLASS count for 80: " + $cmd.ExecuteScalar())

$cmd.CommandText = "SELECT COUNT(*) FROM FEE_CLASS WHERE C_ID = '65'"
Write-Host ("FEE_CLASS count for 65: " + $cmd.ExecuteScalar())

$cmd.CommandText = "SELECT TOP 5 s_id, s_name, ADMISSION_NO, c_id, SHIFT, SECTION_ID FROM student WHERE c_id = '65' AND active='true' AND SessionID='81' AND branch_id='2' ORDER BY s_id"
$r = $cmd.ExecuteReader()
Write-Host "Students in Class 65:"
while ($r.Read()) {
    Write-Host ("s_id=" + $r[0] + ", name=" + $r[1] + ", adm=" + $r[2] + ", cid=" + $r[3] + ", shift=" + $r[4] + ", sec=" + $r[5])
}
$r.Close()
$con.Close()
