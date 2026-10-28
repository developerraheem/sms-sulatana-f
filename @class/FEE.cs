using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

namespace School._class
{

    public class FEE
    {

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        List<string> myListofQueries = new List<string>();
        string QUERY = null;
        Boolean CHECK = false;

        public string GetMasterID()
        {
            string MASTERID = "";
            rs = SYS.Show_Query(" select max(convert(int,FEE_MASTER_ID))+1 as ids from FEE_MASTER where SESSIONID='" + SYSTEMSETTING.sessionid + "'");
            foreach (DataRow RowDocument in rs.Tables[0].Rows)
            {
                MASTERID = RowDocument[0].ToString();
            }
            if (MASTERID == "")
                MASTERID = "1";

            return MASTERID;

        }
        public string GetDETAILID()
        {
            string MASTERID = "";
            rs = SYS.Show_Query(" select max(convert(int,FEE_DETAIL_ID))+1 as ids from FEE_DETAIL");
            foreach (DataRow RowDocument in rs.Tables[0].Rows)
            {
                MASTERID = RowDocument[0].ToString();
            }
            if (MASTERID == "")
                MASTERID = "1";

            return MASTERID;

        }

        public void generatefee(string classid, string month, string SHIFT, string studentid, string DUE_DATE, string remarks)
        {
            try
            {
                myListofQueries.Clear();
                string concessionfee = "";
                string amount = "";
                string master_id = GetMasterID();
                double tamount = 0;


                if (!string.IsNullOrEmpty(studentid))
                {
                    string qCheck = "SELECT FEE_MASTER_ID, PAID, REC_AMOUNT FROM FEE_MASTER WHERE s_id = '" + studentid + "' AND FEE_MONTH = '" + month + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "'";
                    DataSet dsEx = SYS.Show_Query(qCheck);
                    if (dsEx != null && dsEx.Tables.Count > 0 && dsEx.Tables[0].Rows.Count > 0)
                    {
                        DataRow rEx = dsEx.Tables[0].Rows[0];
                        string exPaid = rEx["PAID"] != DBNull.Value ? rEx["PAID"].ToString().Trim() : "";
                        double exRecAmt = -1;
                        bool hasRec = false;
                        if (rEx["REC_AMOUNT"] != DBNull.Value && !string.IsNullOrEmpty(rEx["REC_AMOUNT"].ToString()))
                        {
                            hasRec = true;
                            double.TryParse(rEx["REC_AMOUNT"].ToString(), out exRecAmt);
                        }

                        bool isUnposted = hasRec && exRecAmt == 0 && string.IsNullOrEmpty(exPaid);
                        if (!isUnposted)
                        {
                            MessageBox.Show("Voucher already generated for this month.");
                            return;
                        }
                        else
                        {
                            string exMasterId = rEx["FEE_MASTER_ID"].ToString();
                            SYS.Insert_Query("DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + exMasterId + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "'");
                            SYS.Insert_Query("DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + exMasterId + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "'");
                        }
                    }
                }

                if (studentid == "")
                {
                    QUERY = "Select * from [student] where [c_id] ='" + classid + "' and [active]='true' and SHIFT='" + SHIFT + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id = '" + SYSTEMSETTING.branch_ID + "' and [s_id] NOT IN (Select [s_id] from [FEE_MASTER] where [c_id] ='" + classid + "' and [FEE_MONTH]='" + month + "' AND SHIFT ='" + SHIFT + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id = '" + SYSTEMSETTING.branch_ID + "')";
                }
                else
                {
                    QUERY = "Select * from [student] where [c_id] ='" + classid + "' and [active]='true' and SHIFT='" + SHIFT + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id = '" + SYSTEMSETTING.branch_ID + "' and s_id='" + studentid + "' and [s_id] NOT IN (Select [s_id] from [FEE_MASTER] where [c_id] ='" + classid + "' and [FEE_MONTH]='" + month + "' AND SHIFT ='" + SHIFT + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id = '" + SYSTEMSETTING.branch_ID + "')";
                }

                rs = SYS.Show_Query(QUERY);
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {

                    //---- Fee Master ---------

                    //Guid guid = Guid.NewGuid()
                    string barcode = System.Guid.NewGuid().ToString();
                    bool buscharges = Convert.ToBoolean(RowDocument["buscharges"]);
                    barcode = barcode.Substring(0, 3);
                    barcode = "*" + barcode + master_id + "*";

                    concessionfee = RowDocument["CONCESSION_FEE"].ToString();
                    tamount = 0;

                    if (concessionfee == "")
                    {
                        concessionfee = "0";
                    }

                    QUERY = "Insert into FEE_MASTER(FEE_MASTER_ID,s_id,C_ID,FEE_MONTH,SHIFT,FEE_MONTH_FROM,SESSIONID,DUE_DATE,BARCODE,REMARKS,BRANCH_ID) VALUES('" + master_id + "','" + RowDocument["s_id"].ToString() + "','" + classid + "','" + month + "','" + SHIFT + "','" + month + "','" + SYSTEMSETTING.sessionid + "','" + DUE_DATE + "','" + barcode + "','" + remarks + "','" + SYSTEMSETTING.branch_ID + "')";
                    myListofQueries.Add(QUERY);


                    //---- Fee Detail ---------
                    Dictionary<string, double> feeDetailsMap = new Dictionary<string, double>();

                    double stdConcession = 0;
                    double.TryParse(concessionfee, out stdConcession);
                    bool concessionHeadFound = false;

                    string branchFilter = "";
                    if (!string.IsNullOrEmpty(SYSTEMSETTING.branch_ID))
                    {
                        branchFilter = " and (fc.branch_id = '" + SYSTEMSETTING.branch_ID + "' or fc.branch_id is null)";
                    }
                    QUERY = "Select fc.*, fh.Fee_head, fh.Category from FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID='" + classid + "' and (fc.ACTIVE = 1 or fc.ACTIVE = 'true') AND fc.TYPE='" + RowDocument["TYPE"].ToString() + "'" + branchFilter + " Order by fc.Fee_head_id";
                    rs = SYS.Show_Query(QUERY);
                    foreach (DataRow Row_Inner in rs.Tables[0].Rows)
                    {
                        string headId = Row_Inner["Fee_head_id"].ToString();
                        double famt = Convert.ToDouble(Row_Inner["AMOUNT"]);
                        string headName = (Row_Inner["Fee_head"] != DBNull.Value) ? Row_Inner["Fee_head"].ToString().Trim().ToUpper() : "";
                        string cat = (Row_Inner["Category"] != DBNull.Value) ? Row_Inner["Category"].ToString().Trim().ToUpper() : "";
                        bool isConcessionHead = (cat == "DISCOUNT" || cat == "CONCESSION" || headName.Contains("CONCESSION"));
                        bool isArrearHead = (cat == "ARREAR" || headName.Contains("ARREAR"));

                        if (isArrearHead)
                        {
                            // Arrears are calculated dynamically from genuine student balance, not as static class charges
                            continue;
                        }

                        // BUS CHARGES
                        if (headId == "19")
                        {
                            if (buscharges == true)
                            {
                                feeDetailsMap[headId] = famt;
                            }
                        }
                        else if (isConcessionHead)
                        {
                            concessionHeadFound = true;
                            if (stdConcession > 0)
                            {
                                famt = -(Math.Abs(famt) + stdConcession);
                            }
                            feeDetailsMap[headId] = famt;
                        }
                        else
                        {
                            feeDetailsMap[headId] = famt;
                        }
                    }

                    if (stdConcession > 0 && !concessionHeadFound)
                    {
                        string qBranchConc = "SELECT TOP 1 Fee_head_id FROM Fee_Head WHERE branch_id = '" + SYSTEMSETTING.branch_ID + "' AND (Category IN ('DISCOUNT', 'CONCESSION') OR UPPER(Fee_head) LIKE '%CONCESSION%') ORDER BY CASE WHEN UPPER(LTRIM(RTRIM(Fee_head))) = 'FEE CONCESSION' THEN 1 WHEN UPPER(LTRIM(RTRIM(Fee_head))) LIKE '%CONCESSION%' THEN 2 ELSE 3 END, Fee_head_id";
                        DataSet dsBranchConc = SYS.Show_Query(qBranchConc);
                        if (dsBranchConc != null && dsBranchConc.Tables.Count > 0 && dsBranchConc.Tables[0].Rows.Count > 0)
                        {
                            string branchConcHeadId = dsBranchConc.Tables[0].Rows[0]["Fee_head_id"].ToString();
                            feeDetailsMap[branchConcHeadId] = -stdConcession;
                        }
                    }

                    //---- Fine & Concession / Discount Adjustment ---------
                    string admNoSingle = (RowDocument.Table.Columns.Contains("ADMISSION_NO") && RowDocument["ADMISSION_NO"] != DBNull.Value) ? RowDocument["ADMISSION_NO"].ToString().Trim().Replace("'", "''") : "";
                    string sidSingle = RowDocument["s_id"].ToString().Trim().Replace("'", "''");

                    QUERY = "SELECT b.FINE_ID, b.Fee_head_id, b.FINE_AMOUNT, a.Category, a.Fee_head " +
                            "FROM FINE_HISTORY b " +
                            "INNER JOIN Fee_Head a ON b.Fee_head_id = a.Fee_head_id " +
                            "WHERE (b.S_ID = '" + sidSingle + "'" + (!string.IsNullOrEmpty(admNoSingle) ? " OR b.S_ID = '" + admNoSingle + "'" : "") + ") " +
                            "  AND (b.active = 'Y' OR b.active LIKE 'Y%') " +
                            "  AND (b.FEE_MASTER_ID IS NULL OR b.FEE_MASTER_ID = '') " +
                            "  AND b.SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                            "  AND b.branch_id = '" + SYSTEMSETTING.branch_ID + "' " +
                            "  AND (LTRIM(RTRIM(b.FEE_MONTH)) = '" + month.Trim() + "' OR b.FEE_MONTH = '' OR b.FEE_MONTH IS NULL)";
                    rs = SYS.Show_Query(QUERY);
                    if (rs != null && rs.Tables.Count > 0)
                    {
                        foreach (DataRow Row_Fine in rs.Tables[0].Rows)
                        {
                            string fineId = Row_Fine["FINE_ID"].ToString();
                            string feeHeadId = Row_Fine["Fee_head_id"].ToString();
                            string category = (Row_Fine["Category"] != DBNull.Value) ? Row_Fine["Category"].ToString().Trim().ToUpper() : "";
                            double fineAmt = 0;
                            if (Row_Fine["FINE_AMOUNT"] != DBNull.Value)
                            {
                                double.TryParse(Row_Fine["FINE_AMOUNT"].ToString(), out fineAmt);
                            }
                            if (fineAmt > 0)
                            {
                                if (category == "DISCOUNT" || category == "CONCESSION")
                                {
                                    // Fee Concession / Discount reduces payable fee
                                    if (feeDetailsMap.ContainsKey(feeHeadId))
                                    {
                                        if (feeDetailsMap[feeHeadId] <= 0)
                                        {
                                            feeDetailsMap[feeHeadId] = -(Math.Abs(feeDetailsMap[feeHeadId]) + fineAmt);
                                        }
                                        else
                                        {
                                            feeDetailsMap[feeHeadId] = -fineAmt;
                                        }
                                    }
                                    else
                                    {
                                        feeDetailsMap[feeHeadId] = -fineAmt;
                                    }
                                }
                                else
                                {
                                    // Fine adds to payable fee
                                    if (feeDetailsMap.ContainsKey(feeHeadId))
                                    {
                                        feeDetailsMap[feeHeadId] += fineAmt;
                                    }
                                    else
                                    {
                                        feeDetailsMap[feeHeadId] = fineAmt;
                                    }
                                }

                                QUERY = "Update FINE_HISTORY set active='N', FEE_MASTER_ID='" + master_id + "' where FINE_ID='" + fineId + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                                myListofQueries.Add(QUERY);
                            }
                        }
                    }

                    // Insert unique FEE_DETAIL records (preventing duplicate lines)
                    foreach (KeyValuePair<string, double> kvp in feeDetailsMap)
                    {
                        string headId = kvp.Key;
                        double detailAmt = kvp.Value;

                        QUERY = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SESSIONID,branch_id) VALUES(" + master_id + "," + headId + "," + detailAmt + ",'" + month + "','Y','" + detailAmt + "','" + month + "','" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "')";
                        myListofQueries.Add(QUERY);

                        tamount = tamount + detailAmt;
                    }

                    //#region
                    ////---- Previous Balance  OLD METHOD---------
                    //string PRVBALANCE = "";
                    //double tprvbal = 0;

                    //QUERY = "SELECT BALANCE,FEE_MASTER_ID FROM FEE_MASTER WHERE (BALANCE) >0 and s_id='" + RowDocument["s_id"].ToString() + "' AND PAID IS NULL AND SESSIONID ='" + SYSTEMSETTING.sessionid + "'";
                    //rs = SYS.Show_Query(QUERY);
                    //foreach (DataRow Row_FM in rs.Tables[0].Rows)
                    //{
                    //    PRVBALANCE = Row_FM[0].ToString();




                    //    QUERY = "UPDATE FEE_MASTER SET PAID='N' where FEE_MASTER_ID='" + Row_FM[1].ToString() + "' AND SESSIONID='" + SYSTEMSETTING.sessionid + "'";
                    //    myListofQueries.Add(QUERY);

                    //    tprvbal = tprvbal + Convert.ToDouble(PRVBALANCE);
                    //}

                    //if (PRVBALANCE == "")
                    //{ }
                    //else
                    //{


                    //    QUERY = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SESSIONID) VALUES(" + master_id + ",'3'," + PRVBALANCE + ",'" + month + "','N','" + PRVBALANCE + "','" + month + "','" + SYSTEMSETTING.sessionid + "')";
                    //    myListofQueries.Add(QUERY);
                    //    tamount = tamount + (Convert.ToDouble(PRVBALANCE));
                    //}
                    //#endregion


                    #region
                    //---- Previous Balance (Read-Only Arrears Carry Forward) ---------
                    double tprvbal = GetPreviousOutstandingArrears(RowDocument["s_id"].ToString(), month, master_id, SYSTEMSETTING.branch_ID, SYSTEMSETTING.sessionid);
                    if (tprvbal > 0)
                    {
                        string arrearHeadId = GetBranchArrearHeadId(SYSTEMSETTING.branch_ID);
                        QUERY = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SESSIONID,branch_id) VALUES(" + master_id + ",'" + arrearHeadId + "'," + tprvbal + ",'" + month + "','N'," + tprvbal + ",'" + month + "','" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "')";
                        myListofQueries.Add(QUERY);
                        tamount = tamount + tprvbal;
                    }
                    #endregion


                    //Update fine status and fee month
                    //QUERY = "Update FINE Set STATUS='R', FEE_MONTH='" & ddlmonth.SelectedItem.ToString() & "' WHERE SCHOOL_ID='" & Session("SCHOOL_ID") & "' AND BRANCH_ID='" & Session("BRANCH_ID") & "' AND CLASS_SEC='" & ddlclass.SelectedValue & "' and STUDENT_ID='" & Row_std(0) & "' ";
                    //myListofQueries.Add(QUERY);

                    QUERY = "Update FEE_MASTER Set RECEIVABLE_AMOUNT='" + tamount + "', BALANCE='" + tamount + "' WHERE FEE_MASTER_ID='" + master_id + "' AND SESSIONID='" + SYSTEMSETTING.sessionid + "' and branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                    myListofQueries.Add(QUERY);


                    master_id = (Convert.ToInt64(master_id) + 1).ToString();
                }


                if (myListofQueries.Count > 0)
                {
                    string[] bulkqueries1 = myListofQueries.ToArray();
                    CHECK = SYS.Insert_Query_manualcommit(bulkqueries1);

                    if (CHECK == true)
                    {
                        SYS.setMessageBox("Fee Generated Generated", 1);
                    }
                    else
                    {
                        MessageBox.Show("Fee Not Generated!");
                    }
                }

                // Also check and apply any pending fines for students with existing vouchers
                ApplyPendingFinesForClassOrStudents(classid, month, month, SHIFT, "", studentid);

            }
            catch (Exception exp)
            {
                SYS.setMessageBox(exp.Message, 3);
            }



        }

        public void generatefeeMulti(string classid, string month, string SHIFT, string studentid, int months, string monthfrom, string DUE_DATE, string tmonths, string tfine, string remarks, string ISSUE_DATE, string startdate, string enddate, string sectionID)
        {
            try
            {
                myListofQueries.Clear();
                string concessionfee = "";
                string amount = "";
                string master_id = GetMasterID();
                double tamount = 0;
                double famount = 0;
                bool multitag = false;

                if (!string.IsNullOrEmpty(studentid))
                {
                    string qCheck = "SELECT FEE_MASTER_ID, PAID, REC_AMOUNT FROM FEE_MASTER WHERE s_id = '" + studentid + "' AND FEE_MONTH = '" + month + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "'";
                    DataSet dsEx = SYS.Show_Query(qCheck);
                    if (dsEx != null && dsEx.Tables.Count > 0 && dsEx.Tables[0].Rows.Count > 0)
                    {
                        DataRow rEx = dsEx.Tables[0].Rows[0];
                        string exPaid = rEx["PAID"] != DBNull.Value ? rEx["PAID"].ToString().Trim() : "";
                        double exRecAmt = -1;
                        bool hasRec = false;
                        if (rEx["REC_AMOUNT"] != DBNull.Value && !string.IsNullOrEmpty(rEx["REC_AMOUNT"].ToString()))
                        {
                            hasRec = true;
                            double.TryParse(rEx["REC_AMOUNT"].ToString(), out exRecAmt);
                        }

                        bool isUnposted = hasRec && exRecAmt == 0 && string.IsNullOrEmpty(exPaid);
                        if (!isUnposted)
                        {
                            MessageBox.Show("Voucher already generated for this month.");
                            return;
                        }
                        else
                        {
                            string exMasterId = rEx["FEE_MASTER_ID"].ToString();
                            SYS.Insert_Query("DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + exMasterId + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "'");
                            SYS.Insert_Query("DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + exMasterId + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "'");
                        }
                    }
                }

                if (studentid == "")
                {
                    QUERY = "Select * from [student] where [c_id] ='" + classid + "' and [active]='true' and SHIFT='" + SHIFT + "' and SessionID='" + SYSTEMSETTING.sessionid + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' AND SECTION_ID='" + sectionID + "' and [s_id] NOT IN (Select [s_id] from [FEE_MASTER] where [c_id] ='" + classid + "' and [FEE_MONTH]='" + month + "' AND SHIFT ='" + SHIFT + "' AND SESSIONID='" + SYSTEMSETTING.sessionid + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "')";
                }
                else
                {
                    QUERY = "Select * from [student] where [c_id] ='" + classid + "' and [active]='true' and SHIFT='" + SHIFT + "' and SessionID='" + SYSTEMSETTING.sessionid + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' AND SECTION_ID='" + sectionID + "' and s_id='" + studentid + "' and [s_id] NOT IN (Select [s_id] from [FEE_MASTER] where [c_id] ='" + classid + "' and [FEE_MONTH]='" + month + "' AND SHIFT ='" + SHIFT + "'AND SESSIONID='" + SYSTEMSETTING.sessionid + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "')";
                }

                rs = SYS.Show_Query(QUERY);
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {

                    //---- Fee Master ---------


                    //string barcode = System.Guid.NewGuid().ToString();
                    //barcode = barcode.Substring(0, 13);
                    //barcode = barcode + master_id;


                    string barcode = System.Guid.NewGuid().ToString();
                    string buscharges = RowDocument["buscharges"].ToString();
                    bool buscharge = false;
                    if (!string.IsNullOrEmpty(buscharges))
                    {
                        buscharge = Convert.ToBoolean(buscharges);
                    }


                    barcode = barcode.Substring(0, 3);
                    barcode = "*" + barcode + master_id + "*";


                    concessionfee = RowDocument["CONCESSION_FEE"].ToString();
                    tamount = 0;

                    if (concessionfee == "")
                    {
                        concessionfee = "0";
                    }

                    QUERY = "Insert into FEE_MASTER(FEE_MASTER_ID,s_id,C_ID,FEE_MONTH,SHIFT,FEE_MONTH_FROM,MULTITAG,SessionID,DUE_DATE,T_MONTHS,FINE_AFTER_DUE_DATE,BARCODE,BRANCH_ID,REMARKS,ISSUE_DATE,startdate,enddate) VALUES('" + master_id + "','" + RowDocument["s_id"].ToString() + "','" + classid + "','" + month + "','" + SHIFT + "','" + monthfrom + "','Y','" + SYSTEMSETTING.sessionid + "','" + DUE_DATE + "','" + tmonths + "','" + tfine + "','" + barcode + "','" + SYSTEMSETTING.branch_ID + "','" + remarks + "','" + ISSUE_DATE + "','" + startdate + "','" + enddate + "')";
                    myListofQueries.Add(QUERY);


                    //---- Fee Detail ---------
                    Dictionary<string, double> feeDetailsMap = new Dictionary<string, double>();

                    double stdConcession = 0;
                    double.TryParse(concessionfee, out stdConcession);
                    bool concessionHeadFound = false;

                    //and AMOUNT <> 0 Remove from 9 April 2025
                    string branchFilterMulti = "";
                    if (!string.IsNullOrEmpty(SYSTEMSETTING.branch_ID))
                    {
                        branchFilterMulti = " and (fc.branch_id = '" + SYSTEMSETTING.branch_ID + "' or fc.branch_id is null)";
                    }
                    QUERY = "Select fc.*, fh.Fee_head, fh.Category from FEE_CLASS fc INNER JOIN Fee_Head fh ON fc.Fee_head_id = fh.Fee_head_id WHERE fc.C_ID='" + classid + "' and (fc.ACTIVE = 1 or fc.ACTIVE = 'true') AND fc.TYPE='" + RowDocument["TYPE"].ToString() + "'" + branchFilterMulti + " Order by fc.Fee_head_id";
                    rs = SYS.Show_Query(QUERY);
                    foreach (DataRow Row_Inner in rs.Tables[0].Rows)
                    {

                        if (Row_Inner["ISMULTIPLY"].ToString() == "" || Row_Inner["ISMULTIPLY"].ToString() == string.Empty)
                        {
                            multitag = false;
                        }
                        else
                        {
                            multitag = true;
                        }

                        //    multitag = Convert.ToBoolean(Row_Inner["ISMULTIPLY"].ToString());

                        if (multitag == true)
                        {
                            famount = Convert.ToDouble(Row_Inner["AMOUNT"]) * months;
                        }
                        else
                        {
                            famount = Convert.ToDouble(Row_Inner["AMOUNT"]);
                        }

                        string headId = Row_Inner["Fee_head_id"].ToString();
                        string headName = (Row_Inner["Fee_head"] != DBNull.Value) ? Row_Inner["Fee_head"].ToString().Trim().ToUpper() : "";
                        string cat = (Row_Inner["Category"] != DBNull.Value) ? Row_Inner["Category"].ToString().Trim().ToUpper() : "";
                        bool isConcessionHead = (cat == "DISCOUNT" || cat == "CONCESSION" || headName.Contains("CONCESSION"));
                        bool isArrearHead = (cat == "ARREAR" || headName.Contains("ARREAR"));

                        if (isArrearHead)
                        {
                            // Arrears are calculated dynamically from genuine student balance, not as static class charges
                            continue;
                        }

                        if (isConcessionHead)
                        {
                            concessionHeadFound = true;
                            if (stdConcession > 0)
                            {
                                double concAmt = multitag ? (stdConcession * months) : stdConcession;
                                famount = -(Math.Abs(famount) + concAmt);
                            }
                        }

                        feeDetailsMap[headId] = famount;
                    }

                    if (stdConcession > 0 && !concessionHeadFound)
                    {
                        string qBranchConc = "SELECT TOP 1 Fee_head_id FROM Fee_Head WHERE branch_id = '" + SYSTEMSETTING.branch_ID + "' AND (Category IN ('DISCOUNT', 'CONCESSION') OR UPPER(Fee_head) LIKE '%CONCESSION%') ORDER BY CASE WHEN UPPER(LTRIM(RTRIM(Fee_head))) = 'FEE CONCESSION' THEN 1 WHEN UPPER(LTRIM(RTRIM(Fee_head))) LIKE '%CONCESSION%' THEN 2 ELSE 3 END, Fee_head_id";
                        DataSet dsBranchConc = SYS.Show_Query(qBranchConc);
                        if (dsBranchConc != null && dsBranchConc.Tables.Count > 0 && dsBranchConc.Tables[0].Rows.Count > 0)
                        {
                            string branchConcHeadId = dsBranchConc.Tables[0].Rows[0]["Fee_head_id"].ToString();
                            double concAmt = stdConcession * months;
                            feeDetailsMap[branchConcHeadId] = -concAmt;
                        }
                    }

                    //---- Fine & Concession / Discount Adjustment ---------
                    string admNoMulti = (RowDocument.Table.Columns.Contains("ADMISSION_NO") && RowDocument["ADMISSION_NO"] != DBNull.Value) ? RowDocument["ADMISSION_NO"].ToString().Trim().Replace("'", "''") : "";
                    string sidMulti = RowDocument["s_id"].ToString().Trim().Replace("'", "''");

                    QUERY = "SELECT b.FINE_ID, b.Fee_head_id, b.FINE_AMOUNT, a.Category, a.Fee_head " +
                            "FROM FINE_HISTORY b " +
                            "INNER JOIN Fee_Head a ON b.Fee_head_id = a.Fee_head_id " +
                            "WHERE (b.S_ID = '" + sidMulti + "'" + (!string.IsNullOrEmpty(admNoMulti) ? " OR b.S_ID = '" + admNoMulti + "'" : "") + ") " +
                            "  AND (b.active = 'Y' OR b.active LIKE 'Y%') " +
                            "  AND (b.FEE_MASTER_ID IS NULL OR b.FEE_MASTER_ID = '') " +
                            "  AND b.SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                            "  AND b.branch_id = '" + SYSTEMSETTING.branch_ID + "' " +
                            "  AND (LTRIM(RTRIM(b.FEE_MONTH)) = '" + month.Trim() + "' " +
                            "       OR LTRIM(RTRIM(b.FEE_MONTH)) = '" + monthfrom.Trim() + "' " +
                            "       OR (b.FEE_MONTH >= '" + monthfrom.Trim() + "' AND b.FEE_MONTH <= '" + month.Trim() + "') " +
                            "       OR b.FEE_MONTH = '' OR b.FEE_MONTH IS NULL)";
                    rs = SYS.Show_Query(QUERY);
                    if (rs != null && rs.Tables.Count > 0)
                    {
                        foreach (DataRow Row_Fine in rs.Tables[0].Rows)
                        {
                            string fineId = Row_Fine["FINE_ID"].ToString();
                            string feeHeadId = Row_Fine["Fee_head_id"].ToString();
                            string category = (Row_Fine["Category"] != DBNull.Value) ? Row_Fine["Category"].ToString().Trim().ToUpper() : "";
                            double fineAmt = 0;
                            if (Row_Fine["FINE_AMOUNT"] != DBNull.Value)
                            {
                                double.TryParse(Row_Fine["FINE_AMOUNT"].ToString(), out fineAmt);
                            }
                            if (fineAmt > 0)
                            {
                                if (category == "DISCOUNT" || category == "CONCESSION")
                                {
                                    // Fee Concession / Discount reduces payable fee
                                    if (feeDetailsMap.ContainsKey(feeHeadId))
                                    {
                                        if (feeDetailsMap[feeHeadId] <= 0)
                                        {
                                            feeDetailsMap[feeHeadId] = -(Math.Abs(feeDetailsMap[feeHeadId]) + fineAmt);
                                        }
                                        else
                                        {
                                            feeDetailsMap[feeHeadId] = -fineAmt;
                                        }
                                    }
                                    else
                                    {
                                        feeDetailsMap[feeHeadId] = -fineAmt;
                                    }
                                }
                                else
                                {
                                    // Fine adds to payable fee
                                    if (feeDetailsMap.ContainsKey(feeHeadId))
                                    {
                                        feeDetailsMap[feeHeadId] += fineAmt;
                                    }
                                    else
                                    {
                                        feeDetailsMap[feeHeadId] = fineAmt;
                                    }
                                }

                                QUERY = "Update FINE_HISTORY set active='N', FEE_MASTER_ID='" + master_id + "' where FINE_ID='" + fineId + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                                myListofQueries.Add(QUERY);
                            }
                        }
                    }

                    // Insert unique FEE_DETAIL records (preventing duplicate lines)
                    foreach (KeyValuePair<string, double> kvp in feeDetailsMap)
                    {
                        string headId = kvp.Key;
                        double detailAmt = kvp.Value;

                        QUERY = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SessionID,branch_id) VALUES(" + master_id + "," + headId + "," + detailAmt + ",'" + month + "','Y','" + detailAmt + "','" + monthfrom + "','" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "')";
                        myListofQueries.Add(QUERY);

                        tamount = tamount + detailAmt;
                    }


                    //---- Previous Balance (Read-Only Arrears Carry Forward) ---------
                    double tprvbal = GetPreviousOutstandingArrears(RowDocument["s_id"].ToString(), month, master_id, SYSTEMSETTING.branch_ID, SYSTEMSETTING.sessionid);
                    if (tprvbal > 0)
                    {
                        string prvba = GetBranchArrearHeadId(SYSTEMSETTING.branch_ID);
                        QUERY = "Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,FEE_MONTH_FROM,SessionID,branch_id) VALUES(" + master_id + ",'" + prvba + "'," + tprvbal + ",'" + month + "','N','" + tprvbal + "','" + monthfrom + "','" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "')";
                        myListofQueries.Add(QUERY);
                        tamount = tamount + tprvbal;
                    }


                    //Update fine status and fee month
                    //QUERY = "Update FINE Set STATUS='R', FEE_MONTH='" & ddlmonth.SelectedItem.ToString() & "' WHERE SCHOOL_ID='" & Session("SCHOOL_ID") & "' AND BRANCH_ID='" & Session("BRANCH_ID") & "' AND CLASS_SEC='" & ddlclass.SelectedValue & "' and STUDENT_ID='" & Row_std(0) & "' ";
                    //myListofQueries.Add(QUERY);

                    QUERY = "Update FEE_MASTER Set RECEIVABLE_AMOUNT='" + tamount + "', BALANCE='" + tamount + "' WHERE FEE_MASTER_ID='" + master_id + "' AND SESSIONID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                    myListofQueries.Add(QUERY);


                    master_id = (Convert.ToInt64(master_id) + 1).ToString();
                }


                if (myListofQueries.Count > 0)
                {
                    string[] bulkqueries1 = myListofQueries.ToArray();
                    CHECK = SYS.Insert_Query_manualcommit(bulkqueries1);

                    if (CHECK == true)
                    {
                        //SYS.setMessageBox("Fee Generated Generated", 1);
                    }
                    else
                    {
                        MessageBox.Show("Fee Not Generated!");
                    }
                }

                // Also check and apply any pending fines for students with existing vouchers
                ApplyPendingFinesForClassOrStudents(classid, month, monthfrom, SHIFT, sectionID, studentid);

            }
            catch (Exception exp)
            {
                SYS.setMessageBox(exp.Message, 3);
            }



        }

        /// <summary>
        /// Applies all active, unapplied pending fines and concessions to an existing student fee voucher.
        /// Inserts line items into FEE_DETAIL, updates FINE_HISTORY to active='N' and links FEE_MASTER_ID,
        /// and recalculates FEE_MASTER.RECEIVABLE_AMOUNT and BALANCE in a single transaction.
        /// </summary>
        public int ApplyPendingFinesToExistingVoucher(string masterId, string studentId, string admissionNo, string monthTo, string monthFrom)
        {
            if (string.IsNullOrEmpty(masterId) || string.IsNullOrEmpty(studentId))
                return 0;

            int appliedCount = 0;
            try
            {
                string mTo = (monthTo ?? "").Trim();
                string mFrom = (monthFrom ?? "").Trim();
                if (string.IsNullOrEmpty(mFrom)) mFrom = mTo;

                string adm = (admissionNo ?? "").Trim().Replace("'", "''");
                string sid = studentId.Trim().Replace("'", "''");

                string q = "SELECT b.FINE_ID, b.Fee_head_id, b.FINE_AMOUNT, a.Category, a.Fee_head " +
                           "FROM FINE_HISTORY b " +
                           "INNER JOIN Fee_Head a ON b.Fee_head_id = a.Fee_head_id " +
                           "WHERE (b.S_ID = '" + sid + "'" + (!string.IsNullOrEmpty(adm) ? " OR b.S_ID = '" + adm + "'" : "") + ") " +
                           "  AND (b.active = 'Y' OR b.active LIKE 'Y%') " +
                           "  AND (b.FEE_MASTER_ID IS NULL OR b.FEE_MASTER_ID = '') " +
                           "  AND b.SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                           "  AND b.branch_id = '" + SYSTEMSETTING.branch_ID + "' " +
                           "  AND (LTRIM(RTRIM(b.FEE_MONTH)) = '" + mTo + "' " +
                           "       OR LTRIM(RTRIM(b.FEE_MONTH)) = '" + mFrom + "' " +
                           "       OR (b.FEE_MONTH >= '" + mFrom + "' AND b.FEE_MONTH <= '" + mTo + "') " +
                           "       OR b.FEE_MONTH = '' OR b.FEE_MONTH IS NULL)";

                DataSet ds = SYS.Show_Query(q);
                bool hasFines = (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0);

                // Check if student has saved CONCESSION_FEE that needs to be applied to an existing voucher
                double stdConcession = 0;
                string qStudentConc = "SELECT CONCESSION_FEE FROM student WHERE s_id = '" + sid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                DataSet dsStdConc = SYS.Show_Query(qStudentConc);
                if (dsStdConc != null && dsStdConc.Tables.Count > 0 && dsStdConc.Tables[0].Rows.Count > 0 && dsStdConc.Tables[0].Rows[0]["CONCESSION_FEE"] != DBNull.Value)
                {
                    double.TryParse(dsStdConc.Tables[0].Rows[0]["CONCESSION_FEE"].ToString(), out stdConcession);
                }

                if (!hasFines && stdConcession <= 0)
                {
                    return 0;
                }

                List<string> updateQueries = new List<string>();

                // Query existing FEE_DETAIL lines for this voucher to prevent duplicate lines
                string qDetails = "SELECT FEE_DETAIL_ID, Fee_head_id, AMOUNT FROM FEE_DETAIL " +
                                  "WHERE FEE_MASTER_ID = '" + masterId + "' " +
                                  "  AND SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                                  "  AND branch_id = '" + SYSTEMSETTING.branch_ID + "' ORDER BY FEE_DETAIL_ID";
                DataSet dsDetails = SYS.Show_Query(qDetails);
                Dictionary<string, List<string[]>> existingDetails = new Dictionary<string, List<string[]>>();
                if (dsDetails != null && dsDetails.Tables.Count > 0)
                {
                    foreach (DataRow dr in dsDetails.Tables[0].Rows)
                    {
                        string hId = dr["Fee_head_id"].ToString().Trim();
                        string dId = dr["FEE_DETAIL_ID"].ToString().Trim();
                        string dAmt = (dr["AMOUNT"] != DBNull.Value) ? dr["AMOUNT"].ToString().Trim() : "0";
                        if (!existingDetails.ContainsKey(hId))
                        {
                            existingDetails[hId] = new List<string[]>();
                        }
                        existingDetails[hId].Add(new string[] { dId, dAmt });
                    }
                }

                // If student has a saved concession fee in student profile and voucher currently has 0 concession, apply it
                if (stdConcession > 0)
                {
                    // Find concession fee head for this branch
                    string qConcHead = "SELECT TOP 1 Fee_head_id FROM Fee_Head WHERE branch_id = '" + SYSTEMSETTING.branch_ID + "' AND (Category IN ('DISCOUNT', 'CONCESSION') OR UPPER(Fee_head) LIKE '%CONCESSION%') ORDER BY CASE WHEN UPPER(LTRIM(RTRIM(Fee_head))) = 'FEE CONCESSION' THEN 1 WHEN UPPER(LTRIM(RTRIM(Fee_head))) LIKE '%CONCESSION%' THEN 2 ELSE 3 END, Fee_head_id";
                    DataSet dsConcHead = SYS.Show_Query(qConcHead);
                    if (dsConcHead != null && dsConcHead.Tables.Count > 0 && dsConcHead.Tables[0].Rows.Count > 0)
                    {
                        string concHeadId = dsConcHead.Tables[0].Rows[0]["Fee_head_id"].ToString().Trim();
                        double tMonths = 1;
                        string qMonths = "SELECT ISNULL(T_MONTHS, 1) FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + masterId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                        DataSet dsM = SYS.Show_Query(qMonths);
                        if (dsM != null && dsM.Tables.Count > 0 && dsM.Tables[0].Rows.Count > 0 && dsM.Tables[0].Rows[0][0] != DBNull.Value)
                        {
                            double.TryParse(dsM.Tables[0].Rows[0][0].ToString(), out tMonths);
                        }
                        if (tMonths <= 0) tMonths = 1;

                        double concAmt = stdConcession * tMonths;

                        if (existingDetails.ContainsKey(concHeadId) && existingDetails[concHeadId].Count > 0)
                        {
                            double currentConcAmt = 0;
                            double.TryParse(existingDetails[concHeadId][0][1], out currentConcAmt);
                            // Only apply if the existing concession line is 0 (i.e. unapplied)
                            if (currentConcAmt >= 0)
                            {
                                string primaryDetailId = existingDetails[concHeadId][0][0];
                                double newConcAmt = -concAmt;
                                string updConc = "UPDATE FEE_DETAIL SET AMOUNT = " + newConcAmt + ", BALANCE = " + newConcAmt + " " +
                                                 "WHERE FEE_DETAIL_ID = '" + primaryDetailId + "' " +
                                                 "  AND SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                                                 "  AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                                updateQueries.Add(updConc);
                                existingDetails[concHeadId][0][1] = newConcAmt.ToString();
                                appliedCount++;
                            }
                        }
                        else
                        {
                            // Concession line not yet in voucher, insert it
                            double newConcAmt = -concAmt;
                            string insConc = "INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, FEE_MONTH, ISCURRENT, BALANCE, FEE_MONTH_FROM, SessionID, branch_id) " +
                                             "VALUES (" + masterId + ", " + concHeadId + ", " + newConcAmt + ", '" + mTo + "', 'Y', " + newConcAmt + ", '" + mFrom + "', '" + SYSTEMSETTING.sessionid + "', '" + SYSTEMSETTING.branch_ID + "')";
                            updateQueries.Add(insConc);
                            existingDetails[concHeadId] = new List<string[]>();
                            existingDetails[concHeadId].Add(new string[] { "NEW", newConcAmt.ToString() });
                            appliedCount++;
                        }
                    }
                }

                if (hasFines)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string fineId = row["FINE_ID"].ToString().Trim();
                        string feeHeadId = row["Fee_head_id"].ToString().Trim();
                        string category = row["Category"] != DBNull.Value ? row["Category"].ToString().Trim().ToUpper() : "";
                        double fineAmt = 0;
                        if (row["FINE_AMOUNT"] != DBNull.Value)
                        {
                            double.TryParse(row["FINE_AMOUNT"].ToString(), out fineAmt);
                        }

                        if (fineAmt <= 0) continue;

                        bool isConcession = (category == "DISCOUNT" || category == "CONCESSION");

                        if (existingDetails.ContainsKey(feeHeadId) && existingDetails[feeHeadId].Count > 0)
                        {
                            // Update the primary row for this fee head
                            string primaryDetailId = existingDetails[feeHeadId][0][0];
                            double existingAmt = 0;
                            double.TryParse(existingDetails[feeHeadId][0][1], out existingAmt);
                            double newAmt;

                            if (isConcession)
                            {
                                if (existingAmt <= 0)
                                {
                                    newAmt = -(Math.Abs(existingAmt) + fineAmt);
                                }
                                else
                                {
                                    newAmt = -fineAmt;
                                }
                            }
                            else
                            {
                                newAmt = existingAmt + fineAmt;
                            }

                            string updDetail = "UPDATE FEE_DETAIL SET AMOUNT = " + newAmt + ", BALANCE = " + newAmt + " " +
                                               "WHERE FEE_DETAIL_ID = '" + primaryDetailId + "' " +
                                               "  AND SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                                               "  AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                            updateQueries.Add(updDetail);

                            // Update in-memory tracker
                            existingDetails[feeHeadId][0][1] = newAmt.ToString();

                            // Delete any duplicate rows for this fee head in this voucher
                            for (int i = 1; i < existingDetails[feeHeadId].Count; i++)
                            {
                                string dupId = existingDetails[feeHeadId][i][0];
                                string delDup = "DELETE FROM FEE_DETAIL WHERE FEE_DETAIL_ID = '" + dupId + "' " +
                                                "  AND SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                                                "  AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                                updateQueries.Add(delDup);
                            }
                            if (existingDetails[feeHeadId].Count > 1)
                            {
                                existingDetails[feeHeadId].RemoveRange(1, existingDetails[feeHeadId].Count - 1);
                            }
                        }
                        else
                        {
                            // Fee head not yet in voucher; insert single line
                            double detailAmt = isConcession ? -fineAmt : fineAmt;
                            string insDetail = "INSERT INTO FEE_DETAIL (FEE_MASTER_ID, Fee_head_id, AMOUNT, FEE_MONTH, ISCURRENT, BALANCE, FEE_MONTH_FROM, SessionID, branch_id) " +
                                               "VALUES (" + masterId + ", " + feeHeadId + ", " + detailAmt + ", '" + mTo + "', 'Y', " + detailAmt + ", '" + mFrom + "', '" + SYSTEMSETTING.sessionid + "', '" + SYSTEMSETTING.branch_ID + "')";
                            updateQueries.Add(insDetail);

                            if (!existingDetails.ContainsKey(feeHeadId))
                            {
                                existingDetails[feeHeadId] = new List<string[]>();
                            }
                            existingDetails[feeHeadId].Add(new string[] { "NEW", detailAmt.ToString() });
                        }

                        // Mark FINE_HISTORY as applied
                        string updFine = "UPDATE FINE_HISTORY SET active = 'N', FEE_MASTER_ID = '" + masterId + "' " +
                                         "WHERE FINE_ID = '" + fineId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                        updateQueries.Add(updFine);

                        appliedCount++;
                    }
                }

                if (updateQueries.Count > 0)
                {
                    string updMaster = "UPDATE FEE_MASTER SET " +
                                       "RECEIVABLE_AMOUNT = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + masterId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'), " +
                                       "BALANCE = (SELECT ISNULL(SUM(AMOUNT), 0) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + masterId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "') - ISNULL(REC_AMOUNT, 0) " +
                                       "WHERE FEE_MASTER_ID = '" + masterId + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'";
                    updateQueries.Add(updMaster);

                    bool ok = SYS.Insert_Query_manualcommit(updateQueries.ToArray());
                    if (!ok)
                    {
                        appliedCount = 0;
                    }
                }
            }
            catch (Exception)
            {
                appliedCount = 0;
            }

            return appliedCount;
        }

        /// <summary>
        /// Scans for students in a class (or a specific student) who already have a voucher for this month
        /// and applies any pending fines or concessions to their existing vouchers.
        /// </summary>
        public int ApplyPendingFinesForClassOrStudents(string classId, string monthTo, string monthFrom, string shift, string sectionId, string studentId)
        {
            int totalApplied = 0;
            try
            {
                string mTo = (monthTo ?? "").Trim();
                string mFrom = (monthFrom ?? "").Trim();
                if (string.IsNullOrEmpty(mFrom)) mFrom = mTo;

                string q = "SELECT fm.FEE_MASTER_ID, fm.s_id, s.ADMISSION_NO " +
                           "FROM FEE_MASTER fm " +
                           "INNER JOIN student s ON fm.s_id = s.s_id AND s.branch_id = fm.branch_id " +
                           "WHERE fm.C_ID = '" + classId + "' " +
                           "  AND fm.SessionID = '" + SYSTEMSETTING.sessionid + "' " +
                           "  AND fm.branch_id = '" + SYSTEMSETTING.branch_ID + "' " +
                           "  AND (fm.FEE_MONTH = '" + mTo + "' OR fm.FEE_MONTH = '" + mFrom + "' OR fm.FEE_MONTH_FROM = '" + mTo + "' OR fm.FEE_MONTH_FROM = '" + mFrom + "') ";

                if (!string.IsNullOrEmpty(studentId))
                {
                    q += " AND fm.s_id = '" + studentId.Replace("'", "''") + "' ";
                }
                if (!string.IsNullOrEmpty(shift))
                {
                    q += " AND fm.SHIFT = '" + shift.Replace("'", "''") + "' ";
                }

                DataSet ds = SYS.Show_Query(q);
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        string mId = r["FEE_MASTER_ID"].ToString();
                        string sId = r["s_id"].ToString();
                        string adm = r["ADMISSION_NO"] != DBNull.Value ? r["ADMISSION_NO"].ToString() : "";

                        totalApplied += ApplyPendingFinesToExistingVoucher(mId, sId, adm, mTo, mFrom);
                    }
                }
            }
            catch (Exception)
            {
            }
            return totalApplied;
        }

        public bool submitfeeSingle(double paidamountbyform, string voucherno, bool finetag, DateTime submitdate, DateTime Duedate, string bankid, string SCROLLNO)
        {
            bool a = false;
            double receivable_amount = 0;
            double existing_rec = 0;
            double existing_bal = 0;
            string feemonth = "";
            string sid = "";
            string classid = "";
            string multitag = "";
            string fineafterduedate = "";
            string fee_month_from = "";

            try
            {
                QUERY = "Select * from [FEE_MASTER] where FEE_MASTER_ID='" + voucherno + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                rs = SYS.Show_Query(QUERY);
                if (rs != null && rs.Tables.Count > 0 && rs.Tables[0].Rows.Count > 0)
                {
                    DataRow Row = rs.Tables[0].Rows[0];
                    double.TryParse(Row["RECEIVABLE_AMOUNT"].ToString(), out receivable_amount);
                    if (Row["REC_AMOUNT"] != DBNull.Value) double.TryParse(Row["REC_AMOUNT"].ToString(), out existing_rec);
                    if (Row["BALANCE"] != DBNull.Value) double.TryParse(Row["BALANCE"].ToString(), out existing_bal);
                    else existing_bal = receivable_amount - existing_rec;
                    feemonth = Row["FEE_MONTH"] != DBNull.Value ? Row["FEE_MONTH"].ToString() : "";
                    fee_month_from = Row["FEE_MONTH_FROM"] != DBNull.Value ? Row["FEE_MONTH_FROM"].ToString() : "";
                    sid = Row["s_id"] != DBNull.Value ? Row["s_id"].ToString() : "";
                    classid = Row["C_ID"] != DBNull.Value ? Row["C_ID"].ToString() : "";
                    multitag = Row["MULTITAG"] != DBNull.Value ? Row["MULTITAG"].ToString() : "";
                    fineafterduedate = Row["FINE_AFTER_DUE_DATE"] != DBNull.Value ? Row["FINE_AFTER_DUE_DATE"].ToString() : "0";
                }

                //----- Update student status from un-confirmed to confirm ------//
                bool isconfirmation = true;
                QUERY = "UPDATE student set isconfirm='" + isconfirmation + "' where s_id='" + sid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                SYS.Insert_Query(QUERY);
                //---- ~~~~~~~~~~~~~~~~~~~ -----//

                if (submitdate > Duedate)
                {
                    double fineVal = 0;
                    double.TryParse(fineafterduedate, out fineVal);
                    receivable_amount += fineVal;
                }

                double todayPayment = paidamountbyform;
                double newTotalRec = 0;

                if (existing_rec > 0)
                {
                    if (paidamountbyform > existing_bal && paidamountbyform <= receivable_amount)
                    {
                        // User entered cumulative paid amount
                        newTotalRec = paidamountbyform;
                        todayPayment = newTotalRec - existing_rec;
                    }
                    else
                    {
                        // User entered payment for today
                        todayPayment = paidamountbyform;
                        newTotalRec = existing_rec + todayPayment;
                    }
                }
                else
                {
                    todayPayment = paidamountbyform;
                    newTotalRec = paidamountbyform;
                }

                if (todayPayment < 0) todayPayment = 0;
                if (newTotalRec > receivable_amount) newTotalRec = receivable_amount;

                double balance = receivable_amount - newTotalRec;
                if (balance < 0) balance = 0;
                string paidStatus = (balance <= 0) ? "Y" : "N";

                string sDateStr = submitdate.ToString("yyyy-MM-dd HH:mm:ss");
                string safeScroll = string.IsNullOrEmpty(SCROLLNO) ? "" : (SCROLLNO.Length > 5 ? SCROLLNO.Substring(0, 5) : SCROLLNO);

                QUERY = "Update FEE_MASTER set REC_AMOUNT='" + newTotalRec + "', SUBMIT_DATE='" + sDateStr + "', RECEIVABLE_AMOUNT='" + receivable_amount + "', PAID='" + paidStatus + "', BALANCE ='" + balance + "', STATUS='Y', BANK_ID='" + bankid + "', SCROLLNO='" + safeScroll + "', FINE_AFTER_DUE_DATE=0 WHERE FEE_MASTER_ID='" + voucherno + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                a = SYS.Insert_Query(QUERY);

                // Allocate cumulative received amount across fee heads
                double allocRemaining = newTotalRec;
                QUERY = "select AMOUNT, FEE_DETAIL_ID from FEE_DETAIL where FEE_MASTER_ID='" + voucherno + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by FEE_DETAIL_ID";
                rs = SYS.Show_Query(QUERY);
                if (rs != null && rs.Tables.Count > 0 && rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Row in rs.Tables[0].Rows)
                    {
                        double headamount = 0;
                        double.TryParse(Row[0].ToString(), out headamount);
                        string detailId = Row[1].ToString();

                        if (headamount <= 0)
                        {
                            SYS.Insert_Query("Update FEE_DETAIL set RECEIVED_AMOUNT='0', BALANCE='" + headamount + "' where FEE_MASTER_ID='" + voucherno + "' and FEE_DETAIL_ID='" + detailId + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                        }
                        else if (allocRemaining >= headamount)
                        {
                            allocRemaining -= headamount;
                            SYS.Insert_Query("Update FEE_DETAIL set RECEIVED_AMOUNT='" + headamount + "', BALANCE='0' where FEE_MASTER_ID='" + voucherno + "' and FEE_DETAIL_ID='" + detailId + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                        }
                        else if (allocRemaining > 0)
                        {
                            double rem = headamount - allocRemaining;
                            SYS.Insert_Query("Update FEE_DETAIL set RECEIVED_AMOUNT='" + allocRemaining + "', BALANCE='" + rem + "' where FEE_MASTER_ID='" + voucherno + "' and FEE_DETAIL_ID='" + detailId + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                            allocRemaining = 0;
                        }
                        else
                        {
                            SYS.Insert_Query("Update FEE_DETAIL set RECEIVED_AMOUNT='0', BALANCE='" + headamount + "' where FEE_MASTER_ID='" + voucherno + "' and FEE_DETAIL_ID='" + detailId + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                        }
                    }
                }

                // Insert into FEE_HISTORY
                string sDateNew = submitdate.ToString("yyyy-MM-dd");
                string QUERY2 = "Insert into FEE_HISTORY(VOUCHER_NO,SUBMITION_DATE,PAID_AMOUNT,SessionID,SUBMISSION_DATE_NEW,BRANCH_ID) VALUES('" + voucherno + "','" + submitdate.ToShortDateString() + "','" + todayPayment + "','" + SYSTEMSETTING.sessionid + "','" + sDateNew + "','" + SYSTEMSETTING.branch_ID + "')";
                SYS.Insert_Query(QUERY2);

                // Recalculate downstream unposted arrears for this student
                RecalculateStudentArrears(sid, SYSTEMSETTING.branch_ID, SYSTEMSETTING.sessionid);
            }
            catch (Exception ex)
            {
                SYS.setMessageBox(ex.Message, 3);
                a = false;
            }

            return a;
        }


        public void BalanceVoucher(string VoucherNo, string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId)) sessionId = SYSTEMSETTING.sessionid;
            string TotalAmount = "0";

            string q = "select sum(amount) from FEE_DETAIL where FEE_MASTER_ID='" + VoucherNo + "'";
            if (!string.IsNullOrEmpty(sessionId))
            {
                q += " AND SessionID='" + sessionId + "'";
            }
            if (!string.IsNullOrEmpty(SYSTEMSETTING.branch_ID))
            {
                q += " AND branch_id='" + SYSTEMSETTING.branch_ID + "'";
            }
            DataSet dsBal = SYS.Show_Query(q);

            if (dsBal != null && dsBal.Tables.Count > 0 && dsBal.Tables[0].Rows.Count > 0)
            {
                object val = dsBal.Tables[0].Rows[0][0];
                if (val != DBNull.Value && !string.IsNullOrEmpty(val.ToString()))
                {
                    TotalAmount = val.ToString();
                }
            }

            double totalAmt = 0;
            double.TryParse(TotalAmount, out totalAmt);

            double recAmt = 0;
            string qRec = "select REC_AMOUNT from FEE_MASTER where FEE_MASTER_ID='" + VoucherNo + "'";
            if (!string.IsNullOrEmpty(sessionId))
            {
                qRec += " AND SessionID='" + sessionId + "'";
            }
            if (!string.IsNullOrEmpty(SYSTEMSETTING.branch_ID))
            {
                qRec += " AND branch_id='" + SYSTEMSETTING.branch_ID + "'";
            }
            DataSet dsRec = SYS.Show_Query(qRec);
            if (dsRec != null && dsRec.Tables.Count > 0 && dsRec.Tables[0].Rows.Count > 0)
            {
                object rVal = dsRec.Tables[0].Rows[0]["REC_AMOUNT"];
                if (rVal != DBNull.Value && !string.IsNullOrEmpty(rVal.ToString()))
                {
                    double.TryParse(rVal.ToString(), out recAmt);
                }
            }

            double bal = totalAmt - recAmt;
            if (bal < 0) bal = 0;

            string qUpd = "Update FEE_MASTER set RECEIVABLE_AMOUNT='" + totalAmt + "',BALANCE='" + bal + "' where FEE_MASTER_ID='" + VoucherNo + "'";
            if (!string.IsNullOrEmpty(sessionId))
            {
                qUpd += " AND SessionID='" + sessionId + "'";
            }
            if (!string.IsNullOrEmpty(SYSTEMSETTING.branch_ID))
            {
                qUpd += " AND branch_id='" + SYSTEMSETTING.branch_ID + "'";
            }
            SYS.Insert_Query(qUpd);
        }

        public void BalanceVoucher(string VoucherNo)
        {
            BalanceVoucher(VoucherNo, SYSTEMSETTING.sessionid);
        }

        public void RecalculateStudentArrears(string studentId, string branchId, string sessionId)
        {
            try
            {
                if (string.IsNullOrEmpty(studentId)) return;
                if (string.IsNullOrEmpty(branchId)) branchId = SYSTEMSETTING.branch_ID;
                if (string.IsNullOrEmpty(sessionId)) sessionId = SYSTEMSETTING.sessionid;

                string resolvedSid = studentId;
                string qCheck = "SELECT s_id FROM student WHERE s_id = '" + studentId + "' AND branch_id = '" + branchId + "'";
                DataSet dsCheck = SYS.Show_Query(qCheck);
                if (dsCheck == null || dsCheck.Tables.Count == 0 || dsCheck.Tables[0].Rows.Count == 0)
                {
                    string qAdm = "SELECT s_id FROM student WHERE ADMISSION_NO = '" + studentId + "' AND branch_id = '" + branchId + "'";
                    DataSet dsAdm = SYS.Show_Query(qAdm);
                    if (dsAdm != null && dsAdm.Tables.Count > 0 && dsAdm.Tables[0].Rows.Count > 0)
                    {
                        resolvedSid = dsAdm.Tables[0].Rows[0]["s_id"].ToString();
                    }
                }

                string q = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE s_id = '" + resolvedSid + "' AND branch_id = '" + branchId + "' AND SessionID = '" + sessionId + "' AND (PAID IS NULL OR PAID <> 'Y' OR (BALANCE > 0 AND (REC_AMOUNT IS NULL OR REC_AMOUNT = 0))) ORDER BY FEE_MASTER_ID";
                DataSet ds = SYS.Show_Query(q);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                List<DataRow> unpostedVouchers = new List<DataRow>();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    double rec = 0;
                    if (r["REC_AMOUNT"] != DBNull.Value) double.TryParse(r["REC_AMOUNT"].ToString(), out rec);
                    if (rec <= 0)
                    {
                        unpostedVouchers.Add(r);
                    }
                }

                unpostedVouchers.Sort(delegate(DataRow a, DataRow b)
                {
                    int ka = GetFeeMonthSortKey(a["FEE_MONTH"] != DBNull.Value ? a["FEE_MONTH"].ToString() : "");
                    int kb = GetFeeMonthSortKey(b["FEE_MONTH"] != DBNull.Value ? b["FEE_MONTH"].ToString() : "");
                    if (ka != kb) return ka.CompareTo(kb);
                    int idA = 0, idB = 0;
                    int.TryParse(a["FEE_MASTER_ID"].ToString(), out idA);
                    int.TryParse(b["FEE_MASTER_ID"].ToString(), out idB);
                    return idA.CompareTo(idB);
                });

                string arrearHeadId = GetBranchArrearHeadId(branchId);

                foreach (DataRow unposted in unpostedVouchers)
                {
                    string vMasterId = unposted["FEE_MASTER_ID"].ToString();
                    string vMonth = unposted["FEE_MONTH"] != DBNull.Value ? unposted["FEE_MONTH"].ToString().Trim() : "";

                    double outstanding = GetPreviousOutstandingArrears(resolvedSid, vMonth, vMasterId, branchId, sessionId);

                    string qArrear = "SELECT d.FEE_DETAIL_ID, d.AMOUNT FROM FEE_DETAIL d LEFT JOIN Fee_Head h ON d.Fee_head_id = h.Fee_head_id WHERE d.FEE_MASTER_ID = '" + vMasterId + "' AND d.SessionID = '" + sessionId + "' AND d.branch_id = '" + branchId + "' AND (d.Fee_head_id = '" + arrearHeadId + "' OR d.ISCURRENT = 'N' OR h.Category = 'ARREAR' OR UPPER(h.Fee_head) LIKE '%ARREAR%')";
                    DataSet dsArrear = SYS.Show_Query(qArrear);

                    if (outstanding <= 0)
                    {
                        if (dsArrear != null && dsArrear.Tables.Count > 0 && dsArrear.Tables[0].Rows.Count > 0)
                        {
                            SYS.Insert_Query("DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + vMasterId + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "' AND (Fee_head_id = '" + arrearHeadId + "' OR ISCURRENT = 'N' OR Fee_head_id IN (SELECT Fee_head_id FROM Fee_Head WHERE Category = 'ARREAR' OR UPPER(Fee_head) LIKE '%ARREAR%'))");
                            BalanceVoucher(vMasterId, sessionId);
                        }
                    }
                    else
                    {
                        if (dsArrear != null && dsArrear.Tables.Count > 0 && dsArrear.Tables[0].Rows.Count > 0)
                        {
                            string firstDetailId = dsArrear.Tables[0].Rows[0]["FEE_DETAIL_ID"].ToString();
                            SYS.Insert_Query("UPDATE FEE_DETAIL SET AMOUNT = '" + outstanding + "', BALANCE = '" + outstanding + "', Fee_head_id = '" + arrearHeadId + "', ISCURRENT = 'N' WHERE FEE_DETAIL_ID = '" + firstDetailId + "' AND FEE_MASTER_ID = '" + vMasterId + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "'");

                            if (dsArrear.Tables[0].Rows.Count > 1)
                            {
                                for (int k = 1; k < dsArrear.Tables[0].Rows.Count; k++)
                                {
                                    string extraDetailId = dsArrear.Tables[0].Rows[k]["FEE_DETAIL_ID"].ToString();
                                    SYS.Insert_Query("DELETE FROM FEE_DETAIL WHERE FEE_DETAIL_ID = '" + extraDetailId + "' AND FEE_MASTER_ID = '" + vMasterId + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "'");
                                }
                            }
                        }
                        else
                        {
                            SYS.Insert_Query("INSERT INTO FEE_DETAIL(FEE_MASTER_ID, Fee_head_id, AMOUNT, FEE_MONTH, ISCURRENT, BALANCE, FEE_MONTH_FROM, SessionID, branch_id) VALUES('" + vMasterId + "','" + arrearHeadId + "','" + outstanding + "','" + vMonth + "','N','" + outstanding + "','" + vMonth + "','" + sessionId + "','" + branchId + "')");
                        }
                        BalanceVoucher(vMasterId, sessionId);
                    }
                }
            }
            catch
            {
            }
        }

        public void RecalculateVoucherArrears(string voucherNo, string sessionId)
        {
            try
            {
                if (string.IsNullOrEmpty(voucherNo)) return;
                string q = "SELECT s_id, branch_id, SessionID, PAID FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + voucherNo + "'";
                DataSet ds = SYS.Show_Query(q);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = ds.Tables[0].Rows[0];
                    string paid = r["PAID"] != DBNull.Value ? r["PAID"].ToString().Trim().ToUpper() : "";
                    if (paid != "Y")
                    {
                        string sid = r["s_id"].ToString();
                        string bid = r["branch_id"].ToString();
                        string sess = string.IsNullOrEmpty(sessionId) ? r["SessionID"].ToString() : sessionId;
                        RecalculateStudentArrears(sid, bid, sess);
                    }
                }
            }
            catch { }
        }

        public void RecalculateClassUnpostedArrears(string classId, string feeMonth, string shift, string section, string sessionId, string branchId)
        {
            try
            {
                if (string.IsNullOrEmpty(sessionId)) sessionId = SYSTEMSETTING.sessionid;
                if (string.IsNullOrEmpty(branchId)) branchId = SYSTEMSETTING.branch_ID;

                string q = "SELECT DISTINCT s_id FROM FEE_MASTER WHERE C_ID = '" + classId + "' AND FEE_MONTH = '" + feeMonth + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "' AND (PAID IS NULL OR PAID <> 'Y')";
                DataSet ds = SYS.Show_Query(q);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        string sid = r["s_id"].ToString();
                        RecalculateStudentArrears(sid, branchId, sessionId);
                    }
                }
            }
            catch { }
        }

        public static int GetFeeMonthSortKey(string feeMonth)
        {
            if (string.IsNullOrEmpty(feeMonth)) return 0;
            string s = feeMonth.Trim();

            string[] parts = s.Split(new char[] { ' ', '/', '-', '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                int p0, p1;
                if (int.TryParse(parts[0], out p0) && int.TryParse(parts[1], out p1))
                {
                    if (p1 > 1000 && p0 >= 1 && p0 <= 12)
                    {
                        return p1 * 12 + p0;
                    }
                    if (p0 > 1000 && p1 >= 1 && p1 <= 12)
                    {
                        return p0 * 12 + p1;
                    }
                }
            }

            DateTime dt;
            if (DateTime.TryParse(s, out dt))
            {
                return dt.Year * 12 + dt.Month;
            }

            return 0;
        }

        public string GetBranchArrearHeadId(string branchId)
        {
            try
            {
                string q = "SELECT TOP 1 Fee_head_id FROM Fee_Head WHERE branch_id = '" + branchId + "' AND (Category = 'ARREAR' OR UPPER(Fee_head) LIKE '%ARREAR%') ORDER BY CASE WHEN Category = 'ARREAR' THEN 1 ELSE 2 END, CASE WHEN UPPER(LTRIM(RTRIM(Fee_head))) = 'ARREARS' THEN 1 WHEN UPPER(LTRIM(RTRIM(Fee_head))) = 'PREVIOUS ARREARS' THEN 2 ELSE 3 END, Fee_head_id";
                DataSet ds = SYS.Show_Query(q);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Fee_head_id"].ToString();
                }
            }
            catch { }
            return "3";
        }

        public double GetPreviousOutstandingArrears(string studentId, string currentFeeMonth, string currentMasterId, string branchId, string sessionId)
        {
            try
            {
                if (string.IsNullOrEmpty(branchId)) branchId = SYSTEMSETTING.branch_ID;
                if (string.IsNullOrEmpty(sessionId)) sessionId = SYSTEMSETTING.sessionid;

                int targetKey = GetFeeMonthSortKey(currentFeeMonth);

                string q = "SELECT FEE_MASTER_ID, FEE_MONTH, RECEIVABLE_AMOUNT, REC_AMOUNT, BALANCE, PAID, STATUS FROM FEE_MASTER WHERE s_id = '" + studentId + "' AND branch_id = '" + branchId + "' AND SessionID = '" + sessionId + "'";
                if (!string.IsNullOrEmpty(currentMasterId))
                {
                    q += " AND FEE_MASTER_ID <> '" + currentMasterId + "'";
                }
                q += " ORDER BY FEE_MASTER_ID";

                DataSet ds = SYS.Show_Query(q);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    return 0;
                }

                List<DataRow> priorVouchers = new List<DataRow>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string vMonth = row["FEE_MONTH"] != DBNull.Value ? row["FEE_MONTH"].ToString().Trim() : "";
                    int vKey = GetFeeMonthSortKey(vMonth);

                    if (targetKey > 0 && vKey > 0)
                    {
                        if (vKey < targetKey)
                        {
                            priorVouchers.Add(row);
                        }
                    }
                    else
                    {
                        if (!string.Equals(vMonth, currentFeeMonth, StringComparison.OrdinalIgnoreCase))
                        {
                            priorVouchers.Add(row);
                        }
                    }
                }

                if (priorVouchers.Count == 0)
                {
                    return 0;
                }

                priorVouchers.Sort(delegate(DataRow a, DataRow b)
                {
                    int ka = GetFeeMonthSortKey(a["FEE_MONTH"].ToString());
                    int kb = GetFeeMonthSortKey(b["FEE_MONTH"].ToString());
                    if (ka != kb) return ka.CompareTo(kb);
                    int idA = 0, idB = 0;
                    int.TryParse(a["FEE_MASTER_ID"].ToString(), out idA);
                    int.TryParse(b["FEE_MASTER_ID"].ToString(), out idB);
                    return idA.CompareTo(idB);
                });

                // Check the most recent prior voucher
                DataRow lastPrior = priorVouchers[priorVouchers.Count - 1];
                string lastMasterId = lastPrior["FEE_MASTER_ID"].ToString();

                double recv = 0;
                if (lastPrior["RECEIVABLE_AMOUNT"] != DBNull.Value)
                {
                    double.TryParse(lastPrior["RECEIVABLE_AMOUNT"].ToString(), out recv);
                }

                double recAmt = 0;
                if (lastPrior["REC_AMOUNT"] != DBNull.Value && !string.IsNullOrEmpty(lastPrior["REC_AMOUNT"].ToString()))
                {
                    double.TryParse(lastPrior["REC_AMOUNT"].ToString(), out recAmt);
                }

                // Check FEE_HISTORY for actual recorded payments on this voucher
                string qHist = "SELECT SUM(CONVERT(FLOAT, PAID_AMOUNT)) FROM FEE_HISTORY WHERE VOUCHER_NO = '" + lastMasterId + "' AND SessionID = '" + sessionId + "' AND BRANCH_ID = '" + branchId + "'";
                DataSet dsHist = SYS.Show_Query(qHist);
                if (dsHist != null && dsHist.Tables.Count > 0 && dsHist.Tables[0].Rows.Count > 0)
                {
                    object hVal = dsHist.Tables[0].Rows[0][0];
                    if (hVal != DBNull.Value && !string.IsNullOrEmpty(hVal.ToString()))
                    {
                        double hAmt = 0;
                        if (double.TryParse(hVal.ToString(), out hAmt) && hAmt > recAmt)
                        {
                            recAmt = hAmt;
                        }
                    }
                }

                string pStatus = lastPrior["PAID"] != DBNull.Value ? lastPrior["PAID"].ToString().Trim().ToUpper() : "";
                string sStatus = lastPrior["STATUS"] != DBNull.Value ? lastPrior["STATUS"].ToString().Trim().ToUpper() : "";

                double recordedBal = -1;
                if (lastPrior["BALANCE"] != DBNull.Value && !string.IsNullOrEmpty(lastPrior["BALANCE"].ToString()))
                {
                    double bVal = 0;
                    if (double.TryParse(lastPrior["BALANCE"].ToString(), out bVal))
                    {
                        recordedBal = bVal;
                    }
                }

                // 1. Fully Paid Check:
                // If marked PAID='Y', or recorded balance <= 0 (when paid/has payment or receivable > 0), or received >= receivable:
                if (pStatus == "Y" || (recordedBal == 0 && (recAmt > 0 || recv > 0)) || (recAmt >= recv && recv > 0))
                {
                    return 0;
                }

                // 2. Partial Payment Check:
                // If payments have been made on the voucher, carry forward ONLY the actual remaining balance
                if (recAmt > 0)
                {
                    double actualRemaining = recv - recAmt;
                    if (recordedBal >= 0 && recordedBal < actualRemaining)
                    {
                        actualRemaining = recordedBal;
                    }
                    return (actualRemaining > 0) ? actualRemaining : 0;
                }

                // 3. Unpaid Voucher:
                // If recorded balance > 0, return recorded balance; otherwise receivable amount
                double unpaidBal = (recordedBal > 0) ? recordedBal : ((recv > 0) ? recv : 0);

                string arrearHeadId = GetBranchArrearHeadId(branchId);
                string qCheckArrear = "SELECT COUNT(*) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + lastMasterId + "' AND SessionID = '" + sessionId + "' AND branch_id = '" + branchId + "' AND (Fee_head_id = '" + arrearHeadId + "' OR ISCURRENT = 'N' OR Fee_head_id IN (SELECT Fee_head_id FROM Fee_Head WHERE Category = 'ARREAR' OR UPPER(Fee_head) LIKE '%ARREAR%'))";
                DataSet dsCheckArr = SYS.Show_Query(qCheckArrear);
                bool hasCarriedArrear = false;
                if (dsCheckArr != null && dsCheckArr.Tables.Count > 0 && dsCheckArr.Tables[0].Rows.Count > 0)
                {
                    int cnt = 0;
                    int.TryParse(dsCheckArr.Tables[0].Rows[0][0].ToString(), out cnt);
                    hasCarriedArrear = cnt > 0;
                }

                if (hasCarriedArrear || priorVouchers.Count == 1)
                {
                    return unpaidBal;
                }

                // If prior vouchers were generated independently without carry-forward, accumulate remaining balances of unrolled prior vouchers
                double totalRemaining = unpaidBal;
                for (int i = priorVouchers.Count - 2; i >= 0; i--)
                {
                    DataRow prevV = priorVouchers[i];
                    string prevPaid = prevV["PAID"] != DBNull.Value ? prevV["PAID"].ToString().Trim().ToUpper() : "";
                    if (prevPaid == "Y") break;

                    double prevRecv = 0, prevRec = 0;
                    if (prevV["RECEIVABLE_AMOUNT"] != DBNull.Value) double.TryParse(prevV["RECEIVABLE_AMOUNT"].ToString(), out prevRecv);
                    if (prevV["REC_AMOUNT"] != DBNull.Value) double.TryParse(prevV["REC_AMOUNT"].ToString(), out prevRec);

                    if (prevRecv > prevRec)
                    {
                        totalRemaining += (prevRecv - prevRec);
                    }
                }

                return (totalRemaining > 0) ? totalRemaining : 0;
            }
            catch
            {
                return 0;
            }
        }



    }
}
