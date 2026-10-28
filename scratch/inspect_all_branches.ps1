$con = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;")
$con.Open()
$cmd = $con.CreateCommand()

Write-Output "=========================================================="
Write-Output "             BRANCH SUMMARY ACROSS ALL 15 BRANCHES        "
Write-Output "=========================================================="

for ($b = 1; $b -le 15; $b++) {
    $cmd.CommandText = "SELECT branch_name FROM Branch WHERE branch_id='$b'"
    $bName = $cmd.ExecuteScalar()
    
    $cmd.CommandText = "SELECT COUNT(*) FROM student WHERE branch_id='$b'"
    $totalStudents = $cmd.ExecuteScalar()

    $cmd.CommandText = "SELECT COUNT(*) FROM student WHERE branch_id='$b' AND active='true'"
    $activeStudents = $cmd.ExecuteScalar()

    $cmd.CommandText = "SELECT COUNT(*) FROM class WHERE branch_id='$b'"
    $totalClasses = $cmd.ExecuteScalar()

    $cmd.CommandText = "SELECT COUNT(*) FROM Fee_Head WHERE branch_id='$b'"
    $totalHeads = $cmd.ExecuteScalar()

    $cmd.CommandText = "SELECT COUNT(*) FROM Fee_Head WHERE branch_id='$b' AND Category IN ('FINE', 'DISCOUNT', 'CONCESSION')"
    $fineDiscountHeads = $cmd.ExecuteScalar()

    $cmd.CommandText = "SELECT COUNT(DISTINCT SessionID) FROM student WHERE branch_id='$b'"
    $sessions = $cmd.ExecuteScalar()

    Write-Output ("Branch " + $b + ": " + $bName)
    Write-Output ("  Students: Total=" + $totalStudents + ", Active=" + $activeStudents + " | Classes=" + $totalClasses + " | FeeHeads: Total=" + $totalHeads + ", Fine/Disc=" + $fineDiscountHeads + " | Student Sessions=" + $sessions)
}

$con.Close()
