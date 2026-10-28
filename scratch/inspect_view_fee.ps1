$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT OBJECT_DEFINITION(OBJECT_ID('view_fee'))"
$def = $cmd.ExecuteScalar()
Write-Host "view_fee definition:"
Write-Host $def

$conn.Close()
