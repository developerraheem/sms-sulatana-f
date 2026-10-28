$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sys = $asm.GetType("SYSTEMSETTING")
$sys.GetField("branch_ID").SetValue($null, "1")
$sys.GetField("sessionid").SetValue($null, "12")

$feeType = $asm.GetType("School._class.FEE")
$fee = [System.Activator]::CreateInstance($feeType)

# Let's see what GetMasterID returns
$mId = $feeType.GetMethod("GetMasterID").Invoke($fee, $null)
Write-Host "GetMasterID returned: '$mId'"

# Query student 2093
$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE s_id = '2093'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "Student 2093: c_id=$($r['c_id']) shift=$($r['SHIFT']) sec=$($r['SECTION_ID']) branch=$($r['branch_id']) session=$($r['SessionID']) active=$($r['active'])"
}
$r.Close()
$con.Close()
