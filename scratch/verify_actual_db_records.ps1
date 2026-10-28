$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

Write-Host "====================================================================="
Write-Host " CONDITION 5 VERIFICATION: ACTUAL DATABASE RECORD REPRESENTATION"
Write-Host "====================================================================="

# 1. Inspect ISCURRENT distribution and heads
Write-Host "`n1. ISCURRENT Column Values in FEE_DETAIL:"
$cmd.CommandText = "SELECT ISCURRENT, COUNT(*) as cnt FROM FEE_DETAIL GROUP BY ISCURRENT"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "   ISCURRENT = '$($r['ISCURRENT'])' -> Count: $($r['cnt'])"
}
$r.Close()

# 2. Inspect Fee heads with ISCURRENT = 'N'
Write-Host "`n2. Fee Heads used with ISCURRENT = 'N':"
$cmd.CommandText = @"
SELECT TOP 5 h.Fee_head, h.Category, COUNT(*) as cnt
FROM FEE_DETAIL d
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.ISCURRENT = 'N'
GROUP BY h.Fee_head, h.Category
ORDER BY cnt DESC
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "   Head: '$($r['Fee_head'])', Category: '$($r['Category'])' -> Count: $($r['cnt'])"
}
$r.Close()

# 3. Inspect Payment states: Fully Paid, Partially Paid, Unpaid
Write-Host "`n3. Payment Representation in FEE_MASTER:"
# Unpaid sample
$cmd.CommandText = "SELECT TOP 1 FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE PAID IS NULL AND RECEIVABLE_AMOUNT > 0 AND (BALANCE = RECEIVABLE_AMOUNT)"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "   Unpaid Voucher:     FM_ID: $($r['FEE_MASTER_ID']), Month: $($r['FEE_MONTH']), Recv: $($r['RECEIVABLE_AMOUNT']), RecAmt: '$($r['REC_AMOUNT'])', Bal: $($r['BALANCE']), Paid: '$($r['PAID'])'"
}
$r.Close()

# Partially paid sample
$cmd.CommandText = "SELECT TOP 1 FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE PAID = 'Y' AND REC_AMOUNT > 0 AND BALANCE > 0"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "   Partially Paid:     FM_ID: $($r['FEE_MASTER_ID']), Month: $($r['FEE_MONTH']), Recv: $($r['RECEIVABLE_AMOUNT']), RecAmt: '$($r['REC_AMOUNT'])', Bal: $($r['BALANCE']), Paid: '$($r['PAID'])'"
}
$r.Close()

# Fully paid sample
$cmd.CommandText = "SELECT TOP 1 FEE_MASTER_ID, s_id, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE PAID = 'Y' AND BALANCE = 0 AND REC_AMOUNT > 0"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "   Fully Paid:         FM_ID: $($r['FEE_MASTER_ID']), Month: $($r['FEE_MONTH']), Recv: $($r['RECEIVABLE_AMOUNT']), RecAmt: '$($r['REC_AMOUNT'])', Bal: $($r['BALANCE']), Paid: '$($r['PAID'])'"
}
$r.Close()

# 4. Concession representation
Write-Host "`n4. Concession Representation in FEE_DETAIL:"
$cmd.CommandText = @"
SELECT TOP 2 d.FEE_MASTER_ID, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT
FROM FEE_DETAIL d
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.AMOUNT < 0
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "   Concession Line: FM_ID: $($r['FEE_MASTER_ID']), Head: '$($r['Fee_head'])', Cat: '$($r['Category'])', Amt: $($r['AMOUNT']), IsCurrent: '$($r['ISCURRENT'])'"
}
$r.Close()

$con.Close()
