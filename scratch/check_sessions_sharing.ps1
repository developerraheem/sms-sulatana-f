$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# 1. Check Sessions table
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM [Sessions] ORDER BY SessionID"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "=== SESSIONS TABLE ==="
$dt | Format-Table -AutoSize | Out-String | Write-Output

# 2. Check if students in different branches have the same SessionID
$cmd.CommandText = @"
SELECT SessionID, COUNT(DISTINCT branch_id) as BranchCount, COUNT(*) as TotalStudents
FROM student
GROUP BY SessionID
HAVING COUNT(DISTINCT branch_id) > 1
ORDER BY BranchCount DESC
"@
$dtSessBranches = New-Object System.Data.DataTable
[void]$da.Fill($dtSessBranches)
Write-Output "=== SESSIONS SHARED ACROSS MULTIPLE BRANCHES ==="
$dtSessBranches | Format-Table -AutoSize | Out-String | Write-Output

# 3. Check if students in different branches share the same ADMISSION_NO in the same SessionID!
$cmd.CommandText = @"
SELECT SessionID, ADMISSION_NO, COUNT(DISTINCT branch_id) as BranchCount, COUNT(*) as TotalStudents
FROM student
GROUP BY SessionID, ADMISSION_NO
HAVING COUNT(DISTINCT branch_id) > 1
ORDER BY BranchCount DESC
"@
$dtAdm = New-Object System.Data.DataTable
[void]$da.Fill($dtAdm)
Write-Output "=== ADMISSION_NO SHARED ACROSS BRANCHES IN SAME SESSION ==="
Write-Output "Count of shared admission numbers: $($dtAdm.Rows.Count)"
$dtAdm | Select-Object -First 10 | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
