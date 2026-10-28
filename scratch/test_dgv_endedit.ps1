$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)

# We can test with a DataGridView and BindingSource directly
$dt = New-Object System.Data.DataTable
$colId = $dt.Columns.Add("ID", [int])
$colActive = $dt.Columns.Add("ACTIVE", [bool])
$row = $dt.NewRow()
$row["ID"] = 1
$row["ACTIVE"] = $true
$dt.Rows.Add($row)
$dt.AcceptChanges()

$bs = New-Object System.Windows.Forms.BindingSource
$bs.DataSource = $dt

$dgv = New-Object System.Windows.Forms.DataGridView
$dgv.DataSource = $bs

# Add dgv to form so it has a parent window
$form.Controls.Add($dgv)
$form.Show()

Write-Output "Initial DB Row ACTIVE: $($row['ACTIVE'])"
Write-Output "Initial HasChanges: $($dt.GetChanges() -ne $null)"

# Focus cell 1 (ACTIVE checkbox)
$dgv.CurrentCell = $dgv.Rows[0].Cells[1]
# Begin edit
$dgv.BeginEdit($true)

# In real UI, user clicks checkbox cell.
# With DataGridViewCheckBoxCell, clicking toggles the EditingControlFormattedValue or dirty state:
$dgv.NotifyCurrentCellAddressChange()
# Let's say user toggled it:
$dgv.Rows[0].Cells[1].Value = $false

Write-Output "IsCurrentCellInEditMode: $($dgv.IsCurrentCellInEditMode)"
Write-Output "Before EndEdit - DB Row ACTIVE: $($row['ACTIVE'])"
Write-Output "Before EndEdit - HasChanges: $($dt.GetChanges() -ne $null)"

# Call Validate and bs.EndEdit WITHOUT dgv.EndEdit()
$form.Validate()
$bs.EndEdit()

Write-Output "After bs.EndEdit() only - DB Row ACTIVE: $($row['ACTIVE'])"
Write-Output "After bs.EndEdit() only - HasChanges: $($dt.GetChanges() -ne $null)"
Write-Output "IsCurrentCellInEditMode still: $($dgv.IsCurrentCellInEditMode)"

# Now call dgv.EndEdit()
$dgv.EndEdit()
$bs.EndEdit()

Write-Output "After dgv.EndEdit() - DB Row ACTIVE: $($row['ACTIVE'])"
Write-Output "After dgv.EndEdit() - HasChanges: $($dt.GetChanges() -ne $null)"

$form.Close()
$form.Dispose()
