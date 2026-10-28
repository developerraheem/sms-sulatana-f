Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Test School')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')

Write-Output "=== TEST 1: Current code (menuStrip.Visible = false, MainMenuStrip = menuStrip) ==="
$mdi1 = [System.Activator]::CreateInstance($tMdi)
$loadMethod = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($mdi1, @($mdi1, [System.EventArgs]::Empty))

# Open child
$child1 = [System.Activator]::CreateInstance($asm.GetType('School._forms.frm_student_promotions'))
$child1.MdiParent = $mdi1
$child1.Show()
Write-Output "Child WindowState: $($child1.WindowState)"
Write-Output "Child ControlBox: $($child1.ControlBox)"
Write-Output "MDI MainMenuStrip.Visible: $($mdi1.MainMenuStrip.Visible)"

Write-Output "`n=== TEST 2: If menuStrip.Visible = true ==="
$mdi2 = [System.Activator]::CreateInstance($tMdi)
$loadMethod.Invoke($mdi2, @($mdi2, [System.EventArgs]::Empty))
$mdi2.Controls['menuStrip'].Visible = $true
$child2 = [System.Activator]::CreateInstance($asm.GetType('School._forms.frm_student_promotions'))
$child2.MdiParent = $mdi2
$child2.Show()
Write-Output "Child WindowState: $($child2.WindowState)"
Write-Output "MDI menuStrip.Visible: $($mdi2.Controls['menuStrip'].Visible)"
Write-Output "MDI menuStrip Items Count: $($mdi2.Controls['menuStrip'].Items.Count)"
for ($i = 0; $i -lt $mdi2.Controls['menuStrip'].Items.Count; $i++) {
    $it = $mdi2.Controls['menuStrip'].Items[$i]
    Write-Output "  Item[$i]: $($it.GetType().Name) | Text='$($it.Text)' | Visible=$($it.Visible)"
}

Write-Output "`n=== TEST 3: If child WindowState = Normal (not Maximized) ==="
$mdi3 = [System.Activator]::CreateInstance($tMdi)
$loadMethod.Invoke($mdi3, @($mdi3, [System.EventArgs]::Empty))
$child3 = [System.Activator]::CreateInstance($asm.GetType('School._forms.frmshift'))
$child3.MdiParent = $mdi3
$child3.Show()
Write-Output "Child Form: $($child3.Name) WindowState: $($child3.WindowState) FormBorderStyle: $($child3.FormBorderStyle)"
