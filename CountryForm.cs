using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace EM
{
	/// <summary>
	/// Summary description for CountryForm.
	/// </summary>
	public class CountryForm : EMForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Data.OleDb.OleDbDataAdapter countryAdapter;
		private EM.EMDataSet emDataSet;
		private System.Windows.Forms.TextBox countryEdt;
		private System.Windows.Forms.TextBox recordIdEdt;
		private System.Data.OleDb.OleDbDataAdapter locationAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public override DataView GetHeaderTable() 
		{
			return DataInterface.ToView(emDataSet.CountryTbl);
			
		}
		public override bool IsDeleteAllowed()
		{
			DataTable locationsInCountry = new DataTable();
			DataInterface.FillAdapterWithParameter(locationAdapter,GetHeaderRow().CountryID);
			locationAdapter.Fill(locationsInCountry);
			if (locationsInCountry.Rows.Count != 0)
			{
				MessageBox.Show("Delete of the country is not allowed " + 
					"unless all locations in the country have been removed",
					"Can't delete");
				return false;
			}
			return true;
		}
		public override void RefreshMainTableFromDataSource() 
		{			emDataSet.Clear();
			countryAdapter.Fill(emDataSet.CountryTbl);
		}

		public override void CommitTablesToDataSource() 
		{
			DataInterface.UpdateTableDelete(countryAdapter,emDataSet.CountryTbl);
			DataInterface.UpdateTableAdd(countryAdapter,emDataSet.CountryTbl);
		}

		public new EMDataSet.CountryTblRow GetHeaderRow()
		{
			return (EMDataSet.CountryTblRow)base.GetHeaderRow();
		}

		public override void UpdateControls() 
		{
			recordIdEdt.Text = GetHeaderRow().CountryID.ToString();
			countryEdt.Text = GetHeaderRow().CountryName;
			UpdateEnabled();
		}
		public override void FromControls() 
		{
			GetHeaderRow().CountryName = countryEdt.Text;
		}
		public void UpdateEnabled() 
		{
			recordIdEdt.ReadOnly = true;
			countryEdt.ReadOnly = base.IsEmptyTable();
		}
			
		public override DataRow CreateFreshRow() 
		{
			EMDataSet.CountryTblRow row = emDataSet.CountryTbl.NewCountryTblRow();
			row.CountryName = "";
			row.CountryID = -1;
			return row;
		}
		public override int AddNewRow(DataRow rowIn) 
		{
			EMDataSet.CountryTblRow row = (EMDataSet.CountryTblRow)rowIn;
			row.CountryID = DataInterface.GetNextKeyNumber("tblCountry");
			emDataSet.CountryTbl.AddCountryTblRow(row);
			return base.GetRecordCount() - 1;
		}	
		public override OleDbConnection GetConnection() 
		{
			return emConnection;
		}
		public override DataSet GetDataSet() 
		{
			return emDataSet;
		}



		public CountryForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataInterface.InitializeAdapterWithParameter(locationAdapter,"CountryID");
			base.Refresh();
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
			this.countryEdt = new System.Windows.Forms.TextBox();
			this.recordIdEdt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.countryAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.emDataSet = new EM.EMDataSet();
			this.locationAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.emDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// countryEdt
			// 
			this.countryEdt.Location = new System.Drawing.Point(96, 72);
			this.countryEdt.Name = "countryEdt";
			this.countryEdt.Size = new System.Drawing.Size(176, 20);
			this.countryEdt.TabIndex = 3;
			this.countryEdt.Text = "textBox1";
			// 
			// recordIdEdt
			// 
			this.recordIdEdt.Location = new System.Drawing.Point(96, 32);
			this.recordIdEdt.Name = "recordIdEdt";
			this.recordIdEdt.ReadOnly = true;
			this.recordIdEdt.TabIndex = 1;
			this.recordIdEdt.Text = "textBox2";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Record ID:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Country Name:";
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""m:\em_prog_2002.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=ReadWrite;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// countryAdapter
			// 
			this.countryAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.countryAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.countryAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.countryAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "tblCountry", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
																																																				   new System.Data.Common.DataColumnMapping("CountryName", "CountryName")})});
			this.countryAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblCountry WHERE (CountryID = ?) AND (CountryName = ?)";
			this.oleDbDeleteCommand1.Connection = this.emConnection;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryName", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblCountry(CountryID, CountryName) VALUES (?, ?)";
			this.oleDbInsertCommand1.Connection = this.emConnection;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, "CountryName"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CountryID, CountryName FROM tblCountry ORDER BY CountryName";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblCountry SET CountryID = ?, CountryName = ? WHERE (CountryID = ?) AND (C" +
				"ountryName = ?)";
			this.oleDbUpdateCommand1.Connection = this.emConnection;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, "CountryName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryName", System.Data.DataRowVersion.Original, null));
			// 
			// emDataSet
			// 
			this.emDataSet.DataSetName = "EMDataSet";
			this.emDataSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// locationAdapter
			// 
			this.locationAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.locationAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tblLocation2", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("Address", "Address"),
																																																					  new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																					  new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
																																																					  new System.Data.Common.DataColumnMapping("LocID", "LocID"),
																																																					  new System.Data.Common.DataColumnMapping("LocName", "LocName")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT Address, CompID, CountryID, LocID, LocName FROM tblLocation2 WHERE (Countr" +
				"yID = ?)";
			this.oleDbSelectCommand2.Connection = this.emConnection;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"));
			// 
			// CountryForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 109);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.recordIdEdt);
			this.Controls.Add(this.countryEdt);
			this.Name = "CountryForm";
			this.Text = "CountryForm";
			((System.ComponentModel.ISupportInitialize)(this.emDataSet)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
