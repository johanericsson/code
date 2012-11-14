namespace EM
{
    partial class InvoiceSupportForm
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
            this.finishGridView = new System.Windows.Forms.DataGridView();
            this.FinishColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommissionRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surchargeGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConvert = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.CustomerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishColumnSurcharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurchargeRateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurchargeDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.finishGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surchargeGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // finishGridView
            // 
            this.finishGridView.AllowUserToAddRows = false;
            this.finishGridView.AllowUserToDeleteRows = false;
            this.finishGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finishGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FinishColumn,
            this.CommissionRate});
            this.finishGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.finishGridView.Location = new System.Drawing.Point(0, 0);
            this.finishGridView.Margin = new System.Windows.Forms.Padding(2);
            this.finishGridView.Name = "finishGridView";
            this.finishGridView.RowTemplate.Height = 29;
            this.finishGridView.Size = new System.Drawing.Size(210, 363);
            this.finishGridView.TabIndex = 0;
            // 
            // FinishColumn
            // 
            this.FinishColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FinishColumn.FillWeight = 10F;
            this.FinishColumn.HeaderText = "Finish";
            this.FinishColumn.Name = "FinishColumn";
            this.FinishColumn.ReadOnly = true;
            this.FinishColumn.Width = 59;
            // 
            // CommissionRate
            // 
            this.CommissionRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CommissionRate.FillWeight = 10F;
            this.CommissionRate.HeaderText = "Rate";
            this.CommissionRate.Name = "CommissionRate";
            this.CommissionRate.Width = 55;
            // 
            // surchargeGridView
            // 
            this.surchargeGridView.AllowUserToAddRows = false;
            this.surchargeGridView.AllowUserToDeleteRows = false;
            this.surchargeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surchargeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerColumn,
            this.FinishColumnSurcharge,
            this.GradeColumn,
            this.SurchargeRateColumn,
            this.SurchargeDateColumn});
            this.surchargeGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surchargeGridView.Location = new System.Drawing.Point(210, 0);
            this.surchargeGridView.Margin = new System.Windows.Forms.Padding(2);
            this.surchargeGridView.Name = "surchargeGridView";
            this.surchargeGridView.RowTemplate.Height = 29;
            this.surchargeGridView.Size = new System.Drawing.Size(736, 363);
            this.surchargeGridView.TabIndex = 2;
            this.surchargeGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.surchargeGridView_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConvert);
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 363);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 65);
            this.panel1.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConvert.Location = new System.Drawing.Point(439, 16);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(2);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(68, 33);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Visible = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(98, 13);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(68, 33);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(14, 13);
            this.okBtn.Margin = new System.Windows.Forms.Padding(2);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(68, 33);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // CustomerColumn
            // 
            this.CustomerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerColumn.FillWeight = 10F;
            this.CustomerColumn.Frozen = true;
            this.CustomerColumn.HeaderText = "Customer";
            this.CustomerColumn.Name = "CustomerColumn";
            this.CustomerColumn.ReadOnly = true;
            this.CustomerColumn.Width = 76;
            // 
            // FinishColumnSurcharge
            // 
            this.FinishColumnSurcharge.HeaderText = "Finish";
            this.FinishColumnSurcharge.Name = "FinishColumnSurcharge";
            this.FinishColumnSurcharge.ReadOnly = true;
            // 
            // GradeColumn
            // 
            this.GradeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GradeColumn.FillWeight = 10F;
            this.GradeColumn.HeaderText = "Grade";
            this.GradeColumn.Name = "GradeColumn";
            this.GradeColumn.ReadOnly = true;
            this.GradeColumn.Width = 61;
            // 
            // SurchargeRateColumn
            // 
            this.SurchargeRateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SurchargeRateColumn.FillWeight = 150F;
            this.SurchargeRateColumn.HeaderText = "Surcharge Rate ($/100lbs)";
            this.SurchargeRateColumn.Name = "SurchargeRateColumn";
            this.SurchargeRateColumn.Width = 144;
            // 
            // SurchargeDateColumn
            // 
            this.SurchargeDateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SurchargeDateColumn.FillWeight = 10F;
            this.SurchargeDateColumn.HeaderText = "SurchargeDate";
            this.SurchargeDateColumn.Name = "SurchargeDateColumn";
            this.SurchargeDateColumn.ReadOnly = true;
            this.SurchargeDateColumn.Width = 104;
            // 
            // InvoiceSupportForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(946, 428);
            this.Controls.Add(this.surchargeGridView);
            this.Controls.Add(this.finishGridView);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InvoiceSupportForm";
            this.Text = "Commissions and Surcharges";
            ((System.ComponentModel.ISupportInitialize)(this.finishGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surchargeGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView finishGridView;
        private System.Windows.Forms.DataGridView surchargeGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommissionRate;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishColumnSurcharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurchargeRateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurchargeDateColumn;
    }
}