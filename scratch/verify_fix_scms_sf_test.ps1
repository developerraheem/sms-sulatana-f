$ErrorActionPreference = 'Stop'
$testConnStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;"

Write-Host "=== TEST 1: Direct SQL DataAdapter Fill Simulation with Safe Parameters ==="
$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()

# Test with valid Branch 6, Class 122, Session 68, Student 88883
$q1 = "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and SECTION_ID='Boys' AND SessionID='68' and branch_id='6' and s_id in (88883)"
$cmd1 = New-Object System.Data.SqlClient.SqlCommand($q1, $conn)
$da1 = New-Object System.Data.SqlClient.SqlDataAdapter($cmd1)
$ds1 = New-Object System.Data.DataSet
$da1.Fill($ds1, "student") | Out-Null
Write-Host "Q1 (Branch 6, Student 88883) -> Succeeded! Rows: $($ds1.Tables['student'].Rows.Count)"

# Test with Branch 1
$q2 = "Select * from student where c_id ='104' and active='true' AND SHIFT ='Morning' and SECTION_ID='Male' AND SessionID='3' and branch_id='1' and s_id in (2771)"
$cmd2 = New-Object System.Data.SqlClient.SqlCommand($q2, $conn)
$da2 = New-Object System.Data.SqlClient.SqlDataAdapter($cmd2)
$ds2 = New-Object System.Data.DataSet
$da2.Fill($ds2, "student") | Out-Null
Write-Host "Q2 (Branch 1, Student 2771) -> Succeeded! Rows: $($ds2.Tables['student'].Rows.Count)"

# Test FEE_MASTER query with safe parameters
$qFm1 = "Select FEE_MASTER_ID from FEE_MASTER WHERE C_ID ='122' and s_id ='88883' and SESSIONID='68' and branch_id='6' and (FEE_MONTH = '11 2026' or FEE_MONTH = '11/23/2026')"
$cmdFm1 = New-Object System.Data.SqlClient.SqlCommand($qFm1, $conn)
$r1 = $cmdFm1.ExecuteReader()
$hasFm = $r1.Read()
Write-Host "Q_FM (Branch 6 Voucher Check) -> Succeeded! Existing Voucher Found: $hasFm"
$r1.Close()

# Test what happens when branch_id / sessionid were previously empty strings (the root cause)
# In our new code, if branch_id is empty, it is NOT appended as branch_id='' which broke SQL Server.
$qSafeOmitted = "Select * from student where c_id ='122' and active='true' and s_id in (88883)"
$cmdSafe = New-Object System.Data.SqlClient.SqlCommand($qSafeOmitted, $conn)
$daSafe = New-Object System.Data.SqlClient.SqlDataAdapter($cmdSafe)
$dsSafe = New-Object System.Data.DataSet
$daSafe.Fill($dsSafe, "student") | Out-Null
Write-Host "Q_Safe (Omitted empty branch_id / sessionid) -> Succeeded! Rows: $($dsSafe.Tables['student'].Rows.Count)"

$conn.Close()

Write-Host "`n=== TEST 2: Assembly Load and PrintVouchers Workflow Validation ==="
$exePath = (Resolve-Path "bin\Debug\School.exe").Path
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

# Temporarily point Sqlconn configuration to SCMS_SF_TEST
$coll = [System.Configuration.ConfigurationManager]::ConnectionStrings
$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$bReadOnly = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", $flags)
if ($bReadOnly) { $bReadOnly.SetValue($coll, $false) }
$coll.Remove("Sqlconn")
$coll.Add((New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")))

# Verify connection points to SCMS_SF_TEST
$sysType = $asm.GetType("SYSTEMSETTING")
$sysInst = [Activator]::CreateInstance($sysType)
$testDbConn = $sysInst.db_connect()
Write-Host "SYSTEMSETTING.db_connect() database: $($testDbConn.Database)"
if ($testDbConn.Database -ne "SCMS_SF_TEST") {
    throw "Safety violation: DB connection is not SCMS_SF_TEST!"
}

# Set environment context for Branch 6
$sysType.GetField("branch_ID").SetValue($null, "6")
$sysType.GetField("sessionid").SetValue($null, "68")
$sysType.GetField("schoolname").SetValue($null, "INFORMATION TECHNOLOGY & SKILLS INSTITUTE")

# Instantiate Frm_generatefee_multi
$frmMultiType = $asm.GetType("School._forms.Frm_generatefee_multi")
$frm = [Activator]::CreateInstance($frmMultiType)

# Populate controls
$allFlags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::Public
$cmbClass = $frmMultiType.GetField("comboBox1", $allFlags).GetValue($frm)
$cmbShift = $frmMultiType.GetField("cmbshift", $allFlags).GetValue($frm)
$cmbSection = $frmMultiType.GetField("cmbsection", $allFlags).GetValue($frm)
$cmbSession = $frmMultiType.GetField("cmbselection", $allFlags).GetValue($frm)
$txtDateTo = $frmMultiType.GetField("txtdateto", $allFlags).GetValue($frm)
$txtDateFrom = $frmMultiType.GetField("txtdatefrom", $allFlags).GetValue($frm)

# Trigger Load
$loadMethod = $frmMultiType.GetMethod("Frm_generatefee_Load", $allFlags)
$loadMethod.Invoke($frm, @($null, [EventArgs]::Empty))

# Select DIT-29
for ($i = 0; $i -lt $cmbClass.Items.Count; $i++) {
    $row = $cmbClass.Items[$i]
    if ($row["c_name"] -eq "DIT-29") {
        $cmbClass.SelectedIndex = $i
        break
    }
}

# Select Morning
for ($i = 0; $i -lt $cmbShift.Items.Count; $i++) {
    $row = $cmbShift.Items[$i]
    if ($row["SHIFT"] -eq "Morning") {
        $cmbShift.SelectedIndex = $i
        break
    }
}

# Select Boys
for ($i = 0; $i -lt $cmbSection.Items.Count; $i++) {
    $row = $cmbSection.Items[$i]
    if ($row["SECTION_NAME"] -eq "Boys") {
        $cmbSection.SelectedIndex = $i
        break
    }
}

Write-Host "Form controls populated for Branch 6, DIT-29, Morning, Boys."
Write-Host "SelectedStudentIds count: $($frm.SelectedStudentIds.Count)"

# Test PrintVouchers directly
Write-Host "`nTesting PrintVouchers with selected student IDs..."
try {
    $frm.PrintVouchers($frm.SelectedStudentIds)
    Write-Host "PrintVouchers SUCCEEDED with 0 errors!"
} catch {
    Write-Host "PrintVouchers FAILED: $($_.Exception.InnerException.Message)"
    throw $_.Exception.InnerException
}

# Test with Branch 1
Write-Host "`nTesting Branch 1 (Islamabad College of Business and Informatics)..."
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "3")
$frmB1 = [Activator]::CreateInstance($frmMultiType)
$loadMethod.Invoke($frmB1, @($null, [EventArgs]::Empty))
Write-Host "Branch 1 Form Load -> Succeeded! Classes count: $($frmMultiType.GetField('comboBox1', $allFlags).GetValue($frmB1).Items.Count)"

$frm.Dispose()
$frmB1.Dispose()

Write-Host "`n=== ALL TESTS PASSED SUCCESSFULLY! ==="
