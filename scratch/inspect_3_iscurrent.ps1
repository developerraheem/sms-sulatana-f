$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT d.FEE_DETAIL_ID, d.FEE_MASTER_ID, m.s_id, m.FEE_MONTH, d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE
FROM FEE_DETAIL d
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.ISCURRENT = 'N'
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FD_ID:" $r["FEE_DETAIL_ID"] "FM_ID:" $r["FEE_MASTER_ID"] "s_id:" $r["s_id"] "Month:" $r["FEE_MONTH"] "Head:" $r["Fee_head"] "Amt:" $r["AMOUNT"]
}
$r.Close()
$con.Close()
