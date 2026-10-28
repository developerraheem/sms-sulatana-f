Add-Type -AssemblyName System.Drawing

$img = [System.Drawing.Bitmap]::FromFile('scratch\media_1792823815369_sidebar.png')
Write-Output ("Sidebar total height: " + $img.Height)

# Let's crop each 55px section from Y=0 to 519
for ($i = 0; $i -lt 9; $i++) {
    $y = $i * 55
    Write-Output ("Slot $i: Y=$y to " + ($y + 55))
}
$img.Dispose()
