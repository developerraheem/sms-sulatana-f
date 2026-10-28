[xml]$xml = Get-Content 'c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\Report_DataSet_new.xsd'
$adapters = $xml.SelectNodes('//*[local-name()="TableAdapter"]')
Write-Output "Found $($adapters.Count) TableAdapters in Report_DataSet_new.xsd"

foreach ($adapter in $adapters) {
    $name = $adapter.Name
    Write-Output "=== Adapter: $name ==="
    $sources = $adapter.SelectNodes('.//*[local-name()="DbSource"]')
    foreach ($src in $sources) {
        $mName = $src.GetAttribute('FillMethodName')
        $cmd = $src.SelectSingleNode('.//*[local-name()="CommandText"]')
        $sql = if ($cmd) { $cmd.InnerText -replace '\s+', ' ' } else { 'NO SQL' }
        Write-Output "  Method: $mName"
        Write-Output "  SQL: $($sql.Substring(0, [Math]::Min(120, $sql.Length)))..."
    }
}
