Add-Type -AssemblyName System.Data

$asmPath = Resolve-Path "bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($asmPath)
$feeType = $asm.GetType("School._class.FEE")
$sysType = $asm.GetType("SYSTEMSETTING")

# Set static fields
$sysType.GetField("branch_ID", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static).SetValue($null, "6")
$sysType.GetField("sessionid", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static).SetValue($null, "68")

# Clean up vouchers for student 88888 and set CONCESSION_FEE = 0 on student to test class concession head alone
$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "UPDATE student SET CONCESSION_FEE = 0 WHERE s_id = '88888'"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '88888')"
$cmd.ExecuteNonQuery() | Out-Null
$cmd.CommandText = "DELETE FROM FEE_MASTER WHERE s_id = '88888'"
$cmd.ExecuteNonQuery() | Out-Null

# Setup parameters matching 3 months selection
$classId = "8889"
$studentid = "88888"
$shift = "Morning"
$section = "Boys"
$totalMonths = 3
$startMonthStr = "10 2026"
$endMonthStr = "12 2026"
$dueDate = "10/27/2026"
$issueDate = "10/27/2026"
$startDate = "10/27/2026"
$endDate = "12/27/2026"
$branchNum = 6
$sessionNum = 68

# Call generatefeeMulti as Frm_generatefee_multi does
$fee = [System.Activator]::CreateInstance($feeType)
$fee.generatefeeMulti($classId, $endMonthStr, $shift, $studentid, $totalMonths, $startMonthStr, $dueDate, $totalMonths.ToString(), "0", "", $issueDate, $startDate, $endDate, $section)

# Get the generated FEE_MASTER_ID
$cmd.CommandText = "SELECT TOP 1 FEE_MASTER_ID FROM FEE_MASTER WHERE C_ID = '$classId' AND s_id = '$studentid' AND FEE_MONTH = '$endMonthStr' AND SessionID = '$sessionNum' AND branch_id = '$branchNum' ORDER BY FEE_MASTER_ID DESC"
$genMasterId = $cmd.ExecuteScalar()
Write-Host "Generated FEE_MASTER_ID: $genMasterId"

# Execute the exact adjustment block from Frm_generatefee_multi.cs
if ($totalMonths -gt 1 -and $genMasterId) {
    $selectDetailsSql = @"
        SELECT fd.FEE_DETAIL_ID, fd.Fee_head_id, fd.AMOUNT, fh.Fee_head, fh.Category, fc.AMOUNT AS BaseAmount, fc.ISMULTIPLY
        FROM FEE_DETAIL fd
        INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id
        LEFT JOIN FEE_CLASS fc ON fc.Fee_head_id = fd.Fee_head_id AND fc.C_ID = '$classId' AND (fc.branch_id = '$branchNum' OR fc.branch_id IS NULL)
        WHERE fd.FEE_MASTER_ID = '$genMasterId' AND fd.branch_id = '$branchNum' AND fd.SessionID = '$sessionNum'
"@
    $daDet = New-Object System.Data.SqlClient.SqlDataAdapter($selectDetailsSql, $con)
    $dtDetails = New-Object System.Data.DataTable
    $daDet.Fill($dtDetails) | Out-Null

    foreach ($dRow in $dtDetails.Rows) {
        $detId = $dRow["FEE_DETAIL_ID"].ToString()
        $hId = $dRow["Fee_head_id"].ToString()
        $hName = $dRow["Fee_head"].ToString().Trim().ToUpper()
        $cat = $dRow["Category"].ToString().Trim().ToUpper()
        $curAmt = [decimal]$dRow["AMOUNT"]

        $isConcession = ($cat -eq "DISCOUNT" -or $cat -eq "CONCESSION" -or $hName.Contains("CONCESSION") -or $hName.Contains("DISCOUNT"))
        $isArrear = ($cat -eq "ARREAR" -or $hName.Contains("ARREAR"))
        $isFine = ($cat -eq "FINE" -or $hName.Contains("FINE"))

        if ($isArrear -or $isFine) {
            continue
        }

        if ($isConcession) {
            $baseConc = 0
            if ($dRow["BaseAmount"] -ne [DBNull]::Value -and [decimal]::TryParse($dRow["BaseAmount"].ToString(), [ref]$baseConc) -and $baseConc -gt 0) {
                $targetConc = -([Math]::Abs($baseConc) * $totalMonths)
                if ($curAmt -ne $targetConc) {
                    $updSql = "UPDATE FEE_DETAIL SET AMOUNT = $targetConc, BALANCE = $targetConc WHERE FEE_DETAIL_ID = $detId"
                    $updCmd = New-Object System.Data.SqlClient.SqlCommand($updSql, $con)
                    $updCmd.ExecuteNonQuery() | Out-Null
                }
            } elseif ($curAmt -gt 0) {
                $targetConc = -([Math]::Abs($curAmt) * $totalMonths)
                $updSql = "UPDATE FEE_DETAIL SET AMOUNT = $targetConc, BALANCE = $targetConc WHERE FEE_DETAIL_ID = $detId"
                $updCmd = New-Object System.Data.SqlClient.SqlCommand($updSql, $con)
                $updCmd.ExecuteNonQuery() | Out-Null
            }
            continue
        }

        $isMultiInClass = $false
        if ($dRow["ISMULTIPLY"] -ne [DBNull]::Value) {
            $mStr = $dRow["ISMULTIPLY"].ToString().Trim()
            $isMultiInClass = (![string]::IsNullOrEmpty($mStr) -and $mStr -ne "0" -and $mStr -ne "false")
        }

        $isMonthlyHead = ($hName.Contains("MONTHLY") -or $hName.Contains("TUITION") -or $hName.Contains("TUTION") -or $isMultiInClass)

        if ($isMonthlyHead) {
            $baseAmt = 0
            if ($dRow["BaseAmount"] -ne [DBNull]::Value -and [decimal]::TryParse($dRow["BaseAmount"].ToString(), [ref]$baseAmt) -and $baseAmt -gt 0) {
            } else {
                $baseAmt = $curAmt
            }

            $targetAmt = $baseAmt * $totalMonths
            if ($curAmt -ne $targetAmt) {
                $updSql = "UPDATE FEE_DETAIL SET AMOUNT = $targetAmt, BALANCE = $targetAmt WHERE FEE_DETAIL_ID = $detId"
                $updCmd = New-Object System.Data.SqlClient.SqlCommand($updSql, $con)
                $updCmd.ExecuteNonQuery() | Out-Null
            }
        }
    }

    $sumSql = "SELECT SUM(AMOUNT) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '$genMasterId' AND branch_id = '$branchNum' AND SessionID = '$sessionNum'"
    $sumCmd = New-Object System.Data.SqlClient.SqlCommand($sumSql, $con)
    $sObj = $sumCmd.ExecuteScalar()
    $totalRec = [decimal]$sObj
    $updMasterSql = "UPDATE FEE_MASTER SET RECEIVABLE_AMOUNT = '$totalRec', BALANCE = '$totalRec' WHERE FEE_MASTER_ID = '$genMasterId' AND branch_id = '$branchNum' AND SessionID = '$sessionNum'"
    $updMasterCmd = New-Object System.Data.SqlClient.SqlCommand($updMasterSql, $con)
    $updMasterCmd.ExecuteNonQuery() | Out-Null
}

# Verify FEE_MASTER
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = $genMasterId AND branch_id = '$branchNum' AND SessionID = '$sessionNum'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("MASTER: ID=" + $r["FEE_MASTER_ID"] + ", Month=" + $r["FEE_MONTH"] + ", From=" + $r["FEE_MONTH_FROM"] + ", T_MONTHS=" + $r["T_MONTHS"] + ", RecAmt=" + $r["RECEIVABLE_AMOUNT"] + ", Balance=" + $r["BALANCE"])
}
$r.Close()

# Verify FEE_DETAIL
$cmd.CommandText = "SELECT fd.*, fh.Fee_head FROM FEE_DETAIL fd INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id WHERE fd.FEE_MASTER_ID = $genMasterId AND fd.branch_id = '$branchNum' AND SessionID = '$sessionNum'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("DETAIL: Head=" + $r["Fee_head"] + ", Amt=" + $r["AMOUNT"] + ", Balance=" + $r["BALANCE"])
}
$r.Close()

$con.Close()
Write-Host "Test completed successfully."
