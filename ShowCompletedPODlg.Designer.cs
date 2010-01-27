namespace EM
{
    partial class ShowCompletedPODlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.poTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.percentEdt = new System.Windows.Forms.TextBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.constraintsEdt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // poTreeView
            // 
            this.poTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poTreeView.Location = new System.Drawing.Point(0, 200);
            this.poTreeView.Name = "poTreeView";
            this.poTreeView.Size = new System.Drawing.Size(778, 275);
            this.poTreeView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Percent Completed";
            // 
            // percentEdt
            // 
            this.percentEdt.Location = new System.Drawing.Point(125, 156);
            this.percentEdt.Name = "percentEdt";
            this.percentEdt.Size = new System.Drawing.Size(100, 20);
            this.percentEdt.TabIndex = 3;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(252, 156);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 4;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(691, 153);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(75, 29);
            this.btnJump.TabIndex = 5;
            this.btnJump.Text = "Jump To PO";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // constraintsEdt
            // 
            this.constraintsEdt.Location = new System.Drawing.Point(0, 0);
            this.constraintsEdt.Multiline = true;
            this.constraintsEdt.Name = "constraintsEdt";
            this.constraintsEdt.ReadOnly = true;
            this.constraintsEdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.constraintsEdt.Size = new System.Drawing.Size(766, 137);
            this.constraintsEdt.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.refreshBtn);
            this.panel1.Controls.Add(this.constraintsEdt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnJump);
            this.panel1.Controls.Add(this.percentEdt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 200);
            this.panel1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(397, 143);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(123, 41);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // ShowCompletedPODlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 475);
            this.Controls.Add(this.poTreeView);
            this.Controls.Add(this.panel1);
            this.Name = "ShowCompletedPODlg";
            this.Text = "ShowCompletedPODlg";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView poTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox percentEdt;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.TextBox constraintsEdt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
    }
}