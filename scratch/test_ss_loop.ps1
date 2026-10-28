[System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe") | Out-Null
$entries = [School.ExcelHelper]::ExtractZip("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
$bytes = $entries['xl/sharedStrings.xml']
$ms = New-Object System.IO.MemoryStream(,$bytes)
$settings = New-Object System.Xml.XmlReaderSettings
$xr = [System.Xml.XmlReader]::Create([System.IO.Stream]$ms, $settings)

$sharedStrings = New-Object System.Collections.Generic.List[string]
$sb = New-Object System.Text.StringBuilder
$insideSi = $false

while ($xr.Read()) {
    if ($xr.NodeType -eq [System.Xml.XmlNodeType]::Element -and $xr.LocalName -eq "si") {
        $insideSi = $true
        $sb.Length = 0
    }
    elseif ($xr.NodeType -eq [System.Xml.XmlNodeType]::EndElement -and $xr.LocalName -eq "si") {
        $sharedStrings.Add($sb.ToString())
        $insideSi = $false
    }
    elseif ($insideSi -and $xr.NodeType -eq [System.Xml.XmlNodeType]::Element -and $xr.LocalName -eq "t") {
        $sb.Append($xr.ReadElementContentAsString()) | Out-Null
    }
}
$xr.Close()
$ms.Close()

Write-Output ("Count: " + $sharedStrings.Count)
for ($i = 0; $i -lt $sharedStrings.Count; $i++) {
    Write-Output ($i.ToString() + ": " + $sharedStrings[$i])
}
