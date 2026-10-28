$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT Fee_head_id, Fee_head, Category, branch_id FROM Fee_Head WHERE branch_id IN (4, 5, 9, 10, 12, 13, 14, 15)"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Branch $($r['branch_id']): Head $($r['Fee_head_id']) '$($r['Fee_head'])' (Cat: '$($r['Category'])')"
}
$r.Close()
$con.Close()
