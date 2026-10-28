$con = New-Object System.Data.SqlClient.SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME IN ('FEE_MASTER', 'FEE_DETAIL', 'FEE_HISTORY') ORDER BY TABLE_NAME, ORDINAL_POSITION"
$r = $cmd.ExecuteReader()
while($r.Read()) {
    Write-Host ($r["TABLE_NAME"].ToString() + " -> " + $r["COLUMN_NAME"].ToString())
}
$r.Close()
$con.Close()
