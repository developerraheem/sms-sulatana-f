Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))
$tSys = $asm.GetType('School.SYSTEMSETTING')
$tSys.GetField('schoolname', [System.Reflection.BindingFlags]'Public,Static').SetValue($null, 'Test School')
$tSys.GetField('sUserName', [System.Reflection.BindingFlags]'Public,Static').SetValue($null, 'Admin')
$tSys.GetField('sessionname', [System.Reflection.BindingFlags]'Public,Static').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)

$themeHelper = $asm.GetType('School.ThemeHelper')
$themeHelper.GetMethod('ApplyTheme', [System.Reflection.BindingFlags]'Public,Static').Invoke($null, @($mdi))

$ms = $mdi.Controls['menuStrip1']
Write-Output ("MenuStrip1 found: " + ($ms -ne $null))
if ($ms -ne $null) {
    Write-Output ("MenuStrip size: " + $ms.Size.Width + "x" + $ms.Size.Height)
    Write-Output ("Items count: " + $ms.Items.Count)
    foreach ($item in $ms.Items) {
        Write-Output ("Item: " + $item.Name.PadRight(25) + " Text: " + $item.Text.PadRight(15) + " Size: " + $item.Size.Width + "x" + $item.Size.Height + " Bounds: " + $item.Bounds.ToString() + " Visible: " + $item.Visible + " Available: " + $item.Available + " IsOnOverflow: " + $item.IsOnOverflow)
    }
}
