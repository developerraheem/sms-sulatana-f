[void][System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")

$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's find what vouchers/classes exist in Branch 6 for Session 49 and Session 68
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT fm.SessionID, fm.C_ID, c.c_name, fm.SHIFT, fm.FEE_MONTH, s.SECTION_ID, COUNT(*) as VoucherCount
FROM FEE_MASTER fm
INNER JOIN student s ON fm.s_id = s.s_id AND fm.branch_id = s.branch_id
INNER JOIN class c ON fm.C_ID = c.c_id AND fm.branch_id = c.branch_id
WHERE fm.branch_id = 6
GROUP BY fm.SessionID, fm.C_ID, c.c_name, fm.SHIFT, fm.FEE_MONTH, s.SECTION_ID
ORDER BY VoucherCount DESC
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)

Write-Output "=== Top 10 Branch 6 report parameter sets ==="
$dt | Select-Object -First 10 | Format-Table -AutoSize | Out-String | Write-Output

# Let's test the top parameter set with FEE_HISTORYTableAdapter!
$top = $dt.Rows[0]
$sess = $top['SessionID']
$cid = $top['C_ID']
$shift = $top['SHIFT']
$month = $top['FEE_MONTH']
$sec = $top['SECTION_ID']

Write-Output "Testing with Session=$sess, Class=$cid, Shift=$shift, Month=$month, Section=$sec"

$ds = New-Object School.Report_DataSet_new
$adapter = New-Object School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter
$connProp = $adapter.GetType().GetProperty('Connection', [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::NonPublic)
$connProp.SetValue($adapter, $conn, $null)

# 1. Test Fill
[void]$adapter.Fill($ds.FEE_HISTORY, $cid.ToString(), $shift.ToString(), $month.ToString(), [decimal]$sess)
Write-Output "FEE_HISTORY.Fill row count: $($ds.FEE_HISTORY.Rows.Count)"

$dups = $ds.FEE_HISTORY | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
Write-Output "Duplicate vouchers in Fill: $($dups.Count)"

# 2. Test Unpaid
$ds.FEE_HISTORY.Clear()
[void]$adapter.Unpaid($ds.FEE_HISTORY, $cid.ToString(), $shift.ToString(), $month.ToString(), $sec.ToString(), [decimal]$sess)
Write-Output "FEE_HISTORY.Unpaid row count: $($ds.FEE_HISTORY.Rows.Count)"
$dupsUnpaid = $ds.FEE_HISTORY | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
Write-Output "Duplicate vouchers in Unpaid: $($dupsUnpaid.Count)"

# 3. Test Paid
$ds.FEE_HISTORY.Clear()
[void]$adapter.Paid($ds.FEE_HISTORY, $cid.ToString(), $shift.ToString(), $month.ToString(), [decimal]$sess)
Write-Output "FEE_HISTORY.Paid row count: $($ds.FEE_HISTORY.Rows.Count)"
$dupsPaid = $ds.FEE_HISTORY | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
Write-Output "Duplicate vouchers in Paid: $($dupsPaid.Count)"

$conn.Close()
