$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'student'"
$reader = $cmd.ExecuteReader()
while ($reader.Read()) {
    Write-Host ($reader["COLUMN_NAME"].ToString().PadRight(25) + $reader["DATA_TYPE"] + " (" + $reader["NUMERIC_PRECISION"] + "," + $reader["NUMERIC_SCALE"] + "," + $reader["CHARACTER_MAXIMUM_LENGTH"] + ")")
}
$conn.Close()
