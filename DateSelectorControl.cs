using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for DateSelectorControl.
	/// </summary>
	public class DateSelectorControl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.RadioButton allDateRadio;
		private System.Windows.Forms.RadioButton byDateRadio;
		private System.Windows.Forms.RadioButton byMonthRadio;
		private System.Windows.Forms.RadioButton isNullRadio;
		private System.Windows.Forms.Label yearText;
		private System.Windows.Forms.Button endDateBtn;
		private System.Windows.Forms.TextBox endDateEdt;
		private System.Windows.Forms.Label startDateText;
		private System.Windows.Forms.Label endDateText;
		private System.Windows.Forms.Button startDateBtn;
		private System.Windows.Forms.TextBox startDateEdt;
		private System.Windows.Forms.ComboBox monthlyCombo;
		private System.Windows.Forms.Label monthlyReportText;
		private System.Windows.Forms.GroupBox groupBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DateSelectorControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			int currentYear = System.DateTime.Now.Year;
			startDateEdt.Text = HelperFunctions.ToDateText(new System.DateTime(currentYear,1,1));
			endDateEdt.Text = HelperFunctions.ToDateText(System.DateTime.Now);
			int currentMonth = System.DateTime.Now.Month;
			monthlyCombo.SelectedIndex = currentMonth-1;
			allDateRadio.Select();
		}
        bool m_searchForward = false;
        public bool SearchForward
        {
            get
            {
                return m_searchForward;
            }
            set
            {
                m_searchForward = value;
            }
        }
		public string Title
		{
			get
			{
				return groupBox.Text;
			}
			set
			{
				groupBox.Text = value;
			}
		}
		public string IsNullTitle
		{
			get
			{
				return isNullRadio.Text;
			}
			set
			{
				isNullRadio.Text = value;
			}
		}
		public bool IsNullEnabled
		{
			get
			{
				return isNullRadio.Visible;
			}
			set
			{
				isNullRadio.Visible = value;
			}
		}
		public string GetConstraints(string fieldName,string nullFieldName)
		{
			if (allDateRadio.Checked)
				return null;
			if (isNullRadio.Checked)
			{
				return nullFieldName + " IS NULL";
			}
			System.DateTime startDateObj = System.DateTime.Parse(startDateEdt.Text);
			System.DateTime endDateObj = System.DateTime.Parse(endDateEdt.Text);
			string startDate = HelperFunctions.ToDateText(startDateObj);
			string endDate = HelperFunctions.ToDateText(endDateObj);
			string totalDateConstraint = fieldName + " BETWEEN #" + startDate + "# AND #" + endDate + "#";
			return totalDateConstraint;
		}
        public string GetConstraints(string fieldName)
        {
            return GetConstraints(fieldName, fieldName);
        }
		public void GetConstraints(string fieldName,ArrayList list)
		{
			string str = GetConstraints(fieldName);
			if (str != null)
				list.Add(str);
		}
		public string GetFriendlyConstraints(string fieldName)
		{
			if (allDateRadio.Checked)
				return null;
			if (isNullRadio.Checked)
			{
				return "Only show orders with no " + fieldName + "\n";
			}
			System.DateTime startDateObj = System.DateTime.Parse(startDateEdt.Text);
			System.DateTime endDateObj = System.DateTime.Parse(endDateEdt.Text);
			string startDate = HelperFunctions.ToDateText(startDateObj);
			string endDate = HelperFunctions.ToDateText(endDateObj);
			return fieldName + 
				" Start Date: " + startDate + "  End Date: " + endDate + "\n";
		}
		public string GetFriendlyConstraints(string fieldName,ref string total)
		{
			string str = GetFriendlyConstraints(fieldName);
			if (str!=null)
			{
				total += str;
			}
			return total;
		}
		void dateBtnClick(TextBox edt)
		{
			System.DateTime defaultTime = System.DateTime.Today;
			if (edt.Text != "")
			{
				try
				{
					defaultTime = System.DateTime.Parse(edt.Text);
				}
				catch(Exception)
				{
				}
			}
			if (DialogResult.OK == 
				DateTimeSelector.RequestTime(ref defaultTime,this))
			{
				edt.Text = HelperFunctions.ToDateText(defaultTime);
			}
		}
		private void startDateBtn_Click(object sender, System.EventArgs e)
		{
			dateBtnClick(startDateEdt);
		}
		private void endDateBtn_Click(object sender, System.EventArgs e)
		{
			dateBtnClick(endDateEdt);
		}
		void UpdateControls()
		{
			EnableControls(byDateRadio.Checked,startDateText,endDateText,
				startDateEdt,endDateEdt,startDateBtn,endDateBtn);
			EnableControls(byMonthRadio.Checked,monthlyReportText,
				yearText,monthlyCombo);
			int monthSelected = monthlyCombo.SelectedIndex + 1; //convert from 0 based to 1 based
			int currentMonth = System.DateTime.Now.Month;
			int currentYear = System.DateTime.Now.Year;
            if (!this.m_searchForward)
            {
                if (monthSelected > currentMonth)
                    currentYear = currentYear - 1;
            }
            if (this.m_searchForward)
            {
                if (monthSelected < currentMonth)
                    currentYear = currentYear + 1;
            }
			yearText.Text = currentYear.ToString();
			if (byMonthRadio.Checked)
			{
				System.DateTime startDate = new System.DateTime(currentYear,monthSelected ,1);
				System.DateTime endDate = endDate = 
					new System.DateTime(currentYear,monthSelected ,
					System.DateTime.DaysInMonth(currentYear,monthSelected ));
				startDateEdt.Text = HelperFunctions.ToDateText(startDate);
				endDateEdt.Text = HelperFunctions.ToDateText(endDate);
			}
		}
		void EnableControls(bool newState,params Control[] cs)
		{
			foreach (Control c in cs)
			{
				c.Enabled = newState;
			}
		}
		private void allDateRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateControls();
		}
		private void byDateRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateControls();
		}
		private void byMonthRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateControls();
		}
		private void isNullRadio_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateControls();
		}
		private void MonthlySelectedChanged(object sender, System.EventArgs e)
		{
			UpdateControls();
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.yearText = new System.Windows.Forms.Label();
			this.endDateBtn = new System.Windows.Forms.Button();
			this.endDateEdt = new AutoCompleteTextBox();
			this.startDateText = new System.Windows.Forms.Label();
			this.endDateText = new System.Windows.Forms.Label();
			this.startDateBtn = new System.Windows.Forms.Button();
			this.startDateEdt = new AutoCompleteTextBox();
			this.monthlyCombo = new System.Windows.Forms.ComboBox();
			this.monthlyReportText = new System.Windows.Forms.Label();
			this.isNullRadio = new System.Windows.Forms.RadioButton();
			this.byMonthRadio = new System.Windows.Forms.RadioButton();
			this.byDateRadio = new System.Windows.Forms.RadioButton();
			this.allDateRadio = new System.Windows.Forms.RadioButton();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.yearText);
			this.groupBox.Controls.Add(this.endDateBtn);
			this.groupBox.Controls.Add(this.endDateEdt);
			this.groupBox.Controls.Add(this.startDateText);
			this.groupBox.Controls.Add(this.endDateText);
			this.groupBox.Controls.Add(this.startDateBtn);
			this.groupBox.Controls.Add(this.startDateEdt);
			this.groupBox.Controls.Add(this.monthlyCombo);
			this.groupBox.Controls.Add(this.monthlyReportText);
			this.groupBox.Controls.Add(this.isNullRadio);
			this.groupBox.Controls.Add(this.byMonthRadio);
			this.groupBox.Controls.Add(this.byDateRadio);
			this.groupBox.Controls.Add(this.allDateRadio);
			this.groupBox.Location = new System.Drawing.Point(8, 8);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(416, 144);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Date Title";
			// 
			// yearText
			// 
			this.yearText.Location = new System.Drawing.Point(296, 88);
			this.yearText.Name = "yearText";
			this.yearText.TabIndex = 20;
			this.yearText.Text = "label6";
			// 
			// endDateBtn
			// 
			this.endDateBtn.Location = new System.Drawing.Point(384, 56);
			this.endDateBtn.Name = "endDateBtn";
			this.endDateBtn.Size = new System.Drawing.Size(24, 23);
			this.endDateBtn.TabIndex = 17;
			this.endDateBtn.Text = "...";
			this.endDateBtn.Click += new System.EventHandler(this.endDateBtn_Click);
			// 
			// endDateEdt
			// 
			this.endDateEdt.Location = new System.Drawing.Point(312, 56);
			this.endDateEdt.Name = "endDateEdt";
			this.endDateEdt.Size = new System.Drawing.Size(64, 20);
			this.endDateEdt.TabIndex = 16;
			this.endDateEdt.Text = "textBox1";
			// 
			// startDateText
			// 
			this.startDateText.Location = new System.Drawing.Point(80, 56);
			this.startDateText.Name = "startDateText";
			this.startDateText.Size = new System.Drawing.Size(64, 16);
			this.startDateText.TabIndex = 12;
			this.startDateText.Text = "Start Date:";
			// 
			// endDateText
			// 
			this.endDateText.Location = new System.Drawing.Point(256, 56);
			this.endDateText.Name = "endDateText";
			this.endDateText.Size = new System.Drawing.Size(56, 16);
			this.endDateText.TabIndex = 15;
			this.endDateText.Text = "End Date:";
			// 
			// startDateBtn
			// 
			this.startDateBtn.Location = new System.Drawing.Point(216, 56);
			this.startDateBtn.Name = "startDateBtn";
			this.startDateBtn.Size = new System.Drawing.Size(24, 23);
			this.startDateBtn.TabIndex = 14;
			this.startDateBtn.Text = "...";
			this.startDateBtn.Click += new System.EventHandler(this.startDateBtn_Click);
			// 
			// startDateEdt
			// 
			this.startDateEdt.Location = new System.Drawing.Point(144, 56);
			this.startDateEdt.Name = "startDateEdt";
			this.startDateEdt.Size = new System.Drawing.Size(64, 20);
			this.startDateEdt.TabIndex = 13;
			this.startDateEdt.Text = "textBox1";
			// 
			// monthlyCombo
			// 
			this.monthlyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.monthlyCombo.Items.AddRange(new object[] {
															  "January",
															  "February",
															  "March",
															  "April",
															  "May",
															  "June",
															  "July",
															  "August",
															  "September",
															  "October",
															  "November",
															  "December"});
			this.monthlyCombo.Location = new System.Drawing.Point(168, 88);
			this.monthlyCombo.MaxDropDownItems = 20;
			this.monthlyCombo.Name = "monthlyCombo";
			this.monthlyCombo.Size = new System.Drawing.Size(121, 21);
			this.monthlyCombo.TabIndex = 19;
			this.monthlyCombo.SelectedIndexChanged += new System.EventHandler(this.MonthlySelectedChanged);
			// 
			// monthlyReportText
			// 
			this.monthlyReportText.Location = new System.Drawing.Point(80, 88);
			this.monthlyReportText.Name = "monthlyReportText";
			this.monthlyReportText.Size = new System.Drawing.Size(88, 16);
			this.monthlyReportText.TabIndex = 18;
			this.monthlyReportText.Text = "Monthly Report";
			// 
			// isNullRadio
			// 
			this.isNullRadio.Location = new System.Drawing.Point(8, 112);
			this.isNullRadio.Name = "isNullRadio";
			this.isNullRadio.Size = new System.Drawing.Size(392, 24);
			this.isNullRadio.TabIndex = 3;
			this.isNullRadio.Text = "Is Null";
			this.isNullRadio.CheckedChanged += new System.EventHandler(this.isNullRadio_CheckedChanged);
			// 
			// byMonthRadio
			// 
			this.byMonthRadio.Location = new System.Drawing.Point(8, 80);
			this.byMonthRadio.Name = "byMonthRadio";
			this.byMonthRadio.Size = new System.Drawing.Size(72, 24);
			this.byMonthRadio.TabIndex = 2;
			this.byMonthRadio.Text = "By Month";
			this.byMonthRadio.CheckedChanged += new System.EventHandler(this.byMonthRadio_CheckedChanged);
			// 
			// byDateRadio
			// 
			this.byDateRadio.Location = new System.Drawing.Point(8, 48);
			this.byDateRadio.Name = "byDateRadio";
			this.byDateRadio.Size = new System.Drawing.Size(72, 24);
			this.byDateRadio.TabIndex = 1;
			this.byDateRadio.Text = "By Date";
			this.byDateRadio.CheckedChanged += new System.EventHandler(this.byDateRadio_CheckedChanged);
			// 
			// allDateRadio
			// 
			this.allDateRadio.Location = new System.Drawing.Point(8, 16);
			this.allDateRadio.Name = "allDateRadio";
			this.allDateRadio.Size = new System.Drawing.Size(72, 24);
			this.allDateRadio.TabIndex = 0;
			this.allDateRadio.Text = "All";
			this.allDateRadio.CheckedChanged += new System.EventHandler(this.allDateRadio_CheckedChanged);
			// 
			// DateSelectorControl
			// 
			this.Controls.Add(this.groupBox);
			this.Name = "DateSelectorControl";
			this.Size = new System.Drawing.Size(432, 168);
			this.groupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	}
}
