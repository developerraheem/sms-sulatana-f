$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '736' AND SessionID = '2'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FM_ID: $($r['FEE_MASTER_ID']), Month: $($r['FEE_MONTH']), Recv: $($r['RECEIVABLE_AMOUNT'])"
}
$r.Close()
$con.Close()
