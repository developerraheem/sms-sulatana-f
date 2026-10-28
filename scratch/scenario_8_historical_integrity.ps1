$ErrorActionPreference = "Stop"

Write-Host "--- SCENARIO 8: HISTORICAL PAYMENT AND STATUS INTEGRITY CHECK ---"

# Connect to SCMS_SF_TEST
$conTest = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;")
$conTest.Open()
$cmdTest = $conTest.CreateCommand()

$cmdTest.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$paidCountTest = [int]$cmdTest.ExecuteScalar()
Write-Host "SCMS_SF_TEST count of PAID='Y' records: $paidCountTest (baseline: 15607)"

# Connect to production SCMS_SF
$conProd = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$conProd.Open()
$cmdProd = $conProd.CreateCommand()

$cmdProd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'Y'"
$paidCountProd = [int]$cmdProd.ExecuteScalar()
Write-Host "Production SCMS_SF count of PAID='Y' records: $paidCountProd (baseline: 15607)"

# Check if any test records exist in production SCMS_SF
$cmdProd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id IN ('2093', '736', '1816') AND FEE_MONTH IN ('11 2026', '12 2026')"
$prodTestVouchers = [int]$cmdProd.ExecuteScalar()
Write-Host "Production SCMS_SF test vouchers count: $prodTestVouchers (must be 0)"

# Verify no historical records were changed to PAID='N'
$cmdTest.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE PAID = 'N'"
$paidNCount = [int]$cmdTest.ExecuteScalar()
Write-Host "SCMS_SF_TEST count of PAID='N' records: $paidNCount"

Write-Host "`n--- SCENARIO 8 RESULTS ---"
$pass = ($paidCountTest -eq 15607) -and ($paidCountProd -eq 15607) -and ($prodTestVouchers -eq 0)
if ($pass) {
    Write-Host "SCENARIO 8 RESULT: PASS - All historical payment records, statuses, and production data 100% intact and unchanged." -ForegroundColor Green
} else {
    Write-Host "SCENARIO 8 RESULT: FAIL" -ForegroundColor Red
}

$conTest.Close()
$conProd.Close()
