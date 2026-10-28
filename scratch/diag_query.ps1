$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT b.FINE_ID, b.Fee_head_id, b.FINE_AMOUNT, a.Category, a.Fee_head, b.SessionID, b.branch_id, b.FEE_MONTH, b.active, b.FEE_MASTER_ID FROM FINE_HISTORY b INNER JOIN Fee_Head a ON b.Fee_head_id = a.Fee_head_id WHERE b.FINE_ID = '99992'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("FINE_ID=" + $r[0] + ", Head=" + $r[1] + ", Amt=" + $r[2] + ", Cat=" + $r[3] + ", HeadName=" + $r[4] + ", SessionID=" + $r[5] + ", BranchID=" + $r[6] + ", Month='" + $r[7] + "', active='" + $r[8] + "', MasterID='" + $r[9] + "'")
}
$r.Close()

$cmd.CommandText = "SELECT b.FINE_ID FROM FINE_HISTORY b INNER JOIN Fee_Head a ON b.Fee_head_id = a.Fee_head_id WHERE (b.S_ID = '22578' OR b.S_ID = '26 701') AND (b.active = 'Y' OR b.active LIKE 'Y%') AND (b.FEE_MASTER_ID IS NULL OR b.FEE_MASTER_ID = '') AND b.SessionID = '81' AND b.branch_id = '2' AND (LTRIM(RTRIM(b.FEE_MONTH)) = '10 2026' OR b.FEE_MONTH = '' OR b.FEE_MONTH IS NULL)"
$r = $cmd.ExecuteReader()
$found = $false
while ($r.Read()) {
    $found = $true
    Write-Host ("Found with query: FINE_ID=" + $r[0])
}
if (-not $found) {
    Write-Host "NOT FOUND with query!"
}
$r.Close()
$con.Close()
