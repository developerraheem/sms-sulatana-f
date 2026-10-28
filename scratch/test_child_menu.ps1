Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$mdi.Size = new-object System.Drawing.Size(1024, 600)
$mdi.WindowState = [System.Windows.Forms.FormWindowState]::Normal

# Trigger Load
$loadMethod = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))

Write-Output "--- AFTER LOAD (Dashboard active) ---"
$ms = $mdi.Controls['menuStrip1']
Write-Output ("MenuStrip bounds: " + $ms.Bounds.ToString())
Write-Output ("Items count: " + $ms.Items.Count)
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow + " | Type=" + $it.GetType().Name)
}

# Now open a child form: e.g. Head_student_wise_fee_param or frmClass
$tChild = $asm.GetType('School.Fee_Summary_Reports.Head_student_wise_fee_param')
if ($tChild -eq $null) { $tChild = $asm.GetType('School._forms.frmClass') }
$child = [System.Activator]::CreateInstance($tChild)
$child.MdiParent = $mdi
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized
$child.Show()

Write-Output "`n--- AFTER OPENING CHILD (Maximized) ---"
Write-Output ("MenuStrip bounds: " + $ms.Bounds.ToString())
Write-Output ("Items count: " + $ms.Items.Count)
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow + " | Type=" + $it.GetType().Name)
}

# Now what if child is NOT maximized?
$child.WindowState = [System.Windows.Forms.FormWindowState]::Normal
Write-Output "`n--- AFTER CHILD NORMAL ---"
Write-Output ("Items count: " + $ms.Items.Count)
for ($i = 0; $i -lt $ms.Items.Count; $i++) {
    $it = $ms.Items[$i]
    Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | IsOnOverflow=" + $it.IsOnOverflow + " | Type=" + $it.GetType().Name)
}
