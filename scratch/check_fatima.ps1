$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_DETAIL_ID, Fee_head_id, AMOUNT, FEE_MONTH, ISCURRENT, BALANCE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("DETAIL: ID=" + $r[0] + ", Head=" + $r[1] + ", Amt=" + $r[2] + ", Month=" + $r[3] + ", IsCurrent=" + $r[4] + ", Bal=" + $r[5])
}
$r.Close()
$con.Close()
