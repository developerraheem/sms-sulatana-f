Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Sultana Foundation')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$mdi.StartPosition = [System.Windows.Forms.FormStartPosition]::CenterScreen
$mdi.Size = new-object System.Drawing.Size(1200, 700)

$timer = new-object System.Windows.Forms.Timer
$timer.Interval = 1000
$timer.Add_Tick({
    $timer.Stop()
    $bounds = $mdi.Bounds
    $bmp = new-object System.Drawing.Bitmap($bounds.Width, $bounds.Height)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.CopyFromScreen($bounds.Location, [System.Drawing.Point]::Empty, $bounds.Size)
    $bmp.Save("scratch\actual_run.png", [System.Drawing.Imaging.ImageFormat]::Png)
    $g.Dispose()
    $bmp.Dispose()
    $mdi.Close()
})
$timer.Start()

[System.Windows.Forms.Application]::Run($mdi)
