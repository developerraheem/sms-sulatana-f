$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT TOP 10 d.FEE_DETAIL_ID, d.FEE_MASTER_ID, m.s_id, m.FEE_MONTH, m.FEE_MONTH_FROM, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE
FROM FEE_DETAIL d
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.ISCURRENT = 'N'
ORDER BY d.FEE_DETAIL_ID DESC
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FD_ID:" $r["FEE_DETAIL_ID"] "FM_ID:" $r["FEE_MASTER_ID"] "s_id:" $r["s_id"] "Month:" $r["FEE_MONTH"] "Head:" $r["Fee_head"] "Amt:" $r["AMOUNT"] "Curr:" $r["ISCURRENT"] "Bal:" $r["BALANCE"]
}
$r.Close()
$con.Close()
