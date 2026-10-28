$con = New-Object System.Data.SqlClient.SqlConnection('Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF;Integrated Security=True;')
$con.Open()

$cmd = $con.CreateCommand()
for ($b = 1; $b -le 15; $b++) {
    $cmd.CommandText = @"
SELECT TOP 1 Fee_head_id, Fee_head, Category, branch_id 
FROM Fee_Head 
WHERE branch_id = '$b' 
  AND (Category = 'ARREAR' OR UPPER(Fee_head) LIKE '%ARREAR%')
ORDER BY 
  CASE WHEN Category = 'ARREAR' THEN 1 ELSE 2 END,
  CASE WHEN UPPER(LTRIM(RTRIM(Fee_head))) = 'ARREARS' THEN 1 
       WHEN UPPER(LTRIM(RTRIM(Fee_head))) = 'PREVIOUS ARREARS' THEN 2 
       ELSE 3 END,
  Fee_head_id
"@
    $r = $cmd.ExecuteReader()
    if ($r.Read()) {
        Write-Host "Branch $b -> Head_ID: $($r['Fee_head_id']), Name: '$($r['Fee_head'])', Category: '$($r['Category'])'"
    } else {
        Write-Host "Branch $b -> NO ARREAR HEAD FOUND" -ForegroundColor Yellow
    }
    $r.Close()
}
$con.Close()
