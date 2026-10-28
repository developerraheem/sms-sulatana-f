$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = 198"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-List | Out-String | Write-Host

$cmd.CommandText = "SELECT TOP 5 * FROM FEE_MASTER WHERE s_id = '22535' ORDER BY FEE_MASTER_ID DESC"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
Write-Host "Vouchers for 22535:"
$dt2 | Format-Table FEE_MASTER_ID, s_id, FEE_MONTH, C_ID, TOTAL_FEE, RECEIVABLE_AMOUNT, date | Out-String | Write-Host
$conn.Close()
