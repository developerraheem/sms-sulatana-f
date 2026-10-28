$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 1 * FROM student WHERE s_id='22659'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    foreach ($col in @("s_id", "C_ID", "ACTIVE", "SHIFT", "SessionID", "branch_id", "SECTION_ID", "TYPE", "CONCESSION_FEE")) {
        Write-Host "$col = $($r[$col])"
    }
}
$r.Close()
$con.Close()
