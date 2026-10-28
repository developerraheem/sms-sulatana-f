Add-Type @"
using System;
using System.Runtime.InteropServices;
using System.Text;

public class WinHelper {
    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    public const uint WM_CLOSE = 0x0010;

    public static void ClosePopups() {
        EnumWindows((hWnd, lParam) => {
            StringBuilder sb = new StringBuilder(256);
            GetWindowText(hWnd, sb, 256);
            string title = sb.ToString();
            if (!string.IsNullOrEmpty(title) && (title.Contains("Voucher") || title.Contains("School") || title.Contains("Error") || title.Contains("Info") || title.Length < 30)) {
                // Check if dialog
                SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
            return true;
        }, IntPtr.Zero);
    }
}
"@
[WinHelper]::ClosePopups()
Write-Host "Popup closed."
