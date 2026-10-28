$binPath = (Resolve-Path 'bin\Debug\School.exe').Path
$asm = [System.Reflection.Assembly]::LoadFrom($binPath)

$dsType = $asm.GetType('School.Report_DataSet_new')
$ds = [Activator]::CreateInstance($dsType)

$adapterType = $asm.GetType('School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter')
$adapter = [Activator]::CreateInstance($adapterType)
$prop = $adapterType.GetProperty('Connection', [System.Reflection.BindingFlags]'Instance,NonPublic,Public')
$conn = $prop.GetValue($adapter, $null)
$conn.ConnectionString = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'

$table = $ds.Tables['FEE_HISTORY']

# Let's get distinct parameters for Branch 6 from FEE_MASTER:
$sqlConn = New-Object System.Data.SqlClient.SqlConnection($conn.ConnectionString)
$sqlConn.Open()

$cmd = $sqlConn.CreateCommand()
$cmd.CommandText = @"
SELECT DISTINCT f.C_ID, f.SHIFT, f.FEE_MONTH, f.SessionID, s.SECTION_ID
FROM FEE_MASTER f
INNER JOIN student s ON f.s_id = s.s_id AND f.branch_id = s.branch_id
WHERE f.branch_id = 6
ORDER BY f.SessionID, f.C_ID, f.FEE_MONTH
"@
$r = $cmd.ExecuteReader()
$combos = @()
while ($r.Read()) {
    $combos += [PSCustomObject]@{
        C_ID = $r[0].ToString()
        SHIFT = $r[1].ToString()
        FEE_MONTH = $r[2].ToString()
        SessionID = [decimal]$r[3]
        SECTION_ID = $r[4].ToString()
    }
}
$r.Close()
$sqlConn.Close()

Write-Host ("Testing " + $combos.Count + " parameter combinations for Branch 6 in FEE_HISTORY...")

$dupFillCount = 0
$dupUnpaidCount = 0
$dupPaidCount = 0

foreach ($c in $combos) {
    # 1. Test Fill
    $table.Clear()
    $adapter.Fill($table, $c.C_ID, $c.SHIFT, $c.FEE_MONTH, $c.SessionID) | Out-Null
    $dups = $table | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
    if ($dups.Count -gt 0) {
        Write-Host ("DUP in Fill: C_ID=" + $c.C_ID + ", Month=" + $c.FEE_MONTH + ", Session=" + $c.SessionID + ", Dups=" + $dups.Count)
        $dupFillCount++
    }

    # 2. Test Unpaid
    $table.Clear()
    $adapter.Unpaid($table, $c.C_ID, $c.SHIFT, $c.FEE_MONTH, $c.SECTION_ID, $c.SessionID) | Out-Null
    $dups2 = $table | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
    if ($dups2.Count -gt 0) {
        Write-Host ("DUP in Unpaid: C_ID=" + $c.C_ID + ", Month=" + $c.FEE_MONTH + ", Sec=" + $c.SECTION_ID + ", Session=" + $c.SessionID + ", Dups=" + $dups2.Count)
        $dupUnpaidCount++
    }

    # 3. Test Paid
    $table.Clear()
    $adapter.Paid($table, $c.C_ID, $c.SHIFT, $c.FEE_MONTH, $c.SessionID) | Out-Null
    $dups3 = $table | Group-Object FEE_MASTER_ID | Where-Object { $_.Count -gt 1 }
    if ($dups3.Count -gt 0) {
        Write-Host ("DUP in Paid: C_ID=" + $c.C_ID + ", Month=" + $c.FEE_MONTH + ", Session=" + $c.SessionID + ", Dups=" + $dups3.Count)
        $dupPaidCount++
    }
}

Write-Host "Done testing!"
Write-Host "Total combinations with dups in Fill: $dupFillCount"
Write-Host "Total combinations with dups in Unpaid: $dupUnpaidCount"
Write-Host "Total combinations with dups in Paid: $dupPaidCount"
