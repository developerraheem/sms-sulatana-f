$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT name, parent_class_desc, create_date, modify_date FROM sys.triggers"
$r = $cmd.ExecuteReader()
$count = 0
while ($r.Read()) {
    Write-Host "Trigger: $($r['name']) on $($r['parent_class_desc'])"
    $count++
}
if ($count -eq 0) { Write-Host "No triggers found." }
$conn.Close()
