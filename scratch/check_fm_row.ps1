$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 1 DUE_DATE, ISSUE_DATE, startdate, enddate FROM FEE_MASTER WHERE DUE_DATE IS NOT NULL"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("DUE_DATE=" + $r[0] + " | ISSUE_DATE=" + $r[1] + " | startdate=" + $r[2] + " | enddate=" + $r[3])
}
$r.Close()
$con.Close()
