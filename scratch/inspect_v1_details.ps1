$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT d.*, h.Fee_Head as HeadName FROM FEE_DETAIL d LEFT JOIN FEE_HEAD h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID = '1' AND d.SessionID = '81' AND d.branch_id = '2'"
$r = $cmd.ExecuteReader()
Write-Output "--- FEE_DETAIL for Voucher 1 (Session 81, Branch 2) ---"
while ($r.Read()) {
    $line = ""
    for ($i=0; $i -lt $r.FieldCount; $i++) {
        $line += $r.GetName($i) + "=" + $r.GetValue($i) + ", "
    }
    Write-Output $line
}
$r.Close()

# Also let's check FINE_HISTORY for s_id = 22583
$cmd.CommandText = "SELECT f.*, h.Fee_Head as HeadName FROM FINE_HISTORY f LEFT JOIN FEE_HEAD h ON f.Fee_head_id = h.Fee_head_id WHERE f.s_id = '22583'"
$r2 = $cmd.ExecuteReader()
Write-Output "`n--- FINE_HISTORY for s_id = 22583 ---"
while ($r2.Read()) {
    $line = ""
    for ($i=0; $i -lt $r2.FieldCount; $i++) {
        $line += $r2.GetName($i) + "=" + $r2.GetValue($i) + ", "
    }
    Write-Output $line
}
$r2.Close()
$con.Close()
