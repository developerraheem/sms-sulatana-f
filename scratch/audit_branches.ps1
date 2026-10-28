$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT 
    b.branch_id,
    b.branch_name,
    (SELECT COUNT(*) FROM student s WHERE s.branch_id = b.branch_id) AS total_students,
    (SELECT COUNT(*) FROM student s WHERE s.branch_id = b.branch_id AND s.active = 1) AS active_students,
    (SELECT COUNT(*) FROM class c WHERE c.branch_id = b.branch_id) AS total_classes,
    (SELECT COUNT(*) FROM Fee_Head fh WHERE fh.branch_id = b.branch_id) AS total_fee_heads
FROM branch b
ORDER BY b.branch_id
"@

$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("Branch {0,2}: {1,-50} | Total Std: {2,5} | Active Std: {3,5} | Classes: {4,3} | Heads: {5,3}" -f `
        $r["branch_id"], $r["branch_name"], $r["total_students"], $r["active_students"], $r["total_classes"], $r["total_fee_heads"])
}
$r.Close()
$conn.Close()
