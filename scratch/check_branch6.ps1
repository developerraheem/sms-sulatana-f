$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# 1. Check branch 6 info
$cmd = $conn.CreateCommand()
$cmd.CommandText = 'SELECT * FROM branch WHERE branch_id = 6'
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output '=== Branch 6 ==='
$dt | Format-Table -AutoSize | Out-String | Write-Output

# 2. Check academic sessions for branch 6
$cmd.CommandText = 'SELECT DISTINCT SessionID FROM FEE_MASTER WHERE branch_id = 6'
$dtSessions = New-Object System.Data.DataTable
[void]$da.Fill($dtSessions)
Write-Output '=== Sessions in FEE_MASTER for Branch 6 ==='
$dtSessions | Format-Table -AutoSize | Out-String | Write-Output

# 3. Check classes in branch 6
$cmd.CommandText = 'SELECT c_id, c_name, branch_id FROM class WHERE branch_id = 6'
$dtClasses = New-Object System.Data.DataTable
[void]$da.Fill($dtClasses)
Write-Output '=== Classes for Branch 6 ==='
$dtClasses | Format-Table -AutoSize | Out-String | Write-Output

# 4. Check fee vouchers in branch 6
$cmd.CommandText = 'SELECT TOP 20 FEE_MASTER_ID, s_id, C_ID, SessionID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, branch_id FROM FEE_MASTER WHERE branch_id = 6 ORDER BY FEE_MASTER_ID DESC'
$dtFM = New-Object System.Data.DataTable
[void]$da.Fill($dtFM)
Write-Output '=== Recent Fee Vouchers for Branch 6 ==='
$dtFM | Format-Table -AutoSize | Out-String | Write-Output

# 5. Check Sections in branch 6
$cmd.CommandText = 'SELECT * FROM Sections WHERE BRANCH_ID = 6'
$dtSec = New-Object System.Data.DataTable
[void]$da.Fill($dtSec)
Write-Output '=== Sections for Branch 6 ==='
$dtSec | Format-Table -AutoSize | Out-String | Write-Output

$conn.Close()
