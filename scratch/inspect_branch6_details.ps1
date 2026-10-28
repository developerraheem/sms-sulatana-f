$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Check student records in branch 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT student.s_id, student.s_name, student.ADMISSION_NO, student.c_id, student.SECTION_ID, student.branch_id, student.SessionID
FROM student
WHERE student.branch_id = 6
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dtStd = New-Object System.Data.DataTable
[void]$da.Fill($dtStd)
Write-Output "Branch 6 Students count: $($dtStd.Rows.Count)"

# Check SECTION_ID values used by students in branch 6
$cmd.CommandText = @"
SELECT DISTINCT student.SECTION_ID, student.branch_id
FROM student
WHERE student.branch_id = 6
"@
$dtSecStd = New-Object System.Data.DataTable
[void]$da.Fill($dtSecStd)
Write-Output "=== Distinct SECTION_IDs in student for branch 6 ==="
$dtSecStd | Format-Table -AutoSize | Out-String | Write-Output

# Check Sections table for branch 6 vs other branches
$cmd.CommandText = @"
SELECT * FROM Sections WHERE SECTION_ID IN (SELECT DISTINCT SECTION_ID FROM student WHERE branch_id = 6)
"@
$dtSec = New-Object System.Data.DataTable
[void]$da.Fill($dtSec)
Write-Output "=== Sections table matching student SECTION_IDs in branch 6 ==="
$dtSec | Format-Table -AutoSize | Out-String | Write-Output

# Check FEE_MASTER in branch 6
$cmd.CommandText = @"
SELECT COUNT(*) as TotalFM, COUNT(DISTINCT FEE_MASTER_ID) as DistinctVouchers,
       COUNT(DISTINCT s_id) as DistinctStudents,
       SessionID, C_ID, FEE_MONTH
FROM FEE_MASTER
WHERE branch_id = 6
GROUP BY SessionID, C_ID, FEE_MONTH
ORDER BY TotalFM DESC
"@
$dtFM = New-Object System.Data.DataTable
[void]$da.Fill($dtFM)
Write-Output "=== FEE_MASTER aggregates in branch 6 ==="
$dtFM | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
