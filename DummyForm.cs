using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for DummyForm.
	/// </summary>
	public class DummyForm : System.Windows.Forms.Form
	{
		public System.Data.OleDb.OleDbDataAdapter poHeaderAdapter;
		public System.Data.OleDb.OleDbConnection emConnection;
		public System.Data.OleDb.OleDbDataAdapter poItemAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private EM.EMDataSet emDataSet1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DummyForm()
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
			this.poHeaderAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.poItemAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.emDataSet1 = new EM.EMDataSet();
			((System.ComponentModel.ISupportInitialize)(this.emDataSet1)).BeginInit();
			// 
			// poHeaderAdapter
			// 
			this.poHeaderAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.poHeaderAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.poHeaderAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.poHeaderAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tblPOHeader2", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("POID", "POID"),
																																																					  new System.Data.Common.DataColumnMapping("PONumber", "PONumber")})});
			this.poHeaderAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblPOHeader2 WHERE (POID = ?)";
			this.oleDbDeleteCommand1.Connection = this.emConnection;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POID", System.Data.DataRowVersion.Original, null));
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""m:\em_prog_2002.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=ReadWrite;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblPOHeader2(POID, PONumber) VALUES (?, ?)";
			this.oleDbInsertCommand1.Connection = this.emConnection;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 20, "PONumber"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT POID, PONumber FROM tblPOHeader2";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblPOHeader2 SET POID = ?, PONumber = ? WHERE (POID = ?)";
			this.oleDbUpdateCommand1.Connection = this.emConnection;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 20, "PONumber"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POID", System.Data.DataRowVersion.Original, null));
			// 
			// poItemAdapter
			// 
			this.poItemAdapter.DeleteCommand = this.oleDbDeleteCommand2;
			this.poItemAdapter.InsertCommand = this.oleDbInsertCommand2;
			this.poItemAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.poItemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "tblPOItem2", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
																																																				  new System.Data.Common.DataColumnMapping("POID", "POID"),
																																																				  new System.Data.Common.DataColumnMapping("ItemName", "ItemName"),
																																																				  new System.Data.Common.DataColumnMapping("SeqNumber", "SeqNumber")})});
			this.poItemAdapter.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM tblPOItem2 WHERE (POItemNumber = ?)";
			this.oleDbDeleteCommand2.Connection = this.emConnection;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblPOItem2(POItemNumber, POID, ItemName, SeqNumber) VALUES (?, ?, ?, " +
				"?)";
			this.oleDbInsertCommand2.Connection = this.emConnection;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 30, "ItemName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.SmallInt, 0, "SeqNumber"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT POItemNumber, POID, ItemName, SeqNumber FROM tblPOItem2";
			this.oleDbSelectCommand2.Connection = this.emConnection;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE tblPOItem2 SET POItemNumber = ?, POID = ?, ItemName = ?, SeqNumber = ? WHE" +
				"RE (POItemNumber = ?)";
			this.oleDbUpdateCommand2.Connection = this.emConnection;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 30, "ItemName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.SmallInt, 0, "SeqNumber"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null));
			// 
			// emDataSet1
			// 
			this.emDataSet1.DataSetName = "EMDataSet";
			this.emDataSet1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// DummyForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "DummyForm";
			this.Text = "DummyForm";
			((System.ComponentModel.ISupportInitialize)(this.emDataSet1)).EndInit();

		}
		#endregion
	}
}
