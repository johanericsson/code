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
	/// Summary description for ChooseItem.
	/// </summary>
	public class ChooseItem : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox m_itemList;
		private EM.EMDataSet emDataSet;
		private System.Windows.Forms.Button OKbtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox countBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.ComboBox finishCombo;
		public System.Windows.Forms.ComboBox treatmentCombo;
		private System.Windows.Forms.Panel bottomPanel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public static EMDataSet.ItemTblRow CreateNewRow(int compID,
			out int count,out string finish,out string treatment)
		{
			count = 1;
			finish = null;
			treatment = null;
			ChooseItem chooseDlg = new ChooseItem(compID);
			chooseDlg.m_itemList.Items.Add("Add new...");
			foreach (EMDataSet.ItemTblRow row in chooseDlg.emDataSet.ItemTbl.Rows)
			{
				chooseDlg.m_itemList.Items.Add(row.ItemName);
			}
			chooseDlg.m_itemList.SelectedIndex = 0;
			DialogResult res = chooseDlg.ShowDialog();
			if (res == DialogResult.OK)
			{
				string countAsStr = chooseDlg.countBox.Text;
				count = int.Parse(countAsStr);
				finish = chooseDlg.finishCombo.Text;
				treatment = chooseDlg.treatmentCombo.Text;
				if (chooseDlg.m_itemList.SelectedIndex == 0)
				{
					string compName = chooseDlg.emDataSet.CompanyTbl.
						FindByCompID(compID).CompName;
					AddNewItem newItem = new AddNewItem(compName);
					res = newItem.ShowDialog();
					if (res == DialogResult.Cancel)
						return null;
					return chooseDlg.AddNewItem(newItem.itmNameEdt.Text,newItem.itemDescEdt.Text);
				}
				return chooseDlg.emDataSet.ItemTbl[chooseDlg.m_itemList.SelectedIndex-1];
			}
			return null;
		}
		private void OnChooseItemDblClick(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		public EMDataSet.ItemTblRow AddNewItem(string itemName,string itemDesc)
		{
			if (emDataSet.CompanyTbl.Rows.Count == 0)
			{
				MessageBox.Show("The company selected in the PO doesn't exist");
				return null;
			}

			EMDataSet.ItemTblRow row = emDataSet.ItemTbl.NewItemTblRow();
			row.CompID = ((EMDataSet.CompanyTblRow)emDataSet.CompanyTbl.Rows[0]).CompID;
			row.ItemName = itemName;
			row.ItemDesc = itemDesc;
			row.ItemID = DataInterface.GetNextKeyNumber("tblItem");
			emDataSet.ItemTbl.AddItemTblRow(row);
			using (new OpenConnection(IsWrite.Yes,AdapterHelper.Connection))
			{
				AdapterHelper.UpdateItemsFromCompID(emDataSet);
			}
			return row;
			
		}
		
		public ChooseItem(int compID)
		{
			InitializeComponent();
			using (new OpenConnection(IsWrite.No,AdapterHelper.Connection))
			{
				AdapterHelper.FillCompanyFromCompID(emDataSet,compID);
				if (emDataSet.CompanyTbl.Rows.Count != 0)
				{
					EMDataSet.CompanyTblRow companyRow = (EMDataSet.CompanyTblRow)
						emDataSet.CompanyTbl.Rows[0];
					AdapterHelper.FillItemsFromCompID(emDataSet,compID);
				}
			}
			string[] finishes= HelperFunctions.GetFinishItems("Finish");
            finishCombo.Items.Add("");
            foreach (string finish in finishes)
			{
				finishCombo.Items.Add(finish);
			}
			string[] treatments = HelperFunctions.GetFinishItems("Treatment");
            treatmentCombo.Items.Add("");
            foreach (string treatment in treatments)
			{
				treatmentCombo.Items.Add(treatment);
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
			this.m_itemList = new System.Windows.Forms.ListBox();
			this.emDataSet = new EM.EMDataSet();
			this.OKbtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.countBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.finishCombo = new System.Windows.Forms.ComboBox();
			this.treatmentCombo = new System.Windows.Forms.ComboBox();
			this.bottomPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.emDataSet)).BeginInit();
			this.bottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_itemList
			// 
			this.m_itemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_itemList.Location = new System.Drawing.Point(0, 24);
			this.m_itemList.Name = "m_itemList";
			this.m_itemList.Size = new System.Drawing.Size(448, 485);
			this.m_itemList.TabIndex = 0;
			this.m_itemList.DoubleClick += new System.EventHandler(this.OnChooseItemDblClick);
			// 
			// emDataSet
			// 
			this.emDataSet.DataSetName = "EMDataSet";
			this.emDataSet.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// OKbtn
			// 
			this.OKbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKbtn.Location = new System.Drawing.Point(328, 48);
			this.OKbtn.Name = "OKbtn";
			this.OKbtn.Size = new System.Drawing.Size(56, 24);
			this.OKbtn.TabIndex = 4;
			this.OKbtn.Text = "OK";
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(248, 48);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(72, 23);
			this.cancelBtn.TabIndex = 3;
			this.cancelBtn.Text = "Cancel";
			// 
			// countBox
			// 
			this.countBox.Location = new System.Drawing.Point(56, 16);
			this.countBox.Name = "countBox";
			this.countBox.Size = new System.Drawing.Size(32, 20);
			this.countBox.TabIndex = 2;
			this.countBox.Text = "1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Count";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(96, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Finish:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(224, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Treatment:";
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(448, 24);
			this.label4.TabIndex = 7;
			this.label4.Text = "Grades:";
			// 
			// finishCombo
			// 
			this.finishCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.finishCombo.Location = new System.Drawing.Point(136, 16);
			this.finishCombo.Name = "finishCombo";
			this.finishCombo.Size = new System.Drawing.Size(80, 21);
			this.finishCombo.TabIndex = 8;
			// 
			// treatmentCombo
			// 
			this.treatmentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.treatmentCombo.Location = new System.Drawing.Point(296, 16);
			this.treatmentCombo.Name = "treatmentCombo";
			this.treatmentCombo.Size = new System.Drawing.Size(88, 21);
			this.treatmentCombo.TabIndex = 9;
			// 
			// bottomPanel
			// 
			this.bottomPanel.Controls.Add(this.OKbtn);
			this.bottomPanel.Controls.Add(this.cancelBtn);
			this.bottomPanel.Controls.Add(this.countBox);
			this.bottomPanel.Controls.Add(this.label1);
			this.bottomPanel.Controls.Add(this.label2);
			this.bottomPanel.Controls.Add(this.label3);
			this.bottomPanel.Controls.Add(this.finishCombo);
			this.bottomPanel.Controls.Add(this.treatmentCombo);
			this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bottomPanel.Location = new System.Drawing.Point(0, 429);
			this.bottomPanel.Name = "bottomPanel";
			this.bottomPanel.Size = new System.Drawing.Size(448, 88);
			this.bottomPanel.TabIndex = 10;
			// 
			// ChooseItem
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 517);
			this.Controls.Add(this.bottomPanel);
			this.Controls.Add(this.m_itemList);
			this.Controls.Add(this.label4);
			this.Name = "ChooseItem";
			this.Text = "ChooseItem";
			((System.ComponentModel.ISupportInitialize)(this.emDataSet)).EndInit();
			this.bottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
