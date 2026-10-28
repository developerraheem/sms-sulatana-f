$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COLUMNPROPERTY(OBJECT_ID('FEE_CLASS'), 'FEE_CLASS_ID', 'IsIdentity')"
$isId = $cmd.ExecuteScalar()
Write-Output "FEE_CLASS_ID IsIdentity: $isId"

$cmd.CommandText = "SELECT MAX(FEE_CLASS_ID) FROM FEE_CLASS"
$maxId = $cmd.ExecuteScalar()
Write-Output "MAX FEE_CLASS_ID: $maxId"

$con.Close()
