namespace EM
{
    partial class CurrencyFiller
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
            this.currencyGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.currencyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.currencyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // currencyGrid
            // 
            this.currencyGrid.AllowUserToAddRows = false;
            this.currencyGrid.AllowUserToDeleteRows = false;
            this.currencyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currencyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.currencyColumn,
            this.rateColumn});
            this.currencyGrid.Location = new System.Drawing.Point(0, 0);
            this.currencyGrid.Name = "currencyGrid";
            this.currencyGrid.Size = new System.Drawing.Size(495, 260);
            this.currencyGrid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(411, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(330, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // currencyColumn
            // 
            this.currencyColumn.HeaderText = "Currency";
            this.currencyColumn.Name = "currencyColumn";
            // 
            // rateColumn
            // 
            this.rateColumn.HeaderText = "$/currency";
            this.rateColumn.Name = "rateColumn";
            // 
            // CurrencyFiller
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(498, 311);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currencyGrid);
            this.Name = "CurrencyFiller";
            this.Text = "CurrencyFiller";
            ((System.ComponentModel.ISupportInitialize)(this.currencyGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView currencyGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateColumn;
    }
}