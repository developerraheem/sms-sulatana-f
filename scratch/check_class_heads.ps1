$c = New-Object System.Data.SqlClient.SqlConnection "Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT fc.Fee_head_id, fh.Fee_head, fh.Category, fc.AMOUNT, fc.ACTIVE FROM FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID = 8889"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Head ID=" + $r["Fee_head_id"].ToString() + ", Name=" + $r["Fee_head"].ToString() + ", Cat=" + $r["Category"].ToString() + ", Amt=" + $r["AMOUNT"].ToString() + ", Active=" + $r["ACTIVE"].ToString())
}
$r.Close()
$c.Close()
