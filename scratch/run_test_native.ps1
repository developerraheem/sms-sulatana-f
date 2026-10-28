$binDir = (Resolve-Path "bin\Debug").Path
Set-Location $binDir

$source = @"
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using School;
using School._forms;

public class TestRunner
{
    public static void RunTests()
    {
        SYSTEMSETTING.branch_ID = "1";
        SYSTEMSETTING.sessionid = "81";

        Console.WriteLine("==========================================================");
        Console.WriteLine("TEST 1: Month Normalization and Amount Parsing");
        Console.WriteLine("==========================================================");

        string norm;
        bool ok = FrmExcelImportPreview.TryNormalizeFeeMonth("10 2026", out norm);
        if (!ok || norm != "10 2026") throw new Exception("Failed norm for 10 2026: " + norm);

        ok = FrmExcelImportPreview.TryNormalizeFeeMonth("October 2026", out norm);
        if (!ok || norm != "10 2026") throw new Exception("Failed norm for October 2026: " + norm);

        ok = FrmExcelImportPreview.TryNormalizeFeeMonth("9 2026", out norm);
        if (!ok || norm != "09 2026") throw new Exception("Failed norm for 9 2026: " + norm);

        ok = FrmExcelImportPreview.TryNormalizeFeeMonth("2026-10-01", out norm);
        if (!ok || norm != "10 2026") throw new Exception("Failed norm for 2026-10-01: " + norm);

        ok = FrmExcelImportPreview.TryNormalizeFeeMonth("15/10/2026", out norm);
        if (!ok || norm != "10 2026") throw new Exception("Failed norm for 15/10/2026: " + norm);

        ok = FrmExcelImportPreview.TryNormalizeFeeMonth("invalid_month", out norm);
        if (ok) throw new Exception("Expected failure for invalid_month");

        Console.WriteLine("PASS: Month normalization tests passed!");

        double amt;
        ok = FrmExcelImportPreview.TryParseFineAmount("Rs. 1,500", out amt);
        if (!ok || Math.Abs(amt - 1500) > 0.01) throw new Exception("Failed parse for Rs. 1,500: " + amt);

        ok = FrmExcelImportPreview.TryParseFineAmount("PKR 250.50", out amt);
        if (!ok || Math.Abs(amt - 250.50) > 0.01) throw new Exception("Failed parse for PKR 250.50: " + amt);

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
            // Invoke load via reflection
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

            // Verify Assertions
            // Row 1: VALID
            dynamic r1 = items[0];
            if (r1.Status != "VALID") throw new Exception("Row 1 should be VALID but is " + r1.Status);
            if (r1.ResolvedFeeHead.HeadName != "MONTHLY CONTRIBUTION") throw new Exception("Row 1 head mismatch: " + r1.ResolvedFeeHead.HeadName);

            // Row 2: VALID (same student, different head)
            dynamic r2 = items[1];
            if (r2.Status != "VALID") throw new Exception("Row 2 should be VALID but is " + r2.Status);
            if (r2.ResolvedFeeHead.HeadName != "LATE FEE FINE") throw new Exception("Row 2 head mismatch: " + r2.ResolvedFeeHead.HeadName);

            // Row 3: VALID (same student, concession head)
            dynamic r3 = items[2];
            if (r3.Status != "VALID") throw new Exception("Row 3 should be VALID but is " + r3.Status);
            if (!r3.ResolvedFeeHead.IsConcession) throw new Exception("Row 3 should be detected as Concession!");

            // Row 4: DUPLICATE (same student, head, and month in same file)
            dynamic r4 = items[3];
            if (r4.Status != "DUPLICATE") throw new Exception("Row 4 should be DUPLICATE but is " + r4.Status);

            // Row 5: INVALID (invalid student)
            dynamic r5 = items[4];
            if (r5.Status != "INVALID") throw new Exception("Row 5 should be INVALID but is " + r5.Status);

            // Row 6: INVALID (invalid head)
            dynamic r6 = items[5];
            if (r6.Status != "INVALID") throw new Exception("Row 6 should be INVALID but is " + r6.Status);

            // Row 7: INVALID (invalid month)
            dynamic r7 = items[6];
            if (r7.Status != "INVALID") throw new Exception("Row 7 should be INVALID but is " + r7.Status);

            // Row 8: INVALID (invalid amount)
            dynamic r8 = items[7];
            if (r8.Status != "INVALID") throw new Exception("Row 8 should be INVALID but is " + r8.Status);

            Console.WriteLine("PASS: All validation assertions passed!");
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
            dynamic r = items[0];
            if (r.Status != "VALID") throw new Exception("Legacy row should be VALID but is " + r.Status);
            if (r.ResolvedFeeMonth != "10 2026") throw new Exception("Legacy row month should fallback to 10 2026, got: " + r.ResolvedFeeMonth);
            if (r.ResolvedFeeHead.HeadName != "LATE FEE FINE") throw new Exception("Legacy row head should fallback to LATE FEE FINE, got: " + r.ResolvedFeeHead.HeadName);

            Console.WriteLine("Legacy Row 1: ID=" + r.InputStudentId + ", Month=" + r.ResolvedFeeMonth + ", Head=" + r.ResolvedFeeHead.HeadName + ", Amt=" + r.Amount + ", Status=" + r.Status);
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
        Console.WriteLine("XLSX Template generated & read successfully (" + dtReadXlsx.Rows.Count + " rows, columns: " + string.Join(", ", GetColNames(dtReadXlsx)) + ")");

        ExcelHelper.GenerateTemplateCsv(testCsv);
        DataTable dtReadCsv = ExcelHelper.ReadFile(testCsv);
        if (dtReadCsv == null || dtReadCsv.Rows.Count < 2) throw new Exception("Failed reading generated CSV template");
        Console.WriteLine("CSV Template generated & read successfully (" + dtReadCsv.Rows.Count + " rows, columns: " + string.Join(", ", GetColNames(dtReadCsv)) + ")");

        // Cleanup test files
        if (System.IO.File.Exists(testXlsx)) System.IO.File.Delete(testXlsx);
        if (System.IO.File.Exists(testCsv)) System.IO.File.Delete(testCsv);

        Console.WriteLine("PASS: Excel and CSV template generation verified!");

        Console.WriteLine();
        Console.WriteLine("==========================================================");
        Console.WriteLine("ALL 4 TEST SUITES PASSED WITH 100% SUCCESS!");
        Console.WriteLine("==========================================================");
    }

    private static string[] GetColNames(DataTable dt)
    {
        string[] names = new string[dt.Columns.Count];
        for (int i = 0; i < dt.Columns.Count; i++) names[i] = dt.Columns[i].ColumnName;
        return names;
    }
}
"@

$cp = New-Object System.CodeDom.Compiler.CompilerParameters
$cp.GenerateInMemory = $true
$cp.ReferencedAssemblies.Add("System.dll") | Out-Null
$cp.ReferencedAssemblies.Add("System.Core.dll") | Out-Null
$cp.ReferencedAssemblies.Add("Microsoft.CSharp.dll") | Out-Null
$cp.ReferencedAssemblies.Add("System.Data.dll") | Out-Null
$cp.ReferencedAssemblies.Add("System.Windows.Forms.dll") | Out-Null
$cp.ReferencedAssemblies.Add("System.Drawing.dll") | Out-Null
$cp.ReferencedAssemblies.Add("System.Xml.dll") | Out-Null
$cp.ReferencedAssemblies.Add("$binDir\GlassButton.dll") | Out-Null
$cp.ReferencedAssemblies.Add("$binDir\System.Windows.Forms.Ribbon35.dll") | Out-Null
$cp.ReferencedAssemblies.Add("$binDir\School.exe") | Out-Null

$provider = New-Object Microsoft.CSharp.CSharpCodeProvider
$cr = $provider.CompileAssemblyFromSource($cp, $source)

if ($cr.Errors.HasErrors) {
    foreach ($err in $cr.Errors) {
        Write-Output "Compilation Error: $err"
    }
    exit 1
}

[AppDomain]::CurrentDomain.add_AssemblyResolve({
    param($sender, $args)
    $name = $args.Name.Split(',')[0]
    $pathExe = "$binDir\$name.exe"
    if (Test-Path $pathExe) { return [System.Reflection.Assembly]::LoadFrom($pathExe) }
    $pathDll = "$binDir\$name.dll"
    if (Test-Path $pathDll) { return [System.Reflection.Assembly]::LoadFrom($pathDll) }
    return $null
})

$compiledAsm = $cr.CompiledAssembly
$runnerType = $compiledAsm.GetType("TestRunner")
$runMethod = $runnerType.GetMethod("RunTests")
$runMethod.Invoke($null, $null)
