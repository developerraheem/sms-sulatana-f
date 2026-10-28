$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

Write-Host "School.exe loaded successfully: $($asm.FullName)"

[SYSTEMSETTING]::branch_ID = "1"
[SYSTEMSETTING]::sessionid = "1"
Write-Host "Current branch_ID: $([SYSTEMSETTING]::branch_ID)"
Write-Host "Current sessionid: $([SYSTEMSETTING]::sessionid)"

$fee = New-Object School._class.FEE
Write-Host "Fee instance created: $($fee -ne $null)"
