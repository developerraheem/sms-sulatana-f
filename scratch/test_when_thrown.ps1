$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE branch_id = ''"
try {
    Write-Host "Calling ExecuteReader..."
    $r = $cmd.ExecuteReader()
    Write-Host "ExecuteReader SUCCEEDED! Now calling Read()..."
    $hasRow = $r.Read()
    Write-Host "Read() returned: $hasRow"
} catch {
    Write-Host "CAUGHT EXCEPTION at: $($_.Exception.StackTrace)"
}
$conn.Close()
