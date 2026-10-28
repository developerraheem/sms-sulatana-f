try {
    $stream = [System.IO.File]::Open('bin\Debug\School.exe', 'Open', 'ReadWrite', 'None')
    $stream.Close()
    Write-Output 'File is NOT locked.'
} catch {
    Write-Output ("File IS locked: " + $_.Exception.Message)
}
