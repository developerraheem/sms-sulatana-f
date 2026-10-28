$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's inspect Voucher 1, 5, 6 in Branch 6 with view_fee
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, student.s_name, student.s_id, student.branch_id, view_fee.Fee_head, view_fee.AMOUNT, view_fee.SessionID, view_fee.c_name
FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE student.branch_id = 6 AND view_fee.FEE_MASTER_ID = 1
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "=== Voucher 1 rows in view_fee query for branch 6 ==="
$dt | Format-Table -AutoSize | Out-String | Write-Output

# Why does view_fee produce multiple rows? Let's check view_fee definition again:
# SELECT FEE_MASTER.FEE_MASTER_ID, FEE_MASTER.s_id, class.c_name, FEE_MASTER.FEE_MONTH, Fee_Head.Fee_head, FEE_DETAIL.AMOUNT, student.s_name, class.c_id, 
#        student.SHIFT, student.SECTION_ID, FEE_MASTER.PAID, student.TYPE, student.active, student.SessionID, FEE_DETAIL.RECEIVED_AMOUNT, 
#        FEE_MASTER.FEE_MONTH_FROM, Fee_Head.Fee_head_id, FEE_MASTER.startdate, FEE_MASTER.enddate
# FROM FEE_MASTER 
# LEFT OUTER JOIN FEE_DETAIL ON FEE_MASTER.SessionID = FEE_DETAIL.SessionID AND FEE_MASTER.FEE_MASTER_ID = FEE_DETAIL.FEE_MASTER_ID AND FEE_MASTER.branch_id = FEE_DETAIL.branch_id 
# LEFT OUTER JOIN Fee_Head ON FEE_DETAIL.Fee_head_id = Fee_Head.Fee_head_id 
# LEFT OUTER JOIN student ON FEE_MASTER.s_id = dbo.student.s_id 
# LEFT OUTER JOIN class ON FEE_MASTER.C_ID = class.c_id

$conn.Close()
