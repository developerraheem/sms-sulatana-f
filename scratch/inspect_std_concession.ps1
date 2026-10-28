$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT s_id, s_name, CONCESSION_FEE FROM student WHERE s_id in ('22578', '22583', '22579')"
$r = $cmd.ExecuteReader()
Write-Output "--- Student Concession Fields ---"
while ($r.Read()) {
    Write-Output ("s_id=" + $r["s_id"] + ", name=" + $r["s_name"] + ", CONCESSION_FEE=" + $r["CONCESSION_FEE"])
}
$r.Close()
$con.Close()
