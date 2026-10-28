$asmPath = (Resolve-Path "bin\Debug\School.exe").Path
[System.Reflection.Assembly]::LoadFrom($asmPath) | Out-Null

[SYSTEMSETTING]::branch_ID = "6"
[SYSTEMSETTING]::sessionid = "68"
[SYSTEMSETTING]::schoolname = "INFORMATION TECHNOLOGY & SKILLS INSTITUTE"

$form = New-Object School._forms.Frm_generatefee_multi

# Trigger Load
$loadMethod = $form.GetType().GetMethod("Frm_generatefee_Load", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadMethod.Invoke($form, @($null, [System.EventArgs]::Empty))

Write-Host "cmbshift.SelectedValue: '$($form.cmbshift.SelectedValue)'"
Write-Host "cmbsection.SelectedValue: '$($form.cmbsection.SelectedValue)'"
Write-Host "cmbselection.SelectedValue: '$($form.cmbselection.SelectedValue)'"
Write-Host "comboBox1.SelectedValue: '$($form.comboBox1.SelectedValue)'"

# Select DIT-29
$form.comboBox1.SelectedValue = 122
Write-Host "After setting comboBox1.SelectedValue = 122:"
Write-Host "comboBox1.SelectedValue: '$($form.comboBox1.SelectedValue)'"
Write-Host "SelectedStudentIds count: $($form.SelectedStudentIds.Count)"
foreach ($id in $form.SelectedStudentIds) {
    Write-Host "  SelectedStudentId: '$id'"
}

$form.Dispose()
