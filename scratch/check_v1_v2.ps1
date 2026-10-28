$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT m.FEE_MASTER_ID, m.s_id, s.s_name, m.RECEIVABLE_AMOUNT, m.BALANCE, d.FEE_DETAIL_ID, d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT FROM FEE_MASTER m INNER JOIN student s ON m.s_id=s.s_id INNER JOIN FEE_DETAIL d ON m.FEE_MASTER_ID=d.FEE_MASTER_ID INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id WHERE m.FEE_MASTER_ID IN ('1', '2') ORDER BY m.FEE_MASTER_ID, d.FEE_DETAIL_ID"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("MasterID=" + $r["FEE_MASTER_ID"] + ", s_id=" + $r["s_id"] + ", Name=" + $r["s_name"] + ", RecAmt=" + $r["RECEIVABLE_AMOUNT"] + ", DetailID=" + $r["FEE_DETAIL_ID"] + ", Head=" + $r["Fee_head"] + " (" + $r["Fee_head_id"] + "), Cat=" + $r["Category"] + ", Amt=" + $r["AMOUNT"])
}
$r.Close()
$con.Close()
