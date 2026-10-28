$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT m.FEE_MASTER_ID, m.s_id, s.s_name, m.RECEIVABLE_AMOUNT, m.BALANCE, d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT " +
                   "FROM FEE_MASTER m " +
                   "INNER JOIN student s ON m.s_id=s.s_id AND m.SessionID=s.SessionID AND m.branch_id=s.branch_id " +
                   "INNER JOIN FEE_DETAIL d ON m.FEE_MASTER_ID=d.FEE_MASTER_ID AND m.SessionID=d.SessionID AND m.branch_id=d.branch_id " +
                   "INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id " +
                   "WHERE m.FEE_MASTER_ID='1' AND m.SessionID='81' AND m.branch_id='2' ORDER BY d.FEE_DETAIL_ID"
$r = $cmd.ExecuteReader()
Write-Output "--- VOUCHER 1 (AQSA SHAHZAD) CURRENT STATUS ---"
while ($r.Read()) {
    Write-Output ($r["Fee_head"].ToString() + " (" + $r["Fee_head_id"].ToString() + ", " + $r["Category"].ToString() + "): Rs. " + $r["AMOUNT"].ToString())
}
$r.Close()

$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID='1' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Output ("Total Receivable Amount: Rs. " + $r["RECEIVABLE_AMOUNT"].ToString())
    Write-Output ("Balance: Rs. " + $r["BALANCE"].ToString())
}
$r.Close()

$con.Close()
