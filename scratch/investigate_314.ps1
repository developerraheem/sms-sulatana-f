$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, student.s_id, student.s_name, student.SECTION_ID, Sections.SECTION_NAME, Sections.BRANCH_ID as sec_branch, class.c_id, class.c_name, class.branch_id as class_branch
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND FEE_MASTER.branch_id = class.branch_id
WHERE FEE_MASTER.FEE_MASTER_ID = 314
"@
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("Voucher: " + $r[0] + ", s_id=" + $r[1] + ", s_name=" + $r[2] + ", std_sec=" + $r[3] + ", sec_name=" + $r[4] + ", sec_branch=" + $r[5] + ", c_id=" + $r[6] + ", c_name=" + $r[7] + ", class_branch=" + $r[8])
}
$r.Close()

Write-Host "`nCheck student record for voucher 314:"
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE FEE_MASTER_ID = 314"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("FEE_MASTER: s_id=" + $r["s_id"] + ", branch_id=" + $r["branch_id"] + ", SessionID=" + $r["SessionID"] + ", C_ID=" + $r["C_ID"] + ", month=" + $r["FEE_MONTH"])
}
$r.Close()

Write-Host "`nCheck student records with this s_id:"
$cmd.CommandText = "SELECT s_id, branch_id, SessionID, c_id, SECTION_ID, s_name, active FROM student WHERE s_id IN (SELECT s_id FROM FEE_MASTER WHERE FEE_MASTER_ID = 314)"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("student: s_id=" + $r[0] + ", branch=" + $r[1] + ", SessionID=" + $r[2] + ", c_id=" + $r[3] + ", SECTION_ID=" + $r[4] + ", name=" + $r[5] + ", active=" + $r[6])
}
$r.Close()

Write-Host "`nCheck FEE_MASTER with FEE_MASTER_ID = 314 across ALL branches:"
$cmd.CommandText = "SELECT FEE_MASTER_ID, s_id, branch_id, SessionID, C_ID, FEE_MONTH FROM FEE_MASTER WHERE FEE_MASTER_ID = 314"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("FEE_MASTER: id=" + $r[0] + ", s_id=" + $r[1] + ", branch=" + $r[2] + ", SessionID=" + $r[3] + ", C_ID=" + $r[4] + ", month=" + $r[5])
}
$r.Close()

$conn.Close()
