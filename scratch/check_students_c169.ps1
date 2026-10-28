$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT TOP 5 s_id, s_name, c_id, SHIFT, SessionID, branch_id, SECTION_ID FROM student WHERE c_id = 169 and active='true'"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Output "Class 169 students:"
$dt | Format-Table -AutoSize | Out-String | Write-Output

$cmd.CommandText = "SELECT TOP 5 s_id, s_name, c_id, SHIFT, SessionID, branch_id, SECTION_ID FROM student WHERE c_id = 16 and active='true'"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
Write-Output "Class 16 students:"
$dt2 | Format-Table -AutoSize | Out-String | Write-Output
$conn.Close()
