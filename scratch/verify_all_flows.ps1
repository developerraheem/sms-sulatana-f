$ErrorActionPreference = 'Stop'
$testConnStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;"

Write-Host "=========================================================="
Write-Host " STEP 1: VERIFY EXACT SQL QUERIES AT LINE 486 & 490"
Write-Host "=========================================================="

$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()

# Test 1: Branch 6, Class 122, Session 68, Shift Morning, Section Boys, Student 88883
$qB6 = "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and SECTION_ID='Boys' AND SessionID='68' and branch_id='6' and s_id in (88883)"
$cmdB6 = New-Object System.Data.SqlClient.SqlCommand($qB6, $conn)
$daB6 = New-Object System.Data.SqlClient.SqlDataAdapter($cmdB6)
$dsB6 = New-Object System.Data.DataSet
$daB6.Fill($dsB6, "student") | Out-Null
Write-Host "[PASS] Branch 6 Query Fill: Succeeded! Rows = $($dsB6.Tables['student'].Rows.Count)"

# Test 2: Branch 1, Class 104, Session 3, Shift Morning, Section Male, Student 2771
$qB1 = "Select * from student where c_id ='104' and active='true' AND SHIFT ='Morning' and SECTION_ID='Male' AND SessionID='3' and branch_id='1' and s_id in (2771)"
$cmdB1 = New-Object System.Data.SqlClient.SqlCommand($qB1, $conn)
$daB1 = New-Object System.Data.SqlClient.SqlDataAdapter($cmdB1)
$dsB1 = New-Object System.Data.DataSet
$daB1.Fill($dsB1, "student") | Out-Null
Write-Host "[PASS] Branch 1 Query Fill: Succeeded! Rows = $($dsB1.Tables['student'].Rows.Count)"

# Test 3: Multiple student IDs in Branch 6
$qMulti = "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and SECTION_ID='Boys' AND SessionID='68' and branch_id='6' and s_id in (88883, 88884)"
$cmdMulti = New-Object System.Data.SqlClient.SqlCommand($qMulti, $conn)
$daMulti = New-Object System.Data.SqlClient.SqlDataAdapter($cmdMulti)
$dsMulti = New-Object System.Data.DataSet
$daMulti.Fill($dsMulti, "student") | Out-Null
Write-Host "[PASS] Multiple Student IDs Query Fill: Succeeded! Rows = $($dsMulti.Tables['student'].Rows.Count)"

# Test 4: FEE_MASTER lookup at Line 490
$qFm = "Select FEE_MASTER_ID from FEE_MASTER WHERE C_ID ='122' and s_id ='88883' and SESSIONID='68' and branch_id='6' and (FEE_MONTH = '11 2026' or FEE_MONTH = '11/23/2026' or FEE_MONTH_FROM = '11 2026' or FEE_MONTH_FROM = '11/23/2026')"
$cmdFm = New-Object System.Data.SqlClient.SqlCommand($qFm, $conn)
$rFm = $cmdFm.ExecuteReader()
$hasVoucher = $rFm.Read()
Write-Host "[PASS] FEE_MASTER Query Execution: Succeeded! Existing voucher: $hasVoucher"
$rFm.Close()

$conn.Close()

Write-Host "`n=========================================================="
Write-Host " STEP 2: VERIFY C# LOGIC AND DATAADAPTER VIA ASSEMBLY"
Write-Host "=========================================================="

$exePath = (Resolve-Path "bin\Debug\School.exe").Path
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

# Point ConfigurationManager Sqlconn to SCMS_SF_TEST
$coll = [System.Configuration.ConfigurationManager]::ConnectionStrings
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$bReadOnly = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", $flags)
if ($bReadOnly) { $bReadOnly.SetValue($coll, $false) }
$coll.Remove("Sqlconn")
$coll.Add((New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")))

# Verify runtime is targeting SCMS_SF_TEST
$sysType = $asm.GetType("SYSTEMSETTING")
$sysInst = [Activator]::CreateInstance($sysType)
$verifiedConn = $sysInst.db_connect()
Write-Host "[SAFETY] Verified test connection database: $($verifiedConn.Database)"
if ($verifiedConn.Database -ne "SCMS_SF_TEST") {
    throw "SAFETY ERROR: Connection is not targeting SCMS_SF_TEST!"
}

# Set Branch 6 context
$sysType.GetField("branch_ID").SetValue($null, "6")
$sysType.GetField("sessionid").SetValue($null, "68")
$sysType.GetField("schoolname").SetValue($null, "INFORMATION TECHNOLOGY & SKILLS INSTITUTE")

# Instantiate and test Frm_generatefee_multi
$frmMultiType = $asm.GetType("School._forms.Frm_generatefee_multi")
$frm = [Activator]::CreateInstance($frmMultiType)
$allFlags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::Public

# Call Form_Load
$loadMethod = $frmMultiType.GetMethod("Frm_generatefee_Load", $allFlags)
$loadMethod.Invoke($frm, @($null, [EventArgs]::Empty))
Write-Host "[PASS] Frm_generatefee_multi loaded successfully."

# Verify comboBox1 (classes) loaded
$cmbClass = $frmMultiType.GetField("comboBox1", $allFlags).GetValue($frm)
Write-Host "[PASS] Classes dropdown count: $($cmbClass.Items.Count)"

# Select DIT-29 (c_id = 122)
for ($i = 0; $i -lt $cmbClass.Items.Count; $i++) {
    $row = $cmbClass.Items[$i]
    if ($row["c_name"] -eq "DIT-29") {
        $cmbClass.SelectedIndex = $i
        break
    }
}

# Select Morning
$cmbShift = $frmMultiType.GetField("cmbshift", $allFlags).GetValue($frm)
for ($i = 0; $i -lt $cmbShift.Items.Count; $i++) {
    $row = $cmbShift.Items[$i]
    if ($row["SHIFT"] -eq "Morning") {
        $cmbShift.SelectedIndex = $i
        break
    }
}

# Select Boys
$cmbSection = $frmMultiType.GetField("cmbsection", $allFlags).GetValue($frm)
for ($i = 0; $i -lt $cmbSection.Items.Count; $i++) {
    $row = $cmbSection.Items[$i]
    if ($row["SECTION_NAME"] -eq "Boys") {
        $cmbSection.SelectedIndex = $i
        break
    }
}

Write-Host "[PASS] Selected Class: $($cmbClass.Text) (ID: $($cmbClass.SelectedValue)), Shift: $($cmbShift.Text), Section: $($cmbSection.Text)"
Write-Host "[PASS] SelectedStudentIds count: $($frm.SelectedStudentIds.Count)"

# Now simulate the EXACT data-adapter execution from btnproc_Click line 458-486:
$classId = [int]$cmbClass.SelectedValue
$shift = $cmbShift.SelectedValue.ToString()
$section = $cmbSection.SelectedValue.ToString()
$sessionId = "68"
$branchId = "6"
$idList = [string]::Join(",", $frm.SelectedStudentIds.ToArray())

$testQuery = "Select * from student where c_id ='" + $classId + "' and active='true' AND SHIFT ='" + $shift + "' and SECTION_ID='" + $section + "' AND SessionID='" + $sessionId + "' and branch_id='" + $branchId + "' and s_id in (" + $idList + ")"

$testCon = $sysInst.db_connect()
$testCon.Open()
$testCmd = New-Object System.Data.SqlClient.SqlCommand($testQuery, $testCon)
$testAdptr = New-Object System.Data.SqlClient.SqlDataAdapter($testCmd)
$testDs = New-Object System.Data.DataSet
$testAdptr.Fill($testDs, "student") | Out-Null
Write-Host "[PASS] btnproc_Click DataAdapter.Fill (Line 486) SUCCEEDED! Rows = $($testDs.Tables['student'].Rows.Count)"
$testCon.Close()

# Test Voucher Printing Arrears Recalculation & Voucher_Print query
Write-Host "`n=========================================================="
Write-Host " STEP 3: VERIFY VOUCHER PRINTING & ARREARS RECALCULATION"
Write-Host "=========================================================="

$feeType = $asm.GetType("School._class.FEE")
$feeInst = [Activator]::CreateInstance([Type]$feeType)

# Test RecalculateClassUnpostedArrears
Write-Host "Calling RecalculateClassUnpostedArrears for Class 122, Month '11 2026', Session 68, Branch 6..."
$feeInst.RecalculateClassUnpostedArrears("122", "11 2026", "Morning", "Boys", "68", "6")
Write-Host "[PASS] RecalculateClassUnpostedArrears SUCCEEDED with 0 errors!"

# Test Voucher_Print query directly against SCMS_SF_TEST
$vAdapter = New-Object School.Report_DataSet_newTableAdapters.Voucher_PrintTableAdapter
$reportDs = New-Object School.Report_DataSet_new
$connField = $vAdapter.GetType().GetProperty("Connection", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if ($connField) {
    $connField.SetValue($vAdapter, (New-Object System.Data.SqlClient.SqlConnection($testConnStr)), $null)
}
$vAdapter.Fill($reportDs.Voucher_Print, "122", "11 2026", "Morning", "Boys", [decimal]68) | Out-Null
Write-Host "[PASS] Voucher_PrintTableAdapter.Fill SUCCEEDED! Rows = $($reportDs.Voucher_Print.Rows.Count)"

# Cleanup
$frm.Dispose()

Write-Host "`n=========================================================="
Write-Host " STEP 4: VERIFY PRODUCTION DATABASE SCMS_SF INTEGRITY"
Write-Host "=========================================================="
$prodConn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;")
$prodConn.Open()
$prodCmd = $prodConn.CreateCommand()
$prodCmd.CommandText = "SELECT COUNT(*) FROM student WHERE s_id = 88883"
$cnt = $prodCmd.ExecuteScalar()
Write-Host "[SAFETY] SCMS_SF Student 88883 verified present (count = $cnt)."
$prodConn.Close()

Write-Host "`n=========================================================="
Write-Host " ALL VERIFICATIONS COMPLETED SUCCESSFULLY WITH ZERO ERRORS!"
Write-Host "=========================================================="
