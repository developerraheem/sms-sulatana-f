[System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe") | Out-Null
$entries = [School.ExcelHelper]::ExtractZip("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")
$bytes = $entries['xl/sharedStrings.xml']
$ms = New-Object System.IO.MemoryStream(,$bytes)
$settings = New-Object System.Xml.XmlReaderSettings
$xr = [System.Xml.XmlReader]::Create([System.IO.Stream]$ms, $settings)

$insideSi = $false
while ($xr.Read()) {
    $type = $xr.NodeType.ToString()
    $name = $xr.LocalName
    Write-Host "Read: NodeType=$type, Name=$name, insideSi=$insideSi"
    if ($xr.NodeType -eq [System.Xml.XmlNodeType]::Element -and $xr.LocalName -eq "si") {
        $insideSi = $true
        Write-Host "--> Entered si"
    }
    elseif ($xr.NodeType -eq [System.Xml.XmlNodeType]::EndElement -and $xr.LocalName -eq "si") {
        Write-Host "--> Exited si"
        $insideSi = $false
    }
    elseif ($insideSi -and $xr.NodeType -eq [System.Xml.XmlNodeType]::Element -and $xr.LocalName -eq "t") {
        $content = $xr.ReadElementContentAsString()
        Write-Host "--> Read t content: '$content', After Read: NodeType=$($xr.NodeType), Name=$($xr.LocalName)"
    }
}
$xr.Close()
$ms.Close()
