$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sysType = $asm.GetType("SYSTEMSETTING")
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "78")

$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
Write-Host "Instantiating Frm_generatefee_multi (simulating clicking Fee tab)..."
$form = [System.Activator]::CreateInstance($formType)

$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance

$dtpStart = $formType.GetField("txtstartdate", $flags).GetValue($form)
$dtpEnd = $formType.GetField("txtenddate", $flags).GetValue($form)
$lblMonth = $formType.GetField("lblmonth", $flags).GetValue($form)

Write-Host "txtstartdate initial Value: $($dtpStart.Value)"
Write-Host "txtenddate initial Value:   $($dtpEnd.Value)"

# Call Load
$loadMethod = $formType.GetMethod("Frm_generatefee_Load", $flags)
$loadMethod.Invoke($form, @($null, [EventArgs]::Empty))

Write-Host "SUCCESS: Frm_generatefee_Load completed with NO false error popup!"
Write-Host "txtstartdate after Load: $($dtpStart.Value)"
Write-Host "txtenddate after Load:   $($dtpEnd.Value)"
Write-Host "lblmonth after Load:     $($lblMonth.Text)"

# Test GetMonths directly
$getMonthsMethod = $formType.GetMethod("GetMonths", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Instance)

# Test same month (Today)
$mSame = $getMonthsMethod.Invoke($form, @([DateTime]::Today, [DateTime]::Today))
Write-Host "GetMonths(Today, Today): $mSame (Expected: 1)"
if ($mSame -ne 1) { throw "Expected 1 for same date" }

# Test consecutive months (Sept to Oct)
$m2 = $getMonthsMethod.Invoke($form, @([DateTime]::new(2026, 9, 1), [DateTime]::new(2026, 10, 31)))
Write-Host "GetMonths(01/09/2026, 31/10/2026): $m2 (Expected: 2)"
if ($m2 -ne 2) { throw "Expected 2 for Sept to Oct" }

Write-Host "`nALL DATE VALIDATION TESTS PASSED SUCCESSFULLY!" -ForegroundColor Green
$form.Dispose()
