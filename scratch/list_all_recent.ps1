Get-ChildItem -Path "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation" -Recurse | Where-Object { 
    (-not $_.PSIsContainer) -and 
    ($_.LastWriteTime -gt (Get-Date).AddHours(-4)) -and 
    ($_.FullName -notmatch "\\obj\\") -and 
    ($_.FullName -notmatch "\\bin\\")
} | Select-Object FullName, LastWriteTime | Format-Table -AutoSize
