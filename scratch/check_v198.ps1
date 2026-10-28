$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, s_id, C_ID, SessionID, FEE_MONTH, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE FEE_MASTER_ID = 198 AND branch_id = 6"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("Branch 6 Voucher 198: s_id=" + $r[1] + ", C_ID=" + $r[2] + ", Session=" + $r[3] + ", Month=" + $r[4] + ", Due=" + $r[5])
}
$r.Close()

Write-Host "`nFEE_DETAIL for Voucher 198 with branch_id = 6:"
$cmd.CommandText = "SELECT FEE_DETAIL_ID, FEE_MASTER_ID, Fee_head_id, AMOUNT, SessionID, branch_id FROM FEE_DETAIL WHERE FEE_MASTER_ID = 198 AND branch_id = 6"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("Branch 6 FEE_DETAIL: detail_id=" + $r[0] + ", Session=" + $r[4] + ", head=" + $r[2] + ", Amount=" + $r[3])
}
$r.Close()

$conn.Close()
