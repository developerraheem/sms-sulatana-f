$ErrorActionPreference = 'Stop'
$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;"

$coll = [System.Configuration.ConfigurationManager]::ConnectionStrings
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$bReadOnly = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", $flags)
if ($bReadOnly) { $bReadOnly.SetValue($coll, $false) }
$elem = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $connStr, "System.Data.SqlClient")
$coll.Add($elem)

$sys = $asm.GetType("SYSTEMSETTING")
$fieldBranch = $sys.GetField("branch_ID")
$fieldSession = $sys.GetField("sessionid")

$fieldBranch.SetValue($null, "6")
$fieldSession.SetValue($null, "68")

$frmMultiType = $asm.GetType("School._forms.Frm_generatefee_multi")
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::Public

$frm = [Activator]::CreateInstance($frmMultiType)

# Get form controls
$cmbClass = $frmMultiType.GetField("comboBox1", $flags).GetValue($frm)
$cmbShift = $frmMultiType.GetField("cmbshift", $flags).GetValue($frm)
$cmbSection = $frmMultiType.GetField("cmbsection", $flags).GetValue($frm)
$cmbSession = $frmMultiType.GetField("cmbselection", $flags).GetValue($frm)
$dgv = $frmMultiType.GetField("dgvStudents", $flags).GetValue($frm)

# Load form
$loadMethod = $frmMultiType.GetMethod("Frm_generatefee_Load", $flags)
$loadMethod.Invoke($frm, @($null, [EventArgs]::Empty))

Write-Host "Form loaded."
Write-Host "Classes count: $($cmbClass.Items.Count)"
Write-Host "Shifts count: $($cmbShift.Items.Count)"
Write-Host "Sections count: $($cmbSection.Items.Count)"
Write-Host "Sessions count: $($cmbSession.Items.Count)"

# Select DIT-29 (c_id = 122)
$cmbClass.SelectedValue = "122"
Write-Host "Selected Class Value: '$($cmbClass.SelectedValue)' Text: '$($cmbClass.Text)'"

# Select Morning
$cmbShift.SelectedValue = "Morning"
Write-Host "Selected Shift Value: '$($cmbShift.SelectedValue)' Text: '$($cmbShift.Text)'"

# Select Boys
$cmbSection.SelectedValue = "Boys"
Write-Host "Selected Section Value: '$($cmbSection.SelectedValue)' Text: '$($cmbSection.Text)'"

Write-Host "Selected Session Value: '$($cmbSession.SelectedValue)' Text: '$($cmbSession.Text)'"

# Check students
$selectedIds = $frm.SelectedStudentIds
Write-Host "SelectedStudentIds count: $($selectedIds.Count)"
foreach ($id in $selectedIds) {
    Write-Host "Student ID: $id"
}

# Now inspect what query btnproc_Click would execute:
$query = "Select * from student where c_id ='" + $cmbClass.SelectedValue.ToString() + "' and active='true' AND SHIFT ='" + $cmbShift.SelectedValue + "' and s_id in (" + [string]::Join(",", $selectedIds) + ") AND SessionID='" + $fieldSession.GetValue($null) + "' and branch_id='" + $fieldBranch.GetValue($null) + "' and SECTION_ID='" + $cmbSection.SelectedValue.ToString() + "'"
Write-Host "`nConstructed Query:"
Write-Host $query

# Test executing this query with SqlDataAdapter
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = New-Object System.Data.SqlClient.SqlCommand($query, $conn)
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
try {
    $da.Fill($ds, "student") | Out-Null
    Write-Host "Query Fill SUCCEEDED! Rows returned: $($ds.Tables['student'].Rows.Count)"
} catch {
    Write-Host "Query Fill FAILED: $($_.Exception.Message)"
}
$conn.Close()
