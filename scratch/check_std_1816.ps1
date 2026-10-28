$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, branch_id, SessionID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '1816'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FM_ID: $($r['FEE_MASTER_ID']), Branch: $($r['branch_id']), Session: $($r['SessionID']), Month: $($r['FEE_MONTH']), Recv: $($r['RECEIVABLE_AMOUNT'])"
}
$r.Close()
$con.Close()
