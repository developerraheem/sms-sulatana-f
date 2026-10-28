Get-ChildItem -Path '.' -Recurse -Filter '*.cs' | Select-String 'Frm_generatefee_multi' | ForEach-Object {
    $_.Path + ':' + $_.LineNumber + ': ' + $_.Line.Trim()
}
