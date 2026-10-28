$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Host "=== TEST 1: Check if any student in Branch 6 has multiple records in student table ==="
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT s_name, ADMISSION_NO, COUNT(*) as cnt
FROM student
WHERE branch_id = 6
GROUP BY s_name, ADMISSION_NO
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupStd = 0
while ($r.Read()) {
    Write-Host ("Duplicate student in Branch 6: Name=" + $r[0] + ", AdmNo=" + $r[1] + ", count=" + $r[2])
    $dupStd++
}
$r.Close()
Write-Host "Total duplicate student profiles in Branch 6: $dupStd"

Write-Host "`n=== TEST 2: Check if any voucher in Branch 6 has multiple records in FEE_MASTER table ==="
$cmd.CommandText = @"
SELECT FEE_MASTER_ID, SessionID, COUNT(*) as cnt
FROM FEE_MASTER
WHERE branch_id = 6
GROUP BY FEE_MASTER_ID, SessionID
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupFm = 0
while ($r.Read()) {
    Write-Host ("Duplicate FEE_MASTER in Branch 6: Voucher=" + $r[0] + ", Session=" + $r[1] + ", count=" + $r[2])
    $dupFm++
}
$r.Close()
Write-Host "Total duplicate FEE_MASTER records in Branch 6: $dupFm"

Write-Host "`n=== TEST 3: Check if same student in Branch 6 has multiple vouchers for same FEE_MONTH in same session ==="
$cmd.CommandText = @"
SELECT s_id, FEE_MONTH, SessionID, COUNT(*) as cnt
FROM FEE_MASTER
WHERE branch_id = 6
GROUP BY s_id, FEE_MONTH, SessionID
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupVoucherForMonth = 0
while ($r.Read()) {
    Write-Host ("Same student has multiple vouchers for same month in Branch 6: s_id=" + $r[0] + ", Month=" + $r[1] + ", Session=" + $r[2] + ", count=" + $r[3])
    $dupVoucherForMonth++
}
$r.Close()
Write-Host "Total repeated vouchers for same student/month in Branch 6: $dupVoucherForMonth"

$conn.Close()
