$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's test the actual queries from FEE_HISTORYTableAdapter for Branch 6:
# Fill: (FEE_MASTER.C_ID = @classid) AND (FEE_MASTER.SHIFT = @shift) AND (FEE_MASTER.FEE_MONTH = @feemonth) AND (FEE_MASTER.SESSIONID = @sessionid)
# Paid: (FEE_MASTER.C_ID = @classid) AND (FEE_MASTER.SHIFT = @shift) AND (FEE_MASTER.FEE_MONTH = @feemonth) AND (FEE_MASTER.PAID = 'Y') AND (FEE_MASTER.SESSIONID = @sessionid)
# Unpaid: (FEE_MASTER.C_ID = @classid) AND (FEE_MASTER.SHIFT = @shift) AND (FEE_MASTER.FEE_MONTH = @feemonth) AND (FEE_MASTER.PAID IS NULL OR FEE_MASTER.PAID = 'N') AND (Sections.SECTION_NAME = @section) AND (FEE_MASTER.SESSIONID = @sessionid)

# Let's find distinct combinations of (C_ID, SHIFT, FEE_MONTH, SessionID) in FEE_MASTER for branch_id = 6
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT C_ID, SHIFT, FEE_MONTH, SessionID, COUNT(*) as cnt
FROM FEE_MASTER
WHERE branch_id = 6
GROUP BY C_ID, SHIFT, FEE_MONTH, SessionID
ORDER BY cnt DESC
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dtCombos = New-Object System.Data.DataTable
[void]$da.Fill($dtCombos)

Write-Output "Found $($dtCombos.Rows.Count) combinations in branch 6."

# Check for duplicate FEE_MASTER_ID within any single (C_ID, SHIFT, FEE_MONTH, SessionID)
$dupVoucherCombos = 0
foreach ($row in $dtCombos.Rows) {
    $cid = $row['C_ID']
    $shift = $row['SHIFT']
    $month = $row['FEE_MONTH']
    $sess = $row['SessionID']
    
    # Run Fill query
    $cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE (FEE_MASTER.C_ID = '$cid') AND (FEE_MASTER.SHIFT = '$shift') AND (FEE_MASTER.FEE_MONTH = '$month') AND (FEE_MASTER.SESSIONID = $sess)
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
    $dtRes = New-Object System.Data.DataTable
    $daRes = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    [void]$daRes.Fill($dtRes)
    if ($dtRes.Rows.Count -gt 0) {
        Write-Output "DUPLICATE FOUND in Fill! C_ID=$cid, SHIFT=$shift, Month=$month, Session=$sess - $($dtRes.Rows.Count) duplicate vouchers"
        $dupVoucherCombos++
    }
}
Write-Output "Total combinations with duplicate vouchers in Fill: $dupVoucherCombos"

$conn.Close()
