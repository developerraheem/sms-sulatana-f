$ErrorActionPreference = 'Stop'
$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

# Set database to SCMS_SF_TEST for safe testing
$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;"
$coll = [System.Configuration.ConfigurationManager]::ConnectionStrings
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$bReadOnly = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", $flags)
if ($bReadOnly) { $bReadOnly.SetValue($coll, $false) }
$elem = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $connStr, "System.Data.SqlClient")
$coll.Add($elem)

# Simulate user logging in to Branch 6, Session 68
$sys = $asm.GetType("SYSTEMSETTING")
$sys.GetField("branch_ID").SetValue($null, "6")
$sys.GetField("sessionid").SetValue($null, "68")
$sys.GetField("sUserName").SetValue($null, "ADMIN")

# Open Frm_generatefee_multi
$frmMultiType = $asm.GetType("School._forms.Frm_generatefee_multi")
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::Public
$frm = [Activator]::CreateInstance($frmMultiType)

# Show form (invokes Load)
$frm.Show()

# Check what was selected initially
$cmbClass = $frmMultiType.GetField("comboBox1", $flags).GetValue($frm)
$cmbShift = $frmMultiType.GetField("cmbshift", $flags).GetValue($frm)
$cmbSection = $frmMultiType.GetField("cmbsection", $flags).GetValue($frm)
$cmbSession = $frmMultiType.GetField("cmbselection", $flags).GetValue($frm)
$btnproc = $frmMultiType.GetField("btnproc", $flags).GetValue($frm)

Write-Host "Initial Selected Class Value: '$($cmbClass.SelectedValue)' Text: '$($cmbClass.Text)'"
Write-Host "Initial Selected Shift Value: '$($cmbShift.SelectedValue)' Text: '$($cmbShift.Text)'"
Write-Host "Initial Selected Section Value: '$($cmbSection.SelectedValue)' Text: '$($cmbSection.Text)'"
Write-Host "Initial Selected Session Value: '$($cmbSession.SelectedValue)' Text: '$($cmbSession.Text)'"

# Now simulate selecting DIT-29
for ($i = 0; $i -lt $cmbClass.Items.Count; $i++) {
    $row = $cmbClass.Items[$i]
    if ($row["c_name"] -eq "DIT-29") {
        $cmbClass.SelectedIndex = $i
        break
    }
}

Write-Host "`nAfter selecting DIT-29:"
Write-Host "Selected Class Value: '$($cmbClass.SelectedValue)' Type: $($cmbClass.SelectedValue.GetType().FullName)"
Write-Host "Selected Shift Value: '$($cmbShift.SelectedValue)' Type: $($cmbShift.SelectedValue.GetType().FullName)"
Write-Host "Selected Section Value: '$($cmbSection.SelectedValue)' Type: $($cmbSection.SelectedValue.GetType().FullName)"
Write-Host "Selected Session Value: '$($cmbSession.SelectedValue)' Type: $($cmbSession.SelectedValue.GetType().FullName)"

# Check SelectedStudentIds
Write-Host "SelectedStudentIds: $([string]::Join(',', $frm.SelectedStudentIds))"

# Call btnproc_Click directly!
Write-Host "`nCalling btnproc_Click..."
$btnprocClick = $frmMultiType.GetMethod("btnproc_Click", $flags)
# Note: btnproc_Click shows a MessageBox("You Want to Generate Fee?").
# In an automated script, MessageBox.Show would block unless handled.
