/*using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;

namespace EM
{
	/// <summary>
	/// Summary description for ItemEdit.
	/// </summary>
	public class ItemEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.TextBox descriptionEdt;
		private System.Windows.Forms.TextBox commentsEdt;
		private System.Windows.Forms.TextBox lengthEdt;
		private System.Windows.Forms.TextBox sizeEdt;
		private System.Windows.Forms.TextBox iacEdt;
		private System.Windows.Forms.TextBox dateReqEdt;
		private System.Windows.Forms.TextBox heatEdt;
		private System.Windows.Forms.TextBox ackDateEdt;
		private System.Windows.Forms.Button ackDateBtn;
		private System.Windows.Forms.TextBox millConfirmNoEdt;
		private System.Windows.Forms.TextBox millShipDateEdt;
		private System.Windows.Forms.Button millShipDateBtn;
		private System.Windows.Forms.TextBox weightLbsEdt;
		private System.Windows.Forms.TextBox weightKgEdt;
		private System.Windows.Forms.TextBox rateLbsEdt;
		private System.Windows.Forms.TextBox rateKgEdt;
		private System.Windows.Forms.TextBox costEdt;
		private System.Windows.Forms.Button dateReqBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;



		TextBox[] m_textBoxes;
		string[] m_fieldNames;

		TextBox[] m_decimalEdits;
		string[] m_decimalFields;

		TextBox[] m_dateEdits;
		Button[] m_dateButtons;
		string[] m_dateFields;
		private System.Windows.Forms.RadioButton kgBtn;
		private System.Windows.Forms.RadioButton lbsBtn;
		private System.Windows.Forms.Button calcBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Data.OleDb.OleDbDataAdapter companyAdapter;
		private System.Data.OleDb.OleDbDataAdapter itemAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Windows.Forms.ComboBox nameCombo;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		
		EMDataSet.POItemTblRow m_row;

		EMDataSet.POItemTblRow GetRow()
		{
			return m_row;
		}

		EMDataSet itemDataSet = new EMDataSet();
		public ItemEdit(EMDataSet.POItemTblRow rowIn,string customerCompany)
		{
			
			m_row = rowIn;
			rowIn.BeginEdit();
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			DataInterface.InitializeAdapterWithStringParameter(companyAdapter,"CompName");
			DataInterface.InitializeAdapterWithParameter(itemAdapter,"CompID");
			if (customerCompany != null)
			{
				DataInterface.FillAdapterWithStringParameter(companyAdapter,
						customerCompany);
				companyAdapter.Fill(itemDataSet.CompanyTbl);
				if (itemDataSet.CompanyTbl.Rows.Count > 0)
				{
					DataInterface.FillAdapterWithParameter(itemAdapter,itemDataSet.CompanyTbl[0].CompID);
					itemAdapter.Fill(itemDataSet.ItemTbl);
				}
			}



			m_textBoxes = new TextBox[]{descriptionEdt,commentsEdt,lengthEdt,
										   sizeEdt,iacEdt,heatEdt,
										   millConfirmNoEdt};
			m_fieldNames = new string[]{"ItemDesc","Comments","Length",
										   "SizeOfItem","ItemAccessCode","Heat"
										   ,"MillConfirmNumber"};

			m_decimalEdits = new TextBox[]{weightLbsEdt,rateLbsEdt,
											  weightKgEdt,rateKgEdt,
											  costEdt};
			m_decimalFields = new string[]{"Qty","CustRate",
												  "MetricQty","MetricCustRate",
												  "CustAmount"};


			m_dateEdits = new TextBox[]{dateReqEdt,ackDateEdt,millShipDateEdt};
			m_dateButtons = new Button[]{dateReqBtn,ackDateBtn,millShipDateBtn};
			m_dateFields = new string[]{"DateRequired","AcknowledgeDate","MillShipDate"};
			UpdateControls();
		}

		private void DateBtnClick(object sender, System.EventArgs e)
		{
			Button button = (Button)sender;
			int i;
			for (i=0;i<m_dateFields.Length;i++)
			{
				if (m_dateButtons[i] == button)
					break;
			}
			Debug.Assert(i!= m_dateFields.Length);
			string fieldName = m_dateFields[i];
			TextBox box = m_dateEdits[i];
			DataRow row = GetRow();
			System.DateTime dateTime = System.DateTime.Today;
			if (!row.IsNull(fieldName))
				dateTime = (DateTime)row[fieldName];
			if (DialogResult.OK == DateTimeSelector.RequestTime(ref dateTime))
				box.Text = HelperFunctions.ToDateText(dateTime);
		}

		private void okBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				FromControls();
				GetRow().EndEdit();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void cancelBtn_Click(object sender, System.EventArgs e)
		{
			EMDataSet.POItemTblRow row = GetRow();
			row.CancelEdit();
		}
		public void SetUM()
		{
			EMDataSet.POItemTblRow row = GetRow();
			bool isKg = kgBtn.Checked;
			if (isKg)
				row.UM = "kg";
			else
				row.UM = "lbs";
		}

		bool m_enableWeightSelectedChanged = true;
		void UpdateMassControls()
		{
			m_enableWeightSelectedChanged = false;
			EMDataSet.POItemTblRow row = GetRow();
			bool isKg = DataInterface.IsMetric(row);
			kgBtn.Checked = isKg;
			lbsBtn.Checked = !isKg;
			weightLbsEdt.Enabled = !isKg;
			rateLbsEdt.Enabled = !isKg;
			weightKgEdt.Enabled = isKg;
			rateKgEdt.Enabled = isKg;
			m_enableWeightSelectedChanged = true;
		}
		bool m_enabledNameComboChanged = true;
		private void OnNameIndexChanged(object sender, System.EventArgs e)
		{
			if (!m_enabledNameComboChanged)
				return;
			int itemID = ((TaggedItem)nameCombo.SelectedItem).key;
			EMDataSet.ItemTblRow row = itemDataSet.ItemTbl.FindByItemID(itemID);
			if (row.IsItemDescNull())
				return;
			descriptionEdt.Text = row.ItemDesc;
		}
		void UpdateControls()
		{
			m_enabledNameComboChanged = false;
			DataInterface.UpdateComboBox(itemDataSet.ItemTbl.DefaultView,"ItemID","ItemName",nameCombo,null);
			m_enabledNameComboChanged = true;
			if (m_row.IsItemNameNull())
				nameCombo.Text = "";
			else
				nameCombo.Text = m_row.ItemName;
			for (int i=0;i<m_fieldNames.Length;i++)
			{
				if (!m_row.IsNull(m_fieldNames[i]))
					m_textBoxes[i].Text = (string)m_row[m_fieldNames[i]];
				else
					m_textBoxes[i].Text = "";
			}
			for (int i=0;i<m_dateFields.Length;i++)
			{
				if (!m_row.IsNull(m_dateFields[i]))
					m_dateEdits[i].Text = m_row[m_dateFields[i]].ToString();
				else
					m_dateEdits[i].Text = "";
			}
			for (int i=0;i<m_decimalEdits.Length;i++)
			{
				if (!m_row.IsNull(m_decimalFields[i]))
					m_decimalEdits[i].Text = m_row[m_decimalFields[i]].ToString();
				else
					m_decimalEdits[i].Text = "";
			}
			UpdateMassControls();
		}
		void FromControls()
		{
			SetUM();
			EMDataSet.POItemTblRow row = GetRow();
			for (int i=0;i<m_fieldNames.Length;i++)
			{
				row[m_fieldNames[i]] = m_textBoxes[i].Text;
			}	
			for (int i=0;i<m_dateFields.Length;i++)
			{
				if (m_dateEdits[i].Text == "")
					row[m_dateFields[i]] = DBNull.Value;					
				else
					row[m_dateFields[i]] = m_dateEdits[i].Text;
			}
			for (int i=0;i<m_decimalFields.Length;i++)
			{
				if (m_decimalEdits[i].Text == "")
					row[m_decimalFields[i]] = DBNull.Value;
				else
					row[m_decimalFields[i]] = m_decimalEdits[i].Text;
			}
			row.ItemName = nameCombo.Text;
			Calculate();
		}
		void Calculate()
		{
			EMDataSet.POItemTblRow row = GetRow();
			if (!row.IsQtyNull() && !row.IsCustRateNull())
				row.CustAmount = row.Qty * row.CustRate;
			else
					row.SetCustAmountNull();
		}
		private void calcBtn_Click(object sender, System.EventArgs e)
		{
			try
			{
				FromControls();
				UpdateControls();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void OnWeightSelectedChanged(object sender, System.EventArgs e)
		{
			if (m_enableWeightSelectedChanged == false)
				return;

			SetUM();
			UpdateMassControls();
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
			this.label2 = new System.Windows.Forms.Label();
			this.descriptionEdt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.commentsEdt = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.millShipDateBtn = new System.Windows.Forms.Button();
			this.millShipDateEdt = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.millConfirmNoEdt = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.ackDateBtn = new System.Windows.Forms.Button();
			this.ackDateEdt = new System.Windows.Forms.TextBox();
			this.weightLbsEdt = new System.Windows.Forms.TextBox();
			this.weightKgEdt = new System.Windows.Forms.TextBox();
			this.rateLbsEdt = new System.Windows.Forms.TextBox();
			this.rateKgEdt = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.calcBtn = new System.Windows.Forms.Button();
			this.costEdt = new System.Windows.Forms.TextBox();
			this.kgBtn = new System.Windows.Forms.RadioButton();
			this.lbsBtn = new System.Windows.Forms.RadioButton();
			this.lengthEdt = new System.Windows.Forms.TextBox();
			this.sizeEdt = new System.Windows.Forms.TextBox();
			this.iacEdt = new System.Windows.Forms.TextBox();
			this.dateReqEdt = new System.Windows.Forms.TextBox();
			this.heatEdt = new System.Windows.Forms.TextBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.dateReqBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.emConnection = new System.Data.OleDb.OleDbConnection();
			this.companyAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.itemAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.nameCombo = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description:";
			// 
			// descriptionEdt
			// 
			this.descriptionEdt.AcceptsReturn = true;
			this.descriptionEdt.Location = new System.Drawing.Point(96, 72);
			this.descriptionEdt.Multiline = true;
			this.descriptionEdt.Name = "descriptionEdt";
			this.descriptionEdt.Size = new System.Drawing.Size(320, 112);
			this.descriptionEdt.TabIndex = 3;
			this.descriptionEdt.Text = "textBox1";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 192);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Length:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 216);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Size:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 240);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "IAC:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 264);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "Date Req:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 288);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 23);
			this.label7.TabIndex = 15;
			this.label7.Text = "Heat:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(296, 48);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 23);
			this.label10.TabIndex = 6;
			this.label10.Text = "Rate($/kg):";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(296, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 23);
			this.label11.TabIndex = 2;
			this.label11.Text = "Rate($/lbs):";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(144, 80);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 23);
			this.label12.TabIndex = 8;
			this.label12.Text = "Item Cost:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(424, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 23);
			this.label13.TabIndex = 4;
			this.label13.Text = "Comments:";
			// 
			// commentsEdt
			// 
			this.commentsEdt.AcceptsReturn = true;
			this.commentsEdt.Location = new System.Drawing.Point(496, 72);
			this.commentsEdt.Multiline = true;
			this.commentsEdt.Name = "commentsEdt";
			this.commentsEdt.Size = new System.Drawing.Size(320, 112);
			this.commentsEdt.TabIndex = 5;
			this.commentsEdt.Text = "textBox2";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 23);
			this.label14.TabIndex = 0;
			this.label14.Text = "Date:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.millShipDateBtn);
			this.groupBox1.Controls.Add(this.millShipDateEdt);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.millConfirmNoEdt);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.ackDateBtn);
			this.groupBox1.Controls.Add(this.ackDateEdt);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Location = new System.Drawing.Point(16, 432);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(384, 100);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Acknowledge";
			// 
			// millShipDateBtn
			// 
			this.millShipDateBtn.Location = new System.Drawing.Point(224, 64);
			this.millShipDateBtn.Name = "millShipDateBtn";
			this.millShipDateBtn.Size = new System.Drawing.Size(32, 23);
			this.millShipDateBtn.TabIndex = 7;
			this.millShipDateBtn.Text = "...";
			this.millShipDateBtn.Click += new System.EventHandler(this.DateBtnClick);
			// 
			// millShipDateEdt
			// 
			this.millShipDateEdt.Location = new System.Drawing.Point(112, 64);
			this.millShipDateEdt.Name = "millShipDateEdt";
			this.millShipDateEdt.TabIndex = 6;
			this.millShipDateEdt.Text = "textBox5";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 64);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 23);
			this.label16.TabIndex = 5;
			this.label16.Text = "Mill Ship Date:";
			// 
			// millConfirmNoEdt
			// 
			this.millConfirmNoEdt.Location = new System.Drawing.Point(112, 40);
			this.millConfirmNoEdt.Name = "millConfirmNoEdt";
			this.millConfirmNoEdt.TabIndex = 4;
			this.millConfirmNoEdt.Text = "textBox4";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 40);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(88, 23);
			this.label15.TabIndex = 3;
			this.label15.Text = "Mill Confirm No:";
			// 
			// ackDateBtn
			// 
			this.ackDateBtn.Location = new System.Drawing.Point(224, 16);
			this.ackDateBtn.Name = "ackDateBtn";
			this.ackDateBtn.Size = new System.Drawing.Size(32, 23);
			this.ackDateBtn.TabIndex = 2;
			this.ackDateBtn.Text = "...";
			this.ackDateBtn.Click += new System.EventHandler(this.DateBtnClick);
			// 
			// ackDateEdt
			// 
			this.ackDateEdt.Location = new System.Drawing.Point(112, 16);
			this.ackDateEdt.Name = "ackDateEdt";
			this.ackDateEdt.TabIndex = 1;
			this.ackDateEdt.Text = "textBox3";
			// 
			// weightLbsEdt
			// 
			this.weightLbsEdt.Location = new System.Drawing.Point(128, 24);
			this.weightLbsEdt.Name = "weightLbsEdt";
			this.weightLbsEdt.TabIndex = 1;
			this.weightLbsEdt.Text = "textBox6";
			// 
			// weightKgEdt
			// 
			this.weightKgEdt.Location = new System.Drawing.Point(128, 48);
			this.weightKgEdt.Name = "weightKgEdt";
			this.weightKgEdt.TabIndex = 5;
			this.weightKgEdt.Text = "c";
			// 
			// rateLbsEdt
			// 
			this.rateLbsEdt.Location = new System.Drawing.Point(376, 24);
			this.rateLbsEdt.Name = "rateLbsEdt";
			this.rateLbsEdt.TabIndex = 3;
			this.rateLbsEdt.Text = "textBox8";
			// 
			// rateKgEdt
			// 
			this.rateKgEdt.Location = new System.Drawing.Point(376, 48);
			this.rateKgEdt.Name = "rateKgEdt";
			this.rateKgEdt.TabIndex = 7;
			this.rateKgEdt.Text = "c";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.calcBtn);
			this.groupBox2.Controls.Add(this.costEdt);
			this.groupBox2.Controls.Add(this.kgBtn);
			this.groupBox2.Controls.Add(this.lbsBtn);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.weightLbsEdt);
			this.groupBox2.Controls.Add(this.rateKgEdt);
			this.groupBox2.Controls.Add(this.weightKgEdt);
			this.groupBox2.Controls.Add(this.rateLbsEdt);
			this.groupBox2.Location = new System.Drawing.Point(16, 312);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(528, 112);
			this.groupBox2.TabIndex = 17;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Rates";
			// 
			// calcBtn
			// 
			this.calcBtn.Location = new System.Drawing.Point(32, 80);
			this.calcBtn.Name = "calcBtn";
			this.calcBtn.TabIndex = 10;
			this.calcBtn.Text = "Calculate";
			this.calcBtn.Click += new System.EventHandler(this.calcBtn_Click);
			// 
			// costEdt
			// 
			this.costEdt.Location = new System.Drawing.Point(224, 80);
			this.costEdt.Name = "costEdt";
			this.costEdt.ReadOnly = true;
			this.costEdt.TabIndex = 9;
			this.costEdt.Text = "textBox15";
			// 
			// kgBtn
			// 
			this.kgBtn.Location = new System.Drawing.Point(16, 48);
			this.kgBtn.Name = "kgBtn";
			this.kgBtn.TabIndex = 4;
			this.kgBtn.Text = "Weight(kg):";
			this.kgBtn.CheckedChanged += new System.EventHandler(this.OnWeightSelectedChanged);
			// 
			// lbsBtn
			// 
			this.lbsBtn.Location = new System.Drawing.Point(16, 24);
			this.lbsBtn.Name = "lbsBtn";
			this.lbsBtn.TabIndex = 0;
			this.lbsBtn.Text = "Weight(lbs):";
			this.lbsBtn.CheckedChanged += new System.EventHandler(this.OnWeightSelectedChanged);
			// 
			// lengthEdt
			// 
			this.lengthEdt.Location = new System.Drawing.Point(96, 192);
			this.lengthEdt.Name = "lengthEdt";
			this.lengthEdt.Size = new System.Drawing.Size(184, 20);
			this.lengthEdt.TabIndex = 7;
			this.lengthEdt.Text = "textBox10";
			// 
			// sizeEdt
			// 
			this.sizeEdt.Location = new System.Drawing.Point(96, 216);
			this.sizeEdt.Name = "sizeEdt";
			this.sizeEdt.Size = new System.Drawing.Size(184, 20);
			this.sizeEdt.TabIndex = 9;
			this.sizeEdt.Text = "textBox11";
			// 
			// iacEdt
			// 
			this.iacEdt.Location = new System.Drawing.Point(96, 240);
			this.iacEdt.Name = "iacEdt";
			this.iacEdt.Size = new System.Drawing.Size(184, 20);
			this.iacEdt.TabIndex = 11;
			this.iacEdt.Text = "textBox12";
			// 
			// dateReqEdt
			// 
			this.dateReqEdt.Location = new System.Drawing.Point(96, 264);
			this.dateReqEdt.Name = "dateReqEdt";
			this.dateReqEdt.Size = new System.Drawing.Size(184, 20);
			this.dateReqEdt.TabIndex = 13;
			this.dateReqEdt.Text = "textBox13";
			// 
			// heatEdt
			// 
			this.heatEdt.Location = new System.Drawing.Point(96, 288);
			this.heatEdt.Name = "heatEdt";
			this.heatEdt.Size = new System.Drawing.Size(184, 20);
			this.heatEdt.TabIndex = 16;
			this.heatEdt.Text = "textBox14";
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(736, 528);
			this.okBtn.Name = "okBtn";
			this.okBtn.TabIndex = 19;
			this.okBtn.Text = "OK";
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// dateReqBtn
			// 
			this.dateReqBtn.Location = new System.Drawing.Point(288, 264);
			this.dateReqBtn.Name = "dateReqBtn";
			this.dateReqBtn.Size = new System.Drawing.Size(24, 23);
			this.dateReqBtn.TabIndex = 14;
			this.dateReqBtn.Text = "...";
			this.dateReqBtn.Click += new System.EventHandler(this.DateBtnClick);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(648, 528);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.TabIndex = 20;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// emConnection
			// 
			this.emConnection.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""m:\em_prog_2002.mdb"";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=ReadWrite;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False";
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
			this.oleDbSelectCommand1.CommandText = "SELECT CompID, CompName, CompType FROM tblCompany WHERE (CompName = ?)";
			this.oleDbSelectCommand1.Connection = this.emConnection;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 50, "CompName"));
			// 
			// itemAdapter
			// 
			this.itemAdapter.SelectCommand = this.oleDbSelectCommand2;
			this.itemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "tblItem", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
																																																			 new System.Data.Common.DataColumnMapping("CompID", "CompID"),
																																																			 new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
																																																			 new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
																																																			 new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
																																																			 new System.Data.Common.DataColumnMapping("ItemName", "ItemName")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT CommRate, CompID, CustRate, ItemDesc, ItemID, ItemName FROM tblItem WHERE " +
				"(CompID = ?) ORDER BY ItemName";
			this.oleDbSelectCommand2.Connection = this.emConnection;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"));
			// 
			// nameCombo
			// 
			this.nameCombo.Location = new System.Drawing.Point(96, 40);
			this.nameCombo.Name = "nameCombo";
			this.nameCombo.Size = new System.Drawing.Size(320, 21);
			this.nameCombo.TabIndex = 1;
			this.nameCombo.Text = "comboBox1";
			this.nameCombo.SelectedIndexChanged += new System.EventHandler(this.OnNameIndexChanged);
			// 
			// ItemEdit
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(824, 565);
			this.Controls.Add(this.nameCombo);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.dateReqBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.heatEdt);
			this.Controls.Add(this.dateReqEdt);
			this.Controls.Add(this.iacEdt);
			this.Controls.Add(this.sizeEdt);
			this.Controls.Add(this.lengthEdt);
			this.Controls.Add(this.commentsEdt);
			this.Controls.Add(this.descriptionEdt);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ItemEdit";
			this.Text = "Item";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
*/