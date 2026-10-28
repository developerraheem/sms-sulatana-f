$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Host "=== 1. Branch 6 info ==="
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT Branch_ID, Branch_Name FROM branch WHERE Branch_ID = 6"
$r = $cmd.ExecuteReader()
while ($r.Read()) { Write-Host ("Branch: " + $r[0] + " - " + $r[1]) }
$r.Close()

Write-Host "`n=== 2. Sessions in Branch 6 ==="
$cmd.CommandText = "SELECT DISTINCT SessionID, branch_id FROM FEE_MASTER WHERE branch_id = 6"
$r = $cmd.ExecuteReader()
while ($r.Read()) { Write-Host ("SessionID: " + $r[0] + " in branch " + $r[1]) }
$r.Close()

Write-Host "`n=== 3. Classes in Branch 6 ==="
$cmd.CommandText = "SELECT c_id, c_name FROM class WHERE branch_id = 6 ORDER BY c_id"
$r = $cmd.ExecuteReader()
while ($r.Read()) { Write-Host ("Class: " + $r[0] + " - " + $r[1]) }
$r.Close()

Write-Host "`n=== 4. Test FEE_HISTORY queries in Report_DataSet_new for Branch 6 ==="
# Test query 1: Fill
# Check if any (class, shift, month, session) in Branch 6 returns duplicate vouchers:
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupCount = 0
while ($r.Read()) {
    Write-Host ("Duplicate FEE_MASTER_ID with student.c_id=class.c_id: " + $r[0] + " count=" + $r[1])
    $dupCount++
}
$r.Close()
Write-Host "Total duplicate vouchers with student.c_id=class.c_id: $dupCount"

Write-Host "`n=== 5. What if we remove student.c_id = class.c_id? ==="
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupCount2 = 0
while ($r.Read()) {
    Write-Host ("Duplicate FEE_MASTER_ID without student.c_id=class.c_id: " + $r[0] + " count=" + $r[1])
    $dupCount2++
}
$r.Close()
Write-Host "Total duplicate vouchers without student.c_id=class.c_id: $dupCount2"

Write-Host "`n=== 6. What about vouchers in Branch 6 dropped by student.c_id = class.c_id? ==="
$cmd.CommandText = @"
SELECT f.FEE_MASTER_ID, f.s_id, f.C_ID as voucher_cid, s.c_id as student_cid, f.SessionID, f.FEE_MONTH
FROM FEE_MASTER f
INNER JOIN student s ON f.s_id = s.s_id AND f.branch_id = s.branch_id
WHERE f.branch_id = 6 AND f.C_ID != s.c_id
"@
$r = $cmd.ExecuteReader()
$droppedCount = 0
while ($r.Read()) {
    Write-Host ("Voucher dropped by student.c_id=class.c_id: Voucher " + $r[0] + ", s_id=" + $r[1] + ", voucher_cid=" + $r[2] + ", student_cid=" + $r[3] + ", session=" + $r[4] + ", month=" + $r[5])
    $droppedCount++
}
$r.Close()
Write-Host "Total vouchers dropped because student was promoted/changed class: $droppedCount"

$conn.Close()
