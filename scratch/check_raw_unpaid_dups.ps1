$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Test Unpaid raw SQL
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT fm.SessionID, fm.C_ID, fm.SHIFT, fm.FEE_MONTH, s.SECTION_ID
FROM FEE_MASTER fm
INNER JOIN student s ON fm.s_id = s.s_id AND fm.branch_id = s.branch_id
WHERE fm.branch_id = 6 AND (fm.PAID IS NULL OR fm.PAID = 'N')
GROUP BY fm.SessionID, fm.C_ID, fm.SHIFT, fm.FEE_MONTH, s.SECTION_ID
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dtCombos = New-Object System.Data.DataTable
[void]$da.Fill($dtCombos)

Write-Output "Found $($dtCombos.Rows.Count) combinations for Unpaid in branch 6."

$dupsFound = 0
foreach ($row in $dtCombos.Rows) {
    $cid = $row['C_ID']
    $shift = $row['SHIFT']
    $month = $row['FEE_MONTH']
    $sess = $row['SessionID']
    $sec = $row['SECTION_ID']
    
    $cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
FROM Sections INNER JOIN
     student ON Sections.SECTION_ID = student.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     FEE_MASTER ON student.s_id = FEE_MASTER.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE (FEE_MASTER.C_ID = '$cid') AND (FEE_MASTER.SHIFT = '$shift') AND (FEE_MASTER.FEE_MONTH = '$month') AND (FEE_MASTER.PAID IS NULL OR FEE_MASTER.PAID = 'N') AND (Sections.SECTION_NAME = '$sec') AND (FEE_MASTER.SESSIONID = $sess)
GROUP BY FEE_MASTER.FEE_MASTER_ID
HAVING COUNT(*) > 1
"@
    $dtRes = New-Object System.Data.DataTable
    $daRes = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    [void]$daRes.Fill($dtRes)
    if ($dtRes.Rows.Count -gt 0) {
        Write-Output "DUP FOUND in Unpaid: C_ID=$cid, SHIFT=$shift, Month=$month, Sec=$sec, Session=$sess -> $($dtRes.Rows.Count) duplicate vouchers"
        $dupsFound++
    }
}
Write-Output "Total combinations with duplicate vouchers in Unpaid: $dupsFound"

$conn.Close()
