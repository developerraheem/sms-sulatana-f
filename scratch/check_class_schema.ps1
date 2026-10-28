$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'class'"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host ($reader["COLUMN_NAME"].ToString().PadRight(25) + $reader["DATA_TYPE"])
}
$conn.Close()
