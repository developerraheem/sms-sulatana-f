Add-Type -AssemblyName System.Drawing

function FindGreenStart($file) {
    $img = new-object System.Drawing.Bitmap($file)
    Write-Output ("File: " + (Split-Path $file -Leaf))
    # Look down column X=50
    for ($y = 0; $y -lt 150; $y++) {
        $c = $img.GetPixel(50, $y)
        if ($y % 10 -eq 0) {
            Write-Output ("  Y=" + $y + " Color: R=" + $c.R + " G=" + $c.G + " B=" + $c.B)
        }
    }
    $img.Dispose()
}

FindGreenStart 'scratch\media_1792823815369_sidebar.png'
FindGreenStart 'scratch\media_1792820957957_sidebar.png'
