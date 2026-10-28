$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$con = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$con.Open()
$cmd = $con.CreateCommand()

$studentId = "736"
$currentFeeMonth = "01 2027"
$branchId = "1"
$sessionId = "2"

function GetFeeMonthSortKey($m) {
    if ([string]::IsNullOrEmpty($m)) { return 0 }
    $parts = $m.Trim().Split(@(' ', '/', '-', '.'), [System.StringSplitOptions]::RemoveEmptyEntries)
    if ($parts.Length -eq 2) {
        $first = 0; $second = 0
        if ([int]::TryParse($parts[0], [ref]$first) -and [int]::TryParse($parts[1], [ref]$second)) {
            if ($first > 1000) { return $first * 12 + $second }
            if ($second > 1000) { return $second * 12 + $first }
        }
    }
    return 0
}

$targetKey = GetFeeMonthSortKey $currentFeeMonth
Write-Host "Target key for '$currentFeeMonth': $targetKey"

$cmd.CommandText = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID FROM FEE_MASTER WHERE s_id = '$studentId' AND branch_id = '$branchId' AND SessionID = '$sessionId' ORDER BY FEE_MASTER_ID"
$da = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
$dt = New-Object System.Data.DataTable
$da.Fill($dt) | Out-Null

$priorVouchers = New-Object System.Collections.Generic.List[System.Data.DataRow]
foreach ($row in $dt.Rows) {
    $vMonth = $row["FEE_MONTH"].ToString().Trim()
    $vKey = GetFeeMonthSortKey $vMonth
    Write-Host "Voucher $($row['FEE_MASTER_ID']) month '$vMonth' -> key $vKey"
    if ($targetKey -gt 0 -and $vKey -gt 0) {
        if ($vKey -lt $targetKey) {
            $priorVouchers.Add($row)
            Write-Host "  Added to prior vouchers (vKey < targetKey)"
        }
    }
}

Write-Host "Prior vouchers count: $($priorVouchers.Count)"

$totalPriorDebt = 0
$totalPriorPayments = 0

for ($i = 0; $i -lt $priorVouchers.Count; $i++) {
    $v = $priorVouchers[$i]
    $vMasterId = $v["FEE_MASTER_ID"].ToString()
    $recAmt = 0
    if ($v["REC_AMOUNT"] -ne [DBNull]::Value -and $v["REC_AMOUNT"].ToString() -ne "") {
        $recAmt = [double]$v["REC_AMOUNT"]
    } elseif ($v["PAID"] -ne [DBNull]::Value -and $v["PAID"].ToString().Trim().ToUpper() -eq "Y") {
        $bal = [double]$v["BALANCE"]
        $recv = [double]$v["RECEIVABLE_AMOUNT"]
        if ($bal -le 0 -and $recv -gt 0) { $recAmt = $recv }
    }
    $totalPriorPayments += $recAmt
    Write-Host "Voucher $vMasterId payment: $recAmt, Total payments: $totalPriorPayments"

    if ($i -eq 0) {
        $recv = [double]$v["RECEIVABLE_AMOUNT"]
        Write-Host "Voucher $vMasterId (i=0): recv = $recv"
        if ($recv -eq 0) {
            # Detail sum
        }
        $totalPriorDebt += $recv
        Write-Host "Total prior debt after i=0: $totalPriorDebt"
    } else {
        $qDetail = "SELECT d.AMOUNT FROM FEE_DETAIL d LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID = '$vMasterId' AND (h.Category IS NULL OR (h.Category <> 'ARREAR' AND UPPER(h.Fee_head) NOT LIKE '%ARREAR%')) AND (d.ISCURRENT IS NULL OR d.ISCURRENT = 'Y')"
        $cmd.CommandText = $qDetail
        $rDet = $cmd.ExecuteReader()
        $curVoucherCurrentSum = 0
        while ($rDet.Read()) {
            $damt = [double]$rDet["AMOUNT"]
            $curVoucherCurrentSum += $damt
            Write-Host "  Detail row amount: $damt"
        }
        $rDet.Close()
        Write-Host "Voucher $vMasterId (i>0): current fee sum = $curVoucherCurrentSum"
        $totalPriorDebt += $curVoucherCurrentSum
        Write-Host "Total prior debt: $totalPriorDebt"
    }
}

$outstanding = $totalPriorDebt - $totalPriorPayments
Write-Host "FINAL COMPUTED OUTSTANDING: $outstanding (debt=$totalPriorDebt, payments=$totalPriorPayments)"

$con.Close()
