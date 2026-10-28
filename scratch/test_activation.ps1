Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Sultana Foundation')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$load = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$load.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))

Write-Output "Initial MDI children count: $($mdi.MdiChildren.Length)"
Write-Output "Initial ActiveMdiChild: $($mdi.ActiveMdiChild)"
foreach ($ch in $mdi.MdiChildren) {
    Write-Output "  Child: $($ch.GetType().Name) | Visible=$($ch.Visible) | WindowState=$($ch.WindowState) | Dock=$($ch.Dock)"
}

$ms = $mdi.Controls['menuStrip']
Write-Output "Initial menuStrip.Visible: $($ms.Visible)"

# Now simulate opening a tab/form: frm_student_promotions
$tProm = $asm.GetType('School._forms.frm_student_promotions')
$prom = [System.Activator]::CreateInstance($tProm)
$prom.MdiParent = $mdi
$prom.Show()

Write-Output "`nAfter opening frm_student_promotions:"
Write-Output "MDI children count: $($mdi.MdiChildren.Length)"
Write-Output "ActiveMdiChild: $($mdi.ActiveMdiChild.GetType().Name)"

# If we set menuStrip.Visible = true:
$ms.Visible = $true
Write-Output "menuStrip.Items count: $($ms.Items.Count)"
foreach ($item in $ms.Items) {
    Write-Output "  Item: $($item.GetType().Name) | Text='$($item.Text)' | Available=$($item.Available)"
}
