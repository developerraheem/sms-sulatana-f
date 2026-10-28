$c = New-Object System.Data.SqlClient.SqlConnection "Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT fd.*, fh.Fee_head FROM FEE_DETAIL fd INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID = 457 AND fd.branch_id = 6 AND fd.SessionID = 68"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Detail: Fee_head_id=" + $r["Fee_head_id"] + ", Head=" + $r["Fee_head"] + ", Amt=" + $r["AMOUNT"])
}
$r.Close()
$c.Close()
