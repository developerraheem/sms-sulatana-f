$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, COLUMNPROPERTY(object_id('FEE_MASTER'), COLUMN_NAME, 'IsIdentity') as IsIdentity FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'FEE_MASTER'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ($r[0] + " | " + $r[1] + " | Identity=" + $r[2])
}
$r.Close()
$con.Close()
