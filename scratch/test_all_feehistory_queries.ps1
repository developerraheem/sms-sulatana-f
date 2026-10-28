$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# 1. Test StudentWiseList for all students in branch 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT student.ADMISSION_NO, FEE_MASTER.SESSIONID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6
GROUP BY student.ADMISSION_NO, FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "StudentWiseList duplicates in branch 6: $($dt.Rows.Count)"

# 2. Test Unpaid for all combinations in branch 6
$cmd.CommandText = @"
SELECT FEE_MASTER.C_ID, FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, Sections.SECTION_NAME, FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6 AND (FEE_MASTER.PAID IS NULL OR FEE_MASTER.PAID = 'N')
GROUP BY FEE_MASTER.C_ID, FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, Sections.SECTION_NAME, FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$dtUnpaid = New-Object System.Data.DataTable
[void]$da.Fill($dtUnpaid)
Write-Output "Unpaid duplicates in branch 6: $($dtUnpaid.Rows.Count)"

# 3. Test Paid for all combinations in branch 6
$cmd.CommandText = @"
SELECT FEE_MASTER.C_ID, FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6 AND FEE_MASTER.PAID = 'Y'
GROUP BY FEE_MASTER.C_ID, FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$dtPaid = New-Object System.Data.DataTable
[void]$da.Fill($dtPaid)
Write-Output "Paid duplicates in branch 6: $($dtPaid.Rows.Count)"

# 4. Test FillBy1_All_classwise for all combinations in branch 6
$cmd.CommandText = @"
SELECT FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, Sections.SECTION_NAME, FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6
GROUP BY FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, Sections.SECTION_NAME, FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$dtClasswise = New-Object System.Data.DataTable
[void]$da.Fill($dtClasswise)
Write-Output "FillBy1_All_classwise duplicates in branch 6: $($dtClasswise.Rows.Count)"

# 5. Test FillBy1_ALLL for all sessions in branch 6
$cmd.CommandText = @"
SELECT FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6
GROUP BY FEE_MASTER.SESSIONID, FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$dtAll = New-Object System.Data.DataTable
[void]$da.Fill($dtAll)
Write-Output "FillBy1_ALLL duplicates in branch 6: $($dtAll.Rows.Count)"

$conn.Close()
