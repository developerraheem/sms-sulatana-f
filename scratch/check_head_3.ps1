$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT * FROM Fee_Head WHERE Fee_head_id = '3'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Head 3: ID=$($r['Fee_head_id']) Name='$($r['Fee_head'])' Cat='$($r['Category'])' Branch=$($r['branch_id'])"
}
$r.Close()
$con.Close()
