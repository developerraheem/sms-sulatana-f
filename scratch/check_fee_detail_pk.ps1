$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT k.COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE k WHERE k.TABLE_NAME='FEE_DETAIL'"
$r = $cmd.ExecuteReader()
Write-Output "--- Key columns on FEE_DETAIL ---"
while ($r.Read()) {
    Write-Output $r[0].ToString()
}
$r.Close()

$cmd.CommandText = "SELECT COLUMNPROPERTY(OBJECT_ID('FEE_DETAIL'), 'FEE_DETAIL_ID', 'IsIdentity')"
Write-Output ("FEE_DETAIL_ID IsIdentity: " + $cmd.ExecuteScalar())

$con.Close()
