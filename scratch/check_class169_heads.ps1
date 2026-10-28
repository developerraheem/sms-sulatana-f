$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT fc.FEE_CLASS_ID, fc.Fee_head_id, fh.Fee_head, fc.AMOUNT, fc.ACTIVE, fc.TYPE FROM FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID=169 AND (fc.branch_id=1 OR fc.branch_id IS NULL)"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "fc_id: $($r['FEE_CLASS_ID']) | head: $($r['Fee_head']) | amt: $($r['AMOUNT']) | active: $($r['ACTIVE']) | type: $($r['TYPE'])"
}
$r.Close()
$con.Close()
