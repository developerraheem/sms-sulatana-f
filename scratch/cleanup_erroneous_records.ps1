$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()

# 1. Delete erroneous -9 and -8 / +8 detail rows
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_DETAIL_ID IN ('1026383', '1026382', '1026381')"
$deletedDetails = $cmd.ExecuteNonQuery()
Write-Output ("Deleted " + $deletedDetails + " erroneous FEE_DETAIL rows (IDs 1026383, 1026382, 1026381).")

# 2. Delete erroneous fine history rows
$cmd.CommandText = "DELETE FROM FINE_HISTORY WHERE FINE_ID IN ('888804', '888803', '99992')"
$deletedFines = $cmd.ExecuteNonQuery()
Write-Output ("Deleted " + $deletedFines + " erroneous FINE_HISTORY rows (IDs 888804, 888803, 99992).")

# 3. Recalculate FEE_MASTER for Voucher 1 and 2
$cmd.CommandText = @"
UPDATE FEE_MASTER 
SET RECEIVABLE_AMOUNT = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '1' AND SessionID = '81' AND branch_id = '2'),
    BALANCE = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '1' AND SessionID = '81' AND branch_id = '2') - ISNULL(REC_AMOUNT, 0)
WHERE FEE_MASTER_ID = '1' AND SessionID = '81' AND branch_id = '2';

UPDATE FEE_MASTER 
SET RECEIVABLE_AMOUNT = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'),
    BALANCE = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2') - ISNULL(REC_AMOUNT, 0)
WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2';
"@
$cmd.ExecuteNonQuery()
Write-Output "Recalculated FEE_MASTER 1 and 2."

# 4. Verify Voucher 1 (Aqsa Shahzad)
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '1' AND SessionID = '81' AND branch_id = '2'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Voucher 1: RECEIVABLE=" + $r["RECEIVABLE_AMOUNT"] + ", BALANCE=" + $r["BALANCE"])
}
$r.Close()

$cmd.CommandText = "SELECT d.FEE_DETAIL_ID, d.Fee_head_id, h.Fee_Head, d.AMOUNT FROM FEE_DETAIL d LEFT JOIN FEE_HEAD h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID = '1' AND d.SessionID = '81' AND d.branch_id = '2'"
$r2 = $cmd.ExecuteReader()
Write-Output "--- Clean Details for Voucher 1 ---"
while ($r2.Read()) {
    Write-Output ("Detail: Head=" + $r2["Fee_Head"] + " (ID " + $r2["Fee_head_id"] + "), AMOUNT=" + $r2["AMOUNT"])
}
$r2.Close()

# 5. Verify Voucher 2 (Fatima Noor)
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'"
$r3 = $cmd.ExecuteReader()
while ($r3.Read()) {
    Write-Output ("Voucher 2: RECEIVABLE=" + $r3["RECEIVABLE_AMOUNT"] + ", BALANCE=" + $r3["BALANCE"])
}
$r3.Close()

$cmd.CommandText = "SELECT d.FEE_DETAIL_ID, d.Fee_head_id, h.Fee_Head, d.AMOUNT FROM FEE_DETAIL d LEFT JOIN FEE_HEAD h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID = '2' AND d.SessionID = '81' AND d.branch_id = '2'"
$r4 = $cmd.ExecuteReader()
Write-Output "--- Clean Details for Voucher 2 ---"
while ($r4.Read()) {
    Write-Output ("Detail: Head=" + $r4["Fee_Head"] + " (ID " + $r4["Fee_head_id"] + "), AMOUNT=" + $r4["AMOUNT"])
}
$r4.Close()

$con.Close()
