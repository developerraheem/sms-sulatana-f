$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT m.FEE_MASTER_ID, m.s_id, s.s_name, s.CONCESSION_FEE, m.RECEIVABLE_AMOUNT, m.BALANCE, m.branch_id, m.SessionID
FROM FEE_MASTER m
INNER JOIN student s ON m.s_id = s.s_id
WHERE m.s_id = '22664'
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
Write-Host "=== Master ==="
$dt | Format-Table -AutoSize

$cmd.CommandText = @"
SELECT d.FEE_DETAIL_ID, d.FEE_MASTER_ID, d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT, d.BALANCE
FROM FEE_DETAIL d
INNER JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '22664')
  AND d.branch_id = 2
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
Write-Host "=== Details for Branch 2 ==="
$dt | Format-Table -AutoSize

$conn.Close()
