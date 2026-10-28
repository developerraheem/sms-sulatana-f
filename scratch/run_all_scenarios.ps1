# run_all_scenarios.ps1
# Test the 3 required scenarios against live compiled School.exe and LocalDB

$assemblyPath = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
[System.Reflection.Assembly]::LoadFrom($assemblyPath) | Out-Null

# Set SYSTEMSETTING correctly
[SYSTEMSETTING]::sessionid = "81"
[SYSTEMSETTING]::branch_ID = "2"

$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$testCid = "9999"
$testMonth = "Nov 2026"
$sidA = "99991"
$sidB = "99992"
$sidC = "99993"
$sidD = "99994"

Write-Host "=========================================================="
Write-Host "  TESTING SCENARIOS A, B, C (AND EXISTING VOUCHER UPDATE) "
Write-Host "=========================================================="

# 1. Clean up any previous test remnants
$cleanupQueries = @(
    "DELETE FROM FEE_DETAIL WHERE SessionID='81' AND branch_id='2' AND FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE C_ID='$testCid' AND SessionID='81' AND branch_id='2')",
    "DELETE FROM FEE_MASTER WHERE C_ID='$testCid' AND SessionID='81' AND branch_id='2'",
    "DELETE FROM FINE_HISTORY WHERE S_ID IN ('$sidA', '$sidB', '$sidC', '$sidD') AND SessionID='81' AND branch_id='2'",
    "DELETE FROM student WHERE c_id='$testCid' AND SessionID='81' AND branch_id='2'",
    "DELETE FROM FEE_CLASS WHERE C_ID='$testCid' AND branch_id='2'",
    "DELETE FROM class WHERE c_id='$testCid' AND branch_id='2'"
)
foreach ($q in $cleanupQueries) {
    $cmd.CommandText = $q
    $cmd.ExecuteNonQuery() | Out-Null
}

# 2. Setup Class 9999: Original Fee = 5,000 (Head 67), Fee Concession = 0 (Head 72)
$cmd.CommandText = "INSERT INTO class (c_id, c_name, branch_id) VALUES ('$testCid', 'TEST-SCENARIOS', '2')"
$cmd.ExecuteNonQuery() | Out-Null

$cmd.CommandText = "INSERT INTO FEE_CLASS (C_ID, Fee_head_id, AMOUNT, ACTIVE, TYPE, ISMULTIPLY, branch_id) VALUES ('$testCid', '67', 5000, 1, 'General', '', '2')"
$cmd.ExecuteNonQuery() | Out-Null

$cmd.CommandText = "INSERT INTO FEE_CLASS (C_ID, Fee_head_id, AMOUNT, ACTIVE, TYPE, ISMULTIPLY, branch_id) VALUES ('$testCid', '72', 0, 1, 'General', '', '2')"
$cmd.ExecuteNonQuery() | Out-Null

# 3. Setup Students
$students = @(
    @($sidA, "Student A - Fine Only"),
    @($sidB, "Student B - Concession Only"),
    @($sidC, "Student C - Fine and Concession"),
    @($sidD, "Student D - Existing Voucher Concession Update")
)
foreach ($std in $students) {
    $sid = $std[0]
    $sname = $std[1]
    $cmd.CommandText = "INSERT INTO student (s_id, ADMISSION_NO, s_name, f_name, c_id, SHIFT, SECTION_ID, SessionID, branch_id, active, TYPE, buscharges, CONCESSION_FEE) " +
                       "VALUES ('$sid', '$sid', '$sname', 'Father Name', '$testCid', 'Morning', '1', '81', '2', 'true', 'General', 'false', '0')"
    $cmd.ExecuteNonQuery() | Out-Null
}

Write-Host "Setup completed: Class $testCid with Fee Rs. 5,000 + Concession Head Rs. 0."

# -------------------------------------------------------------------------------------------------
# SCENARIO A: Fine only: Original fee Rs. 5,000; fine Rs. 100; no concession.
# Expected payable amount: Rs. 5,100, with no additional Rs. 9.00 deduction.
# -------------------------------------------------------------------------------------------------
Write-Host "`n--- SCENARIO A: Fine Only ---"
# Insert fine of Rs. 100
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) " +
                   "VALUES ('777001', '$sidA', '145', GETDATE(), 100, '$testMonth', '$testCid', 'Y', '81', '2', 'Scenario A Fine')"
$cmd.ExecuteNonQuery() | Out-Null

# Call generatefeeMulti for Student A
$feeObjA = New-Object School._class.FEE
$feeObjA.generatefeeMulti($testCid, $testMonth, "Morning", $sidA, 1, $testMonth, "11/20/2026", "1", "0", "Scenario A Test", "11/01/2026", "11/01/2026", "11/30/2026", "1")

# Verify Voucher for Student A
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id='$sidA' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
$mIdA = ""
$recAmtA = 0
if ($r.Read()) {
    $mIdA = $r["FEE_MASTER_ID"].ToString()
    $recAmtA = [Convert]::ToDouble($r["RECEIVABLE_AMOUNT"])
}
$r.Close()

$cmd.CommandText = "SELECT d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT FROM FEE_DETAIL d INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id WHERE d.FEE_MASTER_ID='$mIdA' AND d.SessionID='81' AND d.branch_id='2' ORDER BY d.FEE_DETAIL_ID"
$r = $cmd.ExecuteReader()
$detailsA = @()
$concCountA = 0
$hasIncorrect9A = $false
while ($r.Read()) {
    $hId = $r["Fee_head_id"].ToString()
    $hName = $r["Fee_head"].ToString()
    $amt = [Convert]::ToDouble($r["AMOUNT"])
    $cat = $r["Category"].ToString()
    $detailsA += [PSCustomObject]@{ HeadId=$hId; Name=$hName; Amount=$amt; Category=$cat }
    if ($cat -in @("DISCOUNT", "CONCESSION") -or $hId -eq "72") {
        $concCountA++
        if ($amt -eq -9.0 -or $amt -eq 9.0) { $hasIncorrect9A = $true }
    }
}
$r.Close()

Write-Host "Voucher ID: $mIdA"
Write-Host "Lines in FEE_DETAIL:"
foreach ($d in $detailsA) {
    Write-Host ("  - " + $d.Name + " (" + $d.HeadId + ", " + $d.Category + "): Rs. " + $d.Amount)
}
Write-Host "Total Payable Amount: Rs. $recAmtA (Expected: Rs. 5100)"
Write-Host "Concession lines count: $concCountA (Expected: 1 with Rs. 0)"
Write-Host "Incorrect Rs. 9.00 deduction present: $hasIncorrect9A (Expected: False)"

$passA = ($recAmtA -eq 5100) -and ($hasIncorrect9A -eq $false) -and ($concCountA -eq 1)
if ($passA) { Write-Host ">>> SCENARIO A PASSED! <<<" -ForegroundColor Green } else { Write-Host ">>> SCENARIO A FAILED! <<<" -ForegroundColor Red }

# -------------------------------------------------------------------------------------------------
# SCENARIO B: Concession only: Original fee Rs. 5,000; genuine concession Rs. 200.
# Expected payable amount: Rs. 4,800, with the concession applied only once.
# -------------------------------------------------------------------------------------------------
Write-Host "`n--- SCENARIO B: Concession Only ---"
# Insert genuine concession of Rs. 200
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) " +
                   "VALUES ('777002', '$sidB', '72', GETDATE(), 200, '$testMonth', '$testCid', 'Y', '81', '2', 'Scenario B Concession')"
$cmd.ExecuteNonQuery() | Out-Null

# Call generatefeeMulti for Student B
$feeObjB = New-Object School._class.FEE
$feeObjB.generatefeeMulti($testCid, $testMonth, "Morning", $sidB, 1, $testMonth, "11/20/2026", "1", "0", "Scenario B Test", "11/01/2026", "11/01/2026", "11/30/2026", "1")

# Verify Voucher for Student B
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id='$sidB' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
$mIdB = ""
$recAmtB = 0
if ($r.Read()) {
    $mIdB = $r["FEE_MASTER_ID"].ToString()
    $recAmtB = [Convert]::ToDouble($r["RECEIVABLE_AMOUNT"])
}
$r.Close()

$cmd.CommandText = "SELECT d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT FROM FEE_DETAIL d INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id WHERE d.FEE_MASTER_ID='$mIdB' AND d.SessionID='81' AND d.branch_id='2' ORDER BY d.FEE_DETAIL_ID"
$r = $cmd.ExecuteReader()
$detailsB = @()
$concCountB = 0
$concAmtB = 0
while ($r.Read()) {
    $hId = $r["Fee_head_id"].ToString()
    $hName = $r["Fee_head"].ToString()
    $amt = [Convert]::ToDouble($r["AMOUNT"])
    $cat = $r["Category"].ToString()
    $detailsB += [PSCustomObject]@{ HeadId=$hId; Name=$hName; Amount=$amt; Category=$cat }
    if ($cat -in @("DISCOUNT", "CONCESSION") -or $hId -eq "72") {
        $concCountB++
        $concAmtB = $amt
    }
}
$r.Close()

Write-Host "Voucher ID: $mIdB"
Write-Host "Lines in FEE_DETAIL:"
foreach ($d in $detailsB) {
    Write-Host ("  - " + $d.Name + " (" + $d.HeadId + ", " + $d.Category + "): Rs. " + $d.Amount)
}
Write-Host "Total Payable Amount: Rs. $recAmtB (Expected: Rs. 4800)"
Write-Host "Concession lines count: $concCountB (Expected: 1)"
Write-Host "Concession amount: Rs. $concAmtB (Expected: Rs. -200)"

$passB = ($recAmtB -eq 4800) -and ($concCountB -eq 1) -and ($concAmtB -eq -200)
if ($passB) { Write-Host ">>> SCENARIO B PASSED! <<<" -ForegroundColor Green } else { Write-Host ">>> SCENARIO B FAILED! <<<" -ForegroundColor Red }

# -------------------------------------------------------------------------------------------------
# SCENARIO C: Fine and concession: Original fee Rs. 5,000; fine Rs. 100; genuine concession Rs. 200.
# Expected payable amount: Rs. 4,900, with one fine adjustment and one valid concession adjustment.
# -------------------------------------------------------------------------------------------------
Write-Host "`n--- SCENARIO C: Fine and Concession ---"
# Insert fine Rs. 100
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) " +
                   "VALUES ('777003', '$sidC', '145', GETDATE(), 100, '$testMonth', '$testCid', 'Y', '81', '2', 'Scenario C Fine')"
$cmd.ExecuteNonQuery() | Out-Null

# Insert genuine concession Rs. 200
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) " +
                   "VALUES ('777004', '$sidC', '72', GETDATE(), 200, '$testMonth', '$testCid', 'Y', '81', '2', 'Scenario C Concession')"
$cmd.ExecuteNonQuery() | Out-Null

# Call generatefeeMulti for Student C
$feeObjC = New-Object School._class.FEE
$feeObjC.generatefeeMulti($testCid, $testMonth, "Morning", $sidC, 1, $testMonth, "11/20/2026", "1", "0", "Scenario C Test", "11/01/2026", "11/01/2026", "11/30/2026", "1")

# Verify Voucher for Student C
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id='$sidC' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
$mIdC = ""
$recAmtC = 0
if ($r.Read()) {
    $mIdC = $r["FEE_MASTER_ID"].ToString()
    $recAmtC = [Convert]::ToDouble($r["RECEIVABLE_AMOUNT"])
}
$r.Close()

$cmd.CommandText = "SELECT d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT FROM FEE_DETAIL d INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id WHERE d.FEE_MASTER_ID='$mIdC' AND d.SessionID='81' AND d.branch_id='2' ORDER BY d.FEE_DETAIL_ID"
$r = $cmd.ExecuteReader()
$detailsC = @()
$concCountC = 0
$fineCountC = 0
$concAmtC = 0
$fineAmtC = 0
while ($r.Read()) {
    $hId = $r["Fee_head_id"].ToString()
    $hName = $r["Fee_head"].ToString()
    $amt = [Convert]::ToDouble($r["AMOUNT"])
    $cat = $r["Category"].ToString()
    $detailsC += [PSCustomObject]@{ HeadId=$hId; Name=$hName; Amount=$amt; Category=$cat }
    if ($cat -in @("DISCOUNT", "CONCESSION") -or $hId -eq "72") {
        $concCountC++
        $concAmtC = $amt
    }
    if ($cat -eq "FINE" -or $hId -eq "145") {
        $fineCountC++
        $fineAmtC = $amt
    }
}
$r.Close()

Write-Host "Voucher ID: $mIdC"
Write-Host "Lines in FEE_DETAIL:"
foreach ($d in $detailsC) {
    Write-Host ("  - " + $d.Name + " (" + $d.HeadId + ", " + $d.Category + "): Rs. " + $d.Amount)
}
Write-Host "Total Payable Amount: Rs. $recAmtC (Expected: Rs. 4900)"
Write-Host "Concession lines count: $concCountC (Expected: 1), Amount: Rs. $concAmtC (Expected: -200)"
Write-Host "Fine lines count: $fineCountC (Expected: 1), Amount: Rs. $fineAmtC (Expected: 100)"

$passC = ($recAmtC -eq 4900) -and ($concCountC -eq 1) -and ($concAmtC -eq -200) -and ($fineCountC -eq 1) -and ($fineAmtC -eq 100)
if ($passC) { Write-Host ">>> SCENARIO C PASSED! <<<" -ForegroundColor Green } else { Write-Host ">>> SCENARIO C FAILED! <<<" -ForegroundColor Red }

# -------------------------------------------------------------------------------------------------
# SCENARIO D: Existing Voucher Update via ApplyPendingFinesToExistingVoucher
# Student D has existing voucher with original fee 5000 and 0 concession.
# Concession Rs. 200 is added later. ApplyPendingFinesToExistingVoucher must update the line, NOT duplicate it!
# -------------------------------------------------------------------------------------------------
Write-Host "`n--- SCENARIO D: Apply to Existing Voucher ---"
# Generate initial voucher for Student D (no fine, no concession)
$feeObjD = New-Object School._class.FEE
$feeObjD.generatefeeMulti($testCid, $testMonth, "Morning", $sidD, 1, $testMonth, "11/20/2026", "1", "0", "Scenario D Initial", "11/01/2026", "11/01/2026", "11/30/2026", "1")

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE s_id='$sidD' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
$mIdD = ""
if ($r.Read()) { $mIdD = $r["FEE_MASTER_ID"].ToString() }
$r.Close()

# Now insert concession Rs. 200 into FINE_HISTORY
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) " +
                   "VALUES ('777005', '$sidD', '72', GETDATE(), 200, '$testMonth', '$testCid', 'Y', '81', '2', 'Scenario D Concession')"
$cmd.ExecuteNonQuery() | Out-Null

# Call ApplyPendingFinesToExistingVoucher
$appliedD = $feeObjD.ApplyPendingFinesToExistingVoucher($mIdD, $sidD, "", $testMonth, $testMonth)

# Verify updated voucher
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT FROM FEE_MASTER WHERE FEE_MASTER_ID='$mIdD' AND SessionID='81' AND branch_id='2'"
$recAmtD = [Convert]::ToDouble($cmd.ExecuteScalar())

$cmd.CommandText = "SELECT d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT FROM FEE_DETAIL d INNER JOIN Fee_Head h ON d.Fee_head_id=h.Fee_head_id WHERE d.FEE_MASTER_ID='$mIdD' AND d.SessionID='81' AND d.branch_id='2' ORDER BY d.FEE_DETAIL_ID"
$r = $cmd.ExecuteReader()
$detailsD = @()
$concCountD = 0
$concAmtD = 0
while ($r.Read()) {
    $hId = $r["Fee_head_id"].ToString()
    $hName = $r["Fee_head"].ToString()
    $amt = [Convert]::ToDouble($r["AMOUNT"])
    $cat = $r["Category"].ToString()
    $detailsD += [PSCustomObject]@{ HeadId=$hId; Name=$hName; Amount=$amt; Category=$cat }
    if ($cat -in @("DISCOUNT", "CONCESSION") -or $hId -eq "72") {
        $concCountD++
        $concAmtD = $amt
    }
}
$r.Close()

Write-Host "Voucher ID: $mIdD"
Write-Host "Lines in FEE_DETAIL after ApplyPendingFinesToExistingVoucher:"
foreach ($d in $detailsD) {
    Write-Host ("  - " + $d.Name + " (" + $d.HeadId + ", " + $d.Category + "): Rs. " + $d.Amount)
}
Write-Host "Total Payable Amount: Rs. $recAmtD (Expected: Rs. 4800)"
Write-Host "Concession lines count: $concCountD (Expected: 1, exactly NO duplication)"
Write-Host "Concession amount: Rs. $concAmtD (Expected: Rs. -200)"

$passD = ($recAmtD -eq 4800) -and ($concCountD -eq 1) -and ($concAmtD -eq -200)
if ($passD) { Write-Host ">>> SCENARIO D PASSED! <<<" -ForegroundColor Green } else { Write-Host ">>> SCENARIO D FAILED! <<<" -ForegroundColor Red }

# 4. Clean up test data
foreach ($q in $cleanupQueries) {
    $cmd.CommandText = $q
    $cmd.ExecuteNonQuery() | Out-Null
}
$con.Close()

Write-Host "`n=========================================================="
if ($passA -and $passB -and $passC -and $passD) {
    Write-Host "  ALL TEST SCENARIOS PASSED WITH 100% SUCCESS!  " -ForegroundColor Green
} else {
    Write-Host "  SOME TEST SCENARIOS FAILED!  " -ForegroundColor Red
}
Write-Host "=========================================================="
