Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Sultana Foundation')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

function CaptureForm($controlBoxValue, $mainMenuValue, $menuVisValue, $fileName) {
    $tMdi = $asm.GetType('School._forms.MDI_new_admin')
    $mdi = [System.Activator]::CreateInstance($tMdi)
    $mdi.ControlBox = $controlBoxValue
    $mdi.Size = new-object System.Drawing.Size(1100, 650)
    $mdi.StartPosition = [System.Windows.Forms.FormStartPosition]::CenterScreen

    $loadMethod = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
    $loadMethod.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))

    if ($null -ne $mainMenuValue) {
        if ($mainMenuValue -eq "null") {
            $mdi.MainMenuStrip = $null
        } else {
            $mdi.MainMenuStrip = $mdi.Controls[$mainMenuValue]
        }
    }
    if ($null -ne $menuVisValue) {
        $mdi.Controls['menuStrip'].Visible = $menuVisValue
    }

    # Open child: frm_student_promotions
    $tChild = $asm.GetType('School._forms.frm_student_promotions')
    $child = [System.Activator]::CreateInstance($tChild)
    $child.MdiParent = $mdi
    $child.Show()

    # Create handle & render
    $mdi.Show()
    [System.Windows.Forms.Application]::DoEvents()

    $bmp = new-object System.Drawing.Bitmap($mdi.Width, $mdi.Height)
    $mdi.DrawToBitmap($bmp, (new-object System.Drawing.Rectangle(0, 0, $mdi.Width, $mdi.Height)))
    $bmp.Save("scratch\$fileName", [System.Drawing.Imaging.ImageFormat]::Png)
    $bmp.Dispose()
    $child.Close()
    $mdi.Close()
    $mdi.Dispose()
    Write-Output "Saved scratch\$fileName"
}

CaptureForm $false $null $false "test_current.png"
CaptureForm $true $null $false "test_controlbox_true.png"
CaptureForm $false "menuStrip" $true "test_menustrip_true.png"
