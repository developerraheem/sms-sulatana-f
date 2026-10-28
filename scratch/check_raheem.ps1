$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE s_id = '22664' ORDER BY FEE_MASTER_ID DESC"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
Write-Host "=== FEE_MASTER records for 22664 ==="
$dt | Format-Table -Property FEE_MASTER_ID, FEE_MONTH, REC_AMOUNT, RECEIVABLE_AMOUNT, BALANCE, PAID, branch_id, DUE_DATE

$cmd.CommandText = "SELECT d.*, h.Fee_head FROM FEE_DETAIL d LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '22664')"
$da2 = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt2 = New-Object System.Data.DataTable
$da2.Fill($dt2)
Write-Host "=== FEE_DETAIL records for 22664 ==="
$dt2 | Format-Table -Property FEE_DETAIL_ID, FEE_MASTER_ID, Fee_head_id, Fee_head, AMOUNT, RECEIVED_AMOUNT, BALANCE, REMARKS

$conn.Close()
