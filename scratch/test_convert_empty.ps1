$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

try {
    $cmd = New-Object System.Data.SqlClient.SqlCommand("SELECT CONVERT(int, '')", $conn)
    $res = $cmd.ExecuteScalar()
    Write-Host "CONVERT(int, ''): $res"
} catch {
    Write-Host "CONVERT(int, '') FAILED: $($_.Exception.Message)"
}

try {
    $cmd = New-Object System.Data.SqlClient.SqlCommand("SELECT CONVERT(numeric(18,0), '')", $conn)
    $res = $cmd.ExecuteScalar()
    Write-Host "CONVERT(numeric(18,0), ''): $res"
} catch {
    Write-Host "CONVERT(numeric(18,0), '') FAILED: $($_.Exception.Message)"
}

$conn.Close()
