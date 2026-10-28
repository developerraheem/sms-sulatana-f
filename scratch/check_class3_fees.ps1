$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT fc.*, fh.Fee_head, fh.Category FROM FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID = '3' AND fc.ACTIVE = 'true'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Head: $($r['Fee_head']), ID: $($r['Fee_head_id']), Cat: $($r['Category']), Amt: $($r['AMOUNT'])"
}
$r.Close()
$con.Close()
