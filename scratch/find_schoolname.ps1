Get-ChildItem -Path '.' -Recurse -Filter '*.cs' | Select-String 'schoolname' | ForEach-Object {
    $_.Path + ':' + $_.LineNumber + ': ' + $_.Line.Trim()
}
