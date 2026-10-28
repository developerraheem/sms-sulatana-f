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

Write-Host "--- SCENARIO 3: GENERATE NOVEMBER AND DECEMBER SEQUENTIALLY ---"
# Step 1: Generate November
$feeNov = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeNov, @($cid, "11 2026", "Morning", $sid, 1, "11 2026", "2026-11-10", "1", "0", "Test Note", "2026-11-01", "2026-11-01", "2026-11-30", "Female"))

# Step 2: Generate December
$feeDec = [System.Activator]::CreateInstance($feeType)
$genMulti.Invoke($feeDec, @($cid, "12 2026", "Morning", $sid, 1, "12 2026", "2026-12-10", "1", "0", "Test Note", "2026-12-01", "2026-12-01", "2026-12-31", "Female"))

# Step 3: Inspect both vouchers
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$sid' AND SessionID = '12' ORDER BY FEE_MASTER_ID"
$r = $cmd.ExecuteReader()
$vouchers = @()
while($r.Read()) {
    $vouchers += @{
        Id = $r["FEE_MASTER_ID"].ToString()
        Month = $r["FEE_MONTH"].ToString()
        Receivable = [double]$r["RECEIVABLE_AMOUNT"]
        Balance = [double]$r["BALANCE"]
        Paid = if ($r["PAID"] -ne [DBNull]::Value) { $r["PAID"].ToString() } else { "NULL" }
    }
}
$r.Close()

Write-Host "Generated Vouchers count: $($vouchers.Count)"
foreach ($v in $vouchers) {
    Write-Host "  Voucher ID: $($v.Id), Month: $($v.Month), Receivable: $($v.Receivable), Balance: $($v.Balance), Paid: '$($v.Paid)'"
}

# Inspect November details for arrears
$novId = $vouchers[0].Id
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$novId' AND SessionID = '12' AND Fee_head_id = '40'"
$novArrearCount = [int]$cmd.ExecuteScalar()

# Inspect December details for arrears
$decId = $vouchers[1].Id
$cmd.CommandText = "SELECT AMOUNT FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$decId' AND SessionID = '12' AND Fee_head_id = '40'"
$decArrearAmt = [double]$cmd.ExecuteScalar()

Write-Host "`n--- SCENARIO 3 RESULTS ---"
Write-Host "November Arrear Lines: $novArrearCount (expected 0)"
Write-Host "December Arrear Amount: $decArrearAmt (expected $($vouchers[0].Receivable))"
Write-Host "December Total:         $($vouchers[1].Receivable) (expected $($vouchers[0].Receivable * 2))"

$pass = ($vouchers.Count -eq 2) -and ($novArrearCount -eq 0) -and ($decArrearAmt -eq $vouchers[0].Receivable) -and ($vouchers[1].Receivable -eq ($vouchers[0].Receivable * 2))
if ($pass) {
    Write-Host "SCENARIO 3 RESULT: PASS" -ForegroundColor Green
} else {
    Write-Host "SCENARIO 3 RESULT: FAIL" -ForegroundColor Red
}

$con.Close()
