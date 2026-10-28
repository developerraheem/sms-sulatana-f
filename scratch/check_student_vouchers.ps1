$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, FEE_MONTH_FROM, PAID, REC_AMOUNT, RECEIVABLE_AMOUNT, BALANCE, SessionID, branch_id FROM FEE_MASTER WHERE s_id='22659' ORDER BY FEE_MASTER_ID"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "ID: $($r['FEE_MASTER_ID']) | month: '$($r['FEE_MONTH'])' | from: '$($r['FEE_MONTH_FROM'])' | paid: '$($r['PAID'])' | rec: '$($r['REC_AMOUNT'])' | bal: '$($r['BALANCE'])'"
}
$r.Close()
$con.Close()
