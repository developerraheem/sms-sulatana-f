Get-ChildItem -Path "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation" -Filter "*.cs" -Recurse | ForEach-Object {
    $file = $_.FullName
    if ($file -notmatch "Designer\.cs" -and $file -notmatch "\\obj\\" -and $file -notmatch "\\bin\\") {
        $matches = Select-String -Path $file -Pattern "CONCESSION"
        foreach ($m in $matches) {
            Write-Output ($m.Filename + ":" + $m.LineNumber + " " + $m.Line.Trim())
        }
    }
}
