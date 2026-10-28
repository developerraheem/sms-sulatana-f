$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT c_id, c_name FROM class WHERE c_id in ('65', '8', '9')"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["c_id"].ToString() + " = " + $r["c_name"].ToString())
}
$con.Close()
