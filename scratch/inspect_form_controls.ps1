Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Test School')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$mdi.Size = new-object System.Drawing.Size(1200, 700)

$loadMethod = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))

Write-Output "MDI MainMenuStrip: $($mdi.MainMenuStrip.Name)"
Write-Output "MDI MainMenuStrip.Visible: $($mdi.MainMenuStrip.Visible)"
Write-Output "MDI menuStrip.Visible: $($mdi.Controls['menuStrip'].Visible)"
Write-Output "MDI ControlBox: $($mdi.ControlBox)"

$tChild = $asm.GetType('School._forms.frmshift')
$child = [System.Activator]::CreateInstance($tChild)
$child.MdiParent = $mdi
$child.Show()

Write-Output "`n--- CHILD FORM DETAILS ---"
Write-Output "Child Form: $($child.Name), Text=$($child.Text)"
Write-Output "Child WindowState: $($child.WindowState)"
Write-Output "Child FormBorderStyle: $($child.FormBorderStyle)"
Write-Output "Child ControlBox: $($child.ControlBox)"
Write-Output "Child MaximizeBox: $($child.MaximizeBox)"
Write-Output "Child MinimizeBox: $($child.MinimizeBox)"
Write-Output "Child Visible: $($child.Visible)"
Write-Output "Child Bounds: $($child.Bounds)"

# Check if child is maximized or normal
# When maximized:
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized
Write-Output "`n--- AFTER MAXIMIZING CHILD ---"
Write-Output "MDI MainMenuStrip: $($mdi.MainMenuStrip.Name), Visible: $($mdi.MainMenuStrip.Visible)"
Write-Output "MDI MainMenuStrip Items count: $($mdi.MainMenuStrip.Items.Count)"
for ($i = 0; $i -lt $mdi.MainMenuStrip.Items.Count; $i++) {
    $item = $mdi.MainMenuStrip.Items[$i]
    Write-Output "  Item[$i]: Name=$($item.Name), Text=$($item.Text), Visible=$($item.Visible), Type=$($item.GetType().Name), Bounds=$($item.Bounds)"
}
