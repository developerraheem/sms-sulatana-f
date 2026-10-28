$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's inspect recent fee vouchers in Branch 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT TOP 10 fm.FEE_MASTER_ID, fm.s_id, fm.C_ID, fm.SessionID, fm.FEE_MONTH, fm.RECEIVABLE_AMOUNT, fm.REC_AMOUNT, fm.BALANCE, fm.branch_id, s.s_name, s.ADMISSION_NO, s.SECTION_ID
FROM FEE_MASTER fm
LEFT JOIN student s ON fm.s_id = s.s_id AND fm.branch_id = s.branch_id
WHERE fm.branch_id = 6
ORDER BY fm.FEE_MASTER_ID DESC
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "=== Recent Branch 6 Vouchers ==="
$dt | Format-Table -AutoSize | Out-String | Write-Output

# Let's check FEE_DETAIL for these vouchers
$vmIds = ($dt | ForEach-Object { $_.FEE_MASTER_ID }) -join ','
$cmd.CommandText = @"
SELECT fd.FEE_DETAIL_ID, fd.FEE_MASTER_ID, fd.Fee_head_id, fh.Fee_head, fd.AMOUNT, fd.RECEIVED_AMOUNT, fd.BALANCE, fd.branch_id, fd.SessionID
FROM FEE_DETAIL fd
LEFT JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id AND fd.branch_id = fh.branch_id
WHERE fd.FEE_MASTER_ID IN ($vmIds) AND fd.branch_id = 6
ORDER BY fd.FEE_MASTER_ID DESC
"@
$dtFD = New-Object System.Data.DataTable
[void]$da.Fill($dtFD)
Write-Output "=== Fee Details for Recent Vouchers ==="
$dtFD | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
