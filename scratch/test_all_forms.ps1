Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Sultana Foundation')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$mdi.ControlBox = $true
$mdi.MainMenuStrip = $null

$load = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$load.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))
$mdi.MainMenuStrip = $null

$formsToTest = @('School._forms.frmshift', 'School._forms.frm_student_promotions', 'School._forms.frmClass', 'School._forms.Frm_generatefee_multi')

foreach ($fName in $formsToTest) {
    $tF = $asm.GetType($fName)
    $f = [System.Activator]::CreateInstance($tF)
    $f.MdiParent = $mdi
    $f.Show()
    Write-Output "Tested $fName : Parent.Text='$($mdi.Text)', Parent.ControlBox=$($mdi.ControlBox), Child.WindowState=$($f.WindowState), Child.ControlBox=$($f.ControlBox)"
    $f.Close()
}
