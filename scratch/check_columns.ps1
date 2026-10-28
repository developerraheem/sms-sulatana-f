$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='FEE_MASTER'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "$($r['COLUMN_NAME']) ($($r['DATA_TYPE']))"
}
$r.Close()
$con.Close()
