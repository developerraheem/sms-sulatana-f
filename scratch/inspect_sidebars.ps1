Add-Type -AssemblyName System.Drawing

function InspectSidebar($file) {
    $img = [System.Drawing.Image]::FromFile($file)
    Write-Output ("=== File: " + (Split-Path $file -Leaf) + " (" + $img.Width + "x" + $img.Height + ") ===")
    
    # Crop left 130px
    $bmp = new-object System.Drawing.Bitmap(130, $img.Height)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.DrawImage($img, 0, 0, (new-object System.Drawing.Rectangle(0, 0, 130, $img.Height)), [System.Drawing.GraphicsUnit]::Pixel)
    $g.Dispose()
    
    $name = [System.IO.Path]::GetFileNameWithoutExtension($file)
    $outPath = "scratch\" + $name + "_sidebar.png"
    $bmp.Save($outPath, [System.Drawing.Imaging.ImageFormat]::Png)
    $bmp.Dispose()
    $img.Dispose()
    Write-Output ("Saved: " + $outPath)
}

InspectSidebar 'C:\Users\nahee\.gemini\antigravity-ide\brain\e48c82a2-d9c1-4409-b96c-0c9988c77b6f\.user_uploaded\media_1792823815369.png'
InspectSidebar 'C:\Users\nahee\.gemini\antigravity-ide\brain\e48c82a2-d9c1-4409-b96c-0c9988c77b6f\.user_uploaded\media_1792820957957.png'
