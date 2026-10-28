$c = New-Object System.Data.SqlClient.SqlConnection "Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = 456"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Master: ID=" + $r["FEE_MASTER_ID"] + ", Month=" + $r["FEE_MONTH"] + ", From=" + $r["FEE_MONTH_FROM"] + ", T_MONTHS=" + $r["T_MONTHS"] + ", RecAmt=" + $r["RECEIVABLE_AMOUNT"])
}
$r.Close()

$cmd.CommandText = "SELECT fd.*, fh.Fee_head FROM FEE_DETAIL fd INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID = 456"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Detail: Head=" + $r["Fee_head"] + ", Amt=" + $r["AMOUNT"] + ", Balance=" + $r["BALANCE"])
}
$r.Close()
$c.Close()
