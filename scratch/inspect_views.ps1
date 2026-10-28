$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT o.name, o.type_desc, m.definition FROM sys.objects o LEFT JOIN sys.sql_modules m ON o.object_id = m.object_id WHERE o.name IN ('Temp', 'TempDetail')"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Name:" $r[0] "Type:" $r[1]
    Write-Host "Definition:"
    Write-Host $r[2]
    Write-Host "============================================="
}
$con.Close()
