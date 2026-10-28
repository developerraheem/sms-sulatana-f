$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

# Check SYSTEMSETTING in DB
$cmd.CommandText = "SELECT TOP 1 branch_id, sessionid FROM SYSTEMSETTING"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "DB SYSTEMSETTING: branch_id = '$($r[0])', sessionid = '$($r[1])'"
}
$r.Close()

# Check what max FEE_MASTER_ID is for session 12
$cmd.CommandText = "SELECT MAX(CONVERT(INT, FEE_MASTER_ID)) FROM FEE_MASTER WHERE SESSIONID = '12'"
Write-Host "Max FEE_MASTER_ID for session 12:" $cmd.ExecuteScalar()

# Check what max FEE_MASTER_ID is across ALL sessions
$cmd.CommandText = "SELECT MAX(CONVERT(INT, FEE_MASTER_ID)) FROM FEE_MASTER"
Write-Host "Max FEE_MASTER_ID across all sessions:" $cmd.ExecuteScalar()

# Check if student 2093 already has a record in FEE_MASTER for 11 2026
$cmd.CommandText = "SELECT * FROM FEE_MASTER WHERE s_id = '2093' AND FEE_MONTH = '11 2026'"
$r = $cmd.ExecuteReader()
$hasNov = $r.Read()
Write-Host "Already has Nov 2026?" $hasNov
$r.Close()

$con.Close()
