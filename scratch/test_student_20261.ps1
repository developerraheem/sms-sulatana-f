[System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe") | Out-Null
$fee = New-Object School._class.FEE
[SYSTEMSETTING]::branch_ID = "6"
[SYSTEMSETTING]::sessionid = "68"

$arr = $fee.GetPreviousOutstandingArrears("20261", "09 2026", "", "6", "68")
Write-Host "Outstanding Arrears for 20261 for month 09 2026:" $arr

$arr08 = $fee.GetPreviousOutstandingArrears("20261", "08 2026", "", "6", "68")
Write-Host "Outstanding Arrears for 20261 for month 08 2026:" $arr08
