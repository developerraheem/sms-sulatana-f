$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT ISNULL(ISCURRENT, '<NULL>') as ISCURR, COUNT(*) as cnt FROM FEE_DETAIL GROUP BY ISCURRENT"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "ISCURRENT:" $r[0] "Count:" $r[1]
}
$r.Close()
$con.Close()
