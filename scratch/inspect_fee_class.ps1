$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT fc.*, h.Fee_Head, h.Category FROM FEE_CLASS fc LEFT JOIN Fee_Head h ON fc.Fee_head_id = h.Fee_head_id WHERE fc.C_ID = '65' AND fc.ACTIVE = 'true'"
$r = $cmd.ExecuteReader()
Write-Output "--- FEE_CLASS for C_ID = 65 ---"
while ($r.Read()) {
    Write-Output ("Fee_head_id=" + $r["Fee_head_id"] + " (" + $r["Fee_Head"] + "), Category=" + $r["Category"] + ", AMOUNT=" + $r["AMOUNT"] + ", TYPE=" + $r["TYPE"])
}
$r.Close()
$con.Close()
