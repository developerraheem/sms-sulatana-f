$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT TOP 10 fm.s_id, fm.FEE_MASTER_ID, fm.FEE_MONTH, fm.RECEIVABLE_AMOUNT, fm.REC_AMOUNT, fm.BALANCE, fm.PAID, fm.STATUS, fm.branch_id, fm.SessionID
FROM FEE_MASTER fm
WHERE fm.branch_id = 6 AND fm.SessionID = 68
ORDER BY fm.s_id, fm.FEE_MASTER_ID
"@
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
$ds.Tables[0] | Format-Table
$conn.Close()
