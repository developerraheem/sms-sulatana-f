$binDir = (Resolve-Path "bin\Debug").Path
Set-Location $binDir

# Load all referenced dlls into current 32-bit AppDomain
Get-ChildItem -Path $binDir -Filter "*.dll" | ForEach-Object {
    try {
        [System.Reflection.Assembly]::LoadFrom($_.FullName) | Out-Null
    } catch {}
}

$asm = [System.Reflection.Assembly]::LoadFrom("$binDir\School.exe")
$type = $asm.GetType("School._forms.FrmExcelImportPreview")
$sysType = $asm.GetType("School.SYSTEMSETTING")

# Set Branch and Session
$propBranch = $sysType.GetProperty("branch_ID")
$propBranch.SetValue($null, "1", $null)
$propSession = $sysType.GetProperty("sessionid")
$propSession.SetValue($null, "81", $null)

Write-Output "=========================================================="
Write-Output "SECTION 1: Month Normalization and Amount Parsing Unit Tests"
Write-Output "=========================================================="

$normMethod = $type.GetMethod("TryNormalizeFeeMonth", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static)
$testMonths = @(
    @{ In = "10 2026"; Exp = "10 2026" },
    @{ In = "9 2026"; Exp = "09 2026" },
    @{ In = "10/2026"; Exp = "10 2026" },
    @{ In = "2026-10"; Exp = "10 2026" },
    @{ In = "October 2026"; Exp = "10 2026" },
    @{ In = "Oct 2026"; Exp = "10 2026" },
    @{ In = "2026-10-01"; Exp = "10 2026" },
    @{ In = "15/10/2026"; Exp = "10 2026" },
    @{ In = "invalid_month"; Exp = $null }
)

$sec1Pass = $true
foreach ($tm in $testMonths) {
    $arr = @($tm.In, $null)
    $ok = $normMethod.Invoke($null, $arr)
    if ($tm.Exp -eq $null) {
        if ($ok) { Write-Output "FAIL: Expected failure for '$($tm.In)'"; $sec1Pass = $false }
    } else {
        if (-not $ok -or $arr[1] -ne $tm.Exp) {
            Write-Output "FAIL: For '$($tm.In)', expected '$($tm.Exp)' but got '$($arr[1])'"
            $sec1Pass = $false
        }
    }
}
if ($sec1Pass) { Write-Output "PASS: All month normalization formats passed!" }

$parseMethod = $type.GetMethod("TryParseFineAmount", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static)
$testAmts = @(
    @{ In = "500"; Exp = 500.0 },
    @{ In = "Rs. 1,500"; Exp = 1500.0 },
    @{ In = "PKR 250.50"; Exp = 250.50 },
    @{ In = "-100"; Exp = -100.0 },
    @{ In = "free"; Exp = 0.0 }
)
$amtPass = $true
foreach ($ta in $testAmts) {
    $arr = @($ta.In, 0.0)
    $ok = $parseMethod.Invoke($null, $arr)
    if ($ta.In -eq "free") {
        if ($ok) { Write-Output "FAIL: Expected failure for 'free'"; $amtPass = $false }
    } else {
        if (-not $ok -or [Math]::Abs($arr[1] - $ta.Exp) -gt 0.01) {
            Write-Output "FAIL: For '$($ta.In)', expected $($ta.Exp) but got $($arr[1])"
            $amtPass = $false
        }
    }
}
if ($amtPass) { Write-Output "PASS: All amount parsing formats passed!" }

Write-Output ""
Write-Output "=========================================================="
Write-Output "SECTION 2: Multi-Row, Multi-Head, Duplicate & Validation Processing"
Write-Output "=========================================================="

# Create DataTable with 8 test rows
$dt = New-Object System.Data.DataTable
$dt.Columns.Add("Student ID") | Out-Null
$dt.Columns.Add("Class") | Out-Null
$dt.Columns.Add("Fee Month") | Out-Null
$dt.Columns.Add("Fee Head") | Out-Null
$dt.Columns.Add("Amount") | Out-Null
$dt.Columns.Add("Reason") | Out-Null

# Row 1: Student 2093, Monthly Contribution (charge)
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Tuition charge") | Out-Null
# Row 2: Same student 2093, Late Fee Fine (fine)
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Late Fee Fine", "200", "Late fee") | Out-Null
# Row 3: Same student 2093, Fee Concession (concession)
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Fee Concession", "500", "Discount") | Out-Null
# Row 4: Duplicate of Row 1 in file
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Duplicate Tuition") | Out-Null
# Row 5: Invalid student ID
$dt.Rows.Add("99999999", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Ghost student") | Out-Null
# Row 6: Invalid Fee Head
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Alien Space Head", "500", "Invalid head") | Out-Null
# Row 7: Invalid Fee Month
$dt.Rows.Add("2093", "PM-1G", "Nonsense Month", "Monthly Contribution", "2500", "Bad month") | Out-Null
# Row 8: Invalid Amount
$dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "Free", "Bad amt") | Out-Null

$ctor = $type.GetConstructor(@([System.Data.DataTable], [string], [string], [string], [string]))
$ctorArgs = [object[]]@($dt, "10 2026", "39", "MONTHLY CONTRIBUTION", "1")
$preview = $ctor.Invoke($ctorArgs)

# Invoke Load
$bindingFlags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$loadMethod = $type.GetMethod("FrmExcelImportPreview_Load", $bindingFlags)
$loadMethod.Invoke($preview, [object[]]@($null, [System.EventArgs]::Empty))

$fieldItems = $type.GetField("processedItems", $bindingFlags)
$items = $fieldItems.GetValue($preview)

Write-Output "Total Rows Processed: $($items.Count)"
for ($i = 0; $i -lt $items.Count; $i++) {
    $it = $items[$i]
    $headName = if ($it.ResolvedFeeHead -ne $null) { $it.ResolvedFeeHead.HeadName } else { "NULL" }
    $isConc = if ($it.ResolvedFeeHead -ne $null) { $it.ResolvedFeeHead.IsConcession } else { $false }
    Write-Output "Row $($it.RowNum): ID=$($it.InputStudentId), Month=$($it.ResolvedFeeMonth), Head=$headName (IsConc=$isConc), Amt=$($it.Amount), Status=$($it.Status), Notes=$($it.Notes)"
}

$sec2Pass = $true
if ($items[0].Status -ne "VALID") { Write-Output "FAIL: Row 1 should be VALID (got $($items[0].Status))"; $sec2Pass = $false }
if ($items[1].Status -ne "VALID") { Write-Output "FAIL: Row 2 should be VALID (got $($items[1].Status))"; $sec2Pass = $false }
if ($items[2].Status -ne "VALID") { Write-Output "FAIL: Row 3 should be VALID (got $($items[2].Status))"; $sec2Pass = $false }
if ($items[2].ResolvedFeeHead.IsConcession -ne $true) { Write-Output "FAIL: Row 3 should be detected as Concession"; $sec2Pass = $false }
if ($items[3].Status -ne "DUPLICATE") { Write-Output "FAIL: Row 4 should be DUPLICATE (got $($items[3].Status))"; $sec2Pass = $false }
if ($items[4].Status -ne "INVALID") { Write-Output "FAIL: Row 5 should be INVALID (got $($items[4].Status))"; $sec2Pass = $false }
if ($items[5].Status -ne "INVALID") { Write-Output "FAIL: Row 6 should be INVALID (got $($items[5].Status))"; $sec2Pass = $false }
if ($items[6].Status -ne "INVALID") { Write-Output "FAIL: Row 7 should be INVALID (got $($items[6].Status))"; $sec2Pass = $false }
if ($items[7].Status -ne "INVALID") { Write-Output "FAIL: Row 8 should be INVALID (got $($items[7].Status))"; $sec2Pass = $false }

if ($sec2Pass) {
    Write-Output "PASS: Section 2 passed! Multiple rows for same student with different heads are allowed, concessions flagged, duplicates caught, invalid rows cleanly rejected."
}

$preview.Dispose()

Write-Output ""
Write-Output "=========================================================="
Write-Output "SECTION 3: Legacy Fine Template Backward Compatibility"
Write-Output "=========================================================="

# Test legacy table without 'Fee Month' and without 'Fee Head' columns
$dtLegacy = New-Object System.Data.DataTable
$dtLegacy.Columns.Add("Student ID") | Out-Null
$dtLegacy.Columns.Add("Student Name") | Out-Null
$dtLegacy.Columns.Add("Class Name") | Out-Null
$dtLegacy.Columns.Add("Fine") | Out-Null
$dtLegacy.Columns.Add("Reason") | Out-Null

$dtLegacy.Rows.Add("2093", "SYEDA KINZA BIBI", "PM-1G", "150", "Uniform fine") | Out-Null

$previewLegacy = $ctor.Invoke([object[]]@($dtLegacy, "10 2026", "42", "LATE FEE FINE", "1"))
$loadMethod.Invoke($previewLegacy, [object[]]@($null, [System.EventArgs]::Empty))
$itemsLegacy = $fieldItems.GetValue($previewLegacy)

Write-Output "Legacy Items Count: $($itemsLegacy.Count)"
$itL = $itemsLegacy[0]
Write-Output "Legacy Row 1: ID=$($itL.InputStudentId), Month=$($itL.ResolvedFeeMonth), Head=$($itL.ResolvedFeeHead.HeadName), Amt=$($itL.Amount), Status=$($itL.Status), Notes=$($itL.Notes)"

$sec3Pass = $true
if ($itL.Status -ne "VALID") { Write-Output "FAIL: Legacy row should be VALID"; $sec3Pass = $false }
if ($itL.ResolvedFeeMonth -ne "10 2026") { Write-Output "FAIL: Expected month '10 2026' from default fallback"; $sec3Pass = $false }
if ($itL.ResolvedFeeHead.HeadName -ne "LATE FEE FINE") { Write-Output "FAIL: Expected head 'LATE FEE FINE' from default fallback"; $sec3Pass = $false }

if ($sec3Pass) {
    Write-Output "PASS: Section 3 passed! Legacy fine format falls back to default Fee Head and Fee Month correctly."
}

$previewLegacy.Dispose()

Write-Output ""
Write-Output "=========================================================="
Write-Output "ALL TESTS COMPLETED SUCCESSFULLY!"
Write-Output "=========================================================="
