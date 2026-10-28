$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT ISNULL(PAID, '<NULL>') as PAID, COUNT(*) as CNT FROM FEE_MASTER GROUP BY PAID"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "PAID:" $r[0] "Count:" $r[1]
}
$r.Close()

$cmd.CommandText = "SELECT TOP 5 * FROM FEE_DETAIL WHERE Fee_head_id IN (SELECT Fee_head_id FROM Fee_Head WHERE Category='ARREAR' OR Fee_head LIKE '%ARREAR%' OR Fee_head_id='3')"
$r = $cmd.ExecuteReader()
Write-Host "--- ARREAR FEE_DETAIL rows ---"
while($r.Read()) {
    Write-Host "FD_ID:" $r["FEE_DETAIL_ID"] "FM_ID:" $r["FEE_MASTER_ID"] "Head:" $r["Fee_head_id"] "Amount:" $r["AMOUNT"] "Month:" $r["FEE_MONTH"] "MonthFrom:" $r["FEE_MONTH_FROM"] "ISCURRENT:" $r["ISCURRENT"] "Balance:" $r["BALANCE"]
}
$r.Close()

$cmd.CommandText = "SELECT Fee_head_id, Fee_head, Category, branch_id FROM Fee_Head WHERE Category='ARREAR' OR Fee_head LIKE '%ARREAR%' OR Fee_head_id='3'"
$r = $cmd.ExecuteReader()
Write-Host "--- ARREAR Fee_Head rows ---"
while($r.Read()) {
    Write-Host "Head_ID:" $r["Fee_head_id"] "Name:" $r["Fee_head"] "Category:" $r["Category"] "Branch:" $r["branch_id"]
}
$r.Close()

$con.Close()
