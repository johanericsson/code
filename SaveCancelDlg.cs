using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for SaveCancelDlg.
	/// </summary>
	public class SaveCancelDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SaveCancelDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// saveBtn
			// 
			this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.saveBtn.Location = new System.Drawing.Point(24, 48);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.TabIndex = 0;
			this.saveBtn.Text = "&Save";
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(120, 48);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "&Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 32);
			this.label1.TabIndex = 2;
			this.label1.Text = "Do you want to save your changes?";
			// 
			// SaveCancelDlg
			// 
			this.AcceptButton = this.saveBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(216, 77);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.saveBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveCancelDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save/Cancel?";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
