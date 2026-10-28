Add-Type -AssemblyName System.Data

$asmPath = Resolve-Path "bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($asmPath)
$feeType = $asm.GetType("School._class.FEE")
$sysType = $asm.GetType("SYSTEMSETTING")

$sysType.GetField("branch_ID", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static).SetValue($null, "6")
$sysType.GetField("sessionid", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static).SetValue($null, "68")

$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '88888')"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE s_id = '88888'"
$cmd.ExecuteNonQuery() | Out-Null

$classId = "8889"
$studentid = "88888"
$shift = "Morning"
$section = "Boys"
$totalMonths = 1
$startMonthStr = "10 2026"
$endMonthStr = "10 2026"
$dueDate = "10/27/2026"
$issueDate = "10/27/2026"
$startDate = "10/27/2026"
$endDate = "10/27/2026"
$branchNum = 6
$sessionNum = 68

$fee = [System.Activator]::CreateInstance($feeType)
$fee.generatefeeMulti($classId, $endMonthStr, $shift, $studentid, $totalMonths, $startMonthStr, $dueDate, $totalMonths.ToString(), "0", "", $issueDate, $startDate, $endDate, $section)

$cmd.CommandText = "SELECT TOP 1 FEE_MASTER_ID FROM FEE_MASTER WHERE C_ID = '$classId' AND s_id = '$studentid' AND FEE_MONTH = '$endMonthStr' AND SessionID = '$sessionNum' AND branch_id = '$branchNum' ORDER BY FEE_MASTER_ID DESC"
$genMasterId = $cmd.ExecuteScalar()
Write-Host "Generated Single-Month FEE_MASTER_ID: $genMasterId"

$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = $genMasterId AND branch_id = '$branchNum' AND SessionID = '$sessionNum'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("MASTER: ID=" + $r["FEE_MASTER_ID"] + ", Month=" + $r["FEE_MONTH"] + ", From=" + $r["FEE_MONTH_FROM"] + ", T_MONTHS=" + $r["T_MONTHS"] + ", RecAmt=" + $r["RECEIVABLE_AMOUNT"])
}
$r.Close()

$cmd.CommandText = "SELECT fd.*, fh.Fee_head FROM FEE_DETAIL fd INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID = $genMasterId"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("DETAIL: Head=" + $r["Fee_head"] + ", Amt=" + $r["AMOUNT"])
}
$r.Close()
$con.Close()
