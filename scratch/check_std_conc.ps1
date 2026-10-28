$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM student WHERE CONCESSION_FEE IS NOT NULL AND CONCESSION_FEE > 0 AND branch_id='2'"
$cnt = $cmd.ExecuteScalar()
Write-Output "Branch 2 students with CONCESSION_FEE > 0: $cnt"

$cmd.CommandText = "SELECT TOP 5 s_id, s_name, CONCESSION_FEE, CONCESSION_REASON FROM student WHERE CONCESSION_FEE IS NOT NULL AND CONCESSION_FEE > 0 AND branch_id='2'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("s_id=" + $r["s_id"] + ", name=" + $r["s_name"] + ", amt=" + $r["CONCESSION_FEE"] + ", reason=" + $r["CONCESSION_REASON"])
}
$r.Close()
$con.Close()
