$files = Get-ChildItem -Path "Reports" -Filter "*.rdlc"
foreach ($f in $files) {
    $content = [System.IO.File]::ReadAllText($f.FullName)
    if ($content.Contains("Fee_head") -or $content.Contains("FEE CONCESSION") -or $content.Contains("CONCESSION")) {
        Write-Host "Found in $($f.Name)"
    }
}
