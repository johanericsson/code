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
	/// Summary description for LocationForm.
	/// </summary>
	public class LocationForm : EMForm
	{

		private System.Windows.Forms.ListBox companyList;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private EM.EMDataSet emDataSet;
		private System.Windows.Forms.ListBox m_locationList;
		private System.Windows.Forms.TextBox nameEdit;
		private System.Windows.Forms.TextBox addressEdit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private TextBox attnEdt;
        private Label label5;
        private TextBox ccEdt;
        private Label label6;
		private System.Windows.Forms.ComboBox countryCombo;


		public EMDataSet.CompanyTblRow GetCompanyRow()
		{
			return (EMDataSet.CompanyTblRow)
				emDataSet.CompanyTbl.Rows[companyList.SelectedIndex];

		}

		public override DataView GetHeaderTable()
		{
			return DataInterface.ToView(emDataSet.LocationTbl);	
		}


		public override DataRow CreateFreshRow()
		{
			EMDataSet.LocationTblRow row = emDataSet.LocationTbl.NewLocationTblRow();
			row.CompID = GetCompanyRow().CompID;
			row.LocName = "";
			row.Address = "";
			return row;
		}
		public override int AddNewRow(DataRow rowIn)
		{
			EMDataSet.LocationTblRow row = (EMDataSet.LocationTblRow)rowIn;
			row.LocID = DataInterface.GetNextKeyNumber("tblLocation");
			emDataSet.LocationTbl.AddLocationTblRow(row);
			return base.GetRecordCount() -1;
		}

		public new EMDataSet.LocationTblRow GetHeaderRow()
		{
			return (EMDataSet.LocationTblRow)base.GetHeaderRow();
		}

		public override bool IsValid()
		{
			EMDataSet.LocationTblRow row = GetHeaderRow();
			if (row.IsCountryIDNull())
			{
				MessageBox.Show("Error: No country selected");
				return false;
			}
			if (row.LocName == "")
			{
				MessageBox.Show("Error: Must enter name for location");
				return false;
			}
			return true;
		}
		public override void CommitTablesToDataSource()
		{
            using (new OpenConnection(EM.IsWrite.Yes,AdapterHelper.Connection))
	    		AdapterHelper.CommitLocationChanges(emDataSet);
		}
		
		public override void FromControls()
		{
			EMDataSet.LocationTblRow row = GetHeaderRow();
			row.CompID = GetCompanyRow().CompID;
			row.LocName = nameEdit.Text;
			row.Address = addressEdit.Text;
			if (countryCombo.SelectedIndex != -1)
				row.CountryID = 
					((TaggedItem)countryCombo.SelectedItem).key;
            if (!(ccEdt.Text == "" && row.IsCCStringNull()))
                row.CCString = ccEdt.Text;
            if (!(attnEdt.Text == "" && row.IsATTNStringNull()))
                row.ATTNString = attnEdt.Text;
		}
		public override void RefreshMainTableFromDataSource()
		{
			emDataSet.Clear();
			AdapterHelper.FillCompany(emDataSet);
			if (emDataSet.CompanyTbl.Rows.Count == 0)
				throw new Exception("Error: No companies found. Use the company form to enter some companies into the system.");
			AdapterHelper.FillCountry(emDataSet);
			if (emDataSet.CountryTbl.Rows.Count == 0)
				throw new Exception("Error: No countries found. Use the country form to enter some companies into the system.");
			int previousSelection = companyList.SelectedIndex;
			m_enabledCompanySelectedChanged = false;
			DataInterface.UpdateListBox(emDataSet.CompanyTbl,"CompName",companyList);
			if (previousSelection >= companyList.Items.Count)
				previousSelection = 0;
			if (previousSelection < 0)
				previousSelection = 0;
			companyList.SelectedIndex = previousSelection;
			m_enabledCompanySelectedChanged = true;
			EMDataSet.CompanyTblRow compRow = GetCompanyRow();
			AdapterHelper.FillLocations(emDataSet,compRow.CompID);
		}
		public override DataSet GetDataSet()
		{
			return emDataSet;
		}
		public override OleDbConnection GetConnection()
		{
			return AdapterHelper.Connection;
		}
		bool m_enabledCompanySelectedChanged = true;
		private void OnCompanySelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_enabledCompanySelectedChanged)
				{
					Refresh();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				DataInterface.MakeSureRefreshGoesThrough(this);
			}
		}
		public override void UpdateControls()
		{
			EMDataSet.LocationTblRow row = GetHeaderRow();
			nameEdit.Text = row.LocName;
			addressEdit.Text = row.Address;
            if (row.IsATTNStringNull())
            {
                attnEdt.Text = "";
            }
            else
            {
                attnEdt.Text = row.ATTNString;
            }
            if (row.IsCCStringNull())
            {
                ccEdt.Text = "";
            }
            else
            {
                ccEdt.Text = row.CCString;
            }
			m_bLocationSelectedChangedEnabled = false;
			DataInterface.UpdateListBox(emDataSet.LocationTbl,"LocName",m_locationList);
			if (!IsEmptyTable())
				m_locationList.SelectedIndex = base.Position;
			m_bLocationSelectedChangedEnabled = true;

			DataInterface.UpdateComboBox(DataInterface.ToView(emDataSet.CountryTbl),
						"CountryID","CountryName",countryCombo,
								GetHeaderRow());
			UpdateEnabled();
		}
		bool m_bLocationSelectedChangedEnabled = true;
		void UpdateEnabled() 
		{
			bool isEmptyTable = base.IsEmptyTable();
			nameEdit.ReadOnly = isEmptyTable;
			addressEdit.ReadOnly = isEmptyTable;
			countryCombo.Enabled = !isEmptyTable;

			m_locationList.Enabled = true;
			companyList.Enabled = true;
		}

		private void OnLocationSelectedChanged(object sender, System.EventArgs e)
		{
			if (!m_bLocationSelectedChangedEnabled)
				return;
			try
			{
				base.Position = m_locationList.SelectedIndex;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				DataInterface.MakeSureRefreshGoesThrough(this);
			}
		}
		public LocationForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.companyList = new System.Windows.Forms.ListBox();
            this.emDataSet = new EM.EMDataSet();
            this.m_locationList = new System.Windows.Forms.ListBox();
            this.nameEdit = new System.Windows.Forms.TextBox();
            this.addressEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.countryCombo = new System.Windows.Forms.ComboBox();
            this.attnEdt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ccEdt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.emDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // companyList
            // 
            this.companyList.Location = new System.Drawing.Point(8, 32);
            this.companyList.Name = "companyList";
            this.companyList.Size = new System.Drawing.Size(200, 160);
            this.companyList.TabIndex = 2;
            this.companyList.SelectedIndexChanged += new System.EventHandler(this.OnCompanySelectedIndexChanged);
            // 
            // emDataSet
            // 
            this.emDataSet.DataSetName = "EMDataSet";
            this.emDataSet.Locale = new System.Globalization.CultureInfo("en-US");
            this.emDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // m_locationList
            // 
            this.m_locationList.Location = new System.Drawing.Point(424, 32);
            this.m_locationList.Name = "m_locationList";
            this.m_locationList.Size = new System.Drawing.Size(168, 160);
            this.m_locationList.TabIndex = 3;
            this.m_locationList.SelectedIndexChanged += new System.EventHandler(this.OnLocationSelectedChanged);
            // 
            // nameEdit
            // 
            this.nameEdit.Location = new System.Drawing.Point(200, 200);
            this.nameEdit.Name = "nameEdit";
            this.nameEdit.Size = new System.Drawing.Size(368, 20);
            this.nameEdit.TabIndex = 5;
            // 
            // addressEdit
            // 
            this.addressEdit.Location = new System.Drawing.Point(200, 240);
            this.addressEdit.Multiline = true;
            this.addressEdit.Name = "addressEdit";
            this.addressEdit.Size = new System.Drawing.Size(376, 88);
            this.addressEdit.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(432, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Locations:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Companies:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location Name:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Address:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Country:";
            // 
            // countryCombo
            // 
            this.countryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCombo.Location = new System.Drawing.Point(200, 336);
            this.countryCombo.Name = "countryCombo";
            this.countryCombo.Size = new System.Drawing.Size(376, 21);
            this.countryCombo.TabIndex = 9;
            // 
            // attnEdt
            // 
            this.attnEdt.Location = new System.Drawing.Point(200, 384);
            this.attnEdt.Multiline = true;
            this.attnEdt.Name = "attnEdt";
            this.attnEdt.Size = new System.Drawing.Size(376, 88);
            this.attnEdt.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Attn:";
            // 
            // ccEdt
            // 
            this.ccEdt.Location = new System.Drawing.Point(200, 480);
            this.ccEdt.Multiline = true;
            this.ccEdt.Name = "ccEdt";
            this.ccEdt.Size = new System.Drawing.Size(376, 88);
            this.ccEdt.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "CC";
            // 
            // LocationForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(600, 583);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ccEdt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.attnEdt);
            this.Controls.Add(this.countryCombo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addressEdit);
            this.Controls.Add(this.nameEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_locationList);
            this.Controls.Add(this.companyList);
            this.Name = "LocationForm";
            this.Text = "LocationForm";
            ((System.ComponentModel.ISupportInitialize)(this.emDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



		
	}
}
