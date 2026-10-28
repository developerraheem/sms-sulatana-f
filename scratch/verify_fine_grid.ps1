$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()

# Pending view filter test
$cmd.CommandText = "SELECT COUNT(*) FROM FINE_HISTORY b WHERE b.FINE_ID = '99992' AND (b.FEE_MASTER_ID IS NULL OR b.FEE_MASTER_ID = '') AND (b.active = 'Y' OR b.active LIKE 'Y%')"
$pendingCount = $cmd.ExecuteScalar()
Write-Host ("In Pending Filter: " + $pendingCount + " (Expected: 0)")

# Applied view filter test
$cmd.CommandText = "SELECT b.FINE_ID, b.active, b.FEE_MASTER_ID FROM FINE_HISTORY b WHERE b.FINE_ID = '99992' AND ((b.FEE_MASTER_ID IS NOT NULL AND b.FEE_MASTER_ID <> '') OR b.active = 'N')"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    $mId = $r[2].ToString().Trim()
    $status = if ($mId) { "Applied (#$mId)" } else { "Applied" }
    Write-Host ("In Applied Filter: FINE_ID=" + $r[0] + " | Status=" + $status + " (Expected: Applied (#2))")
}
$r.Close()
$con.Close()
