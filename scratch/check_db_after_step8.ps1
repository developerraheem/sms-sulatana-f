$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, REC_AMOUNT, BALANCE, PAID, SUBMIT_DATE FROM FEE_MASTER WHERE s_id = '2093'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "FM_ID=$($r[0]), Month=$($r[1]), Rec=$($r[2]), Bal=$($r[3]), Paid='$($r[4])', Date=$($r[5])"
}
$r.Close()

$cmd.CommandText = "SELECT * FROM FEE_HISTORY WHERE VOUCHER_NO = '1'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host "Fee History: $($r['VOUCHER_NO']) | $($r['PAID_AMOUNT']) | $($r['SUBMITION_DATE'])"
}
$r.Close()
$conn.Close()
