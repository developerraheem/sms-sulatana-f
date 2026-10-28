$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, FEE_MONTH_FROM, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS, SessionID FROM FEE_MASTER WHERE s_id = '2093' ORDER BY FEE_MASTER_ID DESC"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "Paid:" $r["PAID"] "Bal:" $r["BALANCE"] "Session:" $r["SessionID"]
}
$r.Close()
$con.Close()
