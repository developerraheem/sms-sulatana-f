# Test script for Excel Import functionality in CSMS_CSS
$binDir = (Resolve-Path "bin\Debug").Path
Set-Location $binDir

# Load dependencies first
Get-ChildItem -Path $binDir -Filter "*.dll" | ForEach-Object {
    try {
        [System.Reflection.Assembly]::LoadFrom($_.FullName) | Out-Null
    } catch {}
}
[System.Reflection.Assembly]::LoadFrom("$binDir\School.exe") | Out-Null

[School.SYSTEMSETTING]::branch_ID = "1"
[School.SYSTEMSETTING]::sessionid = "81"

Write-Output "=========================================================="
Write-Output "TEST 1: Verify Normalization and Resolution Logic"
Write-Output "=========================================================="

# Test Month Normalization
$testMonths = @(
    @{ Input = "10 2026"; Expected = "10 2026" },
    @{ Input = "9 2026"; Expected = "09 2026" },
    @{ Input = "10/2026"; Expected = "10 2026" },
    @{ Input = "2026-10"; Expected = "10 2026" },
    @{ Input = "October 2026"; Expected = "10 2026" },
    @{ Input = "Oct 2026"; Expected = "10 2026" },
    @{ Input = "2026-10-01"; Expected = "10 2026" },
    @{ Input = "15/10/2026"; Expected = "10 2026" },
    @{ Input = "invalid_month"; Expected = $null }
)

$monthTestsPassed = $true
foreach ($tm in $testMonths) {
    $norm = ""
    $res = [School._forms.FrmExcelImportPreview]::TryNormalizeFeeMonth($tm.Input, [ref]$norm)
    if ($tm.Expected -eq $null) {
        if ($res) {
            Write-Output "FAILED: Expected fail for '$($tm.Input)' but got '$norm'"
            $monthTestsPassed = $false
        }
    } else {
        if (-not $res -or $norm -ne $tm.Expected) {
            Write-Output "FAILED: Expected '$($tm.Expected)' for '$($tm.Input)' but got '$norm' (Success: $res)"
            $monthTestsPassed = $false
        }
    }
}
if ($monthTestsPassed) {
    Write-Output "PASS: All month normalization formats passed!"
}

# Test Amount Parsing
$testAmounts = @(
    @{ Input = "500"; Expected = 500.0 },
    @{ Input = "Rs. 1,500"; Expected = 1500.0 },
    @{ Input = "PKR 250.50"; Expected = 250.50 },
    @{ Input = "-100"; Expected = -100.0 },
    @{ Input = "abc"; Expected = 0.0 }
)
$amtTestsPassed = $true
foreach ($ta in $testAmounts) {
    $amt = 0.0
    $res = [School._forms.FrmExcelImportPreview]::TryParseFineAmount($ta.Input, [ref]$amt)
    if ($ta.Input -eq "abc") {
        if ($res) { Write-Output "FAILED: Expected parse fail for 'abc'"; $amtTestsPassed = $false }
    } else {
        if (-not $res -or [Math]::Abs($amt - $ta.Expected) -gt 0.01) {
            Write-Output "FAILED: Amount parse mismatch for '$($ta.Input)': got $amt"
            $amtTestsPassed = $false
        }
    }
}
if ($amtTestsPassed) {
    Write-Output "PASS: All amount parsing formats passed!"
}

Write-Output ""
Write-Output "=========================================================="
Write-Output "TEST 2: Preview Form Validation & Multi-Head Import Processing"
Write-Output "=========================================================="

# Build a test DataTable with:
# 1. Valid row: student 2093, Class PM-1G, Fee Month 10 2026, Fee Head 'Monthly Contribution', Amount 2500
# 2. Valid row (same student): student 2093, Class PM-1G, Fee Month 10 2026, Fee Head 'Late Fee Fine', Amount 200
# 3. Valid row (same student): student 2093, Class PM-1G, Fee Month 10 2026, Fee Head 'Fee Concession', Amount 500
# 4. Duplicate in file row (same student, same month, same head as #1)
# 5. Invalid student row: student 99999999
# 6. Invalid Fee Head row: 'Alien Space Head'
# 7. Invalid Fee Month row: 'Nonsense Month'
# 8. Invalid Amount row: 'Free'

$dt = New-Object System.Data.DataTable
$dt.Columns.Add("Student ID") | Out-Null
$dt.Columns.Add("Class") | Out-Null
$dt.Columns.Add("Fee Month") | Out-Null
$dt.Columns.Add("Fee Head") | Out-Null
$dt.Columns.Add("Amount") | Out-Null
$dt.Columns.Add("Reason") | Out-Null

$dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Tuition charge") | Out-Null
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Late Fee Fine", "200", "Late fee") | Out-Null
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Fee Concession", "500", "Discount") | Out-Null
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Duplicate Tuition") | Out-Null
$dt.Rows.Add("99999999", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Ghost student") | Out-Null
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Alien Space Head", "500", "Invalid head") | Out-Null
$dt.Rows.Add("2093", "PM-1G", "Nonsense Month", "Monthly Contribution", "2500", "Bad month") | Out-Null
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "Free", "Bad amt") | Out-Null

$preview = New-Object School._forms.FrmExcelImportPreview($dt, "10 2026", "39", "MONTHLY CONTRIBUTION", "1")
# Simulate Load
$bindingFlags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$loadMethod = $preview.GetType().GetMethod("FrmExcelImportPreview_Load", $bindingFlags)
$loadMethod.Invoke($preview, @($null, [System.EventArgs]::Empty))

# Inspect processed items
$fieldItems = $preview.GetType().GetField("processedItems", $bindingFlags)
$items = $fieldItems.GetValue($preview)

Write-Output "Processed Items Count: $($items.Count)"
for ($i = 0; $i -lt $items.Count; $i++) {
    $it = $items[$i]
    $headName = if ($it.ResolvedFeeHead -ne $null) { $it.ResolvedFeeHead.HeadName } else { "NULL" }
    $isConc = if ($it.ResolvedFeeHead -ne $null) { $it.ResolvedFeeHead.IsConcession } else { $false }
    Write-Output "Row $($it.RowNum): ID=$($it.InputStudentId), Month=$($it.ResolvedFeeMonth), Head=$headName (IsConc=$isConc), Amt=$($it.Amount), Status=$($it.Status), Notes=$($it.Notes)"
}

# Verify assertions:
# Rows 1, 2, 3 must be VALID
# Row 4 must be DUPLICATE
# Row 5 must be INVALID (Student not found)
# Row 6 must be INVALID (Fee head not configured)
# Row 7 must be INVALID (Invalid fee month)
# Row 8 must be INVALID (Invalid amount)

$pass = $true
if ($items[0].Status -ne "VALID") { Write-Output "FAIL: Row 1 should be VALID (got $($items[0].Status))"; $pass = $false }
if ($items[1].Status -ne "VALID") { Write-Output "FAIL: Row 2 should be VALID (got $($items[1].Status))"; $pass = $false }
if ($items[2].Status -ne "VALID") { Write-Output "FAIL: Row 3 should be VALID (got $($items[2].Status))"; $pass = $false }
if ($items[2].ResolvedFeeHead.IsConcession -ne $true) { Write-Output "FAIL: Row 3 should be detected as Concession"; $pass = $false }
if ($items[3].Status -ne "DUPLICATE") { Write-Output "FAIL: Row 4 should be DUPLICATE (got $($items[3].Status))"; $pass = $false }
if ($items[4].Status -ne "INVALID") { Write-Output "FAIL: Row 5 should be INVALID (got $($items[4].Status))"; $pass = $false }
if ($items[5].Status -ne "INVALID") { Write-Output "FAIL: Row 6 should be INVALID (got $($items[5].Status))"; $pass = $false }
if ($items[6].Status -ne "INVALID") { Write-Output "FAIL: Row 7 should be INVALID (got $($items[6].Status))"; $pass = $false }
if ($items[7].Status -ne "INVALID") { Write-Output "FAIL: Row 8 should be INVALID (got $($items[7].Status))"; $pass = $false }

if ($pass) {
    Write-Output "PASS: All validation rules, multi-head support, duplicate detection, and concession flags verified successfully!"
}

$preview.Dispose()
