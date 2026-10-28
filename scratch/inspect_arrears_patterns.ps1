$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()

$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT TOP 5 m.s_id, COUNT(*) as cnt
FROM FEE_MASTER m
JOIN FEE_DETAIL d ON m.FEE_MASTER_ID = d.FEE_MASTER_ID
WHERE d.ISCURRENT = 'N'
GROUP BY m.s_id
HAVING COUNT(*) >= 2
"@
$r = $cmd.ExecuteReader()
$sids = @()
while($r.Read()) {
    $sids += $r[0].ToString()
}
$r.Close()

Write-Host "Students with multiple arrears rows: $($sids -join ', ')"

foreach ($sid in $sids) {
    Write-Host "`n=================== Student $sid ==================="
    $cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, FEE_MONTH_FROM, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE s_id = '$sid' ORDER BY FEE_MASTER_ID"
    $r2 = $cmd.ExecuteReader()
    while($r2.Read()) {
        Write-Host "  FM_ID:" $r2["FEE_MASTER_ID"] "Month:" $r2["FEE_MONTH"] "Recv:" $r2["RECEIVABLE_AMOUNT"] "Paid:" $r2["PAID"] "RecAmt:" $r2["REC_AMOUNT"] "Bal:" $r2["BALANCE"]
    }
    $r2.Close()

    $cmd.CommandText = @"
SELECT d.FEE_MASTER_ID, m.FEE_MONTH, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE, d.RECEIVED_AMOUNT
FROM FEE_DETAIL d
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE m.s_id = '$sid'
ORDER BY d.FEE_MASTER_ID, d.FEE_DETAIL_ID
"@
    $r3 = $cmd.ExecuteReader()
    while($r3.Read()) {
        Write-Host "    Detail FM_ID:" $r3["FEE_MASTER_ID"] "Month:" $r3["FEE_MONTH"] "Head:" $r3["Fee_head"] "Amt:" $r3["AMOUNT"] "Curr:" $r3["ISCURRENT"] "Bal:" $r3["BALANCE"]
    }
    $r3.Close()
}

$con.Close()
