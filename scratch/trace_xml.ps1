[System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe") | Out-Null
$entries = [School.ExcelHelper]::ExtractZip("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
$bytes = $entries['xl/sharedStrings.xml']
$ms = New-Object System.IO.MemoryStream(,$bytes)
$settings = New-Object System.Xml.XmlReaderSettings
$xr = [System.Xml.XmlReader]::Create([System.IO.Stream]$ms, $settings)

while ($xr.Read()) {
    Write-Output ("Node: " + $xr.NodeType + ", Name: " + $xr.LocalName + ", Value: " + $xr.Value)
}
$xr.Close()
$ms.Close()
