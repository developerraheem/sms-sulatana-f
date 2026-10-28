$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='FINE_HISTORY'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "$($r['COLUMN_NAME']) : $($r['DATA_TYPE']) ($($r['CHARACTER_MAXIMUM_LENGTH'])) nullable: $($r['IS_NULLABLE'])"
}
$r.Close()
$con.Close()
