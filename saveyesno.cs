using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for SaveNoSaveCancel.
	/// </summary>
	public class SaveYesNo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button dontSaveBtn;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SaveYesNo()
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
			this.dontSaveBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// saveBtn
			// 
			this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.saveBtn.Location = new System.Drawing.Point(8, 48);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.TabIndex = 0;
			this.saveBtn.Text = "&Save";
			// 
			// dontSaveBtn
			// 
			this.dontSaveBtn.DialogResult = System.Windows.Forms.DialogResult.No;
			this.dontSaveBtn.Location = new System.Drawing.Point(88, 48);
			this.dontSaveBtn.Name = "dontSaveBtn";
			this.dontSaveBtn.TabIndex = 1;
			this.dontSaveBtn.Text = "&Don\'t Save";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 32);
			this.label1.TabIndex = 3;
			this.label1.Text = "Do you want to save your changes?";
			// 
			// SaveYesNo
			// 
			this.AcceptButton = this.saveBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(176, 77);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dontSaveBtn);
			this.Controls.Add(this.saveBtn);
			this.Name = "SaveYesNo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save/Don\'t Save";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
