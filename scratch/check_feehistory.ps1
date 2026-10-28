$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, COLUMNPROPERTY(object_id('FEE_HISTORY'), COLUMN_NAME, 'IsIdentity') as IsIdentity FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'FEE_HISTORY'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ($r[0] + " | " + $r[1] + " | Identity=" + $r[2])
}
$r.Close()
$conn.Close()
