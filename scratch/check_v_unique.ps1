$con = New-Object System.Data.SqlClient.SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE FEE_MASTER_ID = '455' AND branch_id = '6'"
Write-Host "Count of 455 in branch 6:" $cmd.ExecuteScalar()

$cmd.CommandText = "SELECT FEE_MASTER_ID, COUNT(*) FROM FEE_MASTER WHERE branch_id = '6' GROUP BY FEE_MASTER_ID HAVING COUNT(*) > 1"
$r = $cmd.ExecuteReader()
$hasDup = $false
while($r.Read()) {
    $hasDup = $true
    Write-Host "Duplicate voucher in branch 6:" $r[0] "count:" $r[1]
}
$r.Close()
if (-not $hasDup) {
    Write-Host "Within branch 6, FEE_MASTER_ID is completely UNIQUE across all sessions!"
}
$con.Close()
