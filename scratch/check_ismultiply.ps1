$c = New-Object System.Data.SqlClient.SqlConnection "Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$c.Open()
$cmd = $c.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) as total, SUM(CASE WHEN ISMULTIPLY IS NOT NULL AND ISMULTIPLY <> '' THEN 1 ELSE 0 END) as with_mult FROM FEE_CLASS"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Output ("Total FEE_CLASS: " + $r["total"] + ", With ISMULTIPLY: " + $r["with_mult"])
}
$r.Close()
$c.Close()
