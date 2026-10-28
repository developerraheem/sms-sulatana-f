$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()

Write-Host "=== TEST 1: Duplicate vouchers for same student, month, session, branch in FEE_MASTER ==="
$cmd.CommandText = @"
SELECT branch_id, s_id, FEE_MONTH, SessionID, COUNT(*) as cnt
FROM FEE_MASTER
GROUP BY branch_id, s_id, FEE_MONTH, SessionID
HAVING COUNT(*) > 1
ORDER BY cnt DESC
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Host "Duplicate student-month vouchers count: $($dt.Rows.Count)"
$dt | Select-Object -First 10 | Format-Table -AutoSize | Out-String | Write-Host

Write-Host "=== TEST 2: Inspect sample duplicate vouchers ==="
if ($dt.Rows.Count -gt 0) {
    $sample = $dt.Rows[0]
    $cmd.CommandText = "SELECT FEE_MASTER_ID, s_id, C_ID, SHIFT, FEE_MONTH, FEE_MONTH_FROM, SessionID, branch_id, RECEIVABLE_AMOUNT, PAID, SUBMIT_DATE FROM FEE_MASTER WHERE s_id = '$($sample['s_id'])' AND FEE_MONTH = '$($sample['FEE_MONTH'])' AND SessionID = '$($sample['SessionID'])' AND branch_id = '$($sample['branch_id'])'"
    $dtSample = New-Object System.Data.DataTable
    $daSample = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    [void]$daSample.Fill($dtSample)
    $dtSample | Format-Table -AutoSize | Out-String | Write-Host
}

Write-Host "=== TEST 3: Check how FEE_MONTH and FEE_MONTH_FROM are stored in FEE_MASTER ==="
$cmd.CommandText = "SELECT DISTINCT TOP 20 FEE_MONTH, FEE_MONTH_FROM, T_MONTHS, MULTITAG FROM FEE_MASTER ORDER BY FEE_MONTH DESC"
$dtMonths = New-Object System.Data.DataTable
$daMonths = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
[void]$daMonths.Fill($dtMonths)
$dtMonths | Format-Table -AutoSize | Out-String | Write-Host

$conn.Close()
