$ass = [System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")
$entries = [School.ExcelHelper]::ExtractZip("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
$ss = [System.Text.Encoding]::UTF8.GetString($entries['xl/sharedStrings.xml'])
Write-Output "--- sharedStrings.xml ---"
Write-Output $ss
$sheet = [System.Text.Encoding]::UTF8.GetString($entries['xl/worksheets/sheet1.xml'])
Write-Output "--- sheet1.xml ---"
Write-Output $sheet
