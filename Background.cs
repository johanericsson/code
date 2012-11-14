using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for Background.
	/// </summary>
	public class Background : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button itemsBtn;
		private System.Windows.Forms.Button companyBtn;
		private System.Windows.Forms.Button locationsBtn;
		private System.Windows.Forms.Button countryBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button contBtn;
		private System.Windows.Forms.Button poBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Background()
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.itemsBtn = new System.Windows.Forms.Button();
			this.companyBtn = new System.Windows.Forms.Button();
			this.locationsBtn = new System.Windows.Forms.Button();
			this.countryBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.contBtn = new System.Windows.Forms.Button();
			this.poBtn = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.groupBox2.Controls.Add(this.itemsBtn);
			this.groupBox2.Controls.Add(this.companyBtn);
			this.groupBox2.Controls.Add(this.locationsBtn);
			this.groupBox2.Controls.Add(this.countryBtn);
			this.groupBox2.Location = new System.Drawing.Point(8, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 88);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Maintenance Forms";
			// 
			// itemsBtn
			// 
			this.itemsBtn.BackColor = System.Drawing.Color.Lime;
			this.itemsBtn.Location = new System.Drawing.Point(88, 56);
			this.itemsBtn.Name = "itemsBtn";
			this.itemsBtn.TabIndex = 3;
			this.itemsBtn.Text = "Items";
			// 
			// companyBtn
			// 
			this.companyBtn.BackColor = System.Drawing.Color.Lime;
			this.companyBtn.Location = new System.Drawing.Point(88, 24);
			this.companyBtn.Name = "companyBtn";
			this.companyBtn.TabIndex = 2;
			this.companyBtn.Text = "Companies";
			// 
			// locationsBtn
			// 
			this.locationsBtn.BackColor = System.Drawing.Color.Lime;
			this.locationsBtn.Location = new System.Drawing.Point(8, 56);
			this.locationsBtn.Name = "locationsBtn";
			this.locationsBtn.TabIndex = 1;
			this.locationsBtn.Text = "Locations";
			// 
			// countryBtn
			// 
			this.countryBtn.BackColor = System.Drawing.Color.Lime;
			this.countryBtn.Location = new System.Drawing.Point(8, 24);
			this.countryBtn.Name = "countryBtn";
			this.countryBtn.TabIndex = 0;
			this.countryBtn.Text = "Countries";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.groupBox1.Controls.Add(this.contBtn);
			this.groupBox1.Controls.Add(this.poBtn);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(224, 64);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User forms";
			// 
			// contBtn
			// 
			this.contBtn.BackColor = System.Drawing.Color.Lime;
			this.contBtn.Location = new System.Drawing.Point(120, 24);
			this.contBtn.Name = "contBtn";
			this.contBtn.TabIndex = 2;
			this.contBtn.Text = "Containers";
			// 
			// poBtn
			// 
			this.poBtn.BackColor = System.Drawing.Color.Lime;
			this.poBtn.Location = new System.Drawing.Point(0, 24);
			this.poBtn.Name = "poBtn";
			this.poBtn.Size = new System.Drawing.Size(104, 23);
			this.poBtn.TabIndex = 1;
			this.poBtn.Text = "Purchase Orders";
			// 
			// Background
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 461);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Background";
			this.Text = "Background";
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
