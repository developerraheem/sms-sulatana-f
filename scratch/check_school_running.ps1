$proc = Get-Process -Name "School" -ErrorAction SilentlyContinue
if ($proc) {
    Write-Host "School.exe is running with PID $($proc.Id)"
    Stop-Process -Id $proc.Id -Force
    Write-Host "Killed process $($proc.Id)"
} else {
    Write-Host "School.exe is not running."
}
