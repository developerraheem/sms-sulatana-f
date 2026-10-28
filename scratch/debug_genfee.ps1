$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$sid1 = "2093"
$cid1 = "64"

# Clean student 2093 test records
$cmd.CommandText = @"
DELETE FROM FEE_HISTORY WHERE VOUCHER_NO IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID IN (SELECT FEE_MASTER_ID FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12') AND SessionID = '12';
DELETE FROM FEE_MASTER WHERE s_id = '$sid1' AND SessionID = '12';
"@
$cmd.ExecuteNonQuery() | Out-Null

# What is max FEE_MASTER_ID in session 12?
$cmd.CommandText = "select max(convert(int,FEE_MASTER_ID))+1 as ids from FEE_MASTER where SESSIONID='12'"
$r = $cmd.ExecuteReader()
if ($r.Read()) { Write-Host "Next Master ID: $($r[0])" }
$r.Close()

# What is max FEE_DETAIL_ID?
$cmd.CommandText = "select max(convert(int,FEE_DETAIL_ID))+1 as ids from FEE_DETAIL"
$r = $cmd.ExecuteReader()
if ($r.Read()) { Write-Host "Next Detail ID: $($r[0])" }
$r.Close()

# Check student record
$cmd.CommandText = "Select * from [student] where [c_id] ='64' and [active]='true' and SHIFT='Morning' and SessionID='12' and branch_id='1' AND SECTION_ID='1' and s_id='2093'"
$r = $cmd.ExecuteReader()
if ($r.Read()) {
    Write-Host "Student found: s_id=$($r['s_id']), type=$($r['TYPE']), buscharges=$($r['buscharges']), concession=$($r['CONCESSION_FEE'])"
} else {
    Write-Host "Student NOT found!"
}
$r.Close()
$con.Close()
