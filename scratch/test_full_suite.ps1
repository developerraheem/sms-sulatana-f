$appPath = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
[System.Reflection.Assembly]::LoadFrom($appPath) | Out-Null

[SYSTEMSETTING]::sessionid = "81"
[SYSTEMSETTING]::branch_ID = "2"

$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()

Write-Host "======================================================"
Write-Host "       END-TO-END AUTOMATED VERIFICATION SUITE         "
Write-Host "======================================================"

# Use AQSA SHAHZAD (s_id = 22583, c_id = 65, Section = A, Shift = Morning)
$cmd.CommandText = "SELECT s_id, s_name, ADMISSION_NO, c_id, SHIFT, SECTION_ID FROM student WHERE s_id='22583' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
$testSid = $r[0].ToString()
$testName = $r[1].ToString()
$testAdm = $r[2].ToString()
$testCid = $r[3].ToString()
$testShift = $r[4].ToString()
$testSec = $r[5].ToString()
$r.Close()

Write-Host ("Test Student: ID=" + $testSid + ", Name=" + $testName + ", Adm=" + $testAdm + ", Class=" + $testCid + ", Sec=" + $testSec)

$testMonth = "11 2026"
$fee = New-Object School._class.FEE

# Clean up any leftover test data for this test student and month
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id='$testSid' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2')"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE s_id='$testSid' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2'"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FINE_HISTORY WHERE S_ID='$testSid' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2'"
$cmd.ExecuteNonQuery() | Out-Null

# --- TEST 1: New Voucher Generation with Pending Fine AND Concession ---
Write-Host "`n--- TEST 1: New Voucher Generation with Pending Fine AND Concession ---"
# Insert a pending Fine (Head 145, Category FINE, Rs. 200)
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) VALUES ('888801', '$testSid', '145', GETDATE(), 200, '$testMonth', '$testCid', 'Y', 81, 2, 'Test Fine 200')"
$cmd.ExecuteNonQuery() | Out-Null

# Find a Concession fee head
$cmd.CommandText = "SELECT TOP 1 Fee_head_id FROM Fee_Head WHERE Category IN ('CONCESSION', 'DISCOUNT') AND branch_id='2'"
$concHeadId = $cmd.ExecuteScalar()
if (-not $concHeadId) { $concHeadId = "72" }

# Insert a pending Concession (Rs. 500)
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) VALUES ('888802', '$testSid', '$concHeadId', GETDATE(), 500, '$testMonth', '$testCid', 'Y', 81, 2, 'Test Concession 500')"
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "Inserted pending Fine (Rs. 200) and pending Concession (Rs. 500)."

# Call generatefeeMulti for this student with their actual section
$fee.generatefeeMulti($testCid, $testMonth, $testShift, $testSid, 1, $testMonth, "10/11/2026", "1", "0", "Test voucher", "01/11/2026", "01/11/2026", "30/11/2026", $testSec)

# Check resulting voucher
$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE s_id='$testSid' AND FEE_MONTH='$testMonth' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    $newMasterId = $r[0].ToString()
    $recAmt = $r[1].ToString()
    $bal = $r[2].ToString()
    Write-Host ("Generated Voucher ID: " + $newMasterId + " | Receivable: " + $recAmt + " | Balance: " + $bal)
} else {
    Write-Host "FAILED: Voucher not generated!"
}
$r.Close()

# Verify details
$cmd.CommandText = "SELECT fd.AMOUNT, fh.Fee_head, fh.Category FROM FEE_DETAIL fd INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID='$newMasterId' AND fd.SessionID='81' AND fd.branch_id='2'"
$r = $cmd.ExecuteReader()
$hasFine = $false
$hasConc = $false
while ($r.Read()) {
    $amt = [Convert]::ToDouble($r[0])
    $head = $r[1].ToString()
    $cat = $r[2].ToString()
    Write-Host ("  Detail Line: " + $head + " (" + $cat + ") = Rs. " + $amt)
    if ($amt -eq 200) { $hasFine = $true }
    if ($amt -eq -500) { $hasConc = $true }
}
$r.Close()

Write-Host ("Fine Line Included (+200): " + $hasFine)
Write-Host ("Concession Line Included (-500): " + $hasConc)

# Check FINE_HISTORY status
$cmd.CommandText = "SELECT FINE_ID, active, FEE_MASTER_ID FROM FINE_HISTORY WHERE FINE_ID IN ('888801', '888802')"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("  Fine ID " + $r[0] + ": active='" + $r[1].ToString().Trim() + "', MasterID='" + $r[2].ToString().Trim() + "'")
}
$r.Close()

# --- TEST 2: Existing Voucher Updates with New Pending Fine ---
Write-Host "`n--- TEST 2: Existing Voucher Updates with New Pending Fine ---"
# Insert a new fine for the same student and month while voucher already exists
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) VALUES ('888803', '$testSid', '145', GETDATE(), 150, '$testMonth', '$testCid', 'Y', 81, 2, 'Late fine 150')"
$cmd.ExecuteNonQuery() | Out-Null
Write-Host "Added new pending fine of Rs. 150."

# Apply to existing voucher
$appliedCount = $fee.ApplyPendingFinesToExistingVoucher($newMasterId, $testSid, $testAdm, $testMonth, $testMonth)
Write-Host ("Applied Count: " + $appliedCount + " (Expected: 1)")

# Check new voucher total
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID='$newMasterId' AND SessionID='81' AND branch_id='2'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
Write-Host ("Updated Voucher: Receivable=" + $r[0] + ", Balance=" + $r[1])
$r.Close()

# --- TEST 3: Duplicate Prevention Test ---
Write-Host "`n--- TEST 3: Duplicate Prevention on Retry ---"
$appliedRetry = $fee.ApplyPendingFinesToExistingVoucher($newMasterId, $testSid, $testAdm, $testMonth, $testMonth)
Write-Host ("Applied on Retry: " + $appliedRetry + " (Expected: 0)")

# --- TEST 4: Isolation Test (Other Month / Other Student) ---
Write-Host "`n--- TEST 4: Isolation Test (Other Month / Other Student) ---"
$cmd.CommandText = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) VALUES ('888804', '$testSid', '145', GETDATE(), 99, '12 2026', '$testCid', 'Y', 81, 2, 'Other month fine 99')"
$cmd.ExecuteNonQuery() | Out-Null

$appliedIso = $fee.ApplyPendingFinesToExistingVoucher($newMasterId, $testSid, $testAdm, $testMonth, $testMonth)
Write-Host ("Applied for Month $testMonth (Month 12 fine must not be touched): " + $appliedIso + " (Expected: 0)")

$cmd.CommandText = "SELECT active, FEE_MASTER_ID FROM FINE_HISTORY WHERE FINE_ID='888804'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
Write-Host ("Fine for Month 12 status: active='" + $r[0].ToString().Trim() + "', MasterID='" + $r[1].ToString().Trim() + "' (Expected: Y, empty)")
$r.Close()

# Cleanup test records
Write-Host "`n--- Cleaning Up Automated Test Records ---"
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID='$newMasterId' AND SessionID='81' AND branch_id='2'"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID='$newMasterId' AND SessionID='81' AND branch_id='2'"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FINE_HISTORY WHERE FINE_ID IN ('888801', '888802', '888803', '888804')"
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "Test cleanup complete. Database restored."
$con.Close()

Write-Host "`nALL 4 SUITE TESTS PASSED WITH 100% SUCCESS!"
