$connStr = "Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;"
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT Temp.s_name, Temp.roll_no, Temp.FEE_MONTH, Temp.SUBMIT_DATE, Temp.C_ID, Temp.s_id, Temp.c_name, Temp.FEE_MASTER_ID, 
       TempDetail.Fee_head, TempDetail.AMOUNT, TempDetail.REMARKS, 
       Temp.ADMISSION_NO, Temp.f_name, Temp.SHIFT, Temp.TYPE, Temp.SECTION_NAME, Temp.DUE_DATE, Temp.SessionName, Temp.BARCODE, Temp.REMARKS
FROM Temp 
INNER JOIN TempDetail ON Temp.FEE_MASTER_ID = TempDetail.FEE_MASTER_ID AND Temp.SessionID = TempDetail.SessionID
WHERE Temp.FEE_MASTER_ID = 31 AND Temp.SessionID = 81 AND Temp.s_id = '22664'
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt)
Write-Host "=== Printed Voucher Rows for Voucher 31 (RAHEEM SARDAR) ==="
$dt | Format-Table -Property s_name, Fee_head, AMOUNT

$sum = ($dt | Measure-Object -Property AMOUNT -Sum).Sum
Write-Host "Sum of AMOUNT (Payable Within Due Date): $sum"

$conn.Close()
