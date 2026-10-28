$con = New-Object System.Data.SqlClient.SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True")
$con.Open()
$cmd = $con.CreateCommand()

Write-Host "=== DIAGNOSTIC: Current DB state for branch 6, session 68 ==="

# Find a good test voucher: unpaid in branch 6, session 68
$cmd.CommandText = "SELECT TOP 5 FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE branch_id='6' AND SessionID='68' ORDER BY FEE_MASTER_ID DESC"
$r = $cmd.ExecuteReader()
Write-Host "--- Recent vouchers for branch 6, session 68 ---"
while($r.Read()) {
    Write-Host ("  VNO=" + $r["FEE_MASTER_ID"] + " | SID=" + $r["s_id"] + " | Month=" + $r["FEE_MONTH"] + " | Recv=" + $r["RECEIVABLE_AMOUNT"] + " | Rec=" + $r["REC_AMOUNT"] + " | Bal=" + $r["BALANCE"] + " | PAID=" + $r["PAID"] + " | STATUS=" + $r["STATUS"])
}
$r.Close()

# Find an unpaid voucher
$cmd.CommandText = "SELECT TOP 1 FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE branch_id='6' AND SessionID='68' AND (PAID IS NULL OR PAID='') AND (BALANCE > 0 OR BALANCE IS NULL) ORDER BY FEE_MASTER_ID DESC"
$r = $cmd.ExecuteReader()
Write-Host "`n--- Unpaid voucher candidates ---"
while($r.Read()) {
    Write-Host ("  Unpaid: VNO=" + $r["FEE_MASTER_ID"] + " SID=" + $r["s_id"] + " Recv=" + $r["RECEIVABLE_AMOUNT"] + " Rec=" + $r["REC_AMOUNT"] + " Bal=" + $r["BALANCE"])
}
$r.Close()

# Find student 20261
$cmd.CommandText = "SELECT TOP 3 FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id='20261' AND branch_id='6' AND SessionID='68' ORDER BY FEE_MASTER_ID DESC"
$r = $cmd.ExecuteReader()
Write-Host "`n--- Vouchers for student 20261, branch 6, session 68 ---"
while($r.Read()) {
    Write-Host ("  VNO=" + $r["FEE_MASTER_ID"] + " Month=" + $r["FEE_MONTH"] + " Recv=" + $r["RECEIVABLE_AMOUNT"] + " Rec=" + $r["REC_AMOUNT"] + " Bal=" + $r["BALANCE"] + " PAID=" + $r["PAID"])
}
$r.Close()

# Check student 20261 info
$cmd.CommandText = "SELECT s_id, s_name, f_name, SessionID, branch_id FROM student WHERE s_id='20261' AND branch_id='6'"
$r = $cmd.ExecuteReader()
Write-Host "`n--- Student 20261 info ---"
while($r.Read()) {
    Write-Host ("  SID=" + $r["s_id"] + " Name=" + $r["s_name"] + " SessionID=" + $r["SessionID"] + " Branch=" + $r["branch_id"])
}
$r.Close()

$con.Close()
