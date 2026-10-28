$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 10 m.FEE_MASTER_ID, m.s_id, m.FEE_MONTH, m.RECEIVABLE_AMOUNT, d.Fee_head_id, h.Fee_head, d.AMOUNT FROM FEE_MASTER m INNER JOIN FEE_DETAIL d ON m.FEE_MASTER_ID=d.FEE_MASTER_ID INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id WHERE m.s_id='7852' ORDER BY m.FEE_MASTER_ID DESC"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("MasterID=" + $r["FEE_MASTER_ID"] + ", Month=" + $r["FEE_MONTH"] + ", Total=" + $r["RECEIVABLE_AMOUNT"] + ", Head=" + $r["Fee_head"] + " (" + $r["Fee_head_id"] + "), Amount=" + $r["AMOUNT"])
}
$r.Close()
$con.Close()
