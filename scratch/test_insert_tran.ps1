$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$tran = $con.BeginTransaction()
$cmd = $con.CreateCommand()
$cmd.Transaction = $tran

try {
    $master_id = "1"
    $barcode = "*1231*"
    $qMaster = "Insert into FEE_MASTER(FEE_MASTER_ID,s_id,C_ID,FEE_MONTH,SHIFT,FEE_MONTH_FROM,MULTITAG,SessionID,DUE_DATE,T_MONTHS,FINE_AFTER_DUE_DATE,BARCODE,BRANCH_ID,REMARKS,ISSUE_DATE,startdate,enddate) VALUES('$master_id','2093','64','11 2026','Morning','11 2026','Y','12','10/11/2026','1','0','$barcode','1','Test Note','01/11/2026','01/11/2026','30/11/2026')"
    $cmd.CommandText = $qMaster
    $cmd.ExecuteNonQuery()
    Write-Host "FEE_MASTER insert succeeded."

    $qDetail1 = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SessionID,branch_id) VALUES($master_id,39,4000,'11 2026','Y','4000','11 2026','12','1')"
    $cmd.CommandText = $qDetail1
    $cmd.ExecuteNonQuery()
    Write-Host "FEE_DETAIL 1 insert succeeded."

    $qUpdateMaster = "Update FEE_MASTER Set RECEIVABLE_AMOUNT='9000', BALANCE='9000' WHERE FEE_MASTER_ID='$master_id' AND SESSIONID='12' and branch_id='1'"
    $cmd.CommandText = $qUpdateMaster
    $cmd.ExecuteNonQuery()
    Write-Host "FEE_MASTER update succeeded."
} catch {
    Write-Host "ERROR: $($_.Exception.Message)"
} finally {
    $tran.Rollback()
    Write-Host "Transaction rolled back cleanly."
    $con.Close()
}
