$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME='FEE_MASTER'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["CONSTRAINT_NAME"].ToString() + " (" + $r["CONSTRAINT_TYPE"].ToString() + ")")
}
$r.Close()

$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='FEE_MASTER'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["COLUMN_NAME"].ToString() + " (" + $r["DATA_TYPE"].ToString() + ", Nullable: " + $r["IS_NULLABLE"].ToString() + ")")
}
$r.Close()

$cmd.CommandText = "SELECT k.COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE k WHERE k.TABLE_NAME='FEE_MASTER'"
$r = $cmd.ExecuteReader()
Write-Output "--- Key columns on FEE_MASTER ---"
while ($r.Read()) {
    Write-Output $r[0].ToString()
}
$r.Close()

$con.Close()
