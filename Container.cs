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
	/// Summary description for Container.
	/// </summary>
	public class Container : KeyBasedForm
	{
		private System.Data.OleDb.OleDbDataAdapter containerAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Data.OleDb.OleDbDataAdapter contPOAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter poHeaderAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter poItemAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox etaEdt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox shipDateEdt;
		private System.Windows.Forms.Button etaDateBtn;
		private System.Windows.Forms.Button shipDateBtn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button findContainerBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox containerNumberEdt;
		private System.Windows.Forms.TextBox commentEdt;
		private System.Windows.Forms.Button editContentsBtn;

		EMDataSet emDataSet = new EMDataSet();
		public Container()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataInterface.InitializeAdapterWithParameter(containerAdapter,"ContID");

			m_textBoxes = new TextBox[]{containerNumberEdt,commentEdt};
			m_textFieldNames = new string[]{"ContNumber","Comments"};
			m_dateBoxes = new TextBox[]{etaEdt,shipDateEdt};
			m_dateFieldNames = new string[]{"ETA","ShipDate"};
			m_dateButtons = new Button[]{etaDateBtn,shipDateBtn};
			Refresh();
		}

		public override  DataTable GetHeaderTable()
		{
			return emDataSet.ContainerTbl;
		}
		public override string GetTableName() 
		{
			return "tblContainer";
		}
		public override void FillTablesFromDatabase() 
		{
			emDataSet.Clear();
			DataInterface.FillAdapterWithParameter(containerAdapter,base.CurrentKey);
			containerAdapter.Fill(emDataSet.ContainerTbl);
		}
		public override void CommitTablesToDatabase() 
		{
			using (new OpenConnection(IsWrite.Yes,emConnection))
			{
				DataInterface.FillAdapterWithParameter(containerAdapter,base.CurrentKey);
				DataInterface.UpdateTableAdd(containerAdapter,emDataSet.ContainerTbl);
				DataInterface.UpdateTableDelete(containerAdapter,emDataSet.ContainerTbl);
			}
		}
		public override OleDbConnection GetConnection() {return emConnection;}
		public override string[] GetSortOrder() {return new String[]{"ContNumber"};}

		public new EMDataSet.ContainerTblRow GetHeaderRow() 
		{
			return (EMDataSet.ContainerTblRow)base.GetHeaderRow();
		}

		TextBox[] m_textBoxes;
		string[] m_textFieldNames;
		TextBox[] m_dateBoxes;
		Button[] m_dateButtons;
		string[] m_dateFieldNames;
		public override void UpdateControls()
		{
			editContentsBtn.Enabled = !IsEmptyTable();
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			findContainerBtn.Enabled = !IsEmptyTable();
			for (int i=0;i<m_textBoxes.Length;i++)
			{
				m_textBoxes[i].Enabled = !IsEmptyTable();
				if (row.IsNull(m_textFieldNames[i]))
				{
					m_textBoxes[i].Text = "";
				}
				else
				{
					m_textBoxes[i].Text = (string)row[m_textFieldNames[i]];
				}
			}
			for (int i=0;i<m_dateBoxes.Length;i++)
			{
				m_dateBoxes[i].Enabled = !IsEmptyTable();
				m_dateButtons[i].Enabled = !IsEmptyTable();
				if (row.IsNull(m_dateFieldNames[i]))
				{
					m_dateBoxes[i].Text = "";
				}
				else
				{
					DateTime date = (DateTime)row[m_dateFieldNames[i]];
					m_dateBoxes[i].Text = HelperFunctions.ToDateText(date);
				}
			}
		}
		public override void FromControls() 
		{
			EMDataSet.ContainerTblRow row = GetHeaderRow();
			for (int i=0;i<m_textBoxes.Length;i++)
			{
				row[m_textFieldNames[i]] = m_textBoxes[i].Text;
			}
			for (int i=0;i<m_dateBoxes.Length;i++)
			{
				if (m_dateBoxes[i].Text == "")
				{
					row[m_dateFieldNames[i]] = DBNull.Value;
				}
				else
				{
					row[m_dateFieldNames[i]] = m_dateBoxes[i].Text;
				}
			}
		}
		private void OnDateBtn(object sender, System.EventArgs e)
		{
			// first find the control
			int i=0;
			for (i=0;i<this.m_dateButtons.Length;i++)
			{
				if (sender == m_dateButtons[i])
				{
					break;
				}
			}
			Debug.Assert(i!= m_dateButtons.Length);
			string fieldName = m_dateFieldNames[i];
			TextBox box = m_dateBoxes[i];
			DataRow row = GetHeaderRow();
			System.DateTime dateTime;
			if (row.IsNull(fieldName))
				dateTime = System.DateTime.Today;
			else
				dateTime = (DateTime)row[fieldName];
			if (DialogResult.OK == DateTimeSelector.RequestTime(ref dateTime))
				box.Text = HelperFunctions.ToDateText(dateTime);
		}

		private void editContentsBtn_Click(object sender, System.EventArgs e)
		{
			if (IsEmptyTable())
				return;
			ContainerItem dlg = new ContainerItem(GetHeaderRow().ContID,0);
			dlg.ShowDialog();
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
			this.containerAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.contPOAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.poHeaderAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.poItemAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
			this.label1 = new System.Windows.Forms.Label();
			this.containerNumberEdt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.etaEdt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.shipDateEdt = new System.Windows.Forms.TextBox();
			this.etaDateBtn = new System.Windows.Forms.Button();
			this.shipDateBtn = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.commentEdt = new System.Windows.Forms.TextBox();
			this.findContainerBtn = new System.Windows.Forms.Button();
			this.editContentsBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// containerAdapter
			// 
			this.containerAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.containerAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.containerAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.containerAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "tblContainer", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																					   new System.Data.Common.DataColumnMapping("ContID", "ContID"),
																																																					   new System.Data.Common.DataColumnMapping("ContNumber", "ContNumber"),
																																																					   new System.Data.Common.DataColumnMapping("ETA", "ETA"),
																																																					   new System.Data.Common.DataColumnMapping("ShipDate", "ShipDate")})});
			this.containerAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblContainer WHERE (ContID = ?) AND (ContNumber = ?) AND (ETA = ? OR " +
				"? IS NULL AND ETA IS NULL) AND (ShipDate = ? OR ? IS NULL AND ShipDate IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.emConnection;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""m:\em_prog_2002.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=ReadWrite;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblContainer(Comments, ContID, ContNumber, ETA, ShipDate) VALUES (?, " +
				"?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.emConnection;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 0, "Comments"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, "ContNumber"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.DBDate, 0, "ETA"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, "ShipDate"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT Comments, ContID, ContNumber, ETA, ShipDate FROM tblContainer WHERE (ContI" +
				"D = ?)";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblContainer SET Comments = ?, ContID = ?, ContNumber = ?, ETA = ?, ShipDa" +
				"te = ? WHERE (ContID = ?) AND (ContNumber = ?) AND (ETA = ? OR ? IS NULL AND ETA" +
				" IS NULL) AND (ShipDate = ? OR ? IS NULL AND ShipDate IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.emConnection;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.VarWChar, 0, "Comments"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, "ContNumber"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.DBDate, 0, "ETA"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, "ShipDate"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ETA1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ETA", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null));
			// 
			// contPOAdapter
			// 
			this.contPOAdapter.DeleteCommand = this.oleDbDeleteCommand2;
			this.contPOAdapter.InsertCommand = this.oleDbInsertCommand2;
			this.contPOAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.contPOAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "tblContPOItem2", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("ContID", "ContID"),
																																																					  new System.Data.Common.DataColumnMapping("Heat Number", "Heat Number"),
																																																					  new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
																																																					  new System.Data.Common.DataColumnMapping("NumberOfBundles", "NumberOfBundles"),
																																																					  new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
																																																					  new System.Data.Common.DataColumnMapping("ShipQty", "ShipQty")})});
			this.contPOAdapter.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM tblContPOItem2 WHERE (ContID = ?) AND (POItemNumber = ?) AND ([Heat Number] = ? OR ? IS NULL AND [Heat Number] IS NULL) AND (InvoiceNumber = ? OR ? IS NULL AND InvoiceNumber IS NULL) AND (NumberOfBundles = ? OR ? IS NULL AND NumberOfBundles IS NULL) AND (ShipQty = ? OR ? IS NULL AND ShipQty IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.emConnection;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat_Number", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat Number", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat_Number1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat Number", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NumberOfBundles", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NumberOfBundles", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NumberOfBundles1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NumberOfBundles", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblContPOItem2(ContID, [Heat Number], InvoiceNumber, NumberOfBundles," +
				" POItemNumber, ShipQty) VALUES (?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.emConnection;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Heat_Number", System.Data.OleDb.OleDbType.VarWChar, 50, "Heat Number"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "InvoiceNumber"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfBundles", System.Data.OleDb.OleDbType.Currency, 0, "NumberOfBundles"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipQty", System.Data.OleDb.OleDbType.Currency, 0, "ShipQty"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT ContID, [Heat Number], InvoiceNumber, NumberOfBundles, POItemNumber, ShipQ" +
				"ty FROM tblContPOItem2 WHERE (ContID = ?)";
			this.oleDbSelectCommand2.Connection = this.emConnection;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE tblContPOItem2 SET ContID = ?, [Heat Number] = ?, InvoiceNumber = ?, NumberOfBundles = ?, POItemNumber = ?, ShipQty = ? WHERE (ContID = ?) AND (POItemNumber = ?) AND ([Heat Number] = ? OR ? IS NULL AND [Heat Number] IS NULL) AND (InvoiceNumber = ? OR ? IS NULL AND InvoiceNumber IS NULL) AND (NumberOfBundles = ? OR ? IS NULL AND NumberOfBundles IS NULL) AND (ShipQty = ? OR ? IS NULL AND ShipQty IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.emConnection;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Heat_Number", System.Data.OleDb.OleDbType.VarWChar, 50, "Heat Number"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 50, "InvoiceNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("NumberOfBundles", System.Data.OleDb.OleDbType.Currency, 0, "NumberOfBundles"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ShipQty", System.Data.OleDb.OleDbType.Currency, 0, "ShipQty"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat_Number", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat Number", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Heat_Number1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Heat Number", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NumberOfBundles", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NumberOfBundles", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_NumberOfBundles1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NumberOfBundles", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ShipQty1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ShipQty", System.Data.DataRowVersion.Original, null));
			// 
			// poHeaderAdapter
			// 
			this.poHeaderAdapter.SelectCommand = this.oleDbSelectCommand3;
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
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = @"SELECT CancelDate, Comments, ExchangeRate, FOB, OtherTotal, PODate, POID, PONumber, ShipCode, ShipToAddress, ShipToCompany, ShipToContact, ShipToCountry, ShipToEMail, ShipToFax, ShipToLocationName, ShipToName, ShipToPhone, Status, Terms, USTotal, VendAddress, VendCompany, VendContact, VendCountry, VendEMail, VendFax, VendLocationName, VendName, VendPhone FROM tblPOHeader2 WHERE (POID = ?)";
			this.oleDbSelectCommand3.Connection = this.emConnection;
			this.oleDbSelectCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			// 
			// poItemAdapter
			// 
			this.poItemAdapter.SelectCommand = this.oleDbSelectCommand4;
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
																																																				  new System.Data.Common.DataColumnMapping("ItemAccessCode", "ItemAccessCode"),
																																																				  new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
																																																				  new System.Data.Common.DataColumnMapping("ItemName", "ItemName"),
																																																				  new System.Data.Common.DataColumnMapping("Length", "Length"),
																																																				  new System.Data.Common.DataColumnMapping("MillConfirmNumber", "MillConfirmNumber"),
																																																				  new System.Data.Common.DataColumnMapping("MillShipDate", "MillShipDate"),
																																																				  new System.Data.Common.DataColumnMapping("POID", "POID"),
																																																				  new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
																																																				  new System.Data.Common.DataColumnMapping("Qty", "Qty"),
																																																				  new System.Data.Common.DataColumnMapping("SeqNumber", "SeqNumber"),
																																																				  new System.Data.Common.DataColumnMapping("SizeOfItem", "SizeOfItem"),
																																																				  new System.Data.Common.DataColumnMapping("UM", "UM")})});
			// 
			// oleDbSelectCommand4
			// 
			this.oleDbSelectCommand4.CommandText = @"SELECT AcknowledgeDate, CancelDate, CommAmount, Comments, CommRate, CustAmount, CustRate, DateRequired, ItemAccessCode, ItemDesc, ItemName, Length, MillConfirmNumber, MillShipDate, POID, POItemNumber, Qty, SeqNumber, SizeOfItem, UM FROM tblPOItem2 WHERE (POID = ?)";
			this.oleDbSelectCommand4.Connection = this.emConnection;
			this.oleDbSelectCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Container Number:";
			// 
			// containerNumberEdt
			// 
			this.containerNumberEdt.Location = new System.Drawing.Point(120, 16);
			this.containerNumberEdt.Name = "containerNumberEdt";
			this.containerNumberEdt.TabIndex = 2;
			this.containerNumberEdt.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "ETA";
			// 
			// etaEdt
			// 
			this.etaEdt.Location = new System.Drawing.Point(56, 48);
			this.etaEdt.Name = "etaEdt";
			this.etaEdt.TabIndex = 4;
			this.etaEdt.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(200, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Ship Date:";
			// 
			// shipDateEdt
			// 
			this.shipDateEdt.Location = new System.Drawing.Point(272, 48);
			this.shipDateEdt.Name = "shipDateEdt";
			this.shipDateEdt.Size = new System.Drawing.Size(64, 20);
			this.shipDateEdt.TabIndex = 6;
			this.shipDateEdt.Text = "";
			// 
			// etaDateBtn
			// 
			this.etaDateBtn.Location = new System.Drawing.Point(168, 48);
			this.etaDateBtn.Name = "etaDateBtn";
			this.etaDateBtn.Size = new System.Drawing.Size(24, 23);
			this.etaDateBtn.TabIndex = 7;
			this.etaDateBtn.Text = "...";
			this.etaDateBtn.Click += new System.EventHandler(this.OnDateBtn);
			// 
			// shipDateBtn
			// 
			this.shipDateBtn.Location = new System.Drawing.Point(344, 48);
			this.shipDateBtn.Name = "shipDateBtn";
			this.shipDateBtn.Size = new System.Drawing.Size(24, 23);
			this.shipDateBtn.TabIndex = 8;
			this.shipDateBtn.Text = "...";
			this.shipDateBtn.Click += new System.EventHandler(this.OnDateBtn);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 24);
			this.label4.TabIndex = 9;
			this.label4.Text = "Comments:";
			// 
			// commentEdt
			// 
			this.commentEdt.AcceptsReturn = true;
			this.commentEdt.Location = new System.Drawing.Point(104, 96);
			this.commentEdt.Multiline = true;
			this.commentEdt.Name = "commentEdt";
			this.commentEdt.Size = new System.Drawing.Size(648, 128);
			this.commentEdt.TabIndex = 10;
			this.commentEdt.Text = "textBox2";
			// 
			// findContainerBtn
			// 
			this.findContainerBtn.Location = new System.Drawing.Point(232, 16);
			this.findContainerBtn.Name = "findContainerBtn";
			this.findContainerBtn.Size = new System.Drawing.Size(32, 23);
			this.findContainerBtn.TabIndex = 11;
			this.findContainerBtn.Text = "...";
			// 
			// editContentsBtn
			// 
			this.editContentsBtn.Location = new System.Drawing.Point(16, 232);
			this.editContentsBtn.Name = "editContentsBtn";
			this.editContentsBtn.Size = new System.Drawing.Size(96, 23);
			this.editContentsBtn.TabIndex = 12;
			this.editContentsBtn.Text = "Edit Contents...";
			this.editContentsBtn.Click += new System.EventHandler(this.editContentsBtn_Click);
			// 
			// Container
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 266);
			this.Controls.Add(this.editContentsBtn);
			this.Controls.Add(this.findContainerBtn);
			this.Controls.Add(this.commentEdt);
			this.Controls.Add(this.shipDateEdt);
			this.Controls.Add(this.etaEdt);
			this.Controls.Add(this.containerNumberEdt);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.shipDateBtn);
			this.Controls.Add(this.etaDateBtn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Container";
			this.Text = "Container";
			this.ResumeLayout(false);

		}
		#endregion



	}
}
