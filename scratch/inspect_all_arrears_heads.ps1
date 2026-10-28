$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT d.Fee_head_id, h.Fee_head, h.Category, COUNT(*) as cnt, SUM(d.AMOUNT) as total_amt
FROM FEE_DETAIL d
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE h.Category = 'ARREAR' OR h.Fee_head LIKE '%ARREAR%'
GROUP BY d.Fee_head_id, h.Fee_head, h.Category
ORDER BY cnt DESC
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Head_ID:" $r[0] "Name:" $r[1] "Cat:" $r[2] "Count:" $r[3] "TotalAmt:" $r[4]
}
$r.Close()
$con.Close()
