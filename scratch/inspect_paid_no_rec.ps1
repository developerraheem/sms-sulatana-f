$c = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE PAID = 'Y' AND (REC_AMOUNT IS NULL OR REC_AMOUNT = 0) AND RECEIVABLE_AMOUNT > 0"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FM_ID:" $r["FEE_MASTER_ID"] "s_id:" $r["s_id"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "RecAmt:" $r["REC_AMOUNT"] "Bal:" $r["BALANCE"] "Paid:" $r["PAID"]
}
$r.Close()
$c.Close()
