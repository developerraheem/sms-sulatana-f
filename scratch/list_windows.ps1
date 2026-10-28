Add-Type @"
using System;
using System.Text;
using System.Runtime.InteropServices;
public class WindowLister {
    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    [DllImport("user32.dll")]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
    [DllImport("user32.dll")]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(IntPtr hWnd);
    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
}
"@

$list = New-Object System.Collections.Generic.List[string]
[WindowLister]::EnumWindows({
    param($hWnd, $lParam)
    if ([WindowLister]::IsWindowVisible($hWnd)) {
        $sb = New-Object System.Text.StringBuilder 256
        $len = [WindowLister]::GetWindowText($hWnd, $sb, 256)
        if ($len -gt 0) {
            $pidVal = 0
            [WindowLister]::GetWindowThreadProcessId($hWnd, [ref]$pidVal)
            $title = $sb.ToString()
            Write-Host "PID $pidVal : '$title'"
        }
    }
    return $true
}, [IntPtr]::Zero) | Out-Null
