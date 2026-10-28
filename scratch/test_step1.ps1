$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path "bin\Debug\School.exe"))
Write-Host "Assembly loaded successfully: $($asm.FullName)"
$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)
Write-Host "Form created successfully: $($form.GetType().FullName)"
$form.Dispose()
Write-Host "Form disposed"
