$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
try {
    $conn.Open()
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'BranchVoucherRemarks'"
    $reader = $cmd.ExecuteReader()
    Write-Output "=== COLUMNS ==="
    while ($reader.Read()) {
        Write-Output ($reader[0] + ' | ' + $reader[1] + ' | ' + $reader[2] + ' | ' + $reader[3])
    }
    $reader.Close()

    Write-Output "=== DATA ==="
    $cmd.CommandText = "SELECT Branch_ID, Remarks, UpdatedAt FROM dbo.BranchVoucherRemarks"
    $adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    $dt = New-Object System.Data.DataTable
    $adapter.Fill($dt) | Out-Null
    $dt | Format-Table -AutoSize | Out-String | Write-Output

    Write-Output "=== ALL BRANCHES ==="
    $cmd.CommandText = "SELECT branch_id, branch_name FROM branch ORDER BY branch_id"
    $dtBranches = New-Object System.Data.DataTable
    (New-Object System.Data.SqlClient.SqlDataAdapter($cmd)).Fill($dtBranches) | Out-Null
    $dtBranches | Format-Table -AutoSize | Out-String | Write-Output
} catch {
    Write-Output ("Error: " + $_.Exception.Message)
} finally {
    $conn.Close()
}
