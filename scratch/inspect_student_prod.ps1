$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE s_id = 88883"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
Write-Host "Found $($dt.Rows.Count) rows for s_id = 88883 in SCMS_SF"
if ($dt.Rows.Count -gt 0) {
    foreach ($col in $dt.Columns) {
        Write-Host "$($col.ColumnName) ($($col.DataType.Name)) = '$($dt.Rows[0][$col])'"
    }
}
$conn.Close()
