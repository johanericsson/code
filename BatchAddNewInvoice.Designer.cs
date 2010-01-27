namespace EM
{
    partial class BatchAddNewInvoice
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
            this.yesBtn = new System.Windows.Forms.Button();
            this.noBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.emInvoiceNumberEdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bundleRowsView = new System.Windows.Forms.TreeView();
            this.showSelectedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // yesBtn
            // 
            this.yesBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.yesBtn.Location = new System.Drawing.Point(361, 487);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(75, 23);
            this.yesBtn.TabIndex = 2;
            this.yesBtn.Text = "Yes";
            this.yesBtn.UseVisualStyleBackColor = true;
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // noBtn
            // 
            this.noBtn.DialogResult = System.Windows.Forms.DialogResult.No;
            this.noBtn.Location = new System.Drawing.Point(442, 487);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(75, 23);
            this.noBtn.TabIndex = 3;
            this.noBtn.Text = "&No";
            this.noBtn.UseVisualStyleBackColor = true;
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "EM Invoice Number";
            // 
            // emInvoiceNumberEdt
            // 
            this.emInvoiceNumberEdt.Location = new System.Drawing.Point(162, 13);
            this.emInvoiceNumberEdt.Name = "emInvoiceNumberEdt";
            this.emInvoiceNumberEdt.Size = new System.Drawing.Size(100, 20);
            this.emInvoiceNumberEdt.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Warning: Clicking Yes will apply invoice # to all items listed above";
            // 
            // bundleRowsView
            // 
            this.bundleRowsView.Location = new System.Drawing.Point(7, 39);
            this.bundleRowsView.Name = "bundleRowsView";
            this.bundleRowsView.Size = new System.Drawing.Size(519, 415);
            this.bundleRowsView.TabIndex = 7;
            // 
            // showSelectedBtn
            // 
            this.showSelectedBtn.Location = new System.Drawing.Point(12, 460);
            this.showSelectedBtn.Name = "showSelectedBtn";
            this.showSelectedBtn.Size = new System.Drawing.Size(167, 23);
            this.showSelectedBtn.TabIndex = 8;
            this.showSelectedBtn.Text = "Show Selected Container Item";
            this.showSelectedBtn.UseVisualStyleBackColor = true;
            this.showSelectedBtn.Click += new System.EventHandler(this.showSelectedBtn_Click);
            // 
            // BatchAddNewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 522);
            this.Controls.Add(this.showSelectedBtn);
            this.Controls.Add(this.bundleRowsView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.emInvoiceNumberEdt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.yesBtn);
            this.Name = "BatchAddNewInvoice";
            this.Text = "Add EM Invoice Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesBtn;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emInvoiceNumberEdt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView bundleRowsView;
        private System.Windows.Forms.Button showSelectedBtn;
    }
}