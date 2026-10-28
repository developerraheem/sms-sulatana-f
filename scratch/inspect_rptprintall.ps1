$xml = [xml](Get-Content "Reports\RptPrintAll.rdlc")
$ns = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
$ns.AddNamespace("d", $xml.DocumentElement.NamespaceURI)

$tb = $xml.SelectSingleNode("//d:Textbox[@Name='AMOUNT']", $ns)
if ($tb) {
    Write-Host "AMOUNT XML in RptPrintAll.rdlc:"
    Write-Host $tb.OuterXml
} else {
    $tbs = $xml.SelectNodes("//d:Textbox[contains(@Name, 'AMOUNT')]", $ns)
    foreach ($t in $tbs) {
        Write-Host "$($t.Name): $($t.OuterXml)"
    }
}
