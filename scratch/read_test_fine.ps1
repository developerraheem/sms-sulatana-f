$ass = [System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")
$dt = [School.ExcelHelper]::ReadFile("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
Write-Output ("Columns count: " + $dt.Columns.Count)
for ($i = 0; $i -lt $dt.Columns.Count; $i++) {
    Write-Output ("Col " + $i + ": " + $dt.Columns[$i].ColumnName)
}
foreach ($r in $dt.Rows) {
    $line = ""
    for ($i = 0; $i -lt $dt.Columns.Count; $i++) {
        $line += "[" + $r[$i] + "] "
    }
    Write-Output $line
}
