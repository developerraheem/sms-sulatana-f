$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT fc.Fee_head_id, fh.Fee_head, fh.Category, COUNT(*) as cnt
FROM FEE_CLASS fc
JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id
WHERE fh.Category = 'ARREAR' OR fh.Fee_head LIKE '%ARREAR%'
GROUP BY fc.Fee_head_id, fh.Fee_head, fh.Category
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Fee Head in FEE_CLASS:" $r[0] $r[1] "Cat:" $r[2] "Count in FEE_CLASS:" $r[3]
}
$r.Close()
$con.Close()
