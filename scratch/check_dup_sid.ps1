$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = 'SELECT s_id, s_name, ADMISSION_NO, branch_id, SessionID, c_id FROM student WHERE s_id IN (SELECT s_id FROM student GROUP BY s_id HAVING COUNT(*) > 1)'
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
$dt | Format-Table -AutoSize | Out-String | Write-Output
$conn.Close()
