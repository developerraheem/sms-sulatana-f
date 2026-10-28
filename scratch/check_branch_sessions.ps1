$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

Write-Output "--- Sessions defined in Sessions table per branch ---"
$cmd.CommandText = "SELECT branch_id, SessionID, SessionName FROM Sessions ORDER BY branch_id, SessionID"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Branch=" + $r["branch_id"].ToString() + ", SessionID=" + $r["SessionID"].ToString() + ", Name=" + $r["SessionName"].ToString())
}
$r.Close()

Write-Output "`n--- Distinct Student SessionIDs per branch ---"
$cmd.CommandText = "SELECT branch_id, SessionID, COUNT(*) as cnt FROM student WHERE active='true' GROUP BY branch_id, SessionID ORDER BY branch_id, SessionID"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("Branch=" + $r["branch_id"].ToString() + ", SessionID=" + $r["SessionID"].ToString() + ", Count=" + $r["cnt"].ToString())
}
$r.Close()

$con.Close()
