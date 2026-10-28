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

# Override Settings.Default["sql_conn"]
$settingsType = $asm.GetType("School.Properties.Settings")
$settingsProp = $settingsType.GetProperty("Default")
$appSettings = $settingsProp.GetValue($null, $null)
$appSettings["sql_conn"] = $testConnStr

$sysType = $asm.GetType("SYSTEMSETTING")
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "78")

$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()
$cmd = $conn.CreateCommand()

Write-Host "================================================================" -ForegroundColor Cyan
Write-Host " STEP 1: INITIAL STATE VERIFICATION (CLASS 169, BRANCH 1)" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan

# Set Admission Fee active = 1 initially for clean test baseline
$cmd.CommandText = "UPDATE FEE_CLASS SET ACTIVE = 1 WHERE FEE_CLASS_ID = 52375"
$cmd.ExecuteNonQuery() | Out-Null

$cmd.CommandText = "SELECT FEE_CLASS_ID, Fee_head_id, C_ID, ACTIVE, AMOUNT, branch_id FROM FEE_CLASS WHERE FEE_CLASS_ID = 52375"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$initialActive = $dt.Rows[0]["ACTIVE"]
Write-Host "Initial Admission Fee (FEE_CLASS_ID 52375) Active = $initialActive"

# Also check Branch 8 (Class 16, FEE_CLASS_ID 41961)
$cmd.CommandText = "SELECT FEE_CLASS_ID, Fee_head_id, C_ID, ACTIVE, AMOUNT, branch_id FROM FEE_CLASS WHERE FEE_CLASS_ID = 41961"
$dtB8 = New-Object System.Data.DataTable
$da.Fill($dtB8) | Out-Null
Write-Host "Branch 8 Admission Fee (FEE_CLASS_ID 41961) Active = $($dtB8.Rows[0]['ACTIVE'])"

Write-Host "`n================================================================" -ForegroundColor Cyan
Write-Host " STEP 2: LOAD FORM, UNCHECK ADMISSION FEE, CLICK SAVE" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan

$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)

# Wire up / call Load
$loadMethod = $formType.GetMethod("Frm_generatefee_Load", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadMethod.Invoke($form, @($null, [System.EventArgs]::Empty))

$cmbClassProp = $formType.GetField("comboBox1", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$cmbClass = $cmbClassProp.GetValue($form)
$cmbClass.SelectedValue = [decimal]169

$gridField = $formType.GetField("fee_Class_updateDataGridView", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$grid = $gridField.GetValue($form)

Write-Host "Loaded Class Fee Heads in grid: $($grid.Rows.Count) rows"

# Find row for Admission Fee (52375)
$targetRow = $null
for ($i = 0; $i -lt $grid.Rows.Count; $i++) {
    if ([decimal]$grid.Rows[$i].Cells[0].Value -eq [decimal]52375) {
        $targetRow = $grid.Rows[$i]
        break
    }
}

if (-not $targetRow) {
    throw "Target row 52375 not found in grid!"
}

Write-Host "Found row: ID=$($targetRow.Cells[0].Value), Active in grid before edit=$($targetRow.Cells[4].Value)"

# Simulate unchecking the Active checkbox
$grid.CurrentCell = $targetRow.Cells[4]
$grid.BeginEdit($true) | Out-Null
$targetRow.Cells[4].Value = $false
# Notify dirty state changed
$dirtyMethod = $formType.GetMethod("fee_Class_updateDataGridView_CurrentCellDirtyStateChanged", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if ($dirtyMethod) {
    $dirtyMethod.Invoke($form, @($grid, [System.EventArgs]::Empty))
}

if (-not ([System.Management.Automation.PSTypeName]'ModalCloser').Type) {
    Add-Type @"
using System;
using System.Threading;
using System.Runtime.InteropServices;

public class ModalCloser {
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    public static void CloseNextDialog(string windowTitle, int timeoutMs) {
        ThreadPool.QueueUserWorkItem(state => {
            int elapsed = 0;
            while (elapsed < timeoutMs) {
                IntPtr hwnd = FindWindow(null, windowTitle);
                if (hwnd != IntPtr.Zero) {
                    PostMessage(hwnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
                    break;
                }
                Thread.Sleep(50);
                elapsed += 50;
            }
        });
    }
}
"@
}

# Click Save button (save method)
$saveMethod = $formType.GetMethod("fee_Class_updateBindingNavigatorSaveItem_Click", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$saveBtnField = $formType.GetField("fee_Class_updateBindingNavigatorSaveItem", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$saveBtn = $saveBtnField.GetValue($form)

[ModalCloser]::CloseNextDialog("[School Management System]", 5000)
$saveMethod.Invoke($form, @($saveBtn, [System.EventArgs]::Empty))

# Verify DB state immediately after save
$cmd.CommandText = "SELECT ACTIVE FROM FEE_CLASS WHERE FEE_CLASS_ID = 52375"
$dbActiveAfterSave = $cmd.ExecuteScalar()
Write-Host "Database ACTIVE after Save: $dbActiveAfterSave"
if ([bool]$dbActiveAfterSave -eq $false) {
    Write-Host "[PASS] Active checkbox state successfully saved as FALSE in database!" -ForegroundColor Green
} else {
    throw "FAILED: Database still has ACTIVE = $dbActiveAfterSave"
}

Write-Host "`n================================================================" -ForegroundColor Cyan
Write-Host " STEP 3: REFRESH / REOPEN FEE STRUCTURE - CONFIRM UNCHECKED" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan

# Re-trigger LoadClassFeeHeads
$loadHeadsMethod = $formType.GetMethod("LoadClassFeeHeads", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadHeadsMethod.Invoke($form, @())

$targetRowAfterRefresh = $null
for ($i = 0; $i -lt $grid.Rows.Count; $i++) {
    if ([decimal]$grid.Rows[$i].Cells[0].Value -eq [decimal]52375) {
        $targetRowAfterRefresh = $grid.Rows[$i]
        break
    }
}
Write-Host "Grid row after refresh: Active = $($targetRowAfterRefresh.Cells[4].Value)"
if ([bool]$targetRowAfterRefresh.Cells[4].Value -eq $false) {
    Write-Host "[PASS] Refreshed fee structure confirms Admission Fee remains UNCHECKED!" -ForegroundColor Green
} else {
    throw "FAILED: Grid row reverted to checked!"
}

Write-Host "`n================================================================" -ForegroundColor Cyan
Write-Host " STEP 4: GENERATE NEXT MONTH'S VOUCHER - CONFIRM NO ADMISSION FEE" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan

$testMonth = "11 2026"
$testStudentId = "22535"
$testClassId = "169"
$testShift = "Morning"
$testSec = "Female"

# Clean up any existing test voucher for this month and student in test session/branch
$cmd.CommandText = @"
DELETE fd FROM FEE_DETAIL fd 
JOIN FEE_MASTER fm ON fd.FEE_MASTER_ID = fm.FEE_MASTER_ID AND fd.SessionID = fm.SessionID AND fd.branch_id = fm.branch_id
WHERE fm.s_id = '$testStudentId' AND fm.SessionID = '78' AND fm.branch_id = '1' AND (fm.FEE_MONTH = '$testMonth' OR fm.FEE_MONTH_FROM = '$testMonth');

DELETE FROM FEE_MASTER WHERE s_id = '$testStudentId' AND SessionID = '78' AND branch_id = '1' AND (FEE_MONTH = '$testMonth' OR FEE_MONTH_FROM = '$testMonth');
"@
$cmd.ExecuteNonQuery() | Out-Null

$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)
$genMethod = $feeType.GetMethod("generatefeeMulti")

# Call generatefeeMulti(classid, month, shift, studentid, months, monthfrom, duedate, tmonths, tfine, remarks, issuedate, startdate, enddate, sectionID)
$genMethod.Invoke($feeInstance, @($testClassId, $testMonth, $testShift, $testStudentId, 1, $testMonth, "2026-11-10", "1", "0", "Test Inactive Fee Fix", "2026-11-01", "2026-11-01", "2026-11-30", $testSec))

# Query newly generated voucher details
$cmd.CommandText = @"
SELECT fd.FEE_MASTER_ID, fd.Fee_head_id, fh.Fee_head, fd.AMOUNT, fd.BALANCE
FROM FEE_DETAIL fd
JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id
JOIN FEE_MASTER fm ON fd.FEE_MASTER_ID = fm.FEE_MASTER_ID AND fd.SessionID = fm.SessionID AND fd.branch_id = fm.branch_id
WHERE fm.s_id = '$testStudentId' AND fm.FEE_MONTH = '$testMonth' AND fm.SessionID = '78' AND fm.branch_id = '1'
ORDER BY fd.Fee_head_id
"@
$dtDetails = New-Object System.Data.DataTable
$da.Fill($dtDetails) | Out-Null

Write-Host "Generated Voucher Details for Student $testStudentId, Month ${testMonth}:"
$dtDetails | Format-Table -AutoSize | Out-String | Write-Host

$hasAdmission = $false
$hasActiveHeads = $false
foreach ($dr in $dtDetails.Rows) {
    $hName = $dr["Fee_head"].ToString().ToUpper()
    if ($hName -like "*ADMISSION*") {
        $hasAdmission = $true
    } else {
        $hasActiveHeads = $true
    }
}

if ($hasAdmission) {
    throw "FAILED: Inactive Admission Fee was STILL ADDED to the generated voucher!"
} else {
    Write-Host "[PASS] Inactive Admission Fee was EXCLUDED from the generated voucher!" -ForegroundColor Green
}

if ($hasActiveHeads) {
    Write-Host "[PASS] Other active fee heads were correctly included in the voucher!" -ForegroundColor Green
} else {
    throw "FAILED: Other active fee heads were not included!"
}

Write-Host "`n================================================================" -ForegroundColor Cyan
Write-Host " STEP 5: BRANCH ISOLATION VERIFICATION" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan

# Check Branch 8 fee structure (FEE_CLASS_ID 41961)
$cmd.CommandText = "SELECT FEE_CLASS_ID, Fee_head_id, C_ID, ACTIVE, AMOUNT, branch_id FROM FEE_CLASS WHERE FEE_CLASS_ID = 41961"
$dtB8After = New-Object System.Data.DataTable
$da.Fill($dtB8After) | Out-Null
$b8ActiveAfter = $dtB8After.Rows[0]["ACTIVE"]
Write-Host "Branch 8 Admission Fee Active = $b8ActiveAfter (Expected True)"
if ([bool]$b8ActiveAfter -eq $true) {
    Write-Host "[PASS] Branch 8 fee structure was completely unaffected and remains ACTIVE!" -ForegroundColor Green
} else {
    throw "FAILED: Branch 8 fee structure was altered!"
}

Write-Host "`n================================================================" -ForegroundColor Cyan
Write-Host " STEP 6: REACTIVATE ADMISSION FEE - VERIFY IT IS INCLUDED AGAIN" -ForegroundColor Cyan
Write-Host "================================================================" -ForegroundColor Cyan

# Re-enable Admission Fee for Class 169
$grid.CurrentCell = $targetRowAfterRefresh.Cells[4]
$grid.BeginEdit($true) | Out-Null
$targetRowAfterRefresh.Cells[4].Value = $true
if ($dirtyMethod) {
    $dirtyMethod.Invoke($form, @($grid, [System.EventArgs]::Empty))
}
[ModalCloser]::CloseNextDialog("[School Management System]", 5000)
$saveMethod.Invoke($form, @($saveBtn, [System.EventArgs]::Empty))

$cmd.CommandText = "SELECT ACTIVE FROM FEE_CLASS WHERE FEE_CLASS_ID = 52375"
$dbActiveRestored = $cmd.ExecuteScalar()
Write-Host "Database ACTIVE after re-activating: $dbActiveRestored"

# Clean up test vouchers for month 1 and month 2
$cmd.CommandText = @"
DELETE fd FROM FEE_DETAIL fd 
JOIN FEE_MASTER fm ON fd.FEE_MASTER_ID = fm.FEE_MASTER_ID AND fd.SessionID = fm.SessionID AND fd.branch_id = fm.branch_id
WHERE fm.s_id = '$testStudentId' AND fm.SessionID = '78' AND fm.branch_id = '1' AND (fm.FEE_MONTH = '$testMonth' OR fm.FEE_MONTH = '$testMonth2');

DELETE FROM FEE_MASTER WHERE s_id = '$testStudentId' AND SessionID = '78' AND branch_id = '1' AND (FEE_MONTH = '$testMonth' OR FEE_MONTH = '$testMonth2');
"@
$cmd.ExecuteNonQuery() | Out-Null

$testMonth2 = "12 2026"
$genMethod.Invoke($feeInstance, @($testClassId, $testMonth2, $testShift, $testStudentId, 1, $testMonth2, "2026-12-10", "1", "0", "Test Active Fee Again", "2026-12-01", "2026-12-01", "2026-12-31", $testSec))

$cmd.CommandText = @"
SELECT fd.FEE_MASTER_ID, fd.Fee_head_id, fh.Fee_head, fd.AMOUNT, fd.BALANCE
FROM FEE_DETAIL fd
JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id
JOIN FEE_MASTER fm ON fd.FEE_MASTER_ID = fm.FEE_MASTER_ID AND fd.SessionID = fm.SessionID AND fd.branch_id = fm.branch_id
WHERE fm.s_id = '$testStudentId' AND fm.FEE_MONTH = '$testMonth2' AND fm.SessionID = '78' AND fm.branch_id = '1'
ORDER BY fd.Fee_head_id
"@
$dtDetails2 = New-Object System.Data.DataTable
$da.Fill($dtDetails2) | Out-Null
Write-Host "Generated Voucher Details when Reactivated ($testMonth2):"
$dtDetails2 | Format-Table -AutoSize | Out-String | Write-Host

$hasAdmission2 = $false
foreach ($dr in $dtDetails2.Rows) {
    if ($dr["Fee_head"].ToString().ToUpper() -like "*ADMISSION*") {
        $hasAdmission2 = $true
    }
}

if ($hasAdmission2) {
    Write-Host "[PASS] When re-activated, Admission Fee is correctly included on the voucher!" -ForegroundColor Green
} else {
    throw "FAILED: Admission Fee was not included when active!"
}

# Clean up test vouchers generated during this automated test
$cmd.CommandText = @"
DELETE fd FROM FEE_DETAIL fd 
JOIN FEE_MASTER fm ON fd.FEE_MASTER_ID = fm.FEE_MASTER_ID AND fd.SessionID = fm.SessionID AND fd.branch_id = fm.branch_id
WHERE fm.s_id = '$testStudentId' AND fm.SessionID = '78' AND fm.branch_id = '1' AND (fm.FEE_MONTH = '$testMonth' OR fm.FEE_MONTH = '$testMonth2');

DELETE FROM FEE_MASTER WHERE s_id = '$testStudentId' AND SessionID = '78' AND branch_id = '1' AND (FEE_MONTH = '$testMonth' OR FEE_MONTH = '$testMonth2');
"@
$cmd.ExecuteNonQuery() | Out-Null

$form.Dispose()
$conn.Close()

Write-Host "`nALL VERIFICATION TESTS PASSED SUCCESSFULLY!" -ForegroundColor Green
