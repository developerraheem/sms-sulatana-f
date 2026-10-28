$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's inspect fee months in Branch 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT DISTINCT SessionID, FEE_MONTH_FROM, COUNT(*) as cnt FROM FEE_MASTER WHERE branch_id = 6 GROUP BY SessionID, FEE_MONTH_FROM ORDER BY SessionID, cnt DESC"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("Session: " + $r[0] + ", MonthFrom: " + $r[1] + ", Count: " + $r[2])
}
$r.Close()

$conn.Close()
