$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

# Set settings
$settingsType = $asm.GetType("School.Properties.Settings")
$settingsProp = $settingsType.GetProperty("Default")
$appSettings = $settingsProp.GetValue($null, $null)
$appSettings["sql_conn"] = $testConnStr

$sysType = $asm.GetType("SYSTEMSETTING")
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "2")

# Let's find a class for branch 1 that has Admission Fee
# In our query earlier:
# Class 169 (BSCS-I) has Fee_head_id 115 (ADMISSION FEE), FEE_CLASS_ID 52375, ACTIVE=True, branch_id 1
# Let's check current ACTIVE in database
$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT FEE_CLASS_ID, Fee_head_id, C_ID, ACTIVE, AMOUNT FROM FEE_CLASS WHERE FEE_CLASS_ID = 52375"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Output "Initial DB State for 52375: Active = $($dt.Rows[0]['ACTIVE'])"
$conn.Close()

# Create Form Frm_generatefee_multi
$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)

# Trigger Form_Load
$loadMethod = $formType.GetMethod("Frm_generatefee_Load", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadMethod.Invoke($form, @($null, [System.EventArgs]::Empty))

# Find comboBox1 (Class dropdown)
$cmbClassProp = $formType.GetField("comboBox1", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$cmbClass = $cmbClassProp.GetValue($form)
Write-Output "ComboBox items count: $($cmbClass.Items.Count)"

# Select class 169
$cmbClass.SelectedValue = [decimal]169
Write-Output "Selected class: $($cmbClass.SelectedValue)"

# Get grid
$gridField = $formType.GetField("fee_Class_updateDataGridView", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$grid = $gridField.GetValue($form)
Write-Output "Grid row count: $($grid.Rows.Count)"

# Find row with FEE_CLASS_ID = 52375
$targetGridRow = $null
for ($i = 0; $i -lt $grid.Rows.Count; $i++) {
    $row = $grid.Rows[$i]
    $idVal = $row.Cells[0].Value
    if ([decimal]$idVal -eq [decimal]52375) {
        $targetGridRow = $row
        Write-Output "Found target grid row at index $i, Active = $($row.Cells[4].Value)"
        break
    }
}

if ($targetGridRow) {
    # Simulate user clicking the checkbox cell to uncheck it
    # Cell 4 is Active checkbox
    $grid.CurrentCell = $targetGridRow.Cells[4]
    $grid.BeginEdit($true)
    $targetGridRow.Cells[4].Value = $false
    Write-Output "After setting cell value to false, cell value: $($targetGridRow.Cells[4].Value)"
    
    # User clicks Save button (fee_Class_updateBindingNavigatorSaveItem) WITHOUT navigating away
    $saveBtnField = $formType.GetField("fee_Class_updateBindingNavigatorSaveItem", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
    $saveBtn = $saveBtnField.GetValue($form)
    
    $saveMethod = $formType.GetMethod("fee_Class_updateBindingNavigatorSaveItem_Click", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
    $saveMethod.Invoke($form, @($saveBtn, [System.EventArgs]::Empty))
    Write-Output "Invoked save button click!"
}

# Check DB state after save
$conn.Open()
$cmd.CommandText = "SELECT FEE_CLASS_ID, Fee_head_id, C_ID, ACTIVE, AMOUNT FROM FEE_CLASS WHERE FEE_CLASS_ID = 52375"
$dtAfter = New-Object System.Data.DataTable
$da.Fill($dtAfter) | Out-Null
Write-Output "DB State AFTER Save for 52375: Active = $($dtAfter.Rows[0]['ACTIVE'])"
$conn.Close()

$form.Dispose()
