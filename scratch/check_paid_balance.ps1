$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) as paid_with_balance FROM FEE_MASTER WHERE PAID = 'Y' AND BALANCE > 0"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
Write-Host "Vouchers with PAID='Y' and BALANCE > 0:" $ds.Tables[0].Rows[0]["paid_with_balance"]
$conn.Close()
