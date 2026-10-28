$ErrorActionPreference = "Stop"

$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)
$sysType = $asm.GetType("SYSTEMSETTING")
$feeType = $asm.GetType("School._class.FEE")
$genMulti = $feeType.GetMethod("generatefeeMulti")

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

Write-Host "--- SCENARIO 6: BRANCH ISOLATION & DYNAMIC ARREARS HEAD (BRANCH 1 VS BRANCH 6) ---"

# Step 1: Dynamic Arrear Head ID resolution
$feeInstance = [System.Activator]::CreateInstance($feeType)
$headB1 = $feeInstance.GetBranchArrearHeadId("1")
$headB6 = $feeInstance.GetBranchArrearHeadId("6")
Write-Host "Branch 1 Arrear Head Resolved: $headB1 (expected 40)"
Write-Host "Branch 6 Arrear Head Resolved: $headB6 (expected 103)"

# Step 2: Branch 1 Generation
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")
$b1Sid = "2093"; $b1Cid = "64"

$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$b1Sid' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$b1Sid' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

$feeB1Nov = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeB1Nov, @($b1Cid, "11 2026", "Morning", $b1Sid, 1, "11 2026", "2026-11-10", "1", "0", "Test B1", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

$feeB1Dec = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeB1Dec, @($b1Cid, "12 2026", "Morning", $b1Sid, 1, "12 2026", "2026-12-10", "1", "0", "Test B1", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = @"
SELECT d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT
FROM FEE_DETAIL d
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID AND d.SessionID = m.SessionID
WHERE m.s_id = '$b1Sid' AND m.SessionID = '12' AND m.FEE_MONTH = '12 2026' AND d.ISCURRENT = 'N'
"@
$r = $cmd.ExecuteReader()
$b1DecArrearHead = ""; $b1DecArrearAmt = 0
if ($r.Read()) {
    $b1DecArrearHead = $r["Fee_head_id"].ToString()
    $b1DecArrearAmt = [double]$r["AMOUNT"]
}
$r.Close()
Write-Host "Branch 1 December Arrear Line Item: Head_ID=$b1DecArrearHead (expected 40), Amount=$b1DecArrearAmt"

# Step 3: Branch 6 Generation
$cmd.CommandText = "SELECT TOP 1 s_id, c_id, SHIFT, SECTION_ID, SessionID FROM student WHERE branch_id = '6' AND active = 'true' ORDER BY s_id"
$r = $cmd.ExecuteReader()
$b6Sid = ""; $b6Cid = ""; $b6Shift = ""; $b6Sec = ""; $b6Sess = ""
if ($r.Read()) {
    $b6Sid = $r["s_id"].ToString(); $b6Cid = $r["c_id"].ToString(); $b6Shift = $r["SHIFT"].ToString(); $b6Sec = $r["SECTION_ID"].ToString(); $b6Sess = $r["SessionID"].ToString()
}
$r.Close()

$sysType.GetField("branch_ID").SetValue($null, "6")
$sysType.GetField("sessionid").SetValue($null, $b6Sess)

Write-Host "Selected Branch 6 Student: s_id=$b6Sid, c_id=$b6Cid, shift=$b6Shift, sec=$b6Sec, session=$b6Sess"

$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$b6Sid' AND SessionID = '$b6Sess') AND SessionID = '$b6Sess';
DELETE FROM FEE_MASTER WHERE s_id = '$b6Sid' AND SessionID = '$b6Sess';
"@
$cmd.ExecuteNonQuery() | Out-Null

$feeB6Nov = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeB6Nov, @($b6Cid, "11 2026", $b6Shift, $b6Sid, 1, "11 2026", "2026-11-10", "1", "0", "Test B6", "2026-11-01", "2026-11-01", "2026-11-30", $b6Sec))

$feeB6Dec = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeB6Dec, @($b6Cid, "12 2026", $b6Shift, $b6Sid, 1, "12 2026", "2026-12-10", "1", "0", "Test B6", "2026-12-01", "2026-12-01", "2026-12-31", $b6Sec))

$cmd.CommandText = @"
SELECT d.Fee_head_id, h.Fee_head, h.Category, d.AMOUNT, d.ISCURRENT
FROM FEE_DETAIL d
JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id
JOIN FEE_MASTER m ON d.FEE_MASTER_ID = m.FEE_MASTER_ID AND d.SessionID = m.SessionID
WHERE m.s_id = '$b6Sid' AND m.SessionID = '$b6Sess' AND m.FEE_MONTH = '12 2026' AND d.ISCURRENT = 'N'
"@
$r = $cmd.ExecuteReader()
$b6DecArrearHead = ""; $b6DecArrearAmt = 0
if ($r.Read()) {
    $b6DecArrearHead = $r["Fee_head_id"].ToString()
    $b6DecArrearAmt = [double]$r["AMOUNT"]
}
$r.Close()
Write-Host "Branch 6 December Arrear Line Item: Head_ID=$b6DecArrearHead (expected 103), Amount=$b6DecArrearAmt"

# Step 4: Verify Cross-Branch Data Isolation
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE branch_id = '6' AND s_id = '$b1Sid'"
$b6HasB1 = [int]$cmd.ExecuteScalar()

$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE branch_id = '1' AND s_id = '$b6Sid'"
$b1HasB6 = [int]$cmd.ExecuteScalar()

Write-Host "Cross-branch check: Branch 6 has Branch 1 student: $b6HasB1 (must be 0)"
Write-Host "Cross-branch check: Branch 1 has Branch 6 student: $b1HasB6 (must be 0)"

Write-Host "`n--- SCENARIO 6 RESULTS ---"
$pass = ($headB1 -eq "40") -and ($headB6 -eq "103") -and ($b1DecArrearHead -eq "40") -and ($b6DecArrearHead -eq "103") -and ($b6HasB1 -eq 0) -and ($b1HasB6 -eq 0)
if ($pass) {
    Write-Host "SCENARIO 6 RESULT: PASS - Full voucher generation for Branch 1 (Head 40) and Branch 6 (Head 103) strictly isolated with zero cross-branch data." -ForegroundColor Green
} else {
    Write-Host "SCENARIO 6 RESULT: FAIL" -ForegroundColor Red
}

$con.Close()
