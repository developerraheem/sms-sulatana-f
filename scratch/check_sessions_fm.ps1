$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE FEE_MASTER_ID = '1' AND SessionID = '12'"
Write-Host "Count of FEE_MASTER_ID=1 and SessionID=12:" $cmd.ExecuteScalar()

$cmd.CommandText = "SELECT DISTINCT SessionID FROM FEE_MASTER ORDER BY SessionID"
$r = $cmd.ExecuteReader()
Write-Host "Sessions present in FEE_MASTER:"
while($r.Read()) {
    Write-Host "  Session: '$($r[0])'"
}
$r.Close()
$con.Close()
