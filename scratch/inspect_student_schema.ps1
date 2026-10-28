$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'student'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ($r["COLUMN_NAME"].ToString() + " | " + $r["DATA_TYPE"].ToString() + " | len=" + $r["CHARACTER_MAXIMUM_LENGTH"] + " | prec=" + $r["NUMERIC_PRECISION"] + " | scale=" + $r["NUMERIC_SCALE"])
}
$conn.Close()
