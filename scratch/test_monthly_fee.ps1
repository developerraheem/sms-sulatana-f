$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Host "=================================================="
Write-Host "3. MonthlyFee query for Branch 6:"
Write-Host "=================================================="
# CommandText of MonthlyFee:
# SELECT SUM(A.AMOUNT) AS DueAmount, SUM(A.RECEIVED_AMOUNT) AS Received, SUM(A.BALANCE) AS Balance, SUM(A.AMOUNT) - SUM(A.RECEIVED_AMOUNT) AS Outstanding, A.FEE_MONTH, Fee_Head.Fee_head, student.TYPE, class.c_name, student.SHIFT, student.SECTION_ID
# FROM FEE_DETAIL AS A INNER JOIN FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID INNER JOIN student ON B.s_id = student.s_id INNER JOIN class ON B.C_ID = class.c_id INNER JOIN Fee_Head ON A.Fee_head_id = Fee_Head.Fee_head_id
# WHERE (A.FEE_MONTH = @feemonth)
# Notice: No branch filter on A.FEE_MASTER_ID = B.FEE_MASTER_ID!
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT A.FEE_MASTER_ID, B.branch_id as fm_branch, A.branch_id as fd_branch, B.SessionID as fm_session, A.SessionID as fd_session
FROM FEE_DETAIL AS A INNER JOIN
     FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID
WHERE B.branch_id = 6 AND (A.branch_id != B.branch_id OR A.SessionID != B.SessionID)
"@
$r = $cmd.ExecuteReader()
$mismatch = 0
while ($r.Read()) {
    $mismatch++
}
$r.Close()
Write-Host ("Cross-branch/session mismatches in MonthlyFee for Branch 6: " + $mismatch)

$conn.Close()
