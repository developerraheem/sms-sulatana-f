Add-Type -AssemblyName System.Drawing

$img = [System.Drawing.Bitmap]::FromFile('scratch\media_1792823815369_sidebar.png')
Write-Output ("Scanning dashboard sidebar height=" + $img.Height)

for ($y = 0; $y -lt $img.Height; $y += 5) {
    $c = $img.GetPixel(30, $y)
    $diff = [Math]::Abs($c.R - 8) + [Math]::Abs($c.G - 120) + [Math]::Abs($c.B - 61)
    if ($diff -gt 40) {
        Write-Output ("  Y=" + $y + ": R=" + $c.R + " G=" + $c.G + " B=" + $c.B)
    }
}
$img.Dispose()
