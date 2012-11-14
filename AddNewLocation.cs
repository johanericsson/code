using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for AddNewLocation.
	/// </summary>
	public class AddNewLocation : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label companyNameStatic;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox locationEdt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Data.OleDb.OleDbDataAdapter locationAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Windows.Forms.ComboBox countryCombo;
		private System.Data.OleDb.OleDbDataAdapter countryAdapter;
		private System.Data.OleDb.OleDbDataAdapter companyAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Windows.Forms.TextBox addressEdt;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Windows.Forms.Button addNewCountryBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		void UpdateCountryCombo()
		{
			try
			{
				enableComboChanged = false;
				DataInterface.UpdateComboBox(dataSet.CountryTbl.DefaultView,
					"CountryID","CountryName",countryCombo,null);
				okBtn.Enabled = false;
			}
			finally
			{
				enableComboChanged = true;
			}
		}

		public AddNewLocation(int compid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			DataInterface.InitializeAdapterWithParameter(companyAdapter,"CompID");
			DataInterface.FillAdapterWithParameter(companyAdapter,compid);
			countryAdapter.Fill(dataSet.CountryTbl);
			companyAdapter.Fill(dataSet.CompanyTbl);
			if (dataSet.CompanyTbl.Rows.Count < 1)
				throw new Exception("Company no longer exists. Addition aborted");
			EMDataSet.CompanyTblRow companyRow = (EMDataSet.CompanyTblRow)
				dataSet.CompanyTbl.Rows[0];
			companyNameStatic.Text = companyRow.CompName;
			UpdateCountryCombo();
		}

		EMDataSet dataSet = new EMDataSet();

		
		bool enableComboChanged = true;
		private void OnCountryComboChanged(object sender, System.EventArgs e)
		{
			if (!enableComboChanged)
				return;
			string current = countryCombo.Text;
			okBtn.Enabled = countryCombo.Text != "";
		}
		public int m_locationID = -1;
		private void okBtn_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				if (!(countryCombo.SelectedItem is TaggedItem))
					return;
				TaggedItem item = (TaggedItem)
					countryCombo.SelectedItem;
				EMDataSet.CountryTblRow countryRow = dataSet.CountryTbl.FindByCountryID(item.key);
				EMDataSet.LocationTblRow newRow = dataSet.LocationTbl.NewLocationTblRow();
				newRow.CompID = (int)dataSet.CompanyTbl.Rows[0]["CompID"];
				newRow.CountryID = countryRow.CountryID;
				newRow.LocID = DataInterface.GetNextKeyNumber("tblLocation");
				newRow.LocName = locationEdt.Text;
				newRow.Address = addressEdt.Text;
				newRow.ExcelFile = "";
				dataSet.LocationTbl.AddLocationTblRow(newRow);
				DataInterface.UpdateTableAdd(locationAdapter,dataSet.LocationTbl);
				m_locationID = newRow.LocID;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.DialogResult = DialogResult.None;
			}
		}

		private void addNewCountryBtn_Click(object sender, System.EventArgs e)
		{
			AddNewCountry dlg = new AddNewCountry();
			DialogResult res = dlg.ShowDialog();
			if (res != DialogResult.OK)
			{
				return;
			}
			this.DialogResult = DialogResult.None;
			if (dlg.countryEdt.Text == "")
			{
				return;
			}
			EMDataSet.CountryTblRow newRow = dataSet.CountryTbl.NewCountryTblRow();
			newRow.CountryID = DataInterface.GetNextKeyNumber("tblCountry");
			newRow.CountryName = dlg.countryEdt.Text;
			dataSet.CountryTbl.AddCountryTblRow(newRow);
			DataInterface.UpdateTableAdd(countryAdapter,dataSet.CountryTbl);
			UpdateCountryCombo();
			DataInterface.SelectComboBox(countryCombo,newRow.CountryID);
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
			this.companyNameStatic = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.locationEdt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.countryCombo = new System.Windows.Forms.ComboBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.locationAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.countryAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.companyAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.addressEdt = new System.Windows.Forms.TextBox();
			this.addNewCountryBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Company Name:";
			// 
			// companyNameStatic
			// 
			this.companyNameStatic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.companyNameStatic.Location = new System.Drawing.Point(136, 16);
			this.companyNameStatic.Name = "companyNameStatic";
			this.companyNameStatic.Size = new System.Drawing.Size(308, 23);
			this.companyNameStatic.TabIndex = 1;
			this.companyNameStatic.Text = "Company Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.TabIndex = 2;
			this.label2.Text = "Location Name:";
			// 
			// locationEdt
			// 
			this.locationEdt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.locationEdt.Location = new System.Drawing.Point(136, 48);
			this.locationEdt.Name = "locationEdt";
			this.locationEdt.Size = new System.Drawing.Size(304, 20);
			this.locationEdt.TabIndex = 3;
			this.locationEdt.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "Address:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.Location = new System.Drawing.Point(16, 200);
			this.label4.Name = "label4";
			this.label4.TabIndex = 6;
			this.label4.Text = "Country:";
			// 
			// countryCombo
			// 
			this.countryCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.countryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.countryCombo.Location = new System.Drawing.Point(136, 200);
			this.countryCombo.Name = "countryCombo";
			this.countryCombo.Size = new System.Drawing.Size(304, 21);
			this.countryCombo.TabIndex = 7;
			this.countryCombo.SelectedIndexChanged += new System.EventHandler(this.OnCountryComboChanged);
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(304, 240);
			this.okBtn.Name = "okBtn";
			this.okBtn.TabIndex = 8;
			this.okBtn.Text = "OK";
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(392, 240);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.TabIndex = 9;
			this.cancelBtn.Text = "Cancel";
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""m:\em_prog_2002.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=ReadWrite;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// locationAdapter
			// 
			this.locationAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.locationAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.locationAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.locationAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tblLocation2", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("Address", "Address"),
																																																					  new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																					  new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
																																																					  new System.Data.Common.DataColumnMapping("LocID", "LocID"),
																																																					  new System.Data.Common.DataColumnMapping("LocName", "LocName")})});
			this.locationAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblLocation2 WHERE (LocID = ?) AND (CompID = ?) AND (CountryID = ?) A" +
				"ND (LocName = ? OR ? IS NULL AND LocName IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.emConnection;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LocName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocName", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblLocation2(Address, CompID, CountryID, LocID, LocName) VALUES (?, ?" +
				", ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.emConnection;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT Address, CompID, CountryID, LocID, LocName FROM tblLocation2";
			this.oleDbSelectCommand2.Connection = this.emConnection;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblLocation2 SET Address = ?, CompID = ?, CountryID = ?, LocID = ?, LocNam" +
				"e = ? WHERE (LocID = ?) AND (CompID = ?) AND (CountryID = ?) AND (LocName = ? OR" +
				" ? IS NULL AND LocName IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.emConnection;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LocName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LocName", System.Data.DataRowVersion.Original, null));
			// 
			// countryAdapter
			// 
			this.countryAdapter.DeleteCommand = this.oleDbDeleteCommand2;
			this.countryAdapter.InsertCommand = this.oleDbInsertCommand2;
			this.countryAdapter.SelectCommand = this.oleDbSelectCommand3;
			this.countryAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "tblCountry", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
																																																				   new System.Data.Common.DataColumnMapping("CountryName", "CountryName")})});
			this.countryAdapter.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM tblCountry WHERE (CountryID = ?) AND (CountryName = ?)";
			this.oleDbDeleteCommand2.Connection = this.emConnection;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryName", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblCountry(CountryID, CountryName) VALUES (?, ?)";
			this.oleDbInsertCommand2.Connection = this.emConnection;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, "CountryName"));
			// 
			// oleDbSelectCommand3
			// 
			this.oleDbSelectCommand3.CommandText = "SELECT CountryID, CountryName FROM tblCountry ORDER BY CountryName";
			this.oleDbSelectCommand3.Connection = this.emConnection;
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE tblCountry SET CountryID = ?, CountryName = ? WHERE (CountryID = ?) AND (C" +
				"ountryName = ?)";
			this.oleDbUpdateCommand2.Connection = this.emConnection;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, "CountryName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CountryName", System.Data.DataRowVersion.Original, null));
			// 
			// companyAdapter
			// 
			this.companyAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.companyAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "tblCompany", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																				   new System.Data.Common.DataColumnMapping("CompName", "CompName"),
																																																				   new System.Data.Common.DataColumnMapping("CompType", "CompType")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CompID, CompName, CompType FROM tblCompany WHERE (CompID = ?)";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			// 
			// addressEdt
			// 
			this.addressEdt.AcceptsReturn = true;
			this.addressEdt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.addressEdt.Location = new System.Drawing.Point(136, 80);
			this.addressEdt.Multiline = true;
			this.addressEdt.Name = "addressEdt";
			this.addressEdt.Size = new System.Drawing.Size(304, 104);
			this.addressEdt.TabIndex = 5;
			this.addressEdt.Text = "";
			// 
			// addNewCountryBtn
			// 
			this.addNewCountryBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.addNewCountryBtn.Location = new System.Drawing.Point(448, 200);
			this.addNewCountryBtn.Name = "addNewCountryBtn";
			this.addNewCountryBtn.Size = new System.Drawing.Size(16, 23);
			this.addNewCountryBtn.TabIndex = 10;
			this.addNewCountryBtn.Text = "+";
			this.addNewCountryBtn.Click += new System.EventHandler(this.addNewCountryBtn_Click);
			// 
			// AddNewLocation
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(472, 270);
			this.Controls.Add(this.addNewCountryBtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.countryCombo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.addressEdt);
			this.Controls.Add(this.locationEdt);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.companyNameStatic);
			this.Controls.Add(this.label1);
			this.Name = "AddNewLocation";
			this.Text = "Add new location";
			this.ResumeLayout(false);

		}
		#endregion



	}
}
