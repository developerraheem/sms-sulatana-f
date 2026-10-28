Get-ChildItem -Path "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation" -Filter "*.cs" -Recurse | Where-Object { 
    $_.FullName -notmatch "\\obj\\" -and $_.FullName -notmatch "\\bin\\" 
} | ForEach-Object {
    $matches = Select-String -Path $_.FullName -Pattern "branch_ID\s*="
    foreach ($m in $matches) {
        Write-Output ($m.Filename + ":" + $m.LineNumber + " " + $m.Line.Trim())
    }
}
