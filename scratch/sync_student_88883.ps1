$conn = New-Object System.Data.SqlClient.SqlConnection("Server=(localdb)\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;")
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = @"
IF NOT EXISTS (SELECT 1 FROM student WHERE s_id = 88883)
BEGIN
    INSERT INTO student (
        c_id, s_id, ADMISSION_NO, s_name, f_name, age, sex, active, roll_no, 
        m_fee, CONCESSION_FEE, SECTION_ID, SessionID, SHIFT, TYPE, branch_id, STUDENT_ID
    )
    SELECT 
        c_id, s_id, ADMISSION_NO, s_name, f_name, age, sex, active, roll_no, 
        m_fee, CONCESSION_FEE, SECTION_ID, SessionID, SHIFT, TYPE, branch_id, STUDENT_ID
    FROM SCMS_SF.dbo.student WHERE s_id = 88883;
END
"@
$rows = $cmd.ExecuteNonQuery()
Write-Host "Result: $rows"
$conn.Close()
