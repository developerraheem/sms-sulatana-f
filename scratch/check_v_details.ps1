$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT fd.FEE_MASTER_ID, fd.Fee_head_id, fh.Fee_head, fd.AMOUNT, fd.BALANCE, fd.SessionID, fd.branch_id
FROM FEE_DETAIL fd
JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id
JOIN FEE_MASTER fm ON fd.FEE_MASTER_ID = fm.FEE_MASTER_ID AND fd.SessionID = fm.SessionID AND fd.branch_id = fm.branch_id
WHERE fm.s_id = '22535' AND fm.FEE_MONTH = '11 2026' AND fm.SessionID = '78' AND fm.branch_id = '1'
ORDER BY fd.Fee_head_id
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-Table -AutoSize | Out-String | Write-Host
$conn.Close()
