$ErrorActionPreference = "Stop"

Write-Host "=========================================================================="
Write-Host " EXECUTING COMPREHENSIVE 9-SCENARIO VERIFICATION ON ISOLATED SCMS_SF_TEST"
Write-Host "=========================================================================="

# 1. Override in-memory connection string so School.exe/SYSTEMSETTING connects to SCMS_SF_TEST
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

# 2. Load School.exe assembly
$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$genMulti = $feeType.GetMethod("generatefeeMulti")

# Verify runtime connection
$sysInst = [System.Activator]::CreateInstance($sysType)
$checkDbConn = $sysInst.db_connect()
Write-Host "Verified School.exe target database: $($checkDbConn.Database)"
if ($checkDbConn.Database -ne "SCMS_SF_TEST") {
    Write-Host "FATAL: Target database is NOT SCMS_SF_TEST! Halting." -ForegroundColor Red
    exit 1
}
$checkDbConn.Close()

# 3. Connect ADO.NET to SCMS_SF_TEST
$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

# Baseline check on SCMS_SF_TEST
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$initialPaidCountTest = [int]$cmd.ExecuteScalar()
Write-Host "Baseline SCMS_SF_TEST count of PAID='Y' records: $initialPaidCountTest"

# Also check production SCMS_SF baseline to verify zero cross-contamination
$prodConn = New-Object System.Data.SqlClient.SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$prodConn.Open()
$prodCmd = $prodConn.CreateCommand()
$prodCmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$initialPaidCountProd = [int]$prodCmd.ExecuteScalar()
Write-Host "Baseline Production SCMS_SF count of PAID='Y' records: $initialPaidCountProd"
$prodConn.Close()

function Clean-TestVouchers([string]$sid, [string[]]$months, [string]$sessId = "12") {
    $mList = ($months | ForEach-Object { "'$_'" }) -join ","
    $cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND FEE_MONTH IN ($mList) AND SessionID = '$sessId') AND SessionID = '$sessId';
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND FEE_MONTH IN ($mList) AND SessionID = '$sessId';
"@
    $cmd.ExecuteNonQuery() | Out-Null
}

function Get-VoucherSummary([string]$sid, [string]$month, [string]$sessId = "12") {
    $cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, SessionID FROM FEE_MASTER WHERE s_id = '$sid' AND FEE_MONTH = '$month' AND SessionID = '$sessId'"
    $r = $cmd.ExecuteReader()
    $summary = $null
    if ($r.Read()) {
        $summary = @{
            MasterId = $r["FEE_MASTER_ID"].ToString()
            Month = $r["FEE_MONTH"].ToString()
            SessionId = $r["SessionID"].ToString()
            Receivable = [double]$r["RECEIVABLE_AMOUNT"]
            RecAmount = if ($r["REC_AMOUNT"] -ne [DBNull]::Value) { [double]$r["REC_AMOUNT"] } else { 0.0 }
            Balance = [double]$r["BALANCE"]
            Paid = if ($r["PAID"] -ne [DBNull]::Value) { $r["PAID"].ToString() } else { "NULL" }
        }
    }
    $r.Close()

    if ($summary -ne $null) {
        $cmd.CommandText = @"
SELECT d.FEE_DETAIL_ID, d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE
FROM FEE_DETAIL d
LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE d.FEE_MASTER_ID = '$($summary.MasterId)' AND d.SessionID = '$($summary.SessionId)'
ORDER BY d.FEE_DETAIL_ID
"@
        $r2 = $cmd.ExecuteReader()
        $details = @()
        while ($r2.Read()) {
            $details += @{
                HeadId = $r2["Fee_head_id"].ToString()
                HeadName = if ($r2["Fee_head"] -ne [DBNull]::Value) { $r2["Fee_head"].ToString() } else { "" }
                Category = if ($r2["Category"] -ne [DBNull]::Value) { $r2["Category"].ToString() } else { "" }
                Amount = [double]$r2["AMOUNT"]
                IsCurrent = $r2["ISCURRENT"].ToString()
                Balance = [double]$r2["BALANCE"]
            }
        }
        $r2.Close()
        $summary.Details = $details
    }
    return $summary
}

$testSid = "2093"
$testClass = "64"

# -----------------------------------------------------------------------------------------
# TEST 1: Completely Unpaid Previous-Month Voucher
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 1: Completely Unpaid Previous-Month Voucher (Nov 2026 unpaid -> Dec 2026)"
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")
Clean-TestVouchers $testSid @("11 2026", "12 2026")

# Generate November 2026 using ISO dates
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"
$novArrears = ($vNov.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
Write-Host "  November Generated: Receivable = $($vNov.Receivable), Balance = $($vNov.Balance), Arrears rows count = $(@($novArrears).Count)"

# Generate December 2026
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"
$decArrears = ($vDec.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }

Write-Host "  December Generated: Receivable = $($vDec.Receivable), Carried Arrears = $decArrearAmt"
Write-Host "  Expected Arrears: $($vNov.Receivable), Actual Arrears: $decArrearAmt"
$t1_pass = (@($novArrears).Count -eq 0) -and ($decArrearAmt -eq $vNov.Receivable) -and ($vDec.Receivable -eq ($vNov.Receivable * 2))
if ($t1_pass) {
    Write-Host "  RESULT: PASS - November has zero self-arrears; December carries full unpaid November balance." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -----------------------------------------------------------------------------------------
# TEST 2: Partially Paid Previous-Month Voucher
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 2: Partially Paid Previous-Month Voucher (Nov partially paid -> Dec)"
Clean-TestVouchers $testSid @("11 2026", "12 2026")

# Generate November
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"
$novTotal = $vNov.Receivable
$partialPay = 3000.0
$expectedRemaining = $novTotal - $partialPay

# Record partial payment on November voucher
$cmd.CommandText = "UPDATE FEE_MASTER SET REC_AMOUNT = '$partialPay', BALANCE = '$expectedRemaining', PAID = 'Y', STATUS = 'Y' WHERE FEE_MASTER_ID = '$($vNov.MasterId)'"
$cmd.ExecuteNonQuery() | Out-Null

# Generate December
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"
$decArrears = ($vDec.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }

# Re-inspect November to verify PAID status
$vNovAfter = Get-VoucherSummary $testSid "11 2026"
Write-Host "  November: Total = $novTotal, Paid = $partialPay, Remaining = $expectedRemaining"
Write-Host "  December: Carried Arrears = $decArrearAmt (expected $expectedRemaining)"
Write-Host "  November PAID status after carry-forward: '$($vNovAfter.Paid)' (must remain 'Y')"

$t2_pass = ($decArrearAmt -eq $expectedRemaining) -and ($vNovAfter.Paid -eq "Y")
if ($t2_pass) {
    Write-Host "  RESULT: PASS - Carried forward ONLY remaining balance ($expectedRemaining) and preserved November PAID='Y'." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -----------------------------------------------------------------------------------------
# TEST 3: Fully Paid Previous-Month Voucher
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 3: Fully Paid Previous-Month Voucher (Nov fully paid -> Dec)"
Clean-TestVouchers $testSid @("11 2026", "12 2026")

# Generate November
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"
$novTotal = $vNov.Receivable

# Record full payment on November voucher
$cmd.CommandText = "UPDATE FEE_MASTER SET REC_AMOUNT = '$novTotal', BALANCE = 0, PAID = 'Y', STATUS = 'Y' WHERE FEE_MASTER_ID = '$($vNov.MasterId)'"
$cmd.ExecuteNonQuery() | Out-Null

# Generate December
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"
$decArrears = ($vDec.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }

Write-Host "  November: Full payment recorded ($novTotal)"
Write-Host "  December: Carried Arrears = $decArrearAmt (expected 0), Total Receivable = $($vDec.Receivable)"

$t3_pass = ($decArrearAmt -eq 0) -and ($vDec.Receivable -eq $novTotal)
if ($t3_pass) {
    Write-Host "  RESULT: PASS - Zero arrears carried forward when previous month was fully paid." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -----------------------------------------------------------------------------------------
# TEST 4 & 5: November & December Together + Repeated Generation
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 4 & 5: Sequential Generation & Repeated Generation (Prevent Duplicate Arrears)"
Clean-TestVouchers $testSid @("11 2026", "12 2026")

# Generate November
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"

# Generate December 1st time
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))
$vDec1 = Get-VoucherSummary $testSid "12 2026"
Write-Host "  December (1st generation): Receivable = $($vDec1.Receivable)"

# Delete December voucher and regenerate December (repeated generation)
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$($vDec1.MasterId)';
DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$($vDec1.MasterId)';
"@
$cmd.ExecuteNonQuery() | Out-Null

$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))
$vDec2 = Get-VoucherSummary $testSid "12 2026"
Write-Host "  December (2nd generation): Receivable = $($vDec2.Receivable)"

$t4_5_pass = ($vDec1.Receivable -eq $vDec2.Receivable) -and ($vDec2.Receivable -eq ($vNov.Receivable * 2))
if ($t4_5_pass) {
    Write-Host "  RESULT: PASS - Regenerating December produces identical arrears without duplication or inflation." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -----------------------------------------------------------------------------------------
# TEST 6: Student with Fee Concession / Exemption
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 6: Student with Fee Concession / Exemption (Student 2533)"
$concSid = "2533"
$concClass = "64"
Clean-TestVouchers $concSid @("11 2026", "12 2026")

$cmd.CommandText = "SELECT CONCESSION_FEE FROM student WHERE s_id = '$concSid'"
$concVal = [double]$cmd.ExecuteScalar()
Write-Host "  Student $concSid configured concession: Rs. $concVal"

# Generate November with concession
$genMulti.Invoke($feeInstance, @($concClass, "11 2026", "Morning", $concSid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))
$vNovConc = Get-VoucherSummary $concSid "11 2026"
Write-Host "  November (with concession): Net Receivable = $($vNovConc.Receivable)"

# Generate December
$genMulti.Invoke($feeInstance, @($concClass, "12 2026", "Morning", $concSid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))
$vDecConc = Get-VoucherSummary $concSid "12 2026"
$decArrears = ($vDecConc.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }

Write-Host "  December Arrears Carried: $decArrearAmt (expected net $($vNovConc.Receivable))"
$t6_pass = ($decArrearAmt -eq $vNovConc.Receivable)
if ($t6_pass) {
    Write-Host "  RESULT: PASS - Genuine net amount after concession ($($vNovConc.Receivable)) carried forward accurately." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

Clean-TestVouchers $concSid @("11 2026", "12 2026")

# -----------------------------------------------------------------------------------------
# TEST 7: Branch 6 and Branch 1 Isolation & Dynamic Arrear Head Resolution
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 7: Branch Isolation & Dynamic Arrear Head (Branch 1 vs Branch 6)"
$headB1 = $feeInstance.GetBranchArrearHeadId("1")
$headB6 = $feeInstance.GetBranchArrearHeadId("6")
Write-Host "  Branch 1 Arrear Head resolved: $headB1 (expected 40)"
Write-Host "  Branch 6 Arrear Head resolved: $headB6 (expected 103)"

# Test Branch 6 generation
$sysType.GetField("branch_ID").SetValue($null, "6")
$sysType.GetField("sessionid").SetValue($null, "12")

$cmd.CommandText = "SELECT TOP 1 s_id, c_id, SHIFT, SECTION_ID FROM student WHERE branch_id = '6' AND active = 'true' ORDER BY s_id"
$rB6 = $cmd.ExecuteReader()
$b6Sid = ""; $b6Cid = ""; $b6Shift = ""; $b6Sec = ""
if ($rB6.Read()) {
    $b6Sid = $rB6["s_id"].ToString()
    $b6Cid = $rB6["c_id"].ToString()
    $b6Shift = $rB6["SHIFT"].ToString()
    $b6Sec = $rB6["SECTION_ID"].ToString()
}
$rB6.Close()

Write-Host "  Branch 6 Student $b6Sid (Class $b6Cid):"
Clean-TestVouchers $b6Sid @("11 2026", "12 2026")

$genMulti.Invoke($feeInstance, @($b6Cid, "11 2026", $b6Shift, $b6Sid, 1, "11 2026", "2026-11-10", "1", "0", "Test B6", "2026-11-01", "2026-11-01", "2026-11-30", $b6Sec))
$vNovB6 = Get-VoucherSummary $b6Sid "11 2026"

$genMulti.Invoke($feeInstance, @($b6Cid, "12 2026", $b6Shift, $b6Sid, 1, "12 2026", "2026-12-10", "1", "0", "Test B6", "2026-12-01", "2026-12-01", "2026-12-31", $b6Sec))
$vDecB6 = Get-VoucherSummary $b6Sid "12 2026"
$decArrearsB6 = ($vDecB6.Details | Where-Object { $_.HeadId -eq $headB6 })

Write-Host "  Branch 6 November Receivable: $($vNovB6.Receivable)"
Write-Host "  Branch 6 December Arrear line item: Head_ID = $($decArrearsB6.HeadId), Name = $($decArrearsB6.HeadName), Amount = $($decArrearsB6.Amount)"

$t7_pass = ($headB1 -eq "40") -and ($headB6 -eq "103") -and ($decArrearsB6.HeadId -eq "103") -and ($decArrearsB6.Amount -eq $vNovB6.Receivable)
if ($t7_pass) {
    Write-Host "  RESULT: PASS - Branch 1 and Branch 6 are completely isolated; dynamic arrear heads (40 vs 103) resolved correctly." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

Clean-TestVouchers $b6Sid @("11 2026", "12 2026")

# -----------------------------------------------------------------------------------------
# TEST 8: Voucher Printing and Report View (TempDetail Join)
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 8: Voucher Printing & Reports (TempDetail view join with dynamic arrear head)"
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")

Clean-TestVouchers $testSid @("11 2026", "12 2026")
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"

$cmd.CommandText = "SELECT Fee_head, Category, AMOUNT, ISCURRENT, BALANCE FROM TempDetail WHERE FEE_MASTER_ID = '$($vDec.MasterId)' AND SessionID = '$($vDec.SessionId)' ORDER BY Fee_head_id"
$rV = $cmd.ExecuteReader()
$viewRows = @()
while ($rV.Read()) {
    $viewRows += @{
        Head = $rV["Fee_head"].ToString()
        Category = $rV["Category"].ToString()
        Amount = [double]$rV["AMOUNT"]
        IsCurrent = $rV["ISCURRENT"].ToString()
    }
}
$rV.Close()

Write-Host "  TempDetail rows for December voucher $($vDec.MasterId):"
foreach ($vr in $viewRows) {
    Write-Host "    Head: $($vr.Head), Cat: $($vr.Category), Amt: $($vr.Amount), IsCurrent: $($vr.IsCurrent)"
}
$arrearInView = ($viewRows | Where-Object { $_.Head -like "*ARREAR*" -or $_.Category -eq "ARREAR" })
$t8_pass = (@($arrearInView).Count -gt 0)
if ($t8_pass) {
    Write-Host "  RESULT: PASS - Arrears line item successfully appears in report view TempDetail without missing head ID." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -----------------------------------------------------------------------------------------
# TEST 9: Historical PAID Statuses and Records Integrity Check
# -----------------------------------------------------------------------------------------
Write-Host "`n>>> TEST 9: Historical PAID Statuses and Integrity Verification"
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$finalPaidCountTest = [int]$cmd.ExecuteScalar()
Write-Host "  SCMS_SF_TEST count of PAID='Y' records: $finalPaidCountTest (initial baseline: $initialPaidCountTest)"

# Verify production SCMS_SF was completely untouched
$prodConn = New-Object System.Data.SqlClient.SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$prodConn.Open()
$prodCmd = $prodConn.CreateCommand()
$prodCmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$finalPaidCountProd = [int]$prodCmd.ExecuteScalar()

$prodCmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id IN ('2093', '2533') AND FEE_MONTH IN ('11 2026', '12 2026')"
$prodTestRecords = [int]$prodCmd.ExecuteScalar()
$prodConn.Close()

Write-Host "  Production SCMS_SF count of PAID='Y' records: $finalPaidCountProd (initial baseline: $initialPaidCountProd)"
Write-Host "  Production SCMS_SF test records count: $prodTestRecords (must be exactly 0)"

$t9_pass = ($finalPaidCountTest -eq $initialPaidCountTest) -and ($finalPaidCountProd -eq $initialPaidCountProd) -and ($prodTestRecords -eq 0)
if ($t9_pass) {
    Write-Host "  RESULT: PASS - Zero historical records or payment statuses modified; Production SCMS_SF 100% untouched." -ForegroundColor Green
} else {
    Write-Host "  RESULT: FAIL" -ForegroundColor Red
}

$con.Close()

Write-Host "`n=========================================================================="
$allPassed = $t1_pass -and $t2_pass -and $t3_pass -and $t4_5_pass -and $t6_pass -and $t7_pass -and $t8_pass -and $t9_pass
if ($allPassed) {
    Write-Host " ALL 9 VERIFICATION TESTS PASSED SUCCESSFULLY ON SCMS_SF_TEST!" -ForegroundColor Green
} else {
    Write-Host " SOME TESTS FAILED!" -ForegroundColor Red
}
Write-Host "=========================================================================="
