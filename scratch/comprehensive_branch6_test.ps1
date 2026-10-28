[void][System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")

$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Output "=========================================================="
Write-Output "COMPREHENSIVE TEST OF ALL FEE REPORTS FOR BRANCH 6"
Write-Output "=========================================================="

# Let's inspect all classes for branch 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT c_id, c_name FROM class WHERE branch_id = 6 ORDER BY c_id"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dtClasses = New-Object System.Data.DataTable
[void]$da.Fill($dtClasses)

# 1. TEST FEE_HISTORY on all Branch 6 classes & vouchers
$dsReport = New-Object School.Report_DataSet_new
$feeHistoryAdapter = New-Object School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter
$connProp = $feeHistoryAdapter.GetType().GetProperty('Connection', [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::NonPublic)
$connProp.SetValue($feeHistoryAdapter, $conn, $null)

# Get distinct parameters used in FEE_MASTER for branch 6
$cmd.CommandText = @"
SELECT DISTINCT fm.SessionID, fm.C_ID, fm.SHIFT, fm.FEE_MONTH
FROM FEE_MASTER fm
WHERE fm.branch_id = 6
ORDER BY fm.SessionID DESC, fm.FEE_MONTH DESC
"@
$dtFMParams = New-Object System.Data.DataTable
[void]$da.Fill($dtFMParams)
Write-Output "Found $($dtFMParams.Rows.Count) distinct parameter sets in FEE_MASTER for branch 6."

$fhDupCount = 0
foreach ($row in $dtFMParams.Rows) {
    $sess = $row['SessionID']
    $cid = $row['C_ID']
    $shift = $row['SHIFT']
    $fm = $row['FEE_MONTH']
    
    $dsReport.FEE_HISTORY.Clear()
    try {
        [void]$feeHistoryAdapter.Fill($dsReport.FEE_HISTORY, $cid.ToString(), $shift.ToString(), $fm.ToString(), [decimal]$sess)
        $dups = $dsReport.FEE_HISTORY | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
        if ($dups.Count -gt 0) {
            Write-Output "FEE_HISTORY.Fill DUP: Session=$sess, Class=$cid, Shift=$shift, Month=$fm -> $($dups.Count) duplicate vouchers!"
            $fhDupCount++
        }
    } catch {
        Write-Output "Error in Fill: $_"
    }
}
Write-Output "Total FEE_HISTORY.Fill duplicate parameter sets: $fhDupCount"

# 2. TEST DateWiseList in FEE_HISTORY
Write-Output "`nTesting DateWiseList for Branch 6 sessions..."
$cmd.CommandText = "SELECT DISTINCT SessionID FROM FEE_MASTER WHERE branch_id = 6"
$dtSess = New-Object System.Data.DataTable
[void]$da.Fill($dtSess)
foreach ($r in $dtSess.Rows) {
    $sess = $r['SessionID']
    $dsReport.FEE_HISTORY.Clear()
    try {
        [void]$feeHistoryAdapter.DateWiseList($dsReport.FEE_HISTORY, [DateTime]'2020-01-01', [DateTime]'2027-01-01', [decimal]$sess, $null)
        $dups = $dsReport.FEE_HISTORY | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
        Write-Output "DateWiseList Session=${sess}: Total rows=$($dsReport.FEE_HISTORY.Rows.Count), Dups=$($dups.Count)"
        if ($dups.Count -gt 0) {
            $dups | Select-Object -First 3 | Format-Table -AutoSize | Out-String | Write-Output
        }
    } catch {
        Write-Output "Error in DateWiseList: $_"
    }
}

# 3. TEST StudentWiseList in FEE_HISTORY
Write-Output "`nTesting StudentWiseList for Branch 6 students..."
$cmd.CommandText = @"
SELECT TOP 100 fm.s_id, fm.SessionID
FROM FEE_MASTER fm
WHERE fm.branch_id = 6
GROUP BY fm.s_id, fm.SessionID
"@
$dtStdSess = New-Object System.Data.DataTable
[void]$da.Fill($dtStdSess)
$swDupCount = 0
foreach ($r in $dtStdSess.Rows) {
    $sid = $r['s_id']
    $sess = $r['SessionID']
    $dsReport.FEE_HISTORY.Clear()
    try {
        [void]$feeHistoryAdapter.StudentWiseList($dsReport.FEE_HISTORY, [decimal]$sid, [decimal]$sess)
        $dups = $dsReport.FEE_HISTORY | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
        if ($dups.Count -gt 0) {
            Write-Output "StudentWiseList DUP: s_id=$sid, Session=$sess -> $($dups.Count) dups"
            $swDupCount++
        }
    } catch {
        Write-Output "Error in StudentWiseList: $_"
    }
}
Write-Output "Total StudentWiseList duplicate cases: $swDupCount"

$conn.Close()
