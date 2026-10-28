$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT fc.FEE_CLASS_ID, fc.Fee_head_id, fc.C_ID, fc.TYPE, fc.AMOUNT, fc.ACTIVE, fc.branch_id, fh.Fee_head FROM FEE_CLASS fc JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID=176"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-Table -AutoSize | Out-String | Write-Output
$conn.Close()
