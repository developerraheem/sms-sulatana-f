Get-ChildItem -Path '.' -Recurse -Filter '*.cs' | Select-String 'btnproc' | ForEach-Object {
    $_.Path + ':' + $_.LineNumber + ': ' + $_.Line.Trim()
}
