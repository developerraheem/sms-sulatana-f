Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Test School')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
# Test on compact 530px window height
$mdi.Size = new-object System.Drawing.Size(1024, 530)

$loadMethod = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))

$ms = $mdi.Controls['menuStrip1']

function CheckSidebar($screenName) {
    $btnExit = $ms.Items['btnexit']
    Write-Output "[$screenName] - Total Items: $($ms.Items.Count)"
    Write-Output "  Exit Button: Bounds=$($btnExit.Bounds), IsOnOverflow=$($btnExit.IsOnOverflow)"
    if ($btnExit.IsOnOverflow -or $btnExit.Bounds.X -gt 10) {
        Write-Output "  FAIL: Exit button is hidden or overflowing!"
    } else {
        Write-Output "  SUCCESS: Exit button is visible in sidebar at X=$($btnExit.Bounds.X), Y=$($btnExit.Bounds.Y)."
    }
}

CheckSidebar "Compact Height (530px) - Dashboard"

$child = [System.Activator]::CreateInstance($asm.GetType('School._forms.frmClass'))
$child.MdiParent = $mdi
$child.Show()
CheckSidebar "Compact Height (530px) - Child Active"

$mdi.Dispose()
