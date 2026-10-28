$asmPath = (Resolve-Path "bin\Debug\School.exe").Path
[System.Reflection.Assembly]::LoadFrom($asmPath) | Out-Null

# Temporarily point connection to SCMS_SF_TEST via ConfigurationManager
$field = [SYSTEMSETTING].Assembly.GetType("SYSTEMSETTING")
[SYSTEMSETTING]::branch_ID = "6"
[SYSTEMSETTING]::sessionid = "68"
[SYSTEMSETTING]::schoolname = "INFORMATION TECHNOLOGY & SKILLS INSTITUTE"

$form = New-Object School._forms.Frm_generatefee_multi

# Get private fields
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$cmbClass = $form.GetType().GetField("comboBox1", $flags).GetValue($form)
$cmbShift = $form.GetType().GetField("cmbshift", $flags).GetValue($form)
$cmbSection = $form.GetType().GetField("cmbsection", $flags).GetValue($form)
$cmbSession = $form.GetType().GetField("cmbselection", $flags).GetValue($form)

# Call Frm_generatefee_Load
$loadMethod = $form.GetType().GetMethod("Frm_generatefee_Load", $flags)
$loadMethod.Invoke($form, @($null, [System.EventArgs]::Empty))

Write-Host "After Form_Load:"
Write-Host "  cmbClass Items count: $($cmbClass.Items.Count)"
Write-Host "  cmbClass SelectedValue: '$($cmbClass.SelectedValue)'"
Write-Host "  cmbShift SelectedValue: '$($cmbShift.SelectedValue)'"
Write-Host "  cmbSection SelectedValue: '$($cmbSection.SelectedValue)'"
Write-Host "  cmbSession SelectedValue: '$($cmbSession.SelectedValue)'"
Write-Host "  SYSTEMSETTING.branch_ID: '$([SYSTEMSETTING]::branch_ID)'"
Write-Host "  SYSTEMSETTING.sessionid: '$([SYSTEMSETTING]::sessionid)'"

# Find DIT-29 in cmbClass
for ($i = 0; $i -lt $cmbClass.Items.Count; $i++) {
    $item = $cmbClass.Items[$i]
    if ($item["c_name"] -eq "DIT-29") {
        $cmbClass.SelectedIndex = $i
        break
    }
}

Write-Host "After selecting DIT-29:"
Write-Host "  cmbClass SelectedIndex: $($cmbClass.SelectedIndex)"
Write-Host "  cmbClass SelectedValue: '$($cmbClass.SelectedValue)' (Type: $($cmbClass.SelectedValue.GetType().FullName))"
Write-Host "  cmbShift SelectedValue: '$($cmbShift.SelectedValue)' (Type: $($cmbShift.SelectedValue.GetType().FullName))"
Write-Host "  cmbSection SelectedValue: '$($cmbSection.SelectedValue)' (Type: $($cmbSection.SelectedValue.GetType().FullName))"
Write-Host "  cmbSession SelectedValue: '$($cmbSession.SelectedValue)' (Type: $($cmbSession.SelectedValue.GetType().FullName))"

# Check SelectedStudentIds
Write-Host "  SelectedStudentIds count: $($form.SelectedStudentIds.Count)"
foreach ($sid in $form.SelectedStudentIds) {
    Write-Host "    Student ID: '$sid'"
}

# Construct the query exactly as btnproc_Click does:
$checkBox1 = $form.GetType().GetField("checkBox1", $flags).GetValue($form)
$txtstudentid = $form.GetType().GetField("txtstudentid", $flags).GetValue($form)
$SelectedStudentIds = $form.SelectedStudentIds

$query = ""
if ($checkBox1.Checked -eq $true) {
    $query = "Select * from student where c_id ='" + $cmbClass.SelectedValue.ToString() + "' and active='true' AND SHIFT ='" + $cmbShift.SelectedValue + "' and s_id='" + $txtstudentid.Text + "' AND SessionID='" + [SYSTEMSETTING]::sessionid + "' and branch_id='" + [SYSTEMSETTING]::branch_ID + "' and SECTION_ID='" + $cmbSection.SelectedValue.ToString() + "'"
} elseif ($SelectedStudentIds -ne $null) {
    $idList = [string]::Join(",", $SelectedStudentIds.ToArray())
    $query = "Select * from student where c_id ='" + $cmbClass.SelectedValue.ToString() + "' and active='true' AND SHIFT ='" + $cmbShift.SelectedValue + "' and s_id in (" + $idList + ") AND SessionID='" + [SYSTEMSETTING]::sessionid + "' and branch_id='" + [SYSTEMSETTING]::branch_ID + "' and SECTION_ID='" + $cmbSection.SelectedValue.ToString() + "'"
} else {
    $query = "Select * from student where c_id ='" + $cmbClass.SelectedValue.ToString() + "' and active='true' AND SHIFT ='" + $cmbShift.SelectedValue + "' AND SessionID='" + [SYSTEMSETTING]::sessionid + "'  and branch_id='" + [SYSTEMSETTING]::branch_ID + "' and SECTION_ID='" + $cmbSection.SelectedValue.ToString() + "'"
}

Write-Host "CONSTRUCTED QUERY:"
Write-Host $query

$form.Dispose()
