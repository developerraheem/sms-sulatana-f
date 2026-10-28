$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = '455'"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-List | Out-String | Write-Output

$cmd.CommandText = "SELECT * FROM FEE_DETAIL WHERE FEE_MASTER_ID = '455'"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
$dt2 | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
