$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '2093'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "Bal:" $r["BALANCE"]
}
$r.Close()

$cmd.CommandText = @"
SELECT d.FEE_DETAIL_ID, d.FEE_MASTER_ID, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT
FROM FEE_DETAIL d
LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '2093')
ORDER BY d.FEE_MASTER_ID, d.FEE_DETAIL_ID
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "  Detail FM_ID:" $r["FEE_MASTER_ID"] "Head:" $r["Fee_head"] "Amt:" $r["AMOUNT"] "Curr:" $r["ISCURRENT"]
}
$r.Close()
$con.Close()
