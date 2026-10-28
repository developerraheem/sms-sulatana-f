$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=5;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
try {
    $con.Open()
    $cmd = $con.CreateCommand()
    $cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE s_id = '2093' AND SessionID = '12' ORDER BY FEE_MASTER_ID"
    $r = $cmd.ExecuteReader()
    Write-Host "--- Vouchers for 2093 ---"
    while ($r.Read()) {
        Write-Host ("ID: " + $r[0] + " | Month: " + $r[1] + " | Recv: " + $r[2] + " | Rec: " + $r[3] + " | Bal: " + $r[4] + " | Paid: " + $r[5] + " | Status: " + $r[6])
    }
    $r.Close()

    $cmd.CommandText = "SELECT d.FEE_MASTER_ID, d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE FROM FEE_DETAIL d LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '2093' AND SessionID = '12') ORDER BY d.FEE_MASTER_ID, d.FEE_DETAIL_ID"
    $r = $cmd.ExecuteReader()
    Write-Host "--- Fee Details for 2093 ---"
    while ($r.Read()) {
        Write-Host ("MasterID: " + $r[0] + " | HeadID: " + $r[1] + " | Head: " + $r[2] + " | Cat: " + $r[3] + " | Amt: " + $r[4] + " | IsCurrent: " + $r[5] + " | Bal: " + $r[6])
    }
    $r.Close()
    $con.Close()
} catch {
    Write-Host ("Error: " + $_.Exception.Message)
}
