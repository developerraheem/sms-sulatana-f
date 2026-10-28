Get-ChildItem -Path "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation" -Filter "*.cs" -Recurse | Where-Object { 
    $_.FullName -notmatch "\\obj\\" -and $_.FullName -notmatch "\\bin\\" 
} | ForEach-Object {
    $matches = Select-String -Path $_.FullName -Pattern "branch_ID\s*=\s*"
    foreach ($m in $matches) {
        if ($m.Line -match "SYSTEMSETTING\.branch_ID\s*=") {
            Write-Output ($m.Filename + ":" + $m.LineNumber + " " + $m.Line.Trim())
        }
    }
}
