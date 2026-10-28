$con = New-Object System.Data.SqlClient.SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, s_id, FEE_MONTH, branch_id, SessionID, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS, FINE_AFTER_DUE_DATE FROM FEE_MASTER WHERE FEE_MASTER_ID = 455"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    for($i=0; $i -lt $r.FieldCount; $i++) {
        Write-Host ($r.GetName($i) + ": " + $r.GetValue($i))
    }
}
$r.Close()

Write-Host "--- FEE_DETAIL for 455 ---"
$cmd.CommandText = "SELECT fd.FEE_DETAIL_ID, fd.Fee_head_id, fh.Fee_head, fd.AMOUNT, fd.RECEIVED_AMOUNT, fd.BALANCE FROM FEE_DETAIL fd LEFT JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID = 455"
$r2 = $cmd.ExecuteReader()
while($r2.Read()) {
    Write-Host ($r2["FEE_DETAIL_ID"].ToString() + " | " + $r2["Fee_head_id"].ToString() + " (" + $r2["Fee_head"].ToString() + ") | Amt: " + $r2["AMOUNT"].ToString() + " | rec: " + $r2["RECEIVED_AMOUNT"].ToString() + " | bal: " + $r2["BALANCE"].ToString())
}
$r2.Close()

Write-Host "--- FEE_HISTORY for 455 ---"
$cmd.CommandText = "SELECT * FROM FEE_HISTORY WHERE VOUCHER_NO = '455'"
$r3 = $cmd.ExecuteReader()
while($r3.Read()) {
    Write-Host ($r3["FEE_HISTORY_ID"].ToString() + " | " + $r3["SUBMITION_DATE"].ToString() + " | Paid: " + $r3["PAID_AMOUNT"].ToString())
}
$r3.Close()

$con.Close()
