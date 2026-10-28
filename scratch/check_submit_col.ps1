$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'FEE_MASTER' AND COLUMN_NAME LIKE '%SUBMIT%'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ($r[0] + " | " + $r[1])
}
$r.Close()
$conn.Close()

