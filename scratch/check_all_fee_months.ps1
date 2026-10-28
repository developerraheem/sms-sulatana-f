$c = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT DISTINCT TOP 50 FEE_MONTH FROM FEE_MASTER WHERE FEE_MONTH IS NOT NULL AND FEE_MONTH <> ''"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FEE_MONTH: '$($r[0])'"
}
$r.Close()
$c.Close()
