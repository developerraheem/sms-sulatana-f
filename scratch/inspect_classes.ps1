$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT C_ID, class_name FROM class WHERE branch_id='2'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["C_ID"].ToString() + " | " + $r["class_name"].ToString())
}
$r.Close()
$con.Close()
