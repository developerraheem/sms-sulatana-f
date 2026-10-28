$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$tran = $con.BeginTransaction()
try {
    # Check current sum for master 2
    $cmd = $con.CreateCommand()
    $cmd.Transaction = $tran
    $cmd.CommandText = "SELECT SUM(AMOUNT) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'"
    $currSum = $cmd.ExecuteScalar()
    Write-Host ("Current Sum in Detail: " + $currSum)

    # Insert a dummy test line with amount 8
    $cmd.CommandText = "INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, FEE_MONTH, ISCURRENT, BALANCE, FEE_MONTH_FROM, SessionID, branch_id) VALUES (2, 145, 8, '10 2026', 'Y', 8, '10 2026', 81, 2)"
    $cmd.ExecuteNonQuery()

    # Query sum again in same transaction
    $cmd.CommandText = "SELECT SUM(AMOUNT) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '2' AND SessionID = '81' AND branch_id = '2'"
    $newSum = $cmd.ExecuteScalar()
    Write-Host ("New Sum after Insert in same tran: " + $newSum)

    # Rollback so DB is completely untouched
    $tran.Rollback()
    Write-Host "Rolled back successfully. DB untouched."
} catch {
    $tran.Rollback()
    Write-Host ("Error: " + $_.Exception.Message)
}
$con.Close()
