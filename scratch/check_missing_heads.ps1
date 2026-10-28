$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) as missing_heads FROM FEE_DETAIL fd LEFT JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fh.Fee_head_id IS NULL"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
Write-Host "Missing heads:" $ds.Tables[0].Rows[0]["missing_heads"]
$conn.Close()
