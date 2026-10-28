$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT s_id, s_name, CONCESSION_FEE, CONCESSION_REASON, DISCOUNT_APPLIED, DISCOUNT_ID, branch_id FROM student WHERE s_id='10754'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Student: s_id=" + $r["s_id"] + ", CONCESSION_FEE=" + $r["CONCESSION_FEE"] + ", DISCOUNT_APPLIED=" + $r["DISCOUNT_APPLIED"] + ", DISCOUNT_ID=" + $r["DISCOUNT_ID"])
}
$r.Close()

$cmd.CommandText = "SELECT * FROM FINE_HISTORY WHERE S_ID='10754'"
$r = $cmd.ExecuteReader()
Write-Output "--- FINE_HISTORY for 10754 ---"
while ($r.Read()) {
    Write-Output ("FINE_ID=" + $r["FINE_ID"] + ", Head=" + $r["Fee_head_id"] + ", Amount=" + $r["FINE_AMOUNT"] + ", MasterID=" + $r["FEE_MASTER_ID"] + ", active=" + $r["active"])
}
$r.Close()

$con.Close()
