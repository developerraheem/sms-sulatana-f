$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, view_fee.Fee_head, COUNT(*) as cnt
FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE (student.SessionID = '49') AND (view_fee.FEE_MONTH_FROM = '11 2025')
  AND (student.branch_id = 6)
GROUP BY view_fee.FEE_MASTER_ID, view_fee.Fee_head
HAVING COUNT(*) > 1
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dtDups = New-Object System.Data.DataTable
[void]$da.Fill($dtDups)
Write-Output "Duplicate vouchers in Session 49, Month 11 2025:"
$dtDups | Format-Table -AutoSize | Out-String | Write-Output

# Let's inspect the first duplicate voucher
$vId = $dtDups.Rows[0]['FEE_MASTER_ID']
Write-Output "=== Inspecting FEE_MASTER_ID $vId ==="

$cmd.CommandText = @"
SELECT view_fee.FEE_MASTER_ID, student.s_id, student.s_name, student.ADMISSION_NO, student.branch_id as StdBranch,
       view_fee.Fee_head, view_fee.AMOUNT, view_fee.RECEIVED_AMOUNT, view_fee.c_name, view_fee.c_id
FROM view_fee INNER JOIN student ON view_fee.s_id = student.s_id AND view_fee.SessionID = student.SessionID
WHERE view_fee.FEE_MASTER_ID = $vId
"@
$dtRows = New-Object System.Data.DataTable
[void]$da.Fill($dtRows)
$dtRows | Format-Table -AutoSize | Out-String | Write-Output

# Let's check FEE_MASTER row for $vId
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = $vId"
$dtFM = New-Object System.Data.DataTable
[void]$da.Fill($dtFM)
Write-Output "=== FEE_MASTER rows for $vId ==="
$dtFM | Select-Object FEE_MASTER_ID, s_id, C_ID, SessionID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, branch_id | Format-Table -AutoSize | Out-String | Write-Output

# Let's check FEE_DETAIL rows for $vId
$cmd.CommandText = "SELECT * FROM FEE_DETAIL WHERE FEE_MASTER_ID = $vId"
$dtFD = New-Object System.Data.DataTable
[void]$da.Fill($dtFD)
Write-Output "=== FEE_DETAIL rows for $vId ==="
$dtFD | Format-Table -AutoSize | Out-String | Write-Output

# Let's check student rows for s_id
$sid = $dtFM.Rows[0]['s_id']
$cmd.CommandText = "SELECT s_id, s_name, ADMISSION_NO, branch_id, SessionID, c_id, SECTION_ID FROM student WHERE s_id = '$sid'"
$dtS = New-Object System.Data.DataTable
[void]$da.Fill($dtS)
Write-Output "=== student rows for s_id $sid ==="
$dtS | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
