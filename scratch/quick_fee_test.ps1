$ErrorActionPreference = "Stop"

# Point to SCMS_SF_TEST
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

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")
$sid = "2093"
$cid = "64"

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

# Cleanup student 2093 test voucher
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '09 2026') AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '09 2026') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '09 2026';
"@
$cmd.ExecuteNonQuery() | Out-Null

# Create 8000 voucher
$cmd.CommandText = "SELECT ISNULL(MAX(CONVERT(INT, FEE_MASTER_ID)), 0) + 1 FROM FEE_MASTER WHERE SessionID = '12'"
$vId = ($cmd.ExecuteScalar()).ToString()

$cmd.CommandText = @"
INSERT INTO FEE_MASTER (FEE_MASTER_ID, s_id, c_id, SessionID, branch_id, FEE_MONTH, FEE_MONTH_FROM, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS, DUE_DATE, FINE_AFTER_DUE_DATE, MULTITAG)
VALUES ('$vId', '$sid', '$cid', '12', '1', '09 2026', '09 2026', 8000, 0, 8000, 'N', 'Y', '2026-09-10', 0, 'N');
INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, RECEIVED_AMOUNT, BALANCE, FEE_MONTH, FEE_MONTH_FROM, ISCURRENT, SessionID, branch_id)
VALUES ('$vId', '1', 8000, 0, 8000, '09 2026', '09 2026', 'Y', '12', '1');
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "Created test voucher $vId with 8000 fee."

# Test initial load via FeeList_Detail
$form = [System.Activator]::CreateInstance($frmFeeEntryType)
$txtreceiptno = $frmFeeEntryType.GetField("txtreceiptno", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtamountpayable = $frmFeeEntryType.GetField("txtamountpayable", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtamount = $frmFeeEntryType.GetField("txtamount", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtbalance = $frmFeeEntryType.GetField("txtbalance", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$btnSave = $frmFeeEntryType.GetField("btnSave", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)

$feeListDetailMethod = $frmFeeEntryType.GetMethod("FeeList_Detail", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)

$txtreceiptno.Text = $vId
$feeListDetailMethod.Invoke($form, $null)

Write-Host "Initial load:"
Write-Host "  Amount Payable = $($txtamountpayable.Text) (expected 8000)"
Write-Host "  Amount Received = $($txtamount.Text) (expected 8000)"
Write-Host "  Balance = $($txtbalance.Text) (expected 0)"
Write-Host "  Save Enabled = $($btnSave.Enabled) (expected True)"

# Now post partial payment of 4000
$ret = $submitMethod.Invoke($feeInstance, @([double]4000.0, $vId, $false, [DateTime]'2026-09-05', [DateTime]'2026-09-10', "1", "SC001"))
Write-Host "Posted partial payment 4000. Ret: $ret"

# Check DB state
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE FEE_MASTER_ID = '$vId' AND SessionID = '12'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "DB after partial:"
    Write-Host "  RECEIVABLE_AMOUNT = $($r['RECEIVABLE_AMOUNT'])"
    Write-Host "  REC_AMOUNT = $($r['REC_AMOUNT'])"
    Write-Host "  BALANCE = $($r['BALANCE'])"
    Write-Host "  PAID = $($r['PAID'])"
}
$r.Close()

# Now re-search the voucher on the form
$txtreceiptno.Text = $vId
$feeListDetailMethod.Invoke($form, $null)

Write-Host "After searching voucher again:"
Write-Host "  Amount Payable = $($txtamountpayable.Text) (expected 8000)"
Write-Host "  Amount Received = $($txtamount.Text) (expected 4000)"
Write-Host "  Balance = $($txtbalance.Text) (expected 4000)"
Write-Host "  Save Enabled = $($btnSave.Enabled) (expected True)"

# Now post full payment of remaining 4000 (total 8000)
$ret2 = $submitMethod.Invoke($feeInstance, @([double]8000.0, $vId, $false, [DateTime]'2026-09-08', [DateTime]'2026-09-10', "1", "SC002"))
Write-Host "Posted full payment 8000. Ret: $ret2"

# Check DB state after full payment
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE FEE_MASTER_ID = '$vId' AND SessionID = '12'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "DB after full payment:"
    Write-Host "  RECEIVABLE_AMOUNT = $($r['RECEIVABLE_AMOUNT'])"
    Write-Host "  REC_AMOUNT = $($r['REC_AMOUNT'])"
    Write-Host "  BALANCE = $($r['BALANCE'])"
    Write-Host "  PAID = $($r['PAID'])"
}
$r.Close()

# Re-search fully paid voucher on form
$feeListDetailMethod.Invoke($form, $null)
Write-Host "After searching fully paid voucher:"
Write-Host "  Amount Payable = $($txtamountpayable.Text) (expected 8000)"
Write-Host "  Amount Received = $($txtamount.Text) (expected 8000)"
Write-Host "  Balance = $($txtbalance.Text) (expected 0)"
Write-Host "  Save Enabled = $($btnSave.Enabled) (expected False)"

# Cleanup test records
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO = '$vId' AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$vId' AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$vId' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()
$form.Dispose()
Write-Host "TEST COMPLETE."
