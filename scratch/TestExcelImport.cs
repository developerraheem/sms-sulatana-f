using System;
using System.Data;
using System.Reflection;
using School;
using School._forms;

namespace TestSuite
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                SYSTEMSETTING.branch_ID = "1";
                SYSTEMSETTING.sessionid = "81";

                Console.WriteLine("==========================================================");
                Console.WriteLine("TEST 1: Month Normalization and Amount Parsing");
                Console.WriteLine("==========================================================");

                string norm;
                bool ok = FrmExcelImportPreview.TryNormalizeFeeMonth("10 2026", out norm);
                if (!ok || norm != "10 2026") throw new Exception("Failed norm for '10 2026': " + norm);

                ok = FrmExcelImportPreview.TryNormalizeFeeMonth("October 2026", out norm);
                if (!ok || norm != "10 2026") throw new Exception("Failed norm for 'October 2026': " + norm);

                ok = FrmExcelImportPreview.TryNormalizeFeeMonth("9 2026", out norm);
                if (!ok || norm != "09 2026") throw new Exception("Failed norm for '9 2026': " + norm);

                ok = FrmExcelImportPreview.TryNormalizeFeeMonth("2026-10-01", out norm);
                if (!ok || norm != "10 2026") throw new Exception("Failed norm for '2026-10-01': " + norm);

                ok = FrmExcelImportPreview.TryNormalizeFeeMonth("15/10/2026", out norm);
                if (!ok || norm != "10 2026") throw new Exception("Failed norm for '15/10/2026': " + norm);

                ok = FrmExcelImportPreview.TryNormalizeFeeMonth("invalid_month", out norm);
                if (ok) throw new Exception("Expected failure for invalid_month");

                Console.WriteLine("PASS: Month normalization tests passed!");

                double amt;
                ok = FrmExcelImportPreview.TryParseFineAmount("Rs. 1,500", out amt);
                if (!ok || Math.Abs(amt - 1500) > 0.01) throw new Exception("Failed parse for 'Rs. 1,500': " + amt);

                ok = FrmExcelImportPreview.TryParseFineAmount("PKR 250.50", out amt);
                if (!ok || Math.Abs(amt - 250.50) > 0.01) throw new Exception("Failed parse for 'PKR 250.50': " + amt);

                ok = FrmExcelImportPreview.TryParseFineAmount("invalid_amount", out amt);
                if (ok) throw new Exception("Expected failure for invalid_amount");

                Console.WriteLine("PASS: Amount parsing tests passed!");

                Console.WriteLine();
                Console.WriteLine("==========================================================");
                Console.WriteLine("TEST 2: Preview Validation, Multi-Row, Multi-Head & Duplicate Check");
                Console.WriteLine("==========================================================");

                DataTable dt = new DataTable();
                dt.Columns.Add("Student ID");
                dt.Columns.Add("Class");
                dt.Columns.Add("Fee Month");
                dt.Columns.Add("Fee Head");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Reason");

                // Row 1: Student 2093, Monthly Contribution
                dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Regular monthly fee");
                // Row 2: Same Student 2093, Late Fee Fine
                dt.Rows.Add("2093", "PM-1G", "10 2026", "Late Fee Fine", "200", "Late payment");
                // Row 3: Same Student 2093, Fee Concession
                dt.Rows.Add("2093", "PM-1G", "10 2026", "Fee Concession", "500", "Sibling concession");
                // Row 4: Duplicate of Row 1 in same file
                dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Duplicate Tuition");
                // Row 5: Ghost student ID
                dt.Rows.Add("99999999", "PM-1G", "10 2026", "Monthly Contribution", "2500", "Ghost student");
                // Row 6: Non-existent Fee Head
                dt.Rows.Add("2093", "PM-1G", "10 2026", "Fantasy Space Head", "500", "Bad head");
                // Row 7: Invalid Fee Month
                dt.Rows.Add("2093", "PM-1G", "Nonsense Month", "Monthly Contribution", "2500", "Bad month");
                // Row 8: Invalid Amount
                dt.Rows.Add("2093", "PM-1G", "10 2026", "Monthly Contribution", "FreeOfCost", "Bad amt");

                using (FrmExcelImportPreview preview = new FrmExcelImportPreview(dt, "10 2026", "39", "MONTHLY CONTRIBUTION", "1"))
                {
                    MethodInfo load = typeof(FrmExcelImportPreview).GetMethod("FrmExcelImportPreview_Load", BindingFlags.NonPublic | BindingFlags.Instance);
                    load.Invoke(preview, new object[] { null, EventArgs.Empty });

                    FieldInfo fi = typeof(FrmExcelImportPreview).GetField("processedItems", BindingFlags.NonPublic | BindingFlags.Instance);
                    System.Collections.IList items = (System.Collections.IList)fi.GetValue(preview);

                    Console.WriteLine("Total Rows Processed: " + items.Count);

                    for (int i = 0; i < items.Count; i++)
                    {
                        object item = items[i];
                        Type itemType = item.GetType();
                        int rowNum = (int)itemType.GetField("RowNum").GetValue(item);
                        string sId = (string)itemType.GetField("InputStudentId").GetValue(item);
                        string month = (string)itemType.GetField("ResolvedFeeMonth").GetValue(item);
                        object headObj = itemType.GetField("ResolvedFeeHead").GetValue(item);
                        string headName = headObj != null ? (string)headObj.GetType().GetField("HeadName").GetValue(headObj) : "NULL";
                        bool isConc = headObj != null ? (bool)headObj.GetType().GetProperty("IsConcession").GetValue(headObj, null) : false;
                        double rowAmt = (double)itemType.GetField("Amount").GetValue(item);
                        string status = (string)itemType.GetField("Status").GetValue(item);
                        string notes = (string)itemType.GetField("Notes").GetValue(item);

                        Console.WriteLine("Row " + rowNum + ": ID=" + sId + ", Month=" + month + ", Head=" + headName + " (IsConc=" + isConc + "), Amt=" + rowAmt + ", Status=" + status + ", Notes=" + notes);
                    }

                    // Verify Row 1: VALID, MONTHLY CONTRIBUTION
                    object item0 = items[0];
                    string s0 = (string)item0.GetType().GetField("Status").GetValue(item0);
                    if (s0 != "VALID") throw new Exception("Row 1 should be VALID but is " + s0);

                    // Verify Row 2: VALID, LATE FEE FINE (multi-head same student)
                    object item1 = items[1];
                    string s1 = (string)item1.GetType().GetField("Status").GetValue(item1);
                    if (s1 != "VALID") throw new Exception("Row 2 should be VALID but is " + s1);

                    // Verify Row 3: VALID, FEE CONCESSION (IsConcession = true)
                    object item2 = items[2];
                    string s2 = (string)item2.GetType().GetField("Status").GetValue(item2);
                    object head2 = item2.GetType().GetField("ResolvedFeeHead").GetValue(item2);
                    bool conc2 = (bool)head2.GetType().GetProperty("IsConcession").GetValue(head2, null);
                    if (s2 != "VALID") throw new Exception("Row 3 should be VALID but is " + s2);
                    if (!conc2) throw new Exception("Row 3 must have IsConcession=true!");

                    // Verify Row 4: DUPLICATE (in-file duplicate)
                    object item3 = items[3];
                    string s3 = (string)item3.GetType().GetField("Status").GetValue(item3);
                    if (s3 != "DUPLICATE") throw new Exception("Row 4 should be DUPLICATE but is " + s3);

                    // Verify Row 5: INVALID (student ID missing from active records)
                    object item4 = items[4];
                    string s4 = (string)item4.GetType().GetField("Status").GetValue(item4);
                    if (s4 != "INVALID") throw new Exception("Row 5 should be INVALID but is " + s4);

                    // Verify Row 6: INVALID (fee head not configured)
                    object item5 = items[5];
                    string s5 = (string)item5.GetType().GetField("Status").GetValue(item5);
                    if (s5 != "INVALID") throw new Exception("Row 6 should be INVALID but is " + s5);

                    // Verify Row 7: INVALID (invalid fee month)
                    object item6 = items[6];
                    string s6 = (string)item6.GetType().GetField("Status").GetValue(item6);
                    if (s6 != "INVALID") throw new Exception("Row 7 should be INVALID but is " + s6);

                    // Verify Row 8: INVALID (invalid amount)
                    object item7 = items[7];
                    string s7 = (string)item7.GetType().GetField("Status").GetValue(item7);
                    if (s7 != "INVALID") throw new Exception("Row 8 should be INVALID but is " + s7);

                    Console.WriteLine("PASS: All validation, multi-row, multi-head, and concession assertions passed!");
                }

                Console.WriteLine();
                Console.WriteLine("==========================================================");
                Console.WriteLine("TEST 3: Backward Compatibility with Legacy Fine Template");
                Console.WriteLine("==========================================================");

                DataTable dtLegacy = new DataTable();
                dtLegacy.Columns.Add("Student ID");
                dtLegacy.Columns.Add("Student Name");
                dtLegacy.Columns.Add("Class Name");
                dtLegacy.Columns.Add("Fine");
                dtLegacy.Columns.Add("Reason");

                dtLegacy.Rows.Add("2093", "SYEDA KINZA BIBI", "PM-1G", "150", "Uniform fine");

                using (FrmExcelImportPreview previewLegacy = new FrmExcelImportPreview(dtLegacy, "10 2026", "42", "LATE FEE FINE", "1"))
                {
                    MethodInfo load = typeof(FrmExcelImportPreview).GetMethod("FrmExcelImportPreview_Load", BindingFlags.NonPublic | BindingFlags.Instance);
                    load.Invoke(previewLegacy, new object[] { null, EventArgs.Empty });

                    FieldInfo fi = typeof(FrmExcelImportPreview).GetField("processedItems", BindingFlags.NonPublic | BindingFlags.Instance);
                    System.Collections.IList items = (System.Collections.IList)fi.GetValue(previewLegacy);

                    if (items.Count != 1) throw new Exception("Expected 1 legacy item, got " + items.Count);
                    object r = items[0];
                    string st = (string)r.GetType().GetField("Status").GetValue(r);
                    string m = (string)r.GetType().GetField("ResolvedFeeMonth").GetValue(r);
                    object h = r.GetType().GetField("ResolvedFeeHead").GetValue(r);
                    string hName = (string)h.GetType().GetField("HeadName").GetValue(h);

                    if (st != "VALID") throw new Exception("Legacy row should be VALID but is " + st);
                    if (m != "10 2026") throw new Exception("Legacy row month should fallback to 10 2026, got: " + m);
                    if (hName != "LATE FEE FINE") throw new Exception("Legacy row head should fallback to LATE FEE FINE, got: " + hName);

                    Console.WriteLine("Legacy Row 1: ID=2093, Month=" + m + ", Head=" + hName + ", Status=" + st);
                    Console.WriteLine("PASS: Legacy Fine Template backward compatibility fully verified!");
                }

                Console.WriteLine();
                Console.WriteLine("==========================================================");
                Console.WriteLine("TEST 4: Excel Template Generation Verification");
                Console.WriteLine("==========================================================");

                string testXlsx = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test_Template.xlsx");
                string testCsv = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test_Template.csv");

                ExcelHelper.GenerateTemplateXlsx(testXlsx);
                DataTable dtReadXlsx = ExcelHelper.ReadFile(testXlsx);
                if (dtReadXlsx == null || dtReadXlsx.Rows.Count < 2) throw new Exception("Failed reading generated XLSX template");
                Console.WriteLine("XLSX Template generated & read successfully (" + dtReadXlsx.Rows.Count + " rows)");

                ExcelHelper.GenerateTemplateCsv(testCsv);
                DataTable dtReadCsv = ExcelHelper.ReadFile(testCsv);
                if (dtReadCsv == null || dtReadCsv.Rows.Count < 2) throw new Exception("Failed reading generated CSV template");
                Console.WriteLine("CSV Template generated & read successfully (" + dtReadCsv.Rows.Count + " rows)");

                if (System.IO.File.Exists(testXlsx)) System.IO.File.Delete(testXlsx);
                if (System.IO.File.Exists(testCsv)) System.IO.File.Delete(testCsv);

                Console.WriteLine("PASS: Template generation verified!");

                Console.WriteLine();
                Console.WriteLine("==========================================================");
                Console.WriteLine("SUCCESS: ALL AUTOMATED TESTS PASSED (100% SUCCESS)!");
                Console.WriteLine("==========================================================");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("TEST FAILED WITH EXCEPTION: " + ex);
                return 1;
            }
        }
    }
}
