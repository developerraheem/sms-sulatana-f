Set WshShell = CreateObject("WScript.Shell")
For i = 1 To 40
    WScript.Sleep 250
    If WshShell.AppActivate("CONFRIM") Then
        WshShell.SendKeys "{ENTER}"
    End If
    If WshShell.AppActivate("Information") Then
        WshShell.SendKeys "{ENTER}"
    End If
Next
