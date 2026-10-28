$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$queries = @(
    "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and s_id in (88883) AND SessionID='68' and branch_id='6' and SECTION_ID='Boys'",
    "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' AND SessionID='68' and branch_id='6' and SECTION_ID='Boys'"
)

foreach ($q in $queries) {
    try {
        $cmd = New-Object System.Data.SqlClient.SqlCommand($q, $conn)
        $da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
        $ds = New-Object System.Data.DataSet
        $da.Fill($ds, "student") | Out-Null
        Write-Host "SUCCESS: $q (Rows: $($ds.Tables['student'].Rows.Count))"
    } catch {
        Write-Host "FAILED: $q -> $($_.Exception.Message)"
    }
}
$conn.Close()
