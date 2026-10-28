$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE s_id = 88883"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    for ($i = 0; $i -lt $r.FieldCount; $i++) {
        $name = $r.GetName($i)
        $val = $r.GetValue($i)
        $type = $r.GetFieldType($i).Name
        Write-Host "$name ($type) = '$val'"
    }
}
$conn.Close()
