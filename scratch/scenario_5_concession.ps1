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

# Student 736 is in Branch 1, Session 2
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "2")

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$sid = "736"
$cid = "3"
$shift = "Morning"
$sec = "Male (A)"
$sess = "2"

# Clean student 736 session 2 records
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '$sess') AND SessionID = '$sess';
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '$sess';
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "--- SCENARIO 5: STUDENT WITH CONCESSION (STUDENT 736) ---"
$cmd.CommandText = "SELECT s_id, CONCESSION_FEE FROM student WHERE s_id = '$sid' AND branch_id = '1' AND SessionID = '$sess'"
$r = $cmd.ExecuteReader()
$concFee = 0
if ($r.Read()) {
    $concFee = [double]$r["CONCESSION_FEE"]
    Write-Host "Student $sid configured concession: Rs. $concFee"
}
$r.Close()

# Step 1: Generate November
$feeNov = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeNov, @($cid, "11 2026", $shift, $sid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", $sec))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '$sess' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$novId = ""; $novRecv = 0
if ($r.Read()) {
    $novId = $r["FEE_MASTER_ID"].ToString()
    $novRecv = [double]$r["RECEIVABLE_AMOUNT"]
    Write-Host "November Voucher: ID=$novId, Net Receivable=$novRecv"
}
$r.Close()

# Step 2: Generate December
$feeDec = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeDec, @($cid, "12 2026", $shift, $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", $sec))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '$sess' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$decId = ""; $decRecv = 0
if ($r.Read()) {
    $decId = $r["FEE_MASTER_ID"].ToString()
    $decRecv = [double]$r["RECEIVABLE_AMOUNT"]
    Write-Host "December Voucher: ID=$decId, Net Receivable=$decRecv"
}
$r.Close()

# Inspect carried arrears on December
$cmd.CommandText = "SELECT AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND SessionID = '$sess' AND Fee_head_id = '40'"
$decArrearAmt = [double]$cmd.ExecuteScalar()
Write-Host "Carried Arrears on December: $decArrearAmt"

Write-Host "`n--- SCENARIO 5 RESULTS ---"
Write-Host "November Net Billed:     $novRecv (Base fee - $concFee concession)"
Write-Host "December Carried Arrear: $decArrearAmt (expected $novRecv)"
Write-Host "December Total:          $decRecv (expected $($novRecv * 2))"

$pass = ($novRecv -gt 0) -and ($decArrearAmt -eq $novRecv) -and ($decRecv -eq ($novRecv * 2))
if ($pass) {
    Write-Host "SCENARIO 5 RESULT: PASS - Net amount after concession ($novRecv) accurately carried forward." -ForegroundColor Green
} else {
    Write-Host "SCENARIO 5 RESULT: FAIL" -ForegroundColor Red
}

$con.Close()
