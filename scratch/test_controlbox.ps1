Add-Type -AssemblyName System.Windows.Forms

$f1 = new-object System.Windows.Forms.Form
$f1.Text = "Form With ControlBox True"
$f1.ControlBox = $true
$f1.WindowState = [System.Windows.Forms.FormWindowState]::Maximized

$f2 = new-object System.Windows.Forms.Form
$f2.Text = "Form With ControlBox False"
$f2.ControlBox = $false
$f2.WindowState = [System.Windows.Forms.FormWindowState]::Maximized

Write-Output "f1 ControlBox: $($f1.ControlBox), MinimizeBox: $($f1.MinimizeBox), MaximizeBox: $($f1.MaximizeBox)"
Write-Output "f2 ControlBox: $($f2.ControlBox), MinimizeBox: $($f2.MinimizeBox), MaximizeBox: $($f2.MaximizeBox)"

# In Win32, when ControlBox is false, the window style WS_SYSMENU is removed from the window styles!
# When WS_SYSMENU is removed, Windows does NOT display the Minimize, Maximize, and Close buttons on the title bar at all!
