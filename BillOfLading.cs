using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EM
{
	/// <summary>
	/// Summary description for BillOfLading.
	/// </summary>
	public class BillOfLading : KeyBasedForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private AutoCompleteTextBox pickupDateEdt;
		private System.Windows.Forms.Button pickupDateBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label asdabfsd;
		private AutoCompleteTextBox contNumberEdt;
		private System.Windows.Forms.Button findContainerBtn;
		private System.Windows.Forms.TabControl bolViewTabPage;
		private System.Windows.Forms.TabPage bundlesPage;
		private AutoCompleteTextBox bolNumberEdt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		string[] m_textFieldNames;
		AutoCompleteTextBox[] m_textBoxes;
		
		string[] m_dateFieldNames;
		AutoCompleteTextBox[] m_dateBoxes;
		private System.Windows.Forms.TabControl containerViewTabPage;
		private System.Windows.Forms.TabPage containerBundlePage;
		private System.Windows.Forms.TabPage containerWeightPage;
		private System.Windows.Forms.Button addBtn;
		Button[] m_dateButtons;
		private System.Windows.Forms.Button removeBtn;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox statusCombo;
		QuickGrid bolGrid = new QuickGrid();
		public BillOfLading(int bolID)
		{
			m_currentKey = bolID;
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_textFieldNames = new string[]{"BOLNumber"};
			m_textBoxes = new AutoCompleteTextBox[]{this.bolNumberEdt};
		
			m_dateFieldNames = new string[]{"PickupDate"};
			m_dateBoxes = new AutoCompleteTextBox[]{this.pickupDateEdt};
			m_dateButtons = new Button[]{this.pickupDateBtn};

			SetupQuickGrid.DoIt(containerBundleGrid,containerBundlePage);
			SetupQuickGrid.DoIt(containerWeightGrid,containerWeightPage);
			SetupQuickGrid.DoIt(bolGrid,bundlesPage);
			Refresh();
		}
		EMDataSet emDataSet = new EMDataSet();
		QuickGrid containerBundleGrid = new QuickGrid();
		QuickGrid containerWeightGrid = new QuickGrid();
		public override DataTable GetHeaderTable()
		{
			return emDataSet.BOLTbl;
		}
		public new EMDataSet.BOLTblRow GetHeaderRow()
		{
			return (EMDataSet.BOLTblRow)base.GetHeaderRow();
		}
		public override void InitializeDataRow(DataRow newRow)
		{
			EMDataSet.BOLTblRow row = (EMDataSet.BOLTblRow)newRow;
			row.BOLNumber = "";
			row.Status = "Open";
		}
		public override void OnFind()
		{
			try
			{
				if (!TryToCommit())
					return;
				string bolNumber = Chooser.GetBOL(AdapterHelper.Connection);
				if (bolNumber != null)
				{
					int bolID = base.GetKeyFromField("BOLNumber","'" + DataInterface.ExpandQuotes(bolNumber)+ "'");
					if (bolID != -1)
						base.CurrentKey = bolID;
				}
		
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public override bool OnUpdateFind()
		{
			return true;
		}
		public override bool IsChanged()
		{
			if (base.IsChanged())
				return true;
			if (emDataSet.BOLItemTbl.GetChanges() != null)
				return true;
			return false;
		}
		
		public override string GetTableName() {return "tblBOL";}
		void FillFromItemRow(EMDataSet.BOLItemTblRow row)
		{
			AdapterHelper.FillContBundleFromContBundleID(emDataSet,row.ContainerBundleID);
			int contID = row.ContBundleTblRow.ContID;
			AdapterHelper.FillContainerHeader(emDataSet,contID);
			AdapterHelper.FillPOItemFromPOItemNumber(emDataSet,row.ContBundleTblRow.POItemNumber);
			foreach (EMDataSet.POItemTblRow poItemRow in emDataSet.POItemTbl.Rows)
			{
				int poid = poItemRow.POID;
				AdapterHelper.FillPOHeader(emDataSet,poid);
				if (!poItemRow.IsItemIDNull())
					AdapterHelper.FillItem(emDataSet,poItemRow.ItemID);
			}
		}
		public override void FillTablesFromDatabase() 
		{
			emDataSet.Clear();
			using (TurnOffConstraints doIt = new TurnOffConstraints(emDataSet))
			{
				AdapterHelper.FillBillOfLading(emDataSet,CurrentKey);
				AdapterHelper.FillBillOfLadingItem(emDataSet,CurrentKey);
				foreach (EMDataSet.BOLItemTblRow row in emDataSet.BOLItemTbl.Rows)
				{
					FillFromItemRow(row);
				}
			}
		}
		public override void CommitTablesToDatabase() 
		{
			using (FileStream lockFile = DataInterface.CreateLockFile("bol.lock"))
			{
				using (new OpenConnection(IsWrite.Yes,AdapterHelper.Connection))
				{
					AdapterHelper.CommitBOLChanges(emDataSet);
				}
			}
			
			
		}
		public override OleDbConnection GetConnection() 
		{
			return AdapterHelper.Connection;
		}
		public override string[] GetSortOrder() 
		{
			return new string[]{"Status","BOLNumber"};
		}
		public override void ClearDataSet() 
		{
			emDataSet.Clear();
		}

		public override void UpdateControls() 
		{
			FormSupport.UpdateTextControls(m_textBoxes,m_textFieldNames,GetHeaderRow(),IsEmptyTable());
			FormSupport.UpdateDateControls(m_dateBoxes,m_dateButtons,m_dateFieldNames,GetHeaderRow(),
				IsEmptyTable());
			if (GetHeaderRow().IsStatusNull())
				statusCombo.Text = "";
			else
				statusCombo.Text = GetHeaderRow().Status;
			statusCombo.Enabled = !IsEmptyTable();
			UpdateGrid();
			RefreshContainerGrids();
			addBtn.Enabled = !IsEmptyTable();
		}
		public override void FromControls() 
		{
			GetHeaderRow().Status = statusCombo.Text;
			FormSupport.FromTextControls(m_textBoxes,m_textFieldNames,GetHeaderRow());
			FormSupport.FromDateControls(m_dateBoxes,m_dateFieldNames,GetHeaderRow());
		}
		EMDataSet.BOLItemTblRow[] GetAllDetailRows()
		{
			EMDataSet.BOLTblRow row = GetHeaderRow();
			return row.GetBOLItemTblRows();
		}

		public override bool IsDeleteAllowed() 
		{
			if (GetAllDetailRows().Length != 0)
			{
				MessageBox.Show("Delete of the bill of lading is not allowed " + 
					"unless all items in the bill of lading have been deleted",
					"Can't delete");
				return false;
			}
			return true;
		}
		

		private void OnDateLeave(object sender, System.EventArgs e)
		{
			FormSupport.OnDateLeave(sender,m_dateBoxes,m_dateFieldNames,GetHeaderRow());
		}

		private void OnDateClick(object sender, System.EventArgs e)
		{
			DateTime dummyTime;
			FormSupport.OnDateBtn(sender,m_dateButtons,m_dateBoxes,m_dateFieldNames,GetHeaderRow(),out dummyTime);
		}

		object GetFieldValue(DataRow sourceRowIn,bool isMetric,string fieldName)
		{
			EMDataSet.BOLItemTblRow bolItemRow = (EMDataSet.BOLItemTblRow)sourceRowIn;
			EMDataSet.ContBundleTblRow bundleRow = bolItemRow.ContBundleTblRow;
			EMDataSet.ContainerTblRow containerRow = bundleRow.ContainerTblRow;
			EMDataSet.POItemTblRow poItemRow = bundleRow.POItemTblRow;
			EMDataSet.POHeaderTblRow poHeaderRow = poItemRow.POHeaderTblRow;
			switch (fieldName)
			{
				case "BundleSeqNumber":
					return bundleRow["BundleSeqNumber"];
				case "ContNumber":
					return containerRow["ContNumber"];
				case "PONumber":
					return poHeaderRow["PONumber"];
				case "ItemName":
				{
					if (poItemRow.IsItemIDNull())
						return DBNull.Value;
					return poItemRow.ItemTblRow["ItemName"];
				}
				case "SizeOfItem":
					return poItemRow["SizeOfItem"];
				case "ItemAccessCode":
					return poItemRow["ItemAccessCode"];
				case "MetricShipQty":
					return bundleRow["MetricShipQty"];
				case "EnglishShipQty":
					return bundleRow["EnglishShipQty"];
				case "Heat":
					return bundleRow["Heat"];
				case "BayNumber":
					return bundleRow["BayNumber"];
				case "BOLID":
					return bolItemRow["BOLID"];
				case "ContainerBundleID":
					return bundleRow["ContainerBundleID"];
			}
			Debug.Assert(false);
			return null;
			
		}
		
		void UpdateGrid()
		{
			string[] fields = {"ContNumber","BundleSeqNumber","PONumber","ItemName","SizeOfItem","ItemAccessCode",
									"MetricShipQty","EnglishShipQty",
								  "Heat","BayNumber","BOLID","ContainerBundleID"};
			bool isMetric = false; // Does this matter?
			FormSupport.GridWizard(bolGrid,emDataSet.BOLItemTbl,isMetric,IsNewAllowed.No,IsReadOnly.Yes,
				"ContNumber,BundleSeqNumber",new FormSupport.GetFieldDelegate(GetFieldValue),null,
				fields);
		}

		
		private void addBtn_Click(object sender, System.EventArgs e)
		{
			int selectedIndex = containerViewTabPage.SelectedIndex;
			if (selectedIndex != 0)
				return;
			EM.QuickGrid.Index index = this.containerBundleGrid.GetCurrentIndex();
			DataTable table = this.containerBundleGrid.GetTable();
			if (table.Rows.Count <= index.row)
				return;
			DataRow row = table.Rows[index.row];
			int bundleID = (int)row["ContainerBundleID"];
			if (emDataSet.BOLItemTbl.FindByBOLIDContainerBundleID(CurrentKey,bundleID)!= null)
				return; // already there
			EMDataSet.BOLItemTblRow bolItemTblRow = emDataSet.BOLItemTbl.NewBOLItemTblRow();
			bolItemTblRow.ContainerBundleID = bundleID;
			bolItemTblRow.BOLID = CurrentKey;

			using (TurnOffConstraints doThat = new TurnOffConstraints(emDataSet))
			using (OpenConnection doIt = new OpenConnection(IsWrite.No,GetConnection()))
			{
				this.FillFromItemRow(bolItemTblRow);
			}
			emDataSet.BOLItemTbl.Rows.Add(bolItemTblRow);
			UpdateGrid();
			RefreshContainerGrids();
		}

		private void removeBtn_Click(object sender, System.EventArgs e)
		{
			EM.QuickGrid.Index index = this.bolGrid.GetCurrentIndex();
			DataTable table = this.bolGrid.GetTable();
			if (index.row < 0 || index.row >= table.Rows.Count)
				return;
			DataRow row = table.Rows[index.row];
			int bolid = (int)row["BOLID"];
			int bundleID = (int)row["ContainerBundleID"];
			EMDataSet.BOLItemTblRow bolRow = emDataSet.BOLItemTbl.FindByBOLIDContainerBundleID(CurrentKey,bundleID);
			Debug.Assert(bolRow != null);
			bolRow.Delete();
			UpdateGrid();
			RefreshContainerGrids();
		}

		EMDataSet.BOLItemTblRow FindBOLByContBundleID(int contBundleID)
		{
			foreach (EMDataSet.BOLItemTblRow row in emDataSet.BOLItemTbl.Rows)
			{
				int rowID;
				if (row.RowState == DataRowState.Deleted)
				{
					rowID = (int)row["ContainerBundleID",DataRowVersion.Original];
				}
				else if (row.RowState == DataRowState.Added)
				{
					rowID = (int)row["ContainerBundleID"];
				}
				else
					continue;
				if (rowID == contBundleID)
					return row;
			}
			return null;
		}

		private object GetBillOfLadingNumber(EMDataSet.ContBundleTblRow row)
		{
			int contBundleID = row.ContainerBundleID;
			// Does this item exist in our view, either deleted or not
			EMDataSet.BOLItemTblRow bolItemRow = FindBOLByContBundleID(contBundleID);
			if (bolItemRow != null)
			{
				if (bolItemRow.RowState == DataRowState.Deleted)
					return DBNull.Value;
				else
				{
					return bolItemRow.BOLTblRow.BOLNumber;
				}
			}
			return FormSupport.DefaultGetBillOfLadingNumber(row);
			
		}

		int m_containerGridID;
		private void RefreshContainerGrids()
		{
			EMDataSet containerDataSet = new EMDataSet();
			FormSupport.FillContainerFromDatabase(containerDataSet,m_containerGridID);
			decimal totalLbs;
			decimal totalKgs;
			FormSupport.SetupContainerGrids(containerDataSet,
				m_containerGridID,
				containerBundleGrid,
				containerWeightGrid,null,IsReadOnly.Yes,
				out totalLbs,out totalKgs,
				new FormSupport.GetBillOfLadingNumberFunc(
				GetBillOfLadingNumber));		
		}

		private void findContainerBtn_Click(object sender, System.EventArgs e)
		{
			try 
			{
				string contNumber = Chooser.GetContainer(AdapterHelper.Connection);
				if (contNumber != null)
				{
					int contID = DataInterface.GetKeyFromField(GetConnection(),"tblContainer",
								"ContID","ContNumber","\"" + contNumber + "\"");
					if (contID != -1)
					{
						m_containerGridID = contID;
						RefreshContainerGrids();
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.bolNumberEdt = new EM.AutoCompleteTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pickupDateEdt = new EM.AutoCompleteTextBox();
			this.pickupDateBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.containerViewTabPage = new System.Windows.Forms.TabControl();
			this.containerBundlePage = new System.Windows.Forms.TabPage();
			this.containerWeightPage = new System.Windows.Forms.TabPage();
			this.findContainerBtn = new System.Windows.Forms.Button();
			this.contNumberEdt = new EM.AutoCompleteTextBox();
			this.asdabfsd = new System.Windows.Forms.Label();
			this.bolViewTabPage = new System.Windows.Forms.TabControl();
			this.bundlesPage = new System.Windows.Forms.TabPage();
			this.addBtn = new System.Windows.Forms.Button();
			this.removeBtn = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.statusCombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.containerViewTabPage.SuspendLayout();
			this.bolViewTabPage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// bolNumberEdt
			// 
			this.bolNumberEdt.Location = new System.Drawing.Point(96, 8);
			this.bolNumberEdt.Name = "bolNumberEdt";
			this.bolNumberEdt.TabIndex = 0;
			this.bolNumberEdt.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bill Of Lading #";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(248, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Pickup Date:";
			// 
			// pickupDateEdt
			// 
			this.pickupDateEdt.Location = new System.Drawing.Point(320, 8);
			this.pickupDateEdt.Name = "pickupDateEdt";
			this.pickupDateEdt.TabIndex = 3;
			this.pickupDateEdt.Text = "";
			this.pickupDateEdt.Leave += new System.EventHandler(this.OnDateLeave);
			// 
			// pickupDateBtn
			// 
			this.pickupDateBtn.Location = new System.Drawing.Point(432, 8);
			this.pickupDateBtn.Name = "pickupDateBtn";
			this.pickupDateBtn.Size = new System.Drawing.Size(24, 23);
			this.pickupDateBtn.TabIndex = 4;
			this.pickupDateBtn.Text = "...";
			this.pickupDateBtn.Click += new System.EventHandler(this.OnDateClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.containerViewTabPage);
			this.groupBox1.Controls.Add(this.findContainerBtn);
			this.groupBox1.Controls.Add(this.contNumberEdt);
			this.groupBox1.Controls.Add(this.asdabfsd);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(960, 312);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Container View";
			// 
			// containerViewTabPage
			// 
			this.containerViewTabPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.containerViewTabPage.Controls.Add(this.containerBundlePage);
			this.containerViewTabPage.Controls.Add(this.containerWeightPage);
			this.containerViewTabPage.Location = new System.Drawing.Point(8, 40);
			this.containerViewTabPage.Name = "containerViewTabPage";
			this.containerViewTabPage.SelectedIndex = 0;
			this.containerViewTabPage.Size = new System.Drawing.Size(944, 272);
			this.containerViewTabPage.TabIndex = 9;
			// 
			// containerBundlePage
			// 
			this.containerBundlePage.Location = new System.Drawing.Point(4, 22);
			this.containerBundlePage.Name = "containerBundlePage";
			this.containerBundlePage.Size = new System.Drawing.Size(936, 246);
			this.containerBundlePage.TabIndex = 0;
			this.containerBundlePage.Text = "Container Bundles";
			// 
			// containerWeightPage
			// 
			this.containerWeightPage.Location = new System.Drawing.Point(4, 22);
			this.containerWeightPage.Name = "containerWeightPage";
			this.containerWeightPage.Size = new System.Drawing.Size(936, 246);
			this.containerWeightPage.TabIndex = 1;
			this.containerWeightPage.Text = "Container by Weight";
			// 
			// findContainerBtn
			// 
			this.findContainerBtn.Location = new System.Drawing.Point(224, 16);
			this.findContainerBtn.Name = "findContainerBtn";
			this.findContainerBtn.Size = new System.Drawing.Size(24, 23);
			this.findContainerBtn.TabIndex = 8;
			this.findContainerBtn.Text = "...";
			this.findContainerBtn.Click += new System.EventHandler(this.findContainerBtn_Click);
			// 
			// contNumberEdt
			// 
			this.contNumberEdt.Location = new System.Drawing.Point(120, 16);
			this.contNumberEdt.Name = "contNumberEdt";
			this.contNumberEdt.ReadOnly = true;
			this.contNumberEdt.TabIndex = 7;
			this.contNumberEdt.Text = "";
			// 
			// asdabfsd
			// 
			this.asdabfsd.Location = new System.Drawing.Point(8, 16);
			this.asdabfsd.Name = "asdabfsd";
			this.asdabfsd.TabIndex = 6;
			this.asdabfsd.Text = "Container #";
			// 
			// bolViewTabPage
			// 
			this.bolViewTabPage.Controls.Add(this.bundlesPage);
			this.bolViewTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bolViewTabPage.Location = new System.Drawing.Point(0, 392);
			this.bolViewTabPage.Name = "bolViewTabPage";
			this.bolViewTabPage.SelectedIndex = 0;
			this.bolViewTabPage.Size = new System.Drawing.Size(960, 237);
			this.bolViewTabPage.TabIndex = 3;
			// 
			// bundlesPage
			// 
			this.bundlesPage.Location = new System.Drawing.Point(4, 22);
			this.bundlesPage.Name = "bundlesPage";
			this.bundlesPage.Size = new System.Drawing.Size(952, 211);
			this.bundlesPage.TabIndex = 0;
			this.bundlesPage.Text = "B/L Bundles";
			// 
			// addBtn
			// 
			this.addBtn.Location = new System.Drawing.Point(8, 16);
			this.addBtn.Name = "addBtn";
			this.addBtn.TabIndex = 8;
			this.addBtn.Text = "Add";
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// removeBtn
			// 
			this.removeBtn.Location = new System.Drawing.Point(8, 8);
			this.removeBtn.Name = "removeBtn";
			this.removeBtn.TabIndex = 9;
			this.removeBtn.Text = "Remove";
			this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.statusCombo);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.pickupDateBtn);
			this.panel1.Controls.Add(this.bolNumberEdt);
			this.panel1.Controls.Add(this.pickupDateEdt);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(960, 32);
			this.panel1.TabIndex = 0;
			// 
			// statusCombo
			// 
			this.statusCombo.Items.AddRange(new object[] {
															 "Open",
															 "Closed",
															 "Cancelled"});
			this.statusCombo.Location = new System.Drawing.Point(528, 8);
			this.statusCombo.Name = "statusCombo";
			this.statusCombo.Size = new System.Drawing.Size(121, 21);
			this.statusCombo.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(480, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Status:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.removeBtn);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 629);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(960, 40);
			this.panel2.TabIndex = 4;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.addBtn);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 344);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(960, 48);
			this.panel3.TabIndex = 2;
			// 
			// BillOfLading
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(960, 669);
			this.Controls.Add(this.bolViewTabPage);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Name = "BillOfLading";
			this.Text = "Bill Of Lading";
			this.groupBox1.ResumeLayout(false);
			this.containerViewTabPage.ResumeLayout(false);
			this.bolViewTabPage.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion







	}
}
