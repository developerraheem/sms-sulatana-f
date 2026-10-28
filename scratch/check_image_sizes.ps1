Add-Type -AssemblyName System.Drawing
$path1 = 'C:\Users\nahee\.gemini\antigravity-ide\brain\e48c82a2-d9c1-4409-b96c-0c9988c77b6f\.user_uploaded\media_1792820957957.png'
$img1 = [System.Drawing.Image]::FromFile($path1)
Write-Output ("Param image size: " + $img1.Width + "x" + $img1.Height)
$img1.Dispose()

$files = Get-ChildItem 'C:\Users\nahee\.gemini\antigravity-ide\brain\e48c82a2-d9c1-4409-b96c-0c9988c77b6f\.user_uploaded\*.png'
foreach ($f in $files) {
    $img = [System.Drawing.Image]::FromFile($f.FullName)
    Write-Output ($f.Name + ": " + $img.Width + "x" + $img.Height)
    $img.Dispose()
}
