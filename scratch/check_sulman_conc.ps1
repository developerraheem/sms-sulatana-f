$c = New-Object System.Data.SqlClient.SqlConnection "Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT s_id, s_name, CONCESSION_FEE FROM student WHERE s_id = '88888'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Sulman CONCESSION_FEE: " + $r["CONCESSION_FEE"])
}
$r.Close()
$c.Close()
