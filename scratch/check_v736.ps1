$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = 736 AND branch_id = 6"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    for ($i = 0; $i -lt $r.FieldCount; $i++) {
        Write-Host ($r.GetName($i) + ": " + $r.GetValue($i))
    }
}
$r.Close()

$conn.Close()
