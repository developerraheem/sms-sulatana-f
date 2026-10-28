$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT branch_id, branch_name FROM branch"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-Table -AutoSize | Out-String | Write-Output

$cmd.CommandText = "SELECT sessionid, session_name FROM session_tbl"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
$dt2 | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
