Add-Type -AssemblyName System.Drawing

$img = [System.Drawing.Bitmap]::FromFile('scratch\media_1792823815369_sidebar.png')
# Look down column X=50 (where text is centered)
# Text is White (255, 255, 255)
for ($y = 0; $y -lt $img.Height; $y++) {
    $c = $img.GetPixel(50, $y)
    if ($c.R -gt 230 -and $c.G -gt 230 -and $c.B -gt 230) {
        Write-Output ("White pixel at Y=" + $y + " (R=" + $c.R + " G=" + $c.G + " B=" + $c.B + ")")
    }
}
$img.Dispose()
