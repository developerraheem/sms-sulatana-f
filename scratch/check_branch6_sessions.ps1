$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Check students in branch 6 with multiple session records or duplicate s_id across sessions
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT s_id, COUNT(*) as cnt, COUNT(DISTINCT SessionID) as SessCount
FROM student
WHERE branch_id = 6
GROUP BY s_id
HAVING COUNT(*) > 1
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "Branch 6 students with multiple rows in student table: $($dt.Rows.Count)"

# Check students in branch 6 with same ADMISSION_NO across sessions
$cmd.CommandText = @"
SELECT ADMISSION_NO, COUNT(*) as cnt, COUNT(DISTINCT SessionID) as SessCount
FROM student
WHERE branch_id = 6
GROUP BY ADMISSION_NO
HAVING COUNT(*) > 1
"@
$dtAdm = New-Object System.Data.DataTable
[void]$da.Fill($dtAdm)
Write-Output "Branch 6 students with same ADMISSION_NO across multiple rows: $($dtAdm.Rows.Count)"
if ($dtAdm.Rows.Count -gt 0) {
    $dtAdm | Select-Object -First 10 | Format-Table -AutoSize | Out-String | Write-Output
}

$conn.Close()
