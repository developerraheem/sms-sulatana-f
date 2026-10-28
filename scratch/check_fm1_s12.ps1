$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT d.FEE_DETAIL_ID, d.FEE_MASTER_ID, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT
FROM FEE_DETAIL d
LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.FEE_MASTER_ID = '1' AND d.SessionID = '12'
ORDER BY d.FEE_DETAIL_ID
"@
$r = $cmd.ExecuteReader()
Write-Host "Details for FM_ID 1 with SessionID = 12:"
while($r.Read()) {
    Write-Host "  Head: $($r['Fee_head']), Cat: $($r['Category']), Amt: $($r['AMOUNT']), Curr: $($r['ISCURRENT'])"
}
$r.Close()
$con.Close()
