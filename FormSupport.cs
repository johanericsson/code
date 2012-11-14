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
	/// Summary description for FormSupport.
	/// </summary>
	public class FormSupport
	{
		public FormSupport()
		{}

		static public void UpdateDateControls(AutoCompleteTextBox[] dateBoxes,Button[] dateButtons,
			string[] dateFieldNames,EMDataRow row,bool isEmptyTable)
		{
			for (int i=0;i<dateBoxes.Length;i++)
			{
				dateBoxes[i].Enabled = !isEmptyTable;
				dateButtons[i].Enabled = !isEmptyTable;
				if (row.IsNull(dateFieldNames[i]))
				{
					dateBoxes[i].Text = "";
				}
				else
				{
					DateTime date = (DateTime)row[dateFieldNames[i]];
					dateBoxes[i].Text = HelperFunctions.ToDateText(date);
				}
			}
		}
		static public void FromDateControls(AutoCompleteTextBox[] dateBoxes,string[]dateFieldNames,EMDataRow row)
		{
			for (int i=0;i<dateBoxes.Length;i++)
			{
				if (dateBoxes[i].Text == "")
				{
					row[dateFieldNames[i]] = DBNull.Value;
				}
				else
				{
					row[dateFieldNames[i]] = dateBoxes[i].Text;
				}
			}
		}
		static public void FromTextControls(AutoCompleteTextBox[] textBoxes,string[] textFieldNames,EMDataRow row)
		{
			for (int i=0;i<textBoxes.Length;i++)
			{
                // Don't apply an empty string over a null field
                if (row.IsNull(textFieldNames[i]) && textBoxes[i].Text.Length == 0)
                    continue;
				row[textFieldNames[i]] = textBoxes[i].Text;
			}
		}

		static public void UpdateTextControls(AutoCompleteTextBox[] textBoxes,string[] textFieldNames,EMDataRow row,
			bool isEmptyTable)
		{
			for (int i=0;i<textBoxes.Length;i++)
			{
				textBoxes[i].Enabled = !isEmptyTable;
				if (row.IsNull(textFieldNames[i]))
				{
					textBoxes[i].Text = "";
				}
				else
				{
					textBoxes[i].Text = (string)row[textFieldNames[i]];
				}
			}
		}

		static public DialogResult OnDateBtn(object sender,Button[] dateButtons,AutoCompleteTextBox[] dateBoxes,
			string[] dateFieldNames,EMDataRow row,out DateTime dateTime)
		{
			// first find the control
			int i=0;
			for (i=0;i<dateButtons.Length;i++)
			{
				if (sender == dateButtons[i])
				{
					break;
				}
			}
			Debug.Assert(i!= dateButtons.Length);
			string fieldName = dateFieldNames[i];
			AutoCompleteTextBox box = dateBoxes[i];
			if (row.IsNull(fieldName))
				dateTime = System.DateTime.Today;
			else
				dateTime = (DateTime)row[fieldName];
			if (DialogResult.OK == DateTimeSelector.RequestTime(ref dateTime))
			{
				box.Text = HelperFunctions.ToDateText(dateTime);
				return DialogResult.OK;
			}
			return DialogResult.Cancel;
		}
		static public void OnDateLeave(object sender,AutoCompleteTextBox[] dateBoxes,string[] dateFields,
			EMDataRow row)
		{
			AutoCompleteTextBox dateBox = null;
			string dateField="";
			for (int i=0;i<dateBoxes.Length;i++)
			{
				if (sender == dateBoxes[i])
				{
					dateBox = dateBoxes[i];
					dateField = dateFields[i];
					break;
				}
			}
			Debug.Assert(dateBox != null);
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

		public static object DefaultGetBillOfLadingNumber(EMDataSet.ContBundleTblRow sourceRow)
		{
            EMDataSet.BOLItemTblRow[] bolItems = new EMDataSet.BOLItemTblRow[1];
			if (bolItems.Length > 1)
				throw new Exception("BUG, too many bill of ladings for a bundle");
			if (bolItems.Length == 0)
				return DBNull.Value;;
			EMDataSet.BOLItemTblRow bolItem = bolItems[0];
			EMDataSet.BOLTblRow bolRow = bolItem.BOLTblRow;
			return bolRow["BOLNumber"];
		}

		class BundleFieldHelper
		{
			public GetBillOfLadingNumberFunc m_getter;

			public object 
				GetBundleField(DataRow sourceRowIn,
				bool isMetric,string fieldName)
			{
				EMDataSet.ContBundleTblRow sourceRow = (EMDataSet.ContBundleTblRow)sourceRowIn;
				EMDataSet.POItemTblRow itemRow = sourceRow.POItemTblRow;
				EMDataSet.POHeaderTblRow poHeader = itemRow.POHeaderTblRow;
				string[] containerFields = {"BundleSeqNumber","Heat","BayNumber",
											   "EnglishShipQty",
											   "MetricShipQty","InvoiceNumber","MillInvoiceDate",
                                                "EMInvoiceNumber","BundleAlloySurcharge",
                                                "BundleScrapSurcharge",
                                                "PickupDate","PickupTerminal",
											   "ContainerBundleID",
											"ProofOfDelivery"};
			
				if (System.Array.IndexOf(containerFields,fieldName) != -1)
				{
					return sourceRow[fieldName];
				}
				if (fieldName == "ItemName")
				{
					return HelperFunctions.GetItemName(itemRow);
				}
				if (fieldName == "ItemDesc")
					return itemRow["ItemDesc"];
                if (fieldName == "CancelDate")
                    return itemRow["CancelDate"];
				if (fieldName == "PONumber")
					return poHeader["PONumber"];
				if (fieldName == "SizeOfItem")
					return itemRow["SizeOfItem"];
			if (fieldName == "BOLNumber")
				{
					return m_getter(sourceRow);
				}
				Debug.Assert(false);
				throw new Exception("BUG, couldn't find field in GetBundleField");
			}
		}
		
		public delegate object 
			GetBillOfLadingNumberFunc(EMDataSet.ContBundleTblRow row);
	

		public static void SetupContainerGrids(EMDataSet emDataSet,
			int contID,QuickGrid bundleGrid,
			QuickGrid weightGrid,
			HelperFunctions.DataGridClientInterface face,IsReadOnly isReadOnly,
			out decimal totalLbs,out decimal totalKgs,
			GetBillOfLadingNumberFunc func)
		{

			string[] bolFieldList = {"*BundleSeqNumber","*PONumber",
				"*ItemName","*SizeOfItem","MetricShipQty",
				"EnglishShipQty","Heat",
				"BayNumber","InvoiceNumber","MillInvoiceDate","BundleAlloySurcharge",
                "BundleScrapSurcharge",
                "EMInvoiceNumber",
				"PickupDate","PickupTerminal","ProofOfDelivery","*CancelDate",
                "ContainerBundleID"};
			EMDataSet.ContainerTblRow contRow = emDataSet.ContainerTbl.FindByContID(contID);
			bool showLessFields = !contRow.IsApplyClosingToEntireContainerNull() &&
				contRow.ApplyClosingToEntireContainer!=0;
			if (showLessFields)
			{
				bolFieldList = new string[]{"*BundleSeqNumber","*PONumber",
											"*ItemName","*SizeOfItem","MetricShipQty",
											"EnglishShipQty","Heat",
											"BayNumber","InvoiceNumber","MillInvoiceDate",
                                            "BundleAlloySurcharge","BundleScrapSurcharge","EMInvoiceNumber",
                                            "*CancelDate",
											"ContainerBundleID"};
			
			}
			BundleFieldHelper bundleFieldHelper = new BundleFieldHelper();
			bundleFieldHelper.m_getter = func;
			GridWizard(bundleGrid,emDataSet.ContBundleTbl,false,
				IsNewAllowed.No,isReadOnly,"BundleSeqNumber",
				new GetFieldDelegate(bundleFieldHelper.GetBundleField),
				face,bolFieldList);

            bundleGrid.SetCancelColumn("CancelDate");
			
			DataTable weightTable = new DataTable();

			weightTable.Clear();
			weightTable.Columns.Clear();
			weightTable.Columns.Add("PONumber",typeof(string));
			weightTable.Columns.Add("ItemName",typeof(string));
			weightTable.Columns.Add("ItemDesc",typeof(string));
			weightTable.Columns.Add("SizeOfItem",typeof(string));
			weightTable.Columns.Add("MetricShipQty",typeof(decimal));
			weightTable.Columns.Add("EnglishShipQty",typeof(decimal));
			weightTable.Columns.Add("POItemNumber",typeof(int));

			totalKgs = 0;
			totalLbs = 0;
			foreach (EMDataSet.ContBundleTblRow sourceRow in emDataSet.ContBundleTbl.Rows)
			{
				if (!DataInterface.IsRowAlive(sourceRow))
					continue;
				EMDataSet.POItemTblRow itemRow = sourceRow.POItemTblRow;
				EMDataSet.POHeaderTblRow poRow = itemRow.POHeaderTblRow;
				DataRow weightRow = weightTable.NewRow();
				weightRow["PONumber"] = poRow.PONumber;
				weightRow["ItemName"] = itemRow.ItemTblRow.ItemName;
				weightRow["ItemDesc"] = itemRow["ItemDesc"];
				weightRow["EnglishShipQty"] = sourceRow["EnglishShipQty"];
				if (!sourceRow.IsNull("EnglishShipQty"))
				{
					totalLbs += (decimal)sourceRow["EnglishShipQty"];
				}
				weightRow["MetricShipQty"] = sourceRow["MetricShipQty"];
				if (!sourceRow.IsNull("MetricShipQty"))
				{
					totalKgs += (decimal)sourceRow["MetricShipQty"];
				}
				weightRow["SizeOfItem"] = itemRow["SizeOfItem"];
				weightRow["POItemNumber"] = itemRow.POItemNumber;
				weightTable.Rows.Add(weightRow);
			}
			
			// Collapse the weightTable
			for (int i=0;i<weightTable.Rows.Count;i++)
			{
				DataRow masterRow = weightTable.Rows[i];
				if (!DataInterface.IsRowAlive(masterRow))
					continue;
				int poItemNumber = (int)masterRow["POItemNumber"];
				for (int j=i+1;j<weightTable.Rows.Count;j++)
				{
					DataRow compareRow = weightTable.Rows[j];
					if (!DataInterface.IsRowAlive(compareRow))
						continue;
					if (((int)compareRow["POItemNumber"]) == poItemNumber) // same item
					{
						if (masterRow.IsNull("MetricShipQty"))
							masterRow["MetricShipQty"] = (decimal)0;
						if (masterRow.IsNull("EnglishShipQty"))
							masterRow["EnglishShipQty"] = (decimal)0;
						decimal metricShipQty = (decimal)masterRow["MetricShipQty"];
						decimal englishShipQty = (decimal)masterRow["EnglishShipQty"];
						if (!compareRow.IsNull("MetricShipQty"))
							metricShipQty += (decimal)compareRow["MetricShipQty"];
						if (!compareRow.IsNull("EnglishShipQty"))
							englishShipQty += (decimal)compareRow["EnglishShipQty"];
						masterRow["MetricShipQty"] = metricShipQty;
						masterRow["EnglishShipQty"] = englishShipQty;
						compareRow.Delete();
						j--;
					}
				}
			}
			DataView weightView = new DataView(weightTable,"","ItemName",DataViewRowState.CurrentRows);
			HelperFunctions.UpdateGrid(weightView,weightGrid,null,false,IsNewAllowed.No,
				IsReadOnly.Yes,"PONumber","ItemName","ItemDesc","SizeOfItem",
				"MetricShipQty","EnglishShipQty");
		}
		public static void FillContainerFromDatabase(EMDataSet emDataSet,int contID)
		{
			using (new OpenConnection(IsWrite.No,AdapterHelper.Connection))
			using (new TurnOffConstraints(emDataSet))
			{
				AdapterHelper.FillContainerHeader(emDataSet,contID);
				AdapterHelper.FillContBundle(emDataSet,contID);
				foreach (EMDataSet.BOLItemTblRow bolItemRow in 
					emDataSet.BOLItemTbl.Rows)
				{
					int bolID = bolItemRow.BOLID;
					AdapterHelper.FillBillOfLading(emDataSet,bolID);
				}
				AdapterHelper.FillOutConstraints(emDataSet);
			}
		}
		public delegate object GetFieldDelegate(DataRow sourceRow,bool isMetric,string fieldName);
		public static void GridWizard(QuickGrid grid,
			DataTable table,bool isMetric,IsNewAllowed isNewAllowed,
			IsReadOnly isReadOnly,
			string sortingField,GetFieldDelegate getField,
			HelperFunctions.DataGridClientInterface face,params string[] fieldsIn)
		{
			// When you get the field properties than the leading "*" is stripped
			string[] fields = (string[])fieldsIn.Clone();
			fieldsIn.CopyTo(fields,0);
			HelperFunctions.FieldProperties[] fieldProperties = HelperFunctions.GetProperties(ref fields,isMetric);
			DataTable newTable = new DataTable();
			for (int i=0;i<fields.Length;i++)
			{
				newTable.Columns.Add(fields[i],fieldProperties[i].type);
			}
			for (int i=0;i<table.Rows.Count;i++)
			{
				if (!DataInterface.IsRowAlive(table.Rows[i]))
					continue;
				DataRow targetRow = newTable.NewRow();
				foreach (string fieldName in fields)
				{
					object o = getField(table.Rows[i],isMetric,fieldName);
					targetRow[fieldName] = o;
				}
				newTable.Rows.Add(targetRow);
			}
			DataView view = new DataView(newTable,"",sortingField,
				DataViewRowState.CurrentRows);
			HelperFunctions.UpdateGrid(view,grid,face,isMetric,
				isNewAllowed,isReadOnly,fieldsIn);
			
		}
        public static void SetupContainerItemSummaryGrid(EMDataSet emDataSet, QuickGrid grid, int poItemNumber)
        {
            SetupContainerItemSummaryGrid(emDataSet, grid, poItemNumber, 0);
        }
		public static void SetupContainerItemSummaryGrid(EMDataSet emDataSet,QuickGrid grid,int poItemNumber,int bundleIDNumber)
		{
			EMDataSet.ContBundleTblRow[] rows = 
				(EMDataSet.ContBundleTblRow[])
				emDataSet.ContBundleTbl.Select("POItemNumber = " + poItemNumber.ToString());
			DataTable newTable = new DataTable();
			string[] fields = new string[]{"ContNumber","BundleSeqNumber","EnglishShipQty","MetricShipQty","ContID","ContainerBundleID"};
			HelperFunctions.FieldProperties[] fieldProperties = HelperFunctions.GetProperties(ref fields,false);
			for (int i =0;i<fields.Length;i++)
			{
				newTable.Columns.Add(fields[i],fieldProperties[i].type);
			}
            int selectedIndex = -1;
            for (int i = 0; i < rows.Length; i++)
            {
                EMDataSet.ContBundleTblRow row = rows[i];
				if (!DataInterface.IsRowAlive(row))
					continue;
                if (row.ContainerBundleID == bundleIDNumber)
                    selectedIndex = i;

                DataRow targetRow = newTable.NewRow();
				targetRow["ContNumber"] = row.ContainerTblRow.ContNumber;
				targetRow["BundleSeqNumber"] = row.BundleSeqNumber;
				targetRow["EnglishShipQty"] = row["EnglishShipQty"];
				targetRow["MetricShipQty"] = row["MetricShipQty"];
				targetRow["ContID"] = row.ContID;
                targetRow["ContainerBundleID"] = row.ContainerBundleID;
				newTable.Rows.Add(targetRow);
			}
			DataView view = new DataView(newTable,"","ContNumber",DataViewRowState.CurrentRows);
			HelperFunctions.UpdateGrid(view,grid,null,false,IsNewAllowed.No,IsReadOnly.Yes,fields);
            if (selectedIndex != -1)
                grid.SetNewFocus(selectedIndex, 0);

		}

	}
	
}
