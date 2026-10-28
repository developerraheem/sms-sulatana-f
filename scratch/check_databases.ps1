$conStr = 'Server=(localdb)\MSSQLLocalDB;Database=master;Integrated Security=True;'
$con = New-Object System.Data.SqlClient.SqlConnection($conStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT name FROM sys.databases WHERE name LIKE '%SCMS%'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output $r["name"]
}
$con.Close()
