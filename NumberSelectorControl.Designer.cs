namespace EM
{
    partial class NumberSelectorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.invoiceNumberEdt = new EM.AutoCompleteTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.invoiceStatusCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editBtn);
            this.groupBox1.Controls.Add(this.invoiceNumberEdt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.invoiceStatusCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Title here";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // invoiceNumberEdt
            // 
            this.invoiceNumberEdt.Enabled = false;
            this.invoiceNumberEdt.Location = new System.Drawing.Point(91, 47);
            this.invoiceNumberEdt.Name = "invoiceNumberEdt";
            this.invoiceNumberEdt.Size = new System.Drawing.Size(121, 20);
            this.invoiceNumberEdt.TabIndex = 3;
            this.invoiceNumberEdt.Text = "All";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Invoice Number:";
            // 
            // invoiceStatusCombo
            // 
            this.invoiceStatusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.invoiceStatusCombo.FormattingEnabled = true;
            this.invoiceStatusCombo.Items.AddRange(new object[] {
            "All",
            "Not Invoiced",
            "Invoiced"});
            this.invoiceStatusCombo.Location = new System.Drawing.Point(91, 18);
            this.invoiceStatusCombo.Name = "invoiceStatusCombo";
            this.invoiceStatusCombo.Size = new System.Drawing.Size(121, 21);
            this.invoiceStatusCombo.TabIndex = 1;
            this.invoiceStatusCombo.SelectedIndexChanged += new System.EventHandler(this.OnStatusChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Status:";
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(218, 45);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(54, 23);
            this.editBtn.TabIndex = 4;
            this.editBtn.Text = "Edit...";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // NumberSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "NumberSelectorControl";
            this.Size = new System.Drawing.Size(289, 93);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox invoiceStatusCombo;
        private System.Windows.Forms.Label label1;
        private EM.AutoCompleteTextBox invoiceNumberEdt;
        private System.Windows.Forms.Button editBtn;
    }
}
