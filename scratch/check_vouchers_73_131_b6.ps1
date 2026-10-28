$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE branch_id = 6 AND FEE_MASTER_ID IN (73, 131)"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "Vouchers 73 and 131 in Branch 6: $($dt.Rows.Count)"
$dt | Format-Table -AutoSize | Out-String | Write-Output
$conn.Close()
