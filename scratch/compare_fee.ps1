$diff = Compare-Object (Get-Content '@class\FEE.cs') (Get-Content 'scratch\backup_fee_cs\FEE.cs.bak2')
Write-Host "Differences count: $($diff.Count)"
foreach ($d in $diff | Select-Object -First 30) {
    Write-Host "$($d.SideIndicator) $($d.InputObject.Trim())"
}
