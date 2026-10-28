$xml = [xml](Get-Content "Reports\RptPrintAll_multi_sf.rdlc")
$ns = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
$ns.AddNamespace("d", $xml.DocumentElement.NamespaceURI)

$tb = $xml.SelectSingleNode("//d:Textbox[@Name='AMOUNT2']", $ns)
Write-Host "AMOUNT2 XML:"
Write-Host $tb.OuterXml
