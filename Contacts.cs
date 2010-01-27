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
	/// Summary description for Contacts.
	/// </summary>
	public class Contacts : EMForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox companyCombo;
		private System.Windows.Forms.ListBox contactList;
		private System.Windows.Forms.TextBox phoneEdt;
		private System.Windows.Forms.TextBox faxEdt;
		private System.Windows.Forms.TextBox emailEdt;
		private EM.EMDataSet emDataSet;
		private System.Data.OleDb.OleDbDataAdapter companyAdapter;
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter contactsAdapter;
		private System.Windows.Forms.TextBox firstNameEdt;
		private System.Windows.Forms.TextBox lastNameEdt;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public EMDataSet.CompanyTblRow GetCompanyRow()
		{
			return (EMDataSet.CompanyTblRow)
				emDataSet.CompanyTbl.Rows[companyCombo.SelectedIndex];
		}
		public override DataView GetHeaderTable()
		{
			return emDataSet.ContactsTbl.DefaultView;
		}
		public new EMDataSet.ContactsTblRow GetHeaderRow()
		{
			return (EMDataSet.ContactsTblRow)base.GetHeaderRow();
		}
		public override void RefreshMainTableFromDataSource() 
		{
			emDataSet.Clear();
			this.companyAdapter.Fill(emDataSet,"CompanyTbl");
			if (emDataSet.CompanyTbl.Rows.Count == 0)
				throw new Exception("Error: No companies found. Use the company form to enter some companies into the system.");
			int previousIndex = companyCombo.SelectedIndex;
			m_isCompanyChangedEnabled = false;
			DataInterface.UpdateComboBox(emDataSet.CompanyTbl.DefaultView,"CompName",this.companyCombo);
			if (previousIndex < 0)
				previousIndex = 0;
			if (previousIndex >= emDataSet.CompanyTbl.Rows.Count)
				previousIndex = emDataSet.CompanyTbl.Rows.Count - 1;
			companyCombo.SelectedIndex = previousIndex;
			m_isCompanyChangedEnabled = true;
			DataInterface.FillAdapterWithParameter(contactsAdapter,GetCompanyRow().CompID);
			this.contactsAdapter.Fill(emDataSet,"ContactsTbl");
		}

		bool m_isCompanyChangedEnabled = true;
		
		public override void CommitTablesToDataSource() 
		{
			DataInterface.UpdateTable(contactsAdapter,emDataSet.ContactsTbl);
		}
		public override void UpdateControls() 
		{
			EMDataSet.ContactsTblRow row = GetHeaderRow();
			firstNameEdt.Text = row.FirstName;
			lastNameEdt.Text = row.LastName;
			phoneEdt.Text =row.Phone;
			faxEdt.Text = row.Fax;
			emailEdt.Text = row.EMail;
			m_isContactsEnabled = false;
			DataInterface.UpdateListBox(emDataSet.ContactsTbl,"LastName",this.contactList);
			if (!IsEmptyTable())
				contactList.SelectedIndex = base.Position;
			m_isContactsEnabled = true;
		}
		void UpdateEnabled()
		{
			bool isEmptyTable = base.IsEmptyTable();
			firstNameEdt.Enabled = !isEmptyTable;
			lastNameEdt.Enabled = !isEmptyTable;
			phoneEdt.Enabled = !isEmptyTable;
			faxEdt.Enabled = !isEmptyTable;
			emailEdt.Enabled = !isEmptyTable;
		}
		public override void FromControls() 
		{
			EMDataSet.ContactsTblRow row = GetHeaderRow();
			row.FirstName = firstNameEdt.Text;
			row.LastName = lastNameEdt.Text;
			row.Phone = phoneEdt.Text;
			row.Fax = faxEdt.Text;
			row.EMail = emailEdt.Text;
		}
			
		public override DataRow CreateFreshRow() 
		{
			EMDataSet.ContactsTblRow row = emDataSet.ContactsTbl.NewContactsTblRow();
			row.CompID = GetCompanyRow().CompID;
			row.FirstName = "";
			row.LastName = "";
			row.Phone = "";
			row.Fax = "";
			row.EMail = "";
			return row;
		}			

		public override int AddNewRow(DataRow rowIn) 
		{
			EMDataSet.ContactsTblRow row = (EMDataSet.ContactsTblRow)rowIn;
			row.ContactID = DataInterface.GetNextKeyNumber("tblContacts");
			emDataSet.ContactsTbl.AddContactsTblRow(row);
			return GetRecordCount() - 1;
		}
		public override OleDbConnection GetConnection() 
		{
			return emConnection;
		}
		public override DataSet GetDataSet() 
		{
			return emDataSet;
		}
			
		public Contacts()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataInterface.InitializeAdapterWithParameter(contactsAdapter,"CompID");

			base.Refresh();
		}

		private void OnCompanyChanged(object sender, System.EventArgs e)
		{
			if (m_isCompanyChangedEnabled)
				Refresh();
		}
		bool m_isContactsEnabled = true;
		private void OnContactChanged(object sender, System.EventArgs e)
		{
			if (m_isContactsEnabled)
			{
				base.Position = contactList.SelectedIndex;
			}
		
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
			this.companyCombo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.contactList = new System.Windows.Forms.ListBox();
			this.firstNameEdt = new System.Windows.Forms.TextBox();
			this.lastNameEdt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.phoneEdt = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.faxEdt = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.emailEdt = new System.Windows.Forms.TextBox();
			this.emDataSet = new EM.EMDataSet();
			this.companyAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.contactsAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.emDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// companyCombo
			// 
			this.companyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.companyCombo.Location = new System.Drawing.Point(72, 8);
			this.companyCombo.Name = "companyCombo";
			this.companyCombo.Size = new System.Drawing.Size(168, 21);
			this.companyCombo.TabIndex = 0;
			this.companyCombo.SelectedIndexChanged += new System.EventHandler(this.OnCompanyChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Company:";
			// 
			// contactList
			// 
			this.contactList.Location = new System.Drawing.Point(8, 40);
			this.contactList.Name = "contactList";
			this.contactList.Size = new System.Drawing.Size(264, 498);
			this.contactList.TabIndex = 2;
			this.contactList.SelectedIndexChanged += new System.EventHandler(this.OnContactChanged);
			// 
			// firstNameEdt
			// 
			this.firstNameEdt.Location = new System.Drawing.Point(328, 64);
			this.firstNameEdt.Name = "firstNameEdt";
			this.firstNameEdt.Size = new System.Drawing.Size(160, 20);
			this.firstNameEdt.TabIndex = 3;
			this.firstNameEdt.Text = "textBox1";
			// 
			// lastNameEdt
			// 
			this.lastNameEdt.Location = new System.Drawing.Point(496, 64);
			this.lastNameEdt.Name = "lastNameEdt";
			this.lastNameEdt.Size = new System.Drawing.Size(176, 20);
			this.lastNameEdt.TabIndex = 4;
			this.lastNameEdt.Text = "textBox2";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(280, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Name:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(280, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Phone:";
			// 
			// phoneEdt
			// 
			this.phoneEdt.Location = new System.Drawing.Point(328, 88);
			this.phoneEdt.Name = "phoneEdt";
			this.phoneEdt.Size = new System.Drawing.Size(216, 20);
			this.phoneEdt.TabIndex = 7;
			this.phoneEdt.Text = "textBox3";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(280, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Fax:";
			// 
			// faxEdt
			// 
			this.faxEdt.Location = new System.Drawing.Point(328, 112);
			this.faxEdt.Name = "faxEdt";
			this.faxEdt.Size = new System.Drawing.Size(216, 20);
			this.faxEdt.TabIndex = 9;
			this.faxEdt.Text = "textBox4";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(280, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "EMail:";
			// 
			// emailEdt
			// 
			this.emailEdt.Location = new System.Drawing.Point(328, 136);
			this.emailEdt.Name = "emailEdt";
			this.emailEdt.Size = new System.Drawing.Size(216, 20);
			this.emailEdt.TabIndex = 11;
			this.emailEdt.Text = "textBox5";
			// 
			// emDataSet
			// 
			this.emDataSet.DataSetName = "EMDataSet";
			this.emDataSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// companyAdapter
			// 
			this.companyAdapter.DeleteCommand = this.oleDbDeleteCommand2;
			this.companyAdapter.InsertCommand = this.oleDbInsertCommand2;
			this.companyAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.companyAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "tblCompany", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																				   new System.Data.Common.DataColumnMapping("CompName", "CompName"),
																																																				   new System.Data.Common.DataColumnMapping("CompType", "CompType")})});
			this.companyAdapter.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""m:\\EM_Prog_2002.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
			// 
			// contactsAdapter
			// 
			this.contactsAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.contactsAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.contactsAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.contactsAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tblContacts", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																					 new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
																																																					 new System.Data.Common.DataColumnMapping("EMail", "EMail"),
																																																					 new System.Data.Common.DataColumnMapping("Fax", "Fax"),
																																																					 new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
																																																					 new System.Data.Common.DataColumnMapping("LastName", "LastName"),
																																																					 new System.Data.Common.DataColumnMapping("Phone", "Phone")})});
			this.contactsAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CompID, CompName, CompType FROM tblCompany ORDER BY CompName";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO tblCompany(CompID, CompName, CompType) VALUES (?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.emConnection;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 50, "CompName"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 15, "CompType"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE tblCompany SET CompID = ?, CompName = ?, CompType = ? WHERE (CompID = ?) A" +
				"ND (CompName = ? OR ? IS NULL AND CompName IS NULL) AND (CompType = ? OR ? IS NU" +
				"LL AND CompType IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.emConnection;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 50, "CompName"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 15, "CompType"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM tblCompany WHERE (CompID = ?) AND (CompName = ? OR ? IS NULL AND Comp" +
				"Name IS NULL) AND (CompType = ? OR ? IS NULL AND CompType IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.emConnection;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT CompID, ContactID, EMail, Fax, FirstName, LastName, Phone FROM tblContacts" +
				" WHERE (CompID = ?) ORDER BY LastName, FirstName";
			this.oleDbSelectCommand2.Connection = this.emConnection;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblContacts(CompID, ContactID, EMail, Fax, FirstName, LastName, Phone" +
				") VALUES (?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.emConnection;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EMail", System.Data.OleDb.OleDbType.VarWChar, 50, "EMail"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 50, "Fax"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarWChar, 50, "FirstName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarWChar, 50, "LastName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 50, "Phone"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblContacts SET CompID = ?, ContactID = ?, EMail = ?, Fax = ?, FirstName =" +
				" ?, LastName = ?, Phone = ? WHERE (ContactID = ?) AND (CompID = ?) AND (EMail = " +
				"?) AND (Fax = ?) AND (FirstName = ?) AND (LastName = ?) AND (Phone = ?)";
			this.oleDbUpdateCommand1.Connection = this.emConnection;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("EMail", System.Data.OleDb.OleDbType.VarWChar, 50, "EMail"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 50, "Fax"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarWChar, 50, "FirstName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarWChar, 50, "LastName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 50, "Phone"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EMail", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EMail", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Fax", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LastName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Phone", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblContacts WHERE (ContactID = ?) AND (CompID = ?) AND (EMail = ?) AN" +
				"D (Fax = ?) AND (FirstName = ?) AND (LastName = ?) AND (Phone = ?)";
			this.oleDbDeleteCommand1.Connection = this.emConnection;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EMail", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EMail", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Fax", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LastName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Phone", System.Data.DataRowVersion.Original, null));
			// 
			// Contacts
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(712, 549);
			this.Controls.Add(this.emailEdt);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.faxEdt);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.phoneEdt);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lastNameEdt);
			this.Controls.Add(this.firstNameEdt);
			this.Controls.Add(this.contactList);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.companyCombo);
			this.Name = "Contacts";
			this.Text = "Contacts";
			((System.ComponentModel.ISupportInitialize)(this.emDataSet)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		

		
	}
}
