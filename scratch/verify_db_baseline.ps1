$c = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
Write-Host "Current count of vouchers with PAID='Y':" $cmd.ExecuteScalar()

$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH IN ('11 2026', '12 2026')"
Write-Host "Count of test vouchers for student 2093 in 11 2026 / 12 2026:" $cmd.ExecuteScalar()
$c.Close()
