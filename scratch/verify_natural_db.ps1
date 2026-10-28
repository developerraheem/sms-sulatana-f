$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$sysInst = [System.Activator]::CreateInstance($sysType)
$c = $sysInst.db_connect()
Write-Host "Natural default runtime database connection:" $c.Database
$c.Close()
