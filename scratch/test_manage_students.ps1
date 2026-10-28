Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$mdi.Size = new-object System.Drawing.Size(1024, 768)

# Trigger Load
$loadMethod = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))

$ms = $mdi.Controls['menuStrip1']
Write-Output "--- AFTER LOAD (Dashboard active) ---"
Write-Output ("Items count: " + $ms.Items.Count)
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow + " | Type=" + $it.GetType().Name)
}

# Now open frm_manage_students (which has WindowState = Maximized)
$tChild = $asm.GetType('School._forms.frm_manage_students')
$child = [System.Activator]::CreateInstance($tChild)
$child.MdiParent = $mdi
$child.Show()

Write-Output "`n--- AFTER OPENING frm_manage_students (Maximized) ---"
Write-Output ("Items count: " + $ms.Items.Count)
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow + " | Type=" + $it.GetType().Name)
}
