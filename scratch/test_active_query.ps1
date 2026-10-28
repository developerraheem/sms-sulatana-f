$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()
$cmd = $conn.CreateCommand()

# Test with class 169 (where 52375 is currently ACTIVE=False from our earlier script!)
$cmd.CommandText = "Select fc.*, fh.Fee_head, fh.Category from FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID='169' and fc.ACTIVE='true' AND fc.TYPE='General' Order by fc.Fee_head_id"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null
Write-Output "Results for C_ID=169 with ACTIVE='true': $($dt.Rows.Count) rows"
foreach ($r in $dt.Rows) {
    Write-Output "FEE_CLASS_ID: $($r['FEE_CLASS_ID']) | Head: $($r['Fee_head']) | Active: $($r['ACTIVE'])"
}

# Also test without ACTIVE filter to see all heads for C_ID=169
$cmd.CommandText = "Select fc.*, fh.Fee_head, fh.Category from FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID='169' AND fc.TYPE='General' Order by fc.Fee_head_id"
$dt2 = New-Object System.Data.DataTable
$da.Fill($dt2) | Out-Null
Write-Output "`nAll heads for C_ID=169:"
foreach ($r in $dt2.Rows) {
    Write-Output "FEE_CLASS_ID: $($r['FEE_CLASS_ID']) | Head: $($r['Fee_head']) | Active: $($r['ACTIVE'])"
}

$conn.Close()
