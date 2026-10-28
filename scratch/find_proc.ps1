$procs = Get-CimInstance Win32_Process -Filter "Name = 'powershell.exe'"
foreach ($p in $procs) {
    if ($p.CommandLine -like "*test_duplicate_arrears_fix.ps1*") {
        Write-Host "Found Test PID: $($p.ProcessId)"
    }
}
