using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace EM
{
	/// <summary>
	/// Summary description for DataInterface.
	/// </summary>
	/// 
    public class SortByBundleNum : System.Collections.IComparer
    {
        public virtual int Compare(object a, object b)
        {
            EMDataSet.ContBundleTblRow rowA = (EMDataSet.ContBundleTblRow)a;
            EMDataSet.ContBundleTblRow rowB = (EMDataSet.ContBundleTblRow)b;
            if (rowA.BundleSeqNumber < rowB.BundleSeqNumber)
                return -1;
            if (rowA.BundleSeqNumber == rowB.BundleSeqNumber)
                return 0;
            return 1;
        }
    }
	public struct TaggedItem
	{
		public int key;
		public string title;
		public TaggedItem(int keyIn,string titleIn)
		{
			key = keyIn;
			title = titleIn;
		}
		public override string ToString()
		{
			return title;
		}
	}
	public struct TaggedItemStr
	{
		public string key;
		public string title;
		public TaggedItemStr(string keyIn,string titleIn)
		{
			key = keyIn;
			title = titleIn;
		}
		public override string ToString()
		{
			return title;
		}
	}


	public class DataInterface
	{
        public static bool IsContainerItemDone(EMDataSet.ContBundleTblRow row)
        {
            string reason;
            return IsContainerItemDone(row, out reason);
        }
		public static bool IsContainerItemDone(EMDataSet.ContBundleTblRow row,out string reason)
		{
            reason = "Could not close container because bundle " + row.BundleSeqNumber + 
                    " does not have a terminal or bill of lading set";
			if (!row.IsProofOfDeliveryNull() && row.ProofOfDelivery != "")
				return true;
            if (row.IsPickupTerminalNull())
                return false;
            if (row.PickupTerminal == "")
                return false;
			return true;
		}
        public class POCompletedNodeTag
        {

            public int poid;
            public int contID;
            public POCompletedNodeTag(int poidIn,int contIDIn)
            {
                contID = contIDIn;
                poid = poidIn;
            }

        }

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string strA, string strB);




        class TreeNodeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                TreeNode left = (TreeNode)x;
                TreeNode right = (TreeNode)y;
                return StrCmpLogicalW(left.Text, right.Text);
            }
        }


        public static void SortOnString(TreeNode node)
        {
            ArrayList listOfChildNodes = new ArrayList();
            foreach (TreeNode child in node.Nodes)
            {
                SortOnString(child);
                listOfChildNodes.Add(child);
            }
            listOfChildNodes.Sort(new TreeNodeSorter());
            node.Nodes.Clear();
            foreach (TreeNode child in listOfChildNodes)
            {
                node.Nodes.Add(child);
            }
        }
        

        public delegate bool IsContainerBundleCompleted(EMDataSet.ContBundleTblRow bundleRow);
        public static bool IsBundlePickedUp(EMDataSet.ContBundleTblRow bundleRow)
        {
            EMDataSet.ContainerTblRow containerRow = bundleRow.ContainerTblRow;
            if (containerRow.ApplyClosingToEntireContainer != 0)
            {
                return DataInterface.IsCompleted(containerRow);
            }
            return DataInterface.IsContainerItemDone(bundleRow);
        }
        
        public static bool IsPOCompleted(EMDataSet.POHeaderTblRow headerRow,
                        ref TreeNode headerNode,IsContainerBundleCompleted isBundleCompleted)
        {
            return IsPOCompleted(headerRow,ref headerNode,isBundleCompleted,90);
        }
        
        public static bool IsPOCompleted(EMDataSet.POHeaderTblRow headerRow,
                        ref TreeNode headerNode,IsContainerBundleCompleted isBundleCompleted,
                int percentageRequired)
        {
            EMDataSet emDataSet = (EMDataSet)headerRow.Table.DataSet;
			bool isMetric = DataInterface.IsMetric(headerRow);
            int completed = 0;
            int total = 0;
            EMDataSet.BalanceRptPORow newBalancePORow = emDataSet.BalanceRptPO.NewBalanceRptPORow();
            newBalancePORow.POID = headerRow.POID;
            newBalancePORow.PONumber = headerRow.PONumber;
			foreach (EMDataSet.POItemTblRow itemRow in headerRow.GetPOItemTblRows())
			{
                EMDataSet.BalanceRtpPOItemRow newBalancePOItemRow = emDataSet.BalanceRtpPOItem.NewBalanceRtpPOItemRow();
                newBalancePOItemRow.POID = headerRow.POID;
                newBalancePOItemRow.POItemNumber = itemRow.POItemNumber;
                newBalancePOItemRow["SizeOfITem"] = itemRow["SizeOfItem"];
                newBalancePOItemRow.Grade = HelperFunctions.GetItemName(itemRow);
                TreeNode poItemNode = new TreeNode();
				if (itemRow.IsQtyNull() || itemRow.Qty == 0)
					continue;
                ++total;
				decimal totalQty = itemRow.Qty;
				decimal totalQtyInClosedContainers = 0;
				string select = "POItemNumber = " + itemRow.POItemNumber.ToString();
				EMDataSet.ContBundleTblRow[] bundleRows = (EMDataSet.ContBundleTblRow[])
								emDataSet.ContBundleTbl.Select(select);
                ArrayList listOfContIDs = new ArrayList();
                foreach (EMDataSet.ContBundleTblRow bundleRow in bundleRows)
                {
                    listOfContIDs.Add(bundleRow.ContID);
                }
                AdapterHelper.Unique(ref listOfContIDs);
                foreach (int contID in listOfContIDs)
                {
                    EMDataSet.ContainerTblRow contRow = 
                        emDataSet.ContainerTbl.FindByContID(contID);
                    decimal totalCompletedInContainer = 0;
                    TreeNode containerNode = new TreeNode();
                    foreach (EMDataSet.ContBundleTblRow bundleRow in bundleRows)
                    {
                        if (bundleRow.ContID != contID)
                            continue;
                        decimal bundleQty = 0;
                        if (isMetric && !bundleRow.IsMetricShipQtyNull())
                            bundleQty = bundleRow.MetricShipQty;
                        else
                            if (!bundleRow.IsEnglishShipQtyNull())
                                bundleQty = bundleRow.EnglishShipQty;
                        decimal percentage = 100*bundleQty / totalQty;
                        string bundleDesc = "Bundle " + bundleRow.BundleSeqNumber +
                                            ": " + bundleQty.ToString("N0") +
                                            ": " + percentage.ToString("N2") + "%";
                        if (isBundleCompleted(bundleRow))
                        {
                            if (isMetric && !bundleRow.IsMetricShipQtyNull())
                            {
                                totalCompletedInContainer += bundleRow.MetricShipQty;
                            }
                            if (!isMetric && !bundleRow.IsEnglishShipQtyNull())
                            {
                                totalCompletedInContainer += bundleRow.EnglishShipQty;
                            }
                            bundleDesc += " (Completed)";
                        }
                        else 
                            bundleDesc += " (Not completed)";
                        TreeNode bundleNode = new TreeNode(bundleDesc);
                        bundleNode.Tag = new POCompletedNodeTag(headerRow.POID,contID);
                        containerNode.Nodes.Add(bundleNode);
                    }
                    totalQtyInClosedContainers += totalCompletedInContainer;
                    decimal percentageInContainer = 100*
                        totalCompletedInContainer / totalQty;
                    containerNode.Text = "Container: " + contRow.ContNumber +
                                         " " + totalCompletedInContainer.ToString("N0")
                                        + " " + percentageInContainer.ToString("N2") + "%";
                    containerNode.Tag = new POCompletedNodeTag(headerRow.POID, contID);
                    poItemNode.Nodes.Add(containerNode);
                }
				decimal itemPercentage = totalQtyInClosedContainers / totalQty * 100;
                poItemNode.Text = "Row:" + itemRow.SeqNumber.ToString() + " " + 
                                    HelperFunctions.GetItemName(itemRow) +
                                 " " + totalQtyInClosedContainers.ToString("N0") + " out of " + 
                                      itemRow.Qty.ToString("N0") + 
                                 " " + itemPercentage.ToString("N2") + "%";
                poItemNode.Tag = new POCompletedNodeTag(headerRow.POID, -1);
                if (itemPercentage >= percentageRequired)
				{
                    completed++;
                    newBalancePOItemRow.FinishedItem = 1;
				}
                newBalancePOItemRow.ClosedPercent = itemPercentage;
                newBalancePOItemRow.ClosedCount = totalQtyInClosedContainers;
                newBalancePOItemRow.TotalCount = totalQty;
                newBalancePOItemRow["UM"] = itemRow["UM"];
                emDataSet.BalanceRtpPOItem.AddBalanceRtpPOItemRow(newBalancePOItemRow);
                headerNode.Tag = new POCompletedNodeTag(headerRow.POID, -1);
                headerNode.Nodes.Add(poItemNode);
			}
            headerNode.Text = headerRow.PONumber;
            if (completed != total)
            {
                headerNode.Text += "(" + completed.ToString() + "/" + total.ToString();
            }
            newBalancePORow.ClosedCount = completed;
            newBalancePORow.TotalCount = total;
            if (completed == total)
                newBalancePORow.FinishedPO = 1;
            emDataSet.BalanceRptPO.AddBalanceRptPORow(newBalancePORow);
			return completed==total;
		}

        static public bool IsCompleted(EMDataSet.ContainerTblRow row)
		{
            string reason;
            return IsCompleted(row,out reason);
        }
        static public bool IsCompleted(EMDataSet.ContainerTblRow row, out string reason)
        {
            reason = null;
			if (!row.IsApplyClosingToEntireContainerNull() &&
				row.ApplyClosingToEntireContainer!=0)
			{
				if (!row.IsContainerPickupTerminalNull() &&
					row.ContainerPickupTerminal != "")
					return true;
				if (!row.IsContainerProofOfDeliveryNull() &&
					row.ContainerProofOfDelivery != "")
					return true;
                reason = "You must enter either a terminal or a bill of lading before closing.";
				return false;
			}
			foreach (EMDataSet.ContBundleTblRow bundleRow in row.GetContBundleTblRows())
			{
				// 2 options: either, each row has a bil of lading item
				// or it has a pick up date and terminal
				if (IsContainerItemDone(bundleRow,out reason))
					continue;
				return false;
			}
			if (row.GetContBundleTblRows().Length == 0)
				return false;
			return true;
		}
	
		static public string TranslateToConstraint(ArrayList listOfConstraints,
            ArrayList orConstraints)
		{
			if (listOfConstraints.Count == 0 && orConstraints.Count == 0)
				return "";
			string query = " WHERE (";
			for (int i=0;i<listOfConstraints.Count;i++)
			{
				string constraint = (string)listOfConstraints[i];
				query += " " + constraint + " ";
				if (i != listOfConstraints.Count -1)
				{
					query += " AND ";
				}
			}
            if (listOfConstraints.Count != 0)
            {
                query += ") ";
                if (orConstraints.Count != 0)
                    query += "AND ";
            }
            if (orConstraints.Count != 0)
                query += "( ";
            for (int i = 0; i < orConstraints.Count; i++)
            {
                string constraint = (string)orConstraints[i];
                query += " " + constraint + " ";
                if (i != orConstraints.Count - 1)
                {
                    query += " OR ";
                }
			}
            if (orConstraints.Count != 0)
                query += ")";
			return query;
		}
        static public string TranslateToConstraint(ArrayList listOfConstraints)
        {
            return TranslateToConstraint(listOfConstraints, new ArrayList());
        }

//        private const decimal conversion = 0.45359237M;
        private const decimal conversion = 0.4536M;// GSB's conversion rate
        public static decimal ConvertToKG(decimal lbs)
		{
			return lbs * conversion;
		}
        public static decimal ConvertToLbs(decimal kg)
        {
            return kg / conversion;
        }
		static Control[] GetAllControls(System.Windows.Forms.Form f)
		{
			ArrayList allControls = new ArrayList();
			Queue queue = new Queue();
			queue.Enqueue(f.Controls);
			while (queue.Count > 0)
			{
				Control.ControlCollection controls = (Control.ControlCollection)
					queue.Dequeue();
				if (controls == null || controls.Count == 0) continue;
				foreach (Control control in controls)
				{
					allControls.Add(control);
					queue.Enqueue(control.Controls);
				}
			}
			return (Control[])allControls.ToArray(typeof(Control));
		}


		public static int GetNextKeyNumbers(string tableName,int countRequested)
		{
			string query = "SELECT * FROM tblKeyNumbers WHERE " + 
				"tblName = '" + tableName + "'";
		
			OleDbConnection emConnection = AdapterHelper.Connection;
			using (new OpenConnection(IsWrite.Yes,emConnection))
			{
				OleDbDataAdapter adaptor = 
					new OleDbDataAdapter(query,emConnection);
				adaptor.SelectCommand.Transaction = emConnection.BeginTransaction();
				EMDataSet dataSet = new EMDataSet();
				EMDataSet.KeyNumberTbleDataTable table = 
					dataSet.KeyNumberTble;
				adaptor.Fill(table);
			
				EMDataSet.KeyNumberTbleRow row = (EMDataSet.KeyNumberTbleRow)table.Rows[0];
				int number = row.nextKeyNumber+1;
				row.nextKeyNumber += countRequested;
				
				new OleDbCommandBuilder(adaptor);
				adaptor.Update(table);
				adaptor.SelectCommand.Transaction.Commit();
				return number;
			}
		}
		public static int GetNextKeyNumber(string tableName)
		{
			return GetNextKeyNumbers(tableName,1);
		}
		public static void ApplyTable(DataTable table,string sqlCommand)
		{
			string strConnect = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=m:\\EM_Prog_2002.mdb";
			using (OleDbConnection conn = new OleDbConnection(strConnect))
			{
				using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sqlCommand,conn))
				{
					new System.Data.OleDb.OleDbCommandBuilder(adaptor);
					adaptor.Update(table);
				}
			}

		}

		public static bool IsRowAlive(DataRow row)
		{
			if (row.RowState == DataRowState.Detached)
				return false;
			if (row.RowState == DataRowState.Deleted)
				return false;
			return true;
		}
		public static string GetExternalPO(int internalPO,EMDataSet dataSet)
		{
			
			EMDataSet.POHeaderTblRow[] row = (EMDataSet.POHeaderTblRow[])
				dataSet.POHeaderTbl.Select("POID ="+internalPO.ToString());
			if (row.Length != 1)
				throw new Exception("Bad");
			return row[0].PONumber;
		}
		public static DataTable GetTable(string sqlCommand)
		{
			string strConnect = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=m:\\EM_Prog_2002.mdb";
			using (OleDbConnection conn = new OleDbConnection(strConnect))
			{
				using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sqlCommand,conn))
				{
					DataTable table = new DataTable();
					adaptor.Fill(table);
					return table;
				}
			}
		}
		public static void UpdateTable(OleDbDataAdapter adapter,
			System.Data.DataTable changedTable,DataRowState typeOfChanges)
		{
			DataTable onlyChanges = changedTable.GetChanges(typeOfChanges);
			if (onlyChanges == null)
				return;
			adapter.Update(onlyChanges);
		}
		public static void UpdateTableDelete(OleDbDataAdapter adapter,System.Data.DataTable changedTable)
		{
			UpdateTable(adapter,changedTable,DataRowState.Deleted);
		}
		public static void UpdateTableAdd(OleDbDataAdapter adapter,System.Data.DataTable changedTable)
		{
			UpdateTable(adapter,changedTable,DataRowState.Modified | DataRowState.Added);
		}

		public static void UpdateTable(OleDbDataAdapter adapter,DataTable changedTable)
		{
			UpdateTableDelete(adapter,changedTable);
			UpdateTableAdd(adapter,changedTable);
		}
		
		public static void UpdateComboBox(DataView table, string keyField,string fieldName,ComboBox box,
			DataRow currentRow)
		{
			System.Collections.ArrayList list = new System.Collections.ArrayList();
			int currentPosition = 0;
			int selectedPosition = -1;
			foreach (DataRowView row in table)
			{
				int key = (int)row[keyField];
				string title = (string)row[fieldName];
				list.Add(new TaggedItem(key,title));
				if (currentRow != null)
					if (!currentRow.IsNull(keyField))
						if (key == (int)currentRow[keyField])
							selectedPosition = currentPosition;
				++currentPosition;
			}
			box.Items.Clear();
			box.Items.AddRange(list.ToArray());
			
			if (selectedPosition != -1)
				box.SelectedIndex = selectedPosition;
		}

		public static void UpdateComboBox(DataView table, string fieldName,ComboBox box)
		{
			System.Collections.ArrayList list = new System.Collections.ArrayList();
			foreach (DataRowView row in table)
			{
				list.Add(row[fieldName]);
			}
			box.Items.Clear();
			box.Items.AddRange(list.ToArray());
		}

		public static void UpdateComboBox(DataTable table,string fieldName,ComboBox box)
		{
			UpdateComboBox(ToView(table),fieldName,box);
		}
		public static void UpdateListBox(DataView table, string fieldName,ListBox box)
		{
			System.Collections.ArrayList list = new System.Collections.ArrayList();
			foreach (DataRowView row in table)
			{
				list.Add(row[fieldName]);
			}
			box.Items.Clear();
			box.Items.AddRange(list.ToArray());
			if (box.Items.Count != 0)
				box.SelectedIndex = 0;
		}

		public static void UpdateListBox(DataTable table, string fieldName,ListBox box)
		{
			UpdateListBox(ToView(table),fieldName,box);
		}
		public static void SelectComboBox(ComboBox box,string name)
		{
			for (int i=0;i<box.Items.Count;i++)
			{
				string item = (string)box.Items[i];
				if (item == name)
				{
					box.SelectedIndex = i;
					return;
				}
			}
		}
		public static void SelectComboBox(ComboBox box, int key)
		{
			for (int i=0;i<box.Items.Count;i++)
			{
				TaggedItem item = (TaggedItem)box.Items[i];
				if (item.key == key)
				{
					box.SelectedIndex = i;
					return;
				}
			}
		}
		public static void InitializeAdapterWithParameter(OleDbDataAdapter  adapter,string parameterName)
		{
			adapter.SelectCommand.Parameters.Add("@ + parameterName",System.Data.OleDb.OleDbType.Integer);
			if (adapter.UpdateCommand!=null)
				adapter.UpdateCommand.Parameters.Add("@ + parameterName",System.Data.OleDb.OleDbType.Integer);
			if (adapter.DeleteCommand!=null)
			adapter.DeleteCommand.Parameters.Add("@ + parameterName",System.Data.OleDb.OleDbType.Integer);
		}
		public static void InitializeAdapterWithStringParameter(OleDbDataAdapter adapter,string parameterName)
		{
			adapter.SelectCommand.Parameters.Add("@ + parameterName",System.Data.OleDb.OleDbType.VarChar);
			if (adapter.UpdateCommand!=null)
				adapter.UpdateCommand.Parameters.Add("@ + parameterName",System.Data.OleDb.OleDbType.VarChar);
			if (adapter.DeleteCommand!=null)
				adapter.DeleteCommand.Parameters.Add("@ + parameterName",System.Data.OleDb.OleDbType.VarChar);
		}
		public static void FillAdapterWithParameter(OleDbDataAdapter adapter,object val)
		{
            FillAdapterWithParameters(adapter, val);
		}

        public static void FillAdapterWithParameters(OleDbDataAdapter adapter, params object[] values)
        {
            for (int i =0;i<values.Length;i++)
            {
                adapter.SelectCommand.Parameters[i].Value = values[i];
                if (adapter.UpdateCommand != null)
                    adapter.UpdateCommand.Parameters[i].Value = values[i];
                if (adapter.DeleteCommand != null)
                    adapter.DeleteCommand.Parameters[i].Value = values[i];
            }
        }
        public static void FillAdapterWithStringParameter(OleDbDataAdapter adapter, string val)
        {
            FillAdapterWithParameters(adapter, val);
        }

		public static DataView ToView(DataTable table)
		{
			return table.DefaultView;
		}

		public static void UpdateListCtrl(ListView ctrl,DataView view,string key,string first,params string[] fields)
		{
			ctrl.Items.Clear();
			foreach (DataRowView rowView in view)
			{
				DataRow row = rowView.Row;
				ListViewItem item = new ListViewItem();
				item.Tag = key;
				item.Text = first;
				item.SubItems.AddRange(fields);
				ctrl.Items.Add(item);
			}
		}
		public static string GetMetricString(bool isMetric)
		{
			if (isMetric)
				return "kg";
			else
				return "lbs";

		}
		public static void ConformMetric(EMDataSet.POItemTblDataTable table,
										 EMDataSet.POItemTblRow row)
		{
			row.UM = GetMetricString(IsMetric(table));
		}
		public static bool DefaultMetric = false;
		public static bool IsMetric(string um)
		{
			if (um == "kg")
				return true;
			return false;
		}
		public static bool IsMetric(EMDataSet.POItemTblRow row)
		{
			if (!row.IsUMNull())
			{
				return IsMetric(row.UM);
			}
			return DefaultMetric;
		}

		public static bool IsMetric(EMDataSet.POItemTblDataTable table)
		{
			foreach (EMDataSet.POItemTblRow row in table.Rows)
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (!row.IsUMNull())
					return IsMetric(row);
			}

			return DefaultMetric;
		}
		public static bool IsMetric(EMDataSet.POHeaderTblRow headerRow)
		{
			foreach (EMDataSet.POItemTblRow row in headerRow.GetPOItemTblRows())
			{
				if (!DataInterface.IsRowAlive(row))
					continue;
				if (!row.IsUMNull())
					return IsMetric(row);
			}
			return DefaultMetric;
		}
		
		public static int FindIndex(DataTable table,string fieldName,int fieldID)
		{
			DataColumn column = table.Columns[fieldName];
			for (int i=0;i<table.Rows.Count;i++)
			{
				if ((int)(table.Rows[i][column]) == fieldID)
					return i;
			}
			return 0;
		}

		public static int GetIndex(DataTable table, string fieldName,int keyValue)
		{
			for (int i=0;i<table.Rows.Count;i++)
			{
				int rowValue = (int)table.Rows[i][fieldName];
				if (keyValue == rowValue)
					return i;
			}
			return 0;
		}
		static public string ExpandQuotes(string query)
		{
			System.Text.StringBuilder b = new System.Text.StringBuilder();
			foreach (char c in query)
			{
				if (c == '\'')
					b.Append("''");
				else
					b.Append(c);
			}
			return b.ToString();
		}
		public static int GetCompID(EMDataSet dataSet,string compName)
		{
			EMDataSet.CompanyTblDataTable table = dataSet.CompanyTbl;
			string query = "CompName = '" + ExpandQuotes(compName) + "'";
			DataRow[] rows = table.Select(query);
			if (rows.Length == 0)
				return -1;
			EMDataSet.CompanyTblRow row = (EMDataSet.CompanyTblRow)rows[0];
			return row.CompID;
		}
		
		static Random m_randomizer = new Random();
		static void Is50()
		{
			return;
			/*int number = m_randomizer.Next(2);
			if (number == 1)
				throw new FakeException("Fake update in progress");*/
		}
		public class FakeException : Exception
		{
			public FakeException(string message) :base(message)
			{
			}
		}
		public class NoMappedDriveException : Exception
		{
			public NoMappedDriveException(string message):base(message){}
		}
		static void CheckMappedDrive()
		{
			try
			{
				using (new FileStream("m:\\test",FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite)){}
			}
			catch(Exception ex)
			{
				throw new NoMappedDriveException("The M: drive wasn't properly mapped:\n" + ex.Message);
			}
		}
		static FileStream CreateSharedFileImpl(string filename, FileShare shareType)
		{
			try
			{
				int i=0;
				while (true)
				{
				   ++i;
					try
					{
						CheckMappedDrive();
						Is50();
						FileStream str = new FileStream("m:\\" + filename,FileMode.OpenOrCreate,
							FileAccess.ReadWrite, shareType);
						return str;
					}
					catch(Exception)
					{
						if (i==10)
							throw;
						System.Threading.Thread.Sleep(100);
					}
				}
			}
			catch (NoMappedDriveException)
			{
				throw;
			}
			catch (FakeException)
			{
				throw;
			}
			catch(Exception e)
			{
				throw new Exception("Update in progress. Try again in a moment.",e);
			}
		}
		public static FileStream CreateLockFile(string filename)
		{
			return CreateSharedFileImpl(filename,FileShare.None);
		}

		public static FileStream CreateSharedLockFile(string filename)
		{
			return CreateSharedFileImpl(filename,FileShare.ReadWrite);
		}
		public static int GetKeyFromField(OleDbConnection connection,
			string tableName,
			string keyName,
			string fieldName,
			string fieldContents)
		{
			using (new OpenConnection(IsWrite.No,connection))
			{
				string keyColumn = keyName;
				string query = "SELECT " + keyColumn + " FROM " + 
					tableName +" WHERE " + fieldName + "=" + fieldContents;
				OleDbCommand command = new OleDbCommand(query,connection);
				using (OleDbDataReader reader = command.ExecuteReader())
				{
					if (!reader.HasRows)
						return -1;
					reader.Read();
					return reader.GetInt32(0);
				}
			}
		}
		public static void CheckForChanges(
			string keyField,
			string descriptionTitle,
			string descriptionField,
			string seqNumberField,
			DataTable databaseTable,
			DataTable currentTable)
		{
			ArrayList listOfCurrentChildren = new ArrayList();
			int  numberOfCurrentRows = 0;
			foreach (DataRow row in currentTable.Rows)
			{
				if (row.RowState != DataRowState.Added)
					numberOfCurrentRows++;
			}
			if (numberOfCurrentRows != databaseTable.Rows.Count)
			{
				throw new Exception("Unable to save. The number of items/bundles " +
					"is out of date. This is a result of another user " + 
					"making a change while you were editing this record.");
			}
			foreach (DataRow databaseRow in databaseTable.Rows)
			{
				object keyValue = databaseRow[keyField];

				DataRow currentRow = null;
				foreach (DataRow findRow in currentTable.Rows)
				{
					if (findRow[keyField,DataRowVersion.Original].Equals(keyValue))
					{
						currentRow = findRow;
						break;
					}
				}
				if (currentRow == null)
				{
					System.Diagnostics.Debug.Assert(false);
					throw new Exception("Unable to save. A row was added by some other user." +
						"This is the result of another "+
						"user making a change while you were editing this record.\n"+
						"Notify Johan of this error. It doesn't seem possible.");
				}
				// Compare the seqnumbers
				int seq1 = (int)
					databaseRow[seqNumberField,DataRowVersion.Original];
				int seq2 = (int)
					currentRow[seqNumberField,DataRowVersion.Original];
				if (seq1 != seq2)
					throw new Exception("Unable to save. The positions of the items/bundes has " + 
						"out of date with the database. This is the result of another user " + 
						"making a change while you were editing this record.");
				foreach (DataColumn column in databaseTable.Columns)
				{
					string columnName = column.ColumnName;
					object database = databaseRow[columnName];
					object current = currentRow[columnName,DataRowVersion.Original];
					if (database.GetType() != current.GetType() ||
						!database.Equals(current))
					{
						string message = "Unable to save. At least some of the data in the list " + 
							"of items is out of date with the latest in the " + 
							"database. You must cancel your change and re-save. This is a " +
							"result of another user making a change while you were editing " + 
							"this record.\n";
						message += descriptionTitle + ":";
						if (!currentRow.IsNull(descriptionField))
						{
							message += currentRow[descriptionField];
						}
						message += "\n";
						message += "Field Name:" + columnName + "\n";
						message += "Database Value:";
						if (!databaseRow.IsNull(columnName))
						{
							message += databaseRow[columnName].ToString();
						}
						message += "\n";
						message += "Your original value:";

						object val = currentRow[columnName,DataRowVersion.Original];
						if (val.GetType() != typeof(DBNull))
						{
							message += val.ToString();
						}
						message += "\n";
						throw new Exception(message);
					}
				}


			}
		}
		public static void MakeSureRefreshGoesThrough(BaseEMForm form)
		{
			while (true)
			{
				try
				{
					form.Refresh();
					return;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		
	}

}
