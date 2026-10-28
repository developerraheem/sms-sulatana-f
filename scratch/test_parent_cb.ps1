Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$parent = new-object System.Windows.Forms.Form
$parent.IsMdiContainer = $true
$parent.Size = new-object System.Drawing.Size(900, 600)
$parent.Text = "Parent MDI Window"
$parent.ControlBox = $true

$ms1 = new-object System.Windows.Forms.MenuStrip
$ms1.Dock = [System.Windows.Forms.DockStyle]::Left
$ms1.AllowMerge = $false
$parent.Controls.Add($ms1)

# MainMenuStrip is null!
$parent.MainMenuStrip = $null

$child = new-object System.Windows.Forms.Form
$child.Text = "Child Form"
$child.MdiParent = $parent
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized

$parent.Show()
$child.Show()
[System.Windows.Forms.Application]::DoEvents()

Write-Output "Parent Text: $($parent.Text)"
Write-Output "Parent ControlBox: $($parent.ControlBox)"
Write-Output "Child WindowState: $($child.WindowState)"
Write-Output "Child FormBorderStyle: $($child.FormBorderStyle)"
Write-Output "Child ControlBox: $($child.ControlBox)"
Write-Output "Child Bounds: $($child.Bounds)"

$parent.Close()
$parent.Dispose()
