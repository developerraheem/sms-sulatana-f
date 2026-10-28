Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$parent = new-object System.Windows.Forms.Form
$parent.IsMdiContainer = $true
$parent.Size = new-object System.Drawing.Size(900, 600)
$parent.Text = "Parent MDI Window"
$parent.ControlBox = $true
$parent.MainMenuStrip = $null

$child = new-object System.Windows.Forms.Form
$child.Text = "Child Form"
$child.MdiParent = $parent
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized

$parent.Show()
$child.Show()
[System.Windows.Forms.Application]::DoEvents()

# Send WM_SYSCOMMAND SC_CLOSE to parent:
# 0x0112 is WM_SYSCOMMAND, 0xF060 is SC_CLOSE
Write-Output "Before close: Parent.Visible=$($parent.Visible), Child.Visible=$($child.Visible), MdiChildren count=$($parent.MdiChildren.Length)"

# When MainMenuStrip is null, does closing close the child or parent?
# In Win32 MDI: if a child is maximized without MenuStrip:
# SC_CLOSE sent to MDI client or active child closes the child, but SC_CLOSE sent to parent title bar closes the PARENT!
