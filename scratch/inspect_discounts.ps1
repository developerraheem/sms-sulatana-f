$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='DISCOUNTS'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["COLUMN_NAME"] + " (" + $r["DATA_TYPE"] + ")")
}
$r.Close()

$cmd.CommandText = "SELECT COUNT(*) FROM DISCOUNTS"
$cnt = $cmd.ExecuteScalar()
Write-Output "Total rows in DISCOUNTS: $cnt"

$con.Close()
