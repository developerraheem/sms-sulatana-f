Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))
$t = $asm.GetType('School.Fee_Summary_Reports.Head_student_wise_fee_param')
$f = [System.Activator]::CreateInstance($t)

$themeHelper = $asm.GetType('School.ThemeHelper')
if ($themeHelper -eq $null) { $themeHelper = $asm.GetType('ThemeHelper') }
$themeHelper.GetMethod('ApplyTheme', [System.Reflection.BindingFlags]'Public,Static').Invoke($null, @($f))

$pnlCard = $f.Controls['panelCard']
Write-Output ("PanelCard exists: " + ($pnlCard -ne $null))
if ($pnlCard -ne $null) {
    Write-Output ("PanelCard Size: " + $pnlCard.Size.Width + "x" + $pnlCard.Size.Height)
    Write-Output ("PanelCard Location: " + $pnlCard.Location.X + "," + $pnlCard.Location.Y)
    Write-Output "`nControls in panelCard:"
    foreach ($c in $pnlCard.Controls) {
        Write-Output ($c.Name.PadRight(18) + " | Type=" + $c.GetType().Name.PadRight(16) + " | Loc=(" + $c.Location.X + "," + $c.Location.Y + ")".PadRight(16) + " | Size=(" + $c.Size.Width + "," + $c.Size.Height + ")".PadRight(18) + " | Text=" + $c.Text)
    }
} else {
    Write-Output "`nControls in form:"
    foreach ($c in $f.Controls) {
        Write-Output ($c.Name.PadRight(18) + " | Loc=(" + $c.Location.X + "," + $c.Location.Y + ") | Text=" + $c.Text)
    }
}
