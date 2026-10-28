Add-Type -AssemblyName System.Drawing

$img = [System.Drawing.Image]::FromFile("C:\Users\nahee\.gemini\antigravity-ide\brain\e48c82a2-d9c1-4409-b96c-0c9988c77b6f\.user_uploaded\media_1792820257847.png")
$bmp = new-object System.Drawing.Bitmap($img)
for ($x = 0; $x -lt 40; $x += 5) {
    for ($y = 0; $y -lt 30; $y += 5) {
        $c = $bmp.GetPixel($x, $y)
        Write-Output "Pixel ($x, $y): R=$($c.R), G=$($c.G), B=$($c.B)"
    }
}
$bmp.Dispose()
$img.Dispose()
