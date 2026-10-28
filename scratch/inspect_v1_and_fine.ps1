$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT TOP 10 * FROM FEE_HEAD"
$r = $cmd.ExecuteReader()
Write-Output "--- FEE_HEAD ---"
while ($r.Read()) {
    $line = ""
    for ($i=0; $i -lt $r.FieldCount; $i++) {
        $line += $r.GetName($i) + "=" + $r.GetValue($i) + ", "
    }
    Write-Output $line
}
$r.Close()

$cmd.CommandText = "SELECT * FROM FINE_HISTORY WHERE FINE_ID IN ('888804', '888803', '99992', '888801', '888802')"
$r2 = $cmd.ExecuteReader()
Write-Output "`n--- FINE_HISTORY ---"
while ($r2.Read()) {
    $line = ""
    for ($i=0; $i -lt $r2.FieldCount; $i++) {
        $line += $r2.GetName($i) + "=" + $r2.GetValue($i) + ", "
    }
    Write-Output $line
}
$r2.Close()

$cmd.CommandText = "SELECT * FROM FEE_DETAIL WHERE FEE_MASTER_ID = '1'"
$r3 = $cmd.ExecuteReader()
Write-Output "`n--- FEE_DETAIL for FEE_MASTER_ID=1 ---"
while ($r3.Read()) {
    $line = ""
    for ($i=0; $i -lt $r3.FieldCount; $i++) {
        $line += $r3.GetName($i) + "=" + $r3.GetValue($i) + ", "
    }
    Write-Output $line
}
$r3.Close()

$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = '1'"
$r4 = $cmd.ExecuteReader()
Write-Output "`n--- FEE_MASTER for FEE_MASTER_ID=1 ---"
while ($r4.Read()) {
    $line = ""
    for ($i=0; $i -lt $r4.FieldCount; $i++) {
        $line += $r4.GetName($i) + "=" + $r4.GetValue($i) + ", "
    }
    Write-Output $line
}
$r4.Close()

$con.Close()
