$conStr = 'Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;'
$con = New-Object System.Data.SqlClient.SqlConnection($conStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = 'SELECT TOP 10 FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE REC_AMOUNT > 0 ORDER BY FEE_MASTER_ID DESC'
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("ID=" + $r["FEE_MASTER_ID"] + " | s_id=" + $r["s_id"] + " | Month=" + $r["FEE_MONTH"] + " | Recv=" + $r["RECEIVABLE_AMOUNT"] + " | Rec=" + $r["REC_AMOUNT"] + " | Bal=" + $r["BALANCE"] + " | Paid=" + $r["PAID"] + " | Status=" + $r["STATUS"])
}
$con.Close()
