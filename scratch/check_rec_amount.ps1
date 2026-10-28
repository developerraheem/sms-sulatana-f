$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE REC_AMOUNT = 0"
$countZero = $cmd.ExecuteScalar()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE REC_AMOUNT IS NULL"
$countNull = $cmd.ExecuteScalar()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE REC_AMOUNT > 0"
$countPos = $cmd.ExecuteScalar()
Write-Host "REC_AMOUNT = 0: $countZero"
Write-Host "REC_AMOUNT IS NULL: $countNull"
Write-Host "REC_AMOUNT > 0: $countPos"
$con.Close()
