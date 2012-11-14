using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace EM
{
    public partial class CloseContainer : Form
    {
        EMDataSet.ContainerTblRow m_containerRow;
        EMDataSet GetDataSet()
        {
            return (EMDataSet)m_containerRow.Table.DataSet;
        }
        EMDataSet.ContainerTblRow GetHeaderRow()
        {
            return m_containerRow;
        }
            public int m_contid;
        EMDataSet m_refresedDataSet;

        void RefreshFromContID()
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
			
            try
            {
                listOfCompletedPOs.Nodes.Clear();
                viewOfNotCompletedPOs.Nodes.Clear();

                EMDataSet emDataSet = new EMDataSet();
                using (new TurnOffConstraints(emDataSet))
                using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
                {
                    FormSupport.FillContainerFromDatabase(emDataSet, m_contid);
                    foreach (EMDataSet.POHeaderTblRow poHeader in emDataSet.POHeaderTbl)
                    {
                        AdapterHelper.FillPOItem(emDataSet,poHeader.POID);
                    }
                    foreach (EMDataSet.POItemTblRow itemRow in emDataSet.POItemTbl)
                    {
                        AdapterHelper.FillContBundleFromPOItemNumber(emDataSet, itemRow.POItemNumber);
                    }
                    AdapterHelper.FillOutConstraints(emDataSet);

                    foreach (EMDataSet.ContainerTblRow containerRow in emDataSet.ContainerTbl)
                    {
                        FormSupport.FillContainerFromDatabase(emDataSet, containerRow.ContID);
                    }
                }
                m_containerRow = emDataSet.ContainerTbl.FindByContID(m_contid);

                ArrayList listOfPOs = new ArrayList();
                foreach (EMDataSet.ContBundleTblRow bundleRow in GetHeaderRow().GetContBundleTblRows())
                {
                    int poid = bundleRow.POItemTblRow.POID;
                    listOfPOs.Add(poid);
                }
                AdapterHelper.Unique(ref listOfPOs);

                containerLbl.Text = GetHeaderRow().ContNumber;
                AdapterHelper.Unique(ref listOfPOs);
                foreach (int poid in listOfPOs)
                {
                    EMDataSet.POHeaderTblRow poHeaderRow =
                        GetDataSet().POHeaderTbl.FindByPOID(poid);
                    TreeNode treeNode = new TreeNode(poHeaderRow.PONumber);
                    bool completed =
                        DataInterface.IsPOCompleted(poHeaderRow, ref treeNode,DataInterface.IsBundlePickedUp);
                    DataInterface.SortOnString(treeNode);
                    if (completed)
                    {
                        listOfCompletedPOs.Nodes.Add(treeNode);
                    }
                    else
                    {
                        viewOfNotCompletedPOs.Nodes.Add(treeNode);
                    }
                }
                this.m_refresedDataSet = emDataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = oldCursor;
        }
        public static void ShowReport(EMDataSet emDataSet,int contid,string reportDescription)
        {
            GenericCrystalViewer view = new GenericCrystalViewer();
            view.Text = "Balance Report";
            BalanceReport report = new BalanceReport();
            report.SetDataSource(emDataSet);
            view.viewer.ReportSource = report;
            ParameterFields fields = new ParameterFields();
            ParameterField field = new ParameterField();
            field.ParameterFieldName = "contNumber";
            ParameterDiscreteValue discrete = new ParameterDiscreteValue();
            discrete.Value = emDataSet.ContainerTbl.FindByContID(contid).ContNumber;
            field.CurrentValues.Add(discrete);
            fields.Add(field);
            ParameterField field2 = new ParameterField();
            field2.ParameterFieldName = "ReportDescription";
            ParameterDiscreteValue discrete2 = new ParameterDiscreteValue();
            discrete2.Value = reportDescription;
            field2.CurrentValues.Add(discrete2);
            fields.Add(field2);
            view.viewer.ParameterFieldInfo = fields;
                
            view.Show();
        }
        public CloseContainer(int contid)
        {
            InitializeComponent();
            this.TopMost = true;
            m_contid = contid;
            RefreshFromContID();
        }
        private void gotoPOBtn_Click(object sender, EventArgs e)
        {

            if (listOfCompletedPOs.SelectedNode == null)
                return; 
            DataInterface.POCompletedNodeTag tag = (DataInterface.POCompletedNodeTag)
                        listOfCompletedPOs.SelectedNode.Tag;

            if (tag!=null)
                MainWindow.ShowPOForm(tag.poid);
        }

        private void gotoContainerBtn_Click(object sender, EventArgs e)
        {

            if (listOfCompletedPOs.SelectedNode == null)
                return;
            DataInterface.POCompletedNodeTag tag = (DataInterface.POCompletedNodeTag)
            listOfCompletedPOs.SelectedNode.Tag;
            if (tag!=null && tag.contID != -1)
                MainWindow.ShowContainerForm(tag.contID);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (viewOfNotCompletedPOs.SelectedNode == null)
                return;
            DataInterface.POCompletedNodeTag tag = (DataInterface.POCompletedNodeTag)
            this.viewOfNotCompletedPOs.SelectedNode.Tag;
            if (tag!=null)
                MainWindow.ShowPOForm(tag.poid);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (viewOfNotCompletedPOs.SelectedNode == null)
                return;
            DataInterface.POCompletedNodeTag tag = (DataInterface.POCompletedNodeTag)
                this.viewOfNotCompletedPOs.SelectedNode.Tag;
            if (tag!=null && tag.contID != -1)
                MainWindow.ShowContainerForm(tag.contID);
        }

        private void viewHeaderContainer_Click(object sender, EventArgs e)
        {
            MainWindow.ShowContainerForm(GetHeaderRow().ContID);
        }

        private void CloseContainer_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GetHeaderRow().Status = "Closed";
                foreach (TreeNode tn in listOfCompletedPOs.Nodes)
                {
                    DataInterface.POCompletedNodeTag tag = (DataInterface.POCompletedNodeTag)
                                tn.Tag;
                    EMDataSet.POHeaderTblRow row =
                        GetDataSet().POHeaderTbl.FindByPOID(tag.poid);
                    row.Status = "Closed";
                
                }
                using (new OpenConnection(IsWrite.Yes, AdapterHelper.Connection))
                {
                    AdapterHelper.CommitContainerChanges(GetDataSet());
                    AdapterHelper.CommitAllPOHeaders(GetDataSet());
                }
                MainWindow.ShowContainerForm(m_contid);
                this.Close();
                MessageBox.Show("Container & associated POs successfully closed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshFromContID();
        }

        private void showDataAsReport(object sender, EventArgs e)
        {
            ShowReport(m_refresedDataSet, m_contid, "This report lists how much of an item in a PO has been included in a container that has been picked up.");

        }

        private void dontClosePO_Click(object sender, EventArgs e)
        {
            TreeNode node = this.listOfCompletedPOs.SelectedNode;
            if (node == null)
                return;
            this.viewOfNotCompletedPOs.Nodes.Add((TreeNode)node.Clone());
            this.listOfCompletedPOs.Nodes.Remove(node);
           
        }

        private void closePO_Click(object sender, EventArgs e)
        {
            TreeNode node = this.viewOfNotCompletedPOs.SelectedNode;
            if (node == null)
                return;
            this.listOfCompletedPOs.Nodes.Add((TreeNode)node.Clone());
            this.viewOfNotCompletedPOs.Nodes.Remove(node);
           
        }



    }
}