$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM Sections WHERE branch_id = 6"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "SECTION_ID=$($r['SECTION_ID']) SECTION_NAME='$($r['SECTION_NAME'])' branch_id=$($r['branch_id'])"
}
$conn.Close()
