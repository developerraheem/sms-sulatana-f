$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Output "=========================================================="
Write-Output "DETAILED INSPECTION OF VOUCHERS 73 & 131 IN BRANCH 6"
Write-Output "=========================================================="

$vouchers = @(
    @{ Id = 73; Sess = 49; Cid = 127; Month = '05 2024'; Sid = 8464 },
    @{ Id = 73; Sess = 68; Cid = 167; Month = '04 2026'; Sid = 20269 },
    @{ Id = 131; Sess = 68; Cid = 177; Month = '05 2026'; Sid = 20379 }
)

foreach ($v in $vouchers) {
    $id = $v.Id
    $sess = $v.Sess
    $cid = $v.Cid
    $month = $v.Month
    $sid = $v.Sid
    
    Write-Output "`n--- Testing Voucher $id (Session $sess, Class $cid, Month $month, s_id $sid) ---"
    
    # 1. Check FEE_MASTER row
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = $id AND branch_id = 6 AND SessionID = $sess"
    $da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    $dtFM = New-Object System.Data.DataTable
    [void]$da.Fill($dtFM)
    Write-Output "FEE_MASTER rows: $($dtFM.Rows.Count)"
    $dtFM | Select-Object FEE_MASTER_ID, s_id, C_ID, SessionID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, branch_id | Format-Table -AutoSize | Out-String | Write-Output
    
    # 2. Check student row
    $cmd.CommandText = "SELECT s_id, s_name, f_name, ADMISSION_NO, SECTION_ID, branch_id, SessionID, c_id FROM student WHERE s_id = $sid"
    $dtS = New-Object System.Data.DataTable
    [void]$da.Fill($dtS)
    Write-Output "student rows for ${sid}: $($dtS.Rows.Count)"
    $dtS | Format-Table -AutoSize | Out-String | Write-Output
    
    # 3. Check Section
    $secId = $dtS.Rows[0]['SECTION_ID']
    $cmd.CommandText = "SELECT * FROM Sections WHERE SECTION_ID = '$secId'"
    $dtSec = New-Object System.Data.DataTable
    [void]$da.Fill($dtSec)
    Write-Output "Sections matching '$secId': $($dtSec.Rows.Count)"
    $dtSec | Format-Table -AutoSize | Out-String | Write-Output
    
    # 4. Check FEE_DETAIL rows
    $cmd.CommandText = "SELECT * FROM FEE_DETAIL WHERE FEE_MASTER_ID = $id AND SessionID = $sess AND branch_id = 6"
    $dtFD = New-Object System.Data.DataTable
    [void]$da.Fill($dtFD)
    Write-Output "FEE_DETAIL rows: $($dtFD.Rows.Count)"
    $dtFD | Select-Object FEE_DETAIL_ID, FEE_MASTER_ID, Fee_head_id, AMOUNT, RECEIVED_AMOUNT, BALANCE, SessionID, branch_id | Format-Table -AutoSize | Out-String | Write-Output
    
    # 5. Run RAW SQL for FEE_HISTORY query
    $cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, student.s_id, student.s_name, student.ADMISSION_NO, Sections.SECTION_NAME, FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, FEE_MASTER.RECEIVABLE_AMOUNT, 
       FEE_MASTER.REC_AMOUNT, FEE_MASTER.BALANCE, FEE_MASTER.PAID, FEE_MASTER.SUBMIT_DATE, class.c_name, student.f_name, FEE_MASTER.SCROLLNO, FEE_MASTER.REMARKS
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE (FEE_MASTER.C_ID = '$cid') AND (FEE_MASTER.FEE_MONTH = '$month') AND (FEE_MASTER.SessionID = $sess)
ORDER BY FEE_MASTER.FEE_MASTER_ID
"@
    $dtRaw = New-Object System.Data.DataTable
    [void]$da.Fill($dtRaw)
    Write-Output "Raw SQL FEE_HISTORY rows: $($dtRaw.Rows.Count)"
    $dtRaw | Format-Table -AutoSize | Out-String | Write-Output
}

$conn.Close()
