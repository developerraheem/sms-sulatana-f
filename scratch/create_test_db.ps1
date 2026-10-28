$backupDir = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\scratch\backup_db"
if (-not (Test-Path $backupDir)) {
    New-Item -ItemType Directory -Path $backupDir -Force | Out-Null
}
$backupFile = Join-Path $backupDir "SCMS_SF_backup.bak"

$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()
$cmd.CommandTimeout = 120

Write-Host "Creating COPY_ONLY backup of SCMS_SF to: $backupFile"
$cmd.CommandText = "BACKUP DATABASE SCMS_SF TO DISK = '$backupFile' WITH INIT, COPY_ONLY"
$cmd.ExecuteNonQuery() | Out-Null

if (Test-Path $backupFile) {
    $size = (Get-Item $backupFile).Length
    Write-Host "Backup created successfully! Size: $size bytes"
} else {
    Write-Host "ERROR: Backup file was not created!"
    $con.Close()
    exit 1
}

# If SCMS_SF_TEST already exists, check it
$cmd.CommandText = "SELECT COUNT(*) FROM sys.databases WHERE name = 'SCMS_SF_TEST'"
$exists = [int]$cmd.ExecuteScalar()
if ($exists -gt 0) {
    Write-Host "SCMS_SF_TEST already exists. Taking offline / dropping previous test db."
    $cmd.CommandText = "ALTER DATABASE SCMS_SF_TEST SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE SCMS_SF_TEST;"
    $cmd.ExecuteNonQuery() | Out-Null
}

$testDataFile = "C:\Users\nahee\SCMS_SF_TEST_0.mdf"
$testLogFile = "C:\Users\nahee\SCMS_SF_TEST_1.ldf"

Write-Host "Restoring SCMS_SF_TEST from backup to:"
Write-Host "  Data: $testDataFile"
Write-Host "  Log:  $testLogFile"

$cmd.CommandText = @"
RESTORE DATABASE SCMS_SF_TEST 
FROM DISK = '$backupFile' 
WITH MOVE 'SchoolSQL_dat' TO '$testDataFile', 
     MOVE 'SchoolSQL_log' TO '$testLogFile', 
     REPLACE
"@
$cmd.ExecuteNonQuery() | Out-Null

$cmd.CommandText = "SELECT state_desc FROM sys.databases WHERE name = 'SCMS_SF_TEST'"
$state = $cmd.ExecuteScalar()
Write-Host "SCMS_SF_TEST database status: $state"

$con.Close()
