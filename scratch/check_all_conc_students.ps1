$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT TOP 20 s_id, s_name, CONCESSION_FEE, CONCESSION_REASON, DISCOUNT_APPLIED, DISCOUNT_ID, branch_id FROM student WHERE CONCESSION_FEE > 0"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
Write-Host "=== Students with CONCESSION_FEE > 0 ==="
$dt | Format-Table -AutoSize

$conn.Close()
