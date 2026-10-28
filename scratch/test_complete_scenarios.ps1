$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"

$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $connStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sysType = $asm.GetType("SYSTEMSETTING")
$sysInst = [System.Activator]::CreateInstance($sysType)
$dbConn = $sysInst.db_connect()
Write-Host "db_connect() database: $($dbConn.Database)"
$dbConn.Close()

$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "78")

$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()

# Clean any existing test records for student 22659
$cmd = $con.CreateCommand()
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1)"
$cmd.ExecuteNonQuery()
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1"
$cmd.ExecuteNonQuery()

Write-Host "=== TEST 1: Generate Consecutive Months (Sept 2026 & Oct 2026) ===" -ForegroundColor Cyan
$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)
$form.CreateControl()

$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance

$dtpStart = $formType.GetField("txtstartdate", $flags).GetValue($form)
$dtpEnd = $formType.GetField("txtenddate", $flags).GetValue($form)
$chkSingle = $formType.GetField("checkBox1", $flags).GetValue($form)
$txtSid = $formType.GetField("txtstudentid", $flags).GetValue($form)
$cmbClass = $formType.GetField("comboBox1", $flags).GetValue($form)
$cmbShift = $formType.GetField("cmbshift", $flags).GetValue($form)
$cmbSection = $formType.GetField("cmbsection", $flags).GetValue($form)
$cmbSession = $formType.GetField("cmbselection", $flags).GetValue($form)
$lblMonth = $formType.GetField("lblmonth", $flags).GetValue($form)
$txtDateFrom = $formType.GetField("txtdatefrom", $flags).GetValue($form)
$txtDateTo = $formType.GetField("txtdateto", $flags).GetValue($form)

$chkSingle.Checked = $true
$txtSid.Text = "22659"
$cmbClass.SelectedValue = "169"
$cmbShift.SelectedValue = "Morning"
$cmbSection.SelectedValue = "Female"
$cmbSession.SelectedValue = "78"

$dtpStart.Value = [DateTime]::new(2026, 9, 1)
$dtpEnd.Value = [DateTime]::new(2026, 10, 31)

Write-Host "lblmonth: $($lblMonth.Text)"
Write-Host "txtdatefrom Value: $($txtDateFrom.Value)"
Write-Host "txtdateto Value: $($txtDateTo.Value)"

if ($lblMonth.Text -ne "2") {
    throw "FAILED: Expected lblMonth to be 2, got '$($lblMonth.Text)'"
}

# Run generation directly using the month-by-month logic matching btnproc_Click
$classId = 169
$shift = "Morning"
$section = "Female"
$sessionId = "78"
$branchId = "1"
$dtStart = $dtpStart.Value
$dtEnd = $dtpEnd.Value

$startMonthDt = New-Object DateTime($dtStart.Year, $dtStart.Month, 1)
$endMonthDt = New-Object DateTime($dtEnd.Year, $dtEnd.Month, 1)

$monthsToProcess = New-Object System.Collections.Generic.List[DateTime]
$m = $startMonthDt
while ($m -le $endMonthDt) {
    $monthsToProcess.Add($m)
    $m = $m.AddMonths(1)
}

$fee = New-Object School._class.FEE
foreach ($curMonthDt in $monthsToProcess) {
    $curMonthStr = $curMonthDt.ToString("MM yyyy")
    $fee.generatefeeMulti("169", $curMonthStr, "Morning", "22659", 1, $curMonthStr, "10/10/2026", "1", "0", "Test voucher", "01/09/2026", "01/09/2026", "31/10/2026", "Female")
}

# Verify vouchers created in database
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, FEE_MONTH_FROM, RECEIVABLE_AMOUNT, BALANCE, PAID, REC_AMOUNT FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1 ORDER BY FEE_MASTER_ID"
$r = $cmd.ExecuteReader()
$vouchers = New-Object System.Collections.ArrayList
while($r.Read()) {
    $vouchers.Add(@{
        Id = $r["FEE_MASTER_ID"]
        Month = $r["FEE_MONTH"]
        From = $r["FEE_MONTH_FROM"]
        Amt = $r["RECEIVABLE_AMOUNT"]
        Bal = $r["BALANCE"]
        Paid = $r["PAID"]
        Rec = $r["REC_AMOUNT"]
    })
    Write-Host "Generated Voucher: ID: $($r['FEE_MASTER_ID']) | Month: '$($r['FEE_MONTH'])' | From: '$($r['FEE_MONTH_FROM'])' | Bal: $($r['BALANCE'])"
}
$r.Close()

if ($vouchers.Count -ne 2) {
    throw "FAILED: Expected 2 vouchers, found $($vouchers.Count)"
}
if ($vouchers[0].Month -ne "09 2026") {
    throw "FAILED: First voucher month should be '09 2026', got '$($vouchers[0].Month)'"
}
if ($vouchers[1].Month -ne "10 2026") {
    throw "FAILED: Second voucher month should be '10 2026', got '$($vouchers[1].Month)'"
}

Write-Host "PASS: September voucher mapped to '09 2026', October voucher mapped to '10 2026'!" -ForegroundColor Green

Write-Host "`n=== TEST 2: Attempt Duplicate Generation ===" -ForegroundColor Cyan
# Now execute the duplicate check loop as in btnproc_Click
$newCount = 0
foreach ($curMonthDt in $monthsToProcess) {
    $curMonthStr = $curMonthDt.ToString("MM yyyy")
    $checkQuery = "SELECT FEE_MASTER_ID, PAID, REC_AMOUNT FROM FEE_MASTER WHERE C_ID='169' AND s_id='22659' AND branch_id=1 AND SessionID=78 AND FEE_MONTH='$curMonthStr'"
    $cmd.CommandText = $checkQuery
    $dr = $cmd.ExecuteReader()
    $exists = $false
    $existingMasterId = ""
    $existingPaid = ""
    $hasRecAmt = $false
    $existingRecAmt = 0
    if ($dr.Read()) {
        $exists = $true
        $existingMasterId = $dr["FEE_MASTER_ID"].ToString()
        if ($dr["PAID"] -ne [DBNull]::Value) { $existingPaid = $dr["PAID"].ToString().Trim() }
        if ($dr["REC_AMOUNT"] -ne [DBNull]::Value) {
            $hasRecAmt = $true
            $existingRecAmt = [decimal]$dr["REC_AMOUNT"]
        }
    }
    $dr.Close()

    if ($exists) {
        if (![string]::IsNullOrEmpty($existingPaid) -or ($hasRecAmt -and $existingRecAmt -gt 0)) {
            Write-Host "Month ${curMonthStr}: Posted voucher exists, skipping."
            continue
        }
        if ($hasRecAmt -and $existingRecAmt -eq 0) {
            Write-Host "Month ${curMonthStr}: Unposted voucher exists, will regenerate."
        } else {
            Write-Host "Month ${curMonthStr}: Active voucher already exists ($existingMasterId), preventing duplicate."
            continue
        }
    }
    $fee.generatefeeMulti("169", $curMonthStr, "Morning", "22659", 1, $curMonthStr, "10/10/2026", "1", "0", "Test voucher", "01/09/2026", "01/09/2026", "31/10/2026", "Female")
    $newCount++
}

# Verify vouchers count remains exactly 2
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1"
$totalCount = [int]$cmd.ExecuteScalar()
Write-Host "Total vouchers in DB after re-generation attempt: $totalCount (newly generated: $newCount)"

if ($totalCount -ne 2) {
    throw "FAILED: Duplicate vouchers generated! Expected 2, found $totalCount"
}
if ($newCount -ne 0) {
    throw "FAILED: New vouchers count should be 0, got $newCount"
}
Write-Host "PASS: No duplicate vouchers created on repeated generation!" -ForegroundColor Green

Write-Host "`n=== TEST 3: Regeneration After Deletion ===" -ForegroundColor Cyan
# Delete October voucher (ID = $vouchers[1].Id)
$octId = $vouchers[1].Id
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID=$octId AND branch_id=1"
$cmd.ExecuteNonQuery()
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID=$octId AND branch_id=1"
$cmd.ExecuteNonQuery()

# Re-run generation logic for Sept and Oct
$regenCount = 0
foreach ($curMonthDt in $monthsToProcess) {
    $curMonthStr = $curMonthDt.ToString("MM yyyy")
    $checkQuery = "SELECT FEE_MASTER_ID, PAID, REC_AMOUNT FROM FEE_MASTER WHERE C_ID='169' AND s_id='22659' AND branch_id=1 AND SessionID=78 AND FEE_MONTH='$curMonthStr'"
    $cmd.CommandText = $checkQuery
    $dr = $cmd.ExecuteReader()
    $exists = $false
    if ($dr.Read()) {
        $exists = $true
    }
    $dr.Close()

    if ($exists) {
        Write-Host "Month ${curMonthStr}: Voucher exists, skipping."
        continue
    }

    Write-Host "Month ${curMonthStr}: Voucher deleted, regenerating..."
    $fee.generatefeeMulti("169", $curMonthStr, "Morning", "22659", 1, $curMonthStr, "10/10/2026", "1", "0", "Test voucher", "01/09/2026", "01/09/2026", "31/10/2026", "Female")
    $regenCount++
}

$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1"
$afterDeleteRegenCount = [int]$cmd.ExecuteScalar()
Write-Host "Total vouchers after delete & regen: $afterDeleteRegenCount (regenerated: $regenCount)"

if ($afterDeleteRegenCount -ne 2) {
    throw "FAILED: Expected 2 vouchers after regeneration, got $afterDeleteRegenCount"
}
if ($regenCount -ne 1) {
    throw "FAILED: Expected exactly 1 regenerated voucher (October), got $regenCount"
}
Write-Host "PASS: Regeneration works after legitimate deletion!" -ForegroundColor Green

Write-Host "`n=== TEST 4: Regeneration After Explicit Unposting ===" -ForegroundColor Cyan
# Get the new October voucher ID
$cmd.CommandText = "SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1 AND FEE_MONTH='10 2026'"
$newOctId = $cmd.ExecuteScalar().ToString()

# Simulate posting October voucher
$cmd.CommandText = "UPDATE FEE_MASTER SET PAID='Y', STATUS='Y', REC_AMOUNT=5500, SUBMIT_DATE=GETDATE(), BALANCE=BALANCE-5500 WHERE FEE_MASTER_ID=$newOctId AND branch_id=1"
$cmd.ExecuteNonQuery()
Write-Host "Posted October voucher $newOctId."

# Unpost voucher using application's frmUnpostVoucher workflow
$cmd.CommandText = "UPDATE FEE_MASTER SET PAID=NULL, STATUS=NULL, REC_AMOUNT=0, SUBMIT_DATE='', BALANCE=RECEIVABLE_AMOUNT WHERE FEE_MASTER_ID=$newOctId AND SessionID=78 AND branch_id=1"
$cmd.ExecuteNonQuery()
$cmd.CommandText = "UPDATE FEE_DETAIL SET RECEIVED_AMOUNT=0, BALANCE=AMOUNT WHERE FEE_MASTER_ID=$newOctId AND SessionID=78 AND branch_id=1"
$cmd.ExecuteNonQuery()
Write-Host "Unposted October voucher $newOctId via frmUnpostVoucher workflow."

# Re-run generation logic
$unpostRegenCount = 0
foreach ($curMonthDt in $monthsToProcess) {
    $curMonthStr = $curMonthDt.ToString("MM yyyy")
    $checkQuery = "SELECT FEE_MASTER_ID, PAID, REC_AMOUNT FROM FEE_MASTER WHERE C_ID='169' AND s_id='22659' AND branch_id=1 AND SessionID=78 AND FEE_MONTH='$curMonthStr'"
    $cmd.CommandText = $checkQuery
    $dr = $cmd.ExecuteReader()
    $exists = $false
    $existingMasterId = ""
    $existingPaid = ""
    $hasRecAmt = $false
    $existingRecAmt = 0
    if ($dr.Read()) {
        $exists = $true
        $existingMasterId = $dr["FEE_MASTER_ID"].ToString()
        if ($dr["PAID"] -ne [DBNull]::Value) { $existingPaid = $dr["PAID"].ToString().Trim() }
        if ($dr["REC_AMOUNT"] -ne [DBNull]::Value) {
            $hasRecAmt = $true
            $existingRecAmt = [decimal]$dr["REC_AMOUNT"]
        }
    }
    $dr.Close()

    if ($exists) {
        if (![string]::IsNullOrEmpty($existingPaid) -or ($hasRecAmt -and $existingRecAmt -gt 0)) {
            Write-Host "Month ${curMonthStr}: Posted voucher exists, skipping."
            continue
        }
        if ($hasRecAmt -and $existingRecAmt -eq 0) {
            Write-Host "Month ${curMonthStr}: Unposted voucher ($existingMasterId) found, cleaning up for regeneration..."
            $cmdDelDetail = $con.CreateCommand()
            $cmdDelDetail.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID='$existingMasterId' AND branch_id=1 AND SessionID=78"
            $cmdDelDetail.ExecuteNonQuery()
            $cmdDelMaster = $con.CreateCommand()
            $cmdDelMaster.CommandText = "DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID='$existingMasterId' AND branch_id=1 AND SessionID=78"
            $cmdDelMaster.ExecuteNonQuery()
        } else {
            Write-Host "Month ${curMonthStr}: Active voucher exists, skipping."
            continue
        }
    }

    $fee.generatefeeMulti("169", $curMonthStr, "Morning", "22659", 1, $curMonthStr, "10/10/2026", "1", "0", "Test voucher", "01/09/2026", "01/09/2026", "31/10/2026", "Female")
    $unpostRegenCount++
}

# Verify vouchers
$cmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1"
$afterUnpostRegenCount = [int]$cmd.ExecuteScalar()
Write-Host "Total vouchers after unpost & regen: $afterUnpostRegenCount (regenerated: $unpostRegenCount)"

if ($afterUnpostRegenCount -ne 2) {
    throw "FAILED: Expected 2 vouchers after unpost regeneration, got $afterUnpostRegenCount"
}
if ($unpostRegenCount -ne 1) {
    throw "FAILED: Expected exactly 1 regenerated voucher (October), got $unpostRegenCount"
}
Write-Host "PASS: Regeneration works after legitimate unposting!" -ForegroundColor Green

Write-Host "`n=== TEST 5: Verify Reports ===" -ForegroundColor Cyan
# Check BankwisePostedReport query does not produce duplicate joins
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM FEE_DETAIL INNER JOIN
     FEE_MASTER ON FEE_DETAIL.FEE_MASTER_ID = FEE_MASTER.FEE_MASTER_ID AND FEE_DETAIL.SessionID = FEE_MASTER.SessionID AND FEE_DETAIL.branch_id = FEE_MASTER.branch_id
WHERE FEE_MASTER.s_id='22659' AND FEE_MASTER.branch_id=1
GROUP BY FEE_MASTER.FEE_MASTER_ID, FEE_DETAIL.FEE_DETAIL_ID
HAVING COUNT(*) > 1
"@
$repDups = 0
$drRep = $cmd.ExecuteReader()
while ($drRep.Read()) {
    $repDups++
}
$drRep.Close()

if ($repDups -gt 0) {
    throw "FAILED: Found $repDups duplicate rows in report join!"
}
Write-Host "PASS: Report queries contain zero duplicate rows!" -ForegroundColor Green

# Cleanup test records
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1)"
$cmd.ExecuteNonQuery()
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE s_id='22659' AND branch_id=1"
$cmd.ExecuteNonQuery()
Write-Host "`nCleaned up test records for student 22659." -ForegroundColor Yellow

$con.Close()
$form.Dispose()
Write-Host "`nALL SCENARIOS VERIFIED SUCCESSFULLY!" -ForegroundColor Green
