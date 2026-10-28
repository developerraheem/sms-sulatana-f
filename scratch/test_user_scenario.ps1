Add-Type -AssemblyName System.Data
Add-Type -AssemblyName System.Windows.Forms

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))
$fee = [System.Activator]::CreateInstance($feeType = $asm.GetType('School._class.FEE'))
$sys = [System.Activator]::CreateInstance($asm.GetType('School.SYSTEMSETTING'))

$conStr = 'Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;'
$con = New-Object System.Data.SqlClient.SqlConnection($conStr)
$con.Open()

# Set SYSTEMSETTING static properties
[School.SYSTEMSETTING]::branch_ID = '1'
[School.SYSTEMSETTING]::sessionid = '1'

# Find an active student in SCMS_SF_TEST
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 1 s_id, c_id, SHIFT, branch_id, SessionID FROM student WHERE active='true' and branch_id='1' and SessionID='1'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    $sid = $r["s_id"].ToString()
    $cid = $r["c_id"].ToString()
    $shift = $r["SHIFT"].ToString()
    $bid = $r["branch_id"].ToString()
    $sess = $r["SessionID"].ToString()
    Write-Output "Testing with Student: $sid, Class: $cid, Shift: $shift, Branch: $bid, Session: $sess"
}
$r.Close()

$con.Close()
