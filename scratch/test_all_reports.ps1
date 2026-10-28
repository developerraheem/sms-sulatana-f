$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Host "============================================================"
Write-Host "CHECKING REPORT 1: FEE_HISTORYTableAdapter (Report_DataSet_new)"
Write-Host "============================================================"

# Check FillBy1_ALLL:
# SELECT FEE_MASTER.FEE_MASTER_ID, student.s_id, ... WHERE (FEE_MASTER.SessionID = @sessionid)
# NOTICE: FillBy1_ALLL has NO branch filter in WHERE clause!
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT COUNT(*), COUNT(DISTINCT FEE_MASTER.FEE_MASTER_ID)
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE (FEE_MASTER.SessionID = 49)
"@
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host ("FillBy1_ALLL Session 49 (no branch filter in WHERE): Total rows=" + $r[0] + ", Distinct Vouchers=" + $r[1])
}
$r.Close()

# What branches are in Session 49?
$cmd.CommandText = "SELECT DISTINCT branch_id FROM FEE_MASTER WHERE SessionID = 49"
$r = $cmd.ExecuteReader()
while ($r.Read()) { Write-Host ("Branches in Session 49: " + $r[0]) }
$r.Close()

# What branches are in Session 68?
$cmd.CommandText = "SELECT DISTINCT branch_id FROM FEE_MASTER WHERE SessionID = 68"
$r = $cmd.ExecuteReader()
while ($r.Read()) { Write-Host ("Branches in Session 68: " + $r[0]) }
$r.Close()

Write-Host "`n============================================================"
Write-Host "CHECKING REPORT 2: HEAD_STUDENT_WISE_FEE (DataSet_Fee_Summary_Reports)"
Write-Host "============================================================"
# Query: FillBy_ALL
# Let's test FillBy_ALL for Branch 6 (Session 49, Month 05 2025, classes 122-182, etc.)
$cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, COUNT(*) as cnt
FROM view_fee INNER JOIN
     student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE (student.SessionID = 49) AND (view_fee.FEE_MONTH_FROM = '05 2025')
GROUP BY view_fee.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupViewFee49 = 0
while ($r.Read()) {
    $dupViewFee49++
}
$r.Close()
Write-Host ("FillBy_ALL Session 49 (Month 05 2025): Vouchers with multiple rows = " + $dupViewFee49)

# Now check Session 68:
$cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, COUNT(*) as cnt
FROM view_fee INNER JOIN
     student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE (student.SessionID = 68) AND (view_fee.FEE_MONTH_FROM = '06 2026')
GROUP BY view_fee.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupViewFee68 = 0
while ($r.Read()) {
    $dupViewFee68++
}
$r.Close()
Write-Host ("FillBy_ALL Session 68 (Month 06 2026): Vouchers with multiple rows = " + $dupViewFee68)

Write-Host "`n============================================================"
Write-Host "CHECKING REPORT 3: DEFAULTER_DETAIL (Report_DataSet_new)"
Write-Host "============================================================"
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id
WHERE (FEE_MASTER.FEE_MONTH = '05 2025') AND (FEE_MASTER.SessionID = 49) AND FEE_MASTER.BALANCE > 0
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
$dupDef = 0
while ($r.Read()) {
    Write-Host ("DEFAULTER_DETAIL duplicate voucher: " + $r[0] + " count=" + $r[1])
    $dupDef++
}
$r.Close()
Write-Host ("DEFAULTER_DETAIL Session 49 (Month 05 2025): Vouchers with duplicates = " + $dupDef)

$conn.Close()
