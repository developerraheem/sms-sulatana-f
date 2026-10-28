$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

$cmd.CommandText = "SELECT COUNT(*) FROM Fee_Head WHERE branch_id IS NULL"
$nullBranch = $cmd.ExecuteScalar()
Write-Output "Fee heads with NULL branch_id: $nullBranch"

Write-Output "`n--- Fee Heads per branch ---"
$cmd.CommandText = "SELECT branch_id, COUNT(*) as cnt FROM Fee_Head GROUP BY branch_id ORDER BY branch_id"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Branch: " + $r["branch_id"].ToString() + " -> " + $r["cnt"].ToString() + " heads")
}
$r.Close()

$con.Close()
