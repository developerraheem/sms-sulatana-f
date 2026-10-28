$file = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
try {
    $stream = [System.IO.File]::Open($file, [System.IO.FileMode]::Open, [System.IO.FileAccess]::ReadWrite, [System.IO.FileShare]::None)
    $stream.Close()
    Write-Host "File is NOT locked."
} catch {
    Write-Host ("File IS locked: " + $_.Exception.Message)
}
