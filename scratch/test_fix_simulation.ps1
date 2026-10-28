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

# Apply the proposed settings:
$ms.AllowMerge = $false
$ms.CanOverflow = $false
if ($topMenu -ne $null) {
    $mdi.MainMenuStrip = $topMenu
}

$themeHelper = $asm.GetType('School.ThemeHelper')
$themeHelper.GetMethod('ApplyTheme', [System.Reflection.BindingFlags]'Public,Static').Invoke($null, @($mdi))

# Now let's test item layout
Write-Output "=== INITIAL STATE (Dashboard) ==="
Write-Output ("ms.AllowMerge: " + $ms.AllowMerge)
Write-Output ("ms.CanOverflow: " + $ms.CanOverflow)
Write-Output ("Items count: " + $ms.Items.Count)
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow)
}

# Open a child form: frm_manage_students
$tChild = $asm.GetType('School._forms.frm_manage_students')
$child = [System.Activator]::CreateInstance($tChild)
$child.MdiParent = $mdi
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized
$child.Show()

Write-Output "`n=== AFTER OPENING frm_manage_students (Maximized) ==="
Write-Output ("Items count: " + $ms.Items.Count)
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow)
}
