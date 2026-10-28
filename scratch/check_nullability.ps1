$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT COLUMN_NAME, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='FEE_CLASS'"
$r = $cmd.ExecuteReader()
Write-Output "--- FEE_CLASS COLUMNS ---"
while ($r.Read()) {
    Write-Output ($r["COLUMN_NAME"] + " (Nullable: " + $r["IS_NULLABLE"] + ")")
}
$r.Close()

$cmd.CommandText = "SELECT COLUMN_NAME, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='student' AND IS_NULLABLE='NO'"
$r = $cmd.ExecuteReader()
Write-Output "--- student NOT NULL COLUMNS ---"
while ($r.Read()) {
    Write-Output ($r["COLUMN_NAME"] + " (Nullable: " + $r["IS_NULLABLE"] + ")")
}
$r.Close()

$con.Close()
