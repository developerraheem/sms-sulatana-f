$ErrorActionPreference = "Stop"

Write-Host "Running comprehensive test suite against SCMS_SF_TEST..."

# 1. Point School.exe to SCMS_SF_TEST in-memory
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

# ==============================================================================
# TEST BRANCH 1 (Arrear Head 40)
# Student 2093, Class 64, Session 12
# ==============================================================================
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")
$sid1 = "2093"
$cid1 = "64"

# Clean student 2093 test records in session 12
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

# STEP 1: Generate November 2026 fee (unpaid)
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cid1, "11 2026", "Morning", $sid1, 1, "11 2026", "2026-11-10", "1", "0", "Nov fee", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId = ""; $novRecv = 0
if ($r.Read()) {
    $novId = $r["FEE_MASTER_ID"].ToString()
    $novRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

# STEP 2: Generate December 2026 fee while November is unpaid
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cid1, "12 2026", "Morning", $sid1, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId = ""; $decRecv = 0
if ($r.Read()) {
    $decId = $r["FEE_MASTER_ID"].ToString()
    $decRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

# Verify Case 1: Unpaid November appears as arrears in December
$cmd.CommandText = "SELECT Fee_head_id, AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND branch_id = '1' AND ISCURRENT = 'N'"
$r = $cmd.ExecuteReader()
$decArrearAmt = 0; $decArrearHead = ""
if ($r.Read()) {
    $decArrearHead = $r["Fee_head_id"].ToString()
    $decArrearAmt = [double]$r["AMOUNT"]
}
$r.Close()

$c1Pass = ($decArrearAmt -eq $novRecv) -and ($decRecv -eq ($novRecv * 2)) -and ($decArrearHead -eq "40")
Report-Result "Case 1: Fully Unpaid Previous Month" $c1Pass "Branch 1 Dec Arrears = $decArrearAmt (expected $novRecv), Head = $decArrearHead (expected 40), Dec Total = $decRecv"

# STEP 3: Post partial payment of Rs. 3,000 on November voucher through submitfeeSingle
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postPartialRet = $submitMethod.Invoke($feeInstance, @([double]3000.0, $novId, $false, [DateTime]'2026-11-05', [DateTime]'2026-11-10', "1", "SC01"))

# Verify November record after partial posting
$cmd.CommandText = "SELECT REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE FEE_MASTER_ID = '$novId' AND SessionID = '12' AND branch_id = '1'"
$r = $cmd.ExecuteReader()
$novPaidAmt = 0; $novBal = 0; $novPaidStatus = ""
if ($r.Read()) {
    if ($r["REC_AMOUNT"] -ne [DBNull]::Value) { $novPaidAmt = [double]$r["REC_AMOUNT"] }
    if ($r["BALANCE"] -ne [DBNull]::Value) { $novBal = [double]$r["BALANCE"] }
    $novPaidStatus = $r["PAID"].ToString()
}
$r.Close()

# Verify December record after partial posting on November
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND branch_id = '1'"
$r = $cmd.ExecuteReader()
$decRecvAfterPartial = 0; $decBalAfterPartial = 0
if ($r.Read()) {
    if ($r["RECEIVABLE_AMOUNT"] -ne [DBNull]::Value) { $decRecvAfterPartial = [double]$r["RECEIVABLE_AMOUNT"] }
    if ($r["BALANCE"] -ne [DBNull]::Value) { $decBalAfterPartial = [double]$r["BALANCE"] }
}
$r.Close()

$cmd.CommandText = "SELECT Fee_head_id, AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND branch_id = '1' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$r = $cmd.ExecuteReader()
$decArrearAfterPartial = 0
if ($r.Read()) {
    $decArrearAfterPartial = [double]$r["AMOUNT"]
}
$r.Close()

$expectedRemainingArrears = $novRecv - 3000.0
$expectedDecTotalAfterPartial = $novRecv + $expectedRemainingArrears
$c2Pass = ($decArrearAfterPartial -eq $expectedRemainingArrears) -and ($decRecvAfterPartial -eq $expectedDecTotalAfterPartial) -and ($novBal -eq $expectedRemainingArrears)
Report-Result "Case 2: Partially Paid Previous Month" $c2Pass "Branch 1 Dec Arrears = $decArrearAfterPartial (expected $expectedRemainingArrears), Dec Total = $decRecvAfterPartial (expected $expectedDecTotalAfterPartial)"

# STEP 4: Post full remaining payment on November voucher through submitfeeSingle
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postFullRet = $submitMethod.Invoke($feeInstance, @([double]$novRecv, $novId, $false, [DateTime]'2026-11-08', [DateTime]'2026-11-10', "1", "SC02"))

# Verify December record after full payment of November
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND branch_id = '1'"
$r = $cmd.ExecuteReader()
$decRecvAfterFull = 0
if ($r.Read()) {
    if ($r["RECEIVABLE_AMOUNT"] -ne [DBNull]::Value) { $decRecvAfterFull = [double]$r["RECEIVABLE_AMOUNT"] }
}
$r.Close()

$cmd.CommandText = "SELECT count(*), ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND branch_id = '1' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$r = $cmd.ExecuteReader()
$decArrearRowsCount = 0; $decArrearSumAfterFull = 0
if ($r.Read()) {
    $decArrearRowsCount = [int]$r[0]
    $decArrearSumAfterFull = [double]$r[1]
}
$r.Close()

$c3Pass = ($decArrearRowsCount -eq 0) -and ($decArrearSumAfterFull -eq 0) -and ($decRecvAfterFull -eq $novRecv)
Report-Result "Case 3: Fully Paid Previous Month" $c3Pass "Branch 1 Dec Arrear Rows = $decArrearRowsCount, Arrear Sum = $decArrearSumAfterFull (expected 0), Dec Total = $decRecvAfterFull (expected $novRecv)"

# STEP 5: Re-open voucher / Preview / Print simulation
# Test RecalculateVoucherArrears and TempDetail view
$feeType.GetMethod("RecalculateVoucherArrears").Invoke($feeInstance, @($decId, "12"))

# Query TempDetail view directly (which report uses)
$cmd.CommandText = "SELECT count(*) FROM TempDetail WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND (Fee_head LIKE '%Arrear%' OR sort_id = 99)"
$r = $cmd.ExecuteReader()
$tempDetailArrearCount = 0
if ($r.Read()) {
    $tempDetailArrearCount = [int]$r[0]
}
$r.Close()

# Also simulate fee regeneration when voucher exists
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cid1, "12 2026", "Morning", $sid1, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT count(*) FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decMasterCount = 0
if ($r.Read()) { $decMasterCount = [int]$r[0] }
$r.Close()

$cmd.CommandText = "SELECT count(*) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND branch_id = '1' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$r = $cmd.ExecuteReader()
$decArrearCountAfterRegen = 0
if ($r.Read()) { $decArrearCountAfterRegen = [int]$r[0] }
$r.Close()

$c4Pass = ($tempDetailArrearCount -eq 0) -and ($decMasterCount -eq 1) -and ($decArrearCountAfterRegen -eq 0)
Report-Result "Case 4: Reopen, Preview & Regenerate" $c4Pass "TempDetail Arrears = $tempDetailArrearCount (expected 0), Dec Voucher Count = $decMasterCount (expected 1), Arrears after regen = $decArrearCountAfterRegen (expected 0)"


# ==============================================================================
# TEST BRANCH 6 (Arrear Head 103)
# Student 1816, Class 43, Evening, Girls, Session 7
# ==============================================================================
$sysType.GetField("branch_ID").SetValue($null, "6")
$sysType.GetField("sessionid").SetValue($null, "7")
$sid6 = "1816"
$cid6 = "43"
$shift6 = "Evening"
$sec6 = "Girls"
$sess6 = "7"

# Clean student 1816 test records in session 7
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6';
"@
$cmd.ExecuteNonQuery() | Out-Null

# STEP 1: Generate November 2026 for Branch 6 (unpaid)
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cid6, "11 2026", $shift6, $sid6, 1, "11 2026", "2026-11-10", "1", "0", "Nov fee B6", "2026-11-01", "2026-11-01", "2026-11-30", $sec6))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6' AND branch_id = '6' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId6 = ""; $novRecv6 = 0
if ($r.Read()) {
    $novId6 = $r["FEE_MASTER_ID"].ToString()
    $novRecv6 = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

# STEP 2: Generate December 2026 for Branch 6 while November is unpaid
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cid6, "12 2026", $shift6, $sid6, 1, "12 2026", "2026-12-10", "1", "0", "Dec fee B6", "2026-12-01", "2026-12-01", "2026-12-31", $sec6))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6' AND branch_id = '6' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId6 = ""; $decRecv6 = 0
if ($r.Read()) {
    $decId6 = $r["FEE_MASTER_ID"].ToString()
    $decRecv6 = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

$cmd.CommandText = "SELECT Fee_head_id, AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6' AND ISCURRENT = 'N'"
$r = $cmd.ExecuteReader()
$decArrearAmt6 = 0; $decArrearHead6 = ""
if ($r.Read()) {
    $decArrearHead6 = $r["Fee_head_id"].ToString()
    $decArrearAmt6 = [double]$r["AMOUNT"]
}
$r.Close()

$b6UnpaidPass = ($decArrearAmt6 -eq $novRecv6) -and ($decArrearHead6 -eq "103")
Report-Result "Case 5a: Branch 6 Unpaid Arrears Head 103" $b6UnpaidPass "Branch 6 Dec Arrears = $decArrearAmt6 (expected $novRecv6), Head = $decArrearHead6 (expected 103)"

# STEP 3: Post Partial Payment on Branch 6 November voucher
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postB6Partial = $submitMethod.Invoke($feeInstance, @([double]1500.0, $novId6, $false, [DateTime]'2026-11-05', [DateTime]'2026-11-10', "1", "B601"))

$cmd.CommandText = "SELECT AMOUNT, Fee_head_id FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6' AND (ISCURRENT = 'N' OR Fee_head_id = '103')"
$r = $cmd.ExecuteReader()
$decB6ArrearAfterPartial = 0; $decB6HeadAfterPartial = ""
if ($r.Read()) {
    $decB6ArrearAfterPartial = [double]$r["AMOUNT"]
    $decB6HeadAfterPartial = $r["Fee_head_id"].ToString()
}
$r.Close()

$b6ExpectedRemaining = $novRecv6 - 1500.0
$b6PartialPass = ($decB6ArrearAfterPartial -eq $b6ExpectedRemaining) -and ($decB6HeadAfterPartial -eq "103")
Report-Result "Case 5b: Branch 6 Partial Payment" $b6PartialPass "Branch 6 Dec Arrears = $decB6ArrearAfterPartial (expected $b6ExpectedRemaining), Head = $decB6HeadAfterPartial (expected 103)"

# STEP 4: Post Full Payment on Branch 6 November voucher
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postB6Full = $submitMethod.Invoke($feeInstance, @([double]$novRecv6, $novId6, $false, [DateTime]'2026-11-09', [DateTime]'2026-11-10', "1", "B602"))

$cmd.CommandText = "SELECT count(*) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6' AND (ISCURRENT = 'N' OR Fee_head_id = '103')"
$b6ArrearCountAfterFull = [int]$cmd.ExecuteScalar()

$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE FEE_MASTER_ID = '$decId6' AND SessionID = '$sess6' AND branch_id = '6'"
$decB6RecvAfterFull = [double]$cmd.ExecuteScalar()

$b6FullPass = ($b6ArrearCountAfterFull -eq 0) -and ($decB6RecvAfterFull -eq $novRecv6)
Report-Result "Case 5c: Branch 6 Full Payment Arrears Removal" $b6FullPass "Branch 6 Dec Arrears Count = $b6ArrearCountAfterFull (expected 0), Dec Total = $decB6RecvAfterFull (expected $novRecv6)"


# ==============================================================================
# TEST CASE 6: Payment covering both current fee and arrears, Concession & Reports
# Student 736, Class 3, Morning, Male (A), Session 2, Branch 1 (Concession: 3300)
# ==============================================================================
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "2")
$sidConc = "736"
$cidConc = "3"
$shiftConc = "Morning"
$secConc = "Male (A)"
$sessConc = "2"

# Clean student 736 test records
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc';
"@
$cmd.ExecuteNonQuery() | Out-Null

# Generate November (billed with concession 3300, net 11400)
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "11 2026", $shiftConc, $sidConc, 1, "11 2026", "2026-11-10", "1", "0", "Nov Conc", "2026-11-01", "2026-11-01", "2026-11-30", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novConcId = ""; $novConcRecv = 0
if ($r.Read()) {
    $novConcId = $r["FEE_MASTER_ID"].ToString()
    $novConcRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

# Generate December
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "12 2026", $shiftConc, $sidConc, 1, "12 2026", "2026-12-10", "1", "0", "Dec Conc", "2026-12-01", "2026-12-01", "2026-12-31", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decConcId = ""; $decConcRecv = 0
if ($r.Read()) {
    $decConcId = $r["FEE_MASTER_ID"].ToString()
    $decConcRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

# Post payment on December voucher that covers BOTH December fee and November arrears!
$feeInstance = [System.Activator]::CreateInstance($feeType)
$postBothRet = $submitMethod.Invoke($feeInstance, @($decConcRecv, $decConcId, $false, [DateTime]'2026-12-05', [DateTime]'2026-12-10', "1", "BT01"))

# Now generate January 2027 fee for student 736: verify January gets 0 arrears!
$feeType.GetMethod("generatefeeMulti").Invoke($feeInstance, @($cidConc, "01 2027", $shiftConc, $sidConc, 1, "01 2027", "2027-01-10", "1", "0", "Jan Conc", "2027-01-01", "2027-01-01", "2027-01-31", $secConc))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc' AND branch_id = '1' AND FEE_MONTH = '01 2027'"
$r = $cmd.ExecuteReader()
$janConcId = ""; $janConcRecv = 0
if ($r.Read()) {
    $janConcId = $r["FEE_MASTER_ID"].ToString()
    $janConcRecv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()

$cmd.CommandText = "SELECT count(*) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$janConcId' AND SessionID = '$sessConc' AND branch_id = '1' AND (ISCURRENT = 'N' OR Fee_head_id = '40')"
$janArrearRowsCount = [int]$cmd.ExecuteScalar()

$c6Pass = ($janArrearRowsCount -eq 0) -and ($janConcRecv -eq $novConcRecv)
Report-Result "Case 6: Payment Covering Current + Arrears" $c6Pass "Jan Arrears Count = $janArrearRowsCount (expected 0), Jan Total = $janConcRecv (expected $novConcRecv)"

# CLEANUP TEST RECORDS IN SCMS_SF_TEST
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12';

DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6') AND SessionID = '$sess6';
DELETE FROM FEE_MASTER WHERE s_id = '$sid6' AND SessionID = '$sess6';

DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc') AND SessionID = '$sessConc';
DELETE FROM FEE_MASTER WHERE s_id = '$sidConc' AND SessionID = '$sessConc';
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()

# Verify SCMS_SF (Production database) untouched
$conProd = New-Object System.Data.SqlClient.SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$conProd.Open()
$cmdProd = $conProd.CreateCommand()
$cmdProd.CommandText = "SELECT count(*) FROM FEE_MASTER WHERE s_id IN ('2093', '1816', '736') AND FEE_MONTH IN ('11 2026', '12 2026', '01 2027')"
$prodTestCount = [int]$cmdProd.ExecuteScalar()
$cmdProd.CommandText = "SELECT count(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$prodPaidCount = [int]$cmdProd.ExecuteScalar()
$conProd.Close()

$prodUntouched = ($prodTestCount -eq 0) -and ($prodPaidCount -eq 15610)
Report-Result "Production Database Integrity" $prodUntouched "SCMS_SF test records = $prodTestCount (expected 0), PAID='Y' count = $prodPaidCount (expected 15610)"

# Verify App.config connection string points to SCMS_SF
$appConfig = [xml](Get-Content "App.config")
$prodConn = ($appConfig.configuration.connectionStrings.add | Where-Object { $_.name -eq 'Sqlconn' }).connectionString
$appConfigCorrect = ($prodConn -like "*Initial Catalog=SCMS_SF;*") -or ($prodConn -like "*Initial Catalog=SCMS_SF *")
Report-Result "Runtime App.config Configuration" $appConfigCorrect "Sqlconn points to production database SCMS_SF"

if ($allPass -and $prodUntouched -and $appConfigCorrect) {
    Write-Host "`n========================================================" -ForegroundColor Green
    Write-Host ">>> ALL ARREARS AND PAYMENT POSTING TESTS PASSED! <<<" -ForegroundColor Green
    Write-Host "========================================================`n" -ForegroundColor Green
    Exit 0
} else {
    Write-Host "`n>>> SOME ARREARS TESTS FAILED! <<<`n" -ForegroundColor Red
    Exit 1
}
