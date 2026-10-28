$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME='FEE_MASTER'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "$($r['CONSTRAINT_NAME']) : $($r['CONSTRAINT_TYPE'])"
}
$r.Close()

$cmd.CommandText = "SELECT MAX(CONVERT(BIGINT, FEE_MASTER_ID)) as MaxAll, MAX(CASE WHEN SESSIONID=78 THEN CONVERT(BIGINT, FEE_MASTER_ID) END) as MaxSession78 FROM FEE_MASTER"
$r2 = $cmd.ExecuteReader()
while ($r2.Read()) {
    Write-Host "MaxAll: $($r2['MaxAll']) | MaxSession78: $($r2['MaxSession78'])"
}
$r2.Close()
$con.Close()
