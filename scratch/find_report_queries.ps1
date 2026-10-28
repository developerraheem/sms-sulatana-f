$xml = [xml](Get-Content 'Report_DataSet_new.xsd')
$ns = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
$ns.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema")
$ns.AddNamespace("msdata", "urn:schemas-microsoft-com:xml-msdata")
$ns.AddNamespace("msprop", "urn:schemas-microsoft-com:xml-msprop")

$adapters = $xml.SelectNodes("//*[local-name()='TableAdapter']")
Write-Host "Found $($adapters.Count) TableAdapters in Report_DataSet_new.xsd"

foreach ($adapter in $adapters) {
    $name = $adapter.Attributes["Name"].Value
    $selectCmd = $adapter.SelectSingleNode(".//*[local-name()='SelectCommand']/*[local-name()='DbCommand']/*[local-name()='CommandText']")
    if ($selectCmd -and ($selectCmd.InnerText -like "*FEE_MASTER*" -or $selectCmd.InnerText -like "*FEE_DETAIL*" -or $selectCmd.InnerText -like "*Temp*")) {
        Write-Host "=================================================="
        Write-Host "TableAdapter: $name"
        Write-Host $selectCmd.InnerText.Trim()
    }
}
