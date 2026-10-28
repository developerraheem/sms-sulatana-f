$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = 'SELECT TOP 10 FEE_MASTER_ID, s_id, FEE_MONTH, FEE_MONTH_FROM, PAID, STATUS, REC_AMOUNT, RECEIVABLE_AMOUNT, BALANCE, SessionID, branch_id FROM FEE_MASTER ORDER BY FEE_MASTER_ID DESC'
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "ID: $($r['FEE_MASTER_ID']) | sid: $($r['s_id']) | month: '$($r['FEE_MONTH'])' | from: '$($r['FEE_MONTH_FROM'])' | paid: '$($r['PAID'])' | status: '$($r['STATUS'])' | rec: $($r['REC_AMOUNT']) | bal: $($r['BALANCE']) | sess: $($r['SessionID']) | br: $($r['branch_id'])"
}
$r.Close()
$con.Close()
