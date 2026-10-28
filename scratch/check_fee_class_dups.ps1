$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT C_ID, Fee_head_id, TYPE, count(*) as cnt FROM FEE_CLASS GROUP BY C_ID, Fee_head_id, TYPE HAVING count(*) > 1"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Output "Duplicates in FEE_CLASS by C_ID, Fee_head_id, TYPE: $($dt.Rows.Count)"
$dt | Format-Table -AutoSize | Out-String | Write-Output
$conn.Close()
