namespace EM
{
    partial class CloseContainer
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
            this.applyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.viewOfNotCompletedPOs = new System.Windows.Forms.TreeView();
            this.listOfCompletedPOs = new System.Windows.Forms.TreeView();
            this.gotoPOClosedBtn = new System.Windows.Forms.Button();
            this.gotoContainerClosedBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.containerLbl = new System.Windows.Forms.Label();
            this.viewHeaderContainer = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.showDataAsRptButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dontClosePO = new System.Windows.Forms.Button();
            this.closePO = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(456, 8);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(195, 32);
            this.applyBtn.TabIndex = 0;
            this.applyBtn.Text = "Apply (close container and POs)";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "You are about to close container: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "The following POs will be closed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "The following POs will not be closed...";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(664, 8);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 32);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // viewOfNotCompletedPOs
            // 
            this.viewOfNotCompletedPOs.Location = new System.Drawing.Point(384, 24);
            this.viewOfNotCompletedPOs.Name = "viewOfNotCompletedPOs";
            this.viewOfNotCompletedPOs.Size = new System.Drawing.Size(360, 448);
            this.viewOfNotCompletedPOs.TabIndex = 6;
            // 
            // listOfCompletedPOs
            // 
            this.listOfCompletedPOs.Location = new System.Drawing.Point(8, 24);
            this.listOfCompletedPOs.Name = "listOfCompletedPOs";
            this.listOfCompletedPOs.Size = new System.Drawing.Size(344, 448);
            this.listOfCompletedPOs.TabIndex = 9;
            // 
            // gotoPOClosedBtn
            // 
            this.gotoPOClosedBtn.Location = new System.Drawing.Point(8, 480);
            this.gotoPOClosedBtn.Name = "gotoPOClosedBtn";
            this.gotoPOClosedBtn.Size = new System.Drawing.Size(75, 23);
            this.gotoPOClosedBtn.TabIndex = 10;
            this.gotoPOClosedBtn.Text = "View PO";
            this.gotoPOClosedBtn.UseVisualStyleBackColor = true;
            this.gotoPOClosedBtn.Click += new System.EventHandler(this.gotoPOBtn_Click);
            // 
            // gotoContainerClosedBtn
            // 
            this.gotoContainerClosedBtn.Location = new System.Drawing.Point(88, 480);
            this.gotoContainerClosedBtn.Name = "gotoContainerClosedBtn";
            this.gotoContainerClosedBtn.Size = new System.Drawing.Size(96, 23);
            this.gotoContainerClosedBtn.TabIndex = 11;
            this.gotoContainerClosedBtn.Text = "View Container";
            this.gotoContainerClosedBtn.UseVisualStyleBackColor = true;
            this.gotoContainerClosedBtn.Click += new System.EventHandler(this.gotoContainerBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(472, 480);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "View Container";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(392, 480);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "View PO";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // containerLbl
            // 
            this.containerLbl.AutoSize = true;
            this.containerLbl.Location = new System.Drawing.Point(184, 16);
            this.containerLbl.Name = "containerLbl";
            this.containerLbl.Size = new System.Drawing.Size(35, 13);
            this.containerLbl.TabIndex = 8;
            this.containerLbl.Text = "label4";
            // 
            // viewHeaderContainer
            // 
            this.viewHeaderContainer.Location = new System.Drawing.Point(304, 8);
            this.viewHeaderContainer.Name = "viewHeaderContainer";
            this.viewHeaderContainer.Size = new System.Drawing.Size(96, 23);
            this.viewHeaderContainer.TabIndex = 14;
            this.viewHeaderContainer.Text = "View Container";
            this.viewHeaderContainer.UseVisualStyleBackColor = true;
            this.viewHeaderContainer.Click += new System.EventHandler(this.viewHeaderContainer_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(656, 8);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(88, 23);
            this.refreshButton.TabIndex = 15;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.applyBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 560);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 50);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.showDataAsRptButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.refreshButton);
            this.panel2.Controls.Add(this.containerLbl);
            this.panel2.Controls.Add(this.viewHeaderContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 44);
            this.panel2.TabIndex = 17;
            // 
            // showDataAsRptButton
            // 
            this.showDataAsRptButton.Location = new System.Drawing.Point(472, 8);
            this.showDataAsRptButton.Name = "showDataAsRptButton";
            this.showDataAsRptButton.Size = new System.Drawing.Size(136, 23);
            this.showDataAsRptButton.TabIndex = 16;
            this.showDataAsRptButton.Text = "Show Data as report...";
            this.showDataAsRptButton.UseVisualStyleBackColor = true;
            this.showDataAsRptButton.Click += new System.EventHandler(this.showDataAsReport);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.closePO);
            this.panel3.Controls.Add(this.dontClosePO);
            this.panel3.Controls.Add(this.viewOfNotCompletedPOs);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.listOfCompletedPOs);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.gotoPOClosedBtn);
            this.panel3.Controls.Add(this.gotoContainerClosedBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(756, 516);
            this.panel3.TabIndex = 18;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // dontClosePO
            // 
            this.dontClosePO.Location = new System.Drawing.Point(190, 480);
            this.dontClosePO.Name = "dontClosePO";
            this.dontClosePO.Size = new System.Drawing.Size(100, 23);
            this.dontClosePO.TabIndex = 14;
            this.dontClosePO.Text = "Don\'t Close PO";
            this.dontClosePO.UseVisualStyleBackColor = true;
            this.dontClosePO.Click += new System.EventHandler(this.dontClosePO_Click);
            // 
            // closePO
            // 
            this.closePO.Location = new System.Drawing.Point(574, 480);
            this.closePO.Name = "closePO";
            this.closePO.Size = new System.Drawing.Size(100, 23);
            this.closePO.TabIndex = 15;
            this.closePO.Text = "Close PO";
            this.closePO.UseVisualStyleBackColor = true;
            this.closePO.Click += new System.EventHandler(this.closePO_Click);
            // 
            // CloseContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 610);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CloseContainer";
            this.Text = "CloseContainer";
            this.Load += new System.EventHandler(this.CloseContainer_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TreeView viewOfNotCompletedPOs;
        private System.Windows.Forms.TreeView listOfCompletedPOs;
        private System.Windows.Forms.Button gotoPOClosedBtn;
        private System.Windows.Forms.Button gotoContainerClosedBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label containerLbl;
        private System.Windows.Forms.Button viewHeaderContainer;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button showDataAsRptButton;
        private System.Windows.Forms.Button closePO;
        private System.Windows.Forms.Button dontClosePO;
    }
}