$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

# Let's inspect Fee_Head
$cmd.CommandText = "SELECT Fee_head_id, Fee_head, Category FROM Fee_Head WHERE branch_id='2'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["Fee_head_id"] + " | " + $r["Fee_head"] + " | " + $r["Category"])
}
$r.Close()

# Let's inspect test students
$cmd.CommandText = "SELECT TOP 5 s_id, s_name, c_id, SHIFT, SECTION_ID FROM student WHERE branch_id='2' AND SessionID='81' AND active='true'"
$r = $cmd.ExecuteReader()
while ($r.Read()) {
    Write-Output ($r["s_id"] + " | " + $r["s_name"] + " | " + $r["c_id"] + " | " + $r["SHIFT"] + " | " + $r["SECTION_ID"])
}
$r.Close()

$con.Close()
