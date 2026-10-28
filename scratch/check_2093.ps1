$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE s_id = '2093'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "Bal:" $r["BALANCE"]
}
$r.Close()
$con.Close()
