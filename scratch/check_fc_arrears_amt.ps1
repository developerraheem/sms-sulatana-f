$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT fc.C_ID, fc.Fee_head_id, fh.Fee_head, fh.Category, fc.AMOUNT, fc.ACTIVE, fc.TYPE, fh.branch_id
FROM FEE_CLASS fc
JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id
WHERE fh.Category = 'ARREAR' OR fh.Fee_head LIKE '%ARREAR%'
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "C_ID:" $r["C_ID"] "Head:" $r["Fee_head_id"] $r["Fee_head"] "Amt:" $r["AMOUNT"] "Active:" $r["ACTIVE"] "Branch:" $r["branch_id"]
}
$r.Close()
$con.Close()
