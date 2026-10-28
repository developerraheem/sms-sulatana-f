$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()

# Find classes with active students and Admission Fee
$cmd.CommandText = @"
SELECT TOP 10 c.c_id, c.c_name, c.branch_id, fh.Fee_head, fc.FEE_CLASS_ID, fc.ACTIVE, fc.AMOUNT,
       (SELECT COUNT(*) FROM student s WHERE s.c_id = c.c_id AND s.active = 'true') as active_students
FROM FEE_CLASS fc
JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id
JOIN Class c ON fc.C_ID = c.c_id
WHERE fh.Fee_head LIKE '%ADMISSION%'
ORDER BY active_students DESC
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
$dt | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
