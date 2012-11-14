using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for AddNewItem.
	/// </summary>
	public class AddNewItem : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox itmNameEdt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox custNameEdt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		public System.Windows.Forms.TextBox itemDescEdt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddNewItem(string companyName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			custNameEdt.Text = companyName;
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
			this.itmNameEdt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.custNameEdt = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.itemDescEdt = new System.Windows.Forms.TextBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Item Name:";
			// 
			// itmNameEdt
			// 
			this.itmNameEdt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.itmNameEdt.Location = new System.Drawing.Point(88, 48);
			this.itmNameEdt.Name = "itmNameEdt";
			this.itmNameEdt.Size = new System.Drawing.Size(344, 20);
			this.itmNameEdt.TabIndex = 3;
			this.itmNameEdt.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			this.label2.Text = "Customer Name:";
			// 
			// custNameEdt
			// 
			this.custNameEdt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.custNameEdt.Location = new System.Drawing.Point(128, 8);
			this.custNameEdt.Name = "custNameEdt";
			this.custNameEdt.ReadOnly = true;
			this.custNameEdt.Size = new System.Drawing.Size(304, 20);
			this.custNameEdt.TabIndex = 1;
			this.custNameEdt.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Item Description:";
			// 
			// itemDescEdt
			// 
			this.itemDescEdt.AcceptsReturn = true;
			this.itemDescEdt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.itemDescEdt.Location = new System.Drawing.Point(16, 104);
			this.itemDescEdt.Multiline = true;
			this.itemDescEdt.Name = "itemDescEdt";
			this.itemDescEdt.Size = new System.Drawing.Size(424, 120);
			this.itemDescEdt.TabIndex = 5;
			this.itemDescEdt.Text = "";
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(360, 240);
			this.okBtn.Name = "okBtn";
			this.okBtn.TabIndex = 7;
			this.okBtn.Text = "OK";
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(280, 240);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(72, 23);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "Cancel";
			// 
			// AddNewItem
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(448, 273);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.itemDescEdt);
			this.Controls.Add(this.custNameEdt);
			this.Controls.Add(this.itmNameEdt);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "AddNewItem";
			this.Text = "Add Item Spec";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
