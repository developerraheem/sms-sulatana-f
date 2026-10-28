Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Sultana Foundation')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')

Write-Output "--- EXPERIMENT 1: ControlBox = true, MainMenuStrip = null, menuStrip1.AllowMerge = false ---"
$m1 = [System.Activator]::CreateInstance($tMdi)
$m1.ControlBox = $true
$m1.MainMenuStrip = $null
$load = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$load.Invoke($m1, @($m1, [System.EventArgs]::Empty))
$m1.MainMenuStrip = $null # ensure null

$tChild = $asm.GetType('School._forms.frm_student_promotions')
$c1 = [System.Activator]::CreateInstance($tChild)
$c1.MdiParent = $m1
$c1.Show()

Write-Output "m1.Text: $($m1.Text)"
Write-Output "m1.ControlBox: $($m1.ControlBox)"
Write-Output "c1.WindowState: $($c1.WindowState)"
Write-Output "c1.ControlBox: $($c1.ControlBox)"
Write-Output "c1.Text: $($c1.Text)"

$ms1 = $m1.Controls['menuStrip1']
Write-Output "menuStrip1.Items.Count: $($ms1.Items.Count)"
Write-Output "Last item in sidebar: $($ms1.Items[$ms1.Items.Count - 1].Text)"

Write-Output "`n--- EXPERIMENT 2: ControlBox = true, MainMenuStrip = menuStrip (Visible = false) ---"
$m2 = [System.Activator]::CreateInstance($tMdi)
$m2.ControlBox = $true
$load.Invoke($m2, @($m2, [System.EventArgs]::Empty))

$c2 = [System.Activator]::CreateInstance($tChild)
$c2.MdiParent = $m2
$c2.Show()

Write-Output "m2.Text: $($m2.Text)"
Write-Output "m2.ControlBox: $($m2.ControlBox)"
Write-Output "c2.WindowState: $($c2.WindowState)"
Write-Output "c2.ControlBox: $($c2.ControlBox)"
Write-Output "c2.Text: $($c2.Text)"
