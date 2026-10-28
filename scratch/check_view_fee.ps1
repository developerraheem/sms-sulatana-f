$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT OBJECT_DEFINITION(OBJECT_ID('dbo.view_fee'))"
$def = $cmd.ExecuteScalar()
Write-Host "view_fee definition:"
Write-Host $def
$con.Close()
