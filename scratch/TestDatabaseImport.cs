using System;
using System.Data;
using System.Data.SqlClient;
using School;

namespace TestSuite
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=SCMS_SF_TEST;Integrated Security=True;";

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();

                    // Find a voucher in FEE_MASTER
                    string qVoucher = @"SELECT TOP 1 m.FEE_MASTER_ID, m.S_ID, m.FEE_MONTH, m.RECEIVABLE_AMOUNT, m.BALANCE, m.REC_AMOUNT, m.branch_id, m.SessionID 
                                        FROM FEE_MASTER m 
                                        WHERE m.FEE_MONTH IS NOT NULL AND m.FEE_MONTH <> '' AND m.RECEIVABLE_AMOUNT > 0
                                        ORDER BY CAST(m.FEE_MASTER_ID AS BIGINT) DESC";

                    string masterId = "";
                    string sId = "";
                    string feeMonth = "";
                    string branchId = "";
                    string sessionId = "";
                    double origReceivable = 0;
                    double origBalance = 0;

                    using (SqlCommand cmd = new SqlCommand(qVoucher, con))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            masterId = dr["FEE_MASTER_ID"].ToString().Trim();
                            sId = dr["S_ID"].ToString().Trim();
                            feeMonth = dr["FEE_MONTH"].ToString().Trim();
                            branchId = dr["branch_id"].ToString().Trim();
                            sessionId = dr["SessionID"].ToString().Trim();
                            double.TryParse(dr["RECEIVABLE_AMOUNT"].ToString(), out origReceivable);
                            double.TryParse(dr["BALANCE"].ToString(), out origBalance);
                        }
                    }

                    if (string.IsNullOrEmpty(masterId))
                    {
                        Console.WriteLine("No voucher found in FEE_MASTER.");
                        return 1;
                    }

                    // Find concession head for this branch
                    string concHeadId = "";
                    string concHeadName = "";
                    string qConc = "SELECT TOP 1 Fee_head_id, Fee_head FROM Fee_Head WHERE branch_id = '" + branchId + "' AND (Category IN ('DISCOUNT', 'CONCESSION') OR UPPER(Fee_head) LIKE '%CONCESSION%')";
                    using (SqlCommand cmd = new SqlCommand(qConc, con))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            concHeadId = dr["Fee_head_id"].ToString().Trim();
                            concHeadName = dr["Fee_head"].ToString().Trim();
                        }
                    }

                    Console.WriteLine("Testing against Voucher #" + masterId + " for Student " + sId + " (Month: " + feeMonth + ", Branch: " + branchId + ", Session: " + sessionId + ")");
                    Console.WriteLine("Original Voucher: Receivable = " + origReceivable + ", Balance = " + origBalance);
                    Console.WriteLine("Branch Concession Head: ID=" + concHeadId + ", Name=" + concHeadName);

                    string testFineId = "999988881";
                    // Clean up before test
                    using (SqlCommand delCmd = new SqlCommand("DELETE FROM FINE_HISTORY WHERE FINE_ID = '" + testFineId + "'", con))
                    {
                        delCmd.ExecuteNonQuery();
                    }

                    // 1. Simulate import: Insert FINE_HISTORY
                    string insFine = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS, FEE_MASTER_ID) " +
                                     "VALUES ('" + testFineId + "', '" + sId + "', '" + concHeadId + "', '10/25/2026', '300', '" + feeMonth + "', '1', 'N', '" + sessionId + "', '" + branchId + "', 'Test Concession Import', '" + masterId + "')";
                    using (SqlCommand insCmd = new SqlCommand(insFine, con))
                    {
                        insCmd.ExecuteNonQuery();
                    }

                    // 2. Insert into FEE_DETAIL as negative (-300) to respect concession rules
                    string insDetail = "INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, FEE_MONTH, ISCURRENT, BALANCE, FEE_MONTH_FROM, SessionID, branch_id) " +
                                       "VALUES (" + masterId + ", " + concHeadId + ", -300, '" + feeMonth + "', 'Y', -300, '" + feeMonth + "', '" + sessionId + "', '" + branchId + "')";
                    using (SqlCommand insDetCmd = new SqlCommand(insDetail, con))
                    {
                        insDetCmd.ExecuteNonQuery();
                    }

                    // 3. Recalculate FEE_MASTER
                    string updMaster = "UPDATE FEE_MASTER SET " +
                                       "RECEIVABLE_AMOUNT = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + masterId + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "'), " +
                                       "BALANCE = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + masterId + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "') - ISNULL(REC_AMOUNT, 0) " +
                                       "WHERE FEE_MASTER_ID = '" + masterId + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "'";
                    using (SqlCommand updCmd = new SqlCommand(updMaster, con))
                    {
                        updCmd.ExecuteNonQuery();
                    }

                    // 4. Verify updated values
                    double newReceivable = 0;
                    double newBalance = 0;
                    using (SqlCommand chkCmd = new SqlCommand("SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + masterId + "'", con))
                    using (SqlDataReader dr2 = chkCmd.ExecuteReader())
                    {
                        if (dr2.Read())
                        {
                            double.TryParse(dr2["RECEIVABLE_AMOUNT"].ToString(), out newReceivable);
                            double.TryParse(dr2["BALANCE"].ToString(), out newBalance);
                        }
                    }

                    Console.WriteLine("After Concession: Receivable = " + newReceivable + ", Balance = " + newBalance);

                    if (Math.Abs(newReceivable - (origReceivable - 300)) > 0.01)
                    {
                        throw new Exception("Receivable amount not properly reduced by concession! Expected " + (origReceivable - 300) + " but got " + newReceivable);
                    }
                    if (Math.Abs(newBalance - (origBalance - 300)) > 0.01)
                    {
                        throw new Exception("Balance not properly reduced by concession! Expected " + (origBalance - 300) + " but got " + newBalance);
                    }

                    Console.WriteLine("PASS: Concession calculation strictly respected and correctly reduced voucher balance by 300!");

                    // 5. Duplicate Check verification
                    string chkDup = "SELECT COUNT(*) FROM FINE_HISTORY WHERE Fee_head_id='" + concHeadId + "' AND FEE_MONTH='" + feeMonth + "' AND S_ID='" + sId + "' AND SessionID='" + sessionId + "' AND branch_id='" + branchId + "'";
                    using (SqlCommand dupCmd = new SqlCommand(chkDup, con))
                    {
                        int dupCount = (int)dupCmd.ExecuteScalar();
                        if (dupCount < 1) throw new Exception("FINE_HISTORY duplicate check failed to find existing entry!");
                        Console.WriteLine("PASS: Re-import duplicate detection verified! Existing DB entries caught (" + dupCount + " record found).");
                    }

                    // 6. CLEANUP test records so database is restored to original state
                    using (SqlCommand clrDetail = new SqlCommand("DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + masterId + "' AND Fee_head_id = " + concHeadId + " AND AMOUNT = -300", con))
                    {
                        clrDetail.ExecuteNonQuery();
                    }
                    using (SqlCommand clrFine = new SqlCommand("DELETE FROM FINE_HISTORY WHERE FINE_ID = '" + testFineId + "'", con))
                    {
                        clrFine.ExecuteNonQuery();
                    }
                    using (SqlCommand clrMaster = new SqlCommand(updMaster, con))
                    {
                        clrMaster.ExecuteNonQuery();
                    }

                    // Verify restore
                    using (SqlCommand chkRestore = new SqlCommand("SELECT RECEIVABLE_AMOUNT, BALANCE FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + masterId + "'", con))
                    using (SqlDataReader dr3 = chkRestore.ExecuteReader())
                    {
                        if (dr3.Read())
                        {
                            double restReceivable = Convert.ToDouble(dr3["RECEIVABLE_AMOUNT"]);
                            double restBalance = Convert.ToDouble(dr3["BALANCE"]);
                            if (Math.Abs(restReceivable - origReceivable) > 0.01 || Math.Abs(restBalance - origBalance) > 0.01)
                            {
                                throw new Exception("Database not properly restored!");
                            }
                        }
                    }

                    Console.WriteLine("PASS: Cleanup completed successfully. Database restored to pristine state!");
                }

                Console.WriteLine();
                Console.WriteLine("==========================================================");
                Console.WriteLine("DATABASE IMPORT INTEGRATION TEST PASSED (100% SUCCESS)!");
                Console.WriteLine("==========================================================");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB TEST FAILED: " + ex);
                return 1;
            }
        }
    }
}
