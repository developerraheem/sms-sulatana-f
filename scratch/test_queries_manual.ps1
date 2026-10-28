$ErrorActionPreference = "Stop"
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$paidamountbyform = 3000.0
$voucherno = "1"
$sessionId = "12"
$branchId = "1"
$receivable_amount = 9000.0
$balance = 6000.0
$sDateStr = "2026-11-05 00:00:00"
$sDateNew = "2026-11-05"
$sid = "2093"

Write-Host "Query 1: Update student..."
$cmd.CommandText = "UPDATE student set isconfirm='True' where s_id='$sid' and SessionID='$sessionId'"
$cmd.ExecuteNonQuery() | Out-Null
Write-Host "Query 1 OK."

Write-Host "Query 2: Update FEE_MASTER with SC01 (4 chars)..."
$cmd.CommandText = "Update FEE_MASTER set REC_AMOUNT='$paidamountbyform', SUBMIT_DATE='$sDateStr',RECEIVABLE_AMOUNT='$receivable_amount',PAID='Y',BALANCE ='$balance', STATUS='Y',BANK_ID='1',SCROLLNO='SC01',FINE_AFTER_DUE_DATE=0 WHERE FEE_MASTER_ID='$voucherno' and SessionID='$sessionId'"
$cmd.ExecuteNonQuery() | Out-Null
Write-Host "Query 2 OK."

Write-Host "Query 3: Select FEE_DETAIL..."
$cmd.CommandText = "select AMOUNT, FEE_DETAIL_ID from FEE_DETAIL where FEE_MASTER_ID='$voucherno' and SessionID='$sessionId' order by AMOUNT"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Host "FEE_DETAIL count: $($dt.Rows.Count)"

Write-Host "Query 4: Insert FEE_HISTORY..."
$cmd.CommandText = "Insert into FEE_HISTORY(VOUCHER_NO,SUBMITION_DATE,PAID_AMOUNT,SessionID,SUBMISSION_DATE_NEW,BRANCH_ID)VALUES('$voucherno','11/5/2026','$paidamountbyform','$sessionId','$sDateNew','$branchId')"
$cmd.ExecuteNonQuery() | Out-Null
Write-Host "Query 4 OK."

$con.Close()
Write-Host "All manual queries executed in < 1 second!"
