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

$loadMethod = $tMdi.GetMethod('MDI_new_admin_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($mdi, @($mdi, [System.EventArgs]::Empty))

$ms = $mdi.Controls['menuStrip1']

function CheckSidebar($screenName) {
    $btnExit = $ms.Items['btnexit']
    $allVisible = $true
    Write-Output "[$screenName] - Sidebar Items Count: $($ms.Items.Count)"
    foreach ($item in $ms.Items) {
        if ($item.IsOnOverflow) { $allVisible = $false }
    }
    Write-Output "  Exit Button: Name=$($btnExit.Name), Text=$($btnExit.Text), Bounds=$($btnExit.Bounds), IsOnOverflow=$($btnExit.IsOnOverflow)"
    if ($btnExit.IsOnOverflow -or $btnExit.Bounds.X -gt 10) {
        Write-Output "  FAIL: Exit button is hidden or overflowing!"
    } else {
        Write-Output "  SUCCESS: Exit button is visible in sidebar."
    }
}

# 1. Dashboard
CheckSidebar "Dashboard"

# 2. Setup (frmClass)
$child = [System.Activator]::CreateInstance($asm.GetType('School._forms.frmClass'))
$child.MdiParent = $mdi
$child.Show()
CheckSidebar "Setup (frmClass)"
$child.Close()

# 3. Admissions (frm_manage_students - Maximized)
$child = [System.Activator]::CreateInstance($asm.GetType('School._forms.frm_manage_students'))
$child.MdiParent = $mdi
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized
$child.Show()
CheckSidebar "Admissions (frm_manage_students Maximized)"
$child.Close()

# 4. Fee (Frm_generatefee_multi - Maximized)
$child = [System.Activator]::CreateInstance($asm.GetType('School._forms.Frm_generatefee_multi'))
$child.MdiParent = $mdi
$child.WindowState = [System.Windows.Forms.FormWindowState]::Maximized
$child.Show()
CheckSidebar "Fee (Frm_generatefee_multi Maximized)"
$child.Close()

# 5. Attendance (frm_std_attend_manually)
$child = [System.Activator]::CreateInstance($asm.GetType('School.Attendance_module.frm_std_attend_manually'))
$child.MdiParent = $mdi
$child.Show()
CheckSidebar "Attendance (frm_std_attend_manually)"
$child.Close()

# 6. Academics (frmexam_compile_classwise)
$child = [System.Activator]::CreateInstance($asm.GetType('School._forms.frmexam_compile_classwise'))
$child.MdiParent = $mdi
$child.Show()
CheckSidebar "Academics (frmexam_compile_classwise)"
$child.Close()

# 7. Process (frmdeletevoucher)
$child = [System.Activator]::CreateInstance($asm.GetType('School._forms.frmdeletevoucher'))
$child.MdiParent = $mdi
$child.Show()
CheckSidebar "Process (frmdeletevoucher)"
$child.Close()

# 8. Reports (Head_student_wise_fee_param)
$child = [System.Activator]::CreateInstance($asm.GetType('School.Fee_Summary_Reports.Head_student_wise_fee_param'))
$child.MdiParent = $mdi
$child.Show()
CheckSidebar "Reports (Head_student_wise_fee_param)"
$child.Close()

$mdi.Dispose()
