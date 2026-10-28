$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT s_id, s_name, ADMISSION_NO, roll_no, c_id, section_id FROM student WHERE s_id IN ('22578', '22583')"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("s_id=" + $r["s_id"] + ", name=" + $r["s_name"] + ", ADM=" + $r["ADMISSION_NO"] + ", roll=" + $r["roll_no"] + ", c_id=" + $r["c_id"] + ", section_id=" + $r["section_id"])
}
$con.Close()
