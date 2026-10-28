Add-Type -AssemblyName System.Drawing

$img = [System.Drawing.Bitmap]::FromFile('scratch\media_1792823815369_sidebar.png')
for ($y = 0; $y -lt 150; $y++) {
    $c = $img.GetPixel(20, $y)
    Write-Output ("Y=" + $y + " R=" + $c.R + " G=" + $c.G + " B=" + $c.B)
}
$img.Dispose()
