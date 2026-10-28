$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT OBJECT_DEFINITION(OBJECT_ID('Temp')) AS ViewTemp"
Write-Host "=== Temp View Definition ==="
Write-Host $cmd.ExecuteScalar()

$cmd.CommandText = "SELECT OBJECT_DEFINITION(OBJECT_ID('TempDetail')) AS ViewTempDetail"
Write-Host "=== TempDetail View Definition ==="
Write-Host $cmd.ExecuteScalar()

$conn.Close()
