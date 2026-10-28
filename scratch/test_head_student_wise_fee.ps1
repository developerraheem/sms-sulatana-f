[void][System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")

$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's test HEAD_STUDENT_WISE_FEETableAdapter in DataSet_Fee_Summary_Reports
$ds = New-Object School.DataSet_Fee_Summary_Reports
$adapter = New-Object School.DataSet_Fee_Summary_ReportsTableAdapters.HEAD_STUDENT_WISE_FEETableAdapter
$connProp = $adapter.GetType().GetProperty('Connection', [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::NonPublic)
$connProp.SetValue($adapter, $conn, $null)

# Test with Branch 6 parameters: Session 49, Month 05 2024, Class from 122 to 182, Section Boys to Girls
Write-Output "Testing FillBy_ALL for Branch 6 (Session 49, Month 05 2024, Class 122 to 182)..."
try {
    [void]$adapter.FillBy_ALL($ds.HEAD_STUDENT_WISE_FEE, "49", "05 2024", "Boys", "Girls", "General", "General", [decimal]122, [decimal]182)
    Write-Output "FillBy_ALL returned $($ds.HEAD_STUDENT_WISE_FEE.Rows.Count) rows"
    
    # Check for duplicate voucher entries
    $dups = $ds.HEAD_STUDENT_WISE_FEE | Group-Object FEE_MASTER_ID, Fee_head | Where-Object { $_.Count -gt 1 }
    Write-Output "Duplicate (FEE_MASTER_ID, Fee_head) in FillBy_ALL: $($dups.Count)"
    if ($dups.Count -gt 0) {
        $dups | Select-Object -First 5 | Format-Table -AutoSize | Out-String | Write-Output
    }
} catch {
    Write-Output "Error in FillBy_ALL: $_"
}

# Now test another month: Month 11 2025
$ds.HEAD_STUDENT_WISE_FEE.Clear()
Write-Output "Testing FillBy_ALL for Branch 6 (Session 49, Month 11 2025)..."
try {
    [void]$adapter.FillBy_ALL($ds.HEAD_STUDENT_WISE_FEE, "49", "11 2025", "Boys", "Girls", "General", "General", [decimal]122, [decimal]182)
    Write-Output "FillBy_ALL returned $($ds.HEAD_STUDENT_WISE_FEE.Rows.Count) rows"
    
    $dups = $ds.HEAD_STUDENT_WISE_FEE | Group-Object FEE_MASTER_ID, Fee_head | Where-Object { $_.Count -gt 1 }
    Write-Output "Duplicate (FEE_MASTER_ID, Fee_head) in FillBy_ALL: $($dups.Count)"
    if ($dups.Count -gt 0) {
        $dups | Select-Object -First 5 | Format-Table -AutoSize | Out-String | Write-Output
    }
} catch {
    Write-Output "Error in FillBy_ALL: $_"
}

$conn.Close()
