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
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace EM
{
	/// <summary>
	/// Summary description for ContainerItem.
	/// </summary>
	public class ContainerItem : KeyBasedForm,
		HelperFunctions.DataGridClientInterface,
		IAllowComboBoxUpdates
	{
		private System.Windows.Forms.Label label1;
		private AutoCompleteTextBox containerNumberEdt;
		private System.Windows.Forms.Button choosePOBtn;
		private AutoCompleteTextBox poNumberEdt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox poGridLocation;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage bundlesTab;
		private System.Windows.Forms.TabPage weightTab;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private AutoCompleteTextBox shipDateEdt;
		private AutoCompleteTextBox etaEdt;
		private System.Windows.Forms.Button shipDateBtn;
		private System.Windows.Forms.Button etaBtn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button removeBtn;
		private System.Windows.Forms.Button moveUpBtn;
		private System.Windows.Forms.Button moveDownBtn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private AutoCompleteTextBox totalLbsEdt;
		private AutoCompleteTextBox totalKgEdt;
		private System.Windows.Forms.Button refreshPOBtn;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Panel bottomPanel;
		private System.Windows.Forms.Button printToExcelBtn;
		private System.Windows.Forms.Label label8;
		private EM.AutoCompleteComboBox customerLocationCombo;
		private EM.AutoCompleteComboBox customerNameCombo;
		private System.Windows.Forms.ComboBox statusCombo;
		private System.Windows.Forms.Button gotoPOBtn;
		private System.Windows.Forms.Button gotoBOLBtn;
		private System.Windows.Forms.Label label9;
		private EM.AutoCompleteTextBox attnEdt;
		private EM.AutoCompleteTextBox ccEdt;
		private System.Windows.Forms.CheckBox closingInfoForContainerBttn;
		private AutoCompleteTextBox contDeliveryDateEdt;
		private AutoCompleteTextBox contTerminalEdt;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private AutoCompleteTextBox contProofEdt;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button contDeliveryDateBtn;
        private Button printITLBtn;
        private TabControl topTab;
        private TabPage poTabPage;
        private TabPage commentPage;
        private Panel poPanel;
        private AutoCompleteTextBox commentsTxt;
        private Button closeContainerButton;
        private Button releaseDateBtn;
        private AutoCompleteTextBox releaseDateEdt;
        private Label label16;
        private Button changeBtn;
        private Button balanceReportBtn;
        private TabPage invoiceTab;
		private System.Windows.Forms.Panel fillPanel;

		public override void OnFind()
		{
			try
			{
				if (!TryToCommit())
					return;
				int contNumber = Chooser.GetContainer(AdapterHelper.Connection);
                base.CurrentKey = contNumber;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				DataInterface.MakeSureRefreshGoesThrough(this);
			}
		}
		public override bool OnUpdateFind()
		{
			return true;
		}

		public override bool IsValid()
		{
			string[] requiredFields = {"ContNumber","ShipDate","ETA"};
			string[] friendlyTitles = {"Container #","Ship Date","ETA"};
			string message;
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			if (HelperFunctions.AreRequiredFieldsFilledIn(row,requiredFields,friendlyTitles,out
							message))
				return true;
			return false;
		}

		public string[] DecimalFieldsToBeMonitored()
		{
			return new string[]{"EnglishShipQty","MetricShipQty"};
		}
		public void NewGridTotal(string fieldName,decimal val)
		{
			if (fieldName == "MetricShipQty")
			{
				totalKgEdt.Text = val.ToString("N0");
			}
			if (fieldName == "EnglishShipQty")
			{
				totalLbsEdt.Text = val.ToString("N0");
			}
		}
		public void OnGridItemClicked(int item)
		{ 
			// This is just here to implement the IDataGridInterface
		}

		EMDataSet.ContBundleTblRow[] GetAllDetailRows()
		{
            EMDataSet.ContBundleTblRow[] rows = GetHeaderRow().GetContBundleTblRows();
			return rows;
		}


		// Interface for the derived type
		public override void ClearDataSet()
		{
			using (new TurnOffConstraints(emDataSet))
			{
				emDataSet.BOLItemTbl.Clear();
				emDataSet.BOLTbl.Clear();
				emDataSet.ContBundleTbl.Clear();
				emDataSet.ContainerTbl.Clear();
				emDataSet.POItemTbl.Clear();
				emDataSet.POHeaderTbl.Clear();
			}
		}
		public override bool IsDeleteAllowed() 
		{
			if (GetAllDetailRows().Length != 0)
			{
				MessageBox.Show("Delete of the container is not allowed " + 
					"unless all items in the container have been deleted",
					"Can't delete");
				return false;
			}
			return true;
		}
		public override bool IsChanged()
		{
			DataTable header = GetHeaderTable().GetChanges();
			DataTable child = emDataSet.ContBundleTbl.GetChanges();
			if (header != null)
				return true;
			if (child != null)
				return true;
			DataTable locTable = emDataSet.LocationTbl.GetChanges();
			if (locTable != null)
				return true;
			return false;
		}

		public override DataTable GetHeaderTable()
		{
			return emDataSet.ContainerTbl;
		}
		public override void InitializeDataRow(DataRow newRow)
		{
			EMDataSet.ContainerTblRow row = (EMDataSet.ContainerTblRow)newRow;
			row.ContNumber = "";
		}
		public override string GetTableName() 
		{
			return "tblContainer";
		}
		public override void FillTablesFromDatabase() 
		{
			emDataSet.Clear();
			FormSupport.FillContainerFromDatabase(emDataSet,CurrentKey);
			AdapterHelper.FillCompanyFromType(emDataSet.CompanyTbl,"Customer");
			AdapterHelper.FillCountry(emDataSet);
			foreach (EMDataSet.CompanyTblRow row in emDataSet.CompanyTbl)
			{
				AdapterHelper.FillLocations(emDataSet,row.CompID);
			}
		}
		public override void CommitTablesToDatabase() 
		{

            
            
            OleDbConnection emConnection = AdapterHelper.Connection;
			using (new OpenConnection(IsWrite.Yes,emConnection))
			{
                EMDataSet.ContainerTblRow row = GetHeaderRow();
                if (DataInterface.IsRowAlive(row) && !row.IsCustomerIDNull())
                {
                    EMDataSet checkForDuplicates = new EMDataSet();
                    checkForDuplicates.EnforceConstraints = false;
                    AdapterHelper.FillContainersWithSameName(checkForDuplicates.ContainerTbl, 
                        row.ContNumber, row.CustomerID);
                    foreach (EMDataSet.ContainerTblRow possibleDuplicateRow in checkForDuplicates.ContainerTbl)
                    {
                        if (possibleDuplicateRow.ContID == row.ContID)
                            continue;
                        throw new Exception("Duplicate container detected. You may not save two containers " +
                                            "with the same name and customer\n"+
                                            "The duplicate container is \n" +
                                            "Container: "  + row.ContNumber +  
                                            "\nCustomer: " + emDataSet.CompanyTbl.FindByCompID(row.CustomerID).CompName);
                    }
                }
                EMDataSet tempDataSet = new EMDataSet();
				tempDataSet.EnforceConstraints = false;
				AdapterHelper.FillContBundle(tempDataSet,base.CurrentKey);
				DataInterface.CheckForChanges("ContainerBundleID","BundleSeqNumber",
					"Bundle #",
					"BundleSeqNumber",tempDataSet.ContBundleTbl,emDataSet.ContBundleTbl);
				AdapterHelper.CommitLocationChanges(emDataSet);
				AdapterHelper.CommitContainerChanges(emDataSet);
			}
		}
		public override OleDbConnection GetConnection() {return AdapterHelper.Connection;}
		public override string[] GetSortOrder() {return new string[]{"Status","ShipDate","CustomerID","ContNumber"};}
		// Internal helper functions

		public new EMDataSet.ContainerTblRow GetHeaderRow()
		{
			return (EMDataSet.ContainerTblRow)base.GetHeaderRow();
		}


		EMDataSet emDataSet = new EMDataSet();
		EMDataSet poDataSet = new EMDataSet();
		private System.Windows.Forms.Button addBtn;
		QuickGrid poGrid = new QuickGrid();
		QuickGrid bundleGrid = new QuickGrid();
		QuickGrid weightGrid = new QuickGrid();
        QuickGrid invoiceTotalGrid = new QuickGrid();
		static decimal GetWeightFromRow(EMDataSet.ContBundleTblRow row,
			bool isMetric)
		{
			decimal weight = 0;
			if (isMetric)
			{
				if (!row.IsMetricShipQtyNull())
					weight += row.MetricShipQty;
			}
			else
			{
				if (!row.IsEnglishShipQtyNull())
					weight += row.EnglishShipQty;
			}
			return weight;
		}

		static decimal GetTotalContainerWeightExcludeCurrentContainer(
			EMDataSet tempContainerDataSet,
			int currentContainer,int poItemNumber,bool isMetric)
		{
			tempContainerDataSet.Clear();
			tempContainerDataSet.EnforceConstraints = false;
			AdapterHelper.FillContBundleFromPOItemNumber(tempContainerDataSet,poItemNumber);
			decimal weight=0;
			foreach(EMDataSet.ContBundleTblRow row in tempContainerDataSet.ContBundleTbl.Rows)
			{
				if (row.ContID == currentContainer)
					continue;
				weight += GetWeightFromRow(row,isMetric);
			}
			return weight;
		}
		decimal GetCurrentContainerWeightForItem(int poItemNumber,bool isMetric)
		{
			decimal weight = 0;
			foreach (EMDataSet.ContBundleTblRow row in this.emDataSet.ContBundleTbl.Rows)
			{
                if (!DataInterface.IsRowAlive(row))
                    continue;
				if (row.ContID != base.CurrentKey)
				{
					Debug.Assert(false);
					continue;
				}
				if (row.POItemNumber != poItemNumber)
					continue;
				weight += GetWeightFromRow(row,isMetric);
			}
			return weight;
		}
		decimal GetTotalContainerWeightForItem(
			EMDataSet tempContainerDataSet,
			int poItemNumber,bool isMetric)
		{
			using (new OpenConnection(IsWrite.No,AdapterHelper.Connection))
			{
				decimal weightOutsideContainer = 
					GetTotalContainerWeightExcludeCurrentContainer(tempContainerDataSet,
					base.CurrentKey,poItemNumber,isMetric);
				decimal weightInsideContainer = GetCurrentContainerWeightForItem(poItemNumber,isMetric);
				return weightOutsideContainer + weightInsideContainer;
			}
		}

		private void refreshPOBtn_Click(object sender, System.EventArgs e)
		{
			FromGrid();
			string po = poNumberEdt.Text;
			po = "'" + po + "'";
			int poid = DataInterface.GetKeyFromField(AdapterHelper.Connection,
				"tblPOHeader2","POID","PONumber",
				po);
			ViewPO(poid);
		}

		object GetFieldValue(DataRow sourceRowIn,bool isMetric,string fieldName)
		{
			EMDataSet.POItemTblRow sourceRow = (EMDataSet.POItemTblRow)sourceRowIn;
			if (fieldName == "TotalContainerWeight")
			{
				EMDataSet tempContainerDataSet = new EMDataSet();
				return this.GetTotalContainerWeightForItem(tempContainerDataSet,sourceRow.POItemNumber,isMetric);
			}
			if (fieldName == "ItemName")
			{
				return HelperFunctions.GetItemName(sourceRow);
			}
			return sourceRow[fieldName];
		}

		void ViewPO(int poid)
		{
			using (new OpenConnection(IsWrite.No,AdapterHelper.Connection))
			using (new TurnOffConstraints(poDataSet))
			{
				poDataSet.POItemTbl.Clear();
				poDataSet.POHeaderTbl.Clear();
				AdapterHelper.FillPOHeader(poDataSet,poid);
				AdapterHelper.FillPOItem(poDataSet,poid);
				AdapterHelper.FillOutConstraints(poDataSet);
			}
            poNumberEdt.Text = poDataSet.POHeaderTbl.FindByPOID(poid).PONumber;
			bool isMetric = DataInterface.IsMetric(poDataSet.POItemTbl);
			FormSupport.GridWizard(poGrid,poDataSet.POItemTbl,isMetric,IsNewAllowed.No,IsReadOnly.Yes,
				"SeqNumber",new FormSupport.GetFieldDelegate(GetFieldValue),null,
				"ItemName","ItemDesc","Length","SizeOfItem",
				"Qty","TotalContainerWeight","CancelDate",
				"POItemNumber","SeqNumber");
            poGrid.SetCancelColumn("CancelDate");
		}

		private void choosePOBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				EMDataSet.ContainerTblRow row = GetHeaderRow();
				int compID;
				int locID;
				if (row.IsCustomerIDNull() || row.IsCustomerLocationIDNull())
				{
					compID = -1;
					locID = -1;
				}
				else 
				{
					compID = row.CustomerID;
					locID = row.CustomerLocationID;
				}
				int po = Chooser.GetPO(AdapterHelper.Connection,compID,locID);
				if (po == 0)
					poNumberEdt.Text = "";
				else
				{
					/*poNumberEdt.Text = po;
					po = "'" + po + "'";
					int poid = DataInterface.GetKeyFromField(AdapterHelper.Connection,
						"tblPOHeader2","POID","PONumber",
						po);*/
					ViewPO(po);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		AutoCompleteTextBox[] m_locTextBoxes;
		string[] m_locFieldNames;
		public ContainerItem(int contID,int contBundleID)
		{
			InitializeComponent();
			m_textBoxes = new AutoCompleteTextBox[]{containerNumberEdt,commentsTxt};
			m_textFieldNames = new string[]{"ContNumber","Comments"};
			m_dateBoxes = new AutoCompleteTextBox[]{shipDateEdt,etaEdt,releaseDateEdt};
			m_dateFieldNames = new string[]{"ShipDate","ETA","ReleaseDate"};
			m_dateButtons = new Button[]{shipDateBtn,etaBtn,releaseDateBtn};

			m_locTextBoxes = new AutoCompleteTextBox[]{attnEdt,ccEdt};
			m_locFieldNames=  new string[]{"ATTNString","CCString"};

			base.m_currentKey = contID;

            SetupQuickGrid.DoIt(poGrid, poGridLocation, poTabPage, AnchorStyles.Top | AnchorStyles.Left);
			SetupQuickGrid.DoIt(bundleGrid,this.bundlesTab);
			SetupQuickGrid.DoIt(weightGrid,this.weightTab);
            SetupQuickGrid.DoIt(invoiceTotalGrid, this.invoiceTab);

			Refresh();
            if (contBundleID != 0)
            {
                EMDataSet.ContBundleTblRow bundleRow = 
                    emDataSet.ContBundleTbl.FindByContainerBundleID(contBundleID);
                bundleGrid.SetNewFocus(bundleRow.BundleSeqNumber - 1, 0);

            }

		}

        void AverageIn(DataRow row, string fieldName, decimal newValue,decimal newQty)
        {
            decimal currentValue = (decimal)row[fieldName];
            decimal currentQty = (decimal)row["Qty"];
            currentValue = currentValue * currentQty + newValue * newQty;
            currentValue = currentValue/(currentQty + newQty);
            row[fieldName] = currentValue;
        }
        void AddIn(DataRow row, string fieldName, decimal value)
        {
            decimal currentValue = (decimal)row[fieldName];
            currentValue += value;
            row[fieldName] = currentValue;
        }

        public void UpdateInvoiceGrid()
        {
            DataTable invoiceTable = new DataTable();

            invoiceTable.Clear();
            invoiceTable.Columns.Clear();
            invoiceTable.Columns.Add("InvoiceNumber", typeof(string));
            invoiceTable.Columns.Add("Qty", typeof(decimal));
            invoiceTable.Columns.Add("CustRate", typeof(decimal));
            invoiceTable.Columns.Add("CustAmount", typeof(decimal));
            invoiceTable.Columns.Add("BundleAlloySurcharge", typeof(decimal));
            invoiceTable.Columns.Add("BundleScrapSurcharge", typeof(decimal));
            invoiceTable.Columns.Add("BundleSurcharge", typeof(decimal));
            invoiceTable.Columns.Add("TotalSurcharge", typeof(decimal));
            invoiceTable.Columns.Add("TotalWithSurcharge", typeof(decimal));
            invoiceTable.Columns.Add("Count", typeof(int));   
            foreach (EMDataSet.ContBundleTblRow bundleRow in GetHeaderRow().GetContBundleTblRows())
            {
                if (bundleRow.IsInvoiceNumberNull())
                    continue;
                EMDataSet.POItemTblRow itemRow = bundleRow.POItemTblRow;
                string millInvoice = bundleRow.InvoiceNumber;
                DataRow[] rows = invoiceTable.Select("InvoiceNumber = '" + millInvoice + "'");
                DataRow invoiceRow = null;
                decimal weight = bundleRow.IsEnglishShipQtyNull() ? 0 : bundleRow.EnglishShipQty;
                decimal rate = itemRow.IsCustRateNull() ? 0 : itemRow.CustRate;
                decimal total = weight * rate;
                decimal alloySurcharge = bundleRow.IsBundleAlloySurchargeNull() ? 0 : bundleRow.BundleAlloySurcharge;
                decimal scrapSurchage = bundleRow.IsBundleScrapSurchargeNull() ? 0 : bundleRow.BundleScrapSurcharge;
                decimal surchargeRate = alloySurcharge + scrapSurchage;
                decimal surchargeTotal = (surchargeRate / 100) * weight;
                 
                if (rows == null || rows.Length == 0)
                {
                    invoiceRow = invoiceTable.NewRow();
                    invoiceRow["Count"] = 1;
                    invoiceRow["InvoiceNumber"] = millInvoice;
                    invoiceRow["Qty"] = weight;
                    invoiceRow["CustRate"] = rate;
                    invoiceRow["CustAmount"] = total;
                    invoiceRow["BundleAlloySurcharge"] = alloySurcharge;
                    invoiceRow["BundleScrapSurcharge"] = scrapSurchage;
                    invoiceRow["BundleSurcharge"] = surchargeRate;
                    invoiceRow["TotalSurcharge"] = surchargeTotal;
                    invoiceRow["TotalWithSurcharge"] = surchargeTotal + total;
                    invoiceTable.Rows.Add(invoiceRow);
                    continue;
                }
                invoiceRow = rows[0];
                System.Diagnostics.Debug.Assert(rows.Length == 1);
                AddIn(invoiceRow, "Qty", weight);
                AverageIn(invoiceRow, "CustRate", rate,weight);
                AddIn(invoiceRow, "CustAmount", total);
                AverageIn(invoiceRow, "BundleAlloySurcharge", alloySurcharge, weight);
                AverageIn(invoiceRow, "BundleScrapSurcharge", scrapSurchage, weight);
                AverageIn(invoiceRow, "BundleSurcharge", surchargeRate,weight);
                AddIn(invoiceRow,"TotalSurcharge",surchargeTotal);
                AddIn(invoiceRow,"TotalWithSurcharge",surchargeTotal + total);
            }
            DataView invoiceView = new DataView(invoiceTable, "", "InvoiceNumber", DataViewRowState.CurrentRows);
            HelperFunctions.UpdateGrid(invoiceView,invoiceTotalGrid, null, false, IsNewAllowed.No,
                IsReadOnly.Yes, "InvoiceNumber", "Qty", "CustRate", "CustAmount", 
                "BundleAlloySurcharge","BundleScrapSurcharge","BundleSurcharge", "TotalSurcharge", "TotalWithSurcharge");
	
	
        }
		public void UpdateGrids()
		{
			decimal totalLbs;
			decimal totalKgs;

			FormSupport.SetupContainerGrids(emDataSet,base.CurrentKey,
				bundleGrid,weightGrid,this,IsReadOnly.No,
				out totalLbs,out totalKgs,
				new FormSupport.GetBillOfLadingNumberFunc(
				FormSupport.DefaultGetBillOfLadingNumber));
            UpdateInvoiceGrid();
            NewGridTotal("EnglishShipQty",totalLbs);
			NewGridTotal("MetricShipQty",totalKgs);
		}
		public AutoCompleteTextBox[] m_textBoxes;
		public string[] m_textFieldNames;
		public AutoCompleteTextBox[] m_dateBoxes;
		public Button[] m_dateButtons;
		public string[] m_dateFieldNames;

		public bool AllowComboBoxUpdates
		{
			get {return allowComboBoxUpdates;}
			set {allowComboBoxUpdates = value;}
		}
		bool allowComboBoxUpdates = true;

		EMDataSet.LocationTblDataTable CreateSubsetLocationTable(int compID)
		{
			EMDataSet.LocationTblDataTable locationCopy = (EMDataSet.LocationTblDataTable)
				emDataSet.LocationTbl.Copy();
			foreach (EMDataSet.LocationTblRow locationRow in locationCopy)
			{
				if (locationRow.CompID != compID)
					locationRow.Delete();
			}
			locationCopy.AcceptChanges();
			return locationCopy;
		}

		public void UpdateLocationCombo()
		{
			customerLocationCombo.Enabled = !IsEmptyTable();
			customerLocationCombo.Items.Clear();
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			if (row.IsCustomerIDNull())
				return;

			EMDataSet.LocationTblRow locationRow = null;
			EMDataSet.LocationTblDataTable locationCopy = CreateSubsetLocationTable(row.CustomerID);
			if (!row.IsCustomerLocationIDNull())
			{
				string query = "LocID = " + row.CustomerLocationID;
				EMDataSet.LocationTblRow[] locationRows = (EMDataSet.LocationTblRow[])locationCopy.Select(query);
				
				Debug.Assert(locationRows.Length < 2);
				if	(locationRows.Length == 1)
					locationRow = locationRows[0];
			}
			DataInterface.UpdateComboBox(locationCopy.DefaultView,"LocID","LocName",customerLocationCombo,locationRow);
		}
		private void OnCustomerChanged(object sender, System.EventArgs e)
		{
			if (!allowComboBoxUpdates)
				return;
			object o = customerNameCombo.SelectedItem;
			TaggedItem tagged = (TaggedItem)o;
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			row.CustomerID = tagged.key;
			UpdateLocationCombo();
		}
		private void OnLocationChanged(object sender, System.EventArgs e)
		{
			if (!allowComboBoxUpdates)
				return;
			object o = customerLocationCombo.SelectedItem;
			TaggedItem tagged = (TaggedItem)o;
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			row.CustomerLocationID = tagged.key;
			UpdateLocationInfo();
		}
		public override void UpdateControls()
		{
			using (new StopComboBoxUpdates(this))
			{
				EMDataSet.ContainerTblRow row = GetHeaderRow();
				FormSupport.UpdateTextControls(m_textBoxes,m_textFieldNames,row,IsEmptyTable());
				FormSupport.UpdateDateControls(m_dateBoxes,m_dateButtons,m_dateFieldNames,row,
					IsEmptyTable());

				if (row.IsStatusNull())
				{
					row.Status = "Open";
				}

                closeContainerButton.Enabled = row.Status != "Closed";
				statusCombo.Enabled = !IsEmptyTable();
				addBtn.Enabled = !IsEmptyTable();
				statusCombo.Text = row.Status;
				customerNameCombo.Enabled = !IsEmptyTable();
				customerNameCombo.Items.Clear();
				EMDataSet.CompanyTblRow compRow= null;
				if (!row.IsCustomerIDNull())
				{
					string query = "CompID = " + row.CustomerID;
					EMDataSet.CompanyTblRow[] compRows = (EMDataSet.CompanyTblRow[])emDataSet.CompanyTbl.Select(query);
				
					Debug.Assert(compRows.Length < 2);
					compRow = null;
					if (compRows.Length == 1)
						compRow = compRows[0];
				}
				DataInterface.UpdateComboBox(emDataSet.CompanyTbl.DefaultView,"CompID","CompName",customerNameCombo,compRow);
				UpdateLocationCombo();
				UpdateGrids();
				UpdateLocationInfo();
				UpdateContainerClosingInfo();
                if (GetHeaderRow().RowState == DataRowState.Added)
                
                    containerNumberEdt.ReadOnly = false;
                else
                    containerNumberEdt.ReadOnly = true;
                changeBtn.Enabled = containerNumberEdt.ReadOnly;
                if (!row.IsCommentsNull() && row.Comments != "")
                {
                    commentPage.Text = "Comments (not empty)";
                }
                else
                    commentPage.Text = "Comments (empty)";

			}
		}

		bool turnOffCheckUpdates = false;
		void UpdateContainerClosingInfo()
		{

			EMDataSet.ContainerTblRow row= GetHeaderRow();
			bool enabled = !row.IsApplyClosingToEntireContainerNull()
						 && row.ApplyClosingToEntireContainer!=0;
			turnOffCheckUpdates = true;
			try
			{
				closingInfoForContainerBttn.Checked = enabled;
			}
			finally
			{
				turnOffCheckUpdates = false;
			}
			Control[] controls = {contDeliveryDateEdt,contDeliveryDateBtn,contTerminalEdt,contProofEdt};
			AutoCompleteTextBox[] boxes = {contDeliveryDateEdt,contTerminalEdt,contProofEdt};
			if (!enabled)
				for (int i=0;i<boxes.Length;i++)
				{
					boxes[i].Text = "";
				}

			for (int i=0;i<controls.Length;i++)
			{
				controls[i].Enabled = enabled;
			}
			if (!enabled)
				return;
			// If enabled... then get the first bundle
			if (row.IsContainerPickupDateNull())
				contDeliveryDateEdt.Text = "";
			else 
				contDeliveryDateEdt.Text = HelperFunctions.ToDateText(row.ContainerPickupDate);
			if (row.IsContainerPickupTerminalNull())
				contTerminalEdt.Text = "";
			else 
				contTerminalEdt.Text = row.ContainerPickupTerminal;
			if (row.IsContainerProofOfDeliveryNull())
				contProofEdt.Text = "";
			else
				contProofEdt.Text = row.ContainerProofOfDelivery;
		}
		private void contDeliveryDateBtn_Click(object sender, System.EventArgs e)
		{
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			DateTime dateTime;
			if (row.IsContainerPickupDateNull())
				dateTime = System.DateTime.Today;
			else
				dateTime = row.ContainerPickupDate;
			if (DialogResult.OK == DateTimeSelector.RequestTime(ref dateTime))
			{
				contDeliveryDateEdt.Text = HelperFunctions.ToDateText(dateTime);
			}
		}
		private void OnContainerClosingChanged(object sender, System.EventArgs e)
		{
			if (turnOffCheckUpdates)
				return;
			FromControls();
			UpdateControls();
		}
		private void FromContainerClose()
		{
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			row.ApplyClosingToEntireContainer = closingInfoForContainerBttn.Checked?1:0;
			row["ContainerPickupDate"] = HelperFunctions.FromDateText(contDeliveryDateEdt);
			row.ContainerPickupTerminal = contTerminalEdt.Text;
			row.ContainerProofOfDelivery = contProofEdt.Text;
		}

		void UpdateLocationInfo()
		{
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			int locID = 0; 
			EMDataSet.LocationTblRow locRow = null;
			if (!row.IsCustomerLocationIDNull())
			{
				locID = row.CustomerLocationID;
				locRow = emDataSet.LocationTbl.FindByLocID(locID);
			}
			for (int i=0;i<this.m_locFieldNames.Length;i++)
			{
				string field = m_locFieldNames[i];
				TextBox box = this.m_locTextBoxes[i];
				if (locRow == null ||
					locRow.IsNull(field))
				{
					box.Text = "";
				}
				else
					box.Text = (string)locRow[field];
			}
		}
		void FromLocationInfo()
		{
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			if (row.IsCustomerLocationIDNull())
				return; // no need to save the location specific info
			int locID = row.CustomerLocationID;
			EMDataSet.LocationTblRow locRow = emDataSet.LocationTbl.FindByLocID(locID);
			for (int i=0;i<this.m_locFieldNames.Length;i++)
			{
				string field = m_locFieldNames[i];
				TextBox box = m_locTextBoxes[i];
				locRow[field] = box.Text;
			}
		}

		void FromGrid()
		{
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			bool doExtraRowsExist = row.IsApplyClosingToEntireContainerNull() ||
				row.ApplyClosingToEntireContainer==0;
			DataTable itemTable = bundleGrid.GetTable();
			foreach (DataRow sourceRow in itemTable.Rows)
			{
				int contID = (int)sourceRow["ContainerBundleID"];
				EMDataSet.ContBundleTblRow targetRow = emDataSet.
					ContBundleTbl.FindByContainerBundleID(contID);
				targetRow["MetricShipQty"] = sourceRow["MetricShipQty"];
				targetRow["EnglishShipQty"] = sourceRow["EnglishShipQty"];
				targetRow["Heat"] = sourceRow["Heat"];
				targetRow["InvoiceNumber"] = sourceRow["InvoiceNumber"];
                targetRow["MillInvoiceDate"] = sourceRow["MillInvoiceDate"];
                targetRow["EMInvoiceNumber"] = sourceRow["EMInvoiceNumber"];
                targetRow["BundleAlloySurcharge"] = sourceRow["BundleAlloySurcharge"];
                targetRow["BundleScrapSurcharge"] = sourceRow["BundleScrapSurcharge"];
                targetRow["BayNumber"] = sourceRow["BayNumber"];
				if (doExtraRowsExist)
				{
					targetRow["PickupDate"] = sourceRow["PickupDate"];
					targetRow["PickupTerminal"] = sourceRow["PickupTerminal"];
					targetRow["ProofOfDelivery"] = sourceRow["ProofOfDelivery"];
				}
			}
			// This is here to cause the grid to lose focus of a
			// currently activated cell
			weightGrid.GetTable();
		}
		public override void FromControls()
		{
			FormSupport.FromTextControls(m_textBoxes,m_textFieldNames,GetHeaderRow());
			FormSupport.FromDateControls(m_dateBoxes,m_dateFieldNames,GetHeaderRow());
			GetHeaderRow().Status = statusCombo.Text;
			FromGrid();
			FromLocationInfo();
			FromContainerClose();
		}

		public int GetMaxBundle()
		{
			int maxBundle= 0;
			foreach (EMDataSet.ContBundleTblRow row in emDataSet.ContBundleTbl.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (maxBundle < row.BundleSeqNumber)
					maxBundle = row.BundleSeqNumber;
			}
			return maxBundle;
		}
		private void addBtn_Click(object sender, System.EventArgs e)
		{
			FromControls();
			try
			{
				int row_number = poGrid.GetCurrentIndex().row;
				if (row_number >= poDataSet.POItemTbl.Rows.Count)
					return;
				EMDataSet.POItemTblRow itemRow = HelperFunctions.GetRowFromSeqNumber(
					poDataSet.POItemTbl,row_number+1);
				if (itemRow.IsQtyNull())
				{
					MessageBox.Show("Item must have a quantity");
					return;
				}
				if (itemRow.IsItemIDNull())
				{
					MessageBox.Show("Item must have a name");
					return;
				}

				EMDataSet.ContBundleTblRow row = emDataSet.ContBundleTbl.NewContBundleTblRow();
				row.ContID = base.CurrentKey;
				row.POItemNumber = itemRow.POItemNumber;
                EMDataSet.POHeaderTblRow poHeaderRow = itemRow.POHeaderTblRow;
                bool dontApplyMillConfirmationToEntirePO =
                     (!poHeaderRow.IsMillConfirmationAppliesToEntirePONull() &&
                     poHeaderRow.MillConfirmationAppliesToEntirePO == 0);

                if (dontApplyMillConfirmationToEntirePO)
                    row["EMInvoiceNumber"] = !itemRow.IsInvoiceNumberNull() ?
                        itemRow["InvoiceNumber"] : poHeaderRow["InvoiceNumber"];
                else
                    row["EMInvoiceNumber"] = poHeaderRow["InvoiceNumber"];
                row.BundleSeqNumber = GetMaxBundle()+1;
				row.ContainerBundleID = DataInterface.GetNextKeyNumber("tblContBundle");
				using (new OpenConnection(EM.IsWrite.No,AdapterHelper.Connection))
				using (new TurnOffConstraints(emDataSet))
				{
					emDataSet.ContBundleTbl.AddContBundleTblRow(row);
					AdapterHelper.FillOutConstraints(emDataSet);
				}
                GetHeaderRow().MillID = itemRow.POHeaderTblRow.MillID;
				UpdateControls();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		
		private void OnDateLeave(object sender, System.EventArgs e)
		{
			FormSupport.OnDateLeave(sender,m_dateBoxes,m_dateFieldNames,GetHeaderRow());
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			if ((sender == shipDateEdt) && (etaEdt.Text == ""))
			{
				if (!row.IsShipDateNull())
				{
					DateTime etaDateTime = row.ShipDate.AddMonths(1);
					etaEdt.Text = HelperFunctions.ToDateText(etaDateTime);
				}
			}

		}
		
		
		private void OnDateBtn(object sender, System.EventArgs e)
		{
			// first find the control
			int i=0;
			for (i=0;i<m_dateButtons.Length;i++)
			{
				if (sender == m_dateButtons[i])
				{
					break;
				}
			}
			Debug.Assert(i!= m_dateButtons.Length);
			string fieldName = m_dateFieldNames[i];
			AutoCompleteTextBox box = m_dateBoxes[i];
			DateTime dateTime;
			if (DialogResult.OK == 
				FormSupport.OnDateBtn(sender,m_dateButtons,m_dateBoxes,
				m_dateFieldNames,GetHeaderRow(),
				out dateTime))
			{
				box.Text = HelperFunctions.ToDateText(dateTime);
				if ((sender == shipDateBtn) && (etaEdt.Text == ""))
				{
					dateTime = dateTime.AddMonths(1);
					etaEdt.Text = HelperFunctions.ToDateText(dateTime);
				}
			}
		}

		EMDataSet.ContBundleTblRow GetSelectedBundleRow()
		{
			if (tabControl.SelectedIndex != 0)
				throw new Exception("Can't get selected bundle when viewing by weight");
			
			int bundleNumber = bundleGrid.GetCurrentIndex().row+1;
			foreach (EMDataSet.ContBundleTblRow row in emDataSet.ContBundleTbl.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (row.BundleSeqNumber == bundleNumber)
					return row;
			}
			return null;
		
		}

		int GetSelectedBundleNumber()
		{
			EMDataSet.ContBundleTblRow row = GetSelectedBundleRow();
			if (row == null)
				return -1;
			return row.BundleSeqNumber;
		}
		void SetSelectedBundleNumber(int number)
		{
			if (tabControl.SelectedIndex != 0)
			{
				throw new Exception("Can't set a selected bundle number when viewing by weight");
			}
			bundleGrid.SetNewFocus(number-1,0);
		}

		EMDataSet.ContBundleTblRow GetRowFromBundle(int bundleNumber)
		{
			if (tabControl.SelectedIndex != 0)
				throw new Exception("Can't get selected bundle when viewing by weight");
			if (bundleNumber == -1)
				throw new Exception("BUG. -1 is not a valid index");
			foreach (EMDataSet.ContBundleTblRow row in emDataSet.ContBundleTbl.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (row.BundleSeqNumber == bundleNumber)
					return row;
			}
			throw new Exception("BUG: couldn't find bundle");
		}

		private void Swap(int bundleLeft,int bundleRight)
		{
			EMDataSet.ContBundleTblRow rowLeft = GetRowFromBundle(bundleLeft);
			EMDataSet.ContBundleTblRow rowRight = GetRowFromBundle(bundleRight);
			int tmpSeqNumber = rowLeft.BundleSeqNumber;
			rowLeft.BundleSeqNumber = rowRight.BundleSeqNumber;
			rowRight.BundleSeqNumber = tmpSeqNumber;
		}

		private void CheckForValidBundles()
		{
			ArrayList list = new ArrayList();
			foreach (EMDataSet.ContBundleTblRow row in emDataSet.ContBundleTbl.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				list.Add(row.BundleSeqNumber);
			}
			list.Sort();
			int [] intList = (int[])list.ToArray(typeof(int));
			for(int i=0;i<list.Count;i++)
			{
				if (intList[i] != i+1)
					throw new Exception("BUG: bad bundle sequences");
			}
		}
		private void removeBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				int bundleSequence = GetSelectedBundleNumber();
				if (bundleSequence == -1)
					return;
				FromGrid();
				EMDataSet.ContBundleTblRow row = GetRowFromBundle(bundleSequence);
				
				int emptyBundle = bundleSequence;
				for (;emptyBundle<GetMaxBundle();emptyBundle++)
				{
					Swap(emptyBundle,emptyBundle+1);
				}
				row.Delete();
				CheckForValidBundles();
				UpdateGrids();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}	
		
		private void moveUpBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				int bundleSequence = GetSelectedBundleNumber();
				if (bundleSequence == -1)
					return;
				if (bundleSequence == 1)
					return;
				FromGrid();
				Swap(bundleSequence-1,bundleSequence);
				CheckForValidBundles();
				UpdateGrids();
				SetSelectedBundleNumber(bundleSequence-1);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		

		private void moveDownBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				int bundleSequence = GetSelectedBundleNumber();
				if (bundleSequence == -1)
					return;
				if (bundleSequence == GetMaxBundle())
					return;
				FromGrid();
				Swap(bundleSequence,bundleSequence+1);
				CheckForValidBundles();
				UpdateGrids();
				SetSelectedBundleNumber(bundleSequence+1);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void gotoPOBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				EMDataSet.ContBundleTblRow row = GetSelectedBundleRow();
				if (row == null)
					return;
				MainWindow w = (MainWindow)this.Parent.Parent;
				w.CreatePOForm(row.POItemTblRow.POID,row.POItemNumber,GetHeaderRow().ContID,row.ContainerBundleID);

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}




		
		private void OnItemGridIndexChanged(object sender, System.EventArgs e)
		{
			int newIndex = tabControl.SelectedIndex;
			FromGrid();
			UpdateGrids();
			addBtn.Enabled = newIndex == 0;
			removeBtn.Enabled = newIndex == 0;
			moveUpBtn.Enabled = newIndex == 0;
			moveDownBtn.Enabled = newIndex == 0;
			gotoPOBtn.Enabled = newIndex == 0;
			gotoBOLBtn.Enabled = newIndex == 0;
		}

        private void changeBtn_Click(object sender, EventArgs e)
        {
            containerNumberEdt.ReadOnly = false;
            changeBtn.Enabled = false;
        }


        private void closeContainerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TryToCommit(true, MessageBoxButtons.OKCancel) == false)
                    return;
                string reason;
                bool isCompleted = DataInterface.IsCompleted(GetHeaderRow(), out reason);
                if (!isCompleted)
                {
                    throw new Exception(reason);
                }
                CloseContainer dlg = new CloseContainer(GetHeaderRow().ContID);
                dlg.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void printITLBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TryToCommit(true, MessageBoxButtons.OKCancel) == false)
                    return;
                EMDataSet.ContainerTblRow row = GetHeaderRow();
                if (row.IsCustomerLocationIDNull())
                    return;
                if (row.IsCustomerIDNull())
                    return;
                using (new NewExcelHelper(row)) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Refresh();
        }
		private void printToExcelBtn_Click(object sender, System.EventArgs e)
		{
			try 
			{
				if (TryToCommit(true,MessageBoxButtons.OKCancel) == false)
					return;
                EMDataSet.ContainerTblRow row = GetHeaderRow();
                if (row.IsCustomerLocationIDNull())
					return;
				if (row.IsCustomerIDNull())
					return;
				EMDataSet.CompanyTblRow customerRow = emDataSet.CompanyTbl.FindByCompID(row.CustomerID);
				EMDataSet.LocationTblRow locRow = emDataSet.LocationTbl.FindByLocID(row.CustomerLocationID);
				string excelFile = null;
				if (!locRow.IsExcelFileNull())
					excelFile = locRow.ExcelFile;
				if (excelFile == null || excelFile == "")
				{
					if (!locRow.CompanyTblRow.IsContainerExcelFileNull())
						excelFile = locRow.CompanyTblRow.ContainerExcelFile;
				}
				string filename = customerRow.CompName + " " + locRow.LocName + ".xls";
				
				ExcelHelper.PrintExcelTemplate(excelFile,emDataSet,GetHeaderRow(),totalKgEdt.Text,totalLbsEdt.Text,
					filename);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

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
            this.containerNumberEdt = new EM.AutoCompleteTextBox();
            this.choosePOBtn = new System.Windows.Forms.Button();
            this.poNumberEdt = new EM.AutoCompleteTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.poGridLocation = new System.Windows.Forms.PictureBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.bundlesTab = new System.Windows.Forms.TabPage();
            this.weightTab = new System.Windows.Forms.TabPage();
            this.invoiceTab = new System.Windows.Forms.TabPage();
            this.shipDateEdt = new EM.AutoCompleteTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.etaEdt = new EM.AutoCompleteTextBox();
            this.shipDateBtn = new System.Windows.Forms.Button();
            this.etaBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.attnEdt = new EM.AutoCompleteTextBox();
            this.removeBtn = new System.Windows.Forms.Button();
            this.moveUpBtn = new System.Windows.Forms.Button();
            this.moveDownBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.totalLbsEdt = new EM.AutoCompleteTextBox();
            this.totalKgEdt = new EM.AutoCompleteTextBox();
            this.refreshPOBtn = new System.Windows.Forms.Button();
            this.customerLocationCombo = new EM.AutoCompleteComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.customerNameCombo = new EM.AutoCompleteComboBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.balanceReportBtn = new System.Windows.Forms.Button();
            this.changeBtn = new System.Windows.Forms.Button();
            this.releaseDateBtn = new System.Windows.Forms.Button();
            this.releaseDateEdt = new EM.AutoCompleteTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.closeContainerButton = new System.Windows.Forms.Button();
            this.topTab = new System.Windows.Forms.TabControl();
            this.poTabPage = new System.Windows.Forms.TabPage();
            this.poPanel = new System.Windows.Forms.Panel();
            this.commentPage = new System.Windows.Forms.TabPage();
            this.commentsTxt = new EM.AutoCompleteTextBox();
            this.printITLBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contDeliveryDateBtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.contDeliveryDateEdt = new EM.AutoCompleteTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.closingInfoForContainerBttn = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.contTerminalEdt = new EM.AutoCompleteTextBox();
            this.contProofEdt = new EM.AutoCompleteTextBox();
            this.ccEdt = new EM.AutoCompleteTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.printToExcelBtn = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.gotoBOLBtn = new System.Windows.Forms.Button();
            this.gotoPOBtn = new System.Windows.Forms.Button();
            this.fillPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.poGridLocation)).BeginInit();
            this.tabControl.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.topTab.SuspendLayout();
            this.poTabPage.SuspendLayout();
            this.poPanel.SuspendLayout();
            this.commentPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.fillPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Container #";
            // 
            // containerNumberEdt
            // 
            this.containerNumberEdt.Location = new System.Drawing.Point(64, 8);
            this.containerNumberEdt.Name = "containerNumberEdt";
            this.containerNumberEdt.Size = new System.Drawing.Size(152, 20);
            this.containerNumberEdt.TabIndex = 1;
            // 
            // choosePOBtn
            // 
            this.choosePOBtn.Location = new System.Drawing.Point(376, 8);
            this.choosePOBtn.Name = "choosePOBtn";
            this.choosePOBtn.Size = new System.Drawing.Size(24, 23);
            this.choosePOBtn.TabIndex = 2;
            this.choosePOBtn.Text = "...";
            this.choosePOBtn.Click += new System.EventHandler(this.choosePOBtn_Click);
            // 
            // poNumberEdt
            // 
            this.poNumberEdt.Location = new System.Drawing.Point(48, 8);
            this.poNumberEdt.Name = "poNumberEdt";
            this.poNumberEdt.ReadOnly = true;
            this.poNumberEdt.Size = new System.Drawing.Size(320, 20);
            this.poNumberEdt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "PO #";
            // 
            // poGridLocation
            // 
            this.poGridLocation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.poGridLocation.Location = new System.Drawing.Point(3, 40);
            this.poGridLocation.Name = "poGridLocation";
            this.poGridLocation.Size = new System.Drawing.Size(834, 171);
            this.poGridLocation.TabIndex = 4;
            this.poGridLocation.TabStop = false;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(560, 8);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add Item";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.bundlesTab);
            this.tabControl.Controls.Add(this.weightTab);
            this.tabControl.Controls.Add(this.invoiceTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1028, 330);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.OnItemGridIndexChanged);
            // 
            // bundlesTab
            // 
            this.bundlesTab.Location = new System.Drawing.Point(4, 22);
            this.bundlesTab.Name = "bundlesTab";
            this.bundlesTab.Size = new System.Drawing.Size(1020, 304);
            this.bundlesTab.TabIndex = 0;
            this.bundlesTab.Text = "Container Bundles";
            this.bundlesTab.UseVisualStyleBackColor = true;
            // 
            // weightTab
            // 
            this.weightTab.Location = new System.Drawing.Point(4, 22);
            this.weightTab.Name = "weightTab";
            this.weightTab.Size = new System.Drawing.Size(1020, 304);
            this.weightTab.TabIndex = 1;
            this.weightTab.Text = "View by Item Weight";
            this.weightTab.UseVisualStyleBackColor = true;
            // 
            // invoiceTab
            // 
            this.invoiceTab.Location = new System.Drawing.Point(4, 22);
            this.invoiceTab.Name = "invoiceTab";
            this.invoiceTab.Padding = new System.Windows.Forms.Padding(3);
            this.invoiceTab.Size = new System.Drawing.Size(1020, 304);
            this.invoiceTab.TabIndex = 2;
            this.invoiceTab.Text = "Invoice Totals";
            this.invoiceTab.UseVisualStyleBackColor = true;
            // 
            // shipDateEdt
            // 
            this.shipDateEdt.Location = new System.Drawing.Point(520, 8);
            this.shipDateEdt.Name = "shipDateEdt";
            this.shipDateEdt.Size = new System.Drawing.Size(64, 20);
            this.shipDateEdt.TabIndex = 5;
            this.shipDateEdt.Leave += new System.EventHandler(this.OnDateLeave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(456, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ship Date";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(624, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "ETA Date";
            // 
            // etaEdt
            // 
            this.etaEdt.Location = new System.Drawing.Point(696, 8);
            this.etaEdt.Name = "etaEdt";
            this.etaEdt.Size = new System.Drawing.Size(64, 20);
            this.etaEdt.TabIndex = 8;
            this.etaEdt.Leave += new System.EventHandler(this.OnDateLeave);
            // 
            // shipDateBtn
            // 
            this.shipDateBtn.Location = new System.Drawing.Point(592, 8);
            this.shipDateBtn.Name = "shipDateBtn";
            this.shipDateBtn.Size = new System.Drawing.Size(24, 23);
            this.shipDateBtn.TabIndex = 6;
            this.shipDateBtn.Text = "...";
            this.shipDateBtn.Click += new System.EventHandler(this.OnDateBtn);
            // 
            // etaBtn
            // 
            this.etaBtn.Location = new System.Drawing.Point(768, 8);
            this.etaBtn.Name = "etaBtn";
            this.etaBtn.Size = new System.Drawing.Size(24, 23);
            this.etaBtn.TabIndex = 9;
            this.etaBtn.Text = "...";
            this.etaBtn.Click += new System.EventHandler(this.OnDateBtn);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(864, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Attn:";
            // 
            // attnEdt
            // 
            this.attnEdt.AcceptsReturn = true;
            this.attnEdt.Location = new System.Drawing.Point(864, 32);
            this.attnEdt.Multiline = true;
            this.attnEdt.Name = "attnEdt";
            this.attnEdt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.attnEdt.Size = new System.Drawing.Size(304, 104);
            this.attnEdt.TabIndex = 18;
            this.attnEdt.WordWrap = false;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(24, 24);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 0;
            this.removeBtn.Text = "Remove";
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // moveUpBtn
            // 
            this.moveUpBtn.Location = new System.Drawing.Point(104, 24);
            this.moveUpBtn.Name = "moveUpBtn";
            this.moveUpBtn.Size = new System.Drawing.Size(75, 23);
            this.moveUpBtn.TabIndex = 1;
            this.moveUpBtn.Text = "Move Up";
            this.moveUpBtn.Click += new System.EventHandler(this.moveUpBtn_Click);
            // 
            // moveDownBtn
            // 
            this.moveDownBtn.Location = new System.Drawing.Point(184, 24);
            this.moveDownBtn.Name = "moveDownBtn";
            this.moveDownBtn.Size = new System.Drawing.Size(75, 23);
            this.moveDownBtn.TabIndex = 2;
            this.moveDownBtn.Text = "Move Down";
            this.moveDownBtn.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(552, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Weight(kg)";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(744, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Weight(lbs)";
            // 
            // totalLbsEdt
            // 
            this.totalLbsEdt.Location = new System.Drawing.Point(824, 16);
            this.totalLbsEdt.Name = "totalLbsEdt";
            this.totalLbsEdt.ReadOnly = true;
            this.totalLbsEdt.Size = new System.Drawing.Size(100, 20);
            this.totalLbsEdt.TabIndex = 8;
            // 
            // totalKgEdt
            // 
            this.totalKgEdt.Location = new System.Drawing.Point(632, 16);
            this.totalKgEdt.Name = "totalKgEdt";
            this.totalKgEdt.ReadOnly = true;
            this.totalKgEdt.Size = new System.Drawing.Size(100, 20);
            this.totalKgEdt.TabIndex = 6;
            // 
            // refreshPOBtn
            // 
            this.refreshPOBtn.Location = new System.Drawing.Point(408, 8);
            this.refreshPOBtn.Name = "refreshPOBtn";
            this.refreshPOBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshPOBtn.TabIndex = 3;
            this.refreshPOBtn.Text = "Refresh PO";
            this.refreshPOBtn.Click += new System.EventHandler(this.refreshPOBtn_Click);
            // 
            // customerLocationCombo
            // 
            this.customerLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerLocationCombo.Location = new System.Drawing.Point(360, 32);
            this.customerLocationCombo.Name = "customerLocationCombo";
            this.customerLocationCombo.Size = new System.Drawing.Size(232, 21);
            this.customerLocationCombo.TabIndex = 13;
            this.customerLocationCombo.SelectedIndexChanged += new System.EventHandler(this.OnLocationChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(304, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Location";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Customer";
            // 
            // customerNameCombo
            // 
            this.customerNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerNameCombo.Location = new System.Drawing.Point(80, 32);
            this.customerNameCombo.Name = "customerNameCombo";
            this.customerNameCombo.Size = new System.Drawing.Size(216, 21);
            this.customerNameCombo.TabIndex = 11;
            this.customerNameCombo.SelectedIndexChanged += new System.EventHandler(this.OnCustomerChanged);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.balanceReportBtn);
            this.topPanel.Controls.Add(this.changeBtn);
            this.topPanel.Controls.Add(this.releaseDateBtn);
            this.topPanel.Controls.Add(this.releaseDateEdt);
            this.topPanel.Controls.Add(this.label16);
            this.topPanel.Controls.Add(this.closeContainerButton);
            this.topPanel.Controls.Add(this.topTab);
            this.topPanel.Controls.Add(this.printITLBtn);
            this.topPanel.Controls.Add(this.groupBox1);
            this.topPanel.Controls.Add(this.ccEdt);
            this.topPanel.Controls.Add(this.label9);
            this.topPanel.Controls.Add(this.statusCombo);
            this.topPanel.Controls.Add(this.label8);
            this.topPanel.Controls.Add(this.attnEdt);
            this.topPanel.Controls.Add(this.label3);
            this.topPanel.Controls.Add(this.label4);
            this.topPanel.Controls.Add(this.containerNumberEdt);
            this.topPanel.Controls.Add(this.etaEdt);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.shipDateBtn);
            this.topPanel.Controls.Add(this.etaBtn);
            this.topPanel.Controls.Add(this.label5);
            this.topPanel.Controls.Add(this.shipDateEdt);
            this.topPanel.Controls.Add(this.label11);
            this.topPanel.Controls.Add(this.customerNameCombo);
            this.topPanel.Controls.Add(this.label10);
            this.topPanel.Controls.Add(this.customerLocationCombo);
            this.topPanel.Controls.Add(this.printToExcelBtn);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1028, 352);
            this.topPanel.TabIndex = 0;
            // 
            // balanceReportBtn
            // 
            this.balanceReportBtn.Location = new System.Drawing.Point(648, 304);
            this.balanceReportBtn.Name = "balanceReportBtn";
            this.balanceReportBtn.Size = new System.Drawing.Size(112, 24);
            this.balanceReportBtn.TabIndex = 26;
            this.balanceReportBtn.Text = "Show Balance...";
            this.balanceReportBtn.UseVisualStyleBackColor = true;
            this.balanceReportBtn.Click += new System.EventHandler(this.balanceReportBtn_Click);
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(216, 8);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(75, 23);
            this.changeBtn.TabIndex = 2;
            this.changeBtn.Text = "Change";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // releaseDateBtn
            // 
            this.releaseDateBtn.Location = new System.Drawing.Point(768, 40);
            this.releaseDateBtn.Name = "releaseDateBtn";
            this.releaseDateBtn.Size = new System.Drawing.Size(24, 23);
            this.releaseDateBtn.TabIndex = 16;
            this.releaseDateBtn.Text = "...";
            this.releaseDateBtn.UseVisualStyleBackColor = true;
            this.releaseDateBtn.Click += new System.EventHandler(this.OnDateBtn);
            // 
            // releaseDateEdt
            // 
            this.releaseDateEdt.Location = new System.Drawing.Point(696, 40);
            this.releaseDateEdt.Name = "releaseDateEdt";
            this.releaseDateEdt.Size = new System.Drawing.Size(64, 20);
            this.releaseDateEdt.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(608, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Release Date";
            // 
            // closeContainerButton
            // 
            this.closeContainerButton.Location = new System.Drawing.Point(648, 328);
            this.closeContainerButton.Name = "closeContainerButton";
            this.closeContainerButton.Size = new System.Drawing.Size(112, 24);
            this.closeContainerButton.TabIndex = 23;
            this.closeContainerButton.Text = "Close Container...";
            this.closeContainerButton.UseVisualStyleBackColor = true;
            this.closeContainerButton.Click += new System.EventHandler(this.closeContainerButton_Click);
            // 
            // topTab
            // 
            this.topTab.Controls.Add(this.poTabPage);
            this.topTab.Controls.Add(this.commentPage);
            this.topTab.Location = new System.Drawing.Point(8, 56);
            this.topTab.Name = "topTab";
            this.topTab.SelectedIndex = 0;
            this.topTab.Size = new System.Drawing.Size(848, 240);
            this.topTab.TabIndex = 21;
            // 
            // poTabPage
            // 
            this.poTabPage.Controls.Add(this.poPanel);
            this.poTabPage.Controls.Add(this.poGridLocation);
            this.poTabPage.Location = new System.Drawing.Point(4, 22);
            this.poTabPage.Name = "poTabPage";
            this.poTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.poTabPage.Size = new System.Drawing.Size(840, 214);
            this.poTabPage.TabIndex = 0;
            this.poTabPage.Text = "Choose PO Items";
            this.poTabPage.UseVisualStyleBackColor = true;
            // 
            // poPanel
            // 
            this.poPanel.Controls.Add(this.label2);
            this.poPanel.Controls.Add(this.poNumberEdt);
            this.poPanel.Controls.Add(this.addBtn);
            this.poPanel.Controls.Add(this.refreshPOBtn);
            this.poPanel.Controls.Add(this.choosePOBtn);
            this.poPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poPanel.Location = new System.Drawing.Point(3, 3);
            this.poPanel.Name = "poPanel";
            this.poPanel.Size = new System.Drawing.Size(834, 37);
            this.poPanel.TabIndex = 0;
            // 
            // commentPage
            // 
            this.commentPage.Controls.Add(this.commentsTxt);
            this.commentPage.Location = new System.Drawing.Point(4, 22);
            this.commentPage.Name = "commentPage";
            this.commentPage.Padding = new System.Windows.Forms.Padding(3);
            this.commentPage.Size = new System.Drawing.Size(840, 214);
            this.commentPage.TabIndex = 1;
            this.commentPage.Text = "Container Comments";
            this.commentPage.UseVisualStyleBackColor = true;
            // 
            // commentsTxt
            // 
            this.commentsTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentsTxt.Location = new System.Drawing.Point(3, 3);
            this.commentsTxt.Multiline = true;
            this.commentsTxt.Name = "commentsTxt";
            this.commentsTxt.Size = new System.Drawing.Size(834, 208);
            this.commentsTxt.TabIndex = 0;
            // 
            // printITLBtn
            // 
            this.printITLBtn.Location = new System.Drawing.Point(768, 328);
            this.printITLBtn.Name = "printITLBtn";
            this.printITLBtn.Size = new System.Drawing.Size(96, 23);
            this.printITLBtn.TabIndex = 25;
            this.printITLBtn.Text = "Print ITL";
            this.printITLBtn.Click += new System.EventHandler(this.printITLBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.contDeliveryDateBtn);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.contDeliveryDateEdt);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.closingInfoForContainerBttn);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.contTerminalEdt);
            this.groupBox1.Controls.Add(this.contProofEdt);
            this.groupBox1.Location = new System.Drawing.Point(8, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 48);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Container Closing Info";
            // 
            // contDeliveryDateBtn
            // 
            this.contDeliveryDateBtn.Location = new System.Drawing.Point(240, 24);
            this.contDeliveryDateBtn.Name = "contDeliveryDateBtn";
            this.contDeliveryDateBtn.Size = new System.Drawing.Size(24, 23);
            this.contDeliveryDateBtn.TabIndex = 3;
            this.contDeliveryDateBtn.Text = "...";
            this.contDeliveryDateBtn.Click += new System.EventHandler(this.contDeliveryDateBtn_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(400, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 16);
            this.label15.TabIndex = 6;
            this.label15.Text = "Or";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(288, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Terminal";
            // 
            // contDeliveryDateEdt
            // 
            this.contDeliveryDateEdt.Location = new System.Drawing.Point(152, 24);
            this.contDeliveryDateEdt.Name = "contDeliveryDateEdt";
            this.contDeliveryDateEdt.Size = new System.Drawing.Size(80, 20);
            this.contDeliveryDateEdt.TabIndex = 2;
            this.contDeliveryDateEdt.Text = "textBox1";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(448, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Bill of lading";
            // 
            // closingInfoForContainerBttn
            // 
            this.closingInfoForContainerBttn.Location = new System.Drawing.Point(8, 16);
            this.closingInfoForContainerBttn.Name = "closingInfoForContainerBttn";
            this.closingInfoForContainerBttn.Size = new System.Drawing.Size(144, 24);
            this.closingInfoForContainerBttn.TabIndex = 0;
            this.closingInfoForContainerBttn.Text = "Apply to entire container";
            this.closingInfoForContainerBttn.CheckedChanged += new System.EventHandler(this.OnContainerClosingChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(152, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Delivery Date";
            // 
            // contTerminalEdt
            // 
            this.contTerminalEdt.Location = new System.Drawing.Point(288, 24);
            this.contTerminalEdt.Name = "contTerminalEdt";
            this.contTerminalEdt.Size = new System.Drawing.Size(100, 20);
            this.contTerminalEdt.TabIndex = 5;
            this.contTerminalEdt.Text = "textBox2";
            // 
            // contProofEdt
            // 
            this.contProofEdt.Location = new System.Drawing.Point(448, 24);
            this.contProofEdt.Name = "contProofEdt";
            this.contProofEdt.Size = new System.Drawing.Size(100, 20);
            this.contProofEdt.TabIndex = 8;
            this.contProofEdt.Text = "textBox3";
            // 
            // ccEdt
            // 
            this.ccEdt.AcceptsReturn = true;
            this.ccEdt.Location = new System.Drawing.Point(864, 160);
            this.ccEdt.Multiline = true;
            this.ccEdt.Name = "ccEdt";
            this.ccEdt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ccEdt.Size = new System.Drawing.Size(304, 136);
            this.ccEdt.TabIndex = 20;
            this.ccEdt.WordWrap = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(864, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "CC:";
            // 
            // statusCombo
            // 
            this.statusCombo.Items.AddRange(new object[] {
            "Open",
            "Closed",
            "Cancelled"});
            this.statusCombo.Location = new System.Drawing.Point(352, 8);
            this.statusCombo.Name = "statusCombo";
            this.statusCombo.Size = new System.Drawing.Size(96, 21);
            this.statusCombo.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(304, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Status";
            // 
            // printToExcelBtn
            // 
            this.printToExcelBtn.Location = new System.Drawing.Point(768, 304);
            this.printToExcelBtn.Name = "printToExcelBtn";
            this.printToExcelBtn.Size = new System.Drawing.Size(96, 23);
            this.printToExcelBtn.TabIndex = 24;
            this.printToExcelBtn.Text = "Print";
            this.printToExcelBtn.Click += new System.EventHandler(this.printToExcelBtn_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.gotoBOLBtn);
            this.bottomPanel.Controls.Add(this.gotoPOBtn);
            this.bottomPanel.Controls.Add(this.removeBtn);
            this.bottomPanel.Controls.Add(this.moveUpBtn);
            this.bottomPanel.Controls.Add(this.moveDownBtn);
            this.bottomPanel.Controls.Add(this.totalLbsEdt);
            this.bottomPanel.Controls.Add(this.totalKgEdt);
            this.bottomPanel.Controls.Add(this.label6);
            this.bottomPanel.Controls.Add(this.label7);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 682);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1028, 64);
            this.bottomPanel.TabIndex = 1;
            // 
            // gotoBOLBtn
            // 
            this.gotoBOLBtn.Location = new System.Drawing.Point(0, 0);
            this.gotoBOLBtn.Name = "gotoBOLBtn";
            this.gotoBOLBtn.Size = new System.Drawing.Size(75, 23);
            this.gotoBOLBtn.TabIndex = 0;
            // 
            // gotoPOBtn
            // 
            this.gotoPOBtn.Location = new System.Drawing.Point(304, 24);
            this.gotoPOBtn.Name = "gotoPOBtn";
            this.gotoPOBtn.Size = new System.Drawing.Size(75, 23);
            this.gotoPOBtn.TabIndex = 3;
            this.gotoPOBtn.Text = "Go to PO";
            this.gotoPOBtn.Click += new System.EventHandler(this.gotoPOBtn_Click);
            // 
            // fillPanel
            // 
            this.fillPanel.Controls.Add(this.tabControl);
            this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillPanel.Location = new System.Drawing.Point(0, 352);
            this.fillPanel.Name = "fillPanel";
            this.fillPanel.Size = new System.Drawing.Size(1028, 330);
            this.fillPanel.TabIndex = 27;
            // 
            // ContainerItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.fillPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Name = "ContainerItem";
            this.Text = "ContainerItem";
            ((System.ComponentModel.ISupportInitialize)(this.poGridLocation)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.topTab.ResumeLayout(false);
            this.poTabPage.ResumeLayout(false);
            this.poPanel.ResumeLayout(false);
            this.poPanel.PerformLayout();
            this.commentPage.ResumeLayout(false);
            this.commentPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.fillPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void balanceReportBtn_Click(object sender, EventArgs e)
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            EMDataSet emDataSet = new EMDataSet();
             try
            {
               using (new TurnOffConstraints(emDataSet))
                using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
                {
                    FormSupport.FillContainerFromDatabase(emDataSet, CurrentKey);
                    foreach (EMDataSet.POHeaderTblRow poHeader in emDataSet.POHeaderTbl)
                    {
                        AdapterHelper.FillPOItem(emDataSet, poHeader.POID);
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
                ArrayList listOfPOs = new ArrayList();
                foreach (EMDataSet.ContBundleTblRow bundleRow in GetHeaderRow().GetContBundleTblRows())
                {
                    int poid = bundleRow.POItemTblRow.POID;
                    listOfPOs.Add(poid);
                }
                AdapterHelper.Unique(ref listOfPOs);
                foreach (int poid in listOfPOs)
                {
                    EMDataSet.POHeaderTblRow poHeaderRow =
                        emDataSet.POHeaderTbl.FindByPOID(poid);
                    TreeNode treeNode = new TreeNode();
                    bool completed =
                        DataInterface.IsPOCompleted(poHeaderRow, ref treeNode,
                        new DataInterface.IsContainerBundleCompleted(delegate(EMDataSet.ContBundleTblRow bundleRow)
                        {
                            return true;
                        }
                            )
                            );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseContainer.ShowReport(emDataSet,CurrentKey,"This report lists how much of an item in a PO has been included in containers.");
            Cursor.Current = oldCursor;
        }            
	}
}
