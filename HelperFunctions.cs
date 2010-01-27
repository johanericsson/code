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
	public enum IsNewAllowed
	{
		Yes,
		No
	}
	public enum IsReadOnly
	{
		Yes,
		No
	}
	public enum IsWrite
	{
		Yes,
		No
	}
	public class OpenConnection : IDisposable
	{
		static bool isWriteProceeding = false;
		OleDbConnection connection;
		bool wasConnectionOpen;
		FileStream lockFile;
		public OpenConnection(IsWrite isWrite,OleDbConnection connectionIn)
		{
			if (isWriteProceeding)
				throw new Exception("BUG: Trying to open connection while writing");
			lockFile = null;
			connection = null;
			wasConnectionOpen= (connectionIn.State == ConnectionState.Open);
			if (!wasConnectionOpen)
			{
				if (isWrite == IsWrite.Yes)
				{
					lockFile = DataInterface.CreateLockFile("database");
				}
				else
				{
					lockFile = DataInterface.CreateSharedLockFile("database");
				}
				connectionIn.Open();
				connection = connectionIn;
			}
			isWriteProceeding = (isWrite == IsWrite.Yes);
		}
		public void Dispose()
		{
			if (!wasConnectionOpen)
			{
				connection.Close();
				lockFile.Close();
			}
			lockFile = null;
			connection = null;
			if (isWriteProceeding)
			{
				isWriteProceeding = false;
			}
		}
		~OpenConnection()
		{
			if (connection != null)
			{
				Debug.Assert(false);
			}
		}
	}

	public class TurnOffConstraints : IDisposable
	{
		DataSet dataSet;
		bool wereConstraintsOn;
		public TurnOffConstraints(DataSet dataSetIn)
		{
			dataSet = dataSetIn;
			wereConstraintsOn = dataSet.EnforceConstraints;
			dataSet.EnforceConstraints = false;
		}
		public void Dispose()
		{
			DataSet tempDataSet = dataSet;
			dataSet = null;
			tempDataSet.EnforceConstraints = wereConstraintsOn;

		}
		~TurnOffConstraints()
		{
			if (dataSet != null)
			{
				Debug.Assert(false);
			}
		}
	}

	/// <summary>
	/// Summary description for HelperFunctions.
	/// </summary>

	public class HelperFunctions
	{
		public const string ADD_NEW = "Add new...";
	

		static public void ToDateText(object sender,
			ConvertEventArgs cevent)
		{
			if (!cevent.DesiredType.Equals(typeof(string)))
				return;
			if (cevent.Value == DBNull.Value)
				return;
			System.DateTime t = (System.DateTime)cevent.Value;
			cevent.Value = t.ToShortDateString();
		}
		static public object FromDateText(AutoCompleteTextBox box)
		{
			if (box.Text == "")
				return System.DBNull.Value;
			return System.DateTime.Parse(box.Text);
		}
		static public string ToDateText(System.DateTime date)
		{
			return date.ToShortDateString();
		}
		public class MultilineEnumerator : IEnumerable, IEnumerator
		{
			public virtual IEnumerator GetEnumerator()
			{
				return this;
			}
			public virtual object Current
			{
				get
				{
					return multiline.Substring(last,current-last);
				}
			}
			public virtual bool MoveNext()
			{
				if (current >= multiline.Length)
					return false;
				last = current;
				for (;current<multiline.Length;current++)
				{
					if (multiline[current] == '\n')
					{
						current++;
						return true;
					}
				}
				return true;
			}
			public virtual void Reset()
			{
				current =0;
			}
			public MultilineEnumerator(string multilineIn)
			{
				multiline = multilineIn;
			}
			string multiline;
			int last = 0;
			int current = 0;
		}

		public enum ColumnStyle
		{
			Text,
			Date,
			Item
		};


		public static TextBox GetCurrentTextBox(DataGrid grid)
		{
			DataGridTableStyle style = grid.TableStyles[0];
			DataGridTextBoxColumn textColumn = (DataGridTextBoxColumn)
				style.GridColumnStyles[grid.CurrentCell.ColumnNumber];
			return textColumn.TextBox;
		}
		public static void SetCurrentCell(object sender,string value)
		{
			Button button = (Button)sender;
			QuickGrid grid = (QuickGrid)button.Parent;
			grid.SetCurrentItem(value);
		}
		public static object GetCurrentCell(object sender)
		{
			Button button = (Button)sender;
			QuickGrid grid = (QuickGrid)button.Parent;
			object currentAsObject = grid.GetItem(grid.GetCurrentIndex());
			return currentAsObject;
		}


		static void OnDateClick(object sender,EventArgs args)
		{
			object currentAsObject = GetCurrentCell(sender);
			DateTime defaultTime = DateTime.Now;
			if (!(currentAsObject is DBNull))
			{

				defaultTime = (DateTime)currentAsObject;
			}
			if (DialogResult.OK == DateTimeSelector.RequestTime(ref defaultTime))
			{
				string dateAsString = HelperFunctions.ToDateText(defaultTime);
				SetCurrentCell(sender,dateAsString);
			}
		}

		public static void RemoveCurrentLine(DataGrid grid)
		{
			int rowNumber = grid.CurrentCell.RowNumber;
			DataTable table = (DataTable)grid.DataSource;
			if (table.Rows.Count <= rowNumber)
				return; // can't delete row that isn't there
			table.Rows[rowNumber].Delete();
		}

		public interface DataGridClientInterface
		{
			void OnGridItemClicked(int currentRow);
			void NewGridTotal(string fieldName,decimal currentTotal);
			string[] DecimalFieldsToBeMonitored();
		}
		public class DataGridClientBridge
		{

			DataGridClientInterface m_interface;
			string[] m_fieldNames;
			public DataGridClientBridge(DataGridClientInterface face)
			{
				m_interface = face;
				m_fieldNames = face.DecimalFieldsToBeMonitored();
			}
			public void OnItemClick(object sender,EventArgs args)
			{
				Button button = (Button)sender;
				QuickGrid grid = (QuickGrid)button.Parent;
				m_interface.OnGridItemClicked(grid.GetCurrentIndex().row);
			}
			public void DataGridColumnChanged( object sender, DataColumnChangeEventArgs e )
			{
				string fieldName = "";
				for (int i=0;i<m_fieldNames.Length;i++)
				{
					if (e.Column.ColumnName == m_fieldNames[i])
					{
						fieldName = m_fieldNames[i];
						break;
					}
				}
				if (fieldName == "")
					return;
				DataTable table = (DataTable)sender;
				decimal total = 0;
				bool doesCancelDateColumnExist = table.Columns.IndexOf("CancelDate")!=-1;
				foreach (DataRow row in table.Rows)
				{
					if (doesCancelDateColumnExist)
					{
						if (!row.IsNull("CancelDate"))
							continue;
					}
					if (!row.IsNull(fieldName))
					{
						total += (decimal)row[fieldName];
					}
				}
				m_interface.NewGridTotal(fieldName,total);
			}
		}

		static bool inDataGridColumnChanged = false;
		public static void DataGridColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if (inDataGridColumnChanged)
				return;
			inDataGridColumnChanged = true;
			try
			{
				DataTable table = (DataTable)sender;
				DataRow row = e.Row;
				DataColumn column = e.Column;
				switch (column.ColumnName)
				{
					case "MetricShipQty":
					{
						if (row.IsNull("MetricShipQty"))
							row["MetricShipQty"] = 0;
                        row["EnglishShipQty"] = DataInterface.ConvertToLbs((decimal)row["MetricShipQty"]);
						break;
					}
					case "EnglishShipQty":
					{
						if (row.IsNull("EnglishShipQty"))
							row["EnglishShipQty"] = 0;
						row["MetricShipQty"] = DataInterface.ConvertToKG((decimal)row["EnglishShipQty"]);
						break;
					}
					case "Qty":
					{

						if (!row.IsNull("Qty"))
						{
							if (!row.IsNull("CustRate"))
							{
								row["CustAmount"] = (decimal)row["Qty"] * (decimal)row["CustRate"];
							}
							else if (!row.IsNull("CustAmount") && ((decimal)row["Qty"]!=0))
								row["CustRate"] = (decimal)row["CustAmount"] / (decimal)row["Qty"];
						}
						break;
					}
					case "CustRate":
					{
						if (!row.IsNull("Qty") && 
							!row.IsNull("CustRate"))
						{
							row["CustAmount"] = (decimal)row["Qty"] * (decimal)row["CustRate"];
						}
						break;
					}
					case "CustAmount":
					{
						if (!row.IsNull("CustAmount"))
						{
							if (!row.IsNull("Qty") && (decimal)row["Qty"]!=0)
								row["CustRate"] = (decimal)row["CustAmount"] / (decimal)row["Qty"];
							else if (!row.IsNull("CustRate") && (decimal)row["CustRate"]!=0)
								row["Qty"] = (decimal)row["CustAmount"] / (decimal)row["CustRate"];
						}
						break;
					}
				}
			}	 
			finally
			{
				inDataGridColumnChanged = false;

			}
		}

		public struct FieldProperties
		{
			public string columnHeading;
			public int width;
			public bool readOnly;
			public System.Type type;
			public HorizontalAlignment alignment;
			public ColumnStyle columnStyle;
			public string formatString;
			public bool isKeyField;
			public string[] comboBoxItems;
		}


		public static EMDataSet helperDataSet = new EMDataSet();

		static HelperFunctions()
		{
			helperDataSet.EnforceConstraints = false;
			AdapterHelper.FillFinish(helperDataSet.FinishTbl);
			AdapterHelper.FillTreatment(helperDataSet.TreatmentTbl);
		}

		public static int[] GetFinishKeys(string tableName)
		{
			string dataTableName = tableName + "tbl";
			DataTable table = helperDataSet.Tables[dataTableName];
			ArrayList list = new ArrayList();
			foreach (DataRow row in table.Rows)
			{
				string keyName = tableName + "ID";
				list.Add(row[keyName]);
			}
			int[] finishIDs = (int[])list.ToArray(typeof(int));
			return finishIDs;
		}
		public static string[] GetFinishItems(string tableName)
		{
			ArrayList list = new ArrayList();
			string dataTableName = tableName + "tbl";
			DataTable table = helperDataSet.Tables[dataTableName];
			
			foreach (DataRow row in table.Rows)
			{
				string valueName = tableName + "Type";
				list.Add(row[valueName]);
			}
			string[] finishItems = (string[])list.ToArray(typeof(string));
			Array.Sort(finishItems);
			return finishItems;
		}
		public static object GetFinishKey(string tableName,string finish)
		{
			if (finish == "")
				return DBNull.Value;
			string valueName = tableName + "Type";
			string query = valueName + " = '" + finish + "'";
			string dataTableName = tableName + "tbl";
			DataTable table = helperDataSet.Tables[dataTableName];
			
			DataRow[] rows = 
				(DataRow[])table.Select(query);
			if (rows.Length != 1)
				throw new Exception("BUG: should be a key for the finish string");
			string keyName = tableName + "ID";
			return rows[0][keyName];
		}
		public static string GetFinishType(string tableName,int key)
		{
			string dataTableName = tableName + "tbl";
			DataTable table = helperDataSet.Tables[dataTableName];
			DataRow row = table.Rows.Find(key);
			string valueName = tableName + "Type";
			return (string)row[valueName];
		}

		public static string GetItemName(EMDataSet.POItemTblRow row)
		{
			if (row == null)
				return null;
			if (row.IsItemIDNull())
				return "";
			string itemName = row.ItemTblRow.ItemName;
			if (!row.IsFinishIDNull())
			{
				itemName = GetFinishType("Finish",row.FinishID) + " " + itemName;
			}
			if (!row.IsTreatmentIDNull())
			{
				itemName = itemName + " " + GetFinishType("Treatment",row.TreatmentID);
			}
			return itemName;
		}

		public static string GetSuffix(bool isKg)
		{
			if (isKg)
				return "(kg)";
			else
				return "(lbs)";
		}

		static float systemDPI = -1;
		public static float GetSystemDPI()
		{
			if (systemDPI == -1)
			{
				using (Control c = new Control())
				using (Graphics g= c.CreateGraphics())
				{
					systemDPI = (int)g.DpiX;
				}
			}
			return systemDPI;
		}

		public static FieldProperties[] GetProperties(ref string[] fieldNames,bool isKg)
		{
			FieldProperties[] properties = new FieldProperties[fieldNames.Length];
			for (int i=0;i<properties.Length;i++)
			{
				FieldProperties prop = new FieldProperties();
				prop.width = 70;
				prop.isKeyField = false;
				prop.readOnly = false;
				prop.type = typeof(string);
				prop.columnStyle = ColumnStyle.Text;
				prop.alignment = HorizontalAlignment.Left;
				prop.formatString = null;
				string fieldName = fieldNames[i];
				if (fieldName[0]=='*') // * indicates read only field
				{
					fieldName = fieldName.Substring(1); // Pull the * off of the string
					prop.readOnly = true;
					fieldNames[i] = fieldName;
				}
				switch (fieldName)
				{
					case "ContainerBundleID":
						prop.isKeyField= true;
						prop.type = typeof(int);
						break;
					case "ContID":
						prop.isKeyField = true;
						prop.type = typeof(int);
						break;
					case "BOLID":
						prop.isKeyField = true;
						prop.type = typeof(int);
						break;
					case "POItemNumber":
						prop.isKeyField = true;
						prop.type = typeof(int);
						break;
					case "SeqNumber":
						prop.isKeyField = true;
						prop.type = typeof(int);
						break;
					case "ContainerWeight":
						prop.width = 170;
						prop.type = typeof(decimal);
						prop.formatString = "N0";
						prop.columnHeading = "Total weight in containers" + GetSuffix(isKg);
						break;
					case "BOLWeight":
						prop.width = 170;
						prop.type = typeof(decimal);
						prop.formatString = "N0";
						prop.columnHeading = "Total weight picked up" + GetSuffix(isKg);
						break;
					case "TotalContainerWeight":
						prop.width = 170;
						prop.type = typeof(decimal);
						prop.formatString = "N0";
						prop.columnHeading = "Total weight in containers" + GetSuffix(isKg);
						break;
					case "EnglishShipQty":
						prop.type = typeof(decimal);
						prop.columnHeading = "Ship Qty(lbs)";
						prop.width = 80;
						prop.formatString = "N0";
						break;
					case "MetricShipQty":
						prop.type = typeof(decimal);
						prop.columnHeading = "Ship Qty(kg)";
						prop.width = 80;
						prop.formatString = "N0";
						break;
					case "ContNumber":
						prop.columnHeading = "Container Number";
						prop.width = 120;
						break;
					case "ETA":
						prop.columnHeading = "ETA";
						break;
					case "ShipDate":
						prop.columnHeading = "Ship Date";
						prop.width = 90;
						break;
					case "PONumber":
						prop.columnHeading = "PONumber";
						prop.width = 100;
						break;
					case "ItemName":
						prop.columnHeading = "Grade";
						prop.columnStyle = ColumnStyle.Item;
						prop.width = 95;
						break;
					case "ItemDesc":
						prop.columnHeading = "Description";
						prop.width = 250;
						break;
					case "PercentPickedUp":
						prop.columnHeading = "% Picked Up";
						prop.width = 90;
						prop.type = typeof(decimal);
						prop.formatString = "N2";
						break;
					case "Qty":
						prop.columnHeading = "Weight" + GetSuffix(isKg);
						prop.type = typeof(decimal);
						prop.formatString = "N0";
						break;
					case "CustRate":
						if (isKg)
							prop.columnHeading = "Rate($/kg)";
						else
							prop.columnHeading = "Rate($/lbs)";
						prop.type = typeof(decimal);
						break;
					case "CustAmount":
						prop.columnHeading = "Amount";
						prop.type = typeof(decimal);
						prop.formatString = "N2";
						break;
					case "Length":
						prop.columnHeading = "Length";
						prop.width = 115;
						break;
					case "SizeOfItem":
						prop.columnHeading = "Size";
						prop.width = 55;
						break;
					case "ItemAccessCode":
						prop.columnHeading = "IAC";
						break;
					case "DateRequired":
						prop.columnHeading = "Date Required";
						prop.width = 90;
						prop.columnStyle = ColumnStyle.Date;
						break;
					case "PickupDate":
						prop.columnHeading = "Pickup Date";
						prop.width = 70;
						prop.columnStyle = ColumnStyle.Date;
						break;
					case "PickupTerminal":
						prop.columnHeading = "Terminal";
						prop.width = 100;
						break;
					case "Heat":
						prop.columnHeading = "Heat";
						prop.width = 70;
						break;
					case "MillShipDate":
						prop.columnHeading = "Ship Date";
						prop.width = 90;
						prop.columnStyle = ColumnStyle.Date;
						break;
					case "Comments":
						prop.columnHeading = "Comments";
						prop.width = 250;
						prop.columnStyle = ColumnStyle.Text;
						break;
					case "CancelDate":
						prop.columnHeading = "Cancel Date";
						prop.width = 100;
						prop.columnStyle = ColumnStyle.Date;
						break;
					case "AcknowledgeDate":
						prop.columnHeading = "Acknowledge Date";
						prop.width = 110;
						prop.columnStyle = ColumnStyle.Date;
						break;
                    case "MillConfirmationNumber":
                        prop.columnHeading = "Confirmation#";
                        prop.width = 110;
                        break;
                    case "MillAcknowledgeDate":
                        prop.columnHeading = "Confirmation Date";
                        prop.width = 110;
                        prop.columnStyle = ColumnStyle.Date;
                        break;
                    case "InvoiceNumber":
                        prop.columnHeading = "Inv#";
                        prop.width = 60;
                        break;
                    case "EMInvoiceNumber":
                        prop.columnHeading = "EM Inv";
                        prop.width = 40;
                        break;
                    case "MillInvoiceDate":
                        prop.columnHeading = "Inv Date";
                        prop.width = 70;
                        prop.columnStyle = ColumnStyle.Date;
                        break;
                    case "BundleAlloySurcharge":
                        prop.columnHeading = "Alloy/100Lbs";
                        prop.width = 100;
                        prop.formatString = "N2";
                        prop.type = typeof(decimal);
                        break;
                    case "BundleScrapSurcharge":
                        prop.columnHeading = "Scrap/100Lbs";
                        prop.width = 100;
                        prop.formatString = "N2";
                        prop.type = typeof(decimal);
                        break;
 
                    case "BundleSurcharge":
                        prop.columnHeading = "Surcharge/100Lbs";
                        prop.width = 120;
                        prop.formatString = "N2";
                        prop.type = typeof(decimal);
                        break;
                    case "TotalSurcharge":
                        prop.columnHeading = "Total Surcharge";
                        prop.width = 95;
                        prop.formatString = "N2";
                        prop.type = typeof(decimal);
                        break;
                    case "TotalWithSurcharge":
                        prop.columnHeading = "Full Total";
                        prop.width = 95;
                        prop.formatString = "N2";
                        prop.type = typeof(decimal);
                        break;
                    case "InvoiceDate":
                        prop.columnHeading = "Invoice Date";
                        prop.width = 100;
                        prop.columnStyle = ColumnStyle.Date;
                        break;
					// Container item grid
					case "BundleSeqNumber":
						prop.columnHeading = "#";
						prop.width = 30;
						prop.type = typeof(int);
						break;
					case "ShipQty":
						prop.columnHeading = "Ship Qty" + GetSuffix(isKg);
						prop.type = typeof(decimal);
						prop.width = 100;
						break;
					case "BayNumber":
						prop.columnHeading = "Bay#";
						prop.width = 40;
						break;
					case "BOLNumber":
						prop.columnHeading = "Lading#";
						prop.width = 100;
						break;
					case "Finish":
						prop.columnHeading = "Finish";
						prop.comboBoxItems = GetFinishItems("Finish");
						prop.width = 40;
						break;
					case "Treatment":
						prop.columnHeading = "Treat";
						prop.comboBoxItems = GetFinishItems("Treatment");
						prop.width = 45;
						break;
					case "Heading":
						prop.columnHeading = "";
						break;
					case "FinishWeight":
						prop.columnHeading = "Weight" + GetSuffix(isKg);
						prop.type = typeof(decimal);
						prop.formatString = "N0";
						break;
					case "FinishAmount":
						prop.columnHeading = "Amount";
						prop.type = typeof(decimal);
						prop.formatString = "N2";
						break;
					case "ProofOfDelivery":
						prop.columnHeading = "Bill of lading";
						prop.type = typeof(string);
						prop.width = 150;
						break;
					default:
						throw new Exception("couldn't find field name");
				}
				float systemDPI = GetSystemDPI();
				float ratio = systemDPI / 96;
				prop.width = (int)(ratio * prop.width + .5);
				if (prop.columnStyle == ColumnStyle.Date)
					prop.type = typeof(DateTime);
				if (prop.type == typeof(decimal))
					prop.alignment = HorizontalAlignment.Right;
				properties[i] = prop;
			}
			return properties;
		}

		public static DataView GetViewFrom(EMDataSet.POItemTblDataTable table)
		{
			DataView view = new DataView(table,"","SeqNumber",DataViewRowState.CurrentRows);
			return view;
		}


		public static string[] AckFields = new string[]
			{
				"*ItemName","*ItemDesc","*SizeOfItem","*ItemAccessCode","*Qty","*CancelDate",
				"POItemNumber","SeqNumber"
				
			};

		static string GetFirstLine(string input)
		{
			int index = input.IndexOfAny(new char[]{'\r','\n'});
			if (index == -1)
				return input;
			return input.Substring(0,index);
		}



		
		static public void UpdateGrid(DataView itemTable,
			QuickGrid grid,
			DataGridClientInterface face,bool isKg,
			IsNewAllowed allowNew,
			IsReadOnly readOnly,
			params string[] fieldNames)
							
		{
			fieldNames = (string[])fieldNames.Clone();
			FieldProperties[] properties = GetProperties(ref fieldNames,isKg);
			int numberOfFields = fieldNames.Length;
			DataTable table = new DataTable();
			for (int i = 0;i<numberOfFields;i++)
			{
				System.Type type = properties[i].type;
				table.Columns.Add(fieldNames[i],type);
			}

			HelperFunctions.DataGridClientBridge bridge = null;
			if (face != null)
				bridge = new DataGridClientBridge(face);
							

			foreach (DataRowView rowView in itemTable)
			{
				DataRow row = rowView.Row;
				if (!DataInterface.IsRowAlive(row))
					continue;
				DataRow newRow = table.NewRow();				
				for (int i = 0;i<numberOfFields;i++)
				{
					string fieldName = fieldNames[i];
					if (!row.IsNull(fieldName) && row[fieldName].GetType() == 
						typeof(System.DateTime))
					{
						DateTime d = (DateTime)row[fieldName];
						newRow[fieldName] = d.ToShortDateString();
					}
					else
						newRow[fieldName] = row[fieldName];
				}
				table.Rows.Add(newRow);
			}
			table.AcceptChanges();
			grid.ClearAllHandlers();
			ArrayList listOfColumnProperties = new ArrayList();
			for (int i=0;i<properties.Length;i++)
			{
				FieldProperties props = properties[i];
				if (props.isKeyField == true)
					continue;
				if (IsReadOnly.Yes == readOnly)
					props.readOnly = true;
				QuickGrid.ColumnProperties coll = new QuickGrid.ColumnProperties();
				switch (props.columnStyle)
				{
					case ColumnStyle.Text:
						coll.formatString = props.formatString;
						break;
					case ColumnStyle.Date:
						coll.formatString = "d";
						grid.AddButtonHandler(i,".",new EventHandler(OnDateClick));
						break;
					case ColumnStyle.Item:
					{
						if (!props.readOnly)
						{
							// since we are not allowing the user
							// to actually edit the field			
							props.readOnly = true; 

							if (face == null)
								throw new Exception("Oops, you need a handler for the item clicker");
							grid.AddButtonHandler(i,".",new EventHandler(bridge.OnItemClick));
						}
						break;
					}
					default:
						throw new Exception("Ahh no case statement");
				}
				if (props.columnHeading == "Description")
				{
					coll.multiline = true;
					coll.variable = true;
				}
				if (props.columnHeading == "Comments")
				{
					coll.multiline = true;
				}
				coll.comboBoxValues = props.comboBoxItems;
				coll.heading = props.columnHeading;
				coll.size = props.width;
				coll.alignment = props.alignment;
				coll.readOnly = props.readOnly;
				listOfColumnProperties.Add(coll);
			}
			table.ColumnChanged +=new DataColumnChangeEventHandler(DataGridColumnChanged);
			if (bridge != null)
				table.ColumnChanged +=new DataColumnChangeEventHandler(bridge.DataGridColumnChanged);
			QuickGrid.ColumnProperties[] columnProperties = (QuickGrid.ColumnProperties[])listOfColumnProperties.ToArray
												(typeof(QuickGrid.ColumnProperties));
			grid.Setup(table,columnProperties,allowNew==IsNewAllowed.Yes?true:false);
		}		

		static public DataRow[] GetChanges(DataTable table,DataRowState state)
		{
			ArrayList rowList = new ArrayList();

			foreach (DataRow row in table.Rows)
			{
				if (row.RowState == state)
				{
					rowList.Add(row);
				}
			}
			return (DataRow[])rowList.ToArray(typeof(DataRow));
		}

		public static int GetMaxSeqNumber(DataTable itemTable)
		{
			int maxSeqNumber = 0;
			// Find max seq number
			foreach (DataRow row in itemTable.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (row.IsNull("SeqNumber"))
					continue;
				int currentSeqNumber = (int)row["SeqNumber"];
				if (maxSeqNumber < currentSeqNumber)
					maxSeqNumber = currentSeqNumber;
			}
			return maxSeqNumber;
		}

		public static object GetItemID(EMDataSet emDataSet, EMDataSet.POItemTblRow row,object inputObject)
		{
			if (inputObject as DBNull != null)
				return DBNull.Value;
			string input = (string)inputObject;
			if (input == "")
				return DBNull.Value;
			int compID = row.POHeaderTblRow.CustomerID;
			string findItem = "CompID = " + compID + " AND ItemName = \'" + input + "\'";
			EMDataSet.ItemTblRow[] itemRows = (EMDataSet.ItemTblRow[])
				emDataSet.ItemTbl.Select(findItem);
            if (itemRows.Length == 0)
                return null; // if this is the mill confirmation #
			Debug.Assert(itemRows.Length == 1);
			return itemRows[0].ItemID;
		}

		public static void TransferFinish(string columnName,
			DataRow sourceRow,EMDataRow targetRow)
		{
			object finishID;
			if (sourceRow.IsNull(columnName))
				finishID = DBNull.Value;
			else
			{
				string finishType = (string)sourceRow[columnName];
				finishID = HelperFunctions.GetFinishKey(columnName,finishType);
			}
			string keyName = columnName + "ID";
			targetRow[keyName] = finishID;
		}

		// This is pretty big function. It converts the information from a the DataGrid back to the
		// item table. 
		// Then it matches up the existing items by using the poitem number keyword
		// Then it adds new items
		static public void FromGrid(int poid,EMDataSet emDataSet,
			QuickGrid generalGrid,bool commitItemName)
		{
			EMDataSet.POItemTblDataTable itemTable = emDataSet.POItemTbl;
			// All the new rows are at the end, but with no poitemnumber
			DataTable grid = (DataTable)generalGrid.GetTable();
			
			// Only work on a temporary copy of the datatable. That way
			// the one that is bound to the datagrid doesn't change
			grid = grid.Copy();
			
			// At this point, the entire datatable should be collapsed.
			// There will be some items with poitemnumbers, and some without
			int maxSeqNumber = GetMaxSeqNumber(grid);
			
			ArrayList poidNumbersInGrid = new ArrayList();
			for (int i=0;i<grid.Rows.Count;i++)
			{
				DataRow sourceRow = grid.Rows[i];
				if (!DataInterface.IsRowAlive(sourceRow))
					continue;

				// Changed row
				if (!sourceRow.IsNull("POItemNumber"))
				{
					int poItemNumber = (int)sourceRow["POItemNumber"];
					EMDataSet.POItemTblRow targetRow = 
						itemTable.FindByPOItemNumber(poItemNumber);
					foreach (DataColumn column in grid.Columns)
					{
						string columnName = column.ColumnName;
                        if (columnName == "Finish")
						{
                            if (commitItemName)
                                TransferFinish("Finish", sourceRow, targetRow);
							continue;
						}
                        if (columnName == "Treatment")
						{
                            if (commitItemName)
							    TransferFinish("Treatment",sourceRow,targetRow);
							continue;
						}
                        if (columnName == "ItemName")
						{
                            if (commitItemName)
							    targetRow["ItemID"] = GetItemID(emDataSet,targetRow,sourceRow["ItemName"]);
							continue;
						}
						targetRow[columnName] = sourceRow[columnName];
					}
					poidNumbersInGrid.Add(poItemNumber);
				}
				else // new row
				{
					EMDataSet.POItemTblRow targetRow 
						= itemTable.NewPOItemTblRow();
					sourceRow["POItemNumber"] = DataInterface.GetNextKeyNumber("tblPOItem2");
					sourceRow["SeqNumber"] = (int)(maxSeqNumber+1);
					maxSeqNumber++;
					targetRow.POID = poid;
					foreach (DataColumn column in grid.Columns)
					{
						string columnName = column.ColumnName;
						if (columnName == "Finish")
						{
							TransferFinish("Finish",sourceRow,targetRow);
							continue;
						}
						if (columnName == "Treatment")
						{
							TransferFinish("Treatment",sourceRow,targetRow);
							continue;
						}
						if (columnName == "ItemName")
						{
							targetRow["ItemID"] = GetItemID(emDataSet,targetRow,sourceRow["ItemName"]);
							continue;
						}
						targetRow[columnName] = sourceRow[columnName];
					}
					DataInterface.ConformMetric(itemTable,targetRow);
					itemTable.AddPOItemTblRow(targetRow);
					poidNumbersInGrid.Add(sourceRow["POItemNumber"]);
				}
			}
			// Look to see if we need to check any of the items
			// as being deleted

			// We have to delete rows
			// after the iteration so that
			// the iteration doesn't get screwed
			// up. This arraylist keeps track of them
			ArrayList listOfRowsToDelete = new ArrayList();
			foreach (EMDataSet.POItemTblRow row in itemTable)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				bool poidFound = false;
				int poidNumber = row.POItemNumber;
				foreach (int gridPOID in poidNumbersInGrid)
				{
					if (poidNumber == gridPOID)
					{
						poidFound = true;
						break;
					}
				}
				if (!poidFound)
					listOfRowsToDelete.Add(row);
			}
			foreach (DataRow row in listOfRowsToDelete)
				row.Delete();
			
			// Test for good seqnumbers
			ArrayList listOfSeqNumbers = new ArrayList();
			foreach (EMDataSet.POItemTblRow row in itemTable)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				listOfSeqNumbers.Add(row.SeqNumber);
			}
			listOfSeqNumbers.Sort();
			int [] arrayOfSeqNumbers = (int[])listOfSeqNumbers.ToArray(typeof(int));
			for (int i=0;i<listOfSeqNumbers.Count;i++)
			{
				if ((i+1) != arrayOfSeqNumbers[i])
					throw new Exception("BUG: bad seq number setup");
			}
		}	
		static public EMDataSet.POItemTblRow 
			GetItemRowOrCreate(EMDataSet.POItemTblDataTable table,
			int poid,
			int index)
		{
			EMDataSet.POItemTblRow row = GetRowFromSeqNumber(table,index + 1);
			if (row != null)
				return (EMDataSet.POItemTblRow)row;
			
			int newSeqNumber = (int)(GetMaxSeqNumber(table) + 1);
			if (newSeqNumber != index + 1)
			{
				throw new Exception("Oops can't add more than one per call");
			}
			row = table.NewPOItemTblRow();
			row.SeqNumber = newSeqNumber;
			row.POItemNumber = DataInterface.GetNextKeyNumber("tblPOItem2");
			row.POID = poid;
			DataInterface.ConformMetric(table,row);
			table.AddPOItemTblRow(row);
			return (EMDataSet.POItemTblRow)table.Rows[index];
		}
		
		static bool DoesColumnExist(DataTable table,string columnName)
		{
			foreach (DataColumn column in table.Columns)
			{
				if (column.ColumnName == columnName)
					return true;
			}
			return false;
		}

	
		public static int GetRowIndex(int position,DataGrid poItemGrid)
		{
			int i=0;
			DataTable table = (DataTable)poItemGrid.DataSource;
			for (;;i++)
			{
				
				string str = (string)table.Rows[i]["SeqNumber"];
				int seqNumber = int.Parse(str);
				if (seqNumber == position + 1)
					break;
			}
			return i;
		}
		public static int GetPosition(QuickGrid grid)
		{
			return grid.GetCurrentIndex().row;
		}
		public static EMDataSet.POItemTblRow 
			GetRowFromSeqNumber(EMDataSet.POItemTblDataTable table,
			int seqNumber)
		{
			foreach (EMDataSet.POItemTblRow row in table.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (row.SeqNumber == seqNumber)
					return row;
			}
			return null;
		}
		public static EMDataSet.POItemTblRow GetCurrentRow(QuickGrid grid,EMDataSet.POItemTblDataTable table)
		{
			int seqNumber = GetPosition(grid)+1;
			return GetRowFromSeqNumber(table,seqNumber);
		}
		public static bool AreRequiredFieldsFilledIn(DataRow row,string[] requiredFields,
			string[] friendlyTitles,out string errorMessage)
		{
			errorMessage = "";
			ArrayList listOfFailedCriteria = new ArrayList();
			for (int i=0;i<requiredFields.Length;i++)
			{
				string fieldName = requiredFields[i];
				if (row.IsNull(fieldName))
				{
					listOfFailedCriteria.Add(i);
					continue;
				}
				if (row.Table.Columns[fieldName].DataType == typeof(string))
				{
					if ((string)row[fieldName] == "")
					{
						listOfFailedCriteria.Add(i);
						continue;
					}
				}
			}
			if (listOfFailedCriteria.Count == 0)
				return true;
			errorMessage = "The following fields should be filled in before saving:";
			foreach (int failure in listOfFailedCriteria)
			{
				errorMessage += "\n" + friendlyTitles[failure];
			}
			errorMessage += "\n\n\n\nContinue Anyway?";
			DialogResult res = MessageBox.Show(errorMessage,"Recommended fields missing",MessageBoxButtons.YesNo);
			if (res == DialogResult.No)
				return false;
			return true;
		}
        public static int GetMonthYearCode(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            return year * 100 + month;
        }
        public static string GetMonthYearString(int numYear)
        {
            int year = numYear / 100;
            int month = numYear % 100;
            string yearAsStr = year.ToString();
            string monthAsStr = month.ToString();
            if (monthAsStr.Length == 1)
                monthAsStr = "0" + monthAsStr;
            return year + "/" + monthAsStr;
        }
	}	
	public interface IAllowComboBoxUpdates
	{
		bool AllowComboBoxUpdates
		{
			get;
			set;
		}
	}
	class StopComboBoxUpdates : IDisposable
	{
		bool wasAllowed;
		IAllowComboBoxUpdates client;
		public StopComboBoxUpdates(IAllowComboBoxUpdates clientIn)
		{
			client = clientIn;
			wasAllowed = client.AllowComboBoxUpdates;
			if (wasAllowed)
				client.AllowComboBoxUpdates = false;
		}
		public void Dispose()
		{
			if (wasAllowed)
				client.AllowComboBoxUpdates = true;
		}
	}
}
