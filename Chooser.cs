using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace EM
{
	/// <summary>
	/// Summary description for Chooser.
	/// </summary>
	public class Chooser : System.Windows.Forms.Form
	{
        int m_recordID = 0;
		public int KeyValue
		{
			get
			{
                return m_recordID;
			}
			set
			{
			    m_recordID = value;
			}
		}
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private EM.AutoCompleteTextBox m_poNumberEdit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListView poListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;



		public enum FieldType
		{
			String,
			Money,
			Date
		}
        string keyField;
        string[] columnHeadings;
		int[] columnWidths;
		string[] fieldNames;
		private System.Windows.Forms.Button findBtn;
		private System.Windows.Forms.ComboBox statusCombo;
		private System.Windows.Forms.Label lblStatusFilter;
		private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private CheckBox showPOInfo;
		FieldType[] fieldTypes;
		
		public interface IFindButtonClick
		{
			DataTable OnFindButtonClick(OleDbConnection connection,string filter);
		}
		class POFindButtonClick : IFindButtonClick
		{
			int compID;
			int locID;
			public POFindButtonClick(int compIDIn,int locIDIn)
			{
				this.compID = compIDIn;
				this.locID = locIDIn;
			}


			public DataTable OnFindButtonClick(OleDbConnection connection,string constraint)
			{
				using (new OpenConnection(IsWrite.No,connection))
				{
					DataTable table = new DataTable();
					table.Columns.Add("POID",typeof(int));
					table.Columns.Add("PONumber",typeof(string));
					table.Columns.Add("PODate",typeof(DateTime));
					table.Columns.Add("Status",typeof(string));
					table.Columns.Add("MillID",typeof(int));
					table.Columns.Add("CustomerID",typeof(int));
					table.Columns.Add("CustomerLocationID",typeof(int));
					table.Columns.Add("MillName",typeof(string));
					table.Columns.Add("CustomerName",typeof(string));
					table.Columns.Add("CustomerLocation",typeof(string));
					OleDbDataAdapter poHeaderAdapter = new OleDbDataAdapter();
					poHeaderAdapter.SelectCommand= new OleDbCommand();
					string query = "SELECT POID, PONumber, PODate, Status,MillID,CustomerID,CustomerLocationID"+
						" FROM tblPOHeader2";
					string statusConstraint = constraint;
					ArrayList constraints = new ArrayList();

					if (statusConstraint != "All")
					{
						statusConstraint = "'" + statusConstraint + "'";
						constraints.Add("STATUS =" + statusConstraint);
					}
					if (compID != -1 && locID != -1)
					{
						string locConstraint =  "CustomerLocationID = " + locID.ToString();
						constraints.Add(locConstraint);
					}
					query += DataInterface.TranslateToConstraint(constraints);
					query += " ORDER BY PONumber";
					poHeaderAdapter.SelectCommand.CommandText = query;
					poHeaderAdapter.SelectCommand.Connection = connection;
					poHeaderAdapter.Fill(table);
					ArrayList compIDs = new ArrayList();
					EMDataSet tempDataSet = new EMDataSet();
					tempDataSet.EnforceConstraints = false;
					ArrayList locIDs = new ArrayList();
					foreach (DataRow row in table.Rows)
					{
						if (!row.IsNull("MillID"))
						{
							compIDs.Add(row["MillID"]);
						}
						if (!row.IsNull("CustomerID"))
						{
							compIDs.Add(row["CustomerID"]);
						}
						if (!row.IsNull("CustomerLocationID"))
						{
							locIDs.Add(row["CustomerLocationID"]);
						}
					}
					compIDs.Sort();
					locIDs.Sort();
					int oldID = -1;
					foreach (int id in compIDs)
					{
						if (id != oldID)
						{
							AdapterHelper.FillCompanyFromCompID(tempDataSet,id);
						}
						oldID = id;
					}
					oldID = -1;
					foreach (int id in locIDs)
					{
						if (id != oldID)
						{
							AdapterHelper.FillLocationFromLocationID(tempDataSet,id);
						}
						oldID = id;
					}
					foreach (DataRow row in table.Rows)
					{
						if (!row.IsNull("MillID"))
						{
							EMDataSet.CompanyTblRow compRow = 
								tempDataSet.CompanyTbl.FindByCompID((int)row["MillID"]);
							row["MillName"] = compRow.CompName;
						}
						if (!row.IsNull("CustomerID"))
						{
							EMDataSet.CompanyTblRow compRow = 
								tempDataSet.CompanyTbl.FindByCompID((int)row["CustomerID"]);
							row["CustomerName"] = compRow.CompName;
						}
						if (!row.IsNull("CustomerLocationID"))
						{
							EMDataSet.LocationTblRow locRow = 
								tempDataSet.LocationTbl.FindByLocID((int)row["CustomerLocationID"]);
							row["CustomerLocation"] = locRow.LocName;
						}
					}
					return table;
				}
			}
		}
		public static int GetPO(OleDbConnection connection)
		{
			return GetPO(connection,-1,-1);
		}
		public static int GetPO(OleDbConnection connection,
			int compID,int locationID)
		{
			string[] mycolumnHeadings = {"PO","Date","Status","Mill","Customer","Customer Location"};
			string[] myfieldNames = {"PONumber","PODate","Status","MillName","CustomerName","CustomerLocation"};
			FieldType[] myfieldTypes = {FieldType.String,FieldType.Date,FieldType.String,
										FieldType.String,FieldType.String,FieldType.String};
			int[] mycolumnWidths = {150,150,60,150,150,200};
			string filterName = "Status";
			string[] filterValues = new string[]{"All","Open","Closed","Cancelled"};
			int initialFilterValue = 1;
			if (compID != -1 && locationID != -1)
			{
				using (new OpenConnection(IsWrite.No,AdapterHelper.Connection))
				{
					EMDataSet tmpSet = new EMDataSet();
					tmpSet.EnforceConstraints = false;
					AdapterHelper.FillCompanyFromCompID(tmpSet,compID);
					AdapterHelper.FillLocationFromLocationID(tmpSet,locationID);
				}
				
			}
			Chooser dlg = new Chooser(connection,"POID",mycolumnHeadings,mycolumnWidths,
				myfieldNames,myfieldTypes,filterName,filterValues,initialFilterValue,
				new POFindButtonClick(compID,locationID));
			DialogResult res = dlg.ShowDialog();
			if (res == DialogResult.OK)
				return dlg.KeyValue;
			else
				return 0;

		}

        private void showPOs_Click(object sender, EventArgs e)
        {
            ContainerFindButtonClick contInfo = 
                (ContainerFindButtonClick)this.m_findButtonClick;
            contInfo.m_showPOs = !contInfo.m_showPOs;
            //fshowPOInfo.Checked = contInfo.m_showPOs;
            findBtn_Click(null, new EventArgs());
        }
		class ContainerFindButtonClick : IFindButtonClick
		{
            public bool m_showPOs = false;
			static public bool Completed(EMDataSet.ContainerTblRow row)
			{
				return DataInterface.IsCompleted(row);
			}

		
			public DataTable OnFindButtonClick(OleDbConnection connection,string constraint)
			{
				using (new OpenConnection(IsWrite.No,connection))
				{
					EMDataSet dataSet = new EMDataSet();
					dataSet.EnforceConstraints = false;
					
					OleDbDataAdapter contAdapter= new OleDbDataAdapter();
					contAdapter.SelectCommand= new OleDbCommand();
					string query = "SELECT ContID, ContNumber, ShipDate, ETA,"+
						"ApplyClosingToEntireContainer,ContainerPickupDate,"+
						"ContainerPickupTerminal,ContainerProofOfDelivery,Status,CustomerID"+
						" FROM tblContainer";
					string statusConstraint = constraint;
					if (statusConstraint != "All")
					{
						statusConstraint = "'" + statusConstraint + "'";
						query += " WHERE STATUS =" + statusConstraint;
					}
					query += " ORDER BY ContNumber";
					contAdapter.SelectCommand.CommandText = query;
					contAdapter.SelectCommand.Connection = connection;
					contAdapter.Fill(dataSet.ContainerTbl);
                    ArrayList customerIDs = new ArrayList();
                    foreach (EMDataSet.ContainerTblRow contRow in dataSet.ContainerTbl)
					{
						AdapterHelper.FillContBundle(dataSet,contRow.ContID);
                        if (!contRow.IsCustomerIDNull())
                            customerIDs.Add(contRow.CustomerID);
					}
                    AdapterHelper.Unique(ref customerIDs);
                    foreach (int id in customerIDs)
                    {
                        AdapterHelper.FillCompanyFromCompID(dataSet, id);
                    }
                    dataSet.ContainerTbl.Columns.Add("Customer",typeof(string));
                    dataSet.ContainerTbl.Columns.Add("Completed", typeof(string));
                    dataSet.ContainerTbl.Columns.Add("PONumbers", typeof(string));
					if (m_showPOs)
                    {
                        AdapterHelper.FillOutConstraints(dataSet);
					    foreach (EMDataSet.ContainerTblRow contRow in dataSet.ContainerTbl)
                        {
                            if (Completed(contRow))
                            {
                                contRow["Completed"] = "Completed";
                            }
                            else
                            {
                                contRow["Completed"] = "Incomplete";
                            }
                            ArrayList listOfPONumbers = new ArrayList();

                            foreach (EMDataSet.ContBundleTblRow bundleRow in contRow.GetContBundleTblRows())
                            {
                                listOfPONumbers.Add(bundleRow.POItemTblRow.POHeaderTblRow.PONumber);
                            }
                            listOfPONumbers.Sort();
                            AdapterHelper.UniqueStr(ref listOfPONumbers);
                            foreach (string ponum in listOfPONumbers)
                            {
                                contRow["PONumbers"] += ponum + " ";
                            }
                        }	
					}
                    foreach (EMDataSet.ContainerTblRow contRow in dataSet.ContainerTbl)
                    {
                        if (!contRow.IsCustomerIDNull())
                        {
                            contRow["Customer"] =
                                dataSet.CompanyTbl.FindByCompID(contRow.CustomerID).CompName;
                        }
                    }
					return dataSet.ContainerTbl;
				}
			}
		}
		public static int GetContainer(OleDbConnection connection)
		{
			string[] mycolumnHeadings = {"Container#","Ship Date","ETA","Status","Customer",
													"Completed","PONumbers"};
			string[] myfieldNames = {"ContNumber","ShipDate","ETA","Status","Customer","Completed","PONumbers"};
			FieldType[] myfieldTypes = {FieldType.String,FieldType.Date,FieldType.Date,
										   FieldType.String,FieldType.String,FieldType.String,
											FieldType.String};
			int[] mycolumnWidths = {100,100,100,60,100,100,400};
			string filterName = "Status";
			string[] filterValues = new string[]{"All","Open","Closed","Cancelled"};
			int initialFilterValue = 1;
			Chooser dlg = new Chooser(connection,"ContID",mycolumnHeadings,mycolumnWidths,
				myfieldNames,myfieldTypes,filterName,filterValues,initialFilterValue,
				new ContainerFindButtonClick());
            dlg.showPOInfo.Visible = true;
            DialogResult res = dlg.ShowDialog();
			if (res == DialogResult.OK)
				return dlg.KeyValue;
			else
				return 0;
		}
		OleDbConnection connection;
		IFindButtonClick m_findButtonClick;
		public Chooser(OleDbConnection connectionIn,
			string keyFieldIn,string[] columnHeadingsIn,int[] columnWidthsIn,
			string[] fieldNamesIn,FieldType[] fieldTypesIn,
			string filterName,string[] filterValues,int initialFilterValue
            ,IFindButtonClick findButtonClick)
		{
			m_findButtonClick = findButtonClick;
			connection = connectionIn;	
			columnHeadings = columnHeadingsIn;
			columnWidths = columnWidthsIn;
			fieldNames = fieldNamesIn;
			fieldTypes = fieldTypesIn;
            keyField = keyFieldIn;
            //
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			if (filterName == "")
			{
				statusCombo.Visible = false;
				lblStatusFilter.Visible = false;
			}
			else
			{
				lblStatusFilter.Text = filterName;
				statusCombo.Items.Clear();
				foreach (string s in filterValues)
				{
					statusCombo.Items.Add(s);
				}
				statusCombo.SelectedIndex = initialFilterValue;
			}
			findBtn.Focus();
			findBtn_Click(null,new EventArgs());
			m_poNumberEdit.Select();
		}
		private void okButton_Click(object sender, System.EventArgs e)
		{
			// Try to get the POID from the PONumber...
            string poNumberCandidate = m_poNumberEdit.Text;
            // only use the poid if the poNumber is not sufficient
            List<DataRow> tags = new List<DataRow>();
            for (int i = 0; i < poListView.Items.Count; i++)
            {
                ListViewItem listViewItem = poListView.Items[i];
                if (listViewItem.Text == poNumberCandidate)
                   
                    tags.Add((DataRow)listViewItem.Tag);
            }
            foreach (DataRow tag in tags)
            {
                if ((int)tag[keyField] == m_recordID)
                {
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return; // This case means that one of the tags match the PONumber... use that tag then
                }
            }
            if (tags.Count == 0) // no matches
            {
                m_recordID = 0;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                if (tags.Count == 1)
                {
                    m_recordID = (int)tags[0][keyField];
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            else {
                DataTable table = tags[0].Table;
                foreach (DataRow row in table.Rows)
                {
                    // Check to see if row is in tags
                    DataRow foundRow = tags.Find(new Predicate<DataRow>(delegate(DataRow tagRow)
                    {
                        if (tagRow == row)
                            return true;
                        return false;
                    }
                    )
                    );
                    if (foundRow == null)
                        row.Delete();

                }
                table.AcceptChanges();
                findBtn_Click(table, new EventArgs());
            }
		}

        private void OnSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (poListView.SelectedIndices.Count == 0)
				return;
			m_poNumberEdit.Text = (string)poListView.SelectedItems[0].Text;
            DataRow row = (DataRow)poListView.SelectedItems[0].Tag;
            m_recordID = (int)row[keyField];
		}

		
		private void OnDoubleClick(object sender, System.EventArgs e)
		{
			this.okButton_Click(null,new System.EventArgs());
		}

		private void OnColumnClicked(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			poListView.ListViewItemSorter = new ListViewItemComparer(e.Column,fieldTypes[e.Column]);
		}
		
		// Implements the manual sorting of items by columns.
		class ListViewItemComparer : IComparer
		{
			private int col;
			private FieldType fieldType;
			public ListViewItemComparer(int column,FieldType fieldTypeIn)
			{
				col = column;
				fieldType = fieldTypeIn;
			}
			public int Compare(object x, object y)
			{
				string s1 = ((ListViewItem)x).SubItems[col].Text;
				string s2 = ((ListViewItem)y).SubItems[col].Text;
				switch (fieldType)
				{
					case FieldType.String:
						return String.Compare(s1,s2);
					case FieldType.Date:
						if ((s1 == "") && (s2 == ""))
							return 0;
						if (s1 == "")
							return -1;
						if (s2 == "")
							return 1;
						DateTime t1 = DateTime.Parse(s1);
						DateTime t2 = DateTime.Parse(s2);
						return DateTime.Compare(t1,t2);
					default:
						throw new Exception("Bad type");
				}
			}
		}

		private void findBtn_Click(object sender, System.EventArgs e)
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
			try
			{
                DataTable table = null;
                if (sender is DataTable)
                {
                    table = (DataTable)sender;
                }
                else
                    table = m_findButtonClick.OnFindButtonClick(connection,
					statusCombo.Text);
				poListView.Clear();
				for (int i=0;i<columnHeadings.Length;i++)
				{
					poListView.Columns.Add(columnHeadings[i],
						columnWidths[i],HorizontalAlignment.Left);
				}

				System.Collections.ArrayList arrayOfKeys = 
					new System.Collections.ArrayList();
				foreach (DataRow row in table.Rows)
				{
					ListViewItem item = new ListViewItem();
					item.Text = (string)row[fieldNames[0]];
					arrayOfKeys.Add(item.Text);
					for (int i=1;i<columnHeadings.Length;i++)
					{
						if (row.IsNull(fieldNames[i]))
							item.SubItems.Add("");
						else
						{
							switch (fieldTypes[i])
							{
								case (FieldType.String):
									item.SubItems.Add((string)row[fieldNames[i]]);
									break;
								case (FieldType.Date):
									item.SubItems.Add(HelperFunctions.ToDateText((DateTime)row[fieldNames[i]]));
									break;
								default:
									throw new Exception("Bad field type");
							}
						}
					}
                    item.Tag = row;
					poListView.Items.Add(item);
				}
				this.m_poNumberEdit.MatchCandidates = 
					(string[])arrayOfKeys.ToArray(typeof(string));
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
            Cursor.Current = oldCursor;
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.poListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.statusCombo = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.findBtn = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.m_poNumberEdit = new EM.AutoCompleteTextBox();
            this.showPOInfo = new System.Windows.Forms.CheckBox();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(792, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 24);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(704, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 24);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            // 
            // poListView
            // 
            this.poListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.poListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poListView.FullRowSelect = true;
            this.poListView.Location = new System.Drawing.Point(0, 80);
            this.poListView.MultiSelect = false;
            this.poListView.Name = "poListView";
            this.poListView.Size = new System.Drawing.Size(888, 294);
            this.poListView.TabIndex = 0;
            this.poListView.UseCompatibleStateImageBehavior = false;
            this.poListView.View = System.Windows.Forms.View.Details;
            this.poListView.DoubleClick += new System.EventHandler(this.OnDoubleClick);
            this.poListView.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            this.poListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnColumnClicked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PO";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Vender";
            this.columnHeader3.Width = 100;
            // 
            // statusCombo
            // 
            this.statusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCombo.Items.AddRange(new object[] {
            "All",
            "Open",
            "Closed",
            "Cancelled"});
            this.statusCombo.Location = new System.Drawing.Point(104, 48);
            this.statusCombo.Name = "statusCombo";
            this.statusCombo.Size = new System.Drawing.Size(121, 21);
            this.statusCombo.TabIndex = 2;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.Location = new System.Drawing.Point(16, 48);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(72, 23);
            this.lblStatusFilter.TabIndex = 1;
            this.lblStatusFilter.Text = "Status Filter";
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(240, 48);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 23);
            this.findBtn.TabIndex = 3;
            this.findBtn.Text = "Find";
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.cancelButton);
            this.bottomPanel.Controls.Add(this.okButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 374);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(888, 48);
            this.bottomPanel.TabIndex = 2;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.showPOInfo);
            this.topPanel.Controls.Add(this.m_poNumberEdit);
            this.topPanel.Controls.Add(this.findBtn);
            this.topPanel.Controls.Add(this.statusCombo);
            this.topPanel.Controls.Add(this.lblStatusFilter);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(888, 80);
            this.topPanel.TabIndex = 1;
            // 
            // m_poNumberEdit
            // 
            this.m_poNumberEdit.Location = new System.Drawing.Point(16, 8);
            this.m_poNumberEdit.Name = "m_poNumberEdit";
            this.m_poNumberEdit.Size = new System.Drawing.Size(568, 20);
            this.m_poNumberEdit.TabIndex = 0;
            // 
            // showPOInfo
            // 
            this.showPOInfo.AutoSize = true;
            this.showPOInfo.Location = new System.Drawing.Point(368, 48);
            this.showPOInfo.Name = "showPOInfo";
            this.showPOInfo.Size = new System.Drawing.Size(125, 17);
            this.showPOInfo.TabIndex = 5;
            this.showPOInfo.Text = "Show PO information";
            this.showPOInfo.UseVisualStyleBackColor = true;
            this.showPOInfo.Visible = false;
            this.showPOInfo.CheckedChanged += new System.EventHandler(this.showPOs_Click);
            // 
            // Chooser
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(888, 422);
            this.Controls.Add(this.poListView);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chooser";
            this.ShowInTaskbar = false;
            this.Text = "Chooser";
            this.bottomPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion






	}
}
