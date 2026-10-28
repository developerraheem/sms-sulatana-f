$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT TOP 5 d.FEE_DETAIL_ID, d.FEE_MASTER_ID, m.s_id, m.FEE_MONTH, m.RECEIVABLE_AMOUNT, m.BALANCE, m.PAID, d.Fee_head_id, d.AMOUNT, d.ISCURRENT
FROM FEE_DETAIL d
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID
WHERE d.Fee_head_id IN ('40', '140', '130') AND d.AMOUNT > 0
ORDER BY d.FEE_DETAIL_ID DESC
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FD_ID:" $r["FEE_DETAIL_ID"] "FM_ID:" $r["FEE_MASTER_ID"] "s_id:" $r["s_id"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "Bal:" $r["BALANCE"] "Paid:" $r["PAID"] "Head:" $r["Fee_head_id"] "Amt:" $r["AMOUNT"] "Curr:" $r["ISCURRENT"]
}
$r.Close()
$con.Close()
