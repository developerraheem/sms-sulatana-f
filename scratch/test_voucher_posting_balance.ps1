$ErrorActionPreference = "Stop"

Write-Host "======================================================================"
Write-Host "TEST SUITE: Voucher Posting Balance Preservation (SCMS_SF_TEST only)"
Write-Host "======================================================================"

# Point to SCMS_SF_TEST in-memory
$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$submitMethod = $feeType.GetMethod("submitfeeSingle")

$frmFeeEntryType = $asm.GetType("School._forms.Frm_FeeEntry")

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$allPass = $true

function Report-Result($testName, $passed, $details) {
    if ($passed) {
        Write-Host "[PASS] $testName - $details" -ForegroundColor Green
    } else {
        Write-Host "[FAIL] $testName - $details" -ForegroundColor Red
        $script:allPass = $false
    }
}

function Invoke-SearchVoucher($formInstance, $voucherId) {
    $txtreceiptno = $frmFeeEntryType.GetField("txtreceiptno", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($formInstance)
    $txtreceiptno.Text = $voucherId.ToString()
    
    $feeListDetailMethod = $frmFeeEntryType.GetMethod("FeeList_Detail", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
    $feeListDetailMethod.Invoke($formInstance, $null)
}

# Branch 1, Session 12, Student 2093
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")
$sid = "2093"
$cid = "64"

# Clean any existing test voucher for fee month '09 2026'
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '09 2026') AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '09 2026') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '09 2026';
"@
$cmd.ExecuteNonQuery() | Out-Null

# STEP 1: Generate an Rs. 8,000 test voucher
$cmd.CommandText = "SELECT ISNULL(MAX(CONVERT(INT, FEE_MASTER_ID)), 0) + 1 FROM FEE_MASTER WHERE SessionID = '12'"
$testVoucherId = ($cmd.ExecuteScalar()).ToString()

$cmd.CommandText = @"
INSERT INTO FEE_MASTER (FEE_MASTER_ID, s_id, c_id, SessionID, branch_id, FEE_MONTH, FEE_MONTH_FROM, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS, DUE_DATE, FINE_AFTER_DUE_DATE, MULTITAG)
VALUES ('$testVoucherId', '$sid', '$cid', '12', '1', '09 2026', '09 2026', 8000, 0, 8000, 'N', 'Y', '2026-09-10', 0, 'N');

INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, RECEIVED_AMOUNT, BALANCE, FEE_MONTH, FEE_MONTH_FROM, ISCURRENT, SessionID, branch_id)
VALUES ('$testVoucherId', '1', 5000, 0, 5000, '09 2026', '09 2026', 'Y', '12', '1');

INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, RECEIVED_AMOUNT, BALANCE, FEE_MONTH, FEE_MONTH_FROM, ISCURRENT, SessionID, branch_id)
VALUES ('$testVoucherId', '2', 3000, 0, 3000, '09 2026', '09 2026', 'Y', '12', '1');
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "Created test voucher ${testVoucherId}: Total = Rs. 8,000, Unpaid"

# STEP 2: Search initial unpaid voucher in Frm_FeeEntry
$form1 = [System.Activator]::CreateInstance($frmFeeEntryType)
$txtamountpayable1 = $frmFeeEntryType.GetField("txtamountpayable", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form1)
$txtamount1 = $frmFeeEntryType.GetField("txtamount", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form1)
$txtbalance1 = $frmFeeEntryType.GetField("txtbalance", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form1)
$btnSave1 = $frmFeeEntryType.GetField("btnSave", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form1)

Invoke-SearchVoucher $form1 $testVoucherId

$initialPayable = $txtamountpayable1.Text
$initialAmount = $txtamount1.Text
$initialBal = $txtbalance1.Text
$step2Pass = ($initialPayable -eq "8000") -and ($initialAmount -eq "8000") -and ($btnSave1.Enabled -eq $true)
Report-Result "Initial Voucher Search (Unpaid)" $step2Pass "Payable: $initialPayable (expected 8000), Amount: $initialAmount (expected 8000), Balance: $initialBal, Save: $($btnSave1.Enabled)"
$form1.Dispose()

# STEP 3: Post partial payment of Rs. 4,000 in Voucher Posting (via submitfeeSingle)
$retPartial = $submitMethod.Invoke($feeInstance, @([double]4000.0, $testVoucherId, $false, [DateTime]'2026-09-05', [DateTime]'2026-09-10', "1", "SC001"))
Write-Host "Posted partial payment of Rs. 4,000. submitfeeSingle returned: $retPartial"

# Verify Fee_Master in DB after partial payment
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE FEE_MASTER_ID = '$testVoucherId' AND SessionID = '12'"
$r = $cmd.ExecuteReader()
$dbRecv = 0; $dbRec = 0; $dbBal = 0; $dbPaid = ""; $dbStatus = ""
if ($r.Read()) {
    $dbRecv = [double]$r["RECEIVABLE_AMOUNT"]
    $dbRec = [double]$r["REC_AMOUNT"]
    $dbBal = [double]$r["BALANCE"]
    $dbPaid = $r["PAID"].ToString()
    $dbStatus = $r["STATUS"].ToString()
}
$r.Close()

$dbPartialPass = ($dbRecv -eq 8000) -and ($dbRec -eq 4000) -and ($dbBal -eq 4000) -and ($dbPaid -eq "N") -and ($dbStatus -eq "Y")
Report-Result "Database State After Partial Payment" $dbPartialPass "RECEIVABLE_AMOUNT=$dbRecv (exp 8000), REC_AMOUNT=$dbRec (exp 4000), BALANCE=$dbBal (exp 4000), PAID='$dbPaid' (exp 'N')"

# STEP 4: Search the SAME voucher again in Voucher Posting
$form2 = [System.Activator]::CreateInstance($frmFeeEntryType)
$txtamountpayable2 = $frmFeeEntryType.GetField("txtamountpayable", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form2)
$txtamount2 = $frmFeeEntryType.GetField("txtamount", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form2)
$txtbalance2 = $frmFeeEntryType.GetField("txtbalance", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form2)
$btnSave2 = $frmFeeEntryType.GetField("btnSave", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form2)

Invoke-SearchVoucher $form2 $testVoucherId

$search2Payable = $txtamountpayable2.Text
$search2Amount = $txtamount2.Text
$search2Bal = $txtbalance2.Text
$search2BtnSave = $btnSave2.Enabled

$search2Pass = ($search2Payable -eq "8000") -and ($search2Amount -eq "4000") -and ($search2Bal -eq "0") -and ($search2BtnSave -eq $true)
Report-Result "Reload/Search Voucher Again After Rs. 4,000 Partial Payment" $search2Pass "Total Payable: $search2Payable (exp 8000), Amount Received: $search2Amount (exp 4000), Balance After Payment: $search2Bal (exp 0), Save Enabled: $search2BtnSave (exp True)"

# STEP 5: Repeated searches on same form instance
Invoke-SearchVoucher $form2 $testVoucherId
$repeatPayable = $txtamountpayable2.Text
$repeatAmount = $txtamount2.Text
$repeatBal = $txtbalance2.Text
$repeatPass = ($repeatPayable -eq "8000") -and ($repeatAmount -eq "4000") -and ($repeatBal -eq "0")
Report-Result "Repeated Search On Same Form Instance" $repeatPass "Total Payable: $repeatPayable (exp 8000), Amount Received: $repeatAmount (exp 4000), Balance After Payment: $repeatBal (exp 0)"
$form2.Dispose()

# STEP 6: Reopen form and search again
$form3 = [System.Activator]::CreateInstance($frmFeeEntryType)
$txtamountpayable3 = $frmFeeEntryType.GetField("txtamountpayable", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form3)
$txtamount3 = $frmFeeEntryType.GetField("txtamount", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form3)
$txtbalance3 = $frmFeeEntryType.GetField("txtbalance", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form3)
$btnSave3 = $frmFeeEntryType.GetField("btnSave", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form3)

Invoke-SearchVoucher $form3 $testVoucherId

$reopenPayable = $txtamountpayable3.Text
$reopenAmount = $txtamount3.Text
$reopenBal = $txtbalance3.Text
$reopenPass = ($reopenPayable -eq "8000") -and ($reopenAmount -eq "4000") -and ($reopenBal -eq "0") -and ($btnSave3.Enabled -eq $true)
Report-Result "Search in Brand New Form Instance" $reopenPass "Total Payable: $reopenPayable (exp 8000), Amount Received: $reopenAmount (exp 4000), Balance After Payment: $reopenBal (exp 0), Save Enabled: $($btnSave3.Enabled)"
$form3.Dispose()

# STEP 7: Post full remaining payment (cumulative 8,000)
$retFull = $submitMethod.Invoke($feeInstance, @([double]8000.0, $testVoucherId, $false, [DateTime]'2026-09-08', [DateTime]'2026-09-10', "1", "SC002"))
Write-Host "Posted full remaining payment of Rs. 4,000 (total 8,000). submitfeeSingle returned: $retFull"

$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE FEE_MASTER_ID = '$testVoucherId' AND SessionID = '12'"
$r = $cmd.ExecuteReader()
$dbFullRecv = 0; $dbFullRec = 0; $dbFullBal = 0; $dbFullPaid = ""
if ($r.Read()) {
    $dbFullRecv = [double]$r["RECEIVABLE_AMOUNT"]
    $dbFullRec = [double]$r["REC_AMOUNT"]
    $dbFullBal = [double]$r["BALANCE"]
    $dbFullPaid = $r["PAID"].ToString()
}
$r.Close()

$dbFullPass = ($dbFullRecv -eq 8000) -and ($dbFullRec -eq 8000) -and ($dbFullBal -eq 0) -and ($dbFullPaid -eq "Y")
Report-Result "Database State After Full Payment" $dbFullPass "RECEIVABLE_AMOUNT=$dbFullRecv, REC_AMOUNT=$dbFullRec, BALANCE=$dbFullBal (exp 0), PAID='$dbFullPaid' (exp 'Y')"

# Cleanup test records
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO = '$testVoucherId' AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$testVoucherId' AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$testVoucherId' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()

Write-Host "======================================================================"
if ($allPass) {
    Write-Host "ALL VOUCHER POSTING BALANCE TESTS PASSED SUCCESSFULLY!" -ForegroundColor Green
} else {
    Write-Host "SOME TESTS FAILED!" -ForegroundColor Red
    exit 1
}
Write-Host "======================================================================"
