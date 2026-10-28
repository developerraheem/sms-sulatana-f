$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT b.branch_id, b.branch_name, fh.Fee_head_id, fh.Fee_head, fh.Category, COUNT(fc.C_ID) as ClassCount, AVG(fc.AMOUNT) as AvgAmount
FROM Fee_Head fh
INNER JOIN branch b ON fh.branch_id = b.branch_id
LEFT JOIN FEE_CLASS fc ON fh.Fee_head_id = fc.Fee_head_id
WHERE fh.Category IN ('DISCOUNT', 'CONCESSION') OR fh.Fee_head LIKE '%CONCESSION%'
GROUP BY b.branch_id, b.branch_name, fh.Fee_head_id, fh.Fee_head, fh.Category
ORDER BY b.branch_id, fh.Fee_head_id
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
$dt | Format-Table -AutoSize

$conn.Close()
