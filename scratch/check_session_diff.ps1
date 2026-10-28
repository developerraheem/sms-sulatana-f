$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Check Session 68 vouchers in Branch 6 and their students' SessionID
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT fm.FEE_MASTER_ID, fm.SessionID as FmSession, s.SessionID as StdSession, s.s_name, s.branch_id
FROM FEE_MASTER fm
INNER JOIN student s ON fm.s_id = s.s_id AND fm.branch_id = s.branch_id
WHERE fm.branch_id = 6 AND fm.SessionID = 68 AND s.SessionID <> 68
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "Branch 6 vouchers in Session 68 where student.SessionID <> 68: $($dt.Rows.Count)"

$conn.Close()
