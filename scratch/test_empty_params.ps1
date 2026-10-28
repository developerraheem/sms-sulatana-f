$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$queries = @(
    "SELECT * FROM student WHERE s_id = ''",
    "SELECT * FROM student WHERE c_id = ''",
    "SELECT * FROM student WHERE branch_id = ''",
    "SELECT * FROM student WHERE s_id IN ('')",
    "SELECT * FROM student WHERE s_id IN ()",
    "SELECT * FROM student WHERE c_id = 'System.Data.DataRowView'",
    "SELECT * FROM student WHERE s_id in (ITSI-2026-DIT-29-1-786786)",
    "SELECT * FROM student WHERE s_id in ('ITSI-2026-DIT-29-1-786786')"
)

foreach ($q in $queries) {
    try {
        $cmd = New-Object System.Data.SqlClient.SqlCommand($q, $conn)
        $da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
        $ds = New-Object System.Data.DataSet
        $da.Fill($ds, "student") | Out-Null
        Write-Host "SUCCESS: $q"
    } catch {
        Write-Host "FAILED: $q -> $($_.Exception.Message)"
    }
}
$conn.Close()
