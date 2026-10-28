$ass = [System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")
$entries = [School.ExcelHelper]::ExtractZip("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\test_fine.xlsx")

# Load shared strings with XmlDocument
$ssBytes = $entries['xl/sharedStrings.xml']
$ssDoc = New-Object System.Xml.XmlDocument
$ms = New-Object System.IO.MemoryStream(,$ssBytes)
$ssDoc.Load($ms)

$sharedStrings = New-Object System.Collections.Generic.List[string]
$siNodes = $ssDoc.SelectNodes("//*[local-name()='si']")
foreach ($si in $siNodes) {
    $sb = New-Object System.Text.StringBuilder
    $tNodes = $si.SelectNodes(".//*[local-name()='t']")
    foreach ($t in $tNodes) {
        $sb.Append($t.InnerText) | Out-Null
    }
    $sharedStrings.Add($sb.ToString())
}

# Now parse sheet1.xml
$sheetBytes = $entries['xl/worksheets/sheet1.xml']
$sheetDoc = New-Object System.Xml.XmlDocument
$ms2 = New-Object System.IO.MemoryStream(,$sheetBytes)
$sheetDoc.Load($ms2)

$rowNodes = $sheetDoc.SelectNodes("//*[local-name()='row']")
foreach ($row in $rowNodes) {
    $line = "Row " + $row.GetAttribute("r") + ": "
    $cNodes = $row.SelectNodes(".//*[local-name()='c']")
    foreach ($c in $cNodes) {
        $ref = $c.GetAttribute("r")
        $t = $c.GetAttribute("t")
        $vNode = $c.SelectSingleNode(".//*[local-name()='v']")
        $val = if ($vNode -ne $null) { $vNode.InnerText } else { "" }
        if ($t -eq "s") {
            $idx = [int]$val
            $val = $sharedStrings[$idx]
        }
        $line += "[$ref = $val] "
    }
    Write-Output $line
}
