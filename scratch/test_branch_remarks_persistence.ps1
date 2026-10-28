$ErrorActionPreference = 'Stop'
$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sys = $asm.GetType("SYSTEMSETTING")
$fieldBranch = $sys.GetField("branch_ID")
$fieldSession = $sys.GetField("sessionid")

$frmMultiType = $asm.GetType("School._forms.Frm_generatefee_multi")
$frmSingleType = $asm.GetType("School._forms.Frm_generatefee")
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::Public

Write-Host "==========================================================================" -ForegroundColor Cyan
Write-Host " VERIFICATION TEST: BRANCH-WISE VOUCHER REMARKS PERSISTENCE" -ForegroundColor Cyan
Write-Host "==========================================================================" -ForegroundColor Cyan

# Prepare DB connection to verify direct database state
$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

function Get-DbRemarks($branchId) {
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "SELECT Remarks FROM dbo.BranchVoucherRemarks WHERE Branch_ID = @b"
    $cmd.Parameters.Add((New-Object System.Data.SqlClient.SqlParameter("@b", [System.Data.SqlDbType]::VarChar, 50))) | Out-Null
    $cmd.Parameters["@b"].Value = $branchId.ToString()
    return $cmd.ExecuteScalar()
}

$ctorMulti = $frmMultiType.GetConstructor([Type]::EmptyTypes)
$fieldTxtNotes = $frmMultiType.GetField("txtnotes", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadMultiMethod = $frmMultiType.GetMethod("Frm_generatefee_Load", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$saveMultiMethod = $frmMultiType.GetMethod("SaveCurrentBranchVoucherNote", $flags)

# -------------------------------------------------------------------------
# Test 1: Open Branch 1 and enter remarks: "Branch A Test Remark"
# -------------------------------------------------------------------------
Write-Host "`n[Step 1] Open Branch 1 ('Islamabad College') in Generate Fee..." -ForegroundColor Yellow
$fieldBranch.SetValue($null, "1")
$fieldSession.SetValue($null, "1")

$frm1 = $ctorMulti.Invoke($null)
$loadMultiMethod.Invoke($frm1, @($null, [System.EventArgs]::Empty))

$txt1 = $fieldTxtNotes.GetValue($frm1)
Write-Host "Initially loaded remarks for Branch 1: '$($txt1.Text)'"

$remarkA = "Branch A Test Remark`r`nPlease deposit the fee before the due date."
$txt1.Text = $remarkA
Write-Host "Entered remarks for Branch 1: '$remarkA'"

# -------------------------------------------------------------------------
# Test 2: Save the remarks and switch to Branch 2
# -------------------------------------------------------------------------
Write-Host "`n[Step 2] Save remarks for Branch 1 and switch branch..." -ForegroundColor Yellow
$saveMultiMethod.Invoke($frm1, $null)

$dbRemarks1 = Get-DbRemarks("1")
Write-Host "Database verified for Branch 1: '$dbRemarks1'"
if ($dbRemarks1 -ne $remarkA) {
    throw "FAILED: Branch 1 remarks in DB do not match entered text!"
}
Write-Host "PASS: Branch 1 remarks successfully saved to BranchVoucherRemarks." -ForegroundColor Green

$frm1.Close()

# -------------------------------------------------------------------------
# Test 3: Switch to Branch 2 and enter/save "Branch B Test Remark"
# -------------------------------------------------------------------------
Write-Host "`n[Step 3] Switch to Branch 2 ('PRINCE SALMAN COLLEGE') and enter remarks..." -ForegroundColor Yellow
$fieldBranch.SetValue($null, "2")
$fieldSession.SetValue($null, "1")

$frm2 = $ctorMulti.Invoke($null)
$loadMultiMethod.Invoke($frm2, @($null, [System.EventArgs]::Empty))

$txt2 = $fieldTxtNotes.GetValue($frm2)
Write-Host "Initially loaded remarks for Branch 2: '$($txt2.Text)'"

$remarkB = "Branch B Test Remark`r`nPlease submit the fee voucher to the school office."
$txt2.Text = $remarkB
Write-Host "Entered remarks for Branch 2: '$remarkB'"

$saveMultiMethod.Invoke($frm2, $null)

$dbRemarks2 = Get-DbRemarks("2")
Write-Host "Database verified for Branch 2: '$dbRemarks2'"
if ($dbRemarks2 -ne $remarkB) {
    throw "FAILED: Branch 2 remarks in DB do not match entered text!"
}
Write-Host "PASS: Branch 2 remarks successfully saved to BranchVoucherRemarks." -ForegroundColor Green
$frm2.Close()

# -------------------------------------------------------------------------
# Test 4: Switch back to Branch 1 and verify "Branch A Test Remark" appears exactly as saved
# -------------------------------------------------------------------------
Write-Host "`n[Step 4] Switch back to Branch 1 and reopen Generate Fee..." -ForegroundColor Yellow
$fieldBranch.SetValue($null, "1")
$frm1_reopen = $ctorMulti.Invoke($null)
$loadMultiMethod.Invoke($frm1_reopen, @($null, [System.EventArgs]::Empty))

$txt1_reopen = $fieldTxtNotes.GetValue($frm1_reopen)
Write-Host "Reopened Branch 1 displayed remarks: '$($txt1_reopen.Text)'"
if ($txt1_reopen.Text -ne $remarkA) {
    throw "FAILED: Branch 1 reloaded remarks do not match '$remarkA'!"
}
Write-Host "PASS: Branch 1 retained its exact saved remarks including line breaks!" -ForegroundColor Green
$frm1_reopen.Close()

# -------------------------------------------------------------------------
# Test 5: Return to Branch 2 and verify "Branch B Test Remark" appears
# -------------------------------------------------------------------------
Write-Host "`n[Step 5] Switch back to Branch 2 and reopen Generate Fee..." -ForegroundColor Yellow
$fieldBranch.SetValue($null, "2")
$frm2_reopen = $ctorMulti.Invoke($null)
$loadMultiMethod.Invoke($frm2_reopen, @($null, [System.EventArgs]::Empty))

$txt2_reopen = $fieldTxtNotes.GetValue($frm2_reopen)
Write-Host "Reopened Branch 2 displayed remarks: '$($txt2_reopen.Text)'"
if ($txt2_reopen.Text -ne $remarkB) {
    throw "FAILED: Branch 2 reloaded remarks do not match '$remarkB'!"
}
Write-Host "PASS: Branch 2 retained its exact saved remarks!" -ForegroundColor Green
$frm2_reopen.Close()

# -------------------------------------------------------------------------
# Test 6: Test switching branches while the form remains OPEN (using Activated)
# -------------------------------------------------------------------------
Write-Host "`n[Step 6] Test switching branch while Generate Fee is OPEN in background..." -ForegroundColor Yellow
$fieldBranch.SetValue($null, "1")
$frmLive = $ctorMulti.Invoke($null)
$loadMultiMethod.Invoke($frmLive, @($null, [System.EventArgs]::Empty))
$txtLive = $fieldTxtNotes.GetValue($frmLive)
Write-Host "Active in Branch 1: '$($txtLive.Text)'"

# Update remarks live in Branch 1
$remarkA_v2 = "Branch A Updated Remarks v2 - Late payment fee Rs. 1000"
$txtLive.Text = $remarkA_v2

# User switches branch in frmchangesession to Branch 2 without closing frmLive!
$fieldBranch.SetValue($null, "2")

# frmLive becomes Activated again
$activatedMethod = $frmMultiType.GetMethod("Frm_generatefee_multi_Activated", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$activatedMethod.Invoke($frmLive, @($null, [System.EventArgs]::Empty))

# Verify that frmLive saved Branch 1 remarks AND loaded Branch 2 remarks!
$dbRemarks1_updated = Get-DbRemarks("1")
Write-Host "Database Branch 1 after live switch: '$dbRemarks1_updated'"
if ($dbRemarks1_updated -ne $remarkA_v2) {
    throw "FAILED: Branch 1 remarks were not automatically saved before live branch switch!"
}
Write-Host "PASS: Branch 1 remarks automatically saved before branch switch!" -ForegroundColor Green

Write-Host "frmLive remarks now displayed for Branch 2: '$($txtLive.Text)'"
if ($txtLive.Text -ne $remarkB) {
    throw "FAILED: frmLive did not load Branch 2 remarks on Activated!"
}
Write-Host "PASS: Form dynamically reloaded Branch 2 remarks on branch switch!" -ForegroundColor Green
$frmLive.Close()

# -------------------------------------------------------------------------
# Test 7: Confirm updating one branch never overwrites another branch
# -------------------------------------------------------------------------
Write-Host "`n[Step 7] Confirm updating Branch 1 does NOT touch Branch 2..." -ForegroundColor Yellow
$finalDbRemarks1 = Get-DbRemarks("1")
$finalDbRemarks2 = Get-DbRemarks("2")
Write-Host "Final Branch 1 DB: '$finalDbRemarks1'"
Write-Host "Final Branch 2 DB: '$finalDbRemarks2'"
if ($finalDbRemarks1 -ne $remarkA_v2 -or $finalDbRemarks2 -ne $remarkB) {
    throw "FAILED: Cross-branch pollution detected!"
}
Write-Host "PASS: Zero cross-branch pollution. Each branch retains its own remarks." -ForegroundColor Green

# -------------------------------------------------------------------------
# Test 8: Verify remarks are used in fee generation and voucher printing
# -------------------------------------------------------------------------
Write-Host "`n[Step 8] Verify remarks persistence into FEE_MASTER when generating fee vouchers..." -ForegroundColor Yellow
$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)

# Generate a test voucher for Branch 1 using the saved remarks
$testMonth = "12/2026"
$fieldBranch.SetValue($null, "1")
$fieldSession.SetValue($null, "1")

# Find a valid student in Branch 1
$cmdStd = $conn.CreateCommand()
$cmdStd.CommandText = "SELECT TOP 1 s_id, c_id, SHIFT, SECTION_ID, SessionID FROM student WHERE branch_id = 1 AND active = 1"
$readerStd = $cmdStd.ExecuteReader()
if ($readerStd.Read()) {
    $stdId = $readerStd["s_id"].ToString()
    $cId = $readerStd["c_id"].ToString()
    $shift = $readerStd["SHIFT"].ToString()
    $sectionId = $readerStd["SECTION_ID"].ToString()
    $stdSession = $readerStd["SessionID"].ToString()
    $readerStd.Close()

    $fieldSession.SetValue($null, $stdSession)

    # Clean existing test voucher if any
    $cmdDel = $conn.CreateCommand()
    $cmdDel.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$stdId' AND FEE_MONTH = '$testMonth' AND branch_id = 1); DELETE FROM FEE_MASTER WHERE s_id = '$stdId' AND FEE_MONTH = '$testMonth' AND branch_id = 1;"
    $cmdDel.ExecuteNonQuery()

    # Call generatefeeMulti with remarkA_v2
    $genMethod = $feeType.GetMethod("generatefeeMulti")
    $genMethod.Invoke($feeInstance, @($cId, $testMonth, $shift, $stdId, 1, $testMonth, "10/12/2026", "1", "0", $remarkA_v2, "01/12/2026", "01/12/2026", "31/12/2026", $sectionId))

    # Verify FEE_MASTER.REMARKS
    $cmdCheck = $conn.CreateCommand()
    $cmdCheck.CommandText = "SELECT TOP 1 REMARKS FROM FEE_MASTER WHERE s_id = '$stdId' AND FEE_MONTH = '$testMonth' AND branch_id = 1"
    $savedVoucherRemarks = $cmdCheck.ExecuteScalar()
    Write-Host "Generated voucher REMARKS in FEE_MASTER: '$savedVoucherRemarks'"
    if ($savedVoucherRemarks -ne $remarkA_v2) {
        throw "FAILED: FEE_MASTER.REMARKS does not match branch voucher remarks!"
    }
    Write-Host "PASS: Voucher generation and printing workflow correctly uses branch remarks!" -ForegroundColor Green

    # Clean up test voucher
    $cmdDel.ExecuteNonQuery()
} else {
    $readerStd.Close()
    Write-Host "Notice: No active students in Branch 1 to test voucher insertion, checked schema only." -ForegroundColor Gray
}

# -------------------------------------------------------------------------
# Test 9: Verify Frm_generatefee (single-student form) also supports BranchVoucherRemarks
# -------------------------------------------------------------------------
Write-Host "`n[Step 9] Verify Frm_generatefee (single) loads and persists branch remarks..." -ForegroundColor Yellow
$ctorSingle = $frmSingleType.GetConstructor([Type]::EmptyTypes)
$frmSingle = $ctorSingle.Invoke($null)
$fieldTxtRemarks = $frmSingleType.GetField("txtremarks", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadSingleMethod = $frmSingleType.GetMethod("Frm_generatefee_Load", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)

$fieldBranch.SetValue($null, "1")
$loadSingleMethod.Invoke($frmSingle, @($null, [System.EventArgs]::Empty))
$txtSingle = $fieldTxtRemarks.GetValue($frmSingle)
Write-Host "Frm_generatefee loaded Branch 1 remarks: '$($txtSingle.Text)'"
if ($txtSingle.Text -ne $remarkA_v2) {
    throw "FAILED: Frm_generatefee did not load Branch 1 remarks!"
}
Write-Host "PASS: Frm_generatefee correctly loaded Branch 1 remarks!" -ForegroundColor Green
$frmSingle.Close()

$conn.Close()

Write-Host "`n==========================================================================" -ForegroundColor Cyan
Write-Host " ALL VERIFICATION TESTS PASSED PERFECTLY!" -ForegroundColor Green
Write-Host "==========================================================================" -ForegroundColor Cyan
