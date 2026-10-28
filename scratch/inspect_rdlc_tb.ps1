$xml = [xml](Get-Content "Reports\RptPrintAll_multi_sf.rdlc")
$ns = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
$ns.AddNamespace("d", $xml.DocumentElement.NamespaceURI)

$textboxes = $xml.SelectNodes("//d:Textbox", $ns)
foreach ($tb in $textboxes) {
    $val = $tb.SelectSingleNode(".//d:Value", $ns)
    if ($val -and ($val.InnerText -like "*AMOUNT*" -or $val.InnerText -like "*Fee_head*")) {
        Write-Host "Textbox: $($tb.Name), Value: $($val.InnerText)"
    }
}
