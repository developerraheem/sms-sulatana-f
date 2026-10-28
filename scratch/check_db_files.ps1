$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT name, physical_name, state_desc 
FROM sys.master_files 
WHERE database_id = DB_ID('SCMS_SF')
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Logical Name: $($r['name']), File: $($r['physical_name']), State: $($r['state_desc'])"
}
$r.Close()
$con.Close()
