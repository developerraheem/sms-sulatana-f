$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

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

# Check distinct SECTION_ID in student where branch_id = 6
$cmd.CommandText = @"
SELECT DISTINCT student.SECTION_ID
FROM student
WHERE student.branch_id = 6
"@
$dtSecs = New-Object System.Data.DataTable
[void]$da.Fill($dtSecs)
Write-Output "=== Distinct SECTION_IDs in student for branch 6 ==="
$dtSecs | Format-Table -AutoSize | Out-String | Write-Output

# Are all these SECTION_IDs present in Sections where BRANCH_ID = 6?
$cmd.CommandText = @"
SELECT DISTINCT student.SECTION_ID
FROM student
WHERE student.branch_id = 6
  AND student.SECTION_ID NOT IN (SELECT SECTION_ID FROM Sections WHERE BRANCH_ID = 6)
"@
$dtMissingSec = New-Object System.Data.DataTable
[void]$da.Fill($dtMissingSec)
Write-Output "=== SECTION_IDs in student (branch 6) missing from Sections (branch 6) ==="
$dtMissingSec | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
