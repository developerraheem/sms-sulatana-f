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

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "12")

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$sid = "2093"
$cid = "64"

# Clean test student 2093 session 12 records
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

Write-Host "--- SCENARIO 4: REPEATED GENERATION OF DECEMBER ---"
# Step 1: Generate November
$feeNov = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeNov, @($cid, "11 2026", "Morning", $sid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

# Step 2: Generate December 1st time
$feeDec1 = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeDec1, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$dec1Id = ""; $dec1Recv = 0
if ($r.Read()) {
    $dec1Id = $r["FEE_MASTER_ID"].ToString()
    $dec1Recv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "December 1st Generation: ID=$dec1Id, Receivable=$dec1Recv"

# Part A: Try generating December AGAIN while it already exists
$feeDecAgain = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeDecAgain, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '12 2026'"
$decCount = [int]$cmd.ExecuteScalar()
Write-Host "Part A - Vouchers for December after calling generation again: $decCount (must remain 1, preventing unintended duplicates)"

# Part B: Delete December voucher and regenerate it
$cmd.CommandText = @"
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$dec1Id' AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '$dec1Id' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

$feeDecRegen = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeDecRegen, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

$cmd.CommandText = "SELECT FEE_MASTER_ID, RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' AND FEE_MONTH = '12 2026'"
$r = $cmd.ExecuteReader()
$dec2Id = ""; $dec2Recv = 0
if ($r.Read()) {
    $dec2Id = $r["FEE_MASTER_ID"].ToString()
    $dec2Recv = [double]$r["RECEIVABLE_AMOUNT"]
}
$r.Close()
Write-Host "Part B - December Re-generation: ID=$dec2Id, Receivable=$dec2Recv (must equal 1st generation: $dec1Recv)"

# Inspect arrears on regenerated December
$cmd.CommandText = "SELECT AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$dec2Id' AND SessionID = '12' AND Fee_head_id = '40'"
$decRegenArrear = [double]$cmd.ExecuteScalar()
Write-Host "Part B - Carried Arrears on Re-generated December: $decRegenArrear"

Write-Host "`n--- SCENARIO 4 RESULTS ---"
$pass = ($decCount -eq 1) -and ($dec1Recv -eq $dec2Recv) -and ($decRegenArrear -eq 9000)
if ($pass) {
    Write-Host "SCENARIO 4 RESULT: PASS" -ForegroundColor Green
} else {
    Write-Host "SCENARIO 4 RESULT: FAIL" -ForegroundColor Red
}

$con.Close()
