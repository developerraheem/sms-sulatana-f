$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME='FINE_HISTORY'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["CONSTRAINT_NAME"].ToString() + " (" + $r["CONSTRAINT_TYPE"].ToString() + ")")
}
$r.Close()

$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='FINE_HISTORY'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["COLUMN_NAME"].ToString() + " (" + $r["DATA_TYPE"].ToString() + ", Nullable: " + $r["IS_NULLABLE"].ToString() + ")")
}
$r.Close()

$cmd.CommandText = "SELECT MAX(CAST(FINE_ID AS BIGINT)) FROM FINE_HISTORY"
Write-Output ("Global MAX FINE_ID: " + $cmd.ExecuteScalar())

$con.Close()
