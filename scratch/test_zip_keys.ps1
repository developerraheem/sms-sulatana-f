$ass = [System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")
$entries = [School.ExcelHelper]::ExtractZip("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
Write-Output ("Entries count: " + $entries.Count)
foreach ($key in $entries.Keys) {
    Write-Output ("Key: '" + $key + "' (len=" + $entries[$key].Length + ")")
}
