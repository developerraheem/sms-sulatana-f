$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's inspect HEAD_STUDENT_WISE_FEE queries from DataSet_Fee_Summary_Reports.xsd:
# FillBy_ALL:
# SELECT view_fee.FEE_MASTER_ID, student.roll_no, student.ADMISSION_NO, student.s_name, student.f_name, view_fee.c_name, view_fee.SHIFT, view_fee.SECTION_ID, view_fee.TYPE, view_fee.PAID, view_fee.FEE_MONTH, view_fee.Fee_head, view_fee.AMOUNT, view_fee.RECEIVED_AMOUNT, student.c_id
# FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
# WHERE (student.SessionID = @SESSIONID) AND (view_fee.FEE_MONTH_FROM = @FEEMONTH) AND (view_fee.SECTION_ID BETWEEN @sectionfrom AND @sectionto) AND (view_fee.TYPE BETWEEN @typefrom AND @typeto) AND (view_fee.c_id BETWEEN @FROMCLASS AND @TOCLASS)
# ORDER BY view_fee.c_id

# Let's test this query for Branch 6!
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, student.s_name, student.ADMISSION_NO, view_fee.Fee_head, view_fee.AMOUNT, student.branch_id, view_fee.SessionID, view_fee.c_name
FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE student.branch_id = 6
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "Total rows returned for branch 6 in view_fee query: $($dt.Rows.Count)"

# Check if any voucher or student has duplicate rows
$cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, view_fee.Fee_head, COUNT(*) as cnt
FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE student.branch_id = 6
GROUP BY view_fee.FEE_MASTER_ID, view_fee.Fee_head
HAVING COUNT(*) > 1
"@
$dtDups = New-Object System.Data.DataTable
[void]$da.Fill($dtDups)
Write-Output "Duplicate (FEE_MASTER_ID, Fee_head) in branch 6: $($dtDups.Rows.Count)"

if ($dtDups.Rows.Count -gt 0) {
    $dtDups | Select-Object -First 10 | Format-Table -AutoSize | Out-String | Write-Output
}

$conn.Close()
