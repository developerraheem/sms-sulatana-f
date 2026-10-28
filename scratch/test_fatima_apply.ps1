# Set app config to School.exe.config before anything else
$configFile = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe.config"
[AppDomain]::CurrentDomain.SetData("APP_CONFIG_FILE", $configFile)
[Type]::GetType("System.Configuration.ConfigurationManager, System.Configuration")::GetField("s_initState", "NonPublic, Static") | ForEach-Object { $_.SetValue($null, 0) }

$appPath = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
[System.Reflection.Assembly]::LoadFrom($appPath) | Out-Null

# Initialize system settings
[SYSTEMSETTING]::sessionid = "81"
[SYSTEMSETTING]::branch_ID = "2"

Write-Host "=== TEST: Applying Pending Fine to Existing Voucher for Fatima Noor ==="

$fee = New-Object School._class.FEE

# Check state before
$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
Write-Host ("BEFORE - Voucher 2: Receivable=" + $r[0] + ", Balance=" + $r[1])
$r.Close()

$cmd.CommandText = "SELECT FINE_ID, FINE_AMOUNT, active, FEE_MASTER_ID FROM FINE_HISTORY WHERE FINE_ID = '99992'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
Write-Host ("BEFORE - Fine 99992: Amt=" + $r[1] + ", active='" + $r[2] + "', MasterID='" + $r[3] + "'")
$r.Close()

# Apply pending fine to Fatima Noor's existing voucher (MasterID 2, StudentID 22578, Adm 26 701, Month 10 2026)
$applied = $fee.ApplyPendingFinesToExistingVoucher("2", "22578", "26 701", "10 2026", "10 2026")
Write-Host ("Applied Count: " + $applied)

# Check state after
$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
Write-Host ("AFTER - Voucher 2: Receivable=" + $r[0] + ", Balance=" + $r[1])
$r.Close()

$cmd.CommandText = "SELECT FINE_ID, FINE_AMOUNT, active, FEE_MASTER_ID FROM FINE_HISTORY WHERE FINE_ID = '99992'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
Write-Host ("AFTER - Fine 99992: Amt=" + $r[1] + ", active='" + $r[2] + "', MasterID='" + $r[3] + "'")
$r.Close()

# Check FEE_DETAIL rows for Voucher 2
$cmd.CommandText = "SELECT fd.FEE_DETAIL_ID, fh.Fee_head, fh.Category, fd.AMOUNT, fd.FEE_MONTH FROM FEE_DETAIL fd INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID = '2' AND fd.SessionID = '81' AND fd.branch_id = '2'"
$r = $cmd.ExecuteReader()
Write-Host "--- Voucher 2 Fee Details ---"
while ($r.Read()) {
    Write-Host ("Detail: ID=" + $r[0] + " | Head=" + $r[1] + " (" + $r[2] + ") | Amt=" + $r[3] + " | Month=" + $r[4])
}
$r.Close()

# Test Duplicate Prevention: Try applying again!
Write-Host "--- Retrying Apply (Duplicate Prevention Test) ---"
$appliedAgain = $fee.ApplyPendingFinesToExistingVoucher("2", "22578", "26 701", "10 2026", "10 2026")
Write-Host ("Applied Again Count (must be 0): " + $appliedAgain)

$cmd.CommandText = "SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'"
$r = $cmd.ExecuteReader()
$r.Read() | Out-Null
Write-Host ("AFTER RETRY - Voucher 2: Receivable=" + $r[0] + ", Balance=" + $r[1])
$r.Close()

$con.Close()
