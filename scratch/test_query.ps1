$c = New-Object System.Data.SqlClient.SqlConnection "Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE s_id = 88888"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("s_id=" + $r["s_id"].ToString() + ", c_id=" + $r["c_id"].ToString() + ", SHIFT=" + $r["SHIFT"].ToString() + ", SECTION_ID=" + $r["SECTION_ID"].ToString() + ", branch_id=" + $r["branch_id"].ToString() + ", SessionID=" + $r["SessionID"].ToString() + ", active=" + $r["active"].ToString())
}
$r.Close()
$c.Close()
