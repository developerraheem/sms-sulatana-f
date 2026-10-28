$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$frmType = $asm.GetTypes() | Where-Object { $_.Name -eq "Frm_generatefee_multi" }
Write-Host "frmType: $($frmType.FullName)"

$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance

$methodLoad = $frmType.GetMethod("LoadBranchVoucherNote", $flags)
$methodSave = $frmType.GetMethod("SaveBranchVoucherNote", $flags)
$fieldTxtNotes = $frmType.GetField("txtnotes", $flags)

Write-Host "methodLoad: $($methodLoad.Name)"
Write-Host "methodSave: $($methodSave.Name)"
Write-Host "fieldTxtNotes: $($fieldTxtNotes.Name)"

$ctor = $frmType.GetConstructor([Type]::EmptyTypes)
$frm1 = $ctor.Invoke($null)

# Step 1: Open Branch 1
[SYSTEMSETTING]::branch_ID = "1"
$methodLoad.Invoke($frm1, @("1"))
$txt1 = $fieldTxtNotes.GetValue($frm1)
Write-Host "Initial Branch 1 remarks: '$($txt1.Text)'"

# Step 2: User enters Branch A Test Remark
$txt1.Text = "Branch A Test Remark"
$methodSave.Invoke($frm1, @("1", $txt1.Text))

# Step 3: Open Branch 2
[SYSTEMSETTING]::branch_ID = "2"
$frm2 = $ctor.Invoke($null)
$methodLoad.Invoke($frm2, @("2"))
$txt2 = $fieldTxtNotes.GetValue($frm2)
Write-Host "Initial Branch 2 remarks: '$($txt2.Text)'"

# Step 4: User enters Branch B Test Remark
$txt2.Text = "Branch B Test Remark"
$methodSave.Invoke($frm2, @("2", $txt2.Text))

# Step 5: Switch back to Branch 1
[SYSTEMSETTING]::branch_ID = "1"
$frm1_again = $ctor.Invoke($null)
$methodLoad.Invoke($frm1_again, @("1"))
$txt1_again = $fieldTxtNotes.GetValue($frm1_again)
Write-Host "Reloaded Branch 1 remarks: '$($txt1_again.Text)'"

# Step 6: Switch back to Branch 2
[SYSTEMSETTING]::branch_ID = "2"
$frm2_again = $ctor.Invoke($null)
$methodLoad.Invoke($frm2_again, @("2"))
$txt2_again = $fieldTxtNotes.GetValue($frm2_again)
Write-Host "Reloaded Branch 2 remarks: '$($txt2_again.Text)'"
