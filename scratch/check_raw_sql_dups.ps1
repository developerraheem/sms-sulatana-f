$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's inspect the RAW SQL query we have right now in FEE_HISTORYTableAdapter:
# Fill:
$sql = @"
SELECT FEE_MASTER.FEE_MASTER_ID, student.s_id, student.s_name, student.ADMISSION_NO, Sections.SECTION_NAME, FEE_MASTER.SHIFT, FEE_MASTER.FEE_MONTH, FEE_MASTER.RECEIVABLE_AMOUNT, 
       FEE_MASTER.REC_AMOUNT, FEE_MASTER.BALANCE, FEE_MASTER.PAID, FEE_MASTER.SUBMIT_DATE, class.c_name, student.f_name, FEE_MASTER.SCROLLNO, FEE_MASTER.REMARKS,
       FEE_MASTER.FEE_MONTH, FEE_MASTER.ISSUE_DATE
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE (FEE_MASTER.C_ID = @classid) AND (FEE_MASTER.SHIFT = @shift) AND (FEE_MASTER.FEE_MONTH = @feemonth) AND (FEE_MASTER.PAID IS NULL OR FEE_MASTER.PAID = 'Y') AND (FEE_MASTER.SessionID = @sessionid) 
ORDER BY FEE_MASTER.FEE_MASTER_ID
"@

# Does this raw SQL return any duplicate FEE_MASTER_ID for ANY combination in Branch 6?
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT fm.SessionID, fm.C_ID, fm.SHIFT, fm.FEE_MONTH
FROM FEE_MASTER fm
WHERE fm.branch_id = 6
GROUP BY fm.SessionID, fm.C_ID, fm.SHIFT, fm.FEE_MONTH
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dtCombos = New-Object System.Data.DataTable
[void]$da.Fill($dtCombos)

$dupsFound = 0
foreach ($row in $dtCombos.Rows) {
    $cid = $row['C_ID']
    $shift = $row['SHIFT']
    $month = $row['FEE_MONTH']
    $sess = $row['SessionID']
    
    $cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE (FEE_MASTER.C_ID = '$cid') AND (FEE_MASTER.SHIFT = '$shift') AND (FEE_MASTER.FEE_MONTH = '$month') AND (FEE_MASTER.SessionID = $sess)
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
    $dtRes = New-Object System.Data.DataTable
    $daRes = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    [void]$daRes.Fill($dtRes)
    if ($dtRes.Rows.Count -gt 0) {
        Write-Output "DUP FOUND in raw SQL: C_ID=$cid, SHIFT=$shift, Month=$month, Session=$sess -> $($dtRes.Rows.Count) duplicate vouchers"
        $dupsFound++
    }
}
Write-Output "Total combinations with duplicate vouchers in raw SQL: $dupsFound"

$conn.Close()
