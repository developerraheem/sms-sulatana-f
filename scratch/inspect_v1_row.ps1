$ErrorActionPreference = "Stop"
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

# Let's inspect voucher 1
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = '1' AND SessionID = '12'"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Host "Voucher 1 row count: $($dt.Rows.Count)"
foreach ($col in $dt.Columns) {
    Write-Host "$($col.ColumnName) = $($dt.Rows[0][$col.ColumnName])"
}
$con.Close()
