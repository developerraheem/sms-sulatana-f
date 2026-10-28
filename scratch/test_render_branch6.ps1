[void][System.Reflection.Assembly]::LoadFrom("c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")
[void][System.Reflection.Assembly]::LoadWithPartialName("Microsoft.ReportViewer.WinForms")

$connStr = 'Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

# Let's test rendering VoucherslistReport for Branch 6 top parameter sets
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT DISTINCT TOP 10 fm.SessionID, fm.C_ID, c.c_name, fm.SHIFT, fm.FEE_MONTH, s.SECTION_ID
FROM FEE_MASTER fm
INNER JOIN student s ON fm.s_id = s.s_id AND fm.branch_id = s.branch_id
INNER JOIN class c ON fm.C_ID = c.c_id AND fm.branch_id = c.branch_id
WHERE fm.branch_id = 6
ORDER BY fm.SessionID DESC, fm.FEE_MONTH DESC
"@
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
[void]$da.Fill($dt)

$reportPath = "c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\Reports\VoucherslistReport.rdlc"

foreach ($row in $dt.Rows) {
    $sess = $row['SessionID']
    $cid = $row['C_ID']
    $cname = $row['c_name']
    $shift = $row['SHIFT']
    $fm = $row['FEE_MONTH']
    $sec = $row['SECTION_ID']
    
    $ds = New-Object School.Report_DataSet_new
    $adapter = New-Object School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter
    $connProp = $adapter.GetType().GetProperty('Connection', [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::NonPublic)
    $connProp.SetValue($adapter, $conn, $null)
    
    [void]$adapter.Fill($ds.FEE_HISTORY, $cid.ToString(), $shift.ToString(), $fm.ToString(), [decimal]$sess)
    
    Write-Output "Class: $cname ($cid), Month: $fm, Shift: $shift, Rows: $($ds.FEE_HISTORY.Rows.Count)"
    
    # Check for duplicate voucher numbers in the DataTable
    $dups = $ds.FEE_HISTORY | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
    if ($dups.Count -gt 0) {
        Write-Output "  -> DUPLICATES IN DATATABLE: $($dups.Count) vouchers!"
    }
}

$conn.Close()
