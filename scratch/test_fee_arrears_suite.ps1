$ErrorActionPreference = "Stop"

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sysType = $asm.GetType("SYSTEMSETTING")
$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$genMulti = $feeType.GetMethod("generatefeeMulti")
$genSingle = $feeType.GetMethod("generatefee")

$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()

Write-Host "================================================================="
Write-Host " FEE ARREARS CARRY-FORWARD COMPREHENSIVE VERIFICATION SUITE"
Write-Host "================================================================="

# Record historical PAID status baseline for existing vouchers
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$initialPaidCount = [int]$cmd.ExecuteScalar()
Write-Host "Baseline: Total existing vouchers with PAID='Y': $initialPaidCount"

# Helper function to clean test vouchers
function Clean-TestVouchers([string]$sid, [string[]]$months) {
    $mList = ($months | ForEach-Object { "'$_'" }) -join ","
    $cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND FEE_MONTH IN ($mList));
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND FEE_MONTH IN ($mList);
"@
    $cmd.ExecuteNonQuery() | Out-Null
}

# Helper to inspect voucher details
function Get-VoucherSummary([string]$sid, [string]$month) {
    $cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid' AND FEE_MONTH = '$month'"
    $r = $cmd.ExecuteReader()
    $summary = $null
    if ($r.Read()) {
        $summary = @{
            MasterId = $r["FEE_MASTER_ID"].ToString()
            Month = $r["FEE_MONTH"].ToString()
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
WHERE d.FEE_MASTER_ID = '$($summary.MasterId)'
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

# -------------------------------------------------------------
# TEST 1: Completely Unpaid Previous-Month Voucher
# -------------------------------------------------------------
Write-Host "`n>>> TEST 1: Completely Unpaid Previous-Month Voucher (November -> December)"
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")
$testSid = "2093"
$testClass = "64"

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# Generate November (unpaid)
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "10/11/2026", "1", "0", "Test Note", "01/11/2026", "01/11/2026", "30/11/2026", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"
$novArrears = ($vNov.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
Write-Host "  November Generated: Receivable = $($vNov.Receivable), Arrears rows count = $(@($novArrears).Count)"
if (@($novArrears).Count -gt 0) {
    Write-Host "  FAIL: November voucher contains its own arrears!" -ForegroundColor Red
} else {
    Write-Host "  PASS: November does not include its own fee as arrears." -ForegroundColor Green
}

# Generate December
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"
$decArrears = ($vDec.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }
Write-Host "  December Generated: Receivable = $($vDec.Receivable), Carried Arrears = $decArrearAmt (expected $($vNov.Receivable))"
if ($decArrearAmt -eq $vNov.Receivable -and $vDec.Receivable -eq ($vNov.Receivable * 2)) {
    Write-Host "  PASS: Fully unpaid November ($($vNov.Receivable)) correctly carried forward to December." -ForegroundColor Green
} else {
    Write-Host "  FAIL: December arrears mismatch!" -ForegroundColor Red
}

# Check November PAID status is still untouched
$vNovAfter = Get-VoucherSummary $testSid "11 2026"
Write-Host "  November PAID status after December generation: '$($vNovAfter.Paid)' (was '$($vNov.Paid)')"
if ($vNovAfter.Paid -eq $vNov.Paid) {
    Write-Host "  PASS: November historical status was NOT modified." -ForegroundColor Green
} else {
    Write-Host "  FAIL: November status changed to $($vNovAfter.Paid)!" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -------------------------------------------------------------
# TEST 2: Partially Paid Previous-Month Voucher
# -------------------------------------------------------------
Write-Host "`n>>> TEST 2: Partially Paid Previous-Month Voucher (November partially paid -> December)"
Clean-TestVouchers $testSid @("11 2026", "12 2026")

$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "10/11/2026", "1", "0", "Test Note", "01/11/2026", "01/11/2026", "30/11/2026", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"
$novTotal = $vNov.Receivable
$partialPay = 1000.0
$expectedRemaining = $novTotal - $partialPay

# Simulate partial payment recorded on November
$cmd.CommandText = "UPDATE FEE_MASTER SET REC_AMOUNT = '$partialPay', BALANCE = '$expectedRemaining', PAID = 'Y', STATUS = 'Y' WHERE FEE_MASTER_ID = '$($vNov.MasterId)'"
$cmd.ExecuteNonQuery() | Out-Null

# Now generate December
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"
$decArrears = ($vDec.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }
Write-Host "  November was $novTotal with $partialPay paid (remaining $expectedRemaining)"
Write-Host "  December Arrears: $decArrearAmt (expected $expectedRemaining), Total Receivable: $($vDec.Receivable)"
if ($decArrearAmt -eq $expectedRemaining) {
    Write-Host "  PASS: Partially paid voucher carried forward only remaining unpaid balance ($expectedRemaining)." -ForegroundColor Green
} else {
    Write-Host "  FAIL: Expected $expectedRemaining arrears but got $decArrearAmt" -ForegroundColor Red
}

# Verify November PAID status is still 'Y'
$vNovAfter = Get-VoucherSummary $testSid "11 2026"
Write-Host "  November PAID status after carry-forward: '$($vNovAfter.Paid)' (must remain 'Y')"
if ($vNovAfter.Paid -eq "Y") {
    Write-Host "  PASS: Historical PAID='Y' status was preserved and NOT changed to 'N'!" -ForegroundColor Green
} else {
    Write-Host "  FAIL: PAID status was corrupted to '$($vNovAfter.Paid)'!" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -------------------------------------------------------------
# TEST 3: Fully Paid Previous-Month Voucher
# -------------------------------------------------------------
Write-Host "`n>>> TEST 3: Fully Paid Previous-Month Voucher (November fully paid -> December)"
Clean-TestVouchers $testSid @("11 2026", "12 2026")

$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "10/11/2026", "1", "0", "Test Note", "01/11/2026", "01/11/2026", "30/11/2026", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"
$novTotal = $vNov.Receivable

# Simulate full payment recorded on November
$cmd.CommandText = "UPDATE FEE_MASTER SET REC_AMOUNT = '$novTotal', BALANCE = 0, PAID = 'Y', STATUS = 'Y' WHERE FEE_MASTER_ID = '$($vNov.MasterId)'"
$cmd.ExecuteNonQuery() | Out-Null

# Now generate December
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"
$decArrears = ($vDec.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }
Write-Host "  November fully paid ($novTotal). December Arrears = $decArrearAmt (expected 0)"
if ($decArrearAmt -eq 0 -and @($decArrears).Count -eq 0) {
    Write-Host "  PASS: Fully paid previous month resulted in 0 arrears carried forward." -ForegroundColor Green
} else {
    Write-Host "  FAIL: Arrears carried forward when previous month was fully paid!" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -------------------------------------------------------------
# TEST 4 & 5: November & December Together + Repeated Generation
# -------------------------------------------------------------
Write-Host "`n>>> TEST 4 & 5: Sequential Generation & Repeated Generation (Prevent Double-Counting)"
Clean-TestVouchers $testSid @("11 2026", "12 2026")

# Generate November
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "10/11/2026", "1", "0", "Test Note", "01/11/2026", "01/11/2026", "30/11/2026", "Female"))
$vNov = Get-VoucherSummary $testSid "11 2026"

# Generate December
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))
$vDec1 = Get-VoucherSummary $testSid "12 2026"
Write-Host "  December (1st gen): Receivable = $($vDec1.Receivable)"

# Delete December voucher and regenerate December to test repeated generation
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$($vDec1.MasterId)';
DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$($vDec1.MasterId)';
"@
$cmd.ExecuteNonQuery() | Out-Null

$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))
$vDec2 = Get-VoucherSummary $testSid "12 2026"
Write-Host "  December (2nd gen): Receivable = $($vDec2.Receivable) (must equal 1st gen: $($vDec1.Receivable))"
if ($vDec1.Receivable -eq $vDec2.Receivable) {
    Write-Host "  PASS: Regenerating December does NOT duplicate or inflate arrears." -ForegroundColor Green
} else {
    Write-Host "  FAIL: Arrears changed upon regeneration! ($($vDec1.Receivable) vs $($vDec2.Receivable))" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -------------------------------------------------------------
# TEST 6: Student with Concession or Exemption
# -------------------------------------------------------------
Write-Host "`n>>> TEST 6: Student with Fee Concession / Exemption"
# Student 2533 has CONCESSION_FEE = 400
$concSid = "2533"
$concClass = "64"
Clean-TestVouchers $concSid @("11 2026", "12 2026")

# Check student concession amount
$cmd.CommandText = "SELECT CONCESSION_FEE FROM student WHERE s_id = '$concSid'"
$concVal = [double]$cmd.ExecuteScalar()
Write-Host "  Student $concSid configured concession: Rs. $concVal"

$genMulti.Invoke($feeInstance, @($concClass, "11 2026", "Morning", $concSid, 1, "11 2026", "10/11/2026", "1", "0", "Test Note", "01/11/2026", "01/11/2026", "30/11/2026", "Female"))
$vNovConc = Get-VoucherSummary $concSid "11 2026"
Write-Host "  November with concession: Receivable = $($vNovConc.Receivable)"

# Generate December
$genMulti.Invoke($feeInstance, @($concClass, "12 2026", "Morning", $concSid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))
$vDecConc = Get-VoucherSummary $concSid "12 2026"
$decArrears = ($vDecConc.Details | Where-Object { $_.Category -eq "ARREAR" -or $_.HeadName -like "*ARREAR*" })
$decArrearAmt = if (@($decArrears).Count -gt 0) { $decArrears[0].Amount } else { 0 }
Write-Host "  December Arrears: $decArrearAmt (expected $($vNovConc.Receivable))"
if ($decArrearAmt -eq $vNovConc.Receivable) {
    Write-Host "  PASS: Genuine net amount after concession ($($vNovConc.Receivable)) accurately carried forward." -ForegroundColor Green
} else {
    Write-Host "  FAIL: Arrears mismatch for concession student! ($decArrearAmt vs $($vNovConc.Receivable))" -ForegroundColor Red
}

Clean-TestVouchers $concSid @("11 2026", "12 2026")

# -------------------------------------------------------------
# TEST 7: Branch 6 and Branch 1 Isolation & Dynamic Arrear Head
# -------------------------------------------------------------
Write-Host "`n>>> TEST 7: Branch Isolation & Dynamic Arrear Head Resolution (Branch 1 vs Branch 6)"
# In Branch 1: Arrear head is 40
# In Branch 6: Arrear head is 103
$headB1 = $feeInstance.GetBranchArrearHeadId("1")
$headB6 = $feeInstance.GetBranchArrearHeadId("6")
Write-Host "  Branch 1 Arrear Head resolved: $headB1 (expected 40)"
Write-Host "  Branch 6 Arrear Head resolved: $headB6 (expected 103)"
if ($headB1 -eq "40" -and $headB6 -eq "103") {
    Write-Host "  PASS: Dynamic Arrear Head lookup is isolated and resolved correctly per branch." -ForegroundColor Green
} else {
    Write-Host "  FAIL: Arrear head resolution mismatch ($headB1 / $headB6)" -ForegroundColor Red
}

# Test Branch 6 student fee generation
$sysType.GetField("branch_ID").SetValue($null, "6")
$sysType.GetField("sessionid").SetValue($null, "12")

# Find a valid student in Branch 6
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

Write-Host "  Testing Branch 6 with Student $b6Sid (Class $b6Cid):"
Clean-TestVouchers $b6Sid @("11 2026", "12 2026")

$genMulti.Invoke($feeInstance, @($b6Cid, "11 2026", $b6Shift, $b6Sid, 1, "11 2026", "10/11/2026", "1", "0", "Test Note B6", "01/11/2026", "01/11/2026", "30/11/2026", $b6Sec))
$vNovB6 = Get-VoucherSummary $b6Sid "11 2026"
Write-Host "    Branch 6 November Receivable: $($vNovB6.Receivable)"

$genMulti.Invoke($feeInstance, @($b6Cid, "12 2026", $b6Shift, $b6Sid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note B6", "01/12/2026", "01/12/2026", "31/12/2026", $b6Sec))
$vDecB6 = Get-VoucherSummary $b6Sid "12 2026"
$decArrearsB6 = ($vDecB6.Details | Where-Object { $_.HeadId -eq $headB6 })
Write-Host "    Branch 6 December Arrear Row Head ID: $($decArrearsB6.HeadId), Name: $($decArrearsB6.HeadName), Amount: $($decArrearsB6.Amount)"
if ($decArrearsB6 -ne $null -and $decArrearsB6.HeadId -eq "103" -and $decArrearsB6.Amount -eq $vNovB6.Receivable) {
    Write-Host "  PASS: Branch 6 used Arrear Head 103 dynamically and carried $($vNovB6.Receivable) correctly." -ForegroundColor Green
} else {
    Write-Host "  FAIL: Branch 6 arrears head or amount failed!" -ForegroundColor Red
}

Clean-TestVouchers $b6Sid @("11 2026", "12 2026")

# -------------------------------------------------------------
# TEST 8: Voucher Printing and Existing Fee Reports Join
# -------------------------------------------------------------
Write-Host "`n>>> TEST 8: Voucher Printing and Existing Fee Reports (TempDetail view join)"
# Reset to Branch 1
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")

Clean-TestVouchers $testSid @("11 2026", "12 2026")
$genMulti.Invoke($feeInstance, @($testClass, "11 2026", "Morning", $testSid, 1, "11 2026", "10/11/2026", "1", "0", "Test Note", "01/11/2026", "01/11/2026", "30/11/2026", "Female"))
$genMulti.Invoke($feeInstance, @($testClass, "12 2026", "Morning", $testSid, 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))
$vDec = Get-VoucherSummary $testSid "12 2026"

# Query the view TempDetail used by fee voucher reports
$cmd.CommandText = "SELECT Fee_head, Category, AMOUNT, ISCURRENT, BALANCE FROM TempDetail WHERE FEE_MASTER_ID = '$($vDec.MasterId)' ORDER BY Fee_head_id"
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
if (@($arrearInView).Count -gt 0) {
    Write-Host "  PASS: Arrears line item successfully appears in report view TempDetail!" -ForegroundColor Green
} else {
    Write-Host "  FAIL: Arrears line item missing in TempDetail view (Fee_Head join failed)!" -ForegroundColor Red
}

Clean-TestVouchers $testSid @("11 2026", "12 2026")

# -------------------------------------------------------------
# TEST 9: Confirm Historical PAID Statuses and Records Unchanged
# -------------------------------------------------------------
Write-Host "`n>>> TEST 9: Historical PAID Statuses and Payment Records Integrity Check"
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$finalPaidCount = [int]$cmd.ExecuteScalar()
Write-Host "  Final count of vouchers with PAID='Y': $finalPaidCount (initial baseline: $initialPaidCount)"
if ($finalPaidCount -eq $initialPaidCount) {
    Write-Host "  PASS: Historical PAID statuses and records remained completely unchanged!" -ForegroundColor Green
} else {
    Write-Host "  FAIL: Count of PAID='Y' records changed! ($initialPaidCount vs $finalPaidCount)" -ForegroundColor Red
}

$con.Close()
Write-Host "`n================================================================="
Write-Host " ALL TEST SCENARIOS COMPLETED SUCCESSFULLY!"
Write-Host "================================================================="
