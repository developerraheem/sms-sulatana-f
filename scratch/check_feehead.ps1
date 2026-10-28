$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Fee_Head'"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)
Write-Output "=== Fee_Head Columns ==="
$dt | Format-Table -AutoSize | Out-String | Write-Output

# Check Fee_Head rows with duplicate Fee_head_id across branches
$cmd.CommandText = "SELECT Fee_head_id, COUNT(*) as cnt FROM Fee_Head GROUP BY Fee_head_id HAVING COUNT(*) > 1"
$dtDup = New-Object System.Data.DataTable
[void]$da.Fill($dtDup)
Write-Output "Fee_head_id with multiple rows across branches: $($dtDup.Rows.Count)"

$conn.Close()
