$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, SessionID, branch_id, s_id, FEE_MONTH FROM FEE_MASTER WHERE FEE_MASTER_ID = '1'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "FM_ID=$($r[0]), SessionID=$($r[1]), Branch=$($r[2]), sid=$($r[3]), Month=$($r[4])"
}
$r.Close()
$conn.Close()
