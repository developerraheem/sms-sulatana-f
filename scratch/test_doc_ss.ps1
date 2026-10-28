[System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe") | Out-Null
$entries = [School.ExcelHelper]::ExtractZip("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
$bytes = $entries['xl/sharedStrings.xml']
$doc = New-Object System.Xml.XmlDocument
$ms = New-Object System.IO.MemoryStream(,$bytes)
$doc.Load($ms)

$sharedStrings = New-Object System.Collections.Generic.List[string]
$siNodes = $doc.SelectNodes("//*[local-name()='si']")
foreach ($si in $siNodes) {
    $sb = New-Object System.Text.StringBuilder
    $tNodes = $si.SelectNodes(".//*[local-name()='t']")
    foreach ($t in $tNodes) {
        $sb.Append($t.InnerText) | Out-Null
    }
    $sharedStrings.Add($sb.ToString())
}
Write-Output ("Loaded shared strings: " + $sharedStrings.Count)
for ($i = 0; $i -lt $sharedStrings.Count; $i++) {
    Write-Output ($i.ToString() + ": " + $sharedStrings[$i])
}
