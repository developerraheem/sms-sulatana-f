$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandText = "SELECT * FROM FEE_CLASS WHERE C_ID = '64'"
$r = $cmd.ExecuteReader()
$count = 0
while($r.Read()) {
    $count++
    Write-Host "Fee Head:" $r["Fee_head_id"] "Amount:" $r["AMOUNT"] "Active:" $r["ACTIVE"] "Type:" $r["TYPE"]
}
$r.Close()
Write-Host "Total rows for C_ID 64:" $count
$con.Close()
