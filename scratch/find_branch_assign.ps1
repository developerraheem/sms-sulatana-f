Get-ChildItem -Path '.' -Recurse -Filter '*.cs' | Select-String -Pattern 'SYSTEMSETTING\.branch_ID\s*=' | ForEach-Object {
    $_.Path + ':' + $_.LineNumber + ': ' + $_.Line.Trim()
}
