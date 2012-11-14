using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;


namespace EM
{
	/// <summary>
	/// Summary description for ReportDialog.
	/// </summary>
	public class ContainerReportDialog : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okbtn;
        private EM.DateSelectorControl contDateSelector;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox statusCombo;
        private DateSelectorControl etaDateSelector;
        private ComboBox customerCombo;
        private Label label6;
        private Label label7;
        private ComboBox customerLocationCombo;
        private GroupBox groupBox2;
        private DateSelectorControl releaseDateSelector;
        private GroupBox groupBox1;
        private Label label3;
        private ComboBox millCombo;
        private NumberSelectorControl millInvoiceSelector;
        private NumberSelectorControl emInvoiceSelector;
        private DateSelectorControl pickupDateControl;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		void SetupCombo(ComboBox box,string constraint)
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


		private void OnCustomerChanged(object sender, System.EventArgs e)
		{
			object oItem = customerCombo.SelectedItem;
			TaggedItem tagged = (TaggedItem)oItem;
			SetupLocationCombo(customerLocationCombo,tagged.key);
		}
       


		public ContainerReportDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			SetupCombo(customerCombo,"Customer");
            SetupCombo(millCombo, "Vendor");
			
            string[] statusComboTitles = {"Not cancelled","Open only","Closed only","Cancelled only"};
			string[] statusComboMeaning = {"NOT STATUS = \"Cancelled\"",
											  "STATUS = \"Open\"",
											  "STATUS = \"Closed\"",
											  "STATUS = \"Cancelled\""};
			for (int i=0;i<statusComboTitles.Length;i++)
			{
				TaggedItemStr tag = new TaggedItemStr(statusComboMeaning[i],
													statusComboTitles[i]);
				statusCombo.Items.Add(tag);
			}
			statusCombo.SelectedIndex =0;
            for (int i = 0; i < millCombo.Items.Count;i++ )
            {
                TaggedItem item = (TaggedItem)millCombo.Items[i];
                if (item.key == 233) // Sidenor Industrial, S.A. 
                {
                    millCombo.SelectedIndex = i;
                    break;
                }
            }
		}
        public string GetFriendlyConstraints()
		{
			string constraints = "";
			contDateSelector.GetFriendlyConstraints("Ship Date",ref constraints);
            etaDateSelector.GetFriendlyConstraints("ETA Date", ref constraints);
            releaseDateSelector.GetFriendlyConstraints("Release Date", ref constraints);
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
            if (millCombo.SelectedIndex != 0)
            {
                TaggedItem millItem = (TaggedItem)millCombo.SelectedItem;
                constraints += "Mill: " + millItem.title + "\n";
            }
			if (statusCombo.SelectedIndex != 0)
			{
				TaggedItemStr statusTag = (TaggedItemStr)statusCombo.SelectedItem;
				constraints += "Status = " + statusTag.title + "\n";
			}

            millInvoiceSelector.GetFriendlyConstraints(ref constraints);
            emInvoiceSelector.GetFriendlyConstraints(ref constraints);

            return constraints;
		}
		public string GetPOHeaderConstraints()
		{
			ArrayList constraints = new ArrayList();
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
            if (millCombo.SelectedIndex != 0)
            {
                TaggedItem millItem = (TaggedItem)millCombo.SelectedItem;
                string millLocationConstraint = "MillID = " + millItem.key;
                if (millItem.key == 147) // GSB
                    millLocationConstraint += " OR MillID = 233"; //Sidenor
                else if (millItem.key == 233) // Sidenor
                    millLocationConstraint += " OR MillID = 147"; // GSB
                millLocationConstraint = "(" +
                    millLocationConstraint + ")";
                constraints.Add(millLocationConstraint);
			}
			contDateSelector.GetConstraints("ShipDate",constraints);
            etaDateSelector.GetConstraints("ETA", constraints);
            releaseDateSelector.GetConstraints("ReleaseDate", constraints);
			TaggedItemStr statusTag = (TaggedItemStr)statusCombo.SelectedItem;
			constraints.Add(statusTag.key);

			return DataInterface.TranslateToConstraint(constraints);
		}
        public ArrayList GetItemConstraints()
        {
            ArrayList constraints = new ArrayList();
            millInvoiceSelector.GetConstraints(constraints);
            if (constraints.Count == 1)
            {
                string constraint = (string)constraints[0];
                if (constraint == "InvoiceNumber IS NOT NULL")
                    constraints[0] = "MillInvoiceDate IS NOT NULL";
            }
            emInvoiceSelector.GetConstraints(constraints);
            pickupDateControl.GetConstraints("PickupDate", constraints);
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
            this.okbtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusCombo = new System.Windows.Forms.ComboBox();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.customerLocationCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.millCombo = new System.Windows.Forms.ComboBox();
            this.emInvoiceSelector = new EM.NumberSelectorControl();
            this.millInvoiceSelector = new EM.NumberSelectorControl();
            this.releaseDateSelector = new EM.DateSelectorControl();
            this.etaDateSelector = new EM.DateSelectorControl();
            this.contDateSelector = new EM.DateSelectorControl();
            this.pickupDateControl = new EM.DateSelectorControl();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okbtn
            // 
            this.okbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okbtn.Location = new System.Drawing.Point(808, 500);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(80, 23);
            this.okbtn.TabIndex = 6;
            this.okbtn.Text = "OK";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(713, 500);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(80, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(95, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Status:";
            // 
            // statusCombo
            // 
            this.statusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCombo.Location = new System.Drawing.Point(160, 494);
            this.statusCombo.Name = "statusCombo";
            this.statusCombo.Size = new System.Drawing.Size(272, 21);
            this.statusCombo.TabIndex = 12;
            // 
            // customerCombo
            // 
            this.customerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerCombo.Location = new System.Drawing.Point(120, 16);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(288, 21);
            this.customerCombo.TabIndex = 5;
            this.customerCombo.SelectedIndexChanged += new System.EventHandler(this.OnCustomerChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Name:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Location:";
            // 
            // customerLocationCombo
            // 
            this.customerLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerLocationCombo.Location = new System.Drawing.Point(120, 48);
            this.customerLocationCombo.MaxDropDownItems = 14;
            this.customerLocationCombo.Name = "customerLocationCombo";
            this.customerLocationCombo.Size = new System.Drawing.Size(288, 21);
            this.customerLocationCombo.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.customerLocationCombo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.customerCombo);
            this.groupBox2.Location = new System.Drawing.Point(24, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 80);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.millCombo);
            this.groupBox1.Location = new System.Drawing.Point(24, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 50);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mill";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // millCombo
            // 
            this.millCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.millCombo.Location = new System.Drawing.Point(120, 16);
            this.millCombo.Name = "millCombo";
            this.millCombo.Size = new System.Drawing.Size(288, 21);
            this.millCombo.TabIndex = 5;
            // 
            // emInvoiceSelector
            // 
            this.emInvoiceSelector.FieldName = "EMInvoiceNumber";
            this.emInvoiceSelector.FriendlyFieldName = "EM Invoice";
            this.emInvoiceSelector.Location = new System.Drawing.Point(24, 384);
            this.emInvoiceSelector.Name = "emInvoiceSelector";
            this.emInvoiceSelector.Size = new System.Drawing.Size(287, 90);
            this.emInvoiceSelector.TabIndex = 18;
            this.emInvoiceSelector.Title = "EM Invoice Number";
            // 
            // millInvoiceSelector
            // 
            this.millInvoiceSelector.FieldName = "InvoiceNumber";
            this.millInvoiceSelector.FriendlyFieldName = "Mill Invoice";
            this.millInvoiceSelector.Location = new System.Drawing.Point(24, 296);
            this.millInvoiceSelector.Name = "millInvoiceSelector";
            this.millInvoiceSelector.Size = new System.Drawing.Size(297, 90);
            this.millInvoiceSelector.TabIndex = 17;
            this.millInvoiceSelector.Title = "Mill Invoice Number";
            // 
            // releaseDateSelector
            // 
            this.releaseDateSelector.IsNullEnabled = true;
            this.releaseDateSelector.IsNullTitle = "Only containers with no Release Date";
            this.releaseDateSelector.Location = new System.Drawing.Point(456, 160);
            this.releaseDateSelector.Name = "releaseDateSelector";
            this.releaseDateSelector.SearchForward = false;
            this.releaseDateSelector.Size = new System.Drawing.Size(432, 152);
            this.releaseDateSelector.TabIndex = 16;
            this.releaseDateSelector.Title = "Release Date";
            // 
            // etaDateSelector
            // 
            this.etaDateSelector.IsNullEnabled = true;
            this.etaDateSelector.IsNullTitle = "Only containers with no ETA Date";
            this.etaDateSelector.Location = new System.Drawing.Point(456, 8);
            this.etaDateSelector.Name = "etaDateSelector";
            this.etaDateSelector.SearchForward = false;
            this.etaDateSelector.Size = new System.Drawing.Size(432, 152);
            this.etaDateSelector.TabIndex = 15;
            this.etaDateSelector.Title = "ETA Date";
            // 
            // contDateSelector
            // 
            this.contDateSelector.IsNullEnabled = true;
            this.contDateSelector.IsNullTitle = "Only containers with no ship date";
            this.contDateSelector.Location = new System.Drawing.Point(16, 8);
            this.contDateSelector.Name = "contDateSelector";
            this.contDateSelector.SearchForward = false;
            this.contDateSelector.Size = new System.Drawing.Size(432, 152);
            this.contDateSelector.TabIndex = 8;
            this.contDateSelector.Title = "Ship Date";
            // 
            // pickupDateControl
            // 
            this.pickupDateControl.IsNullEnabled = true;
            this.pickupDateControl.IsNullTitle = "Only container items with no pickup date";
            this.pickupDateControl.Location = new System.Drawing.Point(456, 318);
            this.pickupDateControl.Name = "pickupDateControl";
            this.pickupDateControl.SearchForward = false;
            this.pickupDateControl.Size = new System.Drawing.Size(432, 152);
            this.pickupDateControl.TabIndex = 19;
            this.pickupDateControl.Title = "Pickup Date";
            // 
            // ContainerReportDialog
            // 
            this.AcceptButton = this.okbtn;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(928, 535);
            this.Controls.Add(this.pickupDateControl);
            this.Controls.Add(this.emInvoiceSelector);
            this.Controls.Add(this.millInvoiceSelector);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.releaseDateSelector);
            this.Controls.Add(this.etaDateSelector);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contDateSelector);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okbtn);
            this.Name = "ContainerReportDialog";
            this.Text = "Report Selection";
            this.Load += new System.EventHandler(this.ReportDialog_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void ReportDialog_Load(object sender, System.EventArgs e)
		{
		
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        void FillOutSurcharges(EMDataSet.ContBundleTblRow contBundleRow)
        {
            // look up the scrap surcharge and the allow surcharge
            EMDataSet dataSet = (EMDataSet)contBundleRow.Table.DataSet;

            EMDataSet.SurchargeRateTblDataTable surcharges = dataSet.SurchargeRateTbl;
            // First find the scrap
            if (contBundleRow.IsMillInvoiceDateNull())
                return;

            int dateCode = HelperFunctions.GetMonthYearCode(contBundleRow.MillInvoiceDate);
            string date = dateCode.ToString();
            string query = "SurchargeMonth = '" + date.ToString() + "' AND " +
                "ItemID=-1 AND FinishID = " + contBundleRow.POItemTblRow.FinishID;
            EMDataSet.SurchargeRateTblRow[] scrapRows = (EMDataSet.SurchargeRateTblRow[])
                surcharges.Select(query);
            if (scrapRows.Length == 1)
                contBundleRow.BundleScrapSurcharge = scrapRows[0].SurchargeRate * 100;
            else if (scrapRows.Length != 0)
                System.Diagnostics.Debug.Assert(false);
            string alloyquery = "SurchargeMonth = '" + date.ToString() + "' AND " +
                "ItemID=" + contBundleRow.POItemTblRow.ItemID + " AND FinishID = " + contBundleRow.POItemTblRow.FinishID.ToString();
            EMDataSet.SurchargeRateTblRow[] alloyRows = (EMDataSet.SurchargeRateTblRow[])
                surcharges.Select(alloyquery);
            if (alloyRows.Length == 1)
                contBundleRow.BundleAlloySurcharge = alloyRows[0].SurchargeRate * 100;
            else 
                if (alloyRows.Length != 0)System.Diagnostics.Debug.Assert(false);

        }

        // Here we propogate the latest mill PO invoice number to the
        // latest container invoice number
        private void button1_Click(object sender, EventArgs e)
        {
            // Idea is to test whether or not all containers have mills...
            // and then to enforce this here.
            EMDataSet dataSet = new EMDataSet();
            using (new TurnOffConstraints(dataSet))
            using (new OpenConnection(IsWrite.Yes, AdapterHelper.Connection))
            {
                AdapterHelper.FillAllPOHeaders(dataSet);
                foreach (EMDataSet.POHeaderTblRow row in dataSet.POHeaderTbl)
                {
                    if (row.IsInvoiceNumberNull())
                        row.InvoiceNumber = "";
                }
                AdapterHelper.CommitAllPOHeaders(dataSet);
                return;

                AdapterHelper.FillAllContHeaders(dataSet, "");
                foreach (EMDataSet.ContainerTblRow row in dataSet.ContainerTbl)
                {
                    AdapterHelper.FillContBundle(dataSet, row.ContID);
                }
                AdapterHelper.FillOutConstraints(dataSet);
                bool ignoreFailure = false;
                //AdapterHelper.FillAllSurcharges(dataSet.SurchargeRateTbl);
                foreach (EMDataSet.ContainerTblRow row in dataSet.ContainerTbl)
                {
                    int millID = -1; // undefined
                    foreach (EMDataSet.ContBundleTblRow bundleRow in row.GetContBundleTblRows())
                    {
                  //      FillOutSurcharges(bundleRow);
                        AddMillDate(bundleRow);
                        int currentMillID = bundleRow.POItemTblRow.POHeaderTblRow.MillID;
                        int currentCustID = bundleRow.POItemTblRow.POHeaderTblRow.CustomerID;
                        EMDataSet.POHeaderTblRow headerRow = bundleRow.POItemTblRow.POHeaderTblRow;
                        bool dontApplyMillConfirmationToEntirePO =
                            (!headerRow.IsMillConfirmationAppliesToEntirePONull() &&
                            headerRow.MillConfirmationAppliesToEntirePO == 0);
                        bool applyMillConfirmationToEntirePO = !dontApplyMillConfirmationToEntirePO;
                        object invoiceNumber;
                        if (applyMillConfirmationToEntirePO)
                        {
                            invoiceNumber = bundleRow.POItemTblRow.POHeaderTblRow["InvoiceNumber"];
                        }
                        else
                        {
                            invoiceNumber = bundleRow.POItemTblRow["InvoiceNumber"];
                            if (invoiceNumber is System.DBNull)
                            {
                                invoiceNumber = bundleRow.POItemTblRow.POHeaderTblRow["InvoiceNumber"];
                            }
                        }
                        if (invoiceNumber is System.DBNull || (string)invoiceNumber == "")
                        {
                   //         System.Diagnostics.Debug.Assert(
                     //           bundleRow.IsEMInvoiceNumberNull() ||
                       //         bundleRow.EMInvoiceNumber == "");
                            continue; // don't throw out the EM invoice number...
                        }
                        if (invoiceNumber is string)
                        {
                            if (!bundleRow.IsEMInvoiceNumberNull() &&
                                bundleRow.EMInvoiceNumber != "")
                                continue;
                        }

                        bundleRow["EMInvoiceNumber"] = invoiceNumber;

                        if (currentCustID != row.CustomerID)
                        {
                            if (!ignoreFailure)
                            {
                                //    System.Diagnostics.Debug.Assert(false);
                            }
                        }
                        if (currentMillID == 147)
                            currentMillID = 233; // convert GSB to sidenor
                        if (currentMillID != millID && // convert GSB to sidenor
                            (!(currentMillID == 233 &&
                            millID == 147)))
                        {
                            if (millID != -1)
                            {
                                System.Diagnostics.Debug.Assert(false);
                            }
                            millID = currentMillID;
                            row.MillID = millID;
                        }
                    }
                    // now identify the mill ID from one item
                }
                AdapterHelper.CommitContainerChanges(dataSet);
            }
        }
        void AddMillDate(EMDataSet.ContBundleTblRow row)
        {
            for (int i = 0; i < millInvoiceNumbers.Length; i++)
            {
                if (row.IsInvoiceNumberNull())
                    continue;
                if (row.InvoiceNumber == millInvoiceNumbers[i])
                {
                    // 
                    DateTime dateTime = DateTime.Parse(millInvoiceDates[i]);
                    row.MillInvoiceDate = dateTime;
                    System.Diagnostics.Debug.Assert(dateTime.Year == 2007);
                    System.Diagnostics.Debug.Assert(dateTime.Month > 8);
                }
            }

        }
        string[] millInvoiceNumbers = {
        "725974",
"726025",
"726026",
"726027",
"726112",
"726319",
"726526",
"726528",
"726742",
"8207733",
"8207732",
"8207734",
"8207735",
"8207741",
"8207742",
"8207752",
"8207753",
"8207736",
"8207737",
"8207738",
"8207739",
"8207754",
"8207755",
"8207757",
"8207760",
"8208722",
"8208723",
"8208728",
"8208729",
"8208694",
"8210686",
"8210687",
"8210688",
"8210712",
"8210753",
"8210754",
"8210755",
"725538",
"725669",
"726648",
"726745",
"726750"

};
        string[] millInvoiceDates = new string[]{
               "10/2/2007",
"10/3/2007",
"10/3/2007",
"10/3/2007",
"10/8/2007",
"10/18/2007",
"10/22/2007",
"10/22/2007",
"10/26/2007",
"11/14/2007",
"11/16/2007",
"11/16/2007",
"11/16/2007",
"11/19/2007",
"11/19/2007",
"11/19/2007",
"11/19/2007",
"11/20/2007",
"11/20/2007",
"11/20/2007",
"11/20/2007",
"11/20/2007",
"11/20/2007",
"11/22/2007",
"11/22/2007",
"11/23/2007",
"11/23/2007",
"11/23/2007",
"11/23/2007",
"11/27/2007",
"12/3/2007",
"12/3/2007",
"12/3/2007",
"12/3/2007",
"12/3/2007",
"12/4/2007",
"12/4/2007",
"9/24/2007",
"9/24/2007",
"10/22/07",
"10/22/07",
"10/22/07"

        };







		

	}
}
