using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;
namespace EM
{
	/// <summary>
	/// Summary description for PickComputerName.
	/// </summary>
	public class PickComputerName : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox computerNameEdit;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button OKBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		RegistryKey GetKey()
		{
			return Registry.CurrentUser.CreateSubKey("SOFTWARE\\EM");
		}
		void SetValue(string val)
		{
			
			using (RegistryKey key = GetKey())
			{
				key.SetValue("ServerName",val);
			}
		}
		string GetValue()
		{
			using (RegistryKey key = GetKey())
			{
				if (key == null)
					return "";
				string val = (string)key.GetValue("ServerName","");
				return val;
			}
		}
		public PickComputerName()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			computerNameEdit.Text = GetValue();


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
			this.label1 = new System.Windows.Forms.Label();
			this.computerNameEdit = new System.Windows.Forms.TextBox();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server Name:";
			// 
			// computerNameEdit
			// 
			this.computerNameEdit.Location = new System.Drawing.Point(104, 24);
			this.computerNameEdit.Name = "computerNameEdit";
			this.computerNameEdit.Size = new System.Drawing.Size(152, 20);
			this.computerNameEdit.TabIndex = 1;
			this.computerNameEdit.Text = "";
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(136, 64);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(64, 40);
			this.cancelBtn.TabIndex = 2;
			this.cancelBtn.Text = "Cancel";
			// 
			// OKBtn
			// 
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(208, 64);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(64, 40);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// PickComputerName
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(280, 109);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.computerNameEdit);
			this.Controls.Add(this.label1);
			this.Name = "PickComputerName";
			this.Text = "PickComputerName";
			this.ResumeLayout(false);

		}
		#endregion

		private void OKBtn_Click(object sender, System.EventArgs e)
		{
			string computerName = computerNameEdit.Text;
			SetValue(computerName);
		}
	}
}
