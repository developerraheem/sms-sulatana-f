$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT s.s_id, s.s_name, s.c_id, s.branch_id, s.CONCESSION_FEE,
       (SELECT COUNT(*) FROM FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id 
        WHERE fc.C_ID = s.c_id AND (fh.Category IN ('DISCOUNT', 'CONCESSION') OR fh.Fee_head LIKE '%CONCESSION%') AND fc.ACTIVE = 1) AS ConcessionHeadCount
FROM student s
WHERE s.CONCESSION_FEE > 0 AND s.active = 1
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
Write-Host "Total active students with concession > 0: $($dt.Rows.Count)"
$missing = $dt.Select("ConcessionHeadCount = 0")
Write-Host "Students missing concession head in FEE_CLASS: $($missing.Length)"
if ($missing.Length -gt 0) {
    $missing | Format-Table -AutoSize
}

$conn.Close()
