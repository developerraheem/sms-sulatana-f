$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT COUNT(*) FROM (
    SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
    FROM FEE_MASTER INNER JOIN
         student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
         Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
         class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
    WHERE FEE_MASTER.branch_id = 6
    GROUP BY FEE_MASTER.FEE_MASTER_ID
    HAVING COUNT(*) > 1
) t
"@
Write-Host ("Count in Query 4 (with student.c_id=class.c_id, no session filter): " + $cmd.ExecuteScalar())

$cmd.CommandText = @"
SELECT COUNT(*) FROM (
    SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
    FROM FEE_MASTER INNER JOIN
         student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
         Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
         class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
    WHERE FEE_MASTER.branch_id = 6 AND FEE_MASTER.SessionID = 49
    GROUP BY FEE_MASTER.FEE_MASTER_ID
    HAVING COUNT(*) > 1
) t
"@
Write-Host ("Count in Query 4 with SessionID=49: " + $cmd.ExecuteScalar())

$cmd.CommandText = @"
SELECT COUNT(*) FROM (
    SELECT FEE_MASTER.FEE_MASTER_ID, COUNT(*) as cnt
    FROM FEE_MASTER INNER JOIN
         student ON FEE_MASTER.s_id = student.s_id AND FEE_MASTER.branch_id = student.branch_id INNER JOIN
         Sections ON student.SECTION_ID = Sections.SECTION_ID AND student.branch_id = Sections.BRANCH_ID INNER JOIN
         class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id AND FEE_MASTER.branch_id = class.branch_id
    WHERE FEE_MASTER.branch_id = 6 AND FEE_MASTER.SessionID = 68
    GROUP BY FEE_MASTER.FEE_MASTER_ID
    HAVING COUNT(*) > 1
) t
"@
Write-Host ("Count in Query 4 with SessionID=68: " + $cmd.ExecuteScalar())

$conn.Close()
