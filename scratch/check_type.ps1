$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = 'SELECT DISTINCT TYPE FROM student WHERE branch_id = 6'
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "=== Student TYPE in Branch 6 ==="
$dt | Format-Table -AutoSize | Out-String | Write-Output

$cmd.CommandText = 'SELECT DISTINCT TYPE FROM view_fee WHERE s_id IN (SELECT s_id FROM student WHERE branch_id = 6)'
$dtV = New-Object System.Data.DataTable
[void]$da.Fill($dtV)
Write-Output "=== view_fee TYPE for Branch 6 students ==="
$dtV | Format-Table -AutoSize | Out-String | Write-Output
$conn.Close()
