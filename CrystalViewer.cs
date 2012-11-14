using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace EM
{
	/// <summary>
	/// Summary description for CrystalViewer.
	/// </summary>
	public class CrystalViewer : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Panel panel1;
        private Button exportPDF;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CrystalViewer(EMDataSet dataSet,bool isPO)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			ParameterFields fields=  new ParameterFields();
			ParameterField field = new ParameterField();
			field.ParameterFieldName = "isPO";
			ParameterDiscreteValue discrete = new ParameterDiscreteValue();
			discrete.Value = isPO;
			field.CurrentValues.Add(discrete);
			fields.Add(field);
			CrystalReport1 c = new CrystalReport1();
			crystalReportViewer1.ParameterFieldInfo = fields;
			EMDataSet copy = (EMDataSet)dataSet.Copy();
			c.SetDataSource(copy);
			crystalReportViewer1.ReportSource = c;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        private void exportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog1 = new SaveFileDialog();

//            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            CrystalReport1 c = (CrystalReport1)crystalReportViewer1.ReportSource;
            c.ExportToDisk(ExportFormatType.PortableDocFormat,openFileDialog1.FileName);
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exportPDF = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.EnableDrillDown = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 24);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowRefreshButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(544, 373);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exportPDF);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 24);
            this.panel1.TabIndex = 1;
            // 
            // exportPDF
            // 
            this.exportPDF.Location = new System.Drawing.Point(0, 0);
            this.exportPDF.Name = "exportPDF";
            this.exportPDF.Size = new System.Drawing.Size(75, 23);
            this.exportPDF.TabIndex = 0;
            this.exportPDF.Text = "PDF";
            this.exportPDF.UseVisualStyleBackColor = true;
            this.exportPDF.Click += new System.EventHandler(this.exportPDF_Click);
            // 
            // CrystalViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(544, 397);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "CrystalViewer";
            this.Text = "Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


	}
}
