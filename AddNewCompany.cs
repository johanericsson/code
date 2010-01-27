using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for AddNewCompany.
	/// </summary>
	public class AddNewCompany : System.Windows.Forms.Form
	{
		private System.Data.OleDb.OleDbDataAdapter companyAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox companyNameEdt;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label companyTypeStatic;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddNewCompany(string companyType)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			companyTypeStatic.Text = companyType;
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
			this.companyAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.companyNameEdt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.companyTypeStatic = new System.Windows.Forms.Label();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// companyAdapter
			// 
			this.companyAdapter.DeleteCommand = this.oleDbDeleteCommand1;
			this.companyAdapter.InsertCommand = this.oleDbInsertCommand1;
			this.companyAdapter.SelectCommand = this.oleDbSelectCommand1;
			this.companyAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "tblCompany", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																				   new System.Data.Common.DataColumnMapping("CompName", "CompName"),
																																																				   new System.Data.Common.DataColumnMapping("CompType", "CompType")})});
			this.companyAdapter.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM tblCompany WHERE (CompID = ?) AND (CompName = ? OR ? IS NULL AND Comp" +
				"Name IS NULL) AND (CompType = ? OR ? IS NULL AND CompType IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.emConnection;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""m:\em_prog_2002.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=ReadWrite;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO tblCompany(CompID, CompName, CompType) VALUES (?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.emConnection;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 50, "CompName"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 15, "CompType"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT CompID, CompName, CompType FROM tblCompany";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = "UPDATE tblCompany SET CompID = ?, CompName = ?, CompType = ? WHERE (CompID = ?) A" +
				"ND (CompName = ? OR ? IS NULL AND CompName IS NULL) AND (CompType = ? OR ? IS NU" +
				"LL AND CompType IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.emConnection;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 50, "CompName"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 15, "CompType"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompName", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_CompType1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompType", System.Data.DataRowVersion.Original, null));
			// 
			// companyNameEdt
			// 
			this.companyNameEdt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.companyNameEdt.Location = new System.Drawing.Point(120, 56);
			this.companyNameEdt.Name = "companyNameEdt";
			this.companyNameEdt.Size = new System.Drawing.Size(460, 20);
			this.companyNameEdt.TabIndex = 3;
			this.companyNameEdt.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Company Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Adding a new ";
			// 
			// companyTypeStatic
			// 
			this.companyTypeStatic.Location = new System.Drawing.Point(104, 8);
			this.companyTypeStatic.Name = "companyTypeStatic";
			this.companyTypeStatic.Size = new System.Drawing.Size(112, 16);
			this.companyTypeStatic.TabIndex = 1;
			this.companyTypeStatic.Text = "label3";
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(424, 88);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(504, 88);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = "Cancel";
			// 
			// AddNewCompany
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(592, 134);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.companyTypeStatic);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.companyNameEdt);
			this.Name = "AddNewCompany";
			this.Text = "AddNewCompany";
			this.ResumeLayout(false);

		}
		#endregion

		string companyName = "";
		public string GetCompanyName()
		{
			return companyName;
		}
		int compID = -1;
		public int GetCompanyID()
		{
			return compID;
		}
		private void OKBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				EMDataSet dataSet = new EMDataSet();
				EMDataSet.CompanyTblDataTable table = dataSet.CompanyTbl;
				EMDataSet.CompanyTblRow row = table.NewCompanyTblRow();
				row.CompID = DataInterface.GetNextKeyNumber("tblCompany");
				row.CompType = this.companyTypeStatic.Text;
				row.CompName = companyNameEdt.Text;
				row.ContainerExcelFile = "";
				table.AddCompanyTblRow(row);
				DataInterface.UpdateTableAdd(companyAdapter,table);
				companyName = companyNameEdt.Text;
				compID = row.CompID;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
