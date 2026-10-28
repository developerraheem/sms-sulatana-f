$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 20 FEE_MONTH, COUNT(*) FROM FEE_MASTER GROUP BY FEE_MONTH ORDER BY COUNT(*) DESC"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FEE_MONTH:" "'$($r[0])'" "Count:" $r[1]
}
$r.Close()
$con.Close()
