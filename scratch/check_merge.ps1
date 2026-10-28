Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$ms1 = $mdi.Controls['menuStrip1']
Write-Output ("menuStrip1.AllowMerge default: " + $ms1.AllowMerge)
Write-Output ("mdi.MainMenuStrip: " + ($null -ne $mdi.MainMenuStrip))
if ($null -ne $mdi.MainMenuStrip) {
    Write-Output ("mdi.MainMenuStrip name: " + $mdi.MainMenuStrip.Name)
}
$msTop = $mdi.Controls['menuStrip']
Write-Output ("menuStrip (top) found: " + ($null -ne $msTop))
