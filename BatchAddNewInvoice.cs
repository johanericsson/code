using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EM
{
    public partial class BatchAddNewInvoice : Form
    {
        List<EMDataSet.ContBundleTblRow> m_bundleRows;
        public BatchAddNewInvoice(List<EMDataSet.ContBundleTblRow> bundleRows)
        {
            m_bundleRows = bundleRows;

            InitializeComponent();
            foreach (EMDataSet.ContBundleTblRow bundleRow in m_bundleRows)
            {
                // PONumber
                // ItemNameObsolete
                // Container
                // Bundle ID
                // EnglishShipQty
                TreeNode newNode = new TreeNode(bundleRow.ContainerTblRow.ContNumber + ":" +
                                                bundleRow.BundleSeqNumber.ToString());

                newNode.Tag = bundleRow;
                EMDataSet.POItemTblRow itemRow = bundleRow.POItemTblRow;
                newNode.Nodes.Add("PO:" + itemRow.POHeaderTblRow.PONumber);
                newNode.Nodes.Add("ItemName:" + itemRow.ItemNameObsolete);
                newNode.Nodes.Add("Size:" + (itemRow.IsSizeOfItemNull()?"":itemRow.SizeOfItem));
                newNode.Nodes.Add("Length:" + (itemRow.IsLengthNull()?"":itemRow.Length));
                if (!bundleRow.IsEnglishShipQtyNull())
                    newNode.Nodes.Add("lbs:" + bundleRow.EnglishShipQty);
                foreach (TreeNode node in newNode.Nodes)
                {
                    node.Tag = bundleRow;
                }
                bundleRowsView.Nodes.Add(newNode);
            }
        }
        string FindNextName()
        {
            string name = "m:\\newinvoiceCommit";
            string fullName = null;
            for (int i = 0; ; i++)
            {
                fullName = name;
                fullName += i.ToString();
                fullName += ".txt";
                if (!System.IO.File.Exists(fullName))
                    break;
            }
            return fullName;
        }
        private void yesBtn_Click(object sender, EventArgs e)
        {
            int emInvoice = 0;
            try
            {
                emInvoice = int.Parse(emInvoiceNumberEdt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't parse EM Invoice #\n" + ex.Message);
                return;
            }
            m_bundleRows[0].Table.DataSet.RejectChanges();
            foreach (EMDataSet.ContBundleTblRow bundles in m_bundleRows)
            {
                bundles.EMInvoiceNumber = emInvoice.ToString();
            }
            using (TextWriter tw = new StreamWriter(FindNextName()))
            {
                foreach (EMDataSet.ContBundleTblRow bundles in m_bundleRows)
                {
                    tw.Write(bundles.ContainerBundleID.ToString() + "|" + emInvoice.ToString() +
                        tw.NewLine);
                }
            }
            using (new OpenConnection(IsWrite.Yes, AdapterHelper.Connection))
            {
                AdapterHelper.CommitContainerChanges((EMDataSet)m_bundleRows[0].Table.DataSet);
            }
            this.Close();
        }
        private void showSelectedBtn_Click(object sender, EventArgs e)
        {
            EMDataSet.ContBundleTblRow bundleRow = 
                (EMDataSet.ContBundleTblRow)bundleRowsView.SelectedNode.Tag;
            MainWindow.ShowContainerForm(bundleRow.ContID, bundleRow.ContainerBundleID);
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}