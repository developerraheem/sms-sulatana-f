$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT branch_id, branch_name FROM Branch ORDER BY branch_id"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["branch_id"].ToString() + " | " + $r["branch_name"].ToString())
}
$r.Close()
$con.Close()
