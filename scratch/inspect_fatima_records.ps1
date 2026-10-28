$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT f.*, h.Fee_Head as HeadName FROM FINE_HISTORY f LEFT JOIN FEE_HEAD h ON f.Fee_head_id = h.Fee_head_id WHERE f.s_id = '22578'"
$r = $cmd.ExecuteReader()
Write-Output "--- FINE_HISTORY for Fatima Noor (22578) ---"
while ($r.Read()) {
    $line = ""
    for ($i=0; $i -lt $r.FieldCount; $i++) {
        $line += $r.GetName($i) + "=" + $r.GetValue($i) + ", "
    }
    Write-Output $line
}
$r.Close()

$cmd.CommandText = "SELECT fm.FEE_MASTER_ID, fm.RECEIVABLE_AMOUNT, fm.BALANCE, fm.FEE_MONTH FROM FEE_MASTER fm WHERE fm.s_id = '22578' AND fm.SessionID = '81' AND fm.branch_id = '2'"
$r2 = $cmd.ExecuteReader()
Write-Output "`n--- FEE_MASTER for Fatima Noor (22578) ---"
while ($r2.Read()) {
    $line = ""
    for ($i=0; $i -lt $r2.FieldCount; $i++) {
        $line += $r2.GetName($i) + "=" + $r2.GetValue($i) + ", "
    }
    Write-Output $line
}
$r2.Close()

$cmd.CommandText = "SELECT d.*, h.Fee_Head as HeadName FROM FEE_DETAIL d LEFT JOIN FEE_HEAD h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID = '2' AND d.SessionID = '81' AND d.branch_id = '2'"
$r3 = $cmd.ExecuteReader()
Write-Output "`n--- FEE_DETAIL for Voucher 2 (Fatima Noor) ---"
while ($r3.Read()) {
    $line = ""
    for ($i=0; $i -lt $r3.FieldCount; $i++) {
        $line += $r3.GetName($i) + "=" + $r3.GetValue($i) + ", "
    }
    Write-Output $line
}
$r3.Close()
$con.Close()
