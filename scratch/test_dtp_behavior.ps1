$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)
$form.CreateControl()

$startDate = $formType.GetField("txtstartdate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$endDate = $formType.GetField("txtenddate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$dateFrom = $formType.GetField("txtdatefrom", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$dateTo = $formType.GetField("txtdateto", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$lblMonth = $formType.GetField("lblmonth", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)

Write-Host "Initial with handle:"
Write-Host "txtstartdate: Value=$($startDate.Value), Text='$($startDate.Text)'"
Write-Host "txtenddate:   Value=$($endDate.Value), Text='$($endDate.Text)'"
Write-Host "txtdatefrom:  Value=$($dateFrom.Value), Text='$($dateFrom.Text)'"
Write-Host "txtdateto:    Value=$($dateTo.Value), Text='$($dateTo.Text)'"
Write-Host "lblmonth:     Text='$($lblMonth.Text)'"

Write-Host "`nSetting txtstartdate to 2026-09-01 and txtenddate to 2026-10-31..."
$startDate.Value = [DateTime]::new(2026, 9, 1)
$endDate.Value = [DateTime]::new(2026, 10, 31)

Write-Host "After setting Value:"
Write-Host "txtstartdate: Value=$($startDate.Value), Text='$($startDate.Text)'"
Write-Host "txtenddate:   Value=$($endDate.Value), Text='$($endDate.Text)'"
Write-Host "txtdatefrom:  Value=$($dateFrom.Value), Text='$($dateFrom.Text)'"
Write-Host "txtdateto:    Value=$($dateTo.Value), Text='$($dateTo.Text)'"
Write-Host "lblmonth:     Text='$($lblMonth.Text)'"

$form.Dispose()
