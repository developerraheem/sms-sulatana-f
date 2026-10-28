Get-ChildItem -Filter "*.xsd" | ForEach-Object {
    $fileName = $_.Name
    $xml = [xml](Get-Content $_.FullName)
    $adapters = $xml.SelectNodes("//*[local-name()='TableAdapter']")
    foreach ($adapter in $adapters) {
        $name = $adapter.Attributes["Name"].Value
        $cmds = $adapter.SelectNodes(".//*[local-name()='DbCommand']/*[local-name()='CommandText']")
        foreach ($cmd in $cmds) {
            $sql = $cmd.InnerText
            if ($sql -match "FEE_MASTER" -and $sql -match "FEE_DETAIL") {
                if ($sql -notmatch "branch_id") {
                    Write-Host "In $fileName -> TableAdapter ${name}: MISSING branch_id!"
                    Write-Host $sql.Trim()
                    Write-Host "----------------------------------"
                }
            }
        }
    }
}
