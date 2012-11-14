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
using System.Collections.Generic;

namespace EM
{
	/// <summary>
	/// Summary description for PO.
	/// </summary>
	/// 

	public class PO : KeyBasedForm,
		HelperFunctions.DataGridClientInterface,
		IAllowComboBoxUpdates
	{
		private System.Windows.Forms.Label label1;
		private AutoCompleteComboBox m_statusCombo;
	private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private AutoCompleteTextBox m_dateEdt;
		private System.Windows.Forms.Button m_dateBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		// My variables
		
		private AutoCompleteComboBox m_shipCodeCombo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private AutoCompleteTextBox m_fobEdt;
		private System.Windows.Forms.Label label6;
		private AutoCompleteComboBox m_termsCombo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private AutoCompleteTextBox m_cancelDateEdt;
		private System.Windows.Forms.Button m_cancelDateBtn;
		private AutoCompleteTextBox m_commentEdt;
        private EM.EMDataSet m_emDataSet = new EM.EMDataSet();
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private AutoCompleteTextBox m_totalCostEdit;
        private AutoCompleteTextBox m_totalCostUSEdit;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private AutoCompleteComboBox customerCombo;
        private AutoCompleteComboBox millCombo;
		private System.Windows.Forms.Button removeItemBtn;
		private System.Windows.Forms.Button moveUpBtn;
		private System.Windows.Forms.Button moveDownBtn;
		private System.Windows.Forms.Button printPOBtn;
		private System.Windows.Forms.Button printAckBtn;
		//private System.Windows.Forms.DataGrid poGrid;
		private System.Windows.Forms.Label label9;
		private AutoCompleteComboBox umCombo;
		public AutoCompleteTextBox m_purchaseEdt;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button addNewMillBtn;
		private System.Windows.Forms.Button addNewMillLocationBtn;
		private System.Windows.Forms.Button addNewCustomerBtn;
		private System.Windows.Forms.Button addNewCustomerLocationBtn;
		private System.Windows.Forms.TabPage commentPage;
		private System.Windows.Forms.Label labelMillConfirmation;
		private EM.AutoCompleteTextBox millConfirmationNumberEdit;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button insertRowBtn;
		private System.Windows.Forms.Label labelAckDate;
		private EM.AutoCompleteTextBox ackDateEdt;
		private System.Windows.Forms.Button ackDateBtn;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private EM.AutoCompleteTextBox exchangeDateEdt;
		private System.Windows.Forms.Button exchangeDateBtn;
        private System.Windows.Forms.ComboBox currencyCombo;
		private System.Windows.Forms.TabPage purchaseOrderPage;
		private System.Windows.Forms.TabPage weightPage;
		private System.Windows.Forms.TabPage containerTrackingPage;
		private System.Windows.Forms.Panel containerTrackingPanel;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox containerItemDetailsGroupBox;
		private System.Windows.Forms.Panel containerItemDetailsPanel;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button refreshContainerItemtn;
		private System.Windows.Forms.Button goToContainerBtn;
		private System.Windows.Forms.TabControl m_tabControl;
		private EM.AutoCompleteComboBox customerLocationCombo;
		private EM.AutoCompleteComboBox millLocationCombo;
		private EM.AutoCompleteTextBox millCountryEdt;
		private EM.AutoCompleteTextBox millAddressEdt;
		private EM.AutoCompleteTextBox customerCountryEdt;
		private EM.AutoCompleteTextBox customerAddressEdt;
		private System.Windows.Forms.CheckBox surchargeCheck;
		private System.Windows.Forms.Button showGradeTotalsBtn;
		private System.Windows.Forms.Label label28;
		private EM.AutoCompleteTextBox invoiceEdt;
		private System.Windows.Forms.Label revisedAckLabel;
		private EM.AutoCompleteTextBox ackRevisedDateEdt;
		private System.Windows.Forms.Button ackRevisedDateBtn;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Button invoiceDateBtn;
		private System.Windows.Forms.GroupBox invoiceGroup;
		private EM.AutoCompleteTextBox invoiceDateEdt;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label statusLabel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private AutoCompleteComboBox custContactCombo;
        private AutoCompleteComboBox millContactCombo;
        private Button addMillContact;
        private Button addCustomerContact;
        private Button changeBtn;
        private CheckBox btnApplyConfirmationToEntirePO;
        private TabPage millConfirmationPage;
		private AutoCompleteTextBox m_exchangeRateEdt;
		

		public override void ClearDataSet()
		{
			using (new TurnOffConstraints(m_emDataSet))
			{
				EMDataSet.POHeaderTblRow row  = GetHeaderRow();
				foreach (string s in fieldsToRemember)
				{
					oldValues[s] = row[s];
				}
				m_emDataSet.BOLItemTbl.Clear();
				m_emDataSet.BOLTbl.Clear();
				m_emDataSet.ContBundleTbl.Clear();
				m_emDataSet.ContainerTbl.Clear();
				m_emDataSet.POItemTbl.Clear();
				m_emDataSet.POHeaderTbl.Clear();
			}
		}
		public new EMDataSet.POHeaderTblRow GetHeaderRow()
		{
			return (EMDataSet.POHeaderTblRow)base.GetHeaderRow();
		}

		public bool AllowComboBoxUpdates
		{
			get
			{
				return allowComboBoxUpdates;
			}
			set
			{
				allowComboBoxUpdates = value;
			}
		}
	

		public object[] m_textBoxes;
		public string[] m_fieldNames;
		public string[] m_dateFieldNames;
		public AutoCompleteTextBox[] m_dateBoxes;
		
		System.Collections.Hashtable oldValues = new Hashtable();

		string[] fieldsToRemember = new string[]{"MillID","MillLocationID","CustomerID",
													"CustomerLocationID"};

		public override void InitializeDataRow(DataRow rowIn)
		{
			EMDataSet.POHeaderTblRow row = (EMDataSet.POHeaderTblRow)rowIn;
			EMDataSet.POHeaderTblRow oldRow = GetHeaderRow();
			foreach (string s in fieldsToRemember)
			{
				row[s] = oldValues[s];
			}
			row.PODate = DateTime.Today;
			row.Terms = "Net 30";
			row.Status = "Open";
            row.MillConfirmationAppliesToEntirePO = 1;
		}
		public override bool IsChanged()
		{
			DataTable header = GetHeaderTable().GetChanges();
			DataTable child = m_emDataSet.POItemTbl.GetChanges();
			if (header != null)
				return true;
			if (child != null)
				return true;
			return false;
		}

		private void OnDateLeave(object sender, System.EventArgs e)
		{
			AutoCompleteTextBox dateBox = null;
			string dateField="";
			for (int i=0;i<this.m_dateBoxes.Length;i++)
			{
				if (sender == m_dateBoxes[i])
				{
					dateBox = m_dateBoxes[i];
					dateField = m_dateFieldNames[i];
					break;
				}
			}
			Debug.Assert(dateBox != null);
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			
			try
			{
				if (dateBox.Text == "")
					row[dateField] = DBNull.Value;
				else
					row[dateField] = dateBox.Text;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			if (row.IsNull(dateField))
			{
				dateBox.Text = "";
			}
			else
			{
				dateBox.Text = HelperFunctions.ToDateText(
					(DateTime)row[dateField]);
			}		
		}

		public override string[] GetSortOrder()
		{
			return new string[]{"Status","PODate","PONumber"};
		}
	
		public override bool IsDeleteAllowed()
		{
			if (GetAllDetailRows().Length != 0)
			{
				MessageBox.Show("Delete of the purchase order is not allowed " + 
								"unless all items in the purchase order have been deleted",
								"Can't delete");
				return false;
			}
			return true;
		}

		public void MoveToNewCell(DataGrid grid)
		{
			DataGridCell cell = grid.CurrentCell;
			int row = cell.RowNumber;
			int column = cell.ColumnNumber;
			if (column == 0)
				column =1;
			else
				column = 0;
			grid.CurrentCell = new DataGridCell(row,column);
		}

		public void OnGridItemClicked(int selectedRow)
		{
			try
			{
				FromControls();
				EMDataSet.POHeaderTblRow headerRow = GetHeaderRow();
				if (headerRow.IsCustomerIDNull())
				{
					throw new Exception("Customer must be chosen before you can use the item selection window");
				}


				EMDataSet.POItemTblRow rowOut = HelperFunctions.GetRowFromSeqNumber(m_emDataSet.POItemTbl,
					selectedRow+1);


				if ((rowOut != null) && (!rowOut.IsAcknowledgeDateNull()))
				{
					MessageBox.Show("Item can not be changed since it has already been acknowledged.\n" +
						"Remove acknowledgement date first.","Can't change acknowledged item",
						MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}

				int count;
				string finish;
				string treatment;
				EMDataSet.ItemTblRow rowIn = ChooseItem.CreateNewRow(headerRow.CustomerID
					,out count,out finish,out treatment);
				if (rowIn == null)
					return;
				using (new OpenConnection(EM.IsWrite.No,AdapterHelper.Connection))
					AdapterHelper.FillItem(m_emDataSet,rowIn.ItemID);
				// The first row is a description only row, if there is
				// more than 1 row. If there is more than 1 row, then there
				// will actually be an additional row (because of this description
				// only row)
				if (count != 1)
					++count;
				for (int z=0;z<count;z++)
				{
					if (rowIn.IsItemNameNull())
						poGrid.SetItem(new QuickGrid.Index(selectedRow+z,1),"");
					else
						poGrid.SetItem(new QuickGrid.Index(selectedRow+z,1),rowIn.ItemName);
			
					poGrid.SetItem(new QuickGrid.Index(selectedRow+z,0),finish);
					poGrid.SetItem(new QuickGrid.Index(selectedRow+z,2),treatment);

					if (z==0)
					{
						if (rowIn.IsItemDescNull())
							poGrid.SetItem(
								new QuickGrid.Index(selectedRow+z,3),"");
						else
							poGrid.SetItem(
								new QuickGrid.Index(selectedRow+z,3),rowIn.ItemDesc);
					}
					//for (int i=4;i<poGrid.VisibleColumns;i++)
					//{
				//		poGrid.SetItem(new QuickGrid.Index(selectedRow+z,i),"");
				//	}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

		}

		bool DoesItemNameExist()
		{
			foreach (EMDataSet.POItemTblRow childRow in m_emDataSet.POItemTbl.Rows)
			{
				if (!DataInterface.IsRowAlive(childRow))
				{
					continue;
				}
				if (!childRow.IsItemIDNull())
						return true;
			}
			return false;
		}

		public override bool IsValid()
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			if (row.IsPONumberNull() || row.PONumber == "")
			{
				MessageBox.Show("Save aborted. PO Number must be completed");
				return false;
			}
			bool doesItemNameExist = DoesItemNameExist();
			if (!doesItemNameExist)
				return true;
			string[] requiredFields = 
			{"PODate","PONumber","Terms","ShipCode","FOB"};
			string[] friendlyTitles = 
				{	"Purchase order date","PONumber","Terms","Ship Via","FOB"};

			string errorMessage;
			if (!HelperFunctions.AreRequiredFieldsFilledIn(row,
				requiredFields,friendlyTitles,
				out errorMessage))
				return false;

            // Double check that both the mill confirmation number and the mill
            // confirmation date are both filled out.
            bool millConfirmationNumberExists = false;
            bool millConfirmationDateExists = false;
            if (row.IsMillConfirmationAppliesToEntirePONull() ||
                row.MillConfirmationAppliesToEntirePO == 1)
            {
                millConfirmationNumberExists = !row.IsMillConfirmationNumberNull() &&
                    row.MillConfirmationNumber != "";
                millConfirmationDateExists= !row.IsMillAcknowledgeDateNull();
                if (millConfirmationNumberExists != millConfirmationDateExists)
                {
                    MessageBox.Show("Save Aborted: Error, cannot commit changes: " + 
                        "If Mill Confirmation Number exists then " +
                        "Mill Confirmation Date must also exist, and vice-versa");
                    return false;
                }
            }
            else
            {
                foreach (EMDataSet.POItemTblRow itemRow in row.GetPOItemTblRows())
                {
                    millConfirmationNumberExists = !itemRow.IsMillConfirmationNumberNull() &&
                        itemRow.MillConfirmationNumber != "";
                    millConfirmationDateExists =  !itemRow.IsMillAcknowledgeDateNull();
                    if (millConfirmationNumberExists != millConfirmationDateExists)
                    {
                        MessageBox.Show("Save Aborted: Error, cannot commit changes: " +
                            "If Mill Confirmation Number exists then " +
                            "Mill Confirmation Date must also exist, and vice-versa");
                        return false;
                    }
                }
            }
			return true;
		}

		public string[] DecimalFieldsToBeMonitored()
		{
			return new string[]{"CustAmount"};
		}
		public void NewGridTotal(string fieldName,decimal total)
		{
			NewGridTotal(total);
		}

		public void NewGridTotal(decimal total)
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			string otherTotal = total.ToString();
			row.OtherTotal = total;
			if (row.IsExchangeRateNull())
			{
				row.USTotal = row.OtherTotal;
				m_totalCostUSEdit.Text = otherTotal;
			}
			else
			{
				row.USTotal = row.OtherTotal * row.ExchangeRate;
			}
			UpdateCurrencyControls();
		}


		public void FromSelectedGrid()
		{
			FromGrid(m_tabControl.SelectedIndex);
		}
		public void FromGrid(int index)
		{
			if (index == 0)
			{
				HelperFunctions.FromGrid(GetHeaderRow().POID,
					m_emDataSet,poGrid,true);
			}
			else if (index == 1){}
			else if (index == 2){}
            else if (index == 3)
            {
                HelperFunctions.FromGrid(GetHeaderRow().POID, m_emDataSet, millConfirmationGrid,
                    false);
            }
            else
            {
                Debug.Assert(false);
            }
			FixUMButNoUpdates(umCombo.Text);
		}

		public override void FromControls()
		{
			// Depending on the selected tab, we commit changes from the particular grids
			FromSelectedGrid();

			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			for (int i=0;i<m_textBoxes.Length;i++)
			{
				try
				{
					row[m_fieldNames[i]] = GetText(m_textBoxes[i]);
				}
				catch (Exception e)
				{
					throw new Exception("Could not parse field:" + m_fieldNames[i] + "\n" +
						e.Message);
				}
			}
			try
			{
				if (m_exchangeRateEdt.Text.Length == 0)
					row["ExchangeRate"] = 1;
				else
					row["ExchangeRate"] = m_exchangeRateEdt.Text;
			}
			catch( Exception e)
			{
				throw new Exception("Could not parse field: Exchange Rate" + e.Message);
			}

			for (int i=0;i<m_dateBoxes.Length;i++)
			{
				if  (m_dateBoxes[i].Text == "")
					row[m_dateFieldNames[i]] = DBNull.Value;
				else
				{
					try
					{
						row[m_dateFieldNames[i]] = 
							System.DateTime.Parse(m_dateBoxes[i].Text);
					}
					catch(Exception ex)
					{
						string errorMessage = "Didn't understand the text for field \"" + 
							this.m_dateFieldNames[i] +
							"\"\nOriginal Error: " + ex.Message;
						Exception newEx = new Exception(errorMessage,ex);
						throw newEx;
					}
				}
			}

			// First update the total:
			decimal total = 0;
			foreach (EMDataSet.POItemTblRow detailRow in GetAllDetailRows())
			{
				if (!detailRow.IsCustAmountNull() &&
					detailRow.IsCancelDateNull())
					total += detailRow.CustAmount;
			}
			row.OtherTotal = total;
			decimal exchange;
			if (row.IsExchangeRateNull())
				exchange = 1;
			else
				exchange = row.ExchangeRate;
			row.USTotal = total * exchange;

			if (row.IsSurchargesInEffectNull())
			{
				if (this.surchargeCheck.Checked)
					row.SurchargesInEffect = surchargeCheck.Checked;
			}
			else
			{
				row.SurchargesInEffect = this.surchargeCheck.Checked;
			}
            if (this.btnApplyConfirmationToEntirePO.Checked == false)
                row.MillConfirmationAppliesToEntirePO = 0;
            else
            {
                row.MillConfirmationAppliesToEntirePO = 1;
            }
		}
		public static void CompareForValidaty(EMDataSet unsavedDataSet,EMDataSet currentDataSet)
		{
			DataInterface.CheckForChanges("POItemNumber","Sequence Number","SeqNumber",
				"SeqNumber",currentDataSet.POItemTbl,
				unsavedDataSet.POItemTbl);
		}
		public override void CommitTablesToDatabase()
		{
			using (DataInterface.CreateLockFile("po.lock"))
			using (new OpenConnection(IsWrite.Yes,AdapterHelper.Connection))
			{
				EMDataSet tempDataSet = new EMDataSet();
				using (new TurnOffConstraints(tempDataSet))
				{
					AdapterHelper.FillCurrency(tempDataSet);
					AdapterHelper.FillPOHeader(tempDataSet,base.CurrentKey);
					AdapterHelper.FillPOItem(tempDataSet,base.CurrentKey);
					AdapterHelper.FillOutConstraints(tempDataSet);
				}
				if (!IsEmptyTable())
				{
					EMDataSet.POHeaderTblRow row = GetHeaderRow();
					if (DataInterface.IsRowAlive(row))
						CompareForValidaty(m_emDataSet,tempDataSet);
				}
				AdapterHelper.CommitPOChanges(m_emDataSet);
			}
		}

		void UpdateCurrencyControls()
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
            if (row.IsExchangeRateNull())
				m_exchangeRateEdt.Text = "";
			else
				m_exchangeRateEdt.Text = row.ExchangeRate.ToString();

			if (row.IsOtherTotalNull())
				m_totalCostEdit.Text = "";
			else
				m_totalCostEdit.Text = row.OtherTotal.ToString("N2");
			if (row.IsUSTotalNull())
				m_totalCostUSEdit.Text = "";
			else
				m_totalCostUSEdit.Text = row.USTotal.ToString("N2");
		}

		
		private void OnCurrencyChanged(object sender, System.EventArgs e)
		{
			if (!allowComboBoxUpdates)
				return;
			object o = currencyCombo.SelectedItem;
			TaggedItem tagged = (TaggedItem)o;
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			row.CurrencyID = tagged.key;
		}
		public override void UpdateControls() 
		{
			using (new StopComboBoxUpdates(this))
			{
				UpdateGrid();
				EMDataSet.POHeaderTblRow row = GetHeaderRow();
				for (int i=0;i<m_textBoxes.Length;i++)
				{
					SetText(m_textBoxes[i],row[m_fieldNames[i]].ToString());
				}
				for (int i=0;i<m_dateBoxes.Length;i++)
				{
					object field = row[m_dateFieldNames[i]];
					if (field is DateTime)
					{
						m_dateBoxes[i].Text = HelperFunctions.ToDateText((DateTime)field);
					}
					else
						m_dateBoxes[i].Text = "";
				}
				if (!row.IsCommentsNull() && row.Comments != "")
				{
					commentPage.Text = "Comments (not empty)";
				}
				else
					commentPage.Text = "Comments (empty)";

				DataRow currencyRow = null;
				if (!row.IsCurrencyIDNull())
					currencyRow = m_emDataSet.CurrencyTbl.FindByCurrencyID(row.CurrencyID);
				DataInterface.UpdateComboBox(m_emDataSet.CurrencyTbl.DefaultView,
					"CurrencyID","CurrencyName",currencyCombo,currencyRow);


				UpdateCurrencyControls();
				UpdateMillCombo();
				UpdateCustomerCombo();

				UpdateEnabled();
				this.surchargeCheck.Checked = false;
				if (!row.IsSurchargesInEffectNull())
				{
					if (row.SurchargesInEffect)
						this.surchargeCheck.Checked = true;
				}
                this.btnApplyConfirmationToEntirePO.Checked = 
                        row.MillConfirmationAppliesToEntirePO != 0;
                bool makeConfirmationVisible = btnApplyConfirmationToEntirePO.Checked;
                labelMillConfirmation.Visible = makeConfirmationVisible;
                millConfirmationNumberEdit.Visible = makeConfirmationVisible;
                labelAckDate.Visible = makeConfirmationVisible;
                ackDateEdt.Visible = makeConfirmationVisible;
                ackDateBtn.Visible = makeConfirmationVisible;
                //invoiceGroup.Visible = makeConfirmationVisible;
                revisedAckLabel.Visible = makeConfirmationVisible;
                ackRevisedDateEdt.Visible = makeConfirmationVisible;
                ackRevisedDateBtn.Visible = makeConfirmationVisible;
			}
		}

		
		object GetContainerCheckField(DataRow rowIn,bool isMetric,string field)
		{
			EMDataSet.POItemTblRow row = (EMDataSet.POItemTblRow)rowIn;
			string[] itemFields = {"SeqNumber","POItemNumber","Length","SizeOfItem","Qty"};
			if (Array.IndexOf(itemFields,field) != -1) // found
			{
				return row[field];
			}
			decimal bundleWeight = 0;
			decimal bolWeight = 0;
            EMDataSet.ContBundleTblRow[] bundles = row.GetContBundleTblRows();
			foreach (EMDataSet.ContBundleTblRow bundleRow in bundles)
			{
				decimal currentBundleWeight = 0;
				if (isMetric)
				{
					if (!bundleRow.IsMetricShipQtyNull())
						currentBundleWeight += bundleRow.MetricShipQty;
				}
				else
				{
					if (!bundleRow.IsEnglishShipQtyNull())
						currentBundleWeight += bundleRow.EnglishShipQty;
				}
				if (DataInterface.IsContainerItemDone(bundleRow))
				{
					bolWeight += currentBundleWeight;
				}
				else 
				{
					if (!bundleRow.ContainerTblRow.IsStatusNull() &&
						bundleRow.ContainerTblRow.Status == "Closed")
						bolWeight += currentBundleWeight;
				}
				bundleWeight += currentBundleWeight;
			}
			if (field == "ContainerWeight")
				return bundleWeight;
			if (field == "BOLWeight")
				return bolWeight;
            if (field == "CancelDate")
                return row["CancelDate"];
			if (field == "PercentPickedUp")
			{
				if (row.IsQtyNull())
					return DBNull.Value;
				if (row.Qty == 0)
					return DBNull.Value;
				decimal qty = row.Qty;
				decimal deviation = (bolWeight/qty) * 100;
				return deviation;
			}
			if (field == "ItemName")
			{
				if (row.IsItemIDNull())
					return DBNull.Value;
				return row.ItemTblRow.ItemName;
			}
			throw new Exception("BUG Unknown field");
		}


		public object GetPOItemFieldForGrid(DataRow sourceRow,
			bool isMetric,string fieldName)
		{
			if (fieldName == "Finish")
			{
				EMDataSet.POItemTblRow row = (EMDataSet.POItemTblRow)sourceRow;
				if (row.IsFinishIDNull())
					return "";
				string finish = HelperFunctions.GetFinishType("Finish",row.FinishID);
				return finish;
			}
			if (fieldName == "Treatment")
			{
				EMDataSet.POItemTblRow row = (EMDataSet.POItemTblRow)sourceRow;
				if (row.IsTreatmentIDNull())
					return "";
				string finish = HelperFunctions.GetFinishType("Treatment",row.TreatmentID);
				return finish;
			}
			if (fieldName == "ItemName")
			{
                EMDataSet.POItemTblRow row = (EMDataSet.POItemTblRow)sourceRow;
                // For the mill confirmation  - only show the combined item name (grade + finish)
                if (m_tabControl.SelectedIndex == 3)
                    return HelperFunctions.GetItemName(row);
                if (row.IsItemIDNull())
					return "";
				string name = row.ItemTblRow.ItemName;
				return name;
			}
			return sourceRow[fieldName];
		}


		void UpdateGrid()
		{
			using (new StopComboBoxUpdates(this))
			{
				// Disable remove, moveup, and movedown for the ack grid
				int selectedIndex = m_tabControl.SelectedIndex;
				bool enableDelete = (selectedIndex == 0);
				bool isEmptyTable = base.IsEmptyTable();
				enableDelete = enableDelete & !isEmptyTable;
				insertRowBtn.Enabled = enableDelete;
				moveUpBtn.Enabled = enableDelete;
				moveDownBtn.Enabled = enableDelete;
				removeItemBtn.Enabled = enableDelete;

				// Not sure why I'm updating the UM combo when trying to update
				// the grid.
				bool isKg = DataInterface.IsMetric(m_emDataSet.POItemTbl);
				if (isKg)
				{
					umCombo.Text = "kg";
				}
				else
				{
					umCombo.Text = "lbs";			
				}
				this.FixUMButNoUpdates(umCombo.Text);

				EMDataSet.POItemTblDataTable itemTable = m_emDataSet.POItemTbl;
				if (selectedIndex == 0) // is PO grid
				{
               		List<String> poFields = new List<String>(new String[]
			        {
				        "Finish","ItemName","Treatment","ItemDesc",
				        "SizeOfItem","Length",
				        "ItemAccessCode","DateRequired","MillShipDate","Qty",
				        "CustRate","CustAmount","CancelDate",
				        "Comments"});
                    if (!GetHeaderRow().IsMillConfirmationAppliesToEntirePONull() &&
                        GetHeaderRow().MillConfirmationAppliesToEntirePO == 0)
                    {
                        poFields.AddRange(new String[] { "MillConfirmationNumber", "MillAcknowledgeDate" });
                                                    //"InvoiceNumber","InvoiceDate"});
                    }
                    poFields.AddRange(new String[]{"POItemNumber","SeqNumber"});
					FormSupport.GridWizard(poGrid,m_emDataSet.POItemTbl,isKg,
						IsNewAllowed.Yes,IsReadOnly.No,"SeqNumber",
						new FormSupport.GetFieldDelegate(GetPOItemFieldForGrid)
						,this,poFields.ToArray());
                    poGrid.SetCancelColumn("CancelDate");
                }
				else if (selectedIndex == 2) // for container check
				{
					FormSupport.GridWizard(containerCheckGrid,itemTable,isKg,IsNewAllowed.No,
						IsReadOnly.Yes,"SeqNumber",new FormSupport.GetFieldDelegate(this.GetContainerCheckField)
						,null,"ItemName","SizeOfItem","Length","Qty",
						"ContainerWeight","BOLWeight","PercentPickedUp","CancelDate","SeqNumber","POItemNumber");
                    containerCheckGrid.SetCancelColumn("CancelDate");
				}
				else if (selectedIndex == 1) // for weight table
				{
					FinishTypeGrid.DoIt(this.weightGrid,base.CurrentKey,isKg,m_emDataSet);
				}
                else if (selectedIndex == 3)
                {
                    List<String> poFields = new List<String>(new String[]
			        {
				        "*ItemName",
				        "*SizeOfItem","*Length",
				        "*ItemAccessCode","*Qty","*CancelDate"});
                    if (!GetHeaderRow().IsMillConfirmationAppliesToEntirePONull() &&
                        GetHeaderRow().MillConfirmationAppliesToEntirePO == 0)
                    {
                        poFields.AddRange(new String[] { "MillConfirmationNumber", "MillAcknowledgeDate" });
                        //"InvoiceNumber","InvoiceDate"});
                    }
                    poFields.AddRange(new String[] { "POItemNumber", "SeqNumber" });
                    FormSupport.GridWizard(millConfirmationGrid, m_emDataSet.POItemTbl, isKg,
                        IsNewAllowed.No, IsReadOnly.No, "SeqNumber",
                        new FormSupport.GetFieldDelegate(GetPOItemFieldForGrid)
                        , this, poFields.ToArray());
                    millConfirmationGrid.SetCancelColumn("CancelDate");
                    
                }
                else Debug.Assert(false);
			}
		}
		
		public override DataTable GetHeaderTable() 
		{
			return m_emDataSet.POHeaderTbl;
		}
		public override OleDbConnection GetConnection()
		{
			return AdapterHelper.Connection;
		}
		public override string GetTableName()
		{
			return "tblPOHeader2";
		}

		public override void FillTablesFromDatabase() 
		{
			m_emDataSet.Clear();
			using (TurnOffConstraints doIt = new TurnOffConstraints(m_emDataSet))
			{
				AdapterHelper.FillPOHeader(m_emDataSet,base.CurrentKey);
				AdapterHelper.FillTerms(m_emDataSet);
				AdapterHelper.FillShippingCode(m_emDataSet);
				DataInterface.UpdateComboBox(m_emDataSet.ShippingCodeTbl,"ShipCode",m_shipCodeCombo);
				DataInterface.UpdateComboBox(m_emDataSet.PaymentTermsTbl,"Terms",m_termsCombo);
				AdapterHelper.FillCompany(m_emDataSet);
				AdapterHelper.FillAllLocations(m_emDataSet);
                AdapterHelper.FillAllContacts(m_emDataSet);
                AdapterHelper.FillCountry(m_emDataSet);
				AdapterHelper.FillCurrency(m_emDataSet);
				if (IsEmptyTable())
					return;

				AdapterHelper.FillPOItem(m_emDataSet,GetHeaderRow().POID);
				foreach (EMDataSet.POItemTblRow itemRow in m_emDataSet.POItemTbl)
				{
					AdapterHelper.FillContBundleFromPOItemNumber(m_emDataSet,itemRow.POItemNumber);
				}
				foreach (EMDataSet.ContBundleTblRow bundleRow in m_emDataSet.ContBundleTbl)
				{
					AdapterHelper.FillContainerHeader(m_emDataSet,bundleRow.ContID);
					AdapterHelper.FillBOLFromContBundleID(m_emDataSet,bundleRow.ContainerBundleID);
				}
				foreach (EMDataSet.BOLItemTblRow bolItemRow in m_emDataSet.BOLItemTbl)
				{
					AdapterHelper.FillBillOfLading(m_emDataSet,bolItemRow.BOLID);
				}
				AdapterHelper.FillOutConstraints(m_emDataSet);
			}
		}

        void UpdateCompanyCombo(string companyType,
			AutoCompleteComboBox combo,
			object compID)
		{
			string filter = "CompType = '" + companyType + "'";
			DataView compView = new DataView(m_emDataSet.CompanyTbl,filter,"CompName",
				DataViewRowState.CurrentRows);
			DataRow compRow = null;
			if (!(compID is DBNull))
				compRow = compView.Table.Rows.Find(compID);
			DataInterface.UpdateComboBox(compView,
				"CompID","CompName",combo,compRow);
		}

        void UpdateComboBoxesBasedOnCompany(object companyIDObj,
            DataTable table, string idField, string valueField,
            object comboID,
            AutoCompleteComboBox combo)
        {
            if (companyIDObj is DBNull)
            {
                combo.Items.Clear();
            }
            int companyID = (int)companyIDObj;
            string filter = "CompID = " + companyID;
            DataView locationView = new DataView(table, filter, valueField,
                DataViewRowState.CurrentRows);
            DataRow locationRow = null;
            if (!(comboID is DBNull))
                locationRow = locationView.Table.Rows.Find(comboID);
            DataInterface.UpdateComboBox(locationView, idField, valueField,
                combo, locationRow);
        }


		void UpdateLocationCombo(object companyIDObj,
			AutoCompleteComboBox combo,
			object locationID,AutoCompleteTextBox address,
			AutoCompleteTextBox country,
            AutoCompleteComboBox contactCombo,
            object contactIDObj)
		{
			address.Text = "";
			country.Text = "";
            UpdateComboBoxesBasedOnCompany(companyIDObj,
                m_emDataSet.LocationTbl, "LocID", "LocName", locationID,
                combo);
            UpdateComboBoxesBasedOnCompany(companyIDObj, m_emDataSet.ContactsTbl,
                "ContactID", "LastName", contactIDObj, contactCombo);
            EMDataSet.LocationTblRow locationRow = null;
            if (!(locationID is DBNull))
                locationRow = m_emDataSet.LocationTbl.FindByLocID((int)locationID);
			if (locationRow!=null)
			{
				address.Text = locationRow.Address;
				country.Text = locationRow.CountryTblRow.CountryName;
			}
		}

		void UpdateMillCombo()
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			object millID = row["MillID"];
			UpdateCompanyCombo("Vendor",millCombo,millID);
			UpdateMillLocationCombo();
		}
		void UpdateMillLocationCombo()
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			object millID = row["MillID"];
			UpdateLocationCombo(millID,this.millLocationCombo,row["MillLocationID"],
				millAddressEdt,millCountryEdt,millContactCombo,
                row["VendContactID"]);
		}
		void UpdateCustomerCombo()
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			object customerID = row["CustomerID"];
			UpdateCompanyCombo("Customer",customerCombo,customerID);
			UpdateCustomerLocationCombo();
		}
		void UpdateCustomerLocationCombo()
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			object customerID = row["CustomerID"];
			UpdateLocationCombo(customerID,this.customerLocationCombo,row["CustomerLocationID"]
				,customerAddressEdt,customerCountryEdt,custContactCombo,
                row["ShipToContactID"]);
		 }
		
		static void Enable(Object o,bool enable)
		{
			AutoCompleteComboBox combo = o as AutoCompleteComboBox;
			if (combo != null)
				combo.Enabled = enable;
			AutoCompleteTextBox text = o as AutoCompleteTextBox;
			if (text != null)
				text.ReadOnly = !enable;
		}
		static void SetText(object o,string text)
		{
			AutoCompleteComboBox combo = o as AutoCompleteComboBox;
			if (combo != null)
				combo.Text = text;
			AutoCompleteTextBox textBox = o as AutoCompleteTextBox;
			if (textBox != null)
				textBox.Text = text;
		}
		static string GetText(object o)
		{
			AutoCompleteComboBox combo = o as AutoCompleteComboBox;
			if (combo != null)
				return combo.Text;
			AutoCompleteTextBox text = o as AutoCompleteTextBox;
			if (text != null)
				return text.Text;
			throw new Exception("Could not convert to a text box or combo");
		}
		public void UpdateEnabled() 
		{
			int start = 1000;
			bool isEmptyTable = IsEmptyTable();
			if (isEmptyTable)
				start = 0;
			for (int i=0;i<m_textBoxes.Length;i++)
			{
				if (i<start)
					Enable(m_textBoxes[i],true);
				else
					Enable(m_textBoxes[i],false);
			}
			for (int i=0;i<m_dateBoxes.Length;i++)
			{
				Enable(m_dateBoxes[i],!isEmptyTable);
			}
			for (int i=0;i<m_dateSelections.Length;i++)
			{
				m_dateSelections[i].Enabled = !isEmptyTable;
			}
			m_exchangeRateEdt.Enabled = !isEmptyTable;
			
			poGrid.Enabled = !isEmptyTable;

			if (!isEmptyTable)
				UpdateCancelControls();
            if (GetHeaderRow().RowState == DataRowState.Added)
            {
                m_purchaseEdt.ReadOnly = false;
            }
            else
                m_purchaseEdt.ReadOnly = true;
            changeBtn.Enabled = m_purchaseEdt.ReadOnly;
		}

		void UpdateCancelControls()
		{
			bool isCancelled = m_statusCombo.Text =="Cancelled";
			m_cancelDateEdt.Enabled = isCancelled;
		}
		Button[] m_dateSelections;
		QuickGrid containerCheckGrid = new QuickGrid();
		QuickGrid weightGrid = new QuickGrid();
		QuickGrid poGrid = new QuickGrid();
        QuickGrid millConfirmationGrid = new QuickGrid();
		QuickGrid containerItemSummaryGrid = new QuickGrid();
		public PO(int poid,int poItemNumber,int contid,int bundleIDNumber)
		{
			m_currentKey = poid;
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			SetupQuickGrid.DoIt(containerCheckGrid,this.containerTrackingPanel);
			SetupQuickGrid.DoIt(weightGrid,this.weightPage);
			SetupQuickGrid.DoIt(poGrid,purchaseOrderPage);

            SetupQuickGrid.DoIt(millConfirmationGrid, millConfirmationPage);
			SetupQuickGrid.DoIt(containerItemSummaryGrid,containerItemDetailsPanel);
			containerCheckGrid.m_onNewFocus = new EM.QuickGrid.OnNewFocusDelegate
											(this.OnContainerCheckGridFocusChanged);
			m_textBoxes = new object[]{m_statusCombo,m_purchaseEdt,
										  m_shipCodeCombo,m_fobEdt,m_termsCombo,
										  m_commentEdt,millConfirmationNumberEdit,
                invoiceEdt
										  };
			m_fieldNames = new String[]{"Status","PONumber",
										   "ShipCode","FOB","Terms",
										   "Comments","MillConfirmationNumber","InvoiceNumber"
										  };

			

			m_dateBoxes = new AutoCompleteTextBox[]{m_cancelDateEdt,m_dateEdt,ackDateEdt,
													exchangeDateEdt,
													this.ackRevisedDateEdt,
                            this.invoiceDateEdt};
			m_dateFieldNames = new string[]{"CancelDate","PODate","MillAcknowledgeDate","ExchangeDate"
											,"MillAcknowledgeDateRevised",
            "InvoiceDate"};
			m_dateSelections = new Button[]{m_cancelDateBtn,m_dateBtn,ackDateBtn,exchangeDateBtn
											,this.ackRevisedDateBtn,invoiceDateBtn};
			base.Refresh();
            if (contid != 0)
            {
                m_tabControl.SelectedIndex = 2;
                UpdateGrid();
                EMDataSet.POItemTblRow row = m_emDataSet.POItemTbl.FindByPOItemNumber(poItemNumber);
                containerCheckGrid.SetNewFocus(row.SeqNumber - 1, 0);
                FormSupport.SetupContainerItemSummaryGrid(m_emDataSet, containerItemSummaryGrid, poItemNumber,bundleIDNumber);
            }
		}

		EMDataSet millDataSet = new EMDataSet();
		EMDataSet customerDataSet = new EMDataSet();


		
		private void OnLocationChanged(EMDataSet dataSet,AutoCompleteComboBox box,
			AutoCompleteTextBox addressEdt,AutoCompleteTextBox countryEdt,
			AutoCompleteComboBox companyCombo)
		{
			int locationID = ((TaggedItem)box.SelectedItem).key;
			EMDataSet.LocationTblRow row = dataSet.LocationTbl.FindByLocID(locationID);
			int countryID = row.CountryID;
			EMDataSet.CountryTblRow countryRow = dataSet.CountryTbl.FindByCountryID(countryID);
			addressEdt.Text = row.Address;
			countryEdt.Text = countryRow.CountryName;
			box.Text = row.LocName;
		}
		private void OnContactChanged(EMDataSet dataSet,AutoCompleteComboBox box,AutoCompleteTextBox contactEdt,
			AutoCompleteTextBox phoneEdt,AutoCompleteTextBox faxEdt,AutoCompleteTextBox emailEdt)
		{
			TaggedItem item = (TaggedItem)box.SelectedItem;
			int contactsID = item.key;
			EMDataSet.ContactsTblRow row = dataSet.ContactsTbl.FindByContactID(contactsID);
			contactEdt.Text = row.FirstName + " " + row.LastName;
			phoneEdt.Text = row.Phone;
			faxEdt.Text = row.Fax;
			emailEdt.Text = row.EMail;
		}
		private void OnMillLocationChanged(object sender, System.EventArgs e)
		{
			if (allowComboBoxUpdates)
			{
				using (new StopComboBoxUpdates(this))
				{
					EMDataSet.POHeaderTblRow row = GetHeaderRow();
					TaggedItem tagged = (TaggedItem)millLocationCombo.SelectedItem;
					row.MillLocationID = tagged.key;
					UpdateMillLocationCombo();				}
			}
		}
		private void OnShipToLocationChanged(object sender, System.EventArgs e)
		{
			if (allowComboBoxUpdates)
			{
				using (new StopComboBoxUpdates(this))
				{
					EMDataSet.POHeaderTblRow row = GetHeaderRow();
					TaggedItem tagged = (TaggedItem)customerLocationCombo.SelectedItem;
					row.CustomerLocationID = tagged.key;
					UpdateCustomerLocationCombo();
				}
			}
		}
        private void OnMillContactChanged(object sender, EventArgs e)
        {
            EMDataSet.POHeaderTblRow row = GetHeaderRow();
            TaggedItem tagged = (TaggedItem)millContactCombo.SelectedItem;
            row.VendContactID = tagged.key;
        }

        private void OnCustomerContactChanged(object sender, EventArgs e)
        {
            EMDataSet.POHeaderTblRow row = GetHeaderRow();
            TaggedItem tagged = (TaggedItem)custContactCombo.SelectedItem;
            row.ShipToContactID = tagged.key;
        }

		bool allowComboBoxUpdates = true;
		private void OnCompanyChanged(object sender, System.EventArgs e)
		{
	
			if (allowComboBoxUpdates)
			{
				using (new StopComboBoxUpdates(this))
				{
					AutoCompleteComboBox box = (AutoCompleteComboBox)sender;
					object selected = box.SelectedItem;
					TaggedItem tagged = (TaggedItem)selected;
					int key = tagged.key;
					EMDataSet.POHeaderTblRow row = GetHeaderRow();
					if (sender == millCombo)
					{
						
						row.MillID = key;
						row.SetMillLocationIDNull();
						UpdateMillCombo();
					}
					else
					{
						FromGrid(0);
						if (DoesItemNameExist())
						{
							MessageBox.Show("You are only allowed to change the customer if there " + 
								"no items in the Purchase Order");
							foreach (TaggedItem item in box.Items)
							{
								if (item.key == row.CustomerID)
								{
									box.SelectedItem = item;
									return;
								}
							}
							Debug.Assert(false);
							return;
						}
						row.CustomerID = key;
						row.SetCustomerLocationIDNull();
						UpdateCustomerCombo();
					}
				}
			}
		}
		void FixUM(string newUM)
		{
			FromControls();
			FixUMButNoUpdates(newUM);
			UpdateControls();
		}
		void FixUMButNoUpdates(string newUM)
		{
			EMDataSet.POItemTblRow[] rows = GetAllDetailRows();
			foreach (EMDataSet.POItemTblRow row in rows)
			{
				if (row.IsQtyNull())
				{
					row.SetUMNull();
				}
				else
				{
					row.UM = newUM;
				}
			}
		}

		private void insertRowBtn_Click(object sender, System.EventArgs e)
		{
			FromSelectedGrid();
			EMDataSet.POItemTblRow rowCurrent = 
                HelperFunctions.GetCurrentRow(poGrid,
                m_emDataSet.POItemTbl);
			if (rowCurrent == null)
				return;
			int seqNumber = rowCurrent.SeqNumber;
			EMDataSet.POItemTblRow newRow = m_emDataSet.POItemTbl.NewPOItemTblRow();
			newRow.POID = base.CurrentKey;
			newRow.POItemNumber = DataInterface.GetNextKeyNumber("tblPOItem2");
			newRow.SeqNumber = seqNumber;
		foreach (EMDataSet.POItemTblRow row in m_emDataSet.POItemTbl.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (row.SeqNumber >= seqNumber)
				{
					row.SeqNumber++;
				}
			}
			m_emDataSet.POItemTbl.AddPOItemTblRow(newRow);
			UpdateGrid();
		}

		private void removeItemBtn_Click(object sender, System.EventArgs e)
		{
			FromSelectedGrid();
			decimal total = 0;
			EMDataSet.POItemTblRow rowDelete = 
				HelperFunctions.GetCurrentRow(poGrid,m_emDataSet.POItemTbl);
			if (rowDelete != null)
			{
				if (!rowDelete.IsAcknowledgeDateNull())
				{
					MessageBox.Show("Item can not be removed since it has already been acknowledged.\n" +
									"Remove acknowledgement date first.","Can't remove acknowledged item",
									MessageBoxButtons.OK,MessageBoxIcon.Stop);
					return;
				}
				int oldSeqNumber = rowDelete.SeqNumber;
				rowDelete.Delete();
				foreach (EMDataSet.POItemTblRow currentRow in m_emDataSet.POItemTbl.Rows)
				{
					if (!DataInterface.IsRowAlive(currentRow))
						continue;
					if (!currentRow.IsCustAmountNull())
						total += currentRow.CustAmount;
					if (currentRow.SeqNumber > oldSeqNumber)
						currentRow.SeqNumber--;
				}
				UpdateGrid();
				NewGridTotal(total);
				
			}
		}
		private void SelectDateBtn(object sender, System.EventArgs e)
		{
			// first find the control
			int i=0;
			for (i=0;i<m_dateSelections.Length;i++)
			{
				if (sender == m_dateSelections[i])
				{
					break;
				}
			}
			Debug.Assert(i!= m_dateSelections.Length);
			string fieldName = m_dateFieldNames[i];
			AutoCompleteTextBox box = m_dateBoxes[i];
			Debug.Assert(i!=m_dateSelections.Length);
			DataRow row = GetHeaderRow();
			System.DateTime dateTime;
			if (row.IsNull(fieldName))
				dateTime = System.DateTime.Today;
			else
				dateTime = (DateTime)row[fieldName];
			if (DialogResult.OK == DateTimeSelector.RequestTime(ref dateTime))
				box.Text = HelperFunctions.ToDateText(dateTime);
		}

		private void Swap(EMDataSet.POItemTblRow row1,EMDataSet.POItemTblRow row2)
		{
			if (row1 == null)
				return;
			if (row2 == null)
				return;
			int tempSeq = row1.SeqNumber;
			row1.SeqNumber = row2.SeqNumber;
			row2.SeqNumber = tempSeq;
		}
		private void moveUpBtn_Click(object sender, System.EventArgs e)
		{
			FromSelectedGrid();
			EMDataSet.POItemTblRow previousRow = HelperFunctions.GetCurrentRow(poGrid,m_emDataSet.POItemTbl);
			if (previousRow == null)
				return;
			EMDataSet.POItemTblRow nextRow = HelperFunctions.GetRowFromSeqNumber(m_emDataSet.POItemTbl,previousRow.SeqNumber-1);
			Swap(previousRow,nextRow);
			UpdateGrid();
		}

		private void moveDownBtn_Click(object sender, System.EventArgs e)
		{
			FromSelectedGrid();
			EMDataSet.POItemTblRow previousRow = HelperFunctions.GetCurrentRow(poGrid,m_emDataSet.POItemTbl);
			if (previousRow == null)
				return;
			EMDataSet.POItemTblRow nextRow = HelperFunctions.GetRowFromSeqNumber(m_emDataSet.POItemTbl,
				previousRow.SeqNumber+1);
			Swap(previousRow,nextRow);
			UpdateGrid();
		}

		private int GetPOIDFromPONumber(string poNumber)
		{
			string poNumberWithQuotes = "'" + DataInterface.ExpandQuotes(poNumber) + "'";
			int key = base.GetKeyFromField("PONumber",poNumberWithQuotes);
			return key;
		}

		public override void OnFind()
		{
			int po = Chooser.GetPO(AdapterHelper.Connection);
            if (po == 0)
                return;
			try
			{
				base.CurrentKey = po;
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

		
		EMDataSet.POItemTblRow[] GetAllDetailRows()
		{
            DataRow[] rowsGen = GetHeaderRow().GetPOItemTblRows();
			EMDataSet.POItemTblRow[] rows = (EMDataSet.POItemTblRow[])rowsGen;
			return rows;
		}
		
		private void OnCollapseChanged(object sender, System.EventArgs e)
		{
			if (!TryToCommit())
				return;
			Refresh();
		}
		private void OnAckCurrentCellChanged(object sender, System.EventArgs e)
		{
			DataGrid grid = (DataGrid)sender;
			poGrid.SetNewFocus(grid.CurrentCell.RowNumber,grid.CurrentCell.ColumnNumber);
		}

		void PrintIt(string reportType,bool preview)
		{
			object application = null;
			object doCmd = null;
			try 
			{
				FixUMButNoUpdates(this.umCombo.Text);
				if (TryToCommit(true,MessageBoxButtons.OKCancel) == false)
					return;
				bool doesItemNameExist = DoesItemNameExist();
				if (!doesItemNameExist)
				{
					MessageBox.Show("Error: Unable to print a purchase order without any items." +
									" There must be at least one item name");
					return;
				}
				Type tApp = Type.GetTypeFromProgID("Access.Application");
				application = Activator.CreateInstance(tApp);
				object [] args = new object[]
				{
					"M:\\em_prog_2002.mdb"
				};
				tApp.InvokeMember("OpenCurrentDatabase",BindingFlags.InvokeMethod,null,application,args);
				doCmd = tApp.InvokeMember("DoCmd",BindingFlags.GetProperty,null,application,new object[0]);
				Type tDoCmd = doCmd.GetType();
				object [] reportArgs = new object[]
					{
						"rptJEMPO",
						preview?2:0,// 0 is normal 2 is preview
						Type.Missing,
						Type.Missing,
						3,//Type.Missing, // 3dialog
						"POID=" + GetHeaderRow().POID + ";RptType="+reportType
					};

				tDoCmd.InvokeMember("OpenReport",BindingFlags.InvokeMethod,null,doCmd,reportArgs);
				tApp.InvokeMember("Quit",BindingFlags.InvokeMethod,null,application,new object[0]);
			}
			catch(TargetInvocationException ex)
			{
				MessageBox.Show(ex.InnerException.Message);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				if (application!=null)
					Marshal.ReleaseComObject(application);
				if (doCmd != null)
					Marshal.ReleaseComObject(doCmd);
			}

		}
		private void previewPOBtn_Click(object sender, System.EventArgs e)
		{
			PrintIt("PO",true);
		}

		private void previewAckBtn_Click(object sender, System.EventArgs e)
		{
			PrintIt("Ack",true);
		}

		private void printPOBtn_Click(object sender, System.EventArgs e)
		{
			if (!TryToCommit())
				return;
			CrystalViewer view = new CrystalViewer(m_emDataSet,true);
			view.ShowDialog();
		}
		private void printAckBtn_Click(object sender, System.EventArgs e)
		{
			if (!TryToCommit())
				return;
			CrystalViewer view = new CrystalViewer(m_emDataSet,false);
			view.ShowDialog();
		}

		private void umSelectedChanged(object sender, System.EventArgs e)
		{
			if (allowComboBoxUpdates)
			{	
				DataInterface.DefaultMetric = DataInterface.IsMetric(umCombo.Text);
				FixUM(umCombo.Text);
			}
		}

		private void onStatusSelChanged(object sender, System.EventArgs e)
		{
			if (allowComboBoxUpdates)
			{
				UpdateCancelControls();
				if (m_cancelDateEdt.Enabled)
				{
					if (m_cancelDateEdt.Text == "")
					{
						m_cancelDateEdt.Text = HelperFunctions.ToDateText(DateTime.Today);
					}
				}
				else
					m_cancelDateEdt.Text = "";
			}
		
		}

		
		int lastTab = 0;
		private void OnGridTabChanged(object sender, System.EventArgs e)
		{
			if (lastTab == 0 || lastTab == 3)
				FromGrid(lastTab);
			lastTab = m_tabControl.SelectedIndex;
			UpdateGrid();
					}
		
		private void OnExchangeRateValidated(object sender, System.EventArgs e)
		{
			EMDataSet.POHeaderTblRow row = GetHeaderRow();
			try 
			{
				decimal exchangeRate = decimal.Parse(m_exchangeRateEdt.Text);
				row.ExchangeRate = exchangeRate;
			}
			catch(Exception)
			{
				row.SetExchangeRateNull();
			}
			if (!row.IsOtherTotalNull())
			{
				if (row.IsExchangeRateNull())
					row.USTotal = row.OtherTotal;
				else
					row.USTotal = row.OtherTotal * row.ExchangeRate;
			}
			UpdateCurrencyControls();
		}

		private void addNewCompanyBtn_Click(object sender, System.EventArgs e)
		{
			string companyType;
			if (sender == addNewMillBtn)
				companyType = "Vendor";
			else
				companyType = "Customer";
			AddNewCompany dlg = new AddNewCompany(companyType);
			DialogResult res = dlg.ShowDialog();
			if (res == DialogResult.Cancel)
				return;
			if (dlg.GetCompanyName() == "")
				return;
			AdapterHelper.FillCompanyFromCompID(m_emDataSet,dlg.GetCompanyID());
			using (new StopComboBoxUpdates(this))	
			{
				if (sender == addNewMillBtn)
					UpdateMillCombo();
				else
					UpdateCustomerCombo();
			}
			AutoCompleteComboBox box;
			if (sender == addNewMillBtn)
				box = millCombo;
			else
				box = customerCombo;
			
			box.Text = dlg.GetCompanyName();
		}
		private void addNewLocationBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				AutoCompleteComboBox box;
				if (sender == addNewMillLocationBtn)
				{
					box = millLocationCombo;
				}
				else
				{
					box = customerLocationCombo;
				}
			
				EMDataSet.POHeaderTblRow row = GetHeaderRow();
				object compIDObj;
				if (sender == addNewMillLocationBtn)
					compIDObj = row["MillID"];
				else
					compIDObj = row["CustomerID"];
				if (compIDObj is DBNull)
					throw new Exception("No company was selected. Company must be "
						+   "selected before a location can be added");
				int compID = (int)compIDObj;
				AddNewLocation dlg = new AddNewLocation(compID);
				DialogResult res = dlg.ShowDialog();
				if (res != DialogResult.OK)
					return;
				
				AdapterHelper.FillLocations(m_emDataSet,compID);
				if (sender == addNewMillLocationBtn)
				{
					row["MillLocationID"] = dlg.m_locationID;
					UpdateMillLocationCombo();
				}
				else
				{
					row["CustomerLocationID"] = dlg.m_locationID;
					UpdateCustomerLocationCombo();
				}
				
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

		}

		private void OnContainerCheckGridFocusChanged(int currentRow,int column)
		{
			DataTable table = containerCheckGrid.GetTableQuietly();
			if (currentRow >= table.Rows.Count)
				return;
			int itemNumber = (int)table.Rows[containerCheckGrid.GetCurrentIndex().row]["POItemNumber"];
			FormSupport.SetupContainerItemSummaryGrid(m_emDataSet,containerItemSummaryGrid,itemNumber);
		}

		private void goToContainerBtn_Click(object sender, System.EventArgs e)
		{
			DataTable table = containerItemSummaryGrid.GetTable();
			int currentRow = containerItemSummaryGrid.GetCurrentIndex().row;
			if (currentRow >= table.Rows.Count)
				return;
			try
			{
				TryToCommit();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			int contID = (int)table.Rows[currentRow]["ContID"];
            int contBundleID = (int)table.Rows[currentRow]["ContainerBundleID"];
			MainWindow window = (MainWindow)this.Parent.Parent;
			window.CreateContainerForm(contID,contBundleID);
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


		private void button1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Sorry, not yet implemented - Johan");
		
		}		
		

		private void showGradeTotalsBtn_Click(object sender, System.EventArgs e)
		{
			
			GenericCrystalViewer v = new GenericCrystalViewer();
			v.Text = "Monthly Sales View";
			POItemReport report = new POItemReport();
            EMDataSet copyDataSet = (EMDataSet)m_emDataSet.Copy();
            foreach (EMDataSet.POItemTblRow itemRow in copyDataSet.POItemTbl)
            {
                if (!itemRow.IsCancelDateNull())
                {
                    itemRow.Delete();
                    continue;
                }
                if (itemRow.POID != GetHeaderRow().POID)
                    itemRow.Delete();
            }
            copyDataSet.AcceptChanges();
			report.SetDataSource(copyDataSet);
			v.viewer.ReportSource = report;
			v.Show();
		
		}
		
		private void OnStatusTextChanged(object sender, System.EventArgs e)
		{
			statusLabel.Text = ((EM.AutoCompleteComboBox)sender).Text;
			if (statusLabel.Text == "Cancelled")
				statusLabel.BackColor = Color.Red;
			else
			if (statusLabel.Text == "Open")
				statusLabel.BackColor= Color.LightGreen;
			else if (statusLabel.Text == "Closed")
				statusLabel.BackColor = Color.Gray;
			else
				statusLabel.BackColor = Color.Gray;
		
		}
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.m_statusCombo = new EM.AutoCompleteComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dateEdt = new EM.AutoCompleteTextBox();
            this.m_dateBtn = new System.Windows.Forms.Button();
            this.m_shipCodeCombo = new EM.AutoCompleteComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_fobEdt = new EM.AutoCompleteTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_termsCombo = new EM.AutoCompleteComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_exchangeRateEdt = new EM.AutoCompleteTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cancelDateEdt = new EM.AutoCompleteTextBox();
            this.m_cancelDateBtn = new System.Windows.Forms.Button();
            this.m_commentEdt = new EM.AutoCompleteTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnApplyConfirmationToEntirePO = new System.Windows.Forms.CheckBox();
            this.invoiceGroup = new System.Windows.Forms.GroupBox();
            this.invoiceEdt = new EM.AutoCompleteTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.invoiceDateEdt = new EM.AutoCompleteTextBox();
            this.invoiceDateBtn = new System.Windows.Forms.Button();
            this.ackRevisedDateBtn = new System.Windows.Forms.Button();
            this.ackRevisedDateEdt = new EM.AutoCompleteTextBox();
            this.revisedAckLabel = new System.Windows.Forms.Label();
            this.surchargeCheck = new System.Windows.Forms.CheckBox();
            this.exchangeDateBtn = new System.Windows.Forms.Button();
            this.exchangeDateEdt = new EM.AutoCompleteTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.currencyCombo = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.ackDateBtn = new System.Windows.Forms.Button();
            this.ackDateEdt = new EM.AutoCompleteTextBox();
            this.labelAckDate = new System.Windows.Forms.Label();
            this.millConfirmationNumberEdit = new EM.AutoCompleteTextBox();
            this.labelMillConfirmation = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.addNewCustomerLocationBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.customerLocationCombo = new EM.AutoCompleteComboBox();
            this.customerCombo = new EM.AutoCompleteComboBox();
            this.customerCountryEdt = new EM.AutoCompleteTextBox();
            this.customerAddressEdt = new EM.AutoCompleteTextBox();
            this.addNewCustomerBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.addNewMillLocationBtn = new System.Windows.Forms.Button();
            this.addNewMillBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.millCombo = new EM.AutoCompleteComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.millLocationCombo = new EM.AutoCompleteComboBox();
            this.millCountryEdt = new EM.AutoCompleteTextBox();
            this.millAddressEdt = new EM.AutoCompleteTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.umCombo = new EM.AutoCompleteComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addMillContact = new System.Windows.Forms.Button();
            this.millContactCombo = new EM.AutoCompleteComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addCustomerContact = new System.Windows.Forms.Button();
            this.custContactCombo = new EM.AutoCompleteComboBox();
            this.commentPage = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.m_totalCostEdit = new EM.AutoCompleteTextBox();
            this.m_totalCostUSEdit = new EM.AutoCompleteTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.removeItemBtn = new System.Windows.Forms.Button();
            this.moveUpBtn = new System.Windows.Forms.Button();
            this.moveDownBtn = new System.Windows.Forms.Button();
            this.printPOBtn = new System.Windows.Forms.Button();
            this.printAckBtn = new System.Windows.Forms.Button();
            this.m_purchaseEdt = new EM.AutoCompleteTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.showGradeTotalsBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.purchaseOrderPage = new System.Windows.Forms.TabPage();
            this.weightPage = new System.Windows.Forms.TabPage();
            this.containerTrackingPage = new System.Windows.Forms.TabPage();
            this.containerTrackingPanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.containerItemDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.containerItemDetailsPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshContainerItemtn = new System.Windows.Forms.Button();
            this.goToContainerBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.insertRowBtn = new System.Windows.Forms.Button();
            this.millConfirmationPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.invoiceGroup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.commentPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.containerTrackingPage.SuspendLayout();
            this.containerItemDetailsGroupBox.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "PO No.:";
            // 
            // m_statusCombo
            // 
            this.m_statusCombo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_statusCombo.ItemHeight = 13;
            this.m_statusCombo.Items.AddRange(new object[] {
            "Open",
            "Cancelled",
            "Closed"});
            this.m_statusCombo.Location = new System.Drawing.Point(120, 32);
            this.m_statusCombo.Name = "m_statusCombo";
            this.m_statusCombo.Size = new System.Drawing.Size(96, 21);
            this.m_statusCombo.TabIndex = 4;
            this.m_statusCombo.SelectedIndexChanged += new System.EventHandler(this.onStatusSelChanged);
            this.m_statusCombo.TextChanged += new System.EventHandler(this.OnStatusTextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "PO Date";
            // 
            // m_dateEdt
            // 
            this.m_dateEdt.Location = new System.Drawing.Point(120, 8);
            this.m_dateEdt.Name = "m_dateEdt";
            this.m_dateEdt.Size = new System.Drawing.Size(96, 20);
            this.m_dateEdt.TabIndex = 1;
            this.m_dateEdt.Leave += new System.EventHandler(this.OnDateLeave);
            // 
            // m_dateBtn
            // 
            this.m_dateBtn.Location = new System.Drawing.Point(224, 8);
            this.m_dateBtn.Name = "m_dateBtn";
            this.m_dateBtn.Size = new System.Drawing.Size(24, 24);
            this.m_dateBtn.TabIndex = 2;
            this.m_dateBtn.Text = "...";
            this.m_dateBtn.Click += new System.EventHandler(this.SelectDateBtn);
            // 
            // m_shipCodeCombo
            // 
            this.m_shipCodeCombo.Location = new System.Drawing.Point(120, 104);
            this.m_shipCodeCombo.Name = "m_shipCodeCombo";
            this.m_shipCodeCombo.Size = new System.Drawing.Size(120, 21);
            this.m_shipCodeCombo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ship Via:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "FOB:";
            // 
            // m_fobEdt
            // 
            this.m_fobEdt.Location = new System.Drawing.Point(120, 128);
            this.m_fobEdt.Name = "m_fobEdt";
            this.m_fobEdt.Size = new System.Drawing.Size(120, 20);
            this.m_fobEdt.TabIndex = 13;
            this.m_fobEdt.Text = "textBox1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Terms:";
            // 
            // m_termsCombo
            // 
            this.m_termsCombo.Location = new System.Drawing.Point(120, 80);
            this.m_termsCombo.Name = "m_termsCombo";
            this.m_termsCombo.Size = new System.Drawing.Size(121, 21);
            this.m_termsCombo.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Exchange Rate: $/x";
            // 
            // m_exchangeRateEdt
            // 
            this.m_exchangeRateEdt.Location = new System.Drawing.Point(120, 200);
            this.m_exchangeRateEdt.Name = "m_exchangeRateEdt";
            this.m_exchangeRateEdt.Size = new System.Drawing.Size(120, 20);
            this.m_exchangeRateEdt.TabIndex = 19;
            this.m_exchangeRateEdt.Text = "textBox1";
            this.m_exchangeRateEdt.Validated += new System.EventHandler(this.OnExchangeRateValidated);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Cancel Date:";
            // 
            // m_cancelDateEdt
            // 
            this.m_cancelDateEdt.Location = new System.Drawing.Point(120, 56);
            this.m_cancelDateEdt.Name = "m_cancelDateEdt";
            this.m_cancelDateEdt.Size = new System.Drawing.Size(96, 20);
            this.m_cancelDateEdt.TabIndex = 6;
            this.m_cancelDateEdt.Leave += new System.EventHandler(this.OnDateLeave);
            // 
            // m_cancelDateBtn
            // 
            this.m_cancelDateBtn.Location = new System.Drawing.Point(224, 56);
            this.m_cancelDateBtn.Name = "m_cancelDateBtn";
            this.m_cancelDateBtn.Size = new System.Drawing.Size(24, 24);
            this.m_cancelDateBtn.TabIndex = 7;
            this.m_cancelDateBtn.Text = "...";
            this.m_cancelDateBtn.Click += new System.EventHandler(this.SelectDateBtn);
            // 
            // m_commentEdt
            // 
            this.m_commentEdt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_commentEdt.Location = new System.Drawing.Point(0, 0);
            this.m_commentEdt.Multiline = true;
            this.m_commentEdt.Name = "m_commentEdt";
            this.m_commentEdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_commentEdt.Size = new System.Drawing.Size(1008, 261);
            this.m_commentEdt.TabIndex = 23;
            this.m_commentEdt.Text = "textBox1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.commentPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 288);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnApplyConfirmationToEntirePO);
            this.tabPage1.Controls.Add(this.invoiceGroup);
            this.tabPage1.Controls.Add(this.ackRevisedDateBtn);
            this.tabPage1.Controls.Add(this.ackRevisedDateEdt);
            this.tabPage1.Controls.Add(this.revisedAckLabel);
            this.tabPage1.Controls.Add(this.surchargeCheck);
            this.tabPage1.Controls.Add(this.exchangeDateBtn);
            this.tabPage1.Controls.Add(this.exchangeDateEdt);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.currencyCombo);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.ackDateBtn);
            this.tabPage1.Controls.Add(this.ackDateEdt);
            this.tabPage1.Controls.Add(this.labelAckDate);
            this.tabPage1.Controls.Add(this.millConfirmationNumberEdit);
            this.tabPage1.Controls.Add(this.labelMillConfirmation);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.umCombo);
            this.tabPage1.Controls.Add(this.m_dateBtn);
            this.tabPage1.Controls.Add(this.m_dateEdt);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.m_cancelDateBtn);
            this.tabPage1.Controls.Add(this.m_cancelDateEdt);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.m_exchangeRateEdt);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.m_termsCombo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.m_fobEdt);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.m_shipCodeCombo);
            this.tabPage1.Controls.Add(this.m_statusCombo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1008, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnApplyConfirmationToEntirePO
            // 
            this.btnApplyConfirmationToEntirePO.AutoSize = true;
            this.btnApplyConfirmationToEntirePO.Location = new System.Drawing.Point(377, 184);
            this.btnApplyConfirmationToEntirePO.Name = "btnApplyConfirmationToEntirePO";
            this.btnApplyConfirmationToEntirePO.Size = new System.Drawing.Size(172, 17);
            this.btnApplyConfirmationToEntirePO.TabIndex = 41;
            this.btnApplyConfirmationToEntirePO.Text = "Apply Confirmation to entire PO";
            this.btnApplyConfirmationToEntirePO.UseVisualStyleBackColor = true;
            this.btnApplyConfirmationToEntirePO.CheckedChanged += new System.EventHandler(this.OnApplyConfirmationChanged);
            // 
            // invoiceGroup
            // 
            this.invoiceGroup.Controls.Add(this.invoiceEdt);
            this.invoiceGroup.Controls.Add(this.label30);
            this.invoiceGroup.Controls.Add(this.label28);
            this.invoiceGroup.Controls.Add(this.invoiceDateEdt);
            this.invoiceGroup.Controls.Add(this.invoiceDateBtn);
            this.invoiceGroup.Location = new System.Drawing.Point(374, 208);
            this.invoiceGroup.Name = "invoiceGroup";
            this.invoiceGroup.Size = new System.Drawing.Size(328, 48);
            this.invoiceGroup.TabIndex = 40;
            this.invoiceGroup.TabStop = false;
            this.invoiceGroup.Text = "EM Invoice - prepay customers only";
            // 
            // invoiceEdt
            // 
            this.invoiceEdt.Location = new System.Drawing.Point(56, 16);
            this.invoiceEdt.Name = "invoiceEdt";
            this.invoiceEdt.Size = new System.Drawing.Size(120, 20);
            this.invoiceEdt.TabIndex = 33;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(184, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(32, 16);
            this.label30.TabIndex = 37;
            this.label30.Text = "Date:";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(8, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 16);
            this.label28.TabIndex = 32;
            this.label28.Text = "Number:";
            // 
            // invoiceDateEdt
            // 
            this.invoiceDateEdt.Location = new System.Drawing.Point(224, 16);
            this.invoiceDateEdt.Name = "invoiceDateEdt";
            this.invoiceDateEdt.Size = new System.Drawing.Size(64, 20);
            this.invoiceDateEdt.TabIndex = 38;
            // 
            // invoiceDateBtn
            // 
            this.invoiceDateBtn.Location = new System.Drawing.Point(296, 16);
            this.invoiceDateBtn.Name = "invoiceDateBtn";
            this.invoiceDateBtn.Size = new System.Drawing.Size(24, 23);
            this.invoiceDateBtn.TabIndex = 39;
            this.invoiceDateBtn.Text = "...";
            this.invoiceDateBtn.Click += new System.EventHandler(this.SelectDateBtn);
            // 
            // ackRevisedDateBtn
            // 
            this.ackRevisedDateBtn.Location = new System.Drawing.Point(976, 224);
            this.ackRevisedDateBtn.Name = "ackRevisedDateBtn";
            this.ackRevisedDateBtn.Size = new System.Drawing.Size(24, 23);
            this.ackRevisedDateBtn.TabIndex = 36;
            this.ackRevisedDateBtn.Text = "...";
            this.ackRevisedDateBtn.Click += new System.EventHandler(this.SelectDateBtn);
            // 
            // ackRevisedDateEdt
            // 
            this.ackRevisedDateEdt.Location = new System.Drawing.Point(904, 224);
            this.ackRevisedDateEdt.Name = "ackRevisedDateEdt";
            this.ackRevisedDateEdt.Size = new System.Drawing.Size(64, 20);
            this.ackRevisedDateEdt.TabIndex = 35;
            // 
            // revisedAckLabel
            // 
            this.revisedAckLabel.Location = new System.Drawing.Point(776, 216);
            this.revisedAckLabel.Name = "revisedAckLabel";
            this.revisedAckLabel.Size = new System.Drawing.Size(120, 32);
            this.revisedAckLabel.TabIndex = 34;
            this.revisedAckLabel.Text = "Revised Acknowledge Date:";
            // 
            // surchargeCheck
            // 
            this.surchargeCheck.Location = new System.Drawing.Point(280, 224);
            this.surchargeCheck.Name = "surchargeCheck";
            this.surchargeCheck.Size = new System.Drawing.Size(80, 32);
            this.surchargeCheck.TabIndex = 31;
            this.surchargeCheck.Text = "Surcharge Applicable";
            // 
            // exchangeDateBtn
            // 
            this.exchangeDateBtn.Location = new System.Drawing.Point(248, 224);
            this.exchangeDateBtn.Name = "exchangeDateBtn";
            this.exchangeDateBtn.Size = new System.Drawing.Size(24, 24);
            this.exchangeDateBtn.TabIndex = 23;
            this.exchangeDateBtn.Text = "...";
            this.exchangeDateBtn.Click += new System.EventHandler(this.SelectDateBtn);
            // 
            // exchangeDateEdt
            // 
            this.exchangeDateEdt.Location = new System.Drawing.Point(120, 224);
            this.exchangeDateEdt.Name = "exchangeDateEdt";
            this.exchangeDateEdt.Size = new System.Drawing.Size(120, 20);
            this.exchangeDateEdt.TabIndex = 22;
            this.exchangeDateEdt.Text = "textBox1";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 224);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 24);
            this.label27.TabIndex = 21;
            this.label27.Text = "Exchange Date";
            // 
            // currencyCombo
            // 
            this.currencyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyCombo.Items.AddRange(new object[] {
            "one",
            "two",
            "three"});
            this.currencyCombo.Location = new System.Drawing.Point(120, 176);
            this.currencyCombo.Name = "currencyCombo";
            this.currencyCombo.Size = new System.Drawing.Size(121, 21);
            this.currencyCombo.TabIndex = 17;
            this.currencyCombo.SelectedIndexChanged += new System.EventHandler(this.OnCurrencyChanged);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 176);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 23);
            this.label26.TabIndex = 16;
            this.label26.Text = "Currency:";
            // 
            // ackDateBtn
            // 
            this.ackDateBtn.Location = new System.Drawing.Point(976, 184);
            this.ackDateBtn.Name = "ackDateBtn";
            this.ackDateBtn.Size = new System.Drawing.Size(24, 23);
            this.ackDateBtn.TabIndex = 30;
            this.ackDateBtn.Text = "...";
            this.ackDateBtn.Click += new System.EventHandler(this.SelectDateBtn);
            // 
            // ackDateEdt
            // 
            this.ackDateEdt.Location = new System.Drawing.Point(904, 184);
            this.ackDateEdt.Name = "ackDateEdt";
            this.ackDateEdt.Size = new System.Drawing.Size(64, 20);
            this.ackDateEdt.TabIndex = 29;
            // 
            // labelAckDate
            // 
            this.labelAckDate.Location = new System.Drawing.Point(776, 184);
            this.labelAckDate.Name = "labelAckDate";
            this.labelAckDate.Size = new System.Drawing.Size(104, 23);
            this.labelAckDate.TabIndex = 28;
            this.labelAckDate.Text = "Acknowledge Date:";
            // 
            // millConfirmationNumberEdit
            // 
            this.millConfirmationNumberEdit.Location = new System.Drawing.Point(650, 187);
            this.millConfirmationNumberEdit.Name = "millConfirmationNumberEdit";
            this.millConfirmationNumberEdit.Size = new System.Drawing.Size(120, 20);
            this.millConfirmationNumberEdit.TabIndex = 27;
            // 
            // labelMillConfirmation
            // 
            this.labelMillConfirmation.Location = new System.Drawing.Point(561, 179);
            this.labelMillConfirmation.Name = "labelMillConfirmation";
            this.labelMillConfirmation.Size = new System.Drawing.Size(83, 37);
            this.labelMillConfirmation.TabIndex = 26;
            this.labelMillConfirmation.Text = "Mill Confirmation#:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.addNewCustomerLocationBtn);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.customerLocationCombo);
            this.groupBox4.Controls.Add(this.customerCombo);
            this.groupBox4.Controls.Add(this.customerCountryEdt);
            this.groupBox4.Controls.Add(this.customerAddressEdt);
            this.groupBox4.Controls.Add(this.addNewCustomerBtn);
            this.groupBox4.Location = new System.Drawing.Point(672, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 168);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Customer";
            // 
            // addNewCustomerLocationBtn
            // 
            this.addNewCustomerLocationBtn.Location = new System.Drawing.Point(304, 40);
            this.addNewCustomerLocationBtn.Name = "addNewCustomerLocationBtn";
            this.addNewCustomerLocationBtn.Size = new System.Drawing.Size(16, 23);
            this.addNewCustomerLocationBtn.TabIndex = 5;
            this.addNewCustomerLocationBtn.Text = "+";
            this.addNewCustomerLocationBtn.Click += new System.EventHandler(this.addNewLocationBtn_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 3;
            this.label11.Text = "Location:";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 0;
            this.label15.Text = "Customer:";
            // 
            // customerLocationCombo
            // 
            this.customerLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerLocationCombo.Location = new System.Drawing.Point(72, 40);
            this.customerLocationCombo.Name = "customerLocationCombo";
            this.customerLocationCombo.Size = new System.Drawing.Size(224, 21);
            this.customerLocationCombo.TabIndex = 4;
            this.customerLocationCombo.SelectedIndexChanged += new System.EventHandler(this.OnShipToLocationChanged);
            // 
            // customerCombo
            // 
            this.customerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerCombo.Location = new System.Drawing.Point(72, 16);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(224, 21);
            this.customerCombo.TabIndex = 1;
            this.customerCombo.SelectedIndexChanged += new System.EventHandler(this.OnCompanyChanged);
            // 
            // customerCountryEdt
            // 
            this.customerCountryEdt.Location = new System.Drawing.Point(16, 136);
            this.customerCountryEdt.Name = "customerCountryEdt";
            this.customerCountryEdt.ReadOnly = true;
            this.customerCountryEdt.Size = new System.Drawing.Size(280, 20);
            this.customerCountryEdt.TabIndex = 7;
            this.customerCountryEdt.Text = "customerCountryEdt";
            // 
            // customerAddressEdt
            // 
            this.customerAddressEdt.Location = new System.Drawing.Point(16, 64);
            this.customerAddressEdt.Multiline = true;
            this.customerAddressEdt.Name = "customerAddressEdt";
            this.customerAddressEdt.ReadOnly = true;
            this.customerAddressEdt.Size = new System.Drawing.Size(280, 72);
            this.customerAddressEdt.TabIndex = 6;
            this.customerAddressEdt.TabStop = false;
            this.customerAddressEdt.Text = "customerAddressEdt";
            // 
            // addNewCustomerBtn
            // 
            this.addNewCustomerBtn.Location = new System.Drawing.Point(304, 16);
            this.addNewCustomerBtn.Name = "addNewCustomerBtn";
            this.addNewCustomerBtn.Size = new System.Drawing.Size(16, 23);
            this.addNewCustomerBtn.TabIndex = 2;
            this.addNewCustomerBtn.Text = "+";
            this.addNewCustomerBtn.Click += new System.EventHandler(this.addNewCompanyBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addNewMillLocationBtn);
            this.groupBox3.Controls.Add(this.addNewMillBtn);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.millCombo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.millLocationCombo);
            this.groupBox3.Controls.Add(this.millCountryEdt);
            this.groupBox3.Controls.Add(this.millAddressEdt);
            this.groupBox3.Location = new System.Drawing.Point(352, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 168);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mill";
            // 
            // addNewMillLocationBtn
            // 
            this.addNewMillLocationBtn.Location = new System.Drawing.Point(272, 40);
            this.addNewMillLocationBtn.Name = "addNewMillLocationBtn";
            this.addNewMillLocationBtn.Size = new System.Drawing.Size(16, 23);
            this.addNewMillLocationBtn.TabIndex = 6;
            this.addNewMillLocationBtn.Text = "+";
            this.addNewMillLocationBtn.Click += new System.EventHandler(this.addNewLocationBtn_Click);
            // 
            // addNewMillBtn
            // 
            this.addNewMillBtn.Location = new System.Drawing.Point(272, 16);
            this.addNewMillBtn.Name = "addNewMillBtn";
            this.addNewMillBtn.Size = new System.Drawing.Size(16, 23);
            this.addNewMillBtn.TabIndex = 2;
            this.addNewMillBtn.Text = "+";
            this.addNewMillBtn.Click += new System.EventHandler(this.addNewCompanyBtn_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Mill:";
            // 
            // millCombo
            // 
            this.millCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.millCombo.Location = new System.Drawing.Point(64, 16);
            this.millCombo.Name = "millCombo";
            this.millCombo.Size = new System.Drawing.Size(200, 21);
            this.millCombo.TabIndex = 1;
            this.millCombo.SelectedIndexChanged += new System.EventHandler(this.OnCompanyChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Location:";
            // 
            // millLocationCombo
            // 
            this.millLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.millLocationCombo.Location = new System.Drawing.Point(64, 40);
            this.millLocationCombo.Name = "millLocationCombo";
            this.millLocationCombo.Size = new System.Drawing.Size(200, 21);
            this.millLocationCombo.TabIndex = 5;
            this.millLocationCombo.SelectedIndexChanged += new System.EventHandler(this.OnMillLocationChanged);
            // 
            // millCountryEdt
            // 
            this.millCountryEdt.Location = new System.Drawing.Point(16, 136);
            this.millCountryEdt.Name = "millCountryEdt";
            this.millCountryEdt.ReadOnly = true;
            this.millCountryEdt.Size = new System.Drawing.Size(256, 20);
            this.millCountryEdt.TabIndex = 7;
            this.millCountryEdt.Text = "millCountryEdt";
            // 
            // millAddressEdt
            // 
            this.millAddressEdt.Location = new System.Drawing.Point(16, 64);
            this.millAddressEdt.Multiline = true;
            this.millAddressEdt.Name = "millAddressEdt";
            this.millAddressEdt.ReadOnly = true;
            this.millAddressEdt.Size = new System.Drawing.Size(256, 72);
            this.millAddressEdt.TabIndex = 4;
            this.millAddressEdt.TabStop = false;
            this.millAddressEdt.Text = "millAdressEdt";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Unit of Measure:";
            // 
            // umCombo
            // 
            this.umCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.umCombo.Items.AddRange(new object[] {
            "lbs",
            "kg"});
            this.umCombo.Location = new System.Drawing.Point(120, 152);
            this.umCombo.Name = "umCombo";
            this.umCombo.Size = new System.Drawing.Size(121, 21);
            this.umCombo.TabIndex = 15;
            this.umCombo.SelectedIndexChanged += new System.EventHandler(this.umSelectedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1008, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contacts";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addMillContact);
            this.groupBox1.Controls.Add(this.millContactCombo);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mill Contact";
            // 
            // addMillContact
            // 
            this.addMillContact.Location = new System.Drawing.Point(240, 16);
            this.addMillContact.Name = "addMillContact";
            this.addMillContact.Size = new System.Drawing.Size(27, 23);
            this.addMillContact.TabIndex = 14;
            this.addMillContact.Text = "+";
            this.addMillContact.UseVisualStyleBackColor = true;
            this.addMillContact.Click += new System.EventHandler(this.addMillContact_Click);
            // 
            // millContactCombo
            // 
            this.millContactCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.millContactCombo.Location = new System.Drawing.Point(8, 16);
            this.millContactCombo.Name = "millContactCombo";
            this.millContactCombo.Size = new System.Drawing.Size(224, 21);
            this.millContactCombo.TabIndex = 13;
            this.millContactCombo.SelectedIndexChanged += new System.EventHandler(this.OnMillContactChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addCustomerContact);
            this.groupBox2.Controls.Add(this.custContactCombo);
            this.groupBox2.Location = new System.Drawing.Point(304, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Contact";
            // 
            // addCustomerContact
            // 
            this.addCustomerContact.Location = new System.Drawing.Point(232, 16);
            this.addCustomerContact.Name = "addCustomerContact";
            this.addCustomerContact.Size = new System.Drawing.Size(27, 23);
            this.addCustomerContact.TabIndex = 13;
            this.addCustomerContact.Text = "+";
            this.addCustomerContact.UseVisualStyleBackColor = true;
            this.addCustomerContact.Click += new System.EventHandler(this.addCustomerContact_Click);
            // 
            // custContactCombo
            // 
            this.custContactCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.custContactCombo.Location = new System.Drawing.Point(8, 16);
            this.custContactCombo.Name = "custContactCombo";
            this.custContactCombo.Size = new System.Drawing.Size(221, 21);
            this.custContactCombo.TabIndex = 12;
            this.custContactCombo.SelectedIndexChanged += new System.EventHandler(this.OnCustomerContactChanged);
            // 
            // commentPage
            // 
            this.commentPage.BackColor = System.Drawing.SystemColors.Control;
            this.commentPage.Controls.Add(this.m_commentEdt);
            this.commentPage.Location = new System.Drawing.Point(4, 22);
            this.commentPage.Name = "commentPage";
            this.commentPage.Size = new System.Drawing.Size(1008, 262);
            this.commentPage.TabIndex = 2;
            this.commentPage.Text = "Comments";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(630, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 4;
            this.label12.Text = "Total:";
            // 
            // m_totalCostEdit
            // 
            this.m_totalCostEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_totalCostEdit.Location = new System.Drawing.Point(678, 8);
            this.m_totalCostEdit.Name = "m_totalCostEdit";
            this.m_totalCostEdit.ReadOnly = true;
            this.m_totalCostEdit.Size = new System.Drawing.Size(104, 20);
            this.m_totalCostEdit.TabIndex = 5;
            this.m_totalCostEdit.Text = "textBox1";
            this.m_totalCostEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_totalCostUSEdit
            // 
            this.m_totalCostUSEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_totalCostUSEdit.Location = new System.Drawing.Point(870, 8);
            this.m_totalCostUSEdit.Name = "m_totalCostUSEdit";
            this.m_totalCostUSEdit.ReadOnly = true;
            this.m_totalCostUSEdit.Size = new System.Drawing.Size(120, 20);
            this.m_totalCostUSEdit.TabIndex = 7;
            this.m_totalCostUSEdit.Text = "textBox2";
            this.m_totalCostUSEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(798, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 6;
            this.label13.Text = "US Total:";
            // 
            // removeItemBtn
            // 
            this.removeItemBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeItemBtn.Location = new System.Drawing.Point(328, 8);
            this.removeItemBtn.Name = "removeItemBtn";
            this.removeItemBtn.Size = new System.Drawing.Size(80, 24);
            this.removeItemBtn.TabIndex = 3;
            this.removeItemBtn.Text = "Remove Item";
            this.removeItemBtn.Click += new System.EventHandler(this.removeItemBtn_Click);
            // 
            // moveUpBtn
            // 
            this.moveUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveUpBtn.Location = new System.Drawing.Point(120, 8);
            this.moveUpBtn.Name = "moveUpBtn";
            this.moveUpBtn.Size = new System.Drawing.Size(88, 24);
            this.moveUpBtn.TabIndex = 1;
            this.moveUpBtn.Text = "Move Item Up";
            this.moveUpBtn.Click += new System.EventHandler(this.moveUpBtn_Click);
            // 
            // moveDownBtn
            // 
            this.moveDownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveDownBtn.Location = new System.Drawing.Point(216, 8);
            this.moveDownBtn.Name = "moveDownBtn";
            this.moveDownBtn.Size = new System.Drawing.Size(104, 24);
            this.moveDownBtn.TabIndex = 2;
            this.moveDownBtn.Text = "Move Item Down";
            this.moveDownBtn.Click += new System.EventHandler(this.moveDownBtn_Click);
            // 
            // printPOBtn
            // 
            this.printPOBtn.Location = new System.Drawing.Point(8, 16);
            this.printPOBtn.Name = "printPOBtn";
            this.printPOBtn.Size = new System.Drawing.Size(48, 23);
            this.printPOBtn.TabIndex = 0;
            this.printPOBtn.Text = "&PO";
            this.printPOBtn.Click += new System.EventHandler(this.printPOBtn_Click);
            // 
            // printAckBtn
            // 
            this.printAckBtn.Location = new System.Drawing.Point(64, 16);
            this.printAckBtn.Name = "printAckBtn";
            this.printAckBtn.Size = new System.Drawing.Size(136, 23);
            this.printAckBtn.TabIndex = 1;
            this.printAckBtn.Text = "&Acknowledgement";
            this.printAckBtn.Click += new System.EventHandler(this.printAckBtn_Click);
            // 
            // m_purchaseEdt
            // 
            this.m_purchaseEdt.Location = new System.Drawing.Point(64, 16);
            this.m_purchaseEdt.Name = "m_purchaseEdt";
            this.m_purchaseEdt.Size = new System.Drawing.Size(224, 20);
            this.m_purchaseEdt.TabIndex = 1;
            this.m_purchaseEdt.Text = "textBox1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.printPOBtn);
            this.groupBox5.Controls.Add(this.printAckBtn);
            this.groupBox5.Location = new System.Drawing.Point(368, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(216, 48);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Print";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.changeBtn);
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.showGradeTotalsBtn);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_purchaseEdt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 352);
            this.panel1.TabIndex = 0;
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(288, 16);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(75, 23);
            this.changeBtn.TabIndex = 2;
            this.changeBtn.Text = "Change";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(808, 24);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(88, 24);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "asdf";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(728, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 24);
            this.label31.TabIndex = 5;
            this.label31.Text = "Status:";
            // 
            // showGradeTotalsBtn
            // 
            this.showGradeTotalsBtn.Location = new System.Drawing.Point(600, 24);
            this.showGradeTotalsBtn.Name = "showGradeTotalsBtn";
            this.showGradeTotalsBtn.Size = new System.Drawing.Size(112, 23);
            this.showGradeTotalsBtn.TabIndex = 4;
            this.showGradeTotalsBtn.Text = "Show Grade Totals";
            this.showGradeTotalsBtn.Click += new System.EventHandler(this.showGradeTotalsBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_tabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 324);
            this.panel2.TabIndex = 2;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.Add(this.purchaseOrderPage);
            this.m_tabControl.Controls.Add(this.weightPage);
            this.m_tabControl.Controls.Add(this.containerTrackingPage);
            this.m_tabControl.Controls.Add(this.millConfirmationPage);
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ItemSize = new System.Drawing.Size(86, 18);
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(1026, 324);
            this.m_tabControl.TabIndex = 0;
            this.m_tabControl.TabIndexChanged += new System.EventHandler(this.umSelectedChanged);
            this.m_tabControl.SelectedIndexChanged += new System.EventHandler(this.OnGridTabChanged);
            // 
            // purchaseOrderPage
            // 
            this.purchaseOrderPage.Location = new System.Drawing.Point(4, 22);
            this.purchaseOrderPage.Name = "purchaseOrderPage";
            this.purchaseOrderPage.Size = new System.Drawing.Size(1018, 298);
            this.purchaseOrderPage.TabIndex = 0;
            this.purchaseOrderPage.Text = "General";
            this.purchaseOrderPage.UseVisualStyleBackColor = true;
            // 
            // weightPage
            // 
            this.weightPage.Location = new System.Drawing.Point(4, 22);
            this.weightPage.Name = "weightPage";
            this.weightPage.Size = new System.Drawing.Size(1018, 298);
            this.weightPage.TabIndex = 3;
            this.weightPage.Text = "Weights";
            this.weightPage.UseVisualStyleBackColor = true;
            // 
            // containerTrackingPage
            // 
            this.containerTrackingPage.Controls.Add(this.containerTrackingPanel);
            this.containerTrackingPage.Controls.Add(this.splitter1);
            this.containerTrackingPage.Controls.Add(this.containerItemDetailsGroupBox);
            this.containerTrackingPage.Location = new System.Drawing.Point(4, 22);
            this.containerTrackingPage.Name = "containerTrackingPage";
            this.containerTrackingPage.Size = new System.Drawing.Size(1018, 298);
            this.containerTrackingPage.TabIndex = 2;
            this.containerTrackingPage.Text = "Container Tracking";
            this.containerTrackingPage.UseVisualStyleBackColor = true;
            // 
            // containerTrackingPanel
            // 
            this.containerTrackingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerTrackingPanel.Location = new System.Drawing.Point(0, 0);
            this.containerTrackingPanel.Name = "containerTrackingPanel";
            this.containerTrackingPanel.Size = new System.Drawing.Size(815, 298);
            this.containerTrackingPanel.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(815, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 298);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // containerItemDetailsGroupBox
            // 
            this.containerItemDetailsGroupBox.Controls.Add(this.containerItemDetailsPanel);
            this.containerItemDetailsGroupBox.Controls.Add(this.panel4);
            this.containerItemDetailsGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.containerItemDetailsGroupBox.Location = new System.Drawing.Point(818, 0);
            this.containerItemDetailsGroupBox.Name = "containerItemDetailsGroupBox";
            this.containerItemDetailsGroupBox.Size = new System.Drawing.Size(200, 298);
            this.containerItemDetailsGroupBox.TabIndex = 0;
            this.containerItemDetailsGroupBox.TabStop = false;
            this.containerItemDetailsGroupBox.Text = "Item Details";
            // 
            // containerItemDetailsPanel
            // 
            this.containerItemDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerItemDetailsPanel.Location = new System.Drawing.Point(3, 16);
            this.containerItemDetailsPanel.Name = "containerItemDetailsPanel";
            this.containerItemDetailsPanel.Size = new System.Drawing.Size(194, 239);
            this.containerItemDetailsPanel.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.refreshContainerItemtn);
            this.panel4.Controls.Add(this.goToContainerBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 255);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 40);
            this.panel4.TabIndex = 2;
            // 
            // refreshContainerItemtn
            // 
            this.refreshContainerItemtn.Location = new System.Drawing.Point(8, 8);
            this.refreshContainerItemtn.Name = "refreshContainerItemtn";
            this.refreshContainerItemtn.Size = new System.Drawing.Size(75, 23);
            this.refreshContainerItemtn.TabIndex = 1;
            this.refreshContainerItemtn.Text = "Refresh";
            // 
            // goToContainerBtn
            // 
            this.goToContainerBtn.Location = new System.Drawing.Point(88, 8);
            this.goToContainerBtn.Name = "goToContainerBtn";
            this.goToContainerBtn.Size = new System.Drawing.Size(96, 23);
            this.goToContainerBtn.TabIndex = 0;
            this.goToContainerBtn.Text = "Go to Container";
            this.goToContainerBtn.Click += new System.EventHandler(this.goToContainerBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.insertRowBtn);
            this.panel3.Controls.Add(this.m_totalCostEdit);
            this.panel3.Controls.Add(this.removeItemBtn);
            this.panel3.Controls.Add(this.moveUpBtn);
            this.panel3.Controls.Add(this.moveDownBtn);
            this.panel3.Controls.Add(this.m_totalCostUSEdit);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 676);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 40);
            this.panel3.TabIndex = 0;
            // 
            // insertRowBtn
            // 
            this.insertRowBtn.Location = new System.Drawing.Point(32, 8);
            this.insertRowBtn.Name = "insertRowBtn";
            this.insertRowBtn.Size = new System.Drawing.Size(75, 23);
            this.insertRowBtn.TabIndex = 0;
            this.insertRowBtn.Text = "Insert Row";
            this.insertRowBtn.Click += new System.EventHandler(this.insertRowBtn_Click);
            // 
            // millConfirmationPage
            // 
            this.millConfirmationPage.Location = new System.Drawing.Point(4, 22);
            this.millConfirmationPage.Name = "millConfirmationPage";
            this.millConfirmationPage.Size = new System.Drawing.Size(1018, 298);
            this.millConfirmationPage.TabIndex = 4;
            this.millConfirmationPage.Text = "Mill Confirmation";
            this.millConfirmationPage.UseVisualStyleBackColor = true;
            // 
            // PO
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1026, 716);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "PO";
            this.Text = "Purchase Order";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.invoiceGroup.ResumeLayout(false);
            this.invoiceGroup.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.commentPage.ResumeLayout(false);
            this.commentPage.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.containerTrackingPage.ResumeLayout(false);
            this.containerItemDetailsGroupBox.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private int AddNewContact(object compIDItem)
        {
            if (compIDItem is DBNull)
                return -1;
            int compID = (int)compIDItem;
            AddNewContact dlg = new AddNewContact();
            DialogResult res = dlg.ShowDialog();
            if (res != DialogResult.OK)
                return -1;
            string name = dlg.ContactName;
            int key = DataInterface.GetNextKeyNumber("tblContacts");
            EMDataSet.ContactsTblRow row = m_emDataSet.ContactsTbl.NewContactsTblRow();
            row.CompID = compID;
            row.FirstName = "";
            row.Phone = "";
            row.EMail = "";
            row.Fax = "";
            row.LastName = name;
            row.ContactID = key;
            m_emDataSet.ContactsTbl.AddContactsTblRow(row);
            using (new OpenConnection(IsWrite.Yes, AdapterHelper.Connection))
            {
                AdapterHelper.CommitContacts(m_emDataSet);
            }
            return key;
        }

        private void addMillContact_Click(object sender, EventArgs e)
        {
            int newKey = AddNewContact(GetHeaderRow()["MillID"]);
            if (newKey == -1)
                return;
            GetHeaderRow().VendContactID = newKey;
            UpdateMillLocationCombo();
        }

        private void addCustomerContact_Click(object sender, EventArgs e)
        {
            int newKey = AddNewContact(GetHeaderRow()["CustomerID"]);
            if (newKey == -1)
                return;
            GetHeaderRow().ShipToContactID = newKey;
            UpdateCustomerCombo();
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            m_purchaseEdt.ReadOnly = false;
            changeBtn.Enabled = false;
        }

        private void OnApplyConfirmationChanged(object sender, EventArgs e)
        {
            if (allowComboBoxUpdates)
            {
                FromControls();
                UpdateControls();
            }

        }


		













	



	}
}
