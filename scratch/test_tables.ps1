$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_DETAIL_ID, FEE_MASTER_ID, Fee_head_id, AMOUNT, SessionID, branch_id FROM FEE_DETAIL WHERE FEE_MASTER_ID = '2'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("ID=" + $r[0] + ", MasterID=" + $r[1] + ", Head=" + $r[2] + ", Amt=" + $r[3] + ", SessionID=" + $r[4] + ", Branch=" + $r[5])
}
$r.Close()
$con.Close()
