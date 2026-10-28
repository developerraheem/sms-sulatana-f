$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()

function Test-Query($q, $desc) {
    Write-Host "--- Testing: $desc ---"
    Write-Host "Query: $q"
    try {
        $cmd = New-Object System.Data.SqlClient.SqlCommand($q, $conn)
        $adp = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
        $ds = New-Object System.Data.DataSet
        $adp.Fill($ds, "student")
        Write-Host "SUCCESS: Rows count = $($ds.Tables['student'].Rows.Count)"
    } catch {
        Write-Host "ERROR: $($_.Exception.Message)"
    }
}

# Test 1: Normal with branch_id = '6', c_id = '122', s_id in (88883)
Test-Query "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and s_id in (88883) AND SessionID='68' and branch_id='6' and SECTION_ID='Boys'" "All valid values"

# Test 2: What if branch_id is empty string ''?
Test-Query "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and s_id in (88883) AND SessionID='68' and branch_id='' and SECTION_ID='Boys'" "branch_id is empty string"

# Test 3: What if branch_id is null?
Test-Query "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and s_id in (88883) AND SessionID='68' and branch_id=NULL and SECTION_ID='Boys'" "branch_id is null"

# Test 4: What if c_id is empty string ''?
Test-Query "Select * from student where c_id ='' and active='true' AND SHIFT ='Morning' and s_id in (88883) AND SessionID='68' and branch_id='6' and SECTION_ID='Boys'" "c_id is empty string"

# Test 5: What if c_id is 'System.Data.DataRowView'?
Test-Query "Select * from student where c_id ='System.Data.DataRowView' and active='true' AND SHIFT ='Morning' and s_id in (88883) AND SessionID='68' and branch_id='6' and SECTION_ID='Boys'" "c_id is DataRowView"

# Test 6: What if s_id in ('')?
Test-Query "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and s_id in ('') AND SessionID='68' and branch_id='6' and SECTION_ID='Boys'" "s_id in ('')"

# Test 7: What if idList has quotes or non-numeric?
Test-Query "Select * from student where c_id ='122' and active='true' AND SHIFT ='Morning' and s_id in ('88883') AND SessionID='68' and branch_id='6' and SECTION_ID='Boys'" "s_id in ('88883')"

$conn.Close()
