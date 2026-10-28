Add-Type @"
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class FileUtil
{
    [StructLayout(LayoutKind.Sequential)]
    struct RM_UNIQUE_PROCESS
    {
        public int dwProcessId;
        public System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    struct RM_PROCESS_INFO
    {
        public RM_UNIQUE_PROCESS Process;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string strAppName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string strServiceShortName;
        public int ApplicationType;
        public uint AppStatus;
        public uint TSSessionId;
        [MarshalAs(UnmanagedType.Bool)]
        public bool bRestartable;
    }

    [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
    static extern int RmStartSession(out uint pSessionHandle, int dwSessionFlags, string strSessionKey);

    [DllImport("rstrtmgr.dll")]
    static extern int RmEndSession(uint pSessionHandle);

    [DllImport("rstrtmgr.dll", CharSet = CharSet.Auto)]
    static extern int RmRegisterResources(uint pSessionHandle, uint nFiles, string[] rgsFilenames,
        uint nApplications, RM_UNIQUE_PROCESS[] rgApplications, uint nServices, string[] rgsServiceNames);

    [DllImport("rstrtmgr.dll")]
    static extern int RmGetList(uint dwSessionHandle, out uint pnProcInfoNeeded,
        ref uint pnProcInfo, [In, Out] RM_PROCESS_INFO[] rgAffectedApps, ref uint lpdwRebootReasons);

    public static List<int> WhoIsLocking(string path)
    {
        uint handle;
        string key = Guid.NewGuid().ToString();
        List<int> processes = new List<int>();

        int res = RmStartSession(out handle, 0, key);
        if (res != 0) return processes;

        try
        {
            string[] resources = new string[] { path };
            res = RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null);
            if (res != 0) return processes;

            uint pnProcInfoNeeded = 0;
            uint pnProcInfo = 0;
            uint lpdwRebootReasons = 0;

            res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, null, ref lpdwRebootReasons);
            if (res == 234) // ERROR_MORE_DATA
            {
                RM_PROCESS_INFO[] processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];
                pnProcInfo = pnProcInfoNeeded;
                res = RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, ref lpdwRebootReasons);
                if (res == 0)
                {
                    for (int i = 0; i < pnProcInfo; i++)
                    {
                        processes.Add(processInfo[i].Process.dwProcessId);
                    }
                }
            }
        }
        finally
        {
            RmEndSession(handle);
        }

        return processes;
    }
}
"@

$file = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$pids = [FileUtil]::WhoIsLocking($file)
Write-Host "Locking PIDs: $($pids -join ', ')"
foreach ($p in $pids) {
    try {
        $proc = Get-Process -Id $p
        Write-Host ("Process: " + $proc.ProcessName + " (PID: " + $p + ")")
        $proc | Stop-Process -Force
        Write-Host ("Terminated PID: " + $p)
    } catch {
        Write-Host ("Could not terminate PID " + $p + ": " + $_.Exception.Message)
    }
}
