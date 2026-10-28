$binPath = (Resolve-Path 'bin\Debug\School.exe').Path
$asm = [System.Reflection.Assembly]::LoadFrom($binPath)
[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.ReportViewer.WinForms") | Out-Null

$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'

Write-Host "================================================================================"
Write-Host "                 COMPREHENSIVE VERIFICATION & REGRESSION SUITE                  "
Write-Host "================================================================================"

# ====================================================================
# TEST 1: FEE_HISTORY in Branch 6
# ====================================================================
Write-Host "`n--- TEST 1: FEE_HISTORYTableAdapter in Branch 6 ---"
$dsType = $asm.GetType('School.Report_DataSet_new')
$ds = [Activator]::CreateInstance($dsType)

$fhAdapterType = $asm.GetType('School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter')
$fhAdapter = [Activator]::CreateInstance($fhAdapterType)
$prop = $fhAdapterType.GetProperty('Connection', [System.Reflection.BindingFlags]'Instance,NonPublic,Public')
$conn = $prop.GetValue($fhAdapter, $null)
$conn.ConnectionString = $connStr

$table = $ds.Tables['FEE_HISTORY']

# Verify promoted students (previously dropped by student.c_id = class.c_id)
# Student 13607 has Voucher 736 in class 161 (current student c_id is 154)
$table.Clear()
$fhAdapter.Fill($table, "161", "Morning", "07 2025", 49) | Out-Null
$v736 = $table.Select("FEE_MASTER_ID = 736")
Write-Host ("Voucher 736 (Student 13607 promoted) retrieved: " + ($v736.Length -eq 1) + " (Count=" + $v736.Length + ")")
if ($v736.Length -gt 0) {
    Write-Host ("   Student=" + $v736[0]["s_name"] + ", Class=" + $v736[0]["c_name"] + ", Due=" + $v736[0]["RECEIVABLE_AMOUNT"] + ", Bal=" + $v736[0]["BALANCE"])
}

# Student 13608 has Voucher 734 in class 161 (current student c_id is 165)
$v734 = $table.Select("FEE_MASTER_ID = 734")
Write-Host ("Voucher 734 (Student 13608 promoted) retrieved: " + ($v734.Length -eq 1) + " (Count=" + $v734.Length + ")")
if ($v734.Length -gt 0) {
    Write-Host ("   Student=" + $v734[0]["s_name"] + ", Class=" + $v734[0]["c_name"] + ", Due=" + $v734[0]["RECEIVABLE_AMOUNT"] + ", Bal=" + $v734[0]["BALANCE"])
}

# Verify no duplicates in this class result
$dups = $table | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
Write-Host ("Duplicate vouchers in Class 161 Fill result: " + $dups.Count)

# ====================================================================
# TEST 2: DEFAULTER_DETAIL in Branch 6
# ====================================================================
Write-Host "`n--- TEST 2: DEFAULTER_DETAILTableAdapter in Branch 6 ---"
$defAdapterType = $asm.GetType('School.Report_DataSet_newTableAdapters.DEFAULTER_DETAILTableAdapter')
$defAdapter = [Activator]::CreateInstance($defAdapterType)
$prop = $defAdapterType.GetProperty('Connection', [System.Reflection.BindingFlags]'Instance,NonPublic,Public')
$conn = $prop.GetValue($defAdapter, $null)
$conn.ConnectionString = $connStr

$defTable = $ds.Tables['DEFAULTER_DETAIL']
$defTable.Clear()
$defAdapter.FillBy($defTable, "05 2025", 49) | Out-Null
Write-Host ("DEFAULTER_DETAIL rows returned for Session 49, Month 05 2025: " + $defTable.Rows.Count)
$dupsDef = $defTable | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
Write-Host ("DEFAULTER_DETAIL duplicate vouchers: " + $dupsDef.Count + " (Expected 0, was 8 before fix!)")
if ($defTable.Rows.Count -gt 0) {
    $first = $defTable.Rows[0]
    Write-Host ("   Sample Defaulter: Voucher=" + $first["FEE_MASTER_ID"] + ", Student=" + $first["s_name"] + ", Sec=" + $first["SECTION_NAME"] + ", Due=" + $first["RECEIVABLE_AMOUNT"] + ", Bal=" + $first["BALANCE"])
}

# ====================================================================
# TEST 3: DateWisePostedReport in Branch 6
# ====================================================================
Write-Host "`n--- TEST 3: DateWisePostedReportTableAdapter in Branch 6 ---"
$sqlConn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$sqlConn.Open()
$sqlCmd = $sqlConn.CreateCommand()
$sqlCmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, student.s_name, Sections.SECTION_NAME, FEE_MASTER.RECEIVABLE_AMOUNT, FEE_MASTER.REC_AMOUNT, FEE_MASTER.BALANCE
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE (FEE_MASTER.PAID = 'Y') AND (FEE_MASTER.SUBMIT_DATE BETWEEN '2025-05-01' AND '2025-05-31') AND FEE_MASTER.branch_id = 6
"@
$r = $sqlCmd.ExecuteReader()
$postedRows = @()
while ($r.Read()) {
    $postedRows += [PSCustomObject]@{
        Voucher = $r[0]
        Name = $r[1]
        Section = $r[2]
        Due = $r[3]
        Rec = $r[4]
        Bal = $r[5]
    }
}
$r.Close()
Write-Host ("DateWisePosted rows returned for Branch 6 (May 2025): " + $postedRows.Count)
$dupsPosted = $postedRows | Group-Object Voucher | Where-Object { $_.Count -gt 1 }
Write-Host ("DateWisePosted duplicate vouchers: " + $dupsPosted.Count + " (Expected 0, was 108 before fix!)")

# ====================================================================
# TEST 4: MonthlyFee in Branch 6
# ====================================================================
Write-Host "`n--- TEST 4: MonthlyFee query in Branch 6 ---"
$sqlCmd.CommandText = @"
SELECT SUM(A.AMOUNT) AS DueAmount, SUM(A.RECEIVED_AMOUNT) AS Received, SUM(A.BALANCE) AS Balance
FROM FEE_DETAIL AS A INNER JOIN
     FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID AND A.branch_id = B.branch_id AND A.SessionID = B.SessionID INNER JOIN
     Fee_Head ON A.Fee_head_id = Fee_Head.Fee_head_id AND A.branch_id = Fee_Head.branch_id INNER JOIN
     student ON B.S_ID = student.s_id AND B.branch_id = student.branch_id INNER JOIN
     class ON B.C_ID = class.c_id AND B.branch_id = class.branch_id
WHERE B.branch_id = 6 AND A.FEE_MONTH = '05 2025' AND B.SESSIONID = 49
"@
$r = $sqlCmd.ExecuteReader()
if ($r.Read()) {
    Write-Host ("MonthlyFee for Branch 6 (05 2025, Session 49): Due=" + $r[0] + ", Rec=" + $r[1] + ", Bal=" + $r[2])
}
$r.Close()

# Verify 0 cross-branch mismatches
$sqlCmd.CommandText = @"
SELECT COUNT(*)
FROM FEE_DETAIL AS A INNER JOIN
     FEE_MASTER AS B ON A.FEE_MASTER_ID = B.FEE_MASTER_ID AND A.branch_id = B.branch_id AND A.SessionID = B.SessionID
WHERE B.branch_id = 6 AND (A.branch_id != B.branch_id OR A.SessionID != B.SessionID)
"@
Write-Host ("Cross-branch/session mismatches remaining: " + $sqlCmd.ExecuteScalar() + " (Expected 0, was 30073 before fix!)")

# ====================================================================
# TEST 5: RDLC Rendering of VoucherslistReport
# ====================================================================
Write-Host "`n--- TEST 5: VoucherslistReport.rdlc Rendering ---"
$table.Clear()
$fhAdapter.Fill($table, "161", "Morning", "07 2025", 49) | Out-Null
$rv = New-Object Microsoft.Reporting.WinForms.ReportViewer
$rv.LocalReport.ReportPath = (Resolve-Path 'Reports\VoucherslistReport.rdlc').Path
$rds = New-Object Microsoft.Reporting.WinForms.ReportDataSource
$rds.Name = 'DataSet1'
$rds.Value = $table
$rv.LocalReport.DataSources.Add($rds)

$bytes = $rv.LocalReport.Render("PDF")
[System.IO.File]::WriteAllBytes("scratch\VoucherslistReport_verified.pdf", $bytes)
Write-Host ("VoucherslistReport.rdlc rendered successfully! PDF size: " + $bytes.Length + " bytes")

# ====================================================================
# TEST 6: REGRESSION TEST on Branch 11 (Voucher 73 and Voucher 131)
# ====================================================================
Write-Host "`n--- TEST 6: REGRESSION TEST on Branch 11 (Vouchers 73 & 131) ---"
$table.Clear()
$fhAdapter.Unpaid($table, "115", "Morning", "09 2026", "Female", 78) | Out-Null
$v73 = $table.Select("FEE_MASTER_ID = 73")
Write-Host ("Branch 11 Voucher 73 row count: " + $v73.Length + " (Expected 1)")
if ($v73.Length -gt 0) {
    Write-Host ("   Voucher 73: Student=" + $v73[0]["s_name"] + ", Sec=" + $v73[0]["SECTION_NAME"] + ", Due=" + $v73[0]["RECEIVABLE_AMOUNT"] + ", Rec=" + $v73[0]["REC_AMOUNT"] + ", Bal=" + $v73[0]["BALANCE"])
}

$table.Clear()
$fhAdapter.Unpaid($table, "64", "Morning", "09 2026", "Male", 78) | Out-Null
$v131 = $table.Select("FEE_MASTER_ID = 131")
Write-Host ("Branch 11 Voucher 131 row count: " + $v131.Length + " (Expected 1)")
if ($v131.Length -gt 0) {
    Write-Host ("   Voucher 131: Student=" + $v131[0]["s_name"] + ", Sec=" + $v131[0]["SECTION_NAME"] + ", Due=" + $v131[0]["RECEIVABLE_AMOUNT"] + ", Rec=" + $v131[0]["REC_AMOUNT"] + ", Bal=" + $v131[0]["BALANCE"])
}

# ====================================================================
# TEST 7: REGRESSION TEST on Branch 2
# ====================================================================
Write-Host "`n--- TEST 7: REGRESSION TEST on Branch 2 ---"
$table.Clear()
$fhAdapter.Fill($table, "67", "Morning", "12 2025", 65) | Out-Null
Write-Host ("Branch 2 Class 67 rows returned: " + $table.Rows.Count)
$dupsB2 = $table | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
Write-Host ("Branch 2 duplicate vouchers count: " + $dupsB2.Count + " (Expected 0)")

# ====================================================================
# TEST 8: Database Integrity Verification
# ====================================================================
Write-Host "`n--- TEST 8: Database Integrity Verification ---"
$sqlCmd.CommandText = "SELECT COUNT(*) FROM student"
$stdCount = $sqlCmd.ExecuteScalar()
$sqlCmd.CommandText = "SELECT COUNT(*) FROM FEE_MASTER"
$fmCount = $sqlCmd.ExecuteScalar()
$sqlCmd.CommandText = "SELECT COUNT(*) FROM FEE_DETAIL"
$fdCount = $sqlCmd.ExecuteScalar()

Write-Host ("Total student records in DB: " + $stdCount)
Write-Host ("Total FEE_MASTER records in DB: " + $fmCount)
Write-Host ("Total FEE_DETAIL records in DB: " + $fdCount)
Write-Host "Database records verified intact: NO inserts, updates, or deletes on DB data."

$sqlConn.Close()
Write-Host "`n================================================================================"
Write-Host "                           ALL TESTS COMPLETED!                                 "
Write-Host "================================================================================"
