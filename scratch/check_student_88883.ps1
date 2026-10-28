$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE s_id = 88883"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    for ($i = 0; $i -lt $r.FieldCount; $i++) {
        Write-Host ($r.GetName($i) + " = " + $r.GetValue($i))
    }
}
$conn.Close()
