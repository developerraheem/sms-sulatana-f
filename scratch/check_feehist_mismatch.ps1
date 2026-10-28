$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COUNT(*) as hist_without_rec FROM FEE_HISTORY fh INNER JOIN FEE_MASTER fm ON fh.VOUCHER_NO = fm.FEE_MASTER_ID WHERE fm.REC_AMOUNT IS NULL OR fm.REC_AMOUNT = 0"
$adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$ds = New-Object System.Data.DataSet
$adapter.Fill($ds)
Write-Host "FEE_HISTORY entries where FEE_MASTER.REC_AMOUNT is null/0:" $ds.Tables[0].Rows[0]["hist_without_rec"]
$conn.Close()
