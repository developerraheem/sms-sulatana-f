$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Test all FEE_HISTORY queries for Branch 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "FEE_HISTORY query with student.c_id = class.c_id duplicate vouchers in branch 6: $($dt.Rows.Count)"

# Now what if student.c_id != class.c_id?
# Check how many vouchers in FEE_MASTER for branch 6 don't match student.c_id = class.c_id
$cmd.CommandText = @"
SELECT COUNT(*) as MissingCount
FROM FEE_MASTER fm
INNER JOIN student s ON fm.s_id = s.s_id AND fm.branch_id = s.branch_id
WHERE fm.branch_id = 6 AND fm.C_ID <> s.c_id
"@
$missing = $cmd.ExecuteScalar()
Write-Output "Vouchers in branch 6 where fm.C_ID <> s.c_id: $missing"

# Wait, what if Sections has multiple matching rows or what if student has duplicates?
# Check students in branch 6 with duplicate s_id or ADMISSION_NO
$cmd.CommandText = @"
SELECT s_id, COUNT(*) as cnt
FROM student
WHERE branch_id = 6
GROUP BY s_id
HAVING COUNT(*) > 1
"@
$dtDupSid = New-Object System.Data.DataTable
[void]$da.Fill($dtDupSid)
Write-Output "Duplicate s_id within branch 6: $($dtDupSid.Rows.Count)"

$cmd.CommandText = @"
SELECT s_id, COUNT(*) as cnt
FROM student
GROUP BY s_id
HAVING COUNT(*) > 1
"@
$dtDupSidAll = New-Object System.Data.DataTable
[void]$da.Fill($dtDupSidAll)
Write-Output "Duplicate s_id across all branches: $($dtDupSidAll.Rows.Count)"

$conn.Close()
