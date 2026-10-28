Get-Process | Where-Object { $_.ProcessName -like "*School*" -or $_.ProcessName -like "*CSMS*" } | Select-Object Id, ProcessName, Path | Format-Table -AutoSize
