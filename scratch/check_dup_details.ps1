$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = @"
SELECT FEE_MASTER_ID, Fee_head_id, COUNT(*) as cnt 
FROM FEE_DETAIL 
WHERE SessionID = '81' AND branch_id = '2'
GROUP BY FEE_MASTER_ID, Fee_head_id 
HAVING COUNT(*) > 1
"@
$r = $cmd.ExecuteReader()
Write-Output "--- Duplicate FEE_DETAIL rows for Session 81, Branch 2 ---"
while ($r.Read()) {
    Write-Output ("FEE_MASTER_ID=" + $r["FEE_MASTER_ID"] + ", Fee_head_id=" + $r["Fee_head_id"] + ", COUNT=" + $r["cnt"])
}
$r.Close()
$con.Close()
