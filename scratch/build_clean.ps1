Get-Process -Name School -ErrorAction SilentlyContinue | Stop-Process -Force
Get-Process -Name powershell | Where-Object { $_.Id -ne $PID } | Stop-Process -Force -ErrorAction SilentlyContinue
& "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" "CSMS_CSS.csproj" /p:Configuration=Debug /t:Build /verbosity:minimal
