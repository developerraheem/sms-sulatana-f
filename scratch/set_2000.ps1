$c = New-Object System.Data.SqlClient.SqlConnection "Server=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"
$c.Open()
$cmd = $c.CreateCommand()

# Update Head 77 to 2000 for Class 8889 to test exactly 2000
$cmd.CommandText = "UPDATE FEE_CLASS SET AMOUNT = 2000 WHERE C_ID = 8889 AND Fee_head_id = 77"
$cmd.ExecuteNonQuery() | Out-Null
$c.Close()
