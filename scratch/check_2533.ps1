$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID=2533"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    for ($i = 0; $i -lt $r.FieldCount; $i++) {
        Write-Output ($r.GetName($i) + ": " + $r.GetValue($i))
    }
}
$r.Close()

Write-Output "--- FEE_DETAIL for 2533 ---"
$cmd.CommandText = "SELECT * FROM FEE_DETAIL WHERE FEE_MASTER_ID=2533"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("DetailID=" + $r["FEE_DETAIL_ID"] + ", Head=" + $r["Fee_head_id"] + ", Amount=" + $r["AMOUNT"] + ", Balance=" + $r["BALANCE"])
}
$r.Close()

$con.Close()
