$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT DISTINCT TYPE FROM student"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Output "Distinct student.TYPE:"
$dt | Format-Table -AutoSize | Out-String | Write-Output

$cmd.CommandText = "SELECT DISTINCT TYPE FROM FEE_CLASS"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
Write-Output "Distinct FEE_CLASS.TYPE:"
$dt2 | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
