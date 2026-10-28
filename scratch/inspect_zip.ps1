$ass = [System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")
# Let's inspect zip entries in test_fine.xlsx
$zip = [System.IO.Compression.ZipFile]::OpenRead("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
foreach ($entry in $zip.Entries) {
    Write-Output $entry.FullName
}
$zip.Dispose()
