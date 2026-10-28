$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT fm.FEE_MASTER_ID, fm.s_id, fm.C_ID as FmClass, s.c_id as StdClass, c1.c_name as FmClassName, c2.c_name as StdClassName,
       fm.SessionID, fm.FEE_MONTH, fm.RECEIVABLE_AMOUNT, fm.REC_AMOUNT, fm.BALANCE
FROM FEE_MASTER fm
INNER JOIN student s ON fm.s_id = s.s_id AND fm.branch_id = s.branch_id
LEFT JOIN class c1 ON fm.C_ID = c1.c_id
LEFT JOIN class c2 ON s.c_id = c2.c_id
WHERE fm.branch_id = 6 AND fm.C_ID <> s.c_id
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "=== Vouchers in Branch 6 where fm.C_ID <> s.c_id ==="
$dt | Format-Table -AutoSize | Out-String | Write-Output
$conn.Close()
