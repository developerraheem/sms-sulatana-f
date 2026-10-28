Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Test School')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$mdi.Size = new-object System.Drawing.Size(1024, 600)

$ms = $mdi.Controls['menuStrip1']
$topMenu = $mdi.Controls['menuStrip']
$ms.AllowMerge = $false
$ms.CanOverflow = $false
if ($topMenu -ne $null) { $mdi.MainMenuStrip = $topMenu }

# Apply sizing formula:
$availH = $mdi.ClientSize.Height - 24 - 8
$totalCount = 9
$slotH = [int]($availH / $totalCount)
$marginV = if ($slotH -lt 60) { 1 } else { 2 }
$itemH = [Math]::Min(70, [Math]::Max(42, ($slotH - ($marginV * 2))))

foreach ($item in $ms.Items) {
    $item.AutoSize = $false
    $item.Size = new-object System.Drawing.Size(118, $itemH)
    $item.Margin = new-object System.Windows.Forms.Padding(3, $marginV, 3, $marginV)
}

# Open a child form: frm_manage_students (Maximized)
$tChild = $asm.GetType('School._forms.frm_manage_students')
$child = [System.Activator]::CreateInstance($tChild)
$child.MdiParent = $mdi
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized
$child.Show()

# Force layout
$ms.PerformLayout()

Write-Output "=== ITEMS BOUNDS WITH MAXIMIZED CHILD ==="
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name.PadRight(25) + " | Text=" + $it.Text.PadRight(12) + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow)
}
