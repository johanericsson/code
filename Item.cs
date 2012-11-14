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
	/// Summary description for Item.
	/// </summary>
	public class ItemForm : EMForm
						
	{
		private System.Windows.Forms.TextBox m_itemEdt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_descriptionEdt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox m_companyCombo;
        private EM.EMDataSet m_emDataSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox m_itemList;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public EMDataSet.CompanyTblRow GetCompanyRow()
		{
			return (EMDataSet.CompanyTblRow)
				m_emDataSet.CompanyTbl.Rows[m_companyCombo.SelectedIndex];
		}

		// IToolbarInterface
		public override DataRow CreateFreshRow()
		{
			EMDataSet.ItemTblRow row = m_emDataSet.ItemTbl.NewItemTblRow();
			row.CompID = GetCompanyRow().CompID;
			row.ItemName = "";
			row.ItemDesc = "";
			return row;
		}
		public override int AddNewRow(DataRow rowIn)
		{
			EMDataSet.ItemTblRow row = (EMDataSet.ItemTblRow)rowIn;
			row.ItemID = DataInterface.GetNextKeyNumber("tblItem");
			m_emDataSet.ItemTbl.AddItemTblRow(row);
			return GetRecordCount() - 1;
		}

		public override void FromControls()
		{
			GetHeaderRow().ItemName = m_itemEdt.Text;
			GetHeaderRow().ItemDesc = m_descriptionEdt.Text;
		}
        public override bool IsDeleteAllowed()
        {
            using (new OpenConnection(EM.IsWrite.Yes,AdapterHelper.Connection))
            {
                EMDataSet tempDataSet = new EMDataSet();
                using (new TurnOffConstraints(tempDataSet))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = new OleDbCommand();
                    adapter.SelectCommand.CommandText = "SELECT POITEMNumber, ItemID FROM "+
                        "tblPOItem2 where ItemID = " + GetHeaderRow().ItemID;
                    adapter.SelectCommand.Connection = AdapterHelper.Connection;
                    adapter.Fill(tempDataSet.POItemTbl);
                    if (tempDataSet.POItemTbl.Rows.Count != 0)
                    {
                        tempDataSet.Clear();
                        MessageBox.Show("Delete of item is not allowed. Item is still used by " +
                                        "Purchase Orders in the database.");
                        return false;
                    }
                    tempDataSet.Clear();
                }
            }
            return true;
        }

        void UpdatePOItems(int oldItemID, int newItemID)
        {
            OleDbCommand command = new OleDbCommand();
            command.CommandText = "UPDATE tblPOItem2 SET ItemID = " +
                    newItemID.ToString() + " WHERE ItemID = " +
                    oldItemID.ToString();
            command.Connection = AdapterHelper.Connection;
            int rowsAffected = command.ExecuteNonQuery();
            MessageBox.Show("Changed " + rowsAffected.ToString() + " rows.");
        }

		public override void CommitTablesToDataSource()
		{
            using (new OpenConnection(EM.IsWrite.Yes, AdapterHelper.Connection))
            {
                if (DataInterface.IsRowAlive(GetHeaderRow()) && 
                    GetHeaderRow().RowState != DataRowState.Added)
                {
                    if (GetHeaderRow().ItemName != (string)
                        GetHeaderRow()["ItemName", DataRowVersion.Original])
                    {
                        EMDataSet tempDataSet = new EMDataSet();
                        using (new TurnOffConstraints(tempDataSet))
                        {
                            OleDbDataAdapter adapter = new OleDbDataAdapter();
                            adapter.SelectCommand = new OleDbCommand();
                            adapter.SelectCommand.CommandText = "SELECT ItemID,ItemName,CompID FROM " +
                                "tblItem where ItemName = '" + GetHeaderRow().ItemName +
                                "' AND CompID = " + GetHeaderRow().CompID.ToString();
                            adapter.SelectCommand.Connection = AdapterHelper.Connection;
                            adapter.Fill(tempDataSet.ItemTbl);
                            if (tempDataSet.ItemTbl.Rows.Count > 1)
                                throw new Exception("BUG: There are too many rows with that item name");
                            if (tempDataSet.ItemTbl.Rows.Count == 1)
                            {
                                int newItemID = (int)tempDataSet.ItemTbl.Rows[0]["ItemID"];
                                tempDataSet.Clear();
                                DialogResult res = MessageBox.Show("There is already an item with this name. Would you like " +
                                "to merge the item with this one? This will update all purchase orders that " +
                                "have this item.", "Merge Item?", MessageBoxButtons.YesNo);
                                if (res == DialogResult.No)
                                    return;
                                // We will update all the POs to the other item. Then delete the current item.
                                UpdatePOItems(GetHeaderRow().ItemID, newItemID);
                                GetHeaderRow().Delete();
                            }
                            tempDataSet.Clear();
                        }
                    }
                }
                AdapterHelper.UpdateItemsFromCompID(m_emDataSet);
            }
		}
		public override DataSet GetDataSet()
		{
			return m_emDataSet;
		}
		public override OleDbConnection GetConnection()
		{
			return AdapterHelper.Connection;
		}

		public new EMDataSet.ItemTblRow GetHeaderRow()
		{
			return (EMDataSet.ItemTblRow)base.GetHeaderRow();
		}

		public override DataView GetHeaderTable()
		{
			return DataInterface.ToView(m_emDataSet.ItemTbl);
		}
		public override void UpdateControls() 
		{
			m_itemEdt.Text = GetHeaderRow().ItemName;
			m_descriptionEdt.Text = GetHeaderRow().ItemDesc;
			m_isItemChangedEnabled = false;
			DataInterface.UpdateListBox(m_emDataSet.ItemTbl,"ItemName",this.m_itemList);
			bool isEmptyTable = base.IsEmptyTable();
			if (!isEmptyTable)
				m_itemList.SelectedIndex = base.Position;
		
			m_itemEdt.Enabled = !isEmptyTable;
			m_descriptionEdt.Enabled = !isEmptyTable;
			m_isItemChangedEnabled = true;
		}

		private void OnItemSelectedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_isItemChangedEnabled)
					base.Position = m_itemList.SelectedIndex;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				DataInterface.MakeSureRefreshGoesThrough(this);
			}
		}




		bool m_isItemChangedEnabled = true;
		bool m_isCompanyChangedEnabled = true;
		public override void RefreshMainTableFromDataSource()
		{
			m_emDataSet.Clear();
            AdapterHelper.FillCompany(m_emDataSet);
			if (m_emDataSet.CompanyTbl.Rows.Count == 0)
				throw new Exception("Error: No companies found. Use the company form to enter some companies into the system.");
			int previousIndex = m_companyCombo.SelectedIndex;
			m_isCompanyChangedEnabled = false;
			DataInterface.UpdateComboBox(m_emDataSet.CompanyTbl.DefaultView,"CompName",this.m_companyCombo);
			if (previousIndex < 0)
				previousIndex = 0;
			if (previousIndex >= m_emDataSet.CompanyTbl.Rows.Count)
				previousIndex = m_emDataSet.CompanyTbl.Rows.Count - 1;
			m_companyCombo.SelectedIndex = previousIndex;
			m_isCompanyChangedEnabled = true;
            AdapterHelper.FillItemsFromCompID(m_emDataSet, GetCompanyRow().CompID);
		}

		private void OnCompanyChanged(object sender, System.EventArgs e)
		{
			if (m_isCompanyChangedEnabled)
				Refresh();
		}

		public ItemForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		
			Refresh();
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
            this.m_itemEdt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_descriptionEdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_companyCombo = new System.Windows.Forms.ComboBox();
            this.m_emDataSet = new EM.EMDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.m_itemList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_emDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // m_itemEdt
            // 
            this.m_itemEdt.Location = new System.Drawing.Point(392, 8);
            this.m_itemEdt.Name = "m_itemEdt";
            this.m_itemEdt.Size = new System.Drawing.Size(216, 20);
            this.m_itemEdt.TabIndex = 5;
            this.m_itemEdt.Text = "textBox1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(320, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item Name:";
            // 
            // m_descriptionEdt
            // 
            this.m_descriptionEdt.Location = new System.Drawing.Point(328, 56);
            this.m_descriptionEdt.Multiline = true;
            this.m_descriptionEdt.Name = "m_descriptionEdt";
            this.m_descriptionEdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_descriptionEdt.Size = new System.Drawing.Size(280, 96);
            this.m_descriptionEdt.TabIndex = 7;
            this.m_descriptionEdt.Text = "textBox2";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(320, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Company:";
            // 
            // m_companyCombo
            // 
            this.m_companyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_companyCombo.Location = new System.Drawing.Point(80, 8);
            this.m_companyCombo.Name = "m_companyCombo";
            this.m_companyCombo.Size = new System.Drawing.Size(216, 21);
            this.m_companyCombo.TabIndex = 1;
            this.m_companyCombo.SelectedIndexChanged += new System.EventHandler(this.OnCompanyChanged);
            // 
            // m_emDataSet
            // 
            this.m_emDataSet.DataSetName = "EMDataSet";
            this.m_emDataSet.Locale = new System.Globalization.CultureInfo("en-US");
            this.m_emDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Items:";
            // 
            // m_itemList
            // 
            this.m_itemList.Location = new System.Drawing.Point(80, 32);
            this.m_itemList.Name = "m_itemList";
            this.m_itemList.Size = new System.Drawing.Size(216, 407);
            this.m_itemList.TabIndex = 3;
            this.m_itemList.SelectedIndexChanged += new System.EventHandler(this.OnItemSelectedChanged);
            // 
            // ItemForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 453);
            this.Controls.Add(this.m_itemList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_companyCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_descriptionEdt);
            this.Controls.Add(this.m_itemEdt);
            this.Controls.Add(this.label1);
            this.Name = "ItemForm";
            this.Text = "Item";
            ((System.ComponentModel.ISupportInitialize)(this.m_emDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		
	}
}
