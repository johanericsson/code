using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;


namespace EM
{
	/// <summary>
	/// Summary description for KeyBasedForm.
	/// </summary>
	public class KeyBasedForm : 
		//System.Windows.Forms.Form, 
		BaseEMForm,
		IToolbarInterface
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		// Interface for the derived type
		public virtual bool IsDeleteAllowed() {return true;}
		public virtual DataTable GetHeaderTable(){Debug.Assert(false); return null;}
		public virtual void InitializeDataRow(DataRow newRow){}
		public virtual string GetTableName() {Debug.Assert(false);return null;}
		public virtual void FillTablesFromDatabase() {Debug.Assert(false);}
		public virtual void CommitTablesToDatabase() {Debug.Assert(false);}
		public virtual void UpdateControls() {Debug.Assert(false);}
		public override void FromControls() {Debug.Assert(false);}
		public virtual OleDbConnection GetConnection() {Debug.Assert(false);return null;}
		public virtual string[] GetSortOrder() {Debug.Assert(false);return null;}
		public virtual void ClearDataSet() {Debug.Assert(false);}
		// Internal helper functions


		public override bool IsChanged()
		{
			DataTable changedTable = GetHeaderTable().GetChanges();
			bool isChanged = (changedTable != null);
			return isChanged;
		}


		// From BaseEMForm
		public override void Commit()
		{
			CommitTablesToDatabase();
		}

		public override bool IsEmptyTable()
		{
			int size = GetHeaderTable().Rows.Count;
			return size == 0;
		}

		public int GetKeyFromField(string field,string value)
		{
			return DataInterface.GetKeyFromField(GetConnection(),GetTableName(),
							GetKeyField().ColumnName,field,value);
		}

		public bool DoesKeyExistInDatabase(int key)
		{
			string keyColumn = GetKeyField().ColumnName;
			int keyID = GetKeyFromField(keyColumn,key.ToString());
			return (keyID != -1);
		}
		public int GetExistingKey()
		{
			string keyColumn = GetKeyField().ColumnName;
			string query = "SELECT TOP 1 " + keyColumn + " FROM " + 
				GetTableName() + " ORDER BY " + keyColumn + " DESC";
			OleDbCommand getMyPOID = 
				new OleDbCommand(query,GetConnection());
			using (OleDbDataReader reader = getMyPOID.ExecuteReader())
			{
				if (!reader.HasRows)
					return -1;
				bool last = reader.Read();
				return reader.GetInt32(0);
			}
		}
		public override void Refresh()
		{
			using (new OpenConnection(IsWrite.No,GetConnection()))
			{
				if (!DoesKeyExistInDatabase(CurrentKey))
				{
					this.m_currentKey = GetExistingKey();
				}
				FillTablesFromDatabase();
			}
			UpdateControls();
		}
		public virtual DataColumn GetKeyField()
		{
			DataTable table = GetHeaderTable();
			Debug.Assert(table.PrimaryKey.Length == 1);
			return GetHeaderTable().PrimaryKey[0];
		}

		public override DataRow GetHeaderRow()
		{
			if (IsEmptyTable())
				return GetHeaderTable().NewRow();
			DataTable table = GetHeaderTable();
			DataColumn keyColumn = GetKeyField();
			string columnName = keyColumn.ColumnName;
			DataRow headerRow = table.Rows.Find(CurrentKey);
			if (headerRow == null)
				return table.Rows[0];
			return headerRow;
		}

		public int CurrentKey
		{
			get
			{
				return m_currentKey;
			}
			set
			{
				if (!TryToCommit())
					return;
				m_currentKey = value;
				Refresh();
			}
		}

		public struct SortCriteria
		{
			public string fieldName;
			public object currentValue;
		};
	
		public void MoveToNextKey(bool next)
		{
			FromControls();
			OleDbConnection connection = GetConnection();
			string tableName = GetTableName();
			string keyField = GetKeyField().ColumnName;
			string[] sortCriteria = GetSortOrder();
			ArrayList formattedValues = new ArrayList();
			DataRow row = GetHeaderRow();
			foreach (string fieldName in sortCriteria)
			{
				string formatted;
				object currentValue = row[fieldName];
				System.Type type = currentValue.GetType();
				if (type == typeof(string))
				{
					formatted = "'" + DataInterface.ExpandQuotes((string)currentValue) + "'";
				}
				else
					if (type == typeof(DateTime))
				{
					formatted = "#" + 
						HelperFunctions.ToDateText((DateTime)currentValue)
						+ "#";
				}
                    else
                    if (type == typeof(int))
                    {
                        formatted = currentValue.ToString();
                    }
                    else
                        if (type == typeof(DBNull))
                        {
                            formatted = "#" + HelperFunctions.ToDateText(new DateTime(1950, 1, 1, 1, 1, 1, 0))
                                + "#";
                        }

                        else throw new Exception("BUG. not supported sort criteria");

				formattedValues.Add(formatted);
			}
			string[] formattedStringValues = (string[])
				formattedValues.ToArray(typeof(string));
			string query = "SELECT TOP 1 ";
			query += keyField;
			query += " from "+ tableName + " where ";
			string currentPart = "";
			for(int i=0;i<sortCriteria.Length;i++)
			{

				currentPart = "(";
				for (int j=0;
					j<i;j++)
				{
					currentPart += (sortCriteria[j] + " = " + 
						formattedStringValues[j]);
					currentPart += " AND ";
				}
				string comparison;
				if (next)
					comparison = " > ";
				else
					comparison = " < ";
				currentPart += (sortCriteria[i] + comparison + 
					formattedStringValues[i]);
				currentPart += ")";
				if (i!=sortCriteria.Length-1)
					currentPart += " OR ";
				query += currentPart;
			}
			query += " ORDER BY ";
			for (int i=0;i<sortCriteria.Length;i++)
			{
				query += sortCriteria[i];
				if (!next)
					query += " DESC";
				if (i!=sortCriteria.Length-1)
					query += ",";
			}
			int keyValue;
			using (new OpenConnection(IsWrite.No,connection))
			{
				OleDbCommand command = new OleDbCommand(query,connection);
				using (OleDbDataReader reader = command.ExecuteReader())
				{
					if (!reader.HasRows)
						keyValue =  -1;
					else
					{
						reader.Read();
						keyValue = reader.GetInt32(0);
					}
				}
			}
			if (keyValue != -1)
				CurrentKey = keyValue;
		}
	
		public int m_currentKey;


		//interface IToolbarInterface
		public void OnAdd()
		{
			try
			{
				if (!TryToCommit())
					return;

				ClearDataSet();
				DataTable table = GetHeaderTable();
				DataRow row = table.NewRow();
				DataColumn keyField = GetKeyField();
				int currentKey = DataInterface.GetNextKeyNumber(GetTableName());
				row[keyField] = currentKey;
				InitializeDataRow(row);
				table.Rows.Add(row);
				m_currentKey = currentKey;
				UpdateControls();
			}			
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		public void OnDelete()
		{
			if (IsEmptyTable())
				return;
			if (!IsDeleteAllowed())
				return;
			// If this row was never added to the database yet, 
			// there is no need to push anything out the database
			if (GetHeaderRow().RowState == DataRowState.Added)
			{
				GetHeaderRow().Delete();
				Refresh();
				return;
			}

			DialogResult res = 
				MessageBox.Show("Are you sure you would like to delete this selection?",
				"Are you sure?",MessageBoxButtons.YesNo);
			if (res != DialogResult.Yes)
				return;
				
			GetHeaderRow().Delete();
			CommitTablesToDatabase();
			Refresh();
		}
		public void OnCancel()
		{
			try
			{
				Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public virtual void OnNext()
		{
			try
			{
				if (IsEmptyTable())
					return;
				MoveToNextKey(true);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public virtual void OnPrevious()
		{
			try
			{
				if (IsEmptyTable())
					return;
				MoveToNextKey(false);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void OnRefresh()
		{
			try
			{
				Refresh();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public void OnUpdate()
		{
			try
			{
				TryToCommit(false);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public bool OnUpdateAdd(){return true;}
		public bool OnUpdateDelete(){return !IsEmptyTable();}
		public bool OnUpdateCancel() {return true;}
		public virtual bool OnUpdateNext()
		{
			return !IsEmptyTable();
		}
		public virtual bool OnUpdatePrevious()
		{
			return !IsEmptyTable();
		}
		public bool OnUpdateRefresh(){return false;}
		public bool OnUpdateUpdate() {return !IsEmptyTable();}

		public KeyBasedForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "KeyBasedForm";
		}
		#endregion
	}
}
