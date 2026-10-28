$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()

function Get-FeeMonthSortKey([string]$feeMonth) {
    if ([string]::IsNullOrEmpty($feeMonth)) { return 0 }
    $s = $feeMonth.Trim()
    $parts = $s.Split(@(' ', '/', '-', '.'), [System.StringSplitOptions]::RemoveEmptyEntries)
    if ($parts.Length -eq 2) {
        $p0 = 0; $p1 = 0
        if ([int]::TryParse($parts[0], [ref]$p0) -and [int]::TryParse($parts[1], [ref]$p1)) {
            if ($p1 -gt 1000 -and $p0 -ge 1 -and $p0 -le 12) {
                return $p1 * 12 + $p0
            }
            if ($p0 -gt 1000 -and $p1 -ge 1 -and $p1 -le 12) {
                return $p0 * 12 + $p1
            }
        }
    }
    $dt = [DateTime]::MinValue
    if ([DateTime]::TryParse($s, [ref]$dt)) {
        return $dt.Year * 12 + $dt.Month
    }
    return 0
}

Write-Host "Testing Get-FeeMonthSortKey:"
Write-Host "  '11 2026' ->" (Get-FeeMonthSortKey "11 2026") "(expected 24323)"
Write-Host "  '12 2026' ->" (Get-FeeMonthSortKey "12 2026") "(expected 24324)"
Write-Host "  '01 2027' ->" (Get-FeeMonthSortKey "01 2027") "(expected 24325)"
Write-Host "  '11/2026' ->" (Get-FeeMonthSortKey "11/2026") "(expected 24323)"

$con.Close()
