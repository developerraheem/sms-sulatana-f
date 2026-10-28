Add-Type @"
using System;
using System.Runtime.InteropServices;
public class WinSearch {
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
}
"@

$hWnd = [WinSearch]::FindWindow($null, "Fee Not Generated!")
if ($hWnd -ne [IntPtr]::Zero) {
    Write-Host "Found MessageBox 'Fee Not Generated!' at hWnd: $hWnd"
} else {
    Write-Host "MessageBox 'Fee Not Generated!' not found."
}
