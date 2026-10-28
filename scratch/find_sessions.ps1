$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM [Sessions] WHERE SessionName LIKE '%2025%'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "Session: SessionID=$($r['SessionID']) SessionName='$($r['SessionName'])' branch_id=$($r['branch_id'])"
}
$conn.Close()
