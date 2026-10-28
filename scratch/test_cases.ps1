Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Sultana Foundation')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')

Write-Output "Case A: Current state"
$m1 = [System.Activator]::CreateInstance($tMdi)
$load = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$load.Invoke($m1, @($m1, [System.EventArgs]::Empty))
Write-Output "  ControlBox=$($m1.ControlBox), MainMenuStrip.Visible=$($m1.MainMenuStrip.Visible)"

Write-Output "`nCase B: ControlBox = true"
$m1.ControlBox = $true
Write-Output "  ControlBox=$($m1.ControlBox), MinimizeBox=$($m1.MinimizeBox), MaximizeBox=$($m1.MaximizeBox)"

Write-Output "`nCase C: menuStrip.Visible = true"
$m1.Controls['menuStrip'].Visible = $true
Write-Output "  menuStrip.Visible=$($m1.Controls['menuStrip'].Visible)"
