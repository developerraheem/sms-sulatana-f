$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 5 s.s_id, s.s_name, s.CONCESSION_FEE, m.FEE_MASTER_ID, m.FEE_MONTH, m.RECEIVABLE_AMOUNT FROM student s INNER JOIN FEE_MASTER m ON s.s_id = m.s_id WHERE s.CONCESSION_FEE > 0 ORDER BY m.FEE_MASTER_ID DESC"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("s_id=" + $r["s_id"] + ", Name=" + $r["s_name"] + ", Conc=" + $r["CONCESSION_FEE"] + ", MasterID=" + $r["FEE_MASTER_ID"] + ", Month=" + $r["FEE_MONTH"] + ", Amount=" + $r["RECEIVABLE_AMOUNT"])
}
$r.Close()

$cmd.CommandText = "SELECT TOP 10 m.FEE_MASTER_ID, d.Fee_head_id, h.Fee_head, d.AMOUNT FROM FEE_DETAIL d INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id INNER JOIN FEE_MASTER m ON d.FEE_MASTER_ID=m.FEE_MASTER_ID INNER JOIN student s ON m.s_id=s.s_id WHERE s.CONCESSION_FEE > 0 ORDER BY d.FEE_MASTER_ID DESC"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("MasterID=" + $r["FEE_MASTER_ID"] + ", Head=" + $r["Fee_head"] + " (" + $r["Fee_head_id"] + "), Amount=" + $r["AMOUNT"])
}
$r.Close()
$con.Close()
