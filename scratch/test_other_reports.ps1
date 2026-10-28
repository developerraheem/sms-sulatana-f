$connStr = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connStr)
$conn.Open()

Write-Host "=================================================="
Write-Host "1. DefaulterStudent_all query for Branch 6:"
Write-Host "=================================================="
# CommandCollection[0] of DEFAULTER_DETAILTableAdapter:
# SELECT FEE_MASTER.FEE_MASTER_ID, student.s_id, student.s_name, student.ADMISSION_NO, Sections.SECTION_NAME, ...
# WHERE (FEE_MASTER.FEE_MONTH = @feemonth) AND (FEE_MASTER.SessionID = @sessionid) AND FEE_MASTER.BALANCE>0
# Test with Month = '05 2025', Session = 49 (Branch 6 session):
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, student.s_name, Sections.SECTION_NAME, Sections.BRANCH_ID as sec_branch, student.branch_id as std_branch, FEE_MASTER.branch_id as fm_branch
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN
     class ON FEE_MASTER.C_ID = class.c_id AND student.c_id = class.c_id
WHERE (FEE_MASTER.FEE_MONTH = '05 2025') AND (FEE_MASTER.SessionID = 49) AND FEE_MASTER.BALANCE > 0
ORDER BY FEE_MASTER.FEE_MASTER_ID
"@
$r = $cmd.ExecuteReader()
$defRows = @()
while ($r.Read()) {
    $defRows += [PSCustomObject]@{
        Voucher = $r[0]
        Name = $r[1]
        Section = $r[2]
        SecBranch = $r[3]
        StdBranch = $r[4]
        FmBranch = $r[5]
    }
}
$r.Close()
Write-Host ("Defaulter rows count: " + $defRows.Count)
$dups = $defRows | Group-Object Voucher | Where-Object { $_.Count -gt 1 }
Write-Host ("Defaulter duplicate vouchers count: " + $dups.Count)
foreach ($d in $dups) {
    Write-Host ("Duplicate Voucher " + $d.Name + " (" + $d.Count + " rows):")
    foreach ($item in $d.Group) {
        Write-Host ("   Sec=" + $item.Section + ", SecBranch=" + $item.SecBranch + ", StdBranch=" + $item.StdBranch + ", FmBranch=" + $item.FmBranch)
    }
}

Write-Host "`n=================================================="
Write-Host "2. DateWisePostedReport query for Branch 6:"
Write-Host "=================================================="
# CommandText:
# SELECT FEE_MASTER.FEE_MASTER_ID, student.s_id, student.s_name, student.ADMISSION_NO, Sections.SECTION_NAME, ...
# FROM FEE_MASTER INNER JOIN student ON FEE_MASTER.s_id = student.s_id INNER JOIN Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN class ON student.c_id = class.c_id
# WHERE (FEE_MASTER.PAID = 'Y')
# Test with submit dates from Branch 6:
$cmd.CommandText = @"
SELECT FEE_MASTER.FEE_MASTER_ID, student.s_name, Sections.SECTION_NAME, Sections.BRANCH_ID as sec_branch, FEE_MASTER.branch_id as fm_branch
FROM FEE_MASTER INNER JOIN
     student ON FEE_MASTER.s_id = student.s_id INNER JOIN
     Sections ON student.SECTION_ID = Sections.SECTION_ID INNER JOIN
     class ON student.c_id = class.c_id
WHERE (FEE_MASTER.PAID = 'Y') AND (FEE_MASTER.SUBMIT_DATE BETWEEN '2025-05-01' AND '2025-05-31') AND FEE_MASTER.branch_id = 6
"@
$r = $cmd.ExecuteReader()
$dateRows = @()
while ($r.Read()) {
    $dateRows += [PSCustomObject]@{
        Voucher = $r[0]
        Name = $r[1]
        Section = $r[2]
        SecBranch = $r[3]
        FmBranch = $r[4]
    }
}
$r.Close()
Write-Host ("DateWisePosted rows count for Branch 6: " + $dateRows.Count)
$dupsDate = $dateRows | Group-Object Voucher | Where-Object { $_.Count -gt 1 }
Write-Host ("DateWisePosted duplicate vouchers count: " + $dupsDate.Count)
foreach ($d in ($dupsDate | Select-Object -First 5)) {
    Write-Host ("Duplicate Voucher " + $d.Name + " (" + $d.Count + " rows):")
    foreach ($item in $d.Group) {
        Write-Host ("   Sec=" + $item.Section + ", SecBranch=" + $item.SecBranch + ", FmBranch=" + $item.FmBranch)
    }
}

$conn.Close()
