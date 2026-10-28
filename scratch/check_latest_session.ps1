$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "select top 5 FEE_MASTER_ID, SessionID, branch_id from FEE_MASTER order by convert(int, FEE_MASTER_ID) desc"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "ID:" $r[0] "Session:" $r[1] "Branch:" $r[2]
}
$r.Close()
$con.Close()
