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

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$branchId = "1"
$sessionId = "12"
$classid = "64"
$month = "12 2026"
$SHIFT = "Morning"
$studentid = "2093"
$months = 1
$monthfrom = "12 2026"
$DUE_DATE = "2026-12-10"
$tmonths = "1"
$tfine = "0"
$remarks = "Dec fee"
$ISSUE_DATE = "2026-12-01"
$startdate = "2026-12-01"
$enddate = "2026-12-31"
$sectionID = "Female"

# What does GetMasterID return now?
$cmd.CommandText = "select max(convert(int,FEE_MASTER_ID))+1 as ids from FEE_MASTER where SESSIONID='$sessionId'"
$r = $cmd.ExecuteReader()
$master_id = ""
if ($r.Read()) { $master_id = $r[0].ToString() }
$r.Close()
Write-Host "Next master_id: '$master_id'"

# Student query
$qStudent = "Select * from [student] where [c_id] ='$classid' and [active]='true' and SHIFT='$SHIFT' and SessionID='$sessionId' and branch_id='$branchId' AND SECTION_ID='$sectionID' and s_id='$studentid' and [s_id] NOT IN (Select [s_id] from [FEE_MASTER] where [c_id] ='$classid' and [FEE_MONTH]='$month' AND SHIFT ='$SHIFT' AND SESSIONID='$sessionId' and branch_id='$branchId')"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($qStudent, $con)
$dtStudent = New-Object System.Data.DataTable
$da.Fill($dtStudent) | Out-Null
Write-Host "Student rows matched: $($dtStudent.Rows.Count)"

$queries = New-Object System.Collections.Generic.List[string]

foreach ($rowDoc in $dtStudent.Rows) {
    $barcode = "*" + ([System.Guid]::NewGuid().ToString().Substring(0, 3)) + $master_id + "*"
    $qMaster = "Insert into FEE_MASTER(FEE_MASTER_ID,s_id,C_ID,FEE_MONTH,SHIFT,FEE_MONTH_FROM,MULTITAG,SessionID,DUE_DATE,T_MONTHS,FINE_AFTER_DUE_DATE,BARCODE,BRANCH_ID,REMARKS,ISSUE_DATE,startdate,enddate) VALUES('$master_id','$($rowDoc['s_id'])','$classid','$month','$SHIFT','$monthfrom','Y','$sessionId','$DUE_DATE','$tmonths','$tfine','$barcode','$branchId','$remarks','$ISSUE_DATE','$startdate','$enddate')"
    $queries.Add($qMaster)

    # Fee classes
    $qClass = "Select fc.*, fh.Fee_head, fh.Category from FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID='$classid' and fc.ACTIVE='true' AND fc.TYPE='$($rowDoc['TYPE'])' Order by fc.Fee_head_id"
    $daClass = New-Object System.Data.SqlClient.SqlDataAdapter($qClass, $con)
    $dtClass = New-Object System.Data.DataTable
    $daClass.Fill($dtClass) | Out-Null

    $tamount = 0
    foreach ($rowHead in $dtClass.Rows) {
        $headId = $rowHead["Fee_head_id"].ToString()
        $headName = $rowHead["Fee_head"].ToString().Trim().ToUpper()
        $cat = $rowHead["Category"].ToString().Trim().ToUpper()
        if ($cat -eq "ARREAR" -or $headName.Contains("ARREAR")) { continue }
        $amt = [double]$rowHead["AMOUNT"]
        $tamount += $amt
        $qDetail = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SessionID,branch_id) VALUES($master_id,$headId,$amt,'$month','Y','$amt','$monthfrom','$sessionId','$branchId')"
        $queries.Add($qDetail)
    }

    # Arrears!
    # Let's call FEE.GetPreviousOutstandingArrears
    $exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
    $asm = [System.Reflection.Assembly]::LoadFrom($exePath)
    $feeType = $asm.GetType("School._class.FEE")
    $feeInstance = [System.Activator]::CreateInstance($feeType)
    $outstanding = $feeType.GetMethod("GetPreviousOutstandingArrears").Invoke($feeInstance, @($studentid, $month, $master_id, $branchId, $sessionId))
    Write-Host "Outstanding arrears from GetPreviousOutstandingArrears: $outstanding"

    if ($outstanding -gt 0) {
        $arrearHead = $feeType.GetMethod("GetBranchArrearHeadId").Invoke($feeInstance, @($branchId))
        Write-Host "Arrear head: $arrearHead"
        $qArrear = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SessionID,branch_id) VALUES($master_id,'$arrearHead',$outstanding,'$month','N','$outstanding','$monthfrom','$sessionId','$branchId')"
        $queries.Add($qArrear)
        $tamount += $outstanding
    }

    $qUpdateMaster = "Update FEE_MASTER Set RECEIVABLE_AMOUNT='$tamount', BALANCE='$tamount' WHERE FEE_MASTER_ID='$master_id' AND SESSIONID='$sessionId' and branch_id='$branchId'"
    $queries.Add($qUpdateMaster)
    $master_id = ([int64]$master_id + 1).ToString()
}

Write-Host "Total queries to execute: $($queries.Count)"
foreach ($q in $queries) {
    Write-Host "  Query: $q"
}

# Execute with transaction
$tx = $con.BeginTransaction()
$cmd.Transaction = $tx
try {
    foreach ($q in $queries) {
        $cmd.CommandText = $q
        $cmd.ExecuteNonQuery() | Out-Null
    }
    $tx.Commit()
    Write-Host "SUCCESS! All queries executed and committed."
} catch {
    $tx.Rollback()
    Write-Host "FAILED! Error: $($_.Exception.ToString())"
}

$con.Close()
