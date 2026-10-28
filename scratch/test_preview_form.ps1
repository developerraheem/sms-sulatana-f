# Set app config to School.exe.config before anything else
$configFile = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe.config"
[AppDomain]::CurrentDomain.SetData("APP_CONFIG_FILE", $configFile)
[Type]::GetType("System.Configuration.ConfigurationManager, System.Configuration")::GetField("s_initState", "NonPublic, Static") | ForEach-Object { $_.SetValue($null, 0) }

$appPath = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
[System.Reflection.Assembly]::LoadFrom($appPath) | Out-Null

[SYSTEMSETTING]::sessionid = "81"
[SYSTEMSETTING]::branch_ID = "2"

$dt1 = [School.ExcelHelper]::ReadFile("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_scenario_1.xlsx")
Write-Output "=== FORM PREVIEW TEST: test_scenario_1.xlsx ==="
$frm = New-Object School._forms.FrmExcelImportPreview($dt1, "12 2026", "1", "Fine", "65")

# Call ProcessAndValidate via reflection to inspect processedItems
$m = [School._forms.FrmExcelImportPreview].GetMethod("ProcessAndValidate", [System.Reflection.BindingFlags]"NonPublic, Instance")
$m.Invoke($frm, $null)

$field = [School._forms.FrmExcelImportPreview].GetField("processedItems", [System.Reflection.BindingFlags]"NonPublic, Instance")
$items = $field.GetValue($frm)

Write-Output ("Items processed: " + $items.Count)
foreach ($it in $items) {
    Write-Output ("Row " + $it.RowNum + ": InputID=" + $it.InputStudentId + ", Name=" + ($it.MatchedStudent.Name) + ", Amount=" + $it.Amount + ", Status=" + $it.Status + ", Notes=" + $it.Notes)
}

$dt2 = [School.ExcelHelper]::ReadFile("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_scenario_2.xlsx")
Write-Output "`n=== FORM PREVIEW TEST: test_scenario_2.xlsx (Different Column Order) ==="
$frm2 = New-Object School._forms.FrmExcelImportPreview($dt2, "12 2026", "1", "Fine", "65")
$m.Invoke($frm2, $null)
$items2 = $field.GetValue($frm2)
Write-Output ("Items processed: " + $items2.Count)
foreach ($it in $items2) {
    Write-Output ("Row " + $it.RowNum + ": InputID=" + $it.InputStudentId + ", Name=" + ($it.MatchedStudent.Name) + ", Amount=" + $it.Amount + ", Status=" + $it.Status + ", Notes=" + $it.Notes)
}

$frm.Dispose()
$frm2.Dispose()
