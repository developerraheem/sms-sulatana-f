using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace School._forms
{
    public partial class FrmExcelImportPreview : Form
    {
        public string FilePath { get; set; }
        public DataTable RawTable { get; set; }
        public string InitialFeeMonth { get; set; }
        public string InitialFeeHeadId { get; set; }

        private SYSTEMSETTING SYS = new SYSTEMSETTING();

        private class StudentMatch
        {
            public string S_ID;
            public string Name;
            public string AdmissionNo;
            public string RollNo;
            public string C_ID;
            public string ClassName;
        }

        private class FeeHeadInfo
        {
            public string HeadId;
            public string HeadName;
            public string Category;

            public bool IsConcession
            {
                get
                {
                    if (string.IsNullOrEmpty(Category)) return false;
                    string cat = Category.Trim().ToUpperInvariant();
                    if (cat == "DISCOUNT" || cat == "CONCESSION") return true;
                    if (!string.IsNullOrEmpty(HeadName) && HeadName.ToUpperInvariant().Contains("CONCESSION")) return true;
                    return false;
                }
            }
        }

        private class ImportRowItem
        {
            public int RowNum;
            public string InputStudentId;
            public string InputName;
            public string InputClass;
            public string InputFeeMonth;
            public string InputFeeHead;
            public string RawAmount;
            public double Amount;
            public string Reason;
            public string Status; // VALID, INVALID, DUPLICATE
            public string Notes;
            public StudentMatch MatchedStudent;
            public string ResolvedFeeMonth;
            public FeeHeadInfo ResolvedFeeHead;
        }

        public static string CleanHeader(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Trim().Length == 0) return "";
            string s = name.Trim().ToLowerInvariant();
            s = s.Replace("_", " ").Replace("-", " ").Replace(".", " ").Replace("/", " ").Replace("(", " ").Replace(")", " ");
            while (s.Contains("  ")) s = s.Replace("  ", " ");
            return s.Trim();
        }

        public static bool TryParseFineAmount(string input, out double amount)
        {
            amount = 0;
            if (string.IsNullOrEmpty(input) || input.Trim().Length == 0) return false;

            string cleaned = input.Trim();
            cleaned = cleaned.Replace("Rs.", "").Replace("RS.", "").Replace("rs.", "")
                             .Replace("Rs", "").Replace("RS", "").Replace("rs", "")
                             .Replace("PKR", "").Replace("pkr", "")
                             .Replace("$", "")
                             .Replace(",", "")
                             .Trim();

            if (double.TryParse(cleaned, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out amount))
            {
                return true;
            }
            if (double.TryParse(cleaned, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out amount))
            {
                return true;
            }
            return false;
        }

        public static bool TryNormalizeFeeMonth(string input, out string normalizedMonth)
        {
            normalizedMonth = null;
            if (string.IsNullOrEmpty(input) || input.Trim().Length == 0) return false;
            string s = input.Trim();

            // Try standard regex match for M/MM yyyy or yyyy M/MM
            // e.g. "10 2026", "10/2026", "10-2026", "9 2026"
            Match m1 = Regex.Match(s, @"^(\d{1,2})[\s\/\-\.]+(\d{4})$");
            if (m1.Success)
            {
                int m = int.Parse(m1.Groups[1].Value);
                int y = int.Parse(m1.Groups[2].Value);
                if (m >= 1 && m <= 12 && y >= 2000 && y <= 2100)
                {
                    normalizedMonth = m.ToString("00") + " " + y;
                    return true;
                }
            }

            Match m2 = Regex.Match(s, @"^(\d{4})[\s\/\-\.]+(\d{1,2})$");
            if (m2.Success)
            {
                int y = int.Parse(m2.Groups[1].Value);
                int m = int.Parse(m2.Groups[2].Value);
                if (m >= 1 && m <= 12 && y >= 2000 && y <= 2100)
                {
                    normalizedMonth = m.ToString("00") + " " + y;
                    return true;
                }
            }

            // Try DateTime parsing
            string[] formats = new string[] {
                "MM yyyy", "M yyyy", "MM/yyyy", "M/yyyy", "MM-yyyy", "M-yyyy",
                "MMMM yyyy", "MMM yyyy", "yyyy-MM", "yyyy/MM",
                "yyyy-MM-dd", "dd/MM/yyyy", "dd-MM-yyyy", "MM/dd/yyyy", "yyyy/MM/dd",
                "dd MMM yyyy", "dd MMMM yyyy"
            };

            DateTime dt;
            if (DateTime.TryParseExact(s, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
            {
                normalizedMonth = dt.ToString("MM yyyy");
                return true;
            }

            if (DateTime.TryParse(s, out dt))
            {
                normalizedMonth = dt.ToString("MM yyyy");
                return true;
            }

            return false;
        }

        private List<ImportRowItem> processedItems = new List<ImportRowItem>();
        private List<FeeHeadInfo> availableFeeHeads = new List<FeeHeadInfo>();

        public FrmExcelImportPreview()
        {
            InitializeComponent();
        }

        public FrmExcelImportPreview(DataTable dt, string feeMonth, string feeHeadId, string feeHeadName, string cid)
        {
            InitializeComponent();
            this.RawTable = dt;
            this.InitialFeeMonth = feeMonth;
            this.InitialFeeHeadId = feeHeadId;
        }

        public FrmExcelImportPreview(string filePath, string feeMonth, string feeHeadId)
        {
            InitializeComponent();
            this.FilePath = filePath;
            this.InitialFeeMonth = feeMonth;
            this.InitialFeeHeadId = feeHeadId;
        }

        private void FrmExcelImportPreview_Load(object sender, EventArgs e)
        {
            try
            {
                lblFile.Text = "File: " + (!string.IsNullOrEmpty(FilePath) ? Path.GetFileName(FilePath) : "Excel Data (" + (RawTable != null ? RawTable.Rows.Count.ToString() : "0") + " rows)");

                // Load all fee heads for the current branch
                LoadBranchFeeHeads();

                if (!string.IsNullOrEmpty(InitialFeeHeadId))
                {
                    cmbFeeHead.SelectedValue = InitialFeeHeadId;
                }

                if (!string.IsNullOrEmpty(InitialFeeMonth))
                {
                    string norm;
                    if (TryNormalizeFeeMonth(InitialFeeMonth, out norm))
                    {
                        string[] parts = norm.Split(' ');
                        if (parts.Length == 2)
                        {
                            int m, y;
                            if (int.TryParse(parts[0], out m) && int.TryParse(parts[1], out y))
                            {
                                dtpFeeMonth.Value = new DateTime(y, m, 1);
                            }
                        }
                    }
                }

                ProcessAndValidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing preview: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBranchFeeHeads()
        {
            availableFeeHeads.Clear();
            string query = "SELECT Fee_head_id, Fee_head, Category FROM Fee_Head WHERE branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY Fee_head";
            DataSet ds = SYS.Show_Query(query);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    FeeHeadInfo hi = new FeeHeadInfo();
                    hi.HeadId = r["Fee_head_id"].ToString().Trim();
                    hi.HeadName = r["Fee_head"] != DBNull.Value ? r["Fee_head"].ToString().Trim() : "";
                    hi.Category = r["Category"] != DBNull.Value ? r["Category"].ToString().Trim() : "";
                    availableFeeHeads.Add(hi);
                }
            }

            SYS.comboFill(this.cmbFeeHead, query, "Fee_Head", "Fee_head", "Fee_head_id");
        }

        private FeeHeadInfo GetDefaultFeeHead()
        {
            if (cmbFeeHead.SelectedValue != null)
            {
                string selId = cmbFeeHead.SelectedValue.ToString().Trim();
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    if (h.HeadId == selId) return h;
                }
            }
            if (!string.IsNullOrEmpty(InitialFeeHeadId))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    if (h.HeadId == InitialFeeHeadId) return h;
                }
            }
            if (availableFeeHeads.Count > 0) return availableFeeHeads[0];
            return null;
        }

        private FeeHeadInfo ResolveFeeHead(string input, FeeHeadInfo defaultHead)
        {
            if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
            {
                return defaultHead;
            }

            string raw = input.Trim();
            string cleanIn = CleanHeader(raw);

            // 1. Exact numeric ID match
            foreach (FeeHeadInfo h in availableFeeHeads)
            {
                if (raw == h.HeadId) return h;
            }

            // 2. Exact name match (case-insensitive)
            foreach (FeeHeadInfo h in availableFeeHeads)
            {
                if (string.Equals(h.HeadName, raw, StringComparison.OrdinalIgnoreCase)) return h;
            }

            // 3. Clean header exact match
            foreach (FeeHeadInfo h in availableFeeHeads)
            {
                if (CleanHeader(h.HeadName) == cleanIn) return h;
            }

            // 4. Semantic / synonym aliases
            // Attendance Fine / Absent Fine
            if (cleanIn.Contains("attendance") || cleanIn.Contains("absent"))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    string chn = CleanHeader(h.HeadName);
                    if (chn.Contains("attendance") || chn.Contains("absent")) return h;
                }
            }

            // Concession / Discount
            if (cleanIn.Contains("concession") || cleanIn.Contains("discount"))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    if (h.IsConcession) return h;
                }
            }

            // Monthly Fee / Tuition Fee / Monthly Contribution
            if (cleanIn.Contains("monthly") || cleanIn.Contains("tuition") || cleanIn.Contains("contribution"))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    string chn = CleanHeader(h.HeadName);
                    if (chn.Contains("monthly") || chn.Contains("tuition") || chn.Contains("contribution")) return h;
                }
            }

            // Admission Fee / Re-Admission
            if (cleanIn.Contains("admission"))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    string chn = CleanHeader(h.HeadName);
                    if (cleanIn.Contains("re") && chn.Contains("re admission")) return h;
                    if (!cleanIn.Contains("re") && chn.Contains("admission") && !chn.Contains("re admission")) return h;
                }
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    string chn = CleanHeader(h.HeadName);
                    if (chn.Contains("admission")) return h;
                }
            }

            // Student Fund / Annual Fund
            if (cleanIn.Contains("student fund") || cleanIn.Contains("students fund"))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    string chn = CleanHeader(h.HeadName);
                    if (chn.Contains("student fund") || chn.Contains("students fund")) return h;
                }
            }

            // Development Fund
            if (cleanIn.Contains("development") || cleanIn.Contains("dev"))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    string chn = CleanHeader(h.HeadName);
                    if (chn.Contains("development") || chn.Contains("devopment")) return h;
                }
            }

            // General Fine / Late Fee Fine
            if (cleanIn.Contains("fine") || cleanIn.Contains("late"))
            {
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    string chn = CleanHeader(h.HeadName);
                    if (chn == "fine" || chn.Contains("late fee fine") || chn.Contains("late fee")) return h;
                }
                foreach (FeeHeadInfo h in availableFeeHeads)
                {
                    if (h.Category != null && h.Category.Trim().ToUpperInvariant() == "FINE") return h;
                }
            }

            // 5. Substring match
            foreach (FeeHeadInfo h in availableFeeHeads)
            {
                string chn = CleanHeader(h.HeadName);
                if (chn.Contains(cleanIn) || cleanIn.Contains(chn)) return h;
            }

            return null;
        }

        private void ProcessAndValidate()
        {
            processedItems.Clear();
            if (RawTable == null || RawTable.Rows.Count == 0)
            {
                UpdateGridAndCounters();
                return;
            }

            string defaultFeeMonth = !string.IsNullOrEmpty(dtpFeeMonth.Text.Trim()) ? dtpFeeMonth.Text.Trim() : dtpFeeMonth.Value.ToString("MM yyyy");
            if (string.IsNullOrEmpty(defaultFeeMonth) && !string.IsNullOrEmpty(InitialFeeMonth))
            {
                string norm;
                if (TryNormalizeFeeMonth(InitialFeeMonth, out norm)) defaultFeeMonth = norm;
            }
            FeeHeadInfo defaultFeeHead = GetDefaultFeeHead();

            // Identify columns in RawTable
            int colIdxId = -1;
            int colIdxFine = -1;
            int colIdxName = -1;
            int colIdxClass = -1;
            int colIdxMonth = -1;
            int colIdxHead = -1;
            int colIdxReason = -1;

            string[] idHeaders = new string[] {
                "student id", "studentid", "student no", "studentno", "admission no", "admissionno",
                "adm no", "admno", "admission", "roll no", "rollno", "reg no", "registration no",
                "s id", "s_id", "sid", "student code"
            };

            string[] monthHeaders = new string[] {
                "fee month", "feemonth", "fee period", "period", "billing month", "month"
            };

            string[] headHeaders = new string[] {
                "fee head", "feehead", "fee head name", "fee type", "feetype", "charge type", "head name", "head"
            };

            string[] fineExplicitHeaders = new string[] {
                "fine amount", "fine amt", "fineamount", "fine rs", "fine pkr", "fine",
                "penalty amount", "penalty amt", "penalty",
                "fee amount", "fee amt", "amount", "amt",
                "discount amount", "discount amt", "discount",
                "concession amount", "concession amt", "concession"
            };

            string[] fineGenericHeaders = new string[] {
                "total amount", "payable amount", "charge", "charges"
            };

            string[] nameHeaders = new string[] {
                "student name", "studentname", "s name", "name", "student"
            };

            string[] classHeaders = new string[] {
                "class name", "classname", "class", "grade", "section"
            };

            string[] reasonHeaders = new string[] {
                "reason", "remarks", "remark", "description", "note", "notes", "comments"
            };

            // Pass 1: Match Student ID
            for (int i = 0; i < RawTable.Columns.Count; i++)
            {
                string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                foreach (string h in idHeaders)
                {
                    if (cName == h || cName.Contains(h))
                    {
                        colIdxId = i;
                        break;
                    }
                }
                if (colIdxId != -1) break;
            }
            if (colIdxId == -1)
            {
                for (int i = 0; i < RawTable.Columns.Count; i++)
                {
                    string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                    if (cName == "id")
                    {
                        colIdxId = i;
                        break;
                    }
                }
            }

            // Pass 2: Match Fee Month
            for (int i = 0; i < RawTable.Columns.Count; i++)
            {
                if (i == colIdxId) continue;
                string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                foreach (string h in monthHeaders)
                {
                    if (cName == h || cName.Contains(h))
                    {
                        colIdxMonth = i;
                        break;
                    }
                }
                if (colIdxMonth != -1) break;
            }

            // Pass 3: Match Fee Head
            for (int i = 0; i < RawTable.Columns.Count; i++)
            {
                if (i == colIdxId || i == colIdxMonth) continue;
                string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                foreach (string h in headHeaders)
                {
                    if (cName == h || cName.Contains(h))
                    {
                        colIdxHead = i;
                        break;
                    }
                }
                if (colIdxHead != -1) break;
            }

            // Pass 4: Match Class
            for (int i = 0; i < RawTable.Columns.Count; i++)
            {
                if (i == colIdxId || i == colIdxMonth || i == colIdxHead) continue;
                string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                foreach (string h in classHeaders)
                {
                    if (cName == h || cName.Contains(h))
                    {
                        colIdxClass = i;
                        break;
                    }
                }
                if (colIdxClass != -1) break;
            }

            // Pass 5: Match Fine / Amount
            for (int i = 0; i < RawTable.Columns.Count; i++)
            {
                if (i == colIdxId || i == colIdxMonth || i == colIdxHead || i == colIdxClass) continue;
                string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                foreach (string h in fineExplicitHeaders)
                {
                    if (cName == h || cName.Contains(h))
                    {
                        colIdxFine = i;
                        break;
                    }
                }
                if (colIdxFine != -1) break;
            }

            // Pass 6: Match Student Name
            for (int i = 0; i < RawTable.Columns.Count; i++)
            {
                if (i == colIdxId || i == colIdxMonth || i == colIdxHead || i == colIdxClass || i == colIdxFine) continue;
                string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                if (cName.Contains("father") || cName.Contains("mother") || cName.Contains("head")) continue;

                foreach (string h in nameHeaders)
                {
                    if (cName == h || (cName.Contains(h) && (h != "name" || cName == "name" || cName.Contains("student"))))
                    {
                        colIdxName = i;
                        break;
                    }
                }
                if (colIdxName != -1) break;
            }

            // Pass 7: Generic Amount
            if (colIdxFine == -1)
            {
                for (int i = 0; i < RawTable.Columns.Count; i++)
                {
                    if (i == colIdxId || i == colIdxMonth || i == colIdxHead || i == colIdxClass || i == colIdxName) continue;
                    string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                    foreach (string h in fineGenericHeaders)
                    {
                        if (cName == h || cName.Contains(h))
                        {
                            colIdxFine = i;
                            break;
                        }
                    }
                    if (colIdxFine != -1) break;
                }
            }

            // Pass 8: Match Reason
            for (int i = 0; i < RawTable.Columns.Count; i++)
            {
                if (i == colIdxId || i == colIdxMonth || i == colIdxHead || i == colIdxClass || i == colIdxFine || i == colIdxName) continue;
                string cName = CleanHeader(RawTable.Columns[i].ColumnName);
                foreach (string h in reasonHeaders)
                {
                    if (cName == h || cName.Contains(h))
                    {
                        colIdxReason = i;
                        break;
                    }
                }
                if (colIdxReason != -1) break;
            }

            // Fallback for ID if file has no recognizable header for ID
            if (colIdxId == -1 && RawTable.Columns.Count > 0 && colIdxFine != 0)
            {
                colIdxId = 0;
            }

            // Smart numeric detection for Amount if still not found
            if (colIdxFine == -1)
            {
                int bestNumericCol = -1;
                int maxNumericCount = 0;

                for (int i = 0; i < RawTable.Columns.Count; i++)
                {
                    if (i == colIdxId || i == colIdxMonth || i == colIdxHead || i == colIdxClass || i == colIdxName || i == colIdxReason) continue;

                    int numericCount = 0;
                    int rowSample = Math.Min(RawTable.Rows.Count, 20);
                    for (int r = 0; r < rowSample; r++)
                    {
                        string cellStr = RawTable.Rows[r][i] != null ? RawTable.Rows[r][i].ToString() : "";
                        double testAmt;
                        if (TryParseFineAmount(cellStr, out testAmt) && testAmt > 0)
                        {
                            numericCount++;
                        }
                    }

                    if (numericCount > maxNumericCount && numericCount >= Math.Max(1, rowSample / 2))
                    {
                        maxNumericCount = numericCount;
                        bestNumericCol = i;
                    }
                }

                if (bestNumericCol != -1)
                {
                    colIdxFine = bestNumericCol;
                }
            }

            // Load all active students for current session and branch in ONE query
            Dictionary<string, StudentMatch> studentsBySid = new Dictionary<string, StudentMatch>(StringComparer.OrdinalIgnoreCase);
            Dictionary<string, StudentMatch> studentsByAdm = new Dictionary<string, StudentMatch>(StringComparer.OrdinalIgnoreCase);

            string stdQuery = "SELECT s.s_id, s.s_name, s.ADMISSION_NO, s.roll_no, s.c_id, c.c_name " +
                              "FROM student s LEFT JOIN class c ON s.c_id = c.c_id AND c.branch_id = s.branch_id " +
                              "WHERE s.active='true' AND s.branch_id='" + SYSTEMSETTING.branch_ID + "' " +
                              "ORDER BY CASE WHEN s.SessionID='" + SYSTEMSETTING.sessionid + "' THEN 0 ELSE 1 END";
            DataSet dsStudents = SYS.Show_Query(stdQuery);
            if (dsStudents != null && dsStudents.Tables.Count > 0)
            {
                foreach (DataRow r in dsStudents.Tables[0].Rows)
                {
                    StudentMatch sm = new StudentMatch();
                    sm.S_ID = r["s_id"] != DBNull.Value ? r["s_id"].ToString().Trim() : "";
                    sm.Name = r["s_name"] != DBNull.Value ? r["s_name"].ToString().Trim() : "";
                    sm.AdmissionNo = r["ADMISSION_NO"] != DBNull.Value ? r["ADMISSION_NO"].ToString().Trim() : "";
                    sm.RollNo = r["roll_no"] != DBNull.Value ? r["roll_no"].ToString().Trim() : "";
                    sm.C_ID = r["c_id"] != DBNull.Value ? r["c_id"].ToString().Trim() : "";
                    sm.ClassName = r["c_name"] != DBNull.Value ? r["c_name"].ToString().Trim() : "";

                    if (!string.IsNullOrEmpty(sm.S_ID) && !studentsBySid.ContainsKey(sm.S_ID)) studentsBySid[sm.S_ID] = sm;
                    if (!string.IsNullOrEmpty(sm.AdmissionNo) && !studentsByAdm.ContainsKey(sm.AdmissionNo)) studentsByAdm[sm.AdmissionNo] = sm;
                }
            }

            // Load existing fine entries from FINE_HISTORY to prevent duplicates
            // Composite key: S_ID + "|" + Fee_head_id + "|" + FEE_MONTH
            Dictionary<string, string> existingFineEntries = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string dupQuery = "SELECT S_ID, Fee_head_id, FEE_MONTH, active, FEE_MASTER_ID FROM FINE_HISTORY " +
                              "WHERE SessionID='" + SYSTEMSETTING.sessionid + "' AND branch_id='" + SYSTEMSETTING.branch_ID + "'";
            DataSet dsDup = SYS.Show_Query(dupQuery);
            if (dsDup != null && dsDup.Tables.Count > 0)
            {
                foreach (DataRow r in dsDup.Tables[0].Rows)
                {
                    if (r["S_ID"] != DBNull.Value && r["Fee_head_id"] != DBNull.Value)
                    {
                        string sIdKey = r["S_ID"].ToString().Trim();
                        string hId = r["Fee_head_id"].ToString().Trim();
                        string m = r["FEE_MONTH"] != DBNull.Value ? r["FEE_MONTH"].ToString().Trim() : "";
                        string mId = (r["FEE_MASTER_ID"] != DBNull.Value) ? r["FEE_MASTER_ID"].ToString().Trim() : "";
                        string act = (r["active"] != DBNull.Value) ? r["active"].ToString().Trim() : "Y";
                        string statusDesc = (!string.IsNullOrEmpty(mId) || act == "N") ? (!string.IsNullOrEmpty(mId) ? "applied to Voucher #" + mId : "already applied") : "pending in records";

                        string compKey = sIdKey + "|" + hId + "|" + m;
                        if (!existingFineEntries.ContainsKey(compKey))
                        {
                            existingFineEntries[compKey] = statusDesc;
                        }
                    }
                }
            }

            // Track duplicate composite keys within the file itself: S_ID + "|" + Fee_head_id + "|" + FEE_MONTH
            Dictionary<string, bool> seenInFile = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            // Process each raw row
            for (int i = 0; i < RawTable.Rows.Count; i++)
            {
                DataRow dr = RawTable.Rows[i];
                ImportRowItem item = new ImportRowItem();
                item.RowNum = i + 1;

                string rawId = colIdxId >= 0 && colIdxId < RawTable.Columns.Count ? dr[colIdxId].ToString().Trim() : "";
                string rawMonth = colIdxMonth >= 0 && colIdxMonth < RawTable.Columns.Count ? dr[colIdxMonth].ToString().Trim() : "";
                string rawHead = colIdxHead >= 0 && colIdxHead < RawTable.Columns.Count ? dr[colIdxHead].ToString().Trim() : "";
                string rawFine = colIdxFine >= 0 && colIdxFine < RawTable.Columns.Count ? dr[colIdxFine].ToString().Trim() : "";
                string rawName = colIdxName >= 0 && colIdxName < RawTable.Columns.Count ? dr[colIdxName].ToString().Trim() : "";
                string rawClass = colIdxClass >= 0 && colIdxClass < RawTable.Columns.Count ? dr[colIdxClass].ToString().Trim() : "";
                string rawReason = colIdxReason >= 0 && colIdxReason < RawTable.Columns.Count ? dr[colIdxReason].ToString().Trim() : "";

                item.InputStudentId = rawId;
                item.InputFeeMonth = rawMonth;
                item.InputFeeHead = rawHead;
                item.InputName = rawName;
                item.InputClass = rawClass;
                item.RawAmount = rawFine;
                item.Reason = rawReason;

                List<string> notes = new List<string>();
                bool isValid = true;

                // 1. Resolve Fee Month
                string resolvedMonth = "";
                if (!string.IsNullOrEmpty(rawMonth))
                {
                    if (TryNormalizeFeeMonth(rawMonth, out resolvedMonth))
                    {
                        item.ResolvedFeeMonth = resolvedMonth;
                    }
                    else
                    {
                        isValid = false;
                        notes.Add("Invalid Fee Month '" + rawMonth + "'");
                        item.ResolvedFeeMonth = rawMonth;
                    }
                }
                else
                {
                    item.ResolvedFeeMonth = defaultFeeMonth;
                    resolvedMonth = defaultFeeMonth;
                }

                // 2. Resolve Fee Head
                FeeHeadInfo resolvedHead = null;
                if (!string.IsNullOrEmpty(rawHead))
                {
                    resolvedHead = ResolveFeeHead(rawHead, defaultFeeHead);
                    if (resolvedHead == null)
                    {
                        isValid = false;
                        notes.Add("Fee Head '" + rawHead + "' not configured for current branch");
                    }
                }
                else
                {
                    resolvedHead = defaultFeeHead;
                }
                item.ResolvedFeeHead = resolvedHead;

                if (resolvedHead == null)
                {
                    isValid = false;
                    if (notes.Count == 0) notes.Add("Fee Head is required");
                }

                // 3. Validate Student ID
                StudentMatch matched = null;
                if (string.IsNullOrEmpty(rawId))
                {
                    isValid = false;
                    notes.Add("Student ID is missing");
                }
                else
                {
                    if (studentsBySid.ContainsKey(rawId))
                    {
                        matched = studentsBySid[rawId];
                    }
                    else if (studentsByAdm.ContainsKey(rawId))
                    {
                        matched = studentsByAdm[rawId];
                    }

                    if (matched == null)
                    {
                        isValid = false;
                        notes.Add("Student ID '" + rawId + "' not found in active records");
                    }
                    else
                    {
                        item.MatchedStudent = matched;

                        // Check name mismatch warning if name provided in file
                        if (!string.IsNullOrEmpty(rawName) && !rawName.Equals(matched.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            notes.Add("Name in file ('" + rawName + "') differs from DB ('" + matched.Name + "')");
                        }
                    }
                }

                // 4. Validate Amount
                double amt;
                bool validAmt = TryParseFineAmount(rawFine, out amt) && amt > 0;
                if (!validAmt)
                {
                    isValid = false;
                    if (colIdxFine == -1)
                    {
                        notes.Add("Amount column could not be found in file");
                    }
                    else if (string.IsNullOrEmpty(rawFine) || rawFine.Trim().Length == 0)
                    {
                        notes.Add("Amount is missing / empty");
                    }
                    else
                    {
                        notes.Add("Invalid amount ('" + rawFine + "'). Must be a positive number");
                    }
                    item.Amount = 0;
                }
                else
                {
                    item.Amount = Math.Round(amt, 2);
                }

                // 5. Duplicate Checks (Both in-file and database)
                if (matched != null && resolvedHead != null && !string.IsNullOrEmpty(resolvedMonth))
                {
                    string compositeKey = matched.S_ID + "|" + resolvedHead.HeadId + "|" + resolvedMonth;

                    // In-file duplicate check
                    if (seenInFile.ContainsKey(compositeKey))
                    {
                        if (isValid)
                        {
                            item.Status = "DUPLICATE";
                        }
                        isValid = false;
                        notes.Add("Duplicate entry in file for this student, head, and month");
                    }
                    else
                    {
                        seenInFile[compositeKey] = true;
                    }

                    // Database duplicate check
                    if (existingFineEntries.ContainsKey(compositeKey))
                    {
                        if (isValid)
                        {
                            item.Status = "DUPLICATE";
                        }
                        isValid = false;
                        string statusInfo = existingFineEntries[compositeKey];
                        notes.Add("Entry for " + resolvedMonth + " (" + resolvedHead.HeadName + ") " + statusInfo);
                    }
                }

                if (isValid)
                {
                    item.Status = "VALID";
                    string readyMsg = "Ready to import";
                    if (resolvedHead != null && resolvedHead.IsConcession)
                    {
                        readyMsg += " (Concession: will reduce fee)";
                    }
                    if (notes.Count == 0) notes.Add(readyMsg);
                }
                else if (string.IsNullOrEmpty(item.Status))
                {
                    item.Status = "INVALID";
                }

                item.Notes = string.Join("; ", notes.ToArray());
                processedItems.Add(item);
            }

            UpdateGridAndCounters();
        }

        private void UpdateGridAndCounters()
        {
            dgvPreview.Rows.Clear();

            int total = processedItems.Count;
            int valid = 0;
            int invalid = 0;
            int duplicate = 0;

            bool showErrorsOnly = chkShowErrorsOnly.Checked;

            foreach (ImportRowItem item in processedItems)
            {
                if (item.Status == "VALID") valid++;
                else if (item.Status == "DUPLICATE") duplicate++;
                else invalid++;

                if (showErrorsOnly && item.Status == "VALID") continue;

                string headDisplay = "";
                if (item.ResolvedFeeHead != null)
                {
                    headDisplay = item.ResolvedFeeHead.HeadName;
                    if (item.ResolvedFeeHead.IsConcession)
                    {
                        headDisplay += " (Concession)";
                    }
                }
                else if (!string.IsNullOrEmpty(item.InputFeeHead))
                {
                    headDisplay = item.InputFeeHead;
                }

                int rowIndex = dgvPreview.Rows.Add(
                    item.RowNum,
                    item.InputStudentId,
                    item.MatchedStudent != null ? item.MatchedStudent.Name : (item.InputName ?? ""),
                    item.MatchedStudent != null ? item.MatchedStudent.ClassName : (item.InputClass ?? ""),
                    item.ResolvedFeeMonth ?? "",
                    headDisplay,
                    item.Amount > 0 ? item.Amount.ToString("0.##") : (!string.IsNullOrEmpty(item.RawAmount) ? item.RawAmount : ""),
                    item.Reason ?? "",
                    item.Status,
                    item.Notes
                );

                DataGridViewRow row = dgvPreview.Rows[rowIndex];
                if (item.Status == "VALID")
                {
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(8, 120, 61);
                    row.Cells["colStatus"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (item.Status == "DUPLICATE")
                {
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(217, 119, 6);
                    row.Cells["colStatus"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
                }
                else
                {
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(220, 38, 38);
                    row.Cells["colStatus"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
                }
            }

            lblTotalCount.Text = "Total Rows: " + total;
            lblValidCount.Text = "Valid (Ready): " + valid;
            lblInvalidCount.Text = "Invalid / Fail: " + invalid;
            lblDuplicateCount.Text = "Duplicates: " + duplicate;

            btnConfirm.Text = "Confirm & Import Valid Records (" + valid + ")";
            btnConfirm.Enabled = valid > 0;
        }

        private void dtpFeeMonth_ValueChanged(object sender, EventArgs e)
        {
            ProcessAndValidate();
        }

        private void cmbFeeHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessAndValidate();
        }

        private void chkShowErrorsOnly_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGridAndCounters();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExportErrors_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtErrors = new DataTable("ImportErrors");
                dtErrors.Columns.Add("Row #");
                dtErrors.Columns.Add("Student ID");
                dtErrors.Columns.Add("Name in File");
                dtErrors.Columns.Add("Class in File");
                dtErrors.Columns.Add("Fee Month");
                dtErrors.Columns.Add("Fee Head");
                dtErrors.Columns.Add("Amount");
                dtErrors.Columns.Add("Reason");
                dtErrors.Columns.Add("Status");
                dtErrors.Columns.Add("Validation Notes");

                int count = 0;
                foreach (ImportRowItem item in processedItems)
                {
                    if (item.Status != "VALID")
                    {
                        dtErrors.Rows.Add(
                            item.RowNum,
                            item.InputStudentId,
                            item.InputName,
                            item.InputClass,
                            item.ResolvedFeeMonth,
                            item.ResolvedFeeHead != null ? item.ResolvedFeeHead.HeadName : item.InputFeeHead,
                            item.Amount > 0 ? item.Amount.ToString("0.##") : item.RawAmount,
                            item.Reason,
                            item.Status,
                            item.Notes
                        );
                        count++;
                    }
                }

                if (count == 0)
                {
                    MessageBox.Show("There are no invalid or duplicate rows to export. All rows are valid!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = "Fee_Import_Error_Report_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelHelper.ExportErrorReportCsv(sfd.FileName, dtErrors);
                    MessageBox.Show("Error report exported successfully (" + count + " rejected rows).", "Report Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to export error report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                List<ImportRowItem> validItems = new List<ImportRowItem>();
                foreach (ImportRowItem it in processedItems)
                {
                    if (it.Status == "VALID") validItems.Add(it);
                }

                if (validItems.Count == 0)
                {
                    MessageBox.Show("There are no valid entries to import.", "Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to import " + validItems.Count + " valid fee/fine/concession entries?",
                    "Confirm Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;

                // Determine next starting FINE_ID
                long nextId = 1;
                DataSet rsMax = SYS.Show_Query("SELECT ISNULL(MAX(CAST(FINE_ID AS BIGINT)), 0) FROM FINE_HISTORY");
                if (rsMax != null && rsMax.Tables.Count > 0 && rsMax.Tables[0].Rows.Count > 0)
                {
                    long mId;
                    if (long.TryParse(rsMax.Tables[0].Rows[0][0].ToString(), out mId))
                    {
                        nextId = mId + 1;
                    }
                }

                string today = DateTime.Today.ToString("MM/dd/yyyy");
                List<string> queries = new List<string>();
                Dictionary<string, bool> affectedMasterIds = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

                // Query existing vouchers for current session and branch
                string qVouchers = "SELECT FEE_MASTER_ID, S_ID, LTRIM(RTRIM(FEE_MONTH)) AS M_FROM, LTRIM(RTRIM(FEE_MONTH_TO)) AS M_TO " +
                                  "FROM FEE_MASTER WHERE SessionID='" + SYSTEMSETTING.sessionid + "' AND branch_id='" + SYSTEMSETTING.branch_ID + "'";
                DataSet dsVouchers = SYS.Show_Query(qVouchers);
                Dictionary<string, string> voucherMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                if (dsVouchers != null && dsVouchers.Tables.Count > 0)
                {
                    foreach (DataRow vr in dsVouchers.Tables[0].Rows)
                    {
                        string sId = vr["S_ID"] != DBNull.Value ? vr["S_ID"].ToString().Trim() : "";
                        string mFrom = vr["M_FROM"] != DBNull.Value ? vr["M_FROM"].ToString().Trim() : "";
                        string mTo = vr["M_TO"] != DBNull.Value ? vr["M_TO"].ToString().Trim() : "";
                        string vId = vr["FEE_MASTER_ID"].ToString().Trim();

                        if (!string.IsNullOrEmpty(sId))
                        {
                            if (!string.IsNullOrEmpty(mFrom) && !voucherMap.ContainsKey(sId + "|" + mFrom))
                            {
                                voucherMap[sId + "|" + mFrom] = vId;
                            }
                            if (!string.IsNullOrEmpty(mTo) && !voucherMap.ContainsKey(sId + "|" + mTo))
                            {
                                voucherMap[sId + "|" + mTo] = vId;
                            }
                        }
                    }
                }

                // Query existing FEE_DETAIL items for vouchers
                Dictionary<string, string[]> detailMap = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);
                string qDetail = "SELECT FEE_DETAIL_ID, FEE_MASTER_ID, Fee_head_id, AMOUNT FROM FEE_DETAIL " +
                                 "WHERE SessionID='" + SYSTEMSETTING.sessionid + "' AND branch_id='" + SYSTEMSETTING.branch_ID + "'";
                DataSet dsDetail = SYS.Show_Query(qDetail);
                if (dsDetail != null && dsDetail.Tables.Count > 0)
                {
                    foreach (DataRow drDet in dsDetail.Tables[0].Rows)
                    {
                        string dId = drDet["FEE_DETAIL_ID"].ToString().Trim();
                        string vmId = drDet["FEE_MASTER_ID"].ToString().Trim();
                        string fhId = drDet["Fee_head_id"].ToString().Trim();
                        string amtStr = drDet["AMOUNT"] != DBNull.Value ? drDet["AMOUNT"].ToString().Trim() : "0";
                        string detKey = vmId + "|" + fhId;
                        if (!detailMap.ContainsKey(detKey))
                        {
                            detailMap[detKey] = new string[] { dId, amtStr };
                        }
                    }
                }

                foreach (ImportRowItem item in validItems)
                {
                    string fineId = nextId.ToString();
                    nextId++;

                    string sId = item.MatchedStudent.S_ID;
                    string cId = item.MatchedStudent.C_ID;
                    string feeHeadId = item.ResolvedFeeHead.HeadId;
                    string feeMonth = item.ResolvedFeeMonth;
                    bool isConcession = item.ResolvedFeeHead.IsConcession;
                    double amt = item.Amount;
                    string reason = item.Reason != null ? item.Reason.Replace("'", "''").Trim() : "";
                    string amtStr = amt.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);

                    // Check if voucher already exists for this student & month
                    string vKey = sId + "|" + feeMonth;
                    string existingMasterId = voucherMap.ContainsKey(vKey) ? voucherMap[vKey] : null;

                    if (!string.IsNullOrEmpty(existingMasterId))
                    {
                        // Insert into FINE_HISTORY linked to existing voucher and active='N'
                        string qFine = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS, FEE_MASTER_ID) " +
                                       "VALUES ('" + fineId + "', '" + sId + "', '" + feeHeadId + "', '" + today + "', '" + amtStr + "', '" + feeMonth + "', '" + cId + "', 'N', '" + SYSTEMSETTING.sessionid + "', '" + SYSTEMSETTING.branch_ID + "', '" + reason + "', '" + existingMasterId + "')";
                        queries.Add(qFine);

                        // Apply to FEE_DETAIL
                        string detKey = existingMasterId + "|" + feeHeadId;
                        if (detailMap.ContainsKey(detKey))
                        {
                            string detailId = detailMap[detKey][0];
                            double existingAmt = 0;
                            double.TryParse(detailMap[detKey][1], out existingAmt);
                            double newAmt;

                            if (isConcession)
                            {
                                newAmt = -(Math.Abs(existingAmt) + amt);
                            }
                            else
                            {
                                newAmt = existingAmt + amt;
                            }

                            string newAmtStr = newAmt.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
                            string qUpdDetail = "UPDATE FEE_DETAIL SET AMOUNT = " + newAmtStr + ", BALANCE = " + newAmtStr + " " +
                                                "WHERE FEE_DETAIL_ID = '" + detailId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                            queries.Add(qUpdDetail);
                            detailMap[detKey][1] = newAmtStr;
                        }
                        else
                        {
                            double detailAmt = isConcession ? -amt : amt;
                            string detailAmtStr = detailAmt.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
                            string qInsDetail = "INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, FEE_MONTH, ISCURRENT, BALANCE, FEE_MONTH_FROM, SessionID, branch_id) " +
                                                "VALUES (" + existingMasterId + ", " + feeHeadId + ", " + detailAmtStr + ", '" + feeMonth + "', 'Y', " + detailAmtStr + ", '" + feeMonth + "', '" + SYSTEMSETTING.sessionid + "', '" + SYSTEMSETTING.branch_ID + "')";
                            queries.Add(qInsDetail);
                            detailMap[detKey] = new string[] { "NEW", detailAmtStr };
                        }

                        affectedMasterIds[existingMasterId] = true;
                    }
                    else
                    {
                        // No voucher yet: insert into FINE_HISTORY as pending (active = 'Y')
                        string qFine = "INSERT INTO FINE_HISTORY (FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) " +
                                       "VALUES ('" + fineId + "', '" + sId + "', '" + feeHeadId + "', '" + today + "', '" + amtStr + "', '" + feeMonth + "', '" + cId + "', 'Y', '" + SYSTEMSETTING.sessionid + "', '" + SYSTEMSETTING.branch_ID + "', '" + reason + "')";
                        queries.Add(qFine);
                    }
                }

                // Recalculate totals for all affected existing vouchers
                foreach (string mId in affectedMasterIds.Keys)
                {
                    string qUpdMaster = "UPDATE FEE_MASTER SET " +
                                        "RECEIVABLE_AMOUNT = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + mId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'), " +
                                        "BALANCE = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + mId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "') - ISNULL(REC_AMOUNT, 0) " +
                                        "WHERE FEE_MASTER_ID = '" + mId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                    queries.Add(qUpdMaster);
                }

                bool success = SYS.Insert_Query_manualcommit(queries.ToArray());
                Cursor.Current = Cursors.Default;

                if (success)
                {
                    int rejected = processedItems.Count - validItems.Count;
                    string msg = "Successfully imported " + validItems.Count + " entries.";
                    if (affectedMasterIds.Count > 0)
                    {
                        msg += "\n(" + affectedMasterIds.Count + " existing fee vouchers were updated directly with the imported heads.)";
                    }
                    if (rejected > 0)
                    {
                        msg += "\n\n(" + rejected + " invalid/duplicate rows were skipped. You can export the error report if needed.)";
                    }

                    MessageBox.Show(msg, "Import Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save entries to the database. Transaction was rolled back.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("An error occurred during import: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
