$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Inspect one of the duplicate vouchers in branch 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT TOP 1 FEE_MASTER.FEE_MASTER_ID
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.branch_id = 6
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
$dupId = $cmd.ExecuteScalar()
Write-Output "Duplicate FEE_MASTER_ID in Branch 6: $dupId"

# Show all rows for this voucher from each joined table
$cmd.CommandText = @"
SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = $dupId
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dtFM = New-Object System.Data.DataTable
[void]$da.Fill($dtFM)
Write-Output "=== FEE_MASTER row ==="
$dtFM | Format-Table -AutoSize | Out-String | Write-Output

$s_id = $dtFM.Rows[0]['s_id']
$c_id = $dtFM.Rows[0]['C_ID']

$cmd.CommandText = @"
SELECT * FROM student WHERE s_id = '$s_id'
"@
$dtStd = New-Object System.Data.DataTable
[void]$da.Fill($dtStd)
Write-Output "=== student row(s) for s_id $s_id ==="
$dtStd | Select-Object s_id, s_name, ADMISSION_NO, SECTION_ID, branch_id, SessionID, c_id | Format-Table -AutoSize | Out-String | Write-Output

$secId = $dtStd.Rows[0]['SECTION_ID']

$cmd.CommandText = @"
SELECT * FROM Sections WHERE SECTION_ID = '$secId'
"@
$dtSec = New-Object System.Data.DataTable
[void]$da.Fill($dtSec)
Write-Output "=== Sections row(s) for SECTION_ID '$secId' ==="
$dtSec | Format-Table -AutoSize | Out-String | Write-Output

# Show the joined output for this voucher
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, student.s_id, student.s_name, Sections.SECTION_ID, Sections.BRANCH_ID as SecBranch, Sections.SECTION_NAME,
       FEE_MASTER.branch_id as FmBranch, student.branch_id as StdBranch, class.branch_id as ClassBranch
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.FEE_MASTER_ID = $dupId
"@
$dtJoined = New-Object System.Data.DataTable
[void]$da.Fill($dtJoined)
Write-Output "=== Joined output for voucher $dupId ==="
$dtJoined | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
