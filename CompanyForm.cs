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
	/// Summary description for Company.
	/// </summary>
	public class CompanyForm : EMForm
							   
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox m_nameEdit;
		private System.Windows.Forms.ComboBox m_typeBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox companyListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox containerFileEdt;
        private Label label3;
        private TextBox abbrEdt;
		EMDataSet dataSet = new EMDataSet();
		

		bool IsTableEmpty(DataTable table)
		{
			if (table.Rows.Count == 0)
				return true;
			return false;
		}

		public override bool IsDeleteAllowed()
		{
			int compid = GetHeaderRow().CompID;

			EMDataSet tempSet = new EMDataSet();
			tempSet.EnforceConstraints = false;
            using (new OpenConnection(EM.IsWrite.No,AdapterHelper.Connection))
            {
                AdapterHelper.FillLocations(tempSet,compid);
			    AdapterHelper.FillContacts(tempSet,compid);
			    AdapterHelper.FillItemsFromCompID(tempSet,compid);
			    if (!IsTableEmpty(tempSet.LocationTbl) ||
				    !IsTableEmpty(tempSet.ItemTbl) ||
				    !IsTableEmpty(tempSet.ContactsTbl))
			    {
				    MessageBox.Show("Delete of the company is not allowed " + 
					    "until all locations, contacts, and items of the company have been removed",
					    "Can't delete");
				    return false;
			    }
            }
			return true;
		}

		public CompanyForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Refresh();
		}
		override public void FromControls()
		{
			EMDataSet.CompanyTblRow row = GetHeaderRow();
				
			row.CompName = m_nameEdit.Text;
			row.CompType = m_typeBox.Text;
			row.ContainerExcelFile = containerFileEdt.Text;
            row.CompNameAbbreviation = abbrEdt.Text;
		}
		override public void CommitTablesToDataSource()
		{
            using (new OpenConnection(EM.IsWrite.Yes,AdapterHelper.Connection))
    			AdapterHelper.CommitCompanyChanges(this.dataSet);
		}
		public override DataSet GetDataSet()
		{
			return dataSet;
		}
		public override OleDbConnection GetConnection()
		{
			return AdapterHelper.Connection;
		}

		override public DataRow CreateFreshRow()
		{
			EMDataSet.CompanyTblRow row = dataSet.CompanyTbl.NewCompanyTblRow();
			row.CompID = -1;
			row.CompName = "";
			row.CompType = "";
            row.CompNameAbbreviation = "";
			return row;
		}
		override public int AddNewRow(DataRow rowIn)
		{
			EMDataSet.CompanyTblRow row = (EMDataSet.CompanyTblRow)rowIn;
			row.CompID = DataInterface.GetNextKeyNumber("tblCompany");
			dataSet.CompanyTbl.AddCompanyTblRow(row);
			return base.GetRecordCount() -1;
		}

		override public DataView GetHeaderTable()
		{
			return DataInterface.ToView(dataSet.CompanyTbl);
		}
		public new EMDataSet.CompanyTblRow GetHeaderRow()
		{
			return (EMDataSet.CompanyTblRow)base.GetHeaderRow();	
		}

		override public void RefreshMainTableFromDataSource()
		{
			dataSet.Clear();
			AdapterHelper.FillCompany(dataSet);
		}
		
		override public void UpdateControls()
		{
			EMDataSet.CompanyTblRow row = GetHeaderRow();
			m_nameEdit.Text = row.CompName;
			m_typeBox.Text = row.CompType;
			if (row.IsContainerExcelFileNull())
			{
				containerFileEdt.Text = "";
			}
			else
			{
				containerFileEdt.Text = row.ContainerExcelFile;
			}
            if (row.IsCompNameAbbreviationNull())
            {
                abbrEdt.Text = "";
            }
            else
            {
                abbrEdt.Text = row.CompNameAbbreviation;
            }
			System.Collections.ArrayList list = new System.Collections.ArrayList();
			try 
			{
				allowIndexChangedUpdates = false;
				companyListBox.Items.Clear();
				foreach (EMDataSet.CompanyTblRow eachRow in dataSet.CompanyTbl.Rows)
				{
					if (!DataInterface.IsRowAlive(eachRow))
						continue;
					string companyDescription = eachRow.CompName;
					companyListBox.Items.Add(companyDescription);
				}
				companyListBox.SelectedIndex = base.Position;
			}
			finally
			{
				allowIndexChangedUpdates = true;
			}
			UpdateEnabled();
		}
		void UpdateEnabled()
		{
			bool isEmptyTable = IsEmptyTable();
			m_nameEdit.ReadOnly = isEmptyTable;
			m_typeBox.Enabled = !isEmptyTable;
			companyListBox.Enabled = !isEmptyTable;
		}

		bool allowIndexChangedUpdates = true;
		private void OnSelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (allowIndexChangedUpdates)
				{
					base.Position = companyListBox.SelectedIndex;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				DataInterface.MakeSureRefreshGoesThrough(this);
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
            this.m_nameEdit = new System.Windows.Forms.TextBox();
            this.m_typeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.companyListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.containerFileEdt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.abbrEdt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_nameEdit
            // 
            this.m_nameEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_nameEdit.Location = new System.Drawing.Point(264, 8);
            this.m_nameEdit.Name = "m_nameEdit";
            this.m_nameEdit.Size = new System.Drawing.Size(440, 20);
            this.m_nameEdit.TabIndex = 1;
            this.m_nameEdit.Text = "companyNameEdit";
            // 
            // m_typeBox
            // 
            this.m_typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_typeBox.Items.AddRange(new object[] {
            "Customer",
            "Transporter",
            "Vendor"});
            this.m_typeBox.Location = new System.Drawing.Point(376, 40);
            this.m_typeBox.Name = "m_typeBox";
            this.m_typeBox.Size = new System.Drawing.Size(144, 21);
            this.m_typeBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(264, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company Type:";
            // 
            // companyListBox
            // 
            this.companyListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.companyListBox.Location = new System.Drawing.Point(8, 8);
            this.companyListBox.Name = "companyListBox";
            this.companyListBox.Size = new System.Drawing.Size(248, 160);
            this.companyListBox.TabIndex = 0;
            this.companyListBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(272, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Default container file:";
            // 
            // containerFileEdt
            // 
            this.containerFileEdt.Location = new System.Drawing.Point(400, 120);
            this.containerFileEdt.Name = "containerFileEdt";
            this.containerFileEdt.Size = new System.Drawing.Size(280, 20);
            this.containerFileEdt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Abbreviation";
            // 
            // abbrEdt
            // 
            this.abbrEdt.Location = new System.Drawing.Point(376, 72);
            this.abbrEdt.Name = "abbrEdt";
            this.abbrEdt.Size = new System.Drawing.Size(144, 20);
            this.abbrEdt.TabIndex = 7;
            // 
            // CompanyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(712, 189);
            this.Controls.Add(this.abbrEdt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.containerFileEdt);
            this.Controls.Add(this.m_nameEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.companyListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_typeBox);
            this.Name = "CompanyForm";
            this.Text = "Company";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



	}
}
