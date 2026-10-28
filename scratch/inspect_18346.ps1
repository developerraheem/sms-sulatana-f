$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT m.FEE_MASTER_ID, m.FEE_MONTH, m.FEE_MONTH_FROM, m.RECEIVABLE_AMOUNT, m.REC_AMOUNT, m.BALANCE, m.PAID, m.STATUS, m.branch_id
FROM FEE_MASTER m
WHERE m.s_id = '18346'
ORDER BY m.FEE_MASTER_ID
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "Paid:" $r["PAID"] "RecAmt:" $r["REC_AMOUNT"] "Bal:" $r["BALANCE"]
}
$r.Close()

$cmd.CommandText = @"
SELECT d.FEE_DETAIL_ID, d.FEE_MASTER_ID, m.FEE_MONTH, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE
FROM FEE_DETAIL d
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE m.s_id = '18346'
ORDER BY d.FEE_MASTER_ID, d.FEE_DETAIL_ID
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "  Detail FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Head:" $r["Fee_head"] "Amt:" $r["AMOUNT"] "Curr:" $r["ISCURRENT"] "Bal:" $r["BALANCE"]
}
$r.Close()
$con.Close()
