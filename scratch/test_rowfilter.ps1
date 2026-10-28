$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$da = New-Object System.Data.SqlClient.SqlDataAdapter("select SessionID,SessionName from Sessions where branch_id='6'", $conn)
$ds = New-Object System.Data.DataSet
$da.Fill($ds, 'Sessions')
$dv = $ds.Tables['Sessions'].DefaultView

Write-Output ("Before filter: " + $dv.Count)
$dv.RowFilter = "SessionName IS NOT NULL AND SessionName <> ''"
Write-Output ("After filter: " + $dv.Count)
for ($i = 0; $i -lt $dv.Count; $i++) {
    Write-Output ("  [" + $i + "] ID=" + $dv[$i]['SessionID'] + " Name=" + $dv[$i]['SessionName'])
}
$conn.Close()
