Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

function TestMdiMenu($menuVisible) {
    Write-Output "--- Testing MainMenuStrip with Visible = $menuVisible ---"
    $parent = new-object System.Windows.Forms.Form
    $parent.IsMdiContainer = $true
    $parent.Size = new-object System.Drawing.Size(800, 600)
    $parent.ControlBox = $false

    $ms = new-object System.Windows.Forms.MenuStrip
    $ms.Name = "menuStrip"
    $ms.Visible = $menuVisible
    $parent.Controls.Add($ms)
    $parent.MainMenuStrip = $ms

    $child = new-object System.Windows.Forms.Form
    $child.Text = "Child Form"
    $child.MdiParent = $parent
    $child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized

    $parent.Show()
    $child.Show()
    [System.Windows.Forms.Application]::DoEvents()

    Write-Output "MenuStrip.Visible: $($ms.Visible)"
    Write-Output "MenuStrip.Items.Count: $($ms.Items.Count)"
    foreach ($item in $ms.Items) {
        Write-Output "  Item: $($item.GetType().Name) | Text='$($item.Text)' | Visible=$($item.Visible) | Bounds=$($item.Bounds)"
    }

    $parent.Close()
    $parent.Dispose()
}

TestMdiMenu $true
TestMdiMenu $false
