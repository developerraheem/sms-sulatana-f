$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT o.name, o.type_desc, m.definition 
FROM sys.sql_modules m 
JOIN sys.objects o ON m.object_id = o.object_id 
WHERE m.definition LIKE '%ARREAR%' OR m.definition LIKE '%BALANCE%'
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "Object:" $r[0] "Type:" $r[1]
}
$r.Close()
$con.Close()
