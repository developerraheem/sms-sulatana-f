$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM SHIFT WHERE branch_id = 6"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "SHIFT_ID=$($r['SHIFT_ID']) SHIFT='$($r['SHIFT'])' branch_id=$($r['branch_id'])"
}
$conn.Close()
