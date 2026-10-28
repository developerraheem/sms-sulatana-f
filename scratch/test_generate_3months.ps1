Add-Type -AssemblyName System.Data
Add-Type -AssemblyName System.Windows.Forms

# Load School.exe
$asmPath = Resolve-Path "bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($asmPath)
$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$sysType = $asm.GetType("SYSTEMSETTING")

# Set static fields
$sysType.GetField("branch_ID", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static).SetValue($null, "6")
$sysType.GetField("sessionid", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static).SetValue($null, "68")

# Clean up vouchers for student 88888
$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '88888')"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE s_id = '88888'"
$cmd.ExecuteNonQuery() | Out-Null

# Initialize form
$form = [System.Activator]::CreateInstance($formType)

# Get controls
$txtStartDate = $form.GetType().GetField("txtstartdate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtEndDate = $form.GetType().GetField("txtenddate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtIssueDate = $form.GetType().GetField("txtissuedate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtDueDate = $form.GetType().GetField("txtduedate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$cmbClass = $form.GetType().GetField("comboBox1", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$chkSingle = $form.GetType().GetField("checkBox1", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtStudentId = $form.GetType().GetField("txtstudentid", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)

# Populate class combo
$dtClass = New-Object System.Data.DataTable
$null = $dtClass.Columns.Add("c_id", [int])
$null = $dtClass.Columns.Add("c_name", [string])
$row = $dtClass.NewRow()
$row["c_id"] = 8889
$row["c_name"] = "TEST Boys"
$dtClass.Rows.Add($row)
$cmbClass.DisplayMember = "c_name"
$cmbClass.ValueMember = "c_id"
$cmbClass.DataSource = $dtClass
$cmbClass.SelectedValue = 8889

# Configure 3 months: 10/27/2026 to 12/27/2026
$txtStartDate.Value = [DateTime]::new(2026, 10, 27)
$txtEndDate.Value = [DateTime]::new(2026, 12, 27)
$txtIssueDate.Value = [DateTime]::new(2026, 10, 27)
$txtDueDate.Value = [DateTime]::new(2026, 10, 27)
$chkSingle.Checked = $true
$txtStudentId.Text = "88888"

# Launch dismiss dialogs script
$proc = Start-Process "wscript.exe" -ArgumentList "scratch\dismiss_dialogs.vbs" -PassThru

# Trigger btnproc_Click
$btnMethod = $formType.GetMethod("btnproc_Click", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$btnMethod.Invoke($form, @($null, [System.EventArgs]::Empty))

# Verify database results
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE s_id = '88888'"
$r = $cmd.ExecuteReader()
$masterCount = 0
$genMasterId = 0
while ($r.Read()) {
    $masterCount++
    $genMasterId = $r["FEE_MASTER_ID"]
    Write-Host ("MASTER: ID=" + $r["FEE_MASTER_ID"] + ", Month=" + $r["FEE_MONTH"] + ", From=" + $r["FEE_MONTH_FROM"] + ", T_MONTHS=" + $r["T_MONTHS"] + ", RecAmt=" + $r["RECEIVABLE_AMOUNT"] + ", Balance=" + $r["BALANCE"])
}
$r.Close()

Write-Host "Vouchers generated: $masterCount (Expected: 1)"

if ($genMasterId -gt 0) {
    $cmd.CommandText = "SELECT fd.*, fh.Fee_head FROM FEE_DETAIL fd INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID = $genMasterId"
    $r = $cmd.ExecuteReader()
    while ($r.Read()) {
        Write-Host ("DETAIL: Head=" + $r["Fee_head"] + ", Amt=" + $r["AMOUNT"] + ", Balance=" + $r["BALANCE"])
    }
    $r.Close()
}

$con.Close()
$form.Dispose()
Write-Host "SUCCESS: Fee generation test completed."
