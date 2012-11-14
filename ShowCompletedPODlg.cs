using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EM
{
    public partial class ShowCompletedPODlg : Form
    {
        EMDataSet m_emDataSet;
        public ShowCompletedPODlg(EMDataSet poDataSet,string friendlyConstraintsText)
        {
            m_emDataSet = poDataSet;
            m_emDataSet.AcceptChanges();
            InitializeComponent();
            percentEdt.Text = "80";
            this.constraintsEdt.Text = friendlyConstraintsText;
            MyRefresh();
        }
        private void MyRefresh()
        {
            try
            {
                poTreeView.Nodes.Clear();
                int percentComplete = int.Parse(percentEdt.Text);
                textBox1.Text = "";
                foreach (EMDataSet.POHeaderTblRow row in m_emDataSet.POHeaderTbl)
                {
                    TreeNode treeNode = new TreeNode(row.PONumber);
                    bool completed =
                        DataInterface.IsPOCompleted(row, ref treeNode, DataInterface.IsBundlePickedUp,percentComplete);
                    DataInterface.SortOnString(treeNode);
                    if (completed)
                    {
                        this.poTreeView.Nodes.Add(treeNode);
                        textBox1.Text += treeNode.Text + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            m_emDataSet.RejectChanges();

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            MyRefresh();
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            try
            {
                if (poTreeView.SelectedNode == null)
                    return;
                DataInterface.POCompletedNodeTag tag = (DataInterface.POCompletedNodeTag)
                this.poTreeView.SelectedNode.Tag;
                if (tag != null)
                    MainWindow.ShowPOForm(tag.poid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }

}