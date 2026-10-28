$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'FEE_MASTER' AND COLUMN_NAME IN ('C_ID', 's_id', 'branch_id', 'SESSIONID')"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ($r["COLUMN_NAME"].ToString() + " : " + $r["DATA_TYPE"].ToString() + " (" + $r["NUMERIC_PRECISION"] + ")")
}
$conn.Close()
