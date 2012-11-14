using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EM
{
    public partial class InvoiceSupportForm : Form
    {
        int CompareSurcharge(EMDataSet.SurchargeRateTblRow leftSurcharge, EMDataSet.SurchargeRateTblRow rightSurcharge)
        {
            int leftSurchargeMonth = leftSurcharge.SurchargeMonth;
            int rightSurchargeMonth = rightSurcharge.SurchargeMonth;
            if (leftSurcharge.SurchargeMonth < rightSurcharge.SurchargeMonth)
                return -1;
            if (leftSurcharge.SurchargeMonth > rightSurcharge.SurchargeMonth)
                return 1;
            int leftFinishIDNull = leftSurcharge.IsFinishIDNull() ? 0 : 1;
            int rightFinishIDNull = rightSurcharge.IsFinishIDNull() ? 0 : 1;
            if (leftFinishIDNull < rightFinishIDNull)
                return -1;
            if (leftFinishIDNull > rightFinishIDNull)
                return 1;
            if (!(leftSurcharge.IsFinishIDNull() || rightSurcharge.IsFinishIDNull()))
            {
                if (leftSurcharge.FinishID < rightSurcharge.FinishID)
                    return -1;
                if (leftSurcharge.FinishID > rightSurcharge.FinishID)
                    return 1;
            }
            int leftSurchargeItemID = leftSurcharge.ItemID;
            int rightSurchargeItemID = rightSurcharge.ItemID;
            if (leftSurcharge.ItemID == -1 &&
                rightSurcharge.ItemID != -1)
                return -1;
            if (leftSurcharge.ItemID != -1 &&
                rightSurcharge.ItemID == -1)
                return 1;
            if (leftSurcharge.ItemID == -1 &&
                rightSurcharge.ItemID == -1)
            {
                return 0;
            }

            EMDataSet.ItemTblRow left = this.m_emDataSet.ItemTbl.FindByItemID(leftSurcharge.ItemID);
            EMDataSet.ItemTblRow right = this.m_emDataSet.ItemTbl.FindByItemID(rightSurcharge.ItemID);
            int leftCompID = left.CompID;
            int rightCompID = right.CompID;
            string leftCompName = this.m_emDataSet.CompanyTbl.FindByCompID(left.CompID).CompName;
            string rightCompName = this.m_emDataSet.CompanyTbl.FindByCompID(right.CompID).CompName;
            int compCompare = string.Compare(leftCompName, rightCompName);
            if (compCompare != 0)
                return compCompare;
            return string.Compare(left.ItemName, right.ItemName);
        }
        EMDataSet m_emDataSet;
        public InvoiceSupportForm(EMDataSet emDataSet)
        {
            m_emDataSet = emDataSet;
            InitializeComponent();
            emDataSet.EnforceConstraints = false;
            foreach (EMDataSet.FinishTblRow row in emDataSet.FinishTbl)
            {

                decimal commissionRate = row.IsCommissionRateNull() ? 0 : row.CommissionRate;
                string[] values = new string[] { row.FinishType, commissionRate.ToString() };
                finishGridView.Rows.Add(values);
                finishGridView.Rows[finishGridView.Rows.Count - 1].Tag = row.FinishID; ;
            }
            // first collect list of items in the report
            ArrayList surchargeIDs = new ArrayList();
            foreach (EMDataSet.POItemTblRow row in emDataSet.POItemTbl)
            {
                if (!DataInterface.IsRowAlive(row))
                    continue;
                if (row.IsItemIDNull())
                    continue;
                EMDataSet.ContBundleTblRow[] bundleRows = row.GetContBundleTblRows();
                if (bundleRows.Length == 0) // obsolete invoice report (but still runs)
                {
                    surchargeIDs.Add(new SurchargeKey(row.ItemID,
                    row.IsFinishIDNull() ? -1 : row.FinishID, -1, null));
                    // add scrap surcharge
                    surchargeIDs.Add(new SurchargeKey(-1, row.IsFinishIDNull() ? -1 : row.FinishID, -1, null));
                }
                else
                {
                    foreach (EMDataSet.ContBundleTblRow bundleRow in bundleRows)
                    {
                        if (bundleRow.IsMillInvoiceDateNull())
                            continue;
                        DateTime millInvoiceDate = bundleRow.MillInvoiceDate;
                        surchargeIDs.Add(new SurchargeKey(row.ItemID,
                            row.IsFinishIDNull() ? -1 : row.FinishID,
                            HelperFunctions.GetMonthYearCode(millInvoiceDate), bundleRow));
                        // add scrap surcharge
                        surchargeIDs.Add(new SurchargeKey(-1, row.IsFinishIDNull() ? -1 : row.FinishID,
                            HelperFunctions.GetMonthYearCode(millInvoiceDate), bundleRow));
                    }
                }
            }
            AdapterHelper.Unique(ref surchargeIDs,
                delegate(object leftIn, object rightIn)
                {
                    SurchargeKey left = (SurchargeKey)leftIn;
                    SurchargeKey right = (SurchargeKey)rightIn;
                    left.bundleRows.AddRange(right.bundleRows);
                }
                );
            List<EMDataSet.SurchargeRateTblRow> surchargeRows = new List<EMDataSet.SurchargeRateTblRow>();
            using (new EM.OpenConnection(EM.IsWrite.No, AdapterHelper.Connection))
            {
                foreach (SurchargeKey surchargeKey in surchargeIDs)
                {
                    AdapterHelper.FillSurcharge(emDataSet.SurchargeRateTbl, surchargeKey.itemID,
                                                surchargeKey.finishID, surchargeKey.monthYear);
                    // find it
                    string query = "ItemID=" + surchargeKey.itemID;
                    query += "AND FinishID=" + surchargeKey.finishID;
                    query += " AND SurchargeMonth=" + surchargeKey.monthYear;
                    EMDataSet.SurchargeRateTblRow[] rows = (EMDataSet.SurchargeRateTblRow[])
                        emDataSet.SurchargeRateTbl.Select(query);
                    if (rows.Length > 1)
                        throw new Exception("BUG. too many surcharge matches...");
                    EMDataSet.SurchargeRateTblRow surchargeRow = null;
                    if (rows.Length == 0)
                    {
                        int key = DataInterface.GetNextKeyNumber("tblSurchargeRate");
                        surchargeRow = emDataSet.SurchargeRateTbl.NewSurchargeRateTblRow();
                        if (surchargeKey.finishID != -1) // otherwise leave it null
                            surchargeRow.FinishID = surchargeKey.finishID;
                        surchargeRow.ItemID = surchargeKey.itemID;
                        surchargeRow.SurchargeMonth = surchargeKey.monthYear;
                        surchargeRow.SurchargeID = key;
                        surchargeRow.SurchargeRate = 0;
                        emDataSet.SurchargeRateTbl.AddSurchargeRateTblRow(surchargeRow);
                        surchargeRows.Add(surchargeRow);
                    }
                    if (rows.Length == 1)
                    {
                        surchargeRow = rows[0];
                        surchargeRows.Add(surchargeRow);
                    }

                    // Using the bundleSeqNumber as a way to connect the crystal report
                    // view of each bundle to the surchagetable.
                    foreach (EMDataSet.ContBundleTblRow bundleRow in surchargeKey.bundleRows)
                    {
                        if (surchargeKey.itemID == -1) // scrap surcharge
                            bundleRow.AuxKey2 = surchargeRow.SurchargeID;
                        else
                            bundleRow.AuxKey1 = surchargeRow.SurchargeID;
                    }
                }
            }
            surchargeRows.Sort(new Comparison<EMDataSet.SurchargeRateTblRow>(CompareSurcharge));
            {
                foreach (EMDataSet.SurchargeRateTblRow surchargeRow in surchargeRows)
                {
                    decimal surchargeRate = surchargeRow.SurchargeRate;
                    string surchargeDate = surchargeRow.IsSurchargeDateNull() ? "" : surchargeRow.SurchargeDate.ToShortDateString();
                    string itemName;
                    string customerName;
                    if (surchargeRow.ItemID == -1)
                    {
                        itemName = "Scrap";
                        customerName = "";
                    }
                    else
                    {
                        EMDataSet.ItemTblRow itemRow = emDataSet.ItemTbl.FindByItemID(surchargeRow.ItemID);
                        itemName = itemRow.ItemName;
                        EMDataSet.CompanyTblRow customerRow = emDataSet.CompanyTbl.FindByCompID(itemRow.CompID);
                        customerName = customerRow.IsCompNameAbbreviationNull() ||
                                       customerRow.CompNameAbbreviation == ""
                                       ? customerRow.CompName :
                            customerRow.CompNameAbbreviation;
                        System.Diagnostics.Debug.Assert(customerName != null && customerName != "");
                    }

                    string finish = surchargeRow.IsFinishIDNull() ? "" : emDataSet.FinishTbl.FindByFinishID(surchargeRow.FinishID).FinishType;
                    surchargeGridView.Rows.Add(customerName, finish, itemName, (surchargeRate*100).ToString(),
                                                HelperFunctions.GetMonthYearString(surchargeRow.SurchargeMonth));
                    surchargeGridView.Rows[surchargeGridView.Rows.Count - 1].Tag = surchargeRow.SurchargeID;
                }
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {

                // First off, determine what change 
                foreach (DataGridViewRow row in finishGridView.Rows)
                {
                    decimal finishQty = decimal.Parse((string)row.Cells[1].Value);
                    EMDataSet.FinishTblRow finishRow = m_emDataSet.FinishTbl.FindByFinishID((int)row.Tag);
                    finishRow.CommissionRate = finishQty;
                }
                foreach (DataGridViewRow row in this.surchargeGridView.Rows)
                {
                    decimal surcharge = decimal.Parse((string)row.Cells[3].Value)/100;
                    EMDataSet.SurchargeRateTblRow surchargeRow = m_emDataSet.SurchargeRateTbl.FindBySurchargeID((int)row.Tag);
                    surchargeRow.SurchargeRate = surcharge;
                }
                using (new OpenConnection(IsWrite.Yes, AdapterHelper.Connection))
                {
                    AdapterHelper.CommitFinishChanges(m_emDataSet);
                    AdapterHelper.CommitSurchargeChanges(m_emDataSet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void surchargeGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       /* private void btnConvert_Click(object sender, EventArgs e)
        {
           
                EMDataSet emDataSet = new EMDataSet();
                emDataSet.EnforceConstraints = false;
                List<int> finishIDs = new List<int>();
                
                using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
                {    
                    AdapterHelper.FillItems(emDataSet);
                finishIDs.Add(-1);
                AdapterHelper.FillFinish(emDataSet.FinishTbl);
                }
                foreach (EMDataSet.FinishTblRow finishRow in emDataSet.FinishTbl)
                {
                    finishIDs.Add(finishRow.FinishID);
                }
                foreach (EMDataSet.ItemTblRow itemRow in emDataSet.ItemTbl)
                {
                    foreach (int finishID in finishIDs)
                    {
                        EMDataSet.SurchargeRateTblRow surchargeRow =
                            emDataSet.SurchargeRateTbl.NewSurchargeRateTblRow();
                        if (itemRow.IsNull("SurchargeRate"))
                            continue;
                        surchargeRow.SurchargeID = DataInterface.GetNextKeyNumber("tblSurchargeRate");
                        if (finishID != -1)
                            surchargeRow.FinishID = finishID;
                        surchargeRow.ItemID = itemRow.ItemID;
                        surchargeRow["SurchargeRate"] = itemRow["SurchargeRate"];
                        surchargeRow["SurchargeDate"] = itemRow["SurchargeDate"];
                        emDataSet.SurchargeRateTbl.AddSurchargeRateTblRow(surchargeRow);
                    }
                }
            using (new OpenConnection(IsWrite.Yes,AdapterHelper.Connection))
            {
                AdapterHelper.CommitSurchargeChanges(emDataSet);
            }
        }*/
    }
    public class SurchargeKey : IComparable
    {
        public SurchargeKey(int itemID_, int finishID_,int monthYear_,EMDataSet.ContBundleTblRow bundleRow_)
        {
            itemID = itemID_;
            finishID = finishID_;
            monthYear = monthYear_;
            if (bundleRow_ != null)
            {
                bundleRows = new List<EMDataSet.ContBundleTblRow>();
                bundleRows.Add(bundleRow_);
            }
        }

        public int CompareTo(object obj)
        {
            // Check for reflexivity
            int compareResult = CompareToInternal(obj);
            int refCompareResult = ((SurchargeKey)obj).CompareToInternal(this);

            System.Diagnostics.Debug.Assert(refCompareResult * -1 == compareResult);
            return compareResult;
        }
        public int CompareToInternal(object obj)
        {
            SurchargeKey key = (SurchargeKey)obj;

            if (itemID.CompareTo(key.itemID) == 0)
            {
                if (finishID.CompareTo(key.finishID) == 0)
                    return monthYear.CompareTo(key.monthYear);
                else
                    return finishID.CompareTo(key.finishID);
            }
            else
                return itemID.CompareTo(key.itemID);
        }
        public int itemID;
        public int finishID;
        public int monthYear;
        public List<EMDataSet.ContBundleTblRow> bundleRows;
    }
}