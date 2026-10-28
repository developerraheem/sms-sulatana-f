$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT Fee_head_id, Fee_head, Category, branch_id FROM Fee_Head ORDER BY Fee_head_id"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "$($r['Fee_head_id']) | $($r['Fee_head']) | $($r['Category']) | branch: $($r['branch_id'])"
}
$r.Close()
$con.Close()
