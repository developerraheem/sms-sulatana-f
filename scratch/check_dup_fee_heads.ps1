$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, Fee_head_id, COUNT(*) as cnt FROM FEE_DETAIL GROUP BY FEE_MASTER_ID, Fee_head_id HAVING COUNT(*) > 1"
$r = $cmd.ExecuteReader()
$found = 0
while ($r.Read()) {
    $found++
    Write-Output ("Duplicate found! MasterID=" + $r["FEE_MASTER_ID"] + ", Head=" + $r["Fee_head_id"] + ", Count=" + $r["cnt"])
}
$r.Close()
if ($found -eq 0) {
    Write-Output "No duplicate fee heads found in any voucher in FEE_DETAIL!"
}
$con.Close()
