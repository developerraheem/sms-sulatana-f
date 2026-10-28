$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT i.name as index_name, i.is_unique, i.is_primary_key, c.name as column_name FROM sys.indexes i INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id WHERE i.object_id = OBJECT_ID('FEE_MASTER')"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "Index: $($r['index_name']) | Unique: $($r['is_unique']) | PK: $($r['is_primary_key']) | Col: $($r['column_name'])"
}
$r.Close()
$con.Close()
