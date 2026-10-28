$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()

$master_id = "1"
$classid = "64"
$month = "11 2026"
$monthfrom = "11 2026"
$SHIFT = "Morning"
$SessionID = "12"
$branch_id = "1"
$sectionID = "Female"
$DUE_DATE = "2026-11-10"
$tmonths = "1"
$tfine = "0"
$barcode = "*abc1*"
$remarks = "Test Note"
$ISSUE_DATE = "2026-11-01"
$startdate = "2026-11-01"
$enddate = "2026-11-30"

$q1 = "SET DATEFORMAT ymd; Insert into FEE_MASTER(FEE_MASTER_ID,s_id,C_ID,FEE_MONTH,SHIFT,FEE_MONTH_FROM,MULTITAG,SessionID,DUE_DATE,T_MONTHS,FINE_AFTER_DUE_DATE,BARCODE,BRANCH_ID,REMARKS,ISSUE_DATE,startdate,enddate) VALUES('$master_id','2093','$classid','$month','$SHIFT','$monthfrom','Y','$SessionID','$DUE_DATE','$tmonths','$tfine','$barcode','$branch_id','$remarks','$ISSUE_DATE','$startdate','$enddate')"

$tran = $con.BeginTransaction()
$cmd = $con.CreateCommand()
$cmd.Transaction = $tran
$cmd.CommandText = $q1
try {
    $cmd.ExecuteNonQuery()
    Write-Host "Q1 succeeded!"
} catch {
    Write-Host "Q1 FAILED: $_"
}
$tran.Rollback()
$con.Close()
