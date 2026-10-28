Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))

$tSys = $asm.GetType('SYSTEMSETTING')
$tSys.GetField('schoolname').SetValue($null, 'Test School')
$tSys.GetField('sUserName').SetValue($null, 'Admin')
$tSys.GetField('sessionname').SetValue($null, '2025-2026')

$tMdi = $asm.GetType('School._forms.MDI_new_admin')
$mdi = [System.Activator]::CreateInstance($tMdi)
$mdi.Size = new-object System.Drawing.Size(1200, 700)

$ms = $mdi.Controls['menuStrip1']

$timer = new-object System.Windows.Forms.Timer
$timer.Interval = 500
$step = 0
$timer.Add_Tick({
    $script:step++
    if ($script:step -eq 1) {
        Write-Output "=== STEP 1: Dashboard Loaded ==="
        Write-Output ("Items count: " + $ms.Items.Count)
        for ($i = 0; $i -lt $ms.Items.Count; $i++) {
            $it = $ms.Items[$i]
            Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | Type=" + $it.GetType().Name)
        }
        
        # Open child
        $tChild = $asm.GetType('School.Fee_Summary_Reports.Head_student_wise_fee_param')
        $child = [System.Activator]::CreateInstance($tChild)
        $child.MdiParent = $mdi
        $child.Show()
    }
    elseif ($script:step -eq 2) {
        Write-Output "`n=== STEP 2: Child Form Opened ==="
        Write-Output ("Items count: " + $ms.Items.Count)
        for ($i = 0; $i -lt $ms.Items.Count; $i++) {
            $it = $ms.Items[$i]
            Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | Type=" + $it.GetType().Name)
        }
        
        # Maximize child
        if ($mdi.ActiveMdiChild -ne $null) {
            $mdi.ActiveMdiChild.WindowState = [System.Windows.Forms.FormWindowState]::Maximized
        }
    }
    elseif ($script:step -eq 3) {
        Write-Output "`n=== STEP 3: Child Form Maximized ==="
        Write-Output ("Items count: " + $ms.Items.Count)
        for ($i = 0; $i -lt $ms.Items.Count; $i++) {
            $it = $ms.Items[$i]
            Write-Output ("  [$i] " + $it.Name + " | Text=" + $it.Text + " | Visible=" + $it.Visible + " | Bounds=" + $it.Bounds.ToString() + " | Type=" + $it.GetType().Name)
        }
        $timer.Stop()
        $mdi.Close()
    }
})

$timer.Start()
[System.Windows.Forms.Application]::Run($mdi)
