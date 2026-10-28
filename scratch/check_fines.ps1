$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;"
$con = New-Object System.Data.SqlClient.SqlConnection($connStr)
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TOP 20 FINE_ID, S_ID, Fee_head_id, FINE_AMOUNT, FEE_MONTH, active, REMARKS FROM FINE_HISTORY ORDER BY CAST(FINE_ID AS BIGINT) DESC"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ("FINE_ID=" + $r["FINE_ID"] + ", S_ID=" + $r["S_ID"] + ", AMOUNT=" + $r["FINE_AMOUNT"] + ", MONTH=" + $r["FEE_MONTH"] + ", ACTIVE=" + $r["active"] + ", REMARKS=" + $r["REMARKS"])
}
$con.Close()
