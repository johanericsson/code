/*using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace EM
{
	/// <summary>
	/// Summary description for POItem.
	/// </summary>
	public class POItem : EMForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox poNumberEdt;
		private System.Windows.Forms.TextBox nameEdt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox lengthEdt;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox sizeEdt;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox IACEdt;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox dateReqEdt;
		private System.Windows.Forms.Button dateReqBtn;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox heatEdt;
		private System.Data.OleDb.OleDbDataAdapter poHeaderAdapter;
		private System.Data.OleDb.OleDbDataAdapter poItemAdapter;
		private EM.EMDataSet m_emDataSet;
		private System.Windows.Forms.Button upBtn;
		private System.Windows.Forms.Button downBtn;
		private System.Windows.Forms.TabPage CommentsTabPage;
		private System.Windows.Forms.TextBox m_commentEdt;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.RadioButton m_kgBtn;
		private System.Windows.Forms.RadioButton m_lbsBtn;
		private System.Windows.Forms.TextBox kgEdt;
		private System.Windows.Forms.TextBox lbsEdt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox rateEdt;
		private System.Windows.Forms.TextBox metricRateEdt;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox m_custAmountEdt;
		private System.Windows.Forms.TabPage DescriptionTabPage;
		private System.Windows.Forms.TextBox m_descriptionEdt;
		private System.Windows.Forms.TabPage AcknowledgePage;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox acknowledgeEdt;
		private System.Windows.Forms.Button ackDateBtn;
		private System.Windows.Forms.Label staticText;
		private System.Windows.Forms.TextBox millConfirmEdt;
		private System.Windows.Forms.Label Static1;
		private System.Windows.Forms.TextBox millShipDateEdt;
		private System.Windows.Forms.Button shipDateBtn;
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.DataGrid generalGrid;
		private System.Windows.Forms.DataGrid rateGrid;
		private System.Windows.Forms.TabControl page3;
		private System.Windows.Forms.DataGrid ackGrid;
		private System.Windows.Forms.CheckBox collapseCheck;
		private System.Data.OleDb.OleDbDataAdapter contPOItemAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbDataAdapter containerAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.DataGrid containerGrid;
		private System.Windows.Forms.Button gotoPOBtn;
		private System.Windows.Forms.Button gotoContainerBtn;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox containerLbsEdt;
		private System.Windows.Forms.TextBox containerPercentEdt;
		private System.Windows.Forms.TextBox containerKgEdt;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public override void RefreshMainTableFromDataSource() 
		{
			m_emDataSet.Clear();
			DataInterface.FillAdapterWithParameter(poItemAdapter,m_poid);
			poItemAdapter.Fill(m_emDataSet.POItemTbl);
		}
		public override void RefreshOtherTablesFromDataSource()
		{
			DataInterface.FillAdapterWithParameter(poHeaderAdapter,m_poid);
			poHeaderAdapter.Fill(m_emDataSet.POHeaderTbl);
			DataInterface.FillWithContainerInformation(GetHeaderRow(),containerAdapter,
				contPOItemAdapter,m_emDataSet);
		}

		public EMDataSet.POHeaderTblRow GetPOHeaderRow()
		{
			
			EMDataSet.POHeaderTblRow headerRow = (EMDataSet.POHeaderTblRow)
								GetHeaderRow().GetParentRow("POHeaderTblPOItemTbl");
			return headerRow;
		}
		new EMDataSet.POItemTblRow GetHeaderRow()
		{
			return (EMDataSet.POItemTblRow)base.GetHeaderRow();
		}

		public override bool IsDeleteAllowed()
		{
			if (m_emDataSet.ContPOItemTbl.Rows.Count != 0)
			{
				MessageBox.Show("Delete of the purchase order item is not allowed " + 
					"until it has been removed from all containers",
					"Can't delete");
				return false;
			}
			if (base.Position != GetRecordCount() -1)
			{
				MessageBox.Show("Can only delete the item with the highest sequence number",
								"Can't delete");
				return false;
			}
			return true;
		}

		public void SetUM()
		{
			EMDataSet.POItemTblRow row = (EMDataSet.POItemTblRow)GetHeaderRow();
			bool isKg = m_kgBtn.Checked;
			if (isKg)
				row.UM = "kg";
			else
				row.UM = "lbs";
		}
		public override void FromControls()
		{
			EMDataSet.POItemTblRow row = GetHeaderRow();
			for (int i=0;i<m_textBoxes.Length;i++)
			{
				row[m_fieldNames[i]] = m_textBoxes[i].Text;
			}
			for (int i=0;i<m_dateFieldNames.Length;i++)
			{
				string field = m_dateFieldNames[i];
				TextBox box = m_dateTextBoxes[i];
				if (box.Text.Length == 0)
				{
					row[field] = DBNull.Value;
				}
				else
					row[field] = DateTime.Parse(box.Text);
			}
			for (int i=0;i<m_decimalFieldNames.Length;i++)
			{
				string field = m_decimalFieldNames[i];
				TextBox box = m_decimalTextBoxes[i];
				if (box.Text.Length == 0)
				{
					row[field] = DBNull.Value;
				}
				else
					row[field] = Decimal.Parse(box.Text);
			}
			SetUM();
			if (!row.IsQtyNull() && !row.IsCustRateNull())
				row.CustAmount = row.Qty * row.CustRate;
			else
				row.SetCustAmountNull();
		}
		public override void CommitTablesToDataSource() 
		{
			DataInterface.UpdateTableDelete(poItemAdapter,m_emDataSet.POItemTbl);
			DataInterface.UpdateTableAdd(poItemAdapter,m_emDataSet.POItemTbl);
		}
		public void UpdateEnabled() 
		{
			bool isKg = true;
			EMDataSet.POItemTblRow row = GetHeaderRow();
			if (!row.IsUMNull())
			{
				if (row.UM == "lbs")
					isKg = false;
			}
			rateEdt.ReadOnly = isKg;
			lbsEdt.ReadOnly = isKg;
			kgEdt.ReadOnly = !isKg;
			metricRateEdt.ReadOnly = !isKg;
			m_custAmountEdt.ReadOnly = true;
		}
		public override void UpdateControls()
		{
			EMDataSet.POItemTblRow row = GetHeaderRow();
			for (int i=0;i<m_textBoxes.Length;i++)
			{
				string field = m_fieldNames[i];
				TextBox box = m_textBoxes[i];
				if (row.IsNull(field))
					box.Text = "";
				else
					box.Text = (string)row[field];
			}
			for (int i =0;i<m_dateTextBoxes.Length;i++)
			{
				string field = m_dateFieldNames[i];
				TextBox box = m_dateTextBoxes[i];
				if (row.IsNull(field))
					box.Text = "";
				else
					box.Text = HelperFunctions.ToDateText((DateTime)row[field]);
			}
			for (int i=0;i<m_decimalFieldNames.Length;i++)
			{
				string field = m_decimalFieldNames[i];
				TextBox box = m_decimalTextBoxes[i];
				if (row.IsNull(field))
					box.Text = "";
				else
					box.Text = row[field].ToString();

			}
			UpdateMassControls();
			UpdateGrids();
			containerLbsEdt.Text = HelperFunctions.GetTotalContainerLbs(GetHeaderRow()).ToString();
			containerKgEdt.Text = HelperFunctions.GetTotalContainerKg(GetHeaderRow()).ToString();
			containerPercentEdt.Text = HelperFunctions.GetTotalContainerPercentage(GetHeaderRow());
			UpdateEnabled();
		}

		void UpdateGrids()
		{
			HelperFunctions.UpdateGrids(collapseCheck.Checked,m_emDataSet.POItemTbl,generalGrid,rateGrid,ackGrid);
			if (m_emDataSet.POItemTbl.Rows.Count ==0)
				return;
			int rowIndex = HelperFunctions.GetRowIndex(base.Position,generalGrid);
			generalGrid.Select(rowIndex);
			rateGrid.Select(rowIndex);
			ackGrid.Select(rowIndex);
			HelperFunctions.SetupItemContainers(m_emDataSet,GetHeaderRow(),containerGrid);
		}

		protected void Grid_CurCellChange(object sender, EventArgs e)
		{
			base.Position = HelperFunctions.GetPosition((DataGrid)sender);
		}


		bool m_enableWeightSelectedChanged = true;
		void UpdateMassControls()
		{
			m_enableWeightSelectedChanged = false;
			EMDataSet.POItemTblRow row = GetHeaderRow();
			bool isKg = true;
			if (!row.IsUMNull())
			{
				if (row.UM == "lbs")
					isKg = false;
			}
			m_kgBtn.Checked = isKg;
			m_lbsBtn.Checked = !isKg;
			m_enableWeightSelectedChanged = true;
		}
		private void OnWeightSelectedChanged(object sender, System.EventArgs e)
		{
			if (m_enableWeightSelectedChanged == false)
				return;

			SetUM();
			UpdateMassControls();
			UpdateEnabled();
		}
		
		public override DataRow CreateFreshRow() 
		{
			EMDataSet.POItemTblRow row = m_emDataSet.POItemTbl.NewPOItemTblRow();
			row.POID = m_poid;
			return row;
		}
		public override int AddNewRow(DataRow rowIn) 
		{
			EMDataSet.POItemTblRow row = (EMDataSet.POItemTblRow)rowIn;
			row.POItemNumber = DataInterface.GetNextKeyNumber("tblPOItem2");
			short seqNumber;
			if (GetRecordCount() == 0)
				seqNumber = 0;
			else
				seqNumber = (short)GetHeaderTable()[GetRecordCount() - 1]["SeqNumber"];
			row.SeqNumber = (short)(seqNumber + 1);

			if (!GetPOHeaderRow().IsVendNameNull())
			{
				string companyName = GetPOHeaderRow().VendName;
				EMDataSet.ItemTblRow itemRow = ChooseItem.CreateNewRow(companyName);
				if (itemRow!=null)
				{
					row.ItemName = itemRow.ItemName;
					if (!itemRow.IsItemDescNull())
						row.ItemDesc = itemRow.ItemDesc;
				}
			}


			m_emDataSet.POItemTbl.AddPOItemTblRow(row);
			return GetRecordCount() - 1;
		}
		public override OleDbConnection GetConnection() 
		{
			return emConnection;
		}
		public override DataSet GetDataSet() 
		{
			return m_emDataSet;
		}
		public override DataView GetHeaderTable()
		{
			return DataInterface.ToView(m_emDataSet.POItemTbl);
		}
		
		string[] m_fieldNames;
		TextBox[] m_textBoxes;
		int m_poid;
		string[] m_dateFieldNames;
		TextBox[] m_dateTextBoxes;
		Button[] m_dateBtns;

		string[] m_decimalFieldNames;
		TextBox[] m_decimalTextBoxes;
		public POItem(int poid)
		{
			m_poid = poid;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_textBoxes = new TextBox[]{nameEdt,lengthEdt,sizeEdt,IACEdt,heatEdt,m_commentEdt,
										m_descriptionEdt,millConfirmEdt};
			m_fieldNames = new string[]{"ItemName","Length","SizeOfItem","ItemAccessCode","Heat",
										"Comments","ItemDesc","MillConfirmNumber"};

			m_dateFieldNames = new string[]{"DateRequired","AcknowledgeDate","MillShipDate"};
			m_dateTextBoxes = new TextBox[]{dateReqEdt,acknowledgeEdt,millShipDateEdt};
			m_dateBtns = new Button[]{dateReqBtn,ackDateBtn,shipDateBtn};

			m_decimalFieldNames = new string[]{"Qty","MetricQty","CustRate","MetricCustRate",
												"CustAmount"};
			m_decimalTextBoxes = new TextBox[]{lbsEdt,kgEdt,rateEdt,metricRateEdt,m_custAmountEdt};
			DataInterface.InitializeAdapterWithParameter(poHeaderAdapter,"POID");
			DataInterface.InitializeAdapterWithParameter(poItemAdapter,"POID");

			DataInterface.InitializeAdapterWithParameter(containerAdapter,"ContID");
			DataInterface.InitializeAdapterWithParameter(contPOItemAdapter,"POItemNumber");
			poNumberEdt.Text = m_poid.ToString();

			generalGrid.CurrentCellChanged += new EventHandler(Grid_CurCellChange);
			rateGrid.CurrentCellChanged += new EventHandler(Grid_CurCellChange);
			ackGrid.CurrentCellChanged += new EventHandler(Grid_CurCellChange);
			
			Refresh();
		}
		private void OnDateBtnClick(object sender, System.EventArgs e)
		{
			// first find the control
			int i=0;
			for (i=0;i<m_dateBtns.Length;i++)
			{
				if (sender == m_dateBtns[i])
				{
					break;
				}
			}
			Debug.Assert(i!= m_dateBtns.Length);
			string fieldName = m_dateFieldNames[i];
			TextBox box = m_dateTextBoxes[i];
			Debug.Assert(i!=m_dateBtns.Length);
			DataRow row = GetHeaderRow();
			System.DateTime dateTime = System.DateTime.Today;
			if (!row.IsNull(fieldName))
				dateTime = (DateTime)row[fieldName];
			if (DialogResult.OK == DateTimeSelector.RequestTime(ref dateTime))
				box.Text = HelperFunctions.ToDateText(dateTime);
		
		}


		private void upBtn_Click(object sender, System.EventArgs e)
		{
			if (IsEditing)
				return;
			Refresh();
			if (Position == 0)
				return;
			DataView view = GetHeaderTable();
			EMDataSet.POItemTblRow row1 = (EMDataSet.POItemTblRow)view[Position].Row;
			EMDataSet.POItemTblRow row2 = (EMDataSet.POItemTblRow)view[Position-1].Row;
			short tmp = row1.SeqNumber;
			row1.SeqNumber = row2.SeqNumber;
			row2.SeqNumber = tmp;
			Commit();
			Refresh();
		}

		private void downBtn_Click(object sender, System.EventArgs e)
		{
			if (IsEditing)
				return;
			Refresh();
			if (Position == GetRecordCount() -1)
				return;
			DataView view = GetHeaderTable();
			EMDataSet.POItemTblRow row1 = (EMDataSet.POItemTblRow)view[Position].Row;
			EMDataSet.POItemTblRow row2 = (EMDataSet.POItemTblRow)view[Position+1].Row;
			short tmp = row1.SeqNumber;
			row1.SeqNumber = row2.SeqNumber;
			row2.SeqNumber = tmp;
			Commit();
			Refresh();
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
			this.label1 = new System.Windows.Forms.Label();
			this.poNumberEdt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.upBtn = new System.Windows.Forms.Button();
			this.downBtn = new System.Windows.Forms.Button();
			this.nameEdt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lengthEdt = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.sizeEdt = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.IACEdt = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dateReqEdt = new System.Windows.Forms.TextBox();
			this.dateReqBtn = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.heatEdt = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.m_custAmountEdt = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.metricRateEdt = new System.Windows.Forms.TextBox();
			this.rateEdt = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.m_kgBtn = new System.Windows.Forms.RadioButton();
			this.m_lbsBtn = new System.Windows.Forms.RadioButton();
			this.kgEdt = new System.Windows.Forms.TextBox();
			this.lbsEdt = new System.Windows.Forms.TextBox();
			this.CommentsTabPage = new System.Windows.Forms.TabPage();
			this.m_commentEdt = new System.Windows.Forms.TextBox();
			this.DescriptionTabPage = new System.Windows.Forms.TabPage();
			this.m_descriptionEdt = new System.Windows.Forms.TextBox();
			this.AcknowledgePage = new System.Windows.Forms.TabPage();
			this.shipDateBtn = new System.Windows.Forms.Button();
			this.millShipDateEdt = new System.Windows.Forms.TextBox();
			this.Static1 = new System.Windows.Forms.Label();
			this.millConfirmEdt = new System.Windows.Forms.TextBox();
			this.staticText = new System.Windows.Forms.Label();
			this.ackDateBtn = new System.Windows.Forms.Button();
			this.acknowledgeEdt = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.containerKgEdt = new System.Windows.Forms.TextBox();
			this.containerPercentEdt = new System.Windows.Forms.TextBox();
			this.containerLbsEdt = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.gotoContainerBtn = new System.Windows.Forms.Button();
			this.containerGrid = new System.Windows.Forms.DataGrid();
			this.poHeaderAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.poItemAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.m_emDataSet = new EM.EMDataSet();
			this.page3 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.generalGrid = new System.Windows.Forms.DataGrid();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.rateGrid = new System.Windows.Forms.DataGrid();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.ackGrid = new System.Windows.Forms.DataGrid();
			this.collapseCheck = new System.Windows.Forms.CheckBox();
			this.contPOItemAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
			this.containerAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
			this.gotoPOBtn = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.CommentsTabPage.SuspendLayout();
			this.DescriptionTabPage.SuspendLayout();
			this.AcknowledgePage.SuspendLayout();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.containerGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_emDataSet)).BeginInit();
			this.page3.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.generalGrid)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rateGrid)).BeginInit();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ackGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "PONumber:";
			// 
			// poNumberEdt
			// 
			this.poNumberEdt.Location = new System.Drawing.Point(104, 16);
			this.poNumberEdt.Name = "poNumberEdt";
			this.poNumberEdt.ReadOnly = true;
			this.poNumberEdt.TabIndex = 1;
			this.poNumberEdt.Text = "m_poNumberEdt";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Items:";
			// 
			// upBtn
			// 
			this.upBtn.Location = new System.Drawing.Point(800, 96);
			this.upBtn.Name = "upBtn";
			this.upBtn.TabIndex = 5;
			this.upBtn.Text = "Move up";
			this.upBtn.Click += new System.EventHandler(this.upBtn_Click);
			// 
			// downBtn
			// 
			this.downBtn.Location = new System.Drawing.Point(800, 128);
			this.downBtn.Name = "downBtn";
			this.downBtn.TabIndex = 6;
			this.downBtn.Text = "Move Down";
			this.downBtn.Click += new System.EventHandler(this.downBtn_Click);
			// 
			// nameEdt
			// 
			this.nameEdt.Location = new System.Drawing.Point(96, 8);
			this.nameEdt.Name = "nameEdt";
			this.nameEdt.TabIndex = 1;
			this.nameEdt.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Item Name:";
			// 
			// lengthEdt
			// 
			this.lengthEdt.Location = new System.Drawing.Point(96, 32);
			this.lengthEdt.Name = "lengthEdt";
			this.lengthEdt.TabIndex = 3;
			this.lengthEdt.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Length:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Size:";
			// 
			// sizeEdt
			// 
			this.sizeEdt.Location = new System.Drawing.Point(96, 56);
			this.sizeEdt.Name = "sizeEdt";
			this.sizeEdt.TabIndex = 5;
			this.sizeEdt.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "IAC:";
			// 
			// IACEdt
			// 
			this.IACEdt.Location = new System.Drawing.Point(96, 80);
			this.IACEdt.Name = "IACEdt";
			this.IACEdt.TabIndex = 7;
			this.IACEdt.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 23);
			this.label7.TabIndex = 8;
			this.label7.Text = "Date Req:";
			// 
			// dateReqEdt
			// 
			this.dateReqEdt.Location = new System.Drawing.Point(96, 104);
			this.dateReqEdt.Name = "dateReqEdt";
			this.dateReqEdt.TabIndex = 9;
			this.dateReqEdt.Text = "";
			// 
			// dateReqBtn
			// 
			this.dateReqBtn.Location = new System.Drawing.Point(200, 104);
			this.dateReqBtn.Name = "dateReqBtn";
			this.dateReqBtn.Size = new System.Drawing.Size(24, 23);
			this.dateReqBtn.TabIndex = 10;
			this.dateReqBtn.Text = "...";
			this.dateReqBtn.Click += new System.EventHandler(this.OnDateBtnClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.CommentsTabPage);
			this.tabControl1.Controls.Add(this.DescriptionTabPage);
			this.tabControl1.Controls.Add(this.AcknowledgePage);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Location = new System.Drawing.Point(8, 376);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(640, 224);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.heatEdt);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.dateReqBtn);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.dateReqEdt);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.IACEdt);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.nameEdt);
			this.tabPage1.Controls.Add(this.sizeEdt);
			this.tabPage1.Controls.Add(this.lengthEdt);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(632, 198);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			// 
			// heatEdt
			// 
			this.heatEdt.Location = new System.Drawing.Point(96, 136);
			this.heatEdt.Name = "heatEdt";
			this.heatEdt.TabIndex = 12;
			this.heatEdt.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 136);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 23);
			this.label8.TabIndex = 11;
			this.label8.Text = "Heat:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.m_custAmountEdt);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.metricRateEdt);
			this.tabPage2.Controls.Add(this.rateEdt);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.m_kgBtn);
			this.tabPage2.Controls.Add(this.m_lbsBtn);
			this.tabPage2.Controls.Add(this.kgEdt);
			this.tabPage2.Controls.Add(this.lbsEdt);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(632, 198);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Text = "Rate";
			// 
			// m_custAmountEdt
			// 
			this.m_custAmountEdt.Location = new System.Drawing.Point(72, 80);
			this.m_custAmountEdt.Name = "m_custAmountEdt";
			this.m_custAmountEdt.TabIndex = 9;
			this.m_custAmountEdt.Text = "custAmount";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 80);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 23);
			this.label11.TabIndex = 8;
			this.label11.Text = "Total:";
			// 
			// metricRateEdt
			// 
			this.metricRateEdt.Location = new System.Drawing.Point(296, 32);
			this.metricRateEdt.Name = "metricRateEdt";
			this.metricRateEdt.TabIndex = 7;
			this.metricRateEdt.Text = "textBox2";
			// 
			// rateEdt
			// 
			this.rateEdt.Location = new System.Drawing.Point(296, 8);
			this.rateEdt.Name = "rateEdt";
			this.rateEdt.TabIndex = 3;
			this.rateEdt.Text = "textBox1";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(216, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 16);
			this.label10.TabIndex = 6;
			this.label10.Text = "Rate $/kg";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(216, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 2;
			this.label9.Text = "Rate $/lb";
			// 
			// m_kgBtn
			// 
			this.m_kgBtn.Location = new System.Drawing.Point(8, 32);
			this.m_kgBtn.Name = "m_kgBtn";
			this.m_kgBtn.Size = new System.Drawing.Size(88, 24);
			this.m_kgBtn.TabIndex = 4;
			this.m_kgBtn.Text = "Weight(kg)";
			this.m_kgBtn.CheckedChanged += new System.EventHandler(this.OnWeightSelectedChanged);
			// 
			// m_lbsBtn
			// 
			this.m_lbsBtn.Location = new System.Drawing.Point(8, 8);
			this.m_lbsBtn.Name = "m_lbsBtn";
			this.m_lbsBtn.Size = new System.Drawing.Size(88, 24);
			this.m_lbsBtn.TabIndex = 0;
			this.m_lbsBtn.Text = "Weight(lbs)";
			this.m_lbsBtn.CheckedChanged += new System.EventHandler(this.OnWeightSelectedChanged);
			// 
			// kgEdt
			// 
			this.kgEdt.Location = new System.Drawing.Point(104, 32);
			this.kgEdt.Name = "kgEdt";
			this.kgEdt.TabIndex = 5;
			this.kgEdt.Text = "";
			// 
			// lbsEdt
			// 
			this.lbsEdt.Location = new System.Drawing.Point(104, 8);
			this.lbsEdt.Name = "lbsEdt";
			this.lbsEdt.TabIndex = 1;
			this.lbsEdt.Text = "";
			// 
			// CommentsTabPage
			// 
			this.CommentsTabPage.Controls.Add(this.m_commentEdt);
			this.CommentsTabPage.Location = new System.Drawing.Point(4, 22);
			this.CommentsTabPage.Name = "CommentsTabPage";
			this.CommentsTabPage.Size = new System.Drawing.Size(632, 198);
			this.CommentsTabPage.TabIndex = 1;
			this.CommentsTabPage.Text = "Comments";
			// 
			// m_commentEdt
			// 
			this.m_commentEdt.Location = new System.Drawing.Point(0, 0);
			this.m_commentEdt.Multiline = true;
			this.m_commentEdt.Name = "m_commentEdt";
			this.m_commentEdt.Size = new System.Drawing.Size(504, 168);
			this.m_commentEdt.TabIndex = 0;
			this.m_commentEdt.Text = "textBox1";
			// 
			// DescriptionTabPage
			// 
			this.DescriptionTabPage.Controls.Add(this.m_descriptionEdt);
			this.DescriptionTabPage.Location = new System.Drawing.Point(4, 22);
			this.DescriptionTabPage.Name = "DescriptionTabPage";
			this.DescriptionTabPage.Size = new System.Drawing.Size(632, 198);
			this.DescriptionTabPage.TabIndex = 3;
			this.DescriptionTabPage.Text = "Description";
			// 
			// m_descriptionEdt
			// 
			this.m_descriptionEdt.Location = new System.Drawing.Point(0, 0);
			this.m_descriptionEdt.Multiline = true;
			this.m_descriptionEdt.Name = "m_descriptionEdt";
			this.m_descriptionEdt.Size = new System.Drawing.Size(488, 176);
			this.m_descriptionEdt.TabIndex = 0;
			this.m_descriptionEdt.Text = "textBox1";
			// 
			// AcknowledgePage
			// 
			this.AcknowledgePage.Controls.Add(this.shipDateBtn);
			this.AcknowledgePage.Controls.Add(this.millShipDateEdt);
			this.AcknowledgePage.Controls.Add(this.Static1);
			this.AcknowledgePage.Controls.Add(this.millConfirmEdt);
			this.AcknowledgePage.Controls.Add(this.staticText);
			this.AcknowledgePage.Controls.Add(this.ackDateBtn);
			this.AcknowledgePage.Controls.Add(this.acknowledgeEdt);
			this.AcknowledgePage.Controls.Add(this.label12);
			this.AcknowledgePage.Location = new System.Drawing.Point(4, 22);
			this.AcknowledgePage.Name = "AcknowledgePage";
			this.AcknowledgePage.Size = new System.Drawing.Size(632, 198);
			this.AcknowledgePage.TabIndex = 4;
			this.AcknowledgePage.Text = "Acknowledge";
			// 
			// shipDateBtn
			// 
			this.shipDateBtn.Location = new System.Drawing.Point(224, 56);
			this.shipDateBtn.Name = "shipDateBtn";
			this.shipDateBtn.Size = new System.Drawing.Size(24, 23);
			this.shipDateBtn.TabIndex = 7;
			this.shipDateBtn.Text = "...";
			this.shipDateBtn.Click += new System.EventHandler(this.OnDateBtnClick);
			// 
			// millShipDateEdt
			// 
			this.millShipDateEdt.Location = new System.Drawing.Point(120, 56);
			this.millShipDateEdt.Name = "millShipDateEdt";
			this.millShipDateEdt.TabIndex = 6;
			this.millShipDateEdt.Text = "textBox1";
			// 
			// Static1
			// 
			this.Static1.Location = new System.Drawing.Point(8, 56);
			this.Static1.Name = "Static1";
			this.Static1.Size = new System.Drawing.Size(104, 23);
			this.Static1.TabIndex = 5;
			this.Static1.Text = "Mill Ship Date:";
			// 
			// millConfirmEdt
			// 
			this.millConfirmEdt.Location = new System.Drawing.Point(120, 32);
			this.millConfirmEdt.Name = "millConfirmEdt";
			this.millConfirmEdt.TabIndex = 4;
			this.millConfirmEdt.Text = "textBox1";
			// 
			// staticText
			// 
			this.staticText.Location = new System.Drawing.Point(8, 32);
			this.staticText.Name = "staticText";
			this.staticText.Size = new System.Drawing.Size(104, 23);
			this.staticText.TabIndex = 3;
			this.staticText.Text = "Mill Confirm No.:";
			// 
			// ackDateBtn
			// 
			this.ackDateBtn.Location = new System.Drawing.Point(224, 8);
			this.ackDateBtn.Name = "ackDateBtn";
			this.ackDateBtn.Size = new System.Drawing.Size(24, 23);
			this.ackDateBtn.TabIndex = 2;
			this.ackDateBtn.Text = "...";
			this.ackDateBtn.Click += new System.EventHandler(this.OnDateBtnClick);
			// 
			// acknowledgeEdt
			// 
			this.acknowledgeEdt.Location = new System.Drawing.Point(120, 8);
			this.acknowledgeEdt.Name = "acknowledgeEdt";
			this.acknowledgeEdt.TabIndex = 1;
			this.acknowledgeEdt.Text = "textBox1";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(104, 23);
			this.label12.TabIndex = 0;
			this.label12.Text = "Acknowledge Date:";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.containerKgEdt);
			this.tabPage6.Controls.Add(this.containerPercentEdt);
			this.tabPage6.Controls.Add(this.containerLbsEdt);
			this.tabPage6.Controls.Add(this.label15);
			this.tabPage6.Controls.Add(this.label14);
			this.tabPage6.Controls.Add(this.label13);
			this.tabPage6.Controls.Add(this.gotoContainerBtn);
			this.tabPage6.Controls.Add(this.containerGrid);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(632, 198);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Containers";
			// 
			// containerKgEdt
			// 
			this.containerKgEdt.Location = new System.Drawing.Point(88, 168);
			this.containerKgEdt.Name = "containerKgEdt";
			this.containerKgEdt.ReadOnly = true;
			this.containerKgEdt.Size = new System.Drawing.Size(56, 20);
			this.containerKgEdt.TabIndex = 7;
			this.containerKgEdt.Text = "textBox3";
			// 
			// containerPercentEdt
			// 
			this.containerPercentEdt.Location = new System.Drawing.Point(312, 136);
			this.containerPercentEdt.Name = "containerPercentEdt";
			this.containerPercentEdt.ReadOnly = true;
			this.containerPercentEdt.TabIndex = 4;
			this.containerPercentEdt.Text = "textBox2";
			// 
			// containerLbsEdt
			// 
			this.containerLbsEdt.Location = new System.Drawing.Point(88, 136);
			this.containerLbsEdt.Name = "containerLbsEdt";
			this.containerLbsEdt.ReadOnly = true;
			this.containerLbsEdt.Size = new System.Drawing.Size(56, 20);
			this.containerLbsEdt.TabIndex = 2;
			this.containerLbsEdt.Text = "textBox1";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(240, 136);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(80, 32);
			this.label15.TabIndex = 3;
			this.label15.Text = "Percent in containers:";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 168);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 16);
			this.label14.TabIndex = 6;
			this.label14.Text = "Container(kg)";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 136);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 32);
			this.label13.TabIndex = 1;
			this.label13.Text = "Container(lbs)";
			// 
			// gotoContainerBtn
			// 
			this.gotoContainerBtn.Location = new System.Drawing.Point(520, 136);
			this.gotoContainerBtn.Name = "gotoContainerBtn";
			this.gotoContainerBtn.Size = new System.Drawing.Size(104, 23);
			this.gotoContainerBtn.TabIndex = 5;
			this.gotoContainerBtn.Text = "Go to container:";
			this.gotoContainerBtn.Click += new System.EventHandler(this.gotoContainerBtn_Click);
			// 
			// containerGrid
			// 
			this.containerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.containerGrid.DataMember = "";
			this.containerGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.containerGrid.Location = new System.Drawing.Point(0, 0);
			this.containerGrid.Name = "containerGrid";
			this.containerGrid.Size = new System.Drawing.Size(632, 120);
			this.containerGrid.TabIndex = 0;
			// 
			// poHeaderAdapter
			// 
			this.poHeaderAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.poHeaderAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tblPOHeader2", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
																																																					  new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																					  new System.Data.Common.DataColumnMapping("ExchangeRate", "ExchangeRate"),
																																																					  new System.Data.Common.DataColumnMapping("FOB", "FOB"),
																																																					  new System.Data.Common.DataColumnMapping("OtherTotal", "OtherTotal"),
																																																					  new System.Data.Common.DataColumnMapping("PODate", "PODate"),
																																																					  new System.Data.Common.DataColumnMapping("POID", "POID"),
																																																					  new System.Data.Common.DataColumnMapping("PONumber", "PONumber"),
																																																					  new System.Data.Common.DataColumnMapping("ShipCode", "ShipCode"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToAddress", "ShipToAddress"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToCompany", "ShipToCompany"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToContact", "ShipToContact"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToCountry", "ShipToCountry"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToEMail", "ShipToEMail"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToFax", "ShipToFax"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToLocationName", "ShipToLocationName"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToName", "ShipToName"),
																																																					  new System.Data.Common.DataColumnMapping("ShipToPhone", "ShipToPhone"),
																																																					  new System.Data.Common.DataColumnMapping("Status", "Status"),
																																																					  new System.Data.Common.DataColumnMapping("Terms", "Terms"),
																																																					  new System.Data.Common.DataColumnMapping("USTotal", "USTotal"),
																																																					  new System.Data.Common.DataColumnMapping("VendAddress", "VendAddress"),
																																																					  new System.Data.Common.DataColumnMapping("VendCompany", "VendCompany"),
																																																					  new System.Data.Common.DataColumnMapping("VendContact", "VendContact"),
																																																					  new System.Data.Common.DataColumnMapping("VendCountry", "VendCountry"),
																																																					  new System.Data.Common.DataColumnMapping("VendEMail", "VendEMail"),
																																																					  new System.Data.Common.DataColumnMapping("VendFax", "VendFax"),
																																																					  new System.Data.Common.DataColumnMapping("VendLocationName", "VendLocationName"),
																																																					  new System.Data.Common.DataColumnMapping("VendName", "VendName"),
																																																					  new System.Data.Common.DataColumnMapping("VendPhone", "VendPhone")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT CancelDate, Comments, ExchangeRate, FOB, OtherTotal, PODate, POID, PONumber, ShipCode, ShipToAddress, ShipToCompany, ShipToContact, ShipToCountry, ShipToEMail, ShipToFax, ShipToLocationName, ShipToName, ShipToPhone, Status, Terms, USTotal, VendAddress, VendCompany, VendContact, VendCountry, VendEMail, VendFax, VendLocationName, VendName, VendPhone FROM tblPOHeader2 WHERE (POID = ?)";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""m:\em_prog_2002.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=ReadWrite;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// poItemAdapter
			// 
			this.poItemAdapter.DeleteCommand = this.oleDbDeleteCommand2;
			this.poItemAdapter.InsertCommand = this.oleDbInsertCommand2;
			this.poItemAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.poItemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "tblPOItem2", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("AcknowledgeDate", "AcknowledgeDate"),
																																																				  new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
																																																				  new System.Data.Common.DataColumnMapping("CommAmount", "CommAmount"),
																																																				  new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																				  new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
																																																				  new System.Data.Common.DataColumnMapping("CustAmount", "CustAmount"),
																																																				  new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
																																																				  new System.Data.Common.DataColumnMapping("DateRequired", "DateRequired"),
																																																				  new System.Data.Common.DataColumnMapping("Heat", "Heat"),
																																																				  new System.Data.Common.DataColumnMapping("ItemAccessCode", "ItemAccessCode"),
																																																				  new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
																																																				  new System.Data.Common.DataColumnMapping("ItemName", "ItemName"),
																																																				  new System.Data.Common.DataColumnMapping("Length", "Length"),
																																																				  new System.Data.Common.DataColumnMapping("MetricCustRate", "MetricCustRate"),
																																																				  new System.Data.Common.DataColumnMapping("MetricQty", "MetricQty"),
																																																				  new System.Data.Common.DataColumnMapping("MillConfirmNumber", "MillConfirmNumber"),
																																																				  new System.Data.Common.DataColumnMapping("MillShipDate", "MillShipDate"),
																																																				  new System.Data.Common.DataColumnMapping("POID", "POID"),
																																																				  new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
																																																				  new System.Data.Common.DataColumnMapping("Qty", "Qty"),
																																																				  new System.Data.Common.DataColumnMapping("SeqNumber", "SeqNumber"),
																																																				  new System.Data.Common.DataColumnMapping("SizeOfItem", "SizeOfItem"),
																																																				  new System.Data.Common.DataColumnMapping("UM", "UM")})});
			this.poItemAdapter.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM tblPOItem2 WHERE (POItemNumber = ?) AND (AcknowledgeDate = ? OR ? IS NULL AND AcknowledgeDate IS NULL) AND (CancelDate = ? OR ? IS NULL AND CancelDate IS NULL) AND (CommAmount = ? OR ? IS NULL AND CommAmount IS NULL) AND (CommRate = ? OR ? IS NULL AND CommRate IS NULL) AND (CustAmount = ? OR ? IS NULL AND CustAmount IS NULL) AND (CustRate = ? OR ? IS NULL AND CustRate IS NULL) AND (DateRequired = ? OR ? IS NULL AND DateRequired IS NULL) AND (Heat = ? OR ? IS NULL AND Heat IS NULL) AND (ItemAccessCode = ? OR ? IS NULL AND ItemAccessCode IS NULL) AND (ItemName = ?) AND (Length = ? OR ? IS NULL AND Length IS NULL) AND (MetricCustRate = ? OR ? IS NULL AND MetricCustRate IS NULL) AND (MetricQty = ? OR ? IS NULL AND MetricQty IS NULL) AND (MillConfirmNumber = ? OR ? IS NULL AND MillConfirmNumber IS NULL) AND (MillShipDate = ? OR ? IS NULL AND MillShipDate IS NULL) AND (POID = ? OR ? IS NULL AND POID IS NULL) AND (Qty = ? OR ? IS NULL AND Qty IS NULL) AND (SeqNumber = ? OR ? IS NULL AND SeqNumber IS NULL) AND (SizeOfItem = ? OR ? IS NULL AND SizeOfItem IS NULL) AND (UM = ? OR ? IS NULL AND UM IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.emConnection;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CancelDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommAmount1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommRate1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustAmount1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustRate1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateRequired1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricCustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricCustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricCustRate1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricCustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricQty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricQty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillConfirmNumber", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillConfirmNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillConfirmNumber1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillConfirmNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillShipDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Qty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Qty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Qty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SeqNumber1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SizeOfItem1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UM", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UM1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UM", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = @"INSERT INTO tblPOItem2(AcknowledgeDate, CancelDate, CommAmount, Comments, CommRate, CustAmount, CustRate, DateRequired, Heat, ItemAccessCode, ItemDesc, ItemName, Length, MetricCustRate, MetricQty, MillConfirmNumber, MillShipDate, POID, POItemNumber, Qty, SeqNumber, SizeOfItem, UM) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.emConnection;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.DBDate, 0, "AcknowledgeDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.DBDate, 0, "CancelDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 0, "Comments"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.DBDate, 0, "DateRequired"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 30, "Heat"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 30, "ItemAccessCode"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemDesc"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 30, "ItemName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 20, "Length"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MetricCustRate", System.Data.OleDb.OleDbType.Currency, 0, "MetricCustRate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MetricQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricQty"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MillConfirmNumber", System.Data.OleDb.OleDbType.VarWChar, 20, "MillConfirmNumber"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.DBDate, 0, "MillShipDate"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.SmallInt, 0, "SeqNumber"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 20, "SizeOfItem"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 10, "UM"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT AcknowledgeDate, CancelDate, CommAmount, Comments, CommRate, CustAmount, CustRate, DateRequired, Heat, ItemAccessCode, ItemDesc, ItemName, Length, MetricCustRate, MetricQty, MillConfirmNumber, MillShipDate, POID, POItemNumber, Qty, SeqNumber, SizeOfItem, UM FROM tblPOItem2 WHERE (POID = ?) ORDER BY SeqNumber";
			this.oleDbSelectCommand2.Connection = this.emConnection;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE tblPOItem2 SET AcknowledgeDate = ?, CancelDate = ?, CommAmount = ?, Comments = ?, CommRate = ?, CustAmount = ?, CustRate = ?, DateRequired = ?, Heat = ?, ItemAccessCode = ?, ItemDesc = ?, ItemName = ?, Length = ?, MetricCustRate = ?, MetricQty = ?, MillConfirmNumber = ?, MillShipDate = ?, POID = ?, POItemNumber = ?, Qty = ?, SeqNumber = ?, SizeOfItem = ?, UM = ? WHERE (POItemNumber = ?) AND (AcknowledgeDate = ? OR ? IS NULL AND AcknowledgeDate IS NULL) AND (CancelDate = ? OR ? IS NULL AND CancelDate IS NULL) AND (CommAmount = ? OR ? IS NULL AND CommAmount IS NULL) AND (CommRate = ? OR ? IS NULL AND CommRate IS NULL) AND (CustAmount = ? OR ? IS NULL AND CustAmount IS NULL) AND (CustRate = ? OR ? IS NULL AND CustRate IS NULL) AND (DateRequired = ? OR ? IS NULL AND DateRequired IS NULL) AND (Heat = ? OR ? IS NULL AND Heat IS NULL) AND (ItemAccessCode = ? OR ? IS NULL AND ItemAccessCode IS NULL) AND (ItemName = ?) AND (Length = ? OR ? IS NULL AND Length IS NULL) AND (MetricCustRate = ? OR ? IS NULL AND MetricCustRate IS NULL) AND (MetricQty = ? OR ? IS NULL AND MetricQty IS NULL) AND (MillConfirmNumber = ? OR ? IS NULL AND MillConfirmNumber IS NULL) AND (MillShipDate = ? OR ? IS NULL AND MillShipDate IS NULL) AND (POID = ? OR ? IS NULL AND POID IS NULL) AND (Qty = ? OR ? IS NULL AND Qty IS NULL) AND (SeqNumber = ? OR ? IS NULL AND SeqNumber IS NULL) AND (SizeOfItem = ? OR ? IS NULL AND SizeOfItem IS NULL) AND (UM = ? OR ? IS NULL AND UM IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.emConnection;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.DBDate, 0, "AcknowledgeDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.DBDate, 0, "CancelDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 0, "Comments"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.DBDate, 0, "DateRequired"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 30, "Heat"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 30, "ItemAccessCode"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemDesc"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 30, "ItemName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 20, "Length"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MetricCustRate", System.Data.OleDb.OleDbType.Currency, 0, "MetricCustRate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MetricQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricQty"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MillConfirmNumber", System.Data.OleDb.OleDbType.VarWChar, 20, "MillConfirmNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.DBDate, 0, "MillShipDate"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.SmallInt, 0, "SeqNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 20, "SizeOfItem"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 10, "UM"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CancelDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommAmount1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CommRate1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustAmount1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CustRate1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_DateRequired1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Length1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Length", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricCustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricCustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricCustRate1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricCustRate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricQty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricQty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillConfirmNumber", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillConfirmNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillConfirmNumber1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillConfirmNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MillShipDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POID1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Qty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Qty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Qty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SeqNumber1", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SizeOfItem1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UM", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_UM1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UM", System.Data.DataRowVersion.Original, null));
			// 
			// m_emDataSet
			// 
			this.m_emDataSet.DataSetName = "EMDataSet";
			this.m_emDataSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// page3
			// 
			this.page3.Controls.Add(this.tabPage3);
			this.page3.Controls.Add(this.tabPage4);
			this.page3.Controls.Add(this.tabPage5);
			this.page3.Location = new System.Drawing.Point(0, 64);
			this.page3.Name = "page3";
			this.page3.SelectedIndex = 0;
			this.page3.Size = new System.Drawing.Size(792, 288);
			this.page3.TabIndex = 4;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.generalGrid);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(784, 262);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "General";
			// 
			// generalGrid
			// 
			this.generalGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.generalGrid.DataMember = "";
			this.generalGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.generalGrid.Location = new System.Drawing.Point(0, 0);
			this.generalGrid.Name = "generalGrid";
			this.generalGrid.Size = new System.Drawing.Size(792, 264);
			this.generalGrid.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.rateGrid);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(784, 262);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Rate";
			// 
			// rateGrid
			// 
			this.rateGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.rateGrid.DataMember = "";
			this.rateGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.rateGrid.Location = new System.Drawing.Point(0, 0);
			this.rateGrid.Name = "rateGrid";
			this.rateGrid.Size = new System.Drawing.Size(784, 264);
			this.rateGrid.TabIndex = 0;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.ackGrid);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(784, 262);
			this.tabPage5.TabIndex = 2;
			this.tabPage5.Text = "Acknowledgement";
			// 
			// ackGrid
			// 
			this.ackGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.ackGrid.DataMember = "";
			this.ackGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.ackGrid.Location = new System.Drawing.Point(0, 0);
			this.ackGrid.Name = "ackGrid";
			this.ackGrid.Size = new System.Drawing.Size(784, 264);
			this.ackGrid.TabIndex = 0;
			// 
			// collapseCheck
			// 
			this.collapseCheck.Location = new System.Drawing.Point(656, 360);
			this.collapseCheck.Name = "collapseCheck";
			this.collapseCheck.Size = new System.Drawing.Size(136, 32);
			this.collapseCheck.TabIndex = 7;
			this.collapseCheck.Text = "Collapse multi-line descriptions:";
			this.collapseCheck.CheckedChanged += new System.EventHandler(this.OnExpandChanged);
			// 
			// contPOItemAdapter
			// 
			this.contPOItemAdapter.DeleteCommand = this.oleDbDeleteCommand3;
			this.contPOItemAdapter.InsertCommand = this.oleDbInsertCommand3;
			this.contPOItemAdapter.SelectCommand = this.oleDbSelectCommand3;
			this.contPOItemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "tblContPOItem2", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("ContID", "ContID"),
																																																						  new System.Data.Common.DataColumnMapping("MetricShipQty", "MetricShipQty"),
																																																						  new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
																																																						  new System.Data.Common.DataColumnMapping("ShipQty", "ShipQty")})});
			this.contPOItemAdapter.UpdateCommand = this.oleDbUpdateCommand3;
			// 
			// oleDbDeleteCommand3
			// 
			this.oleDbDeleteCommand3.CommandText = "DELETE FROM tblContPOItem2 WHERE (ContID = ?) AND (POItemNumber = ?) AND (MetricS" +
				"hipQty = ? OR ? IS NULL AND MetricShipQty IS NULL) AND (ShipQty = ? OR ? IS NULL" +
				" AND ShipQty IS NULL)";
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricShipQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand3
			// 
			this.oleDbInsertCommand3.CommandText = "INSERT INTO tblContPOItem2(ContID, MetricShipQty, POItemNumber, ShipQty) VALUES (" +
				"?, ?, ?, ?)";
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbInsertCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipQty", System.Data.OleDb.OleDbType.Currency, 0, "ShipQty"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT ContID, MetricShipQty, POItemNumber, ShipQty FROM tblContPOItem2 WHERE (PO" +
				"ItemNumber = ?)";
			this.oleDbSelectCommand3.Connection = this.emConnection;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			// 
			// oleDbUpdateCommand3
			// 
			this.oleDbUpdateCommand3.CommandText = "UPDATE tblContPOItem2 SET ContID = ?, MetricShipQty = ?, POItemNumber = ?, ShipQt" +
				"y = ? WHERE (ContID = ?) AND (POItemNumber = ?) AND (MetricShipQty = ? OR ? IS N" +
				"ULL AND MetricShipQty IS NULL) AND (ShipQty = ? OR ? IS NULL AND ShipQty IS NULL" +
				")";
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipQty", System.Data.OleDb.OleDbType.Currency, 0, "ShipQty"));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MetricShipQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			// 
			// containerAdapter
			// 
			this.containerAdapter.DeleteCommand = this.oleDbDeleteCommand4;
			this.containerAdapter.InsertCommand = this.oleDbInsertCommand4;
			this.containerAdapter.SelectCommand = this.oleDbSelectCommand4;
			this.containerAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "tblContainer", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("ContID", "ContID"),
																																																					   new System.Data.Common.DataColumnMapping("ContNumber", "ContNumber"),
																																																					   new System.Data.Common.DataColumnMapping("ETA", "ETA"),
																																																					   new System.Data.Common.DataColumnMapping("ShipDate", "ShipDate")})});
			this.containerAdapter.UpdateCommand = this.oleDbUpdateCommand4;
			// 
			// oleDbDeleteCommand4
			// 
			this.oleDbDeleteCommand4.CommandText = "DELETE FROM tblContainer WHERE (ContID = ?) AND (ContNumber = ?) AND (ETA = ? OR " +
				"? IS NULL AND ETA IS NULL) AND (ShipDate = ? OR ? IS NULL AND ShipDate IS NULL)";
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand4
			// 
			this.oleDbInsertCommand4.CommandText = "INSERT INTO tblContainer(ContID, ContNumber, ETA, ShipDate) VALUES (?, ?, ?, ?)";
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, "ContNumber"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.DBDate, 0, "ETA"));
			this.oleDbInsertCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, "ShipDate"));
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = "SELECT ContID, ContNumber, ETA, ShipDate FROM tblContainer WHERE (ContID = ?)";
			this.oleDbSelectCommand4.Connection = this.emConnection;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			// 
			// oleDbUpdateCommand4
			// 
			this.oleDbUpdateCommand4.CommandText = "UPDATE tblContainer SET ContID = ?, ContNumber = ?, ETA = ?, ShipDate = ? WHERE (" +
				"ContID = ?) AND (ContNumber = ?) AND (ETA = ? OR ? IS NULL AND ETA IS NULL) AND " +
				"(ShipDate = ? OR ? IS NULL AND ShipDate IS NULL)";
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, "ContNumber"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.DBDate, 0, "ETA"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, "ShipDate"));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			// 
			// gotoPOBtn
			// 
			this.gotoPOBtn.Location = new System.Drawing.Point(224, 16);
			this.gotoPOBtn.Name = "gotoPOBtn";
			this.gotoPOBtn.Size = new System.Drawing.Size(88, 23);
			this.gotoPOBtn.TabIndex = 2;
			this.gotoPOBtn.Text = "Open PO...";
			this.gotoPOBtn.Click += new System.EventHandler(this.gotoPOBtn_Click);
			// 
			// POItem
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(896, 605);
			this.Controls.Add(this.gotoPOBtn);
			this.Controls.Add(this.collapseCheck);
			this.Controls.Add(this.page3);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.downBtn);
			this.Controls.Add(this.upBtn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.poNumberEdt);
			this.Controls.Add(this.label1);
			this.Name = "POItem";
			this.Text = "Items";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.CommentsTabPage.ResumeLayout(false);
			this.DescriptionTabPage.ResumeLayout(false);
			this.AcknowledgePage.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.containerGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_emDataSet)).EndInit();
			this.page3.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.generalGrid)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rateGrid)).EndInit();
			this.tabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ackGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void addBtn_Click(object sender, System.EventArgs e)
		{
			base.OnAdd();
		}

		private void deleteBtn_Click(object sender, System.EventArgs e)
		{
			base.OnDelete();
		}

		private void updateBtn_Click(object sender, System.EventArgs e)
		{
			base.OnUpdate();
		}

		private void cancelBtn_Click(object sender, System.EventArgs e)
		{
			base.OnCancel();
		}

		private void OnExpandChanged(object sender, System.EventArgs e)
		{
			UpdateGrids();
		}

		private void gotoPOBtn_Click(object sender, System.EventArgs e)
		{
			MainWindow main = (MainWindow)this.MdiParent;
			main.CreatePOForm(GetHeaderRow().POID);
		}

		private void gotoContainerBtn_Click(object sender, System.EventArgs e)
		{
			if (m_emDataSet.ContPOItemTbl.Rows.Count == 0)
				return;
			DataGridCell cell = containerGrid.CurrentCell;
			EMDataSet.ContPOItemTblRow row = 
				(EMDataSet.ContPOItemTblRow)m_emDataSet.ContPOItemTbl.Rows[cell.RowNumber];
			MainWindow win = (MainWindow)this.MdiParent;
			win.CreateContainerForm(row.ContID);
		}
	}
}
*/