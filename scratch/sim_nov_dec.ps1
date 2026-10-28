$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sys = $asm.GetType("SYSTEMSETTING")
$sys.GetField("branch_ID").SetValue($null, "1")
$sys.GetField("sessionid").SetValue($null, "12")

$feeType = $asm.GetType("School._class.FEE")
$feeInstance = [System.Activator]::CreateInstance($feeType)

$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()

# Clean any existing test records for student 2093 in 11 2026 / 12 2026
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH IN ('11 2026', '12 2026'));
DELETE FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH IN ('11 2026', '12 2026');
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "--- Step 1: Generate November 2026 fee ---"
# generatefeeMulti(string classid, string month, string SHIFT, string studentid, int months, string monthfrom, string DUE_DATE, string tmonths, string tfine, string remarks, string ISSUE_DATE, string startdate, string enddate, string sectionID)
$genMulti = $feeType.GetMethod("generatefeeMulti")
$genMulti.Invoke($feeInstance, @("64", "11 2026", "Morning", "2093", 1, "11 2026", "10/11/2026", "1", "0", "Test Note", "01/11/2026", "01/11/2026", "30/11/2026", "Female"))

Write-Host "Checking November records:"
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "  FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "Paid:" $r["PAID"] "Bal:" $r["BALANCE"]
}
$r.Close()

$cmd.CommandText = @"
SELECT d.FEE_MASTER_ID, m.FEE_MONTH, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE
FROM FEE_DETAIL d
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE m.s_id = '2093' AND m.FEE_MONTH = '11 2026'
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "    Detail:" $r["Fee_head"] "Amt:" $r["AMOUNT"] "Cat:" $r["Category"] "Curr:" $r["ISCURRENT"] "Bal:" $r["BALANCE"]
}
$r.Close()

Write-Host "`n--- Step 2: Now Generate December 2026 fee (November remains unpaid) ---"
$genMulti.Invoke($feeInstance, @("64", "12 2026", "Morning", "2093", 1, "12 2026", "10/12/2026", "1", "0", "Test Note", "01/12/2026", "01/12/2026", "31/12/2026", "Female"))

Write-Host "Checking all records for student 2093:"
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '2093' ORDER BY FEE_MASTER_ID"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "  FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Recv:" $r["RECEIVABLE_AMOUNT"] "Paid:" $r["PAID"] "Bal:" $r["BALANCE"]
}
$r.Close()

$cmd.CommandText = @"
SELECT d.FEE_MASTER_ID, m.FEE_MONTH, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT, d.BALANCE
FROM FEE_DETAIL d
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
WHERE m.s_id = '2093'
ORDER BY d.FEE_MASTER_ID, d.FEE_DETAIL_ID
"@
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host "    Detail FM_ID:" $r["FEE_MASTER_ID"] "Month:" $r["FEE_MONTH"] "Head:" $r["Fee_head"] "Amt:" $r["AMOUNT"] "Cat:" $r["Category"] "Curr:" $r["ISCURRENT"] "Bal:" $r["BALANCE"]
}
$r.Close()

# Cleanup
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH IN ('11 2026', '12 2026'));
DELETE FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH IN ('11 2026', '12 2026');
"@
$cmd.ExecuteNonQuery() | Out-Null
$con.Close()
