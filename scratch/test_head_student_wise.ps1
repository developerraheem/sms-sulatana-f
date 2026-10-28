$binPath = (Resolve-Path 'bin\Debug\School.exe').Path
$asm = [System.Reflection.Assembly]::LoadFrom($binPath)

$dsType = $asm.GetType('School.DataSet_Fee_Summary_Reports')
$ds = [Activator]::CreateInstance($dsType)

$adapterType = $asm.GetType('School.DataSet_Fee_Summary_ReportsTableAdapters.HEAD_STUDENT_WISE_FEETableAdapter')
$adapter = [Activator]::CreateInstance($adapterType)

# Let's inspect Connection property
$prop = $adapterType.GetProperty('Connection', [System.Reflection.BindingFlags]'Instance,NonPublic,Public')
$conn = $prop.GetValue($adapter, $null)
$conn.ConnectionString = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'

$table = $ds.Tables['HEAD_STUDENT_WISE_FEE']

Write-Host "=== TEST: FillBy_ALL for Branch 6 (Session 49, Month 05 2025) ==="
# Parameters: dataTable, sessionid, feemonth, section_from, section_to, type_from, type_to, classfrom, classto
$adapter.FillBy_ALL($table, "49", "05 2025", "Boys", "Girls", "General", "General", 122, 182) | Out-Null
Write-Host ("Rows returned: " + $table.Rows.Count)

# Check vouchers
$dups = $table | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
Write-Host ("Vouchers with multiple rows: " + $dups.Count)

# Let's check what students appear:
$stdGroups = $table | Group-Object s_name | Where-Object { $_.Count -gt 1 }
Write-Host ("Students appearing multiple times in table: " + $stdGroups.Count)
foreach ($g in ($stdGroups | Select-Object -First 5)) {
    Write-Host ("Student: " + $g.Name + " (" + $g.Count + " rows)")
    foreach ($row in $g.Group) {
        Write-Host ("   Voucher=" + $row["FEE_MASTER_ID"] + ", Month=" + $row["FEE_MONTH"] + ", Head=" + $row["Fee_head"] + ", Amt=" + $row["AMOUNT"] + ", Rec=" + $row["RECEIVED_AMOUNT"])
    }
}
