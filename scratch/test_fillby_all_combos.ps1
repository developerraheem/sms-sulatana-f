$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Test FillBy_ALL in DataSet_Fee_Summary_Reports with parameters:
# SELECT view_fee.FEE_MASTER_ID, student.roll_no, student.ADMISSION_NO, student.s_name, student.f_name, view_fee.c_name, view_fee.SHIFT, view_fee.SECTION_ID, view_fee.TYPE, view_fee.PAID, view_fee.FEE_MONTH, 
#        view_fee.Fee_head, view_fee.AMOUNT, view_fee.RECEIVED_AMOUNT, student.c_id
# FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
# WHERE (student.SessionID = @SESSIONID) AND (view_fee.FEE_MONTH_FROM = @FEEMONTH) AND (view_fee.SECTION_ID BETWEEN @sectionfrom AND @sectionto) AND (view_fee.TYPE BETWEEN @typefrom AND @typeto) AND 
#       (view_fee.c_id BETWEEN @FROMCLASS AND @TOCLASS)

# Let's test for all SessionIDs in branch 6:
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT DISTINCT student.SessionID, view_fee.FEE_MONTH_FROM
FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE student.branch_id = 6
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)

Write-Output "Found $($dt.Rows.Count) (SessionID, FEE_MONTH_FROM) combinations in branch 6."

$dupCount = 0
foreach ($r in $dt.Rows) {
    $sess = $r['SessionID']
    $fm = $r['FEE_MONTH_FROM']
    
    $cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, view_fee.Fee_head, COUNT(*) as cnt
FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE (student.SessionID = '$sess') AND (view_fee.FEE_MONTH_FROM = '$fm')
  AND (student.branch_id = 6)
GROUP BY view_fee.FEE_MASTER_ID, view_fee.Fee_head
HAVING COUNT(*) > 1
"@
    $dtD = New-Object System.Data.DataTable
    $daD = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    [void]$daD.Fill($dtD)
    if ($dtD.Rows.Count -gt 0) {
        Write-Output "DUP in FillBy_ALL: Session=$sess, Month=$fm, Count=$($dtD.Rows.Count)"
        $dupCount++
    }
}
Write-Output "Total duplicate combinations in FillBy_ALL: $dupCount"

$conn.Close()
