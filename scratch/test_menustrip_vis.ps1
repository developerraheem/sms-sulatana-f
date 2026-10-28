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

$ms = $mdi.Controls['menuStrip']
Write-Output "Initial menuStrip.Visible: $($ms.Visible)"

# Let's see what happens if we set menuStrip.Visible = true
$ms.Visible = $true
Write-Output "After setting true, menuStrip.Visible: $($ms.Visible)"
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $item = $ms.Items[$i]
    Write-Output "  Item[$i]: Name=$($item.Name), Text=$($item.Text), Visible=$($item.Visible), Available=$($item.Available)"
}
