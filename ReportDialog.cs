using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Diagnostics;

namespace EM
{
	/// <summary>
	/// Summary description for ReportDialog.
	/// </summary>
	public class ReportDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox millCombo;
		private System.Windows.Forms.ComboBox customerCombo;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okbtn;
		private EM.DateSelectorControl poDateSelector;
		private EM.DateSelectorControl ackDateSelector;
		private EM.DateSelectorControl revisedDateSelector;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox statusCombo;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox customerLocationCombo;
        private Label label3;
        private ComboBox invoiceStatusCombo;
        private DateSelectorControl selectShipDate;
        private Label SizeLbl;
        private ComboBox sizeCombo;
        private ComboBox gradeCombo;
        private ComboBox finishCombo;
        private Label label8;
        private Label label9;
        private ComboBox treatmentCombo;
        private Label label4;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label10;
        private TextBox invoiceNumber;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		void SetupCompanyCombo(ComboBox box,string constraint)
		{
			box.Items.Clear();
			box.Items.Add(new TaggedItem(-1,"All"));
			EMDataSet.CompanyTblDataTable companyTbl = new EMDataSet.CompanyTblDataTable();
			using (new OpenConnection(EM.IsWrite.No,AdapterHelper.Connection))
			{
				AdapterHelper.FillCompanyFromType(companyTbl,constraint);
				foreach (EMDataSet.CompanyTblRow row in companyTbl)
				{
					TaggedItem item = new TaggedItem(row.CompID,row.CompName);
					box.Items.Add(item);
				}
			}
			box.SelectedIndex = 0;
		}
		void SetupLocationCombo(ComboBox box,int compID)
		{
			box.Items.Clear();
			box.Items.Add(new TaggedItem(-1,"All Locations"));
			box.SelectedIndex = 0;
			if (compID == -1)
				return;
			EMDataSet emDataSet = new EMDataSet();
			using (new TurnOffConstraints(emDataSet))
			{
				using (new OpenConnection(EM.IsWrite.No,AdapterHelper.Connection))
				{
					AdapterHelper.FillLocations(emDataSet,compID);
				}
				foreach (EMDataSet.LocationTblRow row in emDataSet.LocationTbl)
				{
					TaggedItem item = new TaggedItem(row.LocID,row.LocName);
					box.Items.Add(item);
				}
				emDataSet.Clear();
			}
		}

		private void OnMillChanged(object sender, System.EventArgs e)
		{
			object oItem = millCombo.SelectedItem;
			TaggedItem tagged = (TaggedItem)oItem;
		}

		private void OnCustomerChanged(object sender, System.EventArgs e)
		{
			object oItem = customerCombo.SelectedItem;
			TaggedItem tagged = (TaggedItem)oItem;
			SetupLocationCombo(customerLocationCombo,tagged.key);
            EMDataSet emDataSet = new EMDataSet();
            gradeCombo.Items.Clear();
            gradeCombo.Items.Add("All");
            if (tagged.key != -1)
            {
                gradeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
                using (new TurnOffConstraints(emDataSet))
                using (new OpenConnection(EM.IsWrite.No, AdapterHelper.Connection))
                {
                    // not all companies
                    AdapterHelper.
                        FillItemsFromCompID(emDataSet, tagged.key);
                    foreach (EMDataSet.ItemTblRow row in
                        emDataSet.ItemTbl.Rows)
                    {
                        int key = row.ItemID;
                        string name = row.ItemName;
                        gradeCombo.Items.Add(new TaggedItem(key, name));
                    }
                }
                gradeCombo.SelectedIndex = 0;
            }
            else
            {
                gradeCombo.DropDownStyle = ComboBoxStyle.DropDown;
                gradeCombo.Text = "All";
            }
		}

        void SetupCombo(ComboBox box,string table)
        {
            box.Items.Add("All");
            string[] items = HelperFunctions.GetFinishItems(table);
            foreach (string s in items)
            {
                int key = (int)HelperFunctions.GetFinishKey(table,s);
                box.Items.Add(new TaggedItem(key, s));
            }
            box.SelectedIndex = 0;
        }

        public ReportDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			SetupCompanyCombo(millCombo,"Vendor");
			SetupCompanyCombo(customerCombo,"Customer");
			string[] statusComboTitles = {"Not cancelled","Open only","Closed only","Cancelled only"};
			string[] statusComboMeaning = {"NOT STATUS = \"Cancelled\"",
											  "STATUS = \"Open\"",
											  "STATUS = \"Closed\"",
											  "STATUS = \"Cancelled\""};
            string[] invoiceComboTitles = { "All", "Invoiced", "Not Invoiced" };
            string[] invoiceComboMeaning = { "", "(InvoiceNumber IS NOT NULL AND InvoiceNumber <> \"\")", 
                                                  "(InvoiceNumber IS NULL OR InvoiceNumber = \"\")" };
			for (int i=0;i<statusComboTitles.Length;i++)
			{
				TaggedItemStr tag = new TaggedItemStr(statusComboMeaning[i],
													statusComboTitles[i]);
				statusCombo.Items.Add(tag);
			}
            for (int i = 0; i < invoiceComboTitles.Length; i++)
            {
                TaggedItemStr tag = new TaggedItemStr(invoiceComboMeaning[i],
                                        invoiceComboTitles[i]);
                invoiceStatusCombo.Items.Add(tag);
            }
            invoiceStatusCombo.SelectedIndex = 0;
			statusCombo.SelectedIndex =0;
            SetupCombo(finishCombo,"Finish");
            SetupCombo(treatmentCombo, "Treatment");
            gradeCombo.Items.Add("All");
            gradeCombo.SelectedIndex = 0;
        }
        public string GetFriendlyConstraints()
		{
			string constraints = "";
			poDateSelector.GetFriendlyConstraints("PO Date",ref constraints);
			ackDateSelector.GetFriendlyConstraints("Mill Acknowledge Date",ref constraints);
			revisedDateSelector.GetFriendlyConstraints("Revised Mill Acknowledge Date",ref constraints);
            selectShipDate.GetFriendlyConstraints("Ship Date",ref constraints);
			if (millCombo.SelectedIndex != 0)
			{
				TaggedItem millItem = (TaggedItem)millCombo.SelectedItem;
				constraints += "Mill: " + millItem.title + "\n";
			}
			if (customerCombo.SelectedIndex != 0)
			{
				TaggedItem customerItem =(TaggedItem)customerCombo.SelectedItem;
				constraints += "Customer: " + customerItem.title + "\n";
			}
			if (customerLocationCombo.SelectedIndex != 0)
			{
				TaggedItem customerLocationItem = (TaggedItem)customerLocationCombo.SelectedItem;
				constraints += "Location: " + customerLocationItem.title + "\n";
			}
			if (statusCombo.SelectedIndex != 0)
			{
				TaggedItemStr statusTag = (TaggedItemStr)statusCombo.SelectedItem;
				constraints += "Status = " + statusTag.title + "\n";
			}
            if (invoiceStatusCombo.SelectedIndex != 0)
            {
                TaggedItemStr invoiceStatusTag = (TaggedItemStr)invoiceStatusCombo.SelectedItem;
                constraints += "Invoice Status = " + invoiceStatusTag.title + "\n";
            }
            if (sizeCombo.Text != "All")
            {
                constraints += "Only items of size:" + sizeCombo.Text + "\n";
            }
            if (finishCombo.SelectedIndex != 0)
            {
                constraints += "Only items with finish: " + finishCombo.Text;
            }
            if (gradeCombo.SelectedIndex != 0)
            {
                constraints += "Only grades:" + gradeCombo.Text + "\n";
            }
            if (treatmentCombo.SelectedIndex != 0)
            {
                constraints += "Only items with treatment: " + treatmentCombo.Text;
            }
            if (invoiceNumber.Text != "All" &&
                invoiceNumber.Text != "")
            {
                constraints += "Only POs with invoiced with: " + invoiceNumber.Text;
            }
			return constraints;
		}
        int GetKeyFromCombo(ComboBox box)
        {
            TaggedItem tag = (TaggedItem)box.SelectedItem;
            return tag.key;
        }
        public ArrayList GetPOItemConstraints(out ArrayList orConstraints)
        {
            ArrayList constraints = new ArrayList();
            orConstraints = new ArrayList();
            selectShipDate.GetConstraints("MillShipDate",constraints);
            if (sizeCombo.Text != "All")
            {
                string constraint = "SizeOfItem='" + DataInterface.ExpandQuotes(sizeCombo.Text) 
                    + "'";
                constraints.Add(constraint);
            }
            if (finishCombo.SelectedIndex != 0)
            {
                string constraint = "FinishID=" + GetKeyFromCombo(finishCombo);
                constraints.Add(constraint);
            }
            if (treatmentCombo.SelectedIndex != 0)
            {
                string constraint = "TreatmentID=" + GetKeyFromCombo(treatmentCombo);
                constraints.Add(constraint);
            }
            if (gradeCombo.DropDownStyle == ComboBoxStyle.DropDown  &&
                gradeCombo.Text != "All")
            {
                // more complicated... just match the string
                EMDataSet emDataSet = new EMDataSet();
                using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
                    AdapterHelper.FillFromItemName(emDataSet, gradeCombo.Text);
                foreach (EMDataSet.ItemTblRow itemRow in emDataSet.ItemTbl)
                {
                    string constraint = "ItemID=" + itemRow.ItemID;
                    orConstraints.Add(constraint);
                }
                if (emDataSet.ItemTbl.Rows.Count == 0) // can't find any
                    constraints.Add("ItemID=-1");// show empty report
            }
            else
                if (gradeCombo.SelectedIndex != 0)
            {
                string constraint = "ItemID=" + GetKeyFromCombo(gradeCombo);
                constraints.Add(constraint);
            }
            return constraints;
        }
        public ArrayList GetMaybePOHeaderConstraints()
        {
            ArrayList constraints = new ArrayList();
            ackDateSelector.GetConstraints("MillAcknowledgeDate", constraints);
            TaggedItemStr invoiceStatusTag = (TaggedItemStr)invoiceStatusCombo.SelectedItem;
            if (invoiceStatusTag.key.Length != 0)
                constraints.Add(invoiceStatusTag.key);
            if (invoiceNumber.Text != "All" &&
                invoiceNumber.Text != "")
            {
                string constraint = "InvoiceNumber = '" + invoiceNumber.Text + "'";
                constraints.Add(constraint);
            }
            return constraints;
        }

		public ArrayList GetPOHeaderConstraints()
		{
			ArrayList constraints = new ArrayList();
            if (millCombo.SelectedIndex != 0)
            {
                TaggedItem millItem = (TaggedItem)millCombo.SelectedItem;
                string millLocationConstraint = "(MillID = " + millItem.key;
                if (millItem.key == 147) // GSB
                    millLocationConstraint += " OR MillID = 233"; //Sidenor
                else if (millItem.key == 233) // Sidenor
                    millLocationConstraint += " OR MillID = 147"; // GSB
                millLocationConstraint += ")";
                constraints.Add(millLocationConstraint);
            }
			if (customerCombo.SelectedIndex != 0)
			{
				TaggedItem customerItem =(TaggedItem)customerCombo.SelectedItem;
				string customerConstraint = "CustomerID = " + customerItem.key;
				constraints.Add(customerConstraint);
			}
			if (customerLocationCombo.SelectedIndex != 0)
			{
				TaggedItem customerLocationItem = (TaggedItem)customerLocationCombo.SelectedItem;
				string customerLocationConstraint = "CustomerLocationID = " + customerLocationItem.key;
				constraints.Add(customerLocationConstraint);
			}
			poDateSelector.GetConstraints("PODate",constraints);
			revisedDateSelector.GetConstraints("MillAcknowledgeDateRevised",constraints);
			TaggedItemStr statusTag = (TaggedItemStr)statusCombo.SelectedItem;
			constraints.Add(statusTag.key);


			return constraints;
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
            this.millCombo = new System.Windows.Forms.ComboBox();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.okbtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.customerLocationCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.invoiceStatusCombo = new System.Windows.Forms.ComboBox();
            this.SizeLbl = new System.Windows.Forms.Label();
            this.sizeCombo = new System.Windows.Forms.ComboBox();
            this.gradeCombo = new System.Windows.Forms.ComboBox();
            this.finishCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.selectShipDate = new EM.DateSelectorControl();
            this.revisedDateSelector = new EM.DateSelectorControl();
            this.ackDateSelector = new EM.DateSelectorControl();
            this.poDateSelector = new EM.DateSelectorControl();
            this.treatmentCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.invoiceNumber = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // millCombo
            // 
            this.millCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.millCombo.Location = new System.Drawing.Point(120, 16);
            this.millCombo.Name = "millCombo";
            this.millCombo.Size = new System.Drawing.Size(288, 21);
            this.millCombo.TabIndex = 1;
            this.millCombo.SelectedIndexChanged += new System.EventHandler(this.OnMillChanged);
            // 
            // customerCombo
            // 
            this.customerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerCombo.Location = new System.Drawing.Point(120, 16);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(288, 21);
            this.customerCombo.TabIndex = 1;
            this.customerCombo.SelectedIndexChanged += new System.EventHandler(this.OnCustomerChanged);
            // 
            // okbtn
            // 
            this.okbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okbtn.Location = new System.Drawing.Point(800, 496);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(64, 31);
            this.okbtn.TabIndex = 13;
            this.okbtn.Text = "OK";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(728, 496);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(64, 31);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // statusCombo
            // 
            this.statusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCombo.Location = new System.Drawing.Point(56, 16);
            this.statusCombo.Name = "statusCombo";
            this.statusCombo.Size = new System.Drawing.Size(104, 21);
            this.statusCombo.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.millCombo);
            this.groupBox1.Location = new System.Drawing.Point(24, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 49);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mill";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.customerLocationCombo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.customerCombo);
            this.groupBox2.Location = new System.Drawing.Point(24, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 80);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer";
            // 
            // customerLocationCombo
            // 
            this.customerLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerLocationCombo.Location = new System.Drawing.Point(120, 48);
            this.customerLocationCombo.MaxDropDownItems = 14;
            this.customerLocationCombo.Name = "customerLocationCombo";
            this.customerLocationCombo.Size = new System.Drawing.Size(288, 21);
            this.customerLocationCombo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Location:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Invoice Status:";
            // 
            // invoiceStatusCombo
            // 
            this.invoiceStatusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.invoiceStatusCombo.FormattingEnabled = true;
            this.invoiceStatusCombo.Location = new System.Drawing.Point(248, 16);
            this.invoiceStatusCombo.Name = "invoiceStatusCombo";
            this.invoiceStatusCombo.Size = new System.Drawing.Size(121, 21);
            this.invoiceStatusCombo.TabIndex = 7;
            // 
            // SizeLbl
            // 
            this.SizeLbl.AutoSize = true;
            this.SizeLbl.Location = new System.Drawing.Point(8, 16);
            this.SizeLbl.Name = "SizeLbl";
            this.SizeLbl.Size = new System.Drawing.Size(50, 13);
            this.SizeLbl.TabIndex = 10;
            this.SizeLbl.Text = "Item Size";
            // 
            // sizeCombo
            // 
            this.sizeCombo.FormattingEnabled = true;
            this.sizeCombo.Items.AddRange(new object[] {
            "All"});
            this.sizeCombo.Location = new System.Drawing.Point(64, 16);
            this.sizeCombo.Name = "sizeCombo";
            this.sizeCombo.Size = new System.Drawing.Size(128, 21);
            this.sizeCombo.TabIndex = 11;
            this.sizeCombo.Text = "All";
            // 
            // gradeCombo
            // 
            this.gradeCombo.FormattingEnabled = true;
            this.gradeCombo.Location = new System.Drawing.Point(168, 40);
            this.gradeCombo.Name = "gradeCombo";
            this.gradeCombo.Size = new System.Drawing.Size(136, 21);
            this.gradeCombo.TabIndex = 16;
            // 
            // finishCombo
            // 
            this.finishCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.finishCombo.FormattingEnabled = true;
            this.finishCombo.Location = new System.Drawing.Point(48, 40);
            this.finishCombo.Name = "finishCombo";
            this.finishCombo.Size = new System.Drawing.Size(64, 21);
            this.finishCombo.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(128, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Grade";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Finish";
            // 
            // selectShipDate
            // 
            this.selectShipDate.IsNullEnabled = true;
            this.selectShipDate.IsNullTitle = "No Ship Date";
            this.selectShipDate.Location = new System.Drawing.Point(448, 320);
            this.selectShipDate.Name = "selectShipDate";
            this.selectShipDate.SearchForward = true;
            this.selectShipDate.Size = new System.Drawing.Size(432, 160);
            this.selectShipDate.TabIndex = 9;
            this.selectShipDate.Title = "Ship Date";
            // 
            // revisedDateSelector
            // 
            this.revisedDateSelector.IsNullEnabled = true;
            this.revisedDateSelector.IsNullTitle = "No Revised Acknowledge Date";
            this.revisedDateSelector.Location = new System.Drawing.Point(448, 160);
            this.revisedDateSelector.Name = "revisedDateSelector";
            this.revisedDateSelector.SearchForward = false;
            this.revisedDateSelector.Size = new System.Drawing.Size(432, 152);
            this.revisedDateSelector.TabIndex = 8;
            this.revisedDateSelector.Title = "Revised Acknowledge Date Selection";
            // 
            // ackDateSelector
            // 
            this.ackDateSelector.IsNullEnabled = true;
            this.ackDateSelector.IsNullTitle = "Unacknowledged";
            this.ackDateSelector.Location = new System.Drawing.Point(448, 8);
            this.ackDateSelector.Name = "ackDateSelector";
            this.ackDateSelector.SearchForward = false;
            this.ackDateSelector.Size = new System.Drawing.Size(432, 152);
            this.ackDateSelector.TabIndex = 1;
            this.ackDateSelector.Title = "Acknowledge Date Selection";
            // 
            // poDateSelector
            // 
            this.poDateSelector.IsNullEnabled = false;
            this.poDateSelector.IsNullTitle = "Is Null";
            this.poDateSelector.Location = new System.Drawing.Point(16, 8);
            this.poDateSelector.Name = "poDateSelector";
            this.poDateSelector.SearchForward = false;
            this.poDateSelector.Size = new System.Drawing.Size(432, 152);
            this.poDateSelector.TabIndex = 0;
            this.poDateSelector.Title = "PO Date Selection";
            // 
            // treatmentCombo
            // 
            this.treatmentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.treatmentCombo.FormattingEnabled = true;
            this.treatmentCombo.Location = new System.Drawing.Point(352, 40);
            this.treatmentCombo.Name = "treatmentCombo";
            this.treatmentCombo.Size = new System.Drawing.Size(56, 21);
            this.treatmentCombo.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Treat";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.invoiceNumber);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.statusCombo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.invoiceStatusCombo);
            this.groupBox3.Location = new System.Drawing.Point(24, 344);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 80);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Invoice Number:";
            // 
            // invoiceNumber
            // 
            this.invoiceNumber.Location = new System.Drawing.Point(264, 48);
            this.invoiceNumber.Name = "invoiceNumber";
            this.invoiceNumber.Size = new System.Drawing.Size(112, 20);
            this.invoiceNumber.TabIndex = 8;
            this.invoiceNumber.Text = "All";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SizeLbl);
            this.groupBox4.Controls.Add(this.sizeCombo);
            this.groupBox4.Controls.Add(this.treatmentCombo);
            this.groupBox4.Controls.Add(this.gradeCombo);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.finishCombo);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(24, 432);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 72);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item";
            // 
            // ReportDialog
            // 
            this.AcceptButton = this.okbtn;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(895, 544);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.selectShipDate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.revisedDateSelector);
            this.Controls.Add(this.ackDateSelector);
            this.Controls.Add(this.poDateSelector);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okbtn);
            this.Name = "ReportDialog";
            this.Text = "Report Selection";
            this.Load += new System.EventHandler(this.ReportDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void ReportDialog_Load(object sender, System.EventArgs e)
		{
		
		}







		

	}
}
