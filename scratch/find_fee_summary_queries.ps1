$xml = [xml](Get-Content 'DataSet_Fee_Summary_Reports.xsd')
$adapters = $xml.SelectNodes("//*[local-name()='TableAdapter']")
Write-Host "Found $($adapters.Count) TableAdapters in DataSet_Fee_Summary_Reports.xsd"

foreach ($adapter in $adapters) {
    $name = $adapter.Attributes["Name"].Value
    $selectCmd = $adapter.SelectSingleNode(".//*[local-name()='SelectCommand']/*[local-name()='DbCommand']/*[local-name()='CommandText']")
    if ($selectCmd -and ($selectCmd.InnerText -like "*FEE_MASTER*" -or $selectCmd.InnerText -like "*FEE_DETAIL*" -or $selectCmd.InnerText -like "*Temp*")) {
        Write-Host "=================================================="
        Write-Host "TableAdapter: $name"
        Write-Host $selectCmd.InnerText.Trim()
    }
}
