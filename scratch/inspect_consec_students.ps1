$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT s_id, COUNT(*) as cnt 
FROM FEE_MASTER 
WHERE FEE_MONTH IN ('11 2024', '12 2024') 
GROUP BY s_id 
HAVING COUNT(*) = 2
"@
$r = $cmd.ExecuteReader()
$sampleSids = @()
while($r.Read() -and $sampleSids.Count -lt 5) {
    $sampleSids += $r["s_id"].ToString()
}
$r.Close()

Write-Host "Sample s_ids with both 11 2024 and 12 2024:" ($sampleSids -join ", ")

foreach ($sid in $sampleSids) {
    Write-Host "`n=== Student $sid ==="
    $cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, FEE_MONTH_FROM, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE s_id = '$sid' AND FEE_MONTH IN ('11 2024', '12 2024') ORDER BY FEE_MASTER_ID"
    $r2 = $cmd.ExecuteReader()
    while($r2.Read()) {
        Write-Host "  FM_ID:" $r2["FEE_MASTER_ID"] "Month:" $r2["FEE_MONTH"] "Recv:" $r2["RECEIVABLE_AMOUNT"] "Paid:" $r2["PAID"] "RecAmt:" $r2["REC_AMOUNT"] "Bal:" $r2["BALANCE"]
    }
    $r2.Close()

    $cmd.CommandText = @"
SELECT d.FEE_MASTER_ID, m.FEE_MONTH, h.Fee_head, h.Category, d.AMOUNT, d.BALANCE, d.ISCURRENT 
FROM FEE_DETAIL d 
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID 
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id 
WHERE m.s_id = '$sid' AND m.FEE_MONTH IN ('11 2024', '12 2024')
ORDER BY d.FEE_MASTER_ID, d.FEE_DETAIL_ID
"@
    $r3 = $cmd.ExecuteReader()
    while($r3.Read()) {
        Write-Host "    Detail FM_ID:" $r3["FEE_MASTER_ID"] "Month:" $r3["FEE_MONTH"] "Head:" $r3["Fee_head"] "Cat:" $r3["Category"] "Amt:" $r3["AMOUNT"] "Bal:" $r3["BALANCE"] "Curr:" $r3["ISCURRENT"]
    }
    $r3.Close()
}

$con.Close()
