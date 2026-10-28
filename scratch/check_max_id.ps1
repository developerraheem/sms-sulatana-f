$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "select max(convert(int,FEE_MASTER_ID))+1 as ids from FEE_MASTER where SESSIONID='12'"
$r = $cmd.ExecuteScalar()
Write-Host "Max ID for session 12:" $r
$cmd.CommandText = "select max(convert(int,FEE_MASTER_ID))+1 as ids from FEE_MASTER"
$r2 = $cmd.ExecuteScalar()
Write-Host "Max ID overall:" $r2
$con.Close()
