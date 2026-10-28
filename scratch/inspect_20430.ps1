$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Host "=== Student 20430 ==="
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT * FROM student WHERE s_id = 20430"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("s_id: " + $r["s_id"] + ", name: " + $r["s_name"] + ", adm: " + $r["ADMISSION_NO"] + ", class: " + $r["c_id"] + ", sec: " + $r["SECTION_ID"] + ", branch: " + $r["branch_id"] + ", session: " + $r["SessionID"] + ", active: " + $r["active"])
}
$r.Close()

Write-Host "`n=== FEE_MASTER for Student 20430 ==="
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE s_id = 20430"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("FEE_MASTER_ID: " + $r["FEE_MASTER_ID"] + ", C_ID: " + $r["C_ID"] + ", month: " + $r["FEE_MONTH"] + ", Due: " + $r["RECEIVABLE_AMOUNT"] + ", Rec: " + $r["REC_AMOUNT"] + ", Bal: " + $r["BALANCE"] + ", Paid: " + $r["PAID"] + ", Session: " + $r["SessionID"] + ", Branch: " + $r["branch_id"])
}
$r.Close()

Write-Host "`n=== FEE_DETAIL for Student 20430 vouchers ==="
$cmd.CommandText = "SELECT d.*, h.Fee_head FROM FEE_DETAIL d LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = 20430)"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Host ("FEE_DETAIL_ID: " + $r["FEE_DETAIL_ID"] + ", Voucher: " + $r["FEE_MASTER_ID"] + ", Head: " + $r["Fee_head"] + ", Amount: " + $r["AMOUNT"] + ", Rec: " + $r["RECEIVED_AMOUNT"] + ", Bal: " + $r["BALANCE"] + ", Branch: " + $r["branch_id"] + ", Session: " + $r["SessionID"])
}
$r.Close()

$conn.Close()
