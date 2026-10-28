$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$classid = "64"
$month = "11 2026"
$SHIFT = "Morning"
$studentid = "2093"
$months = 1
$monthfrom = "11 2026"
$DUE_DATE = "10/11/2026"
$tmonths = "1"
$tfine = "0"
$remarks = "Test Note"
$ISSUE_DATE = "01/11/2026"
$startdate = "01/11/2026"
$enddate = "30/11/2026"
$sectionID = "Female"
$branch_id = "1"
$sessionid = "12"

# 1. Check student selection query
$qStd = "Select * from [student] where [c_id] ='$classid' and [active]='true' and SHIFT='$SHIFT' and SessionID='$sessionid' and branch_id='$branch_id' AND SECTION_ID='$sectionID' and s_id='$studentid' and [s_id] NOT IN (Select [s_id] from [FEE_MASTER] where [c_id] ='$classid' and [FEE_MONTH]='$month' AND SHIFT ='$SHIFT' AND SESSIONID='$sessionid' and branch_id='$branch_id')"
$cmd.CommandText = $qStd
$r = $cmd.ExecuteReader()
$hasStd = $r.Read()
Write-Host "Student found in selection query: $hasStd"
$stdType = "General"
if ($hasStd) {
    $stdType = $r['TYPE'].ToString()
    Write-Host "  s_id: $($r['s_id']), type: $stdType"
}
$r.Close()

# 2. Check FEE_CLASS query
$qFC = "Select fc.*, fh.Fee_head, fh.Category from FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID='$classid' and fc.ACTIVE='true' AND fc.TYPE='$stdType' Order by fc.Fee_head_id"
$cmd.CommandText = $qFC
$r = $cmd.ExecuteReader()
Write-Host "FEE_CLASS rows for class $classid"
while($r.Read()) {
    Write-Host "  Head: $($r['Fee_head']), ID: $($r['Fee_head_id']), Amt: $($r['AMOUNT']), Cat: $($r['Category'])"
}
$r.Close()

$con.Close()
