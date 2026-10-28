Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))
$t = $asm.GetType('School.Fee_Summary_Reports.Head_student_wise_fee_param')
$f = [System.Activator]::CreateInstance($t)

$themeHelper = $asm.GetType('School.ThemeHelper')
$themeHelper.GetMethod('ApplyTheme', [System.Reflection.BindingFlags]'Public,Static').Invoke($null, @($f))

# Force create handle and layout
$f.CreateControl()
$f.Size = New-Object System.Drawing.Size(760, 440)

$bmp = New-Object System.Drawing.Bitmap($f.Width, $f.Height)
$f.DrawToBitmap($bmp, (New-Object System.Drawing.Rectangle(0, 0, $f.Width, $f.Height)))
$bmp.Save('scratch/head_student_wise_aligned.png', [System.Drawing.Imaging.ImageFormat]::Png)
$bmp.Dispose()
$f.Dispose()
Write-Output "Rendered to scratch/head_student_wise_aligned.png"
