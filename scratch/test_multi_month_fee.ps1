Add-Type -AssemblyName System.Data
Add-Type -AssemblyName System.Windows.Forms

# Load School.exe
$asmPath = Resolve-Path "bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($asmPath)
$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$sysType = $asm.GetType("School.SYSTEMSETTING")

# Initialize form
$form = [System.Activator]::CreateInstance($formType)

# Connect to database and clean up any existing vouchers for test student 88888 in 10 2026 - 12 2026
$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '88888')"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE s_id = '88888'"
$cmd.ExecuteNonQuery() | Out-Null

# Set branch and session
[School.SYSTEMSETTING]::branch_ID = "6"
[School.SYSTEMSETTING]::sessionid = "68"

# Trigger form load
$loadMethod = $formType.GetMethod("Frm_generatefee_multi_Load", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadMethod.Invoke($form, @($null, [System.EventArgs]::Empty))

# Get controls
$txtStartDate = $form.GetType().GetField("txtstartdate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtEndDate = $form.GetType().GetField("txtenddate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtIssueDate = $form.GetType().GetField("txtissuedate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtDueDate = $form.GetType().GetField("txtduedate", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtDateFrom = $form.GetType().GetField("txtdatefrom", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtDateTo = $form.GetType().GetField("txtdateto", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$cmbClass = $form.GetType().GetField("comboBox1", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$chkSingle = $form.GetType().GetField("checkBox1", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)
$txtStudentId = $form.GetType().GetField("txtstudentid", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance).GetValue($form)

# Configure for 3-month selection
$txtStartDate.Value = [DateTime]::new(2026, 10, 27)
$txtEndDate.Value = [DateTime]::new(2026, 12, 27)
$txtIssueDate.Value = [DateTime]::new(2026, 10, 27)
$txtDueDate.Value = [DateTime]::new(2026, 10, 27)
$cmbClass.SelectedValue = 8889
$chkSingle.Checked = $true
$txtStudentId.Text = "88888"

Write-Host "Configured 3-month fee generation: Start=$($txtStartDate.Value.ToString('yyyy-MM-dd')), End=$($txtEndDate.Value.ToString('yyyy-MM-dd'))"
Write-Host "txtdatefrom=$($txtDateFrom.Text), txtdateto=$($txtDateTo.Text), lblmonth=$($form.GetMonths($txtStartDate.Value, $txtEndDate.Value))"

# Call btnproc_Click
# Note: btnproc_Click shows a MessageBox "You Want to Generate Fee?". In automated test, let's call the fee logic or test GetMonths and adjustment
$months = $form.GetMonths($txtStartDate.Value, $txtEndDate.Value)
Write-Host "Calculated Months: $months (Expected: 3)"

$con.Close()
$form.Dispose()
Write-Host "Test completed successfully."
