using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using System.IO;

namespace EM
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainWindow : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem Exit;
        private System.Windows.Forms.MenuItem fileMenu;
        private System.Windows.Forms.MenuItem formMenu;
        private System.Windows.Forms.MenuItem purchaseOrder;
        private System.Windows.Forms.ImageList toolbarImages;
        private System.Windows.Forms.MenuItem closeMenu;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton addBtn;
        private System.Windows.Forms.ToolBarButton deleteBtn;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton previousBtn;
        private System.Windows.Forms.ToolBarButton nextBtn;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton updateBtn;
        private System.Windows.Forms.ToolBarButton cancelBtn;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuAdd;
        private System.Windows.Forms.MenuItem menuDelete;
        private System.Windows.Forms.MenuItem menuPrevious;
        private System.Windows.Forms.MenuItem menuNext;
        private System.Windows.Forms.MenuItem menuSave;
        private System.Windows.Forms.MenuItem menuCancel;
        private System.Windows.Forms.MenuItem containerMenu;
        private System.Windows.Forms.ToolBarButton findBtn;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem monthlySalesMenu;
        private System.Windows.Forms.MenuItem monthlySalesCustomer;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem orderLogMenu;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem promiseReportMenu;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem15;
        private MenuItem menuItem16;
        private MenuItem etaReport;
        private MenuItem sizeGradeItem;
        private MenuItem menuItem17;
        private MenuItem monthlyExcel;
        private MenuItem completedPOs;
        private MenuItem newInvoiceReportMenu;
        private MenuItem menuItem12;
        private MenuItem menuItem18;
        private MenuItem menuItem19;
        private MenuItem menuItem20;
        private MenuItem menuItem21;
        private System.ComponentModel.IContainer components;

        public MainWindow()
        {
            this.IsMdiContainer = true;
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.CreatePOForm(0);
            g_this = this;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenu = new System.Windows.Forms.MenuItem();
            this.closeMenu = new System.Windows.Forms.MenuItem();
            this.Exit = new System.Windows.Forms.MenuItem();
            this.formMenu = new System.Windows.Forms.MenuItem();
            this.purchaseOrder = new System.Windows.Forms.MenuItem();
            this.containerMenu = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuAdd = new System.Windows.Forms.MenuItem();
            this.menuDelete = new System.Windows.Forms.MenuItem();
            this.menuPrevious = new System.Windows.Forms.MenuItem();
            this.menuNext = new System.Windows.Forms.MenuItem();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuCancel = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.monthlySalesMenu = new System.Windows.Forms.MenuItem();
            this.monthlySalesCustomer = new System.Windows.Forms.MenuItem();
            this.monthlyExcel = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.newInvoiceReportMenu = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.orderLogMenu = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.promiseReportMenu = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.sizeGradeItem = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.etaReport = new System.Windows.Forms.MenuItem();
            this.completedPOs = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.toolbarImages = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.addBtn = new System.Windows.Forms.ToolBarButton();
            this.deleteBtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.findBtn = new System.Windows.Forms.ToolBarButton();
            this.previousBtn = new System.Windows.Forms.ToolBarButton();
            this.nextBtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.updateBtn = new System.Windows.Forms.ToolBarButton();
            this.cancelBtn = new System.Windows.Forms.ToolBarButton();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenu,
            this.formMenu,
            this.menuItem2,
            this.menuItem8,
            this.menuItem3,
            this.menuItem13});
            // 
            // fileMenu
            // 
            this.fileMenu.Index = 0;
            this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.closeMenu,
            this.Exit});
            this.fileMenu.Text = "&File";
            // 
            // closeMenu
            // 
            this.closeMenu.Index = 0;
            this.closeMenu.Text = "&Close";
            this.closeMenu.Click += new System.EventHandler(this.closeMenu_Click);
            // 
            // Exit
            // 
            this.Exit.Index = 1;
            this.Exit.Text = "E&xit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // formMenu
            // 
            this.formMenu.Index = 1;
            this.formMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.purchaseOrder,
            this.containerMenu});
            this.formMenu.Text = "&Entry Forms";
            // 
            // purchaseOrder
            // 
            this.purchaseOrder.Index = 0;
            this.purchaseOrder.Text = "&Purchase Order";
            this.purchaseOrder.Click += new System.EventHandler(this.purchaseOrder_Click);
            // 
            // containerMenu
            // 
            this.containerMenu.Index = 1;
            this.containerMenu.Text = "&Container";
            this.containerMenu.Click += new System.EventHandler(this.containerMenu_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem1});
            this.menuItem2.Text = "&Maintenance";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "&Countries";
            this.menuItem4.Click += new System.EventHandler(this.countriesMenu_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "C&ompanies";
            this.menuItem5.Click += new System.EventHandler(this.companyMenu_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "&Locations";
            this.menuItem6.Click += new System.EventHandler(this.locationEdit_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 3;
            this.menuItem7.Text = "&Items";
            this.menuItem7.Click += new System.EventHandler(this.itemsMenu_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "Contacts";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAdd,
            this.menuDelete,
            this.menuPrevious,
            this.menuNext,
            this.menuSave,
            this.menuCancel});
            this.menuItem8.Text = "&Navigation";
            // 
            // menuAdd
            // 
            this.menuAdd.Index = 0;
            this.menuAdd.Text = "&Add";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Index = 1;
            this.menuDelete.Text = "&Delete";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuPrevious
            // 
            this.menuPrevious.Index = 2;
            this.menuPrevious.Text = "&Previous";
            this.menuPrevious.Click += new System.EventHandler(this.menuPrevious_Click);
            // 
            // menuNext
            // 
            this.menuNext.Index = 3;
            this.menuNext.Text = "&Next";
            this.menuNext.Click += new System.EventHandler(this.menuNext_Click);
            // 
            // menuSave
            // 
            this.menuSave.Index = 4;
            this.menuSave.Text = "&Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuCancel
            // 
            this.menuCancel.Index = 5;
            this.menuCancel.Text = "&Cancel";
            this.menuCancel.Click += new System.EventHandler(this.menuCancel_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.monthlySalesMenu,
            this.monthlySalesCustomer,
            this.monthlyExcel,
            this.menuItem9,
            this.newInvoiceReportMenu,
            this.menuItem12,
            this.menuItem21,
            this.menuItem10,
            this.orderLogMenu,
            this.menuItem11,
            this.promiseReportMenu,
            this.menuItem16,
            this.sizeGradeItem,
            this.menuItem17,
            this.etaReport,
            this.completedPOs,
            this.menuItem18,
            this.menuItem19,
            this.menuItem20});
            this.menuItem3.Text = "&Reports";
            // 
            // monthlySalesMenu
            // 
            this.monthlySalesMenu.Index = 0;
            this.monthlySalesMenu.Text = "&Monthly Sales by Mill";
            this.monthlySalesMenu.Click += new System.EventHandler(this.monthlySalesMenu_Click);
            // 
            // monthlySalesCustomer
            // 
            this.monthlySalesCustomer.Index = 1;
            this.monthlySalesCustomer.Text = "Monthly Sales by &Customer";
            this.monthlySalesCustomer.Click += new System.EventHandler(this.monthlySalesCustomer_Click);
            // 
            // monthlyExcel
            // 
            this.monthlyExcel.Index = 2;
            this.monthlyExcel.Text = "Sales in Excel";
            this.monthlyExcel.Click += new System.EventHandler(this.monthlyExcel_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "-";
            // 
            // newInvoiceReportMenu
            // 
            this.newInvoiceReportMenu.Index = 4;
            this.newInvoiceReportMenu.Text = "New Invoice Report";
            this.newInvoiceReportMenu.Click += new System.EventHandler(this.newInvoiceReportMenu_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 5;
            this.menuItem12.Text = "New Invoice Report - Fully Itemized";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click_2);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 7;
            this.menuItem10.Text = "-";
            // 
            // orderLogMenu
            // 
            this.orderLogMenu.Index = 8;
            this.orderLogMenu.Text = "Order Log";
            this.orderLogMenu.Click += new System.EventHandler(this.orderLogMenu_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 9;
            this.menuItem11.Text = "-";
            // 
            // promiseReportMenu
            // 
            this.promiseReportMenu.Index = 10;
            this.promiseReportMenu.Text = "Promise Report";
            this.promiseReportMenu.Click += new System.EventHandler(this.promiseReportMenu_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 11;
            this.menuItem16.Text = "-";
            // 
            // sizeGradeItem
            // 
            this.sizeGradeItem.Index = 12;
            this.sizeGradeItem.Text = "SizeGrade Report";
            this.sizeGradeItem.Click += new System.EventHandler(this.sizeGradeItem_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 13;
            this.menuItem17.Text = "-";
            // 
            // etaReport
            // 
            this.etaReport.Index = 14;
            this.etaReport.Text = "ETA Report";
            this.etaReport.Click += new System.EventHandler(this.etaReport_Click);
            // 
            // completedPOs
            // 
            this.completedPOs.Index = 15;
            this.completedPOs.Text = "Completed POs";
            this.completedPOs.Click += new System.EventHandler(this.completedPOs_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 16;
            this.menuItem18.Text = "-";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 17;
            this.menuItem19.Text = "Orders";
            this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 5;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuItem15});
            this.menuItem13.Text = "E&xport All Data To Excel";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 0;
            this.menuItem14.Text = "From &PO";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "From &Container";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // toolbarImages
            // 
            this.toolbarImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.toolbarImages.ImageSize = new System.Drawing.Size(16, 16);
            this.toolbarImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolBar1
            // 
            this.toolBar1.BackColor = System.Drawing.SystemColors.Window;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.addBtn,
            this.deleteBtn,
            this.toolBarButton2,
            this.findBtn,
            this.previousBtn,
            this.nextBtn,
            this.toolBarButton1,
            this.updateBtn,
            this.cancelBtn});
            this.toolBar1.ButtonSize = new System.Drawing.Size(62, 36);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.toolbarImages;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(968, 42);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // addBtn
            // 
            this.addBtn.Name = "addBtn";
            this.addBtn.Text = "New";
            this.addBtn.ToolTipText = "New";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.ToolTipText = "Delete";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // findBtn
            // 
            this.findBtn.Name = "findBtn";
            this.findBtn.Text = "Find...";
            this.findBtn.ToolTipText = "Find...";
            // 
            // previousBtn
            // 
            this.previousBtn.Name = "previousBtn";
            this.previousBtn.Text = "Previous";
            // 
            // nextBtn
            // 
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Text = "Next";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // updateBtn
            // 
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Text = "Save";
            this.updateBtn.ToolTipText = "Update";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Text = "Revert";
            this.cancelBtn.ToolTipText = "Revert to last save";
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 18;
            this.menuItem20.Text = "-";
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 6;
            this.menuItem21.Text = "PO Items not in containers";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(968, 641);
            this.Controls.Add(this.toolBar1);
            this.Menu = this.mainMenu1;
            this.Name = "MainWindow";
            this.Text = "EricssonMetals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainWindow window = new MainWindow();
            Application.Idle += new EventHandler(window.OnIdle);
            Application.Run(window);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4) // Find
            {
                IToolbarInterface i = m_activeForm as IToolbarInterface;
                if (i != null)
                {
                    i.OnFind();
                    return true; // handled
                }
            }
            if (keyData == (Keys.Control | Keys.F))
            {
                IToolbarInterface i = m_activeForm as IToolbarInterface;
                if (i != null)
                {
                    i.OnFind();
                    return true; // handled
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void OnIdle(object o, EventArgs args)
        {
            IToolbarInterface form = null;
            if (m_activeForm != null)
                form = m_activeForm as IToolbarInterface;
            if (form == null)
            {
                addBtn.Enabled = false;
                deleteBtn.Enabled = false;
                cancelBtn.Enabled = false;
                nextBtn.Enabled = false;
                previousBtn.Enabled = false;
                updateBtn.Enabled = false;
                findBtn.Enabled = false;
            }
            else
            {
                addBtn.Enabled = form.OnUpdateAdd();
                deleteBtn.Enabled = form.OnUpdateDelete();
                cancelBtn.Enabled = form.OnUpdateCancel();
                nextBtn.Enabled = form.OnUpdateNext();
                previousBtn.Enabled = form.OnUpdatePrevious();
                updateBtn.Enabled = form.OnUpdateUpdate();
                findBtn.Enabled = form.OnUpdateFind();
            }
        }
        private void Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();

        }

        Form m_activeForm;
        private void purchaseOrder_Click(object sender, System.EventArgs e)
        {
            CreatePOForm(0);
        }

        static public MainWindow g_this;
        public void CreatePOForm(int poid)
        {
            CreatePOForm(poid, 0, 0, 0);
        }
        public void CreatePOForm(int poid, int poItemNumber, int contID, int bundleIDNumber)
        {
            try
            {
                if (!PreCreation())
                    return;
                PO f = new PO(poid, poItemNumber, contID, bundleIDNumber);
                FinishCreation(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ShowPOForm(int poid)
        {
            g_this.CreatePOForm(poid);
        }
        public static void ShowContainerForm(int contid)
        {
            ShowContainerForm(contid, 0);
        }
        public static void ShowContainerForm(int contid, int contBundleID)
        {
            g_this.CreateContainerForm(contid, contBundleID);
        }

        public void CreateContainerForm(int contID)
        {
            CreateContainerForm(contID, 0);

        }
        public void CreateContainerForm(int contID, int contBundleID)
        {
            try
            {
                if (!PreCreation())
                    return;
                Form f = new ContainerItem(contID, contBundleID);
                FinishCreation(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool PreCreation()
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                return i.CheckForDirty();
            }
            return true;
        }
        void FinishCreation(Form f)
        {
            if (m_activeForm != null)
                m_activeForm.Close();
            m_activeForm = f;
            m_activeForm.MdiParent = this;
            m_activeForm.Closed += new EventHandler(ActiveFormClosed);
            m_activeForm.Show();
            m_activeForm.WindowState = FormWindowState.Maximized;
        }

        void ActiveFormClosed(object sender, EventArgs e)
        {
            m_activeForm = null;
        }

        private void containers_Click(object sender, System.EventArgs e)
        {
            CreateContainerForm(0);
        }

        private void countriesMenu_Click(object sender, System.EventArgs e)
        {
            ShowForm(typeof(CountryForm));

        }
        private void companyMenu_Click(object sender, System.EventArgs e)
        {
            ShowForm(typeof(CompanyForm));
        }

        private void locationEdit_Click(object sender, System.EventArgs e)
        {
            ShowForm(typeof(LocationForm));
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                if (e.Button == addBtn)
                    i.OnAdd();
                else if (e.Button == deleteBtn)
                    i.OnDelete();
                else if (e.Button == cancelBtn)
                    i.OnCancel();
                else if (e.Button == nextBtn)
                    i.OnNext();
                else if (e.Button == previousBtn)
                    i.OnPrevious();
                else if (e.Button == updateBtn)
                    i.OnUpdate();
                else if (e.Button == findBtn)
                    i.OnFind();
            }
        }

        private void itemsMenu_Click(object sender, System.EventArgs e)
        {
            ShowForm(typeof(ItemForm));
        }
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            ShowForm(typeof(Contacts));

        }

        private void containerMenu_Click(object sender, System.EventArgs e)
        {
            CreateContainerForm(0);
        }

        private void ShowForm(Type t)
        {
            try
            {
                System.Reflection.ConstructorInfo cInfo = t.GetConstructor(new Type[0]);
                Form f = (Form)cInfo.Invoke(new object[0]);
                FinishCreation(f);
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                MessageBox.Show(e.InnerException.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void refreshMenuItem_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;
            if (i != null)
                i.OnRefresh();
        }

        private void closeMenu_Click(object sender, System.EventArgs e)
        {
            if (m_activeForm != null)
            {
                m_activeForm.Close();
                m_activeForm = null;
            }
        }

        private void addMenu_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
                i.OnAdd();

        }

        private void updateMenu_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
                i.OnUpdate();

        }

        private void previousMenu_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;
            if (i != null)
                i.OnPrevious();
        }

        private void nextMenu_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;
            if (i != null)
                i.OnNext();
        }

        private void updateMen_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;
            if (i != null)
                i.OnUpdate();
        }

        private void cancelMenu_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;
            if (i != null)
                i.OnCancel();
        }

        private void poBtn_Click(object sender, System.EventArgs e)
        {
            purchaseOrder_Click(sender, e);
        }

        private void contBtn_Click(object sender, System.EventArgs e)
        {
            containers_Click(sender, e);
        }

        private void countryBtn_Click(object sender, System.EventArgs e)
        {
            countriesMenu_Click(sender, e);
        }

        private void companyBtn_Click(object sender, System.EventArgs e)
        {
            companyMenu_Click(sender, e);
        }

        private void locationsBtn_Click(object sender, System.EventArgs e)
        {
            locationEdit_Click(sender, e);
        }

        private void itemsBtn_Click(object sender, System.EventArgs e)
        {
            itemsMenu_Click(sender, e);
        }

        private void menuAdd_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                i.OnAdd();
            }
        }

        private void menuDelete_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                i.OnDelete();
            }
        }

        private void menuPrevious_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                i.OnPrevious();
            }
        }

        private void menuNext_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                i.OnNext();
            }
        }

        private void menuSave_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                i.OnUpdate();
            }
        }

        private void menuCancel_Click(object sender, System.EventArgs e)
        {
            IToolbarInterface i = m_activeForm as IToolbarInterface;

            if (i != null)
            {
                i.OnCancel();
            }
        }

        private void monthlySalesMenu_Click(object sender, System.EventArgs e)
        {
            ShowCrystalReport(new SalesReports(), "Monthly Sales");
        }

        private string AddMaybeConstraints(string inConstraints, string maybeConstraints)
        {
            if (maybeConstraints != "")
            {
                if (inConstraints != "")
                {
                    inConstraints += " AND ";
                }
                else
                {
                    inConstraints += " WHERE ";
                }
                // need to remove WHERE from maybeConstraintsAsStr
                int index = maybeConstraints.IndexOf("WHERE");
                maybeConstraints = maybeConstraints.Remove(index, 5);
                inConstraints += " (MillConfirmationAppliesToEntirePO = 0 OR " +
                "(MillConfirmationAppliesToEntirePO = 1 AND " +
                                         maybeConstraints + "))";
            }
            return inConstraints;
        }
        private void CreateLimitedViewOfDataSet(out EMDataSet dataSet, out string friendlyConstraints)
        {
            dataSet = null;
            friendlyConstraints = null;
            ReportDialog dlg = new ReportDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            ArrayList constraints = dlg.GetPOHeaderConstraints();
            friendlyConstraints = dlg.GetFriendlyConstraints();
            ArrayList maybeConstraints = dlg.GetMaybePOHeaderConstraints(); // sometimes applies per item

            //, sometimes for entire PO.
            string constraintsAsStr = DataInterface.TranslateToConstraint(constraints);
            string maybeConstraintsAsStr = DataInterface.TranslateToConstraint(maybeConstraints);
            constraintsAsStr = AddMaybeConstraints(constraintsAsStr, maybeConstraintsAsStr);
            dataSet = new EMDataSet();
            using (new OpenConnection(EM.IsWrite.No, AdapterHelper.Connection))
            using (new TurnOffConstraints(dataSet))
            {
                AdapterHelper.FillCurrency(dataSet);
                AdapterHelper.FillAllPOHeaders(dataSet, constraintsAsStr);
                foreach (EMDataSet.POHeaderTblRow poRow in dataSet.POHeaderTbl)
                {
                    ArrayList poItemconstraints = new ArrayList();
                    string constraint = "POID = " + poRow.POID.ToString();
                    poItemconstraints.Add(constraint);
                    constraint = "CancelDate IS NULL";
                    poItemconstraints.Add(constraint);
                    ArrayList orConstraints;
                    ArrayList constraints2 = dlg.GetPOItemConstraints(out orConstraints);
                    poItemconstraints.InsertRange(0, constraints2);
                    if (poRow.MillConfirmationAppliesToEntirePO == 0)
                    {
                        poItemconstraints.InsertRange(0, maybeConstraints);
                    }
                    constraint = DataInterface.TranslateToConstraint(poItemconstraints, orConstraints);
                    AdapterHelper.FillPOItemsWithConstraints(dataSet, constraint);
                }
                AdapterHelper.FillOutConstraints(dataSet);
            }
            AddAuxiliaryFieldInfo(dataSet);

        }

        private void AddAuxiliaryFieldInfo(EMDataSet dataSet)
        {
            foreach (EMDataSet.POHeaderTblRow poRow in dataSet.POHeaderTbl)
            {
                if (!poRow.IsMillIDNull())
                {
                    EMDataSet.CompanyTblRow compRow =
                        dataSet.CompanyTbl.FindByCompID(poRow.MillID);
                    if (compRow.IsCompNameAbbreviationNull())
                        poRow.VendEMail = compRow.CompName;
                    else
                        poRow.VendEMail = compRow.CompNameAbbreviation;
                }
                if (!poRow.IsCustomerIDNull())
                {
                    poRow.ShipToEMail = dataSet.CompanyTbl.FindByCompID(poRow.CustomerID).CompName;
                }
            }
            // Fill out the treatment + grade + itemname so that we don't need
            // to do it in Crystal Report code. There has been a problem with the
            // crystal report code
            foreach (EMDataSet.POItemTblRow itemRow in dataSet.POItemTbl)
            {
                itemRow.ItemNameObsolete = HelperFunctions.GetItemName(itemRow);
            }
        }
        private void etaReport_Click(object sender, EventArgs e)
        {
            try
            {
                string friendlyConstraints;
                
                EMDataSet dataSet = CreateContainerViewOfDataSet(out friendlyConstraints);
                GenericCrystalViewer v = new GenericCrystalViewer();
                v.Text = "ETA Report";

                ParameterFields fields = new ParameterFields();
                ParameterField field = new ParameterField();
                field.ParameterFieldName = "reportDescription";
                ParameterDiscreteValue discrete = new ParameterDiscreteValue();
                discrete.Value = friendlyConstraints;
                field.CurrentValues.Add(discrete);
                fields.Add(field);
                v.viewer.ParameterFieldInfo = fields;
                ContETAReport report = new ContETAReport();
                report.SetDataSource(dataSet);
                v.viewer.ReportSource = report;
                v.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private EMDataSet CreateContainerViewOfDataSet(out string friendlyConstraints)
        {
            EMDataSet dataSet = null;
            friendlyConstraints = null;
            ContainerReportDialog dlg = new ContainerReportDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
                return null;
            string constraints = dlg.GetPOHeaderConstraints();
            friendlyConstraints = dlg.GetFriendlyConstraints();
            dataSet = new EMDataSet();
            dataSet.EnforceConstraints = false;
            using (new OpenConnection(EM.IsWrite.No, AdapterHelper.Connection))
            {
                ArrayList listOfCompIDs = new ArrayList();
                ArrayList listOfLocIDs = new ArrayList();
                AdapterHelper.FillAllContHeaders(dataSet, constraints);
                foreach (EMDataSet.ContainerTblRow row in dataSet.ContainerTbl
                    .Rows)
                {
                    ArrayList itemConstraints = dlg.GetItemConstraints();
                    string contIDConstraint = "ContID = " + row.ContID.ToString();
                    itemConstraints.Insert(0, contIDConstraint);
                    AdapterHelper.FillContBundles(dataSet,
                        DataInterface.TranslateToConstraint(itemConstraints));
                    if (!row.IsCustomerIDNull())
                        listOfCompIDs.Add(row.CustomerID);
                    if (!row.IsCustomerLocationIDNull())
                        listOfLocIDs.Add(row.CustomerLocationID);
                }
                AdapterHelper.Unique(ref listOfCompIDs);
                AdapterHelper.Unique(ref listOfLocIDs);
                foreach (int compID in listOfCompIDs)
                {
                    AdapterHelper.FillCompanyFromCompID(dataSet, compID);
                }
                foreach (int locID in listOfLocIDs)
                {
                    AdapterHelper.FillLocationFromLocationID(dataSet, locID);
                }
            }

            return dataSet;
        }

        private bool CheckForDirty()
        {
            try
            {
                IToolbarInterface i = m_activeForm as IToolbarInterface;
                if (i == null)
                    return true;
                return i.CheckForDirty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void ShowCrystalReport(EMDataSet dataSet, ReportClass report, string reportName,
            string friendlyConstraints)
        {
            GenericCrystalViewer v = new GenericCrystalViewer();
            v.Text = reportName;

            ParameterFields fields = new ParameterFields();
            ParameterField field = new ParameterField();
            field.ParameterFieldName = "reportDescription";
            ParameterDiscreteValue discrete = new ParameterDiscreteValue();
            discrete.Value = friendlyConstraints;
            field.CurrentValues.Add(discrete);
            fields.Add(field);
            v.viewer.ParameterFieldInfo = fields;

            report.SetDataSource(dataSet);
            v.viewer.ReportSource = report;
            v.Show();
        }
        private EMDataSet ShowCrystalReport(ReportClass report, string reportName)
        {
            try
            {
                if (!CheckForDirty())
                    return null;
                EMDataSet dataSet;
                string friendlyConstraints;
                CreateLimitedViewOfDataSet(out dataSet, out friendlyConstraints);
                if (dataSet == null)
                    return null;
                ShowCrystalReport(dataSet, report, reportName, friendlyConstraints);
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        List<EMDataSet.POHeaderTblRow> GetPOsNotYetInvoiced(EMDataSet emDataSet)
        {
            List<EMDataSet.POHeaderTblRow> rows = new List<EMDataSet.POHeaderTblRow>();
            foreach (EMDataSet.POHeaderTblRow row in
                emDataSet.POHeaderTbl.Rows)
            {
                if (row.MillConfirmationAppliesToEntirePO == 1 &&
                    !row.IsInvoiceNumberNull() && row.InvoiceNumber != "")
                    continue;
                if (row.MillConfirmationAppliesToEntirePO == 0)
                {
                    bool allItemsInvoiced = true;
                    foreach (EMDataSet.POItemTblRow itemRow in
                        row.GetPOItemTblRows())
                    {
                        if (itemRow.IsInvoiceNumberNull() ||
                            itemRow.InvoiceNumber == "")
                        {
                            allItemsInvoiced = false;
                            break;
                        }
                    }
                    if (allItemsInvoiced == true)
                        continue;
                }
                rows.Add(row);
            }
            return rows;
        }
        // new invoice menu item
        private void menuItem12_Click_2(object sender, EventArgs e)
        {
            NewInvoiceReport(false);
        }
        private void NewInvoiceReport(bool summarize)
        {
            if (!CheckForDirty())
                return;
            string friendlyConstraints;
            EMDataSet dataSet = CreateContainerViewOfDataSet(out friendlyConstraints);
            if (dataSet == null)
                return;
            using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
            {
                AdapterHelper.FillOutConstraints(dataSet);
            }
            AddAuxiliaryFieldInfo(dataSet);

            EMDataSet itemizedDataSet = (EMDataSet)dataSet.Copy();
            CurrencyFiller currencyFiller = new CurrencyFiller(dataSet);
            System.Windows.Forms.DialogResult res = 
                currencyFiller.ShowDialog();
            if (res == DialogResult.Cancel)
                return;
            if (!summarize)
            {
         /*       foreach (EMDataSet.POItemTblRow row in dataSet.POItemTbl)
                {
                    if (!row.IsSizeOfItemNull())
                        row.ItemNameObsolete += "-" + row.SizeOfItem;
                    if (!row.IsLengthNull())
                        row.ItemNameObsolete += " " + row.Length;
                }*/
            }
            dataSet.ContBundleTbl.Columns.Add("DoesPickupDateExist", typeof(string));
            

            foreach (EMDataSet.ContBundleTblRow bundleRow in dataSet.ContBundleTbl)
            {
                if (bundleRow.ContainerTblRow.ApplyClosingToEntireContainer!=0)
                {
                    bundleRow["DoesPickupDateExist"] = 
                        bundleRow.ContainerTblRow.
                        IsContainerPickupDateNull() ? "No" : "Yes";
                }
                else
                {
                    bundleRow["DoesPickupDateExist"] = 
                        bundleRow.
                        IsPickupDateNull() ? "No" : "Yes";
                }
                if (!bundleRow.IsBundleAlloySurchargeNull())
                    bundleRow.BundleAlloySurcharge /= 100;
                if (!bundleRow.IsBundleScrapSurchargeNull())
                    bundleRow.BundleScrapSurcharge /= 100;
            }
//                        "ScrapSurchargeRate",
  //          "AlloySurchargeRate",


            // Convet all $/kg to $/lb. The rate that we calculate is 
            // by lbs in the Excel spreadsheet
            foreach (EMDataSet.POItemTblRow row in dataSet.POItemTbl)
            {
                if (DataInterface.IsMetric(row) &&
                    !row.IsCustRateNull())
                {
                    // rate is by default lbs here, so convert from kg to lbs
                     row.CustRate = DataInterface.ConvertToKG(row.CustRate); 
                    // since kg is in denominator
                }
            }

            if (summarize)
            {
                Dictionary<string, List<EMDataSet.ContBundleTblRow>> itemNames = new Dictionary<string, List<EMDataSet.ContBundleTblRow>>();
                foreach (EMDataSet.ContBundleTblRow row in dataSet.ContBundleTbl)
                {
//                    string key = row.POItemTblRow.POID.ToString() + row.POItemNumber.ToString() + (row.IsInvoiceNumberNull()?"":row.InvoiceNumber.ToString());
                    string key = row.IsInvoiceNumberNull() ? "" : row.InvoiceNumber.ToString();
                    key += (string)row["DoesPickupDateExist"];
                    if (!itemNames.ContainsKey(key))
                        itemNames[key] = new List<EMDataSet.ContBundleTblRow>();
                    itemNames[key].Add(row);
                }

                // The rate is the weight averaged rates of all the included pieces:
                foreach (KeyValuePair<string, List<EMDataSet.ContBundleTblRow>> keyValue in itemNames)
                {

                    decimal totalRate = 0;
                    decimal totalWeight = 0;
                    decimal totalScrapSurcharge = 0;
                    decimal totalAlloySurcharge = 0;
                    bool isMetric = false;
                    bool isDefined = false;
                    foreach (EMDataSet.ContBundleTblRow row in keyValue.Value)
                    {
                        if (row.IsMetricShipQtyNull())
                            continue;
                        if (isDefined)
                        {
                            if (DataInterface.IsMetric(row.POItemTblRow.UM) !=
                                isMetric)
                                throw new Exception("Error Container:" + row.ContainerTblRow.ContNumber +
                                    " has 2 or more bundles with different UM (unit of measure)");
                        }
                        isDefined = true;
                        isMetric = DataInterface.IsMetric(row.POItemTblRow.UM);
                        totalWeight += row.MetricShipQty;
                        totalRate += row.MetricShipQty * row.POItemTblRow.CustRate;
                        totalScrapSurcharge += row.IsBundleScrapSurchargeNull() ? 0 : row.BundleScrapSurcharge * row.MetricShipQty;
                        totalAlloySurcharge += row.IsBundleAlloySurchargeNull()?  0: row.BundleAlloySurcharge * row.MetricShipQty;
                    }
                    totalRate = totalRate / totalWeight;
//                    if (isMetric)
  //                      // rate is by default lbs here, so convert from kg to lbs
    //                    totalRate = DataInterface.ConvertToKG(totalRate); // since kg is in denominator
                    decimal totalWeightLbs = DataInterface.ConvertToLbs(totalWeight);
                    totalScrapSurcharge = totalScrapSurcharge / totalWeight;
                    totalAlloySurcharge = totalAlloySurcharge / totalWeight;

                    keyValue.Value[0].BundleScrapSurcharge = totalScrapSurcharge;
                    keyValue.Value[0].BundleAlloySurcharge = totalAlloySurcharge;
                    keyValue.Value[0].EnglishShipQty = totalWeightLbs;
                    keyValue.Value[0].MetricShipQty = totalWeight;
                    keyValue.Value[0].POItemTblRow.CustRate = totalRate;
                    for (int i = 1; i < keyValue.Value.Count; i++)
                    {
                        keyValue.Value[i].Delete();
                    }
                }

                // Now remove POItems that aren't used and containers that aren't used
                foreach (EMDataSet.POItemTblRow row in dataSet.POItemTbl)
                {
                    if (row.GetContBundleTblRows().Length == 0)
                        row.Delete();
                }
                foreach (EMDataSet.ContainerTblRow row in dataSet.ContainerTbl)
                {
                    if (row.GetContBundleTblRows().Length == 0)
                        row.Delete();
                    //else
                      //  row.ContNumber = "";
                }
            }
          
            /* This is where the scrap surcharge is adding to the regular surcharge, 
             * because we were not itemizing the scrap surcharge (but now I plan on
             * actually itemizing it)
             * foreach (EMDataSet.ContBundleTblRow bundleRow in dataSet.ContBundleTbl)
            {
                if (!DataInterface.IsRowAlive(bundleRow))
                    continue;
                EMDataSet.SurchargeRateTblRow surchargeRow = dataSet.SurchargeRateTbl.FindBySurchargeID(bundleRow.AuxKey1);
                if (surchargeRow.ItemID == -1)
                    continue;
                EMDataSet.SurchargeRateTblRow scrapSurchargeRow = 
                    dataSet.SurchargeRateTbl.FindBySurchargeID(bundleRow.AuxKey2);
                surchargeRow.SurchargeRate += scrapSurchargeRow.SurchargeRate;
                surchargeRow.ItemID = -1; // mark as don't update again
            }*/


            ShowInvoiceReportAsCSV(dataSet);

            List<EMDataSet.ContBundleTblRow> notInvoicedRows = new List<EMDataSet.ContBundleTblRow>();
            foreach (EMDataSet.ContBundleTblRow row in itemizedDataSet.ContBundleTbl)
            {
                if (row.IsEMInvoiceNumberNull() ||
                    row.EMInvoiceNumber == "")
                    notInvoicedRows.Add(row);
            }
            if (notInvoicedRows.Count != 0)
            {
                BatchAddNewInvoice bani = new BatchAddNewInvoice(notInvoicedRows);
                bani.Show();
            }
        }

        private void newInvoiceReportMenu_Click(object sender, EventArgs e)
        {
            NewInvoiceReport(true);

        }


        private void invoiceReportMenuClick(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckForDirty())
                    return;
                EMDataSet dataSet;
                string friendlyConstraints;
                CreateLimitedViewOfDataSet(out dataSet, out friendlyConstraints);
                if (dataSet == null)
                    return;
                InvoiceSupportForm supportForm = new InvoiceSupportForm(dataSet);
                DialogResult res = supportForm.ShowDialog();
                if (res == DialogResult.Cancel)
                    return;

                // Here we collapse all the rows with the same item/grade/finish... That's how the report will
                // display them
                foreach (EMDataSet.POHeaderTblRow headerRow in dataSet.POHeaderTbl)
                {
                    ArrayList list = new ArrayList();
                    foreach (EMDataSet.POItemTblRow row in headerRow.GetPOItemTblRows())
                    {
                        if (!row.IsItemNameObsoleteNull())
                            list.Add(row.ItemNameObsolete);
                        if (headerRow.MillConfirmationAppliesToEntirePO == 1)
                        {
                            row["MillAcknowledgeDate"] = headerRow["MillAcknowledgeDate"];
                            row["MillConfirmationNumber"] = headerRow["MillConfirmationNumber"];
                            row["InvoiceDate"] = headerRow["InvoiceDate"];
                            row["InvoiceNumber"] = headerRow["InvoiceNumber"];
                        }
                    }
                    AdapterHelper.UniqueStr(ref list);
                    foreach (string item in list)
                    {
                        string query = "ItemNameObsolete = '" + item + "' AND " +
                            "POID = " + headerRow.POID;
                        EMDataSet.POItemTblRow[] rows = (EMDataSet.POItemTblRow[])dataSet.POItemTbl.Select(query);
                        for (int i = 1; i < rows.Length; i++)
                        {
                            if (!rows[i].IsQtyNull())
                            {
                                if (rows[0].IsQtyNull())
                                    rows[0].Qty = 0;
                                rows[0].Qty += rows[i].Qty;
                            }
                            if (!rows[i].IsCustAmountNull())
                            {
                                if (rows[0].IsCustAmountNull())
                                    rows[0].CustAmount = 0;
                                rows[0].CustAmount += rows[i].CustAmount;
                            }
                            rows[i].Delete();
                        }
                    }
                }
                EMDataSet tempCopy = (EMDataSet)dataSet.Copy();
                ShowCrystalReport(tempCopy, new AcknowledgeReport(), "Invoice Report", friendlyConstraints);

                List<EMDataSet.POHeaderTblRow> notYetInvoicedRows =
                    GetPOsNotYetInvoiced(dataSet);
                if (notYetInvoicedRows.Count == 0) // all invoiced
                    return;
                dataSet.RejectChanges(); // get rid of all these changes
                BatchAddInvoice batchAddInvoice = new BatchAddInvoice(dataSet, notYetInvoicedRows);
                batchAddInvoice.ShowDialog();
                IToolbarInterface iToolbarInterface = m_activeForm as IToolbarInterface;
                if (iToolbarInterface != null)
                    iToolbarInterface.OnCancel(); // make sure that the form gets updated
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void monthlySalesCustomer_Click(object sender, System.EventArgs e)
        {
            ShowCrystalReport(new SalesReportsByCustomer(), "Monthly sales by customer");
        }
        void FillOutContainerFromPO(EMDataSet dataSet)
        {
            dataSet.EnforceConstraints = false;
            // check each PO Item to see if it has any container numbers
            using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
            {
                ArrayList listOfContIDs = new ArrayList();
                foreach (EMDataSet.POItemTblRow row in dataSet.POItemTbl)
                {
                    AdapterHelper.FillContBundleFromPOItemNumber(dataSet, row.POItemNumber);
                    EMDataSet.ContBundleTblRow[] bundleRows = row.GetContBundleTblRows();
                    foreach (EMDataSet.ContBundleTblRow bundleRow in bundleRows)
                    {
                        listOfContIDs.Add(bundleRow.ContID);
                    }
                }
                AdapterHelper.Unique(ref listOfContIDs);
                foreach (int contID in listOfContIDs)
                {
                    AdapterHelper.FillContainerHeader(dataSet, contID);
                }
            }
        }
        private void promiseReportMenu_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckForDirty())
                    return;
                string friendlyConstraints;
                EMDataSet dataSet;
                CreateLimitedViewOfDataSet(out dataSet, out friendlyConstraints);
                if (dataSet == null)
                    return;
                FillOutContainerFromPO(dataSet);
                foreach (EMDataSet.POItemTblRow row in dataSet.POItemTbl)
                {
                    ArrayList listOfContID = new ArrayList();
                    EMDataSet.ContBundleTblRow[] bundleRows = row.GetContBundleTblRows();
                    foreach (EMDataSet.ContBundleTblRow bundleRow in bundleRows)
                    {
                        listOfContID.Add(bundleRow.ContID);
                    }
                    AdapterHelper.Unique(ref listOfContID);
                    row.Comments = "";
                    foreach (int contID in listOfContID)
                    {
                        EMDataSet.ContainerTblRow contRow = dataSet.ContainerTbl.FindByContID(contID);
                        string eta = "";
                        if (!contRow.IsETANull())
                            eta = contRow.ETA.ToString("d");
                        row.Comments += contRow.ContNumber + " " + eta + "\n";
                    }
                }
                ShowCrystalReport(dataSet, new PromiseReport(),
                    "Promise Report", friendlyConstraints);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sizeGradeItem_Click(object sender, EventArgs e)
        {
            ShowCrystalReport(new QuantitySize(), "Size Grade Report");
        }

        private void orderLogMenu_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckForDirty())
                    return;
                string friendlyConstraints;
                EMDataSet emDataSet;
                CreateLimitedViewOfDataSet(out emDataSet, out friendlyConstraints);
                if (emDataSet == null)
                    return;
                // * Propogate the invoice number from the "apply to all" settings
                foreach (EMDataSet.POHeaderTblRow headerRow in emDataSet.POHeaderTbl.Rows)
                {
                    if (!headerRow.IsMillConfirmationAppliesToEntirePONull() &&
                        headerRow.MillConfirmationAppliesToEntirePO != 0)
                    {
                        foreach (EMDataSet.POItemTblRow itemRow in headerRow.GetPOItemTblRows())
                        {
                            itemRow["MillConfirmationNumber"] = headerRow["MillConfirmationNumber"];
                            itemRow["MillAcknowledgeDate"] = headerRow["MillAcknowledgeDate"];
                        }
                    }

                    string locationName = emDataSet.LocationTbl.FindByLocID(headerRow.MillLocationID).LocName;
                    headerRow.VendEMail = locationName;

                }
                foreach (EMDataSet.POItemTblRow itemRow in emDataSet.POItemTbl.Rows)
                {
                    /* 3/14/2011 - there are items with no quantity
                     if (itemRow.IsQtyNull() || itemRow.Qty == 0)
                    {
                        itemRow.Delete();
                        continue;
                    }
                    if (DataInterface.IsMetric(itemRow))
                    {
                        itemRow.Qty = DataInterface.ConvertToLbs(itemRow.Qty);
                    }*/
                    if (itemRow.IsCustAmountNull() || itemRow.CustAmount == 0)
                    {
                        itemRow.Delete();
                        continue;
                    }

                    if (itemRow.IsQtyNull() == false && DataInterface.IsMetric(itemRow))
                    {
                        itemRow.Qty = DataInterface.ConvertToLbs(itemRow.Qty);
                    }
                    
                }

                string[] fieldList = new string[]{
                    "POID>POHeaderTbl.VendEMail",
                    "POID>POHeaderTbl.PONumber",
                    "POID>POHeaderTbl.PODate",
                    "POID>POHeaderTbl.ShipToEmail",
                    "FinishID>FinishTbl.FinishType",
                    "ItemNameObsolete",
                    "TreatmentID>TreatmentTbl.TreatmentType",
                    "Qty",
                    "SizeOfItem",
                    "Length",
                    "CustRate",
                    "POID>POHeaderTbl.ExchangeRate",
                    "CustAmount",
                    "=RC[-2]*RC[-1]",
                    "=IF(RC[-10]=&quot;HR&quot;,RC[-7],0)",
                    "=IF(RC[-11]=&quot;CF&quot;,RC[-8],0)",
                    "=IF(RC[-12]=&quot;SHT&quot;,RC[-9],0)",
                    "=IF(RC[-13]=&quot;Forged&quot;,RC[-10],0)",
                    "=IF(RC[-14]=&quot;SS&quot;,RC[-11],0)"
                };
                
                string[] friendlyTitles = new string[]
                {
                    "Mill",
                       "PONumber",
                       "PODate",
                    "Customer",
                    "Finish",
                    "Grade",
                    "Treatment",
                    "Qty",
                    "Size",
                    "Length",
                    "Rate",
                    "Exchange",
                    "Total",
                    "USTotal",
                    "HR",
                    "CF",
                    "SHT",
                    "Forged",
                    "SS"
               };
                string[] types = new string[]
                {
                    "String",
                    "String",
                    "DateTime",
                    "String",
                    "String",
                    "String",
                    "String",
                    "Number",
                    "String",
                    "String",
                    "Number",
                    "Number",
                    "Number",
                    "Formula",
                    "Formula",
                    "Formula",
                    "Formula",
                    "Formula",
                    "Formula"
                    };
                string title = "Order Log: " + friendlyConstraints;
                EMXMLOutput.WriteXMLOfAllRows(title,fieldList, fieldList, 
                    friendlyTitles, types, emDataSet.POItemTbl.Rows);


                /*

                foreach (EMDataSet.POHeaderTblRow row in emDataSet.POHeaderTbl.Rows)
                {
                    if (!row.IsStatusNull())
                    {
                        if (row.Status == "Cancelled")
                            continue;
                    }
                    EMDataSet.OrderLogTblRow orderLogRow = emDataSet.OrderLogTbl.NewOrderLogTblRow();
                    orderLogRow.ID = row.POID;
                    orderLogRow["Date"] = row["PODate"];
                    if (!row.IsMillIDNull())
                    {
                        orderLogRow.MillName =
                            emDataSet.CompanyTbl.FindByCompID(row.MillID).CompName;
                    }
                    if (!row.IsCustomerIDNull())
                    {
                        orderLogRow.CustomerName =
                            emDataSet.CompanyTbl.FindByCompID(row.CustomerID).CompName;
                    }
                    orderLogRow["MillAcknowledgeNumber"] = row["MillConfirmationNumber"];
                    orderLogRow["InvoiceNumber"] = row["InvoiceNumber"];
                    EMDataSet.POItemTblRow[] items = (EMDataSet.POItemTblRow[])
                        emDataSet.POItemTbl.Select("POID = " + row.POID);
                    if (items.Length == 0)
                        continue;
                    
                    Hashtable weightHash = new Hashtable();
                    Hashtable dollarHash = new Hashtable();
                    foreach (EMDataSet.POItemTblRow itemRow in items)
                    {
                        int key = -1;
                        if (!itemRow.IsFinishIDNull())
                        {
                            key = itemRow.FinishID;
                        }
                        decimal currentWeight = 0;
                        if (weightHash[key] != null)
                            currentWeight = (decimal)weightHash[key];
                        decimal currentDollar = 0;
                        if (dollarHash[key] != null)
                            currentDollar = (decimal)dollarHash[key];
                        if (!itemRow.IsQtyNull())
                        {
                            if (!DataInterface.IsMetric(itemRow))
                            {
                                currentWeight += DataInterface.ConvertToKG(itemRow.Qty);
                            }
                            else
                            {
                                currentWeight += itemRow.Qty;
                            }
                        }
                        if (!itemRow.IsCustAmountNull())
                        {
                            if (row.IsExchangeRateNull())
                            {
                                currentDollar += itemRow.CustAmount;
                            }
                            else
                            {
                                currentDollar += itemRow.CustAmount * row.ExchangeRate;
                            }
                        }
                        weightHash[key] = currentWeight;
                        dollarHash[key] = currentDollar;
                    }
                    int[] treatments = { 0, 1, 2, 4 };
                    string[] treatmentsStr = { "HR", "CF", "Sheet", "Coil" };
                    decimal totalDollars = 0;
                    for (int i = 0; i < treatments.Length; i++)
                    {
                        int treatment = treatments[i];
                        string str = treatmentsStr[i];
                        decimal weight = 0;
                        if (weightHash[treatment] != null)
                        {
                            weight = (decimal)weightHash[treatment];
                        }
                        orderLogRow[str + "Tons"] = weight / 1000;
                        decimal dollar = 0;
                        if (dollarHash[treatment] != null)
                        {
                            dollar = (decimal)dollarHash[treatment];
                        }
                        orderLogRow[str + "Dollars"] = dollar;
                        totalDollars += dollar;
                    }
                    orderLogRow["TotalDollars"] = totalDollars;
                    orderLogRow["PONumber"] = row["PONumber"];
                    emDataSet.OrderLogTbl.AddOrderLogTblRow(orderLogRow);
                }
                GenericCrystalViewer v = new GenericCrystalViewer();
                v.Text = "Order Log";
                ReportClass report = new OrderLog();

                ParameterFields fields = new ParameterFields();
                ParameterField field = new ParameterField();
                field.ParameterFieldName = "reportDescription";
                ParameterDiscreteValue discrete = new ParameterDiscreteValue();
                discrete.Value = friendlyConstraints;
                field.CurrentValues.Add(discrete);
                fields.Add(field);
                v.viewer.ParameterFieldInfo = fields;


                report.SetDataSource(emDataSet);
                v.viewer.ReportSource = report;
                v.ShowDialog();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private int Find(string[] arr, string target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }
            return -1;
        }
        // Orders
        private void menuItem19_Click(object sender, EventArgs e)
        {
            EMDataSet dataSet;
            string friendlyConstraints;
            CreateLimitedViewOfDataSet(out dataSet,out friendlyConstraints);
            if (dataSet == null)
                return;
            FillOutContainerFromPO(dataSet);
            ShowPOTotals(dataSet);
        }

        void ShowPOTotals(EMDataSet dataSet)
        {
            //AdapterHelper.FillContBundles(
            string[] fieldNames = new string[] {
            "PONumber","Status","PODate",
                "ShipToEMail",
            "Qty","Rate","Surcharge",
                "=RC[-3] * RC[-1]",
                "=RC[-4] * RC[-2]",
                "ShippedQty"};
            string[] titles = new string[] {
            "PO","Status","Date","Customer","Qty(kg)",
                "Rate","Total","Total Surcharge","ShippedQty"};
            string[] types = new string[] {
                "String","String","DateTime","String","Number","Number","Number",
                "Formula","Formula"
            ,"Number"};



            dataSet.POHeaderTbl.Columns.Add("Qty", typeof(decimal));
            dataSet.POHeaderTbl.Columns.Add("Rate", typeof(decimal));
            dataSet.POHeaderTbl.Columns.Add("ShippedQty", typeof(decimal));
            dataSet.POHeaderTbl.Columns.Add("Surcharge", typeof(decimal));
            foreach (EMDataSet.POItemTblRow itemRow in dataSet.POItemTbl)
            {
                if (itemRow.IsQtyNull())
                    continue;
                if (itemRow.IsCustRateNull())
                    continue;
                EMDataSet.POHeaderTblRow poHeader = itemRow.POHeaderTblRow;
                decimal oldQty = poHeader.IsNull("Qty")?0:
                    (decimal)poHeader["Qty"];

                decimal conversion = DataInterface.IsMetric(itemRow) ? 1 :
         DataInterface.ConvertToLbs(1);
                decimal newQty = itemRow.Qty / conversion;
     
                oldQty += newQty;
                // Now average all the rates.
                decimal oldRate = poHeader.IsNull("Rate") ? 0 :
                    (decimal)poHeader["Rate"];
                oldRate = oldRate * oldQty; // weigh it by qty
                decimal newRate =itemRow.CustRate*conversion;
                newRate = newRate * newQty; // weight it by the new qty
                oldRate = (oldRate + newRate) / (newQty + oldQty);
                poHeader["Qty"] = oldQty;
                poHeader["Rate"] = oldRate;

                string query = "POItemNumber = " + itemRow.POItemNumber.ToString();
                foreach (EMDataSet.ContBundleTblRow bundleRow in
                    dataSet.ContBundleTbl.Select(query))
                {
                    if (bundleRow.IsMetricShipQtyNull())
                        continue;
                    decimal shippedQty = poHeader.IsNull("ShippedQty")?0:
                        (decimal)poHeader["ShippedQty"];
                    poHeader["ShippedQty"] = shippedQty + bundleRow.MetricShipQty;
                }
                // Add up the qty
            }
            
            EMXMLOutput.WriteXMLOfAllRows("Invoice Report", 
                fieldNames, fieldNames, titles, types, dataSet.POHeaderTbl.Rows);

        }

        void ShowInvoiceReportAsCSV(EMDataSet dataSet)
        {
            string[] fieldNames = new string[]{
            "InvoiceNumber",
            "MillInvoiceDate",
            "DoesPickupDateExist",
            "POItemNumber>POItemTbl.POID>POHeaderTbl.PONumber",
			"POItemNumber>POItemTbl.POID>POHeaderTbl.PODate",
            "ContID>ContainerTbl.ShipDate",
            "ContID>ContainerTbl.ContNumber",
            "POItemNumber>POItemTbl.POID>POHeaderTbl.ShipToEMail",
            "POItemNumber>POItemTbl.ItemNameObsolete",
            "POItemNumber>POItemTbl.SizeOfItem",
            "POItemNumber>POItemTbl.Length",
            "MetricShipQty",
            "EnglishShipQty",
            "POItemNumber>POItemTbl.POID>POHeaderTbl.ExchangeRate",
            "POItemNumber>POItemTbl.CustRate",
            "EMInvoiceNumber",
            "BundleScrapSurcharge",
            "BundleAlloySurcharge",
            "=RC[-6]*RC[-4]",
            "=RC[-7]*RC[-3]",
            "=RC[-8]*RC[-3]",
            "=RC[-3]+RC[-2]+RC[-1]",
            "=RC[-1]*RC[-9]*.03"
            };
            string[] titles = new string[]{
                "Invoice","Invoice Date",
                "Is Picked Up",
                "PONumber","PODate",
                "ShipDate","Container","Customer",
                "ItemName","Size","Length","Qty(kg)","Qty(lbs)","ExchangeRate","CustRate",
                "Invoice","Scrap Surcharge Rate","Alloy Surcharge Rate",
                "Value","Scrap Surcharge","Alloy Surcharge","Total Value","Commission"

            };
            string[] types = new string[]
        {"String","DateTime",
            "String",
            "String","DateTime",
            "DateTime","String","String",
            "String","String","String","Number","Number","Number","Number"
            ,"String","Number","Number",
            "Formula","Formula","Formula","Formula","Formula"
        };

            EMXMLOutput.WriteXMLOfAllRows("Invoice Report",fieldNames, fieldNames, titles, types,dataSet.ContBundleTbl.Rows);
			

        }
        private void CreateCSVOfAllRows(string[] fieldList, string[] originalTitles,
			string[] friendlyTitles,DataRowCollection rows)
        {
            StringBuilder allData = new StringBuilder();
            foreach (string field in fieldList)
            {
                string fieldTmp = field;
                int index = Find(originalTitles, field);
                if (index == -1)
                    allData.Append(FieldExtractor.GetFieldText(field));
                else
                    allData.Append(friendlyTitles[index]);
                allData.Append(',');
            }
            allData.Append("\r\n");
            foreach (DataRow row in rows)
            {
                if (!DataInterface.IsRowAlive(row))
                    continue;
                foreach (string field in fieldList)
                {
                    string f = field;
                    object o = FieldExtractor.GetField(f, row);
                    StringBuilder oAsString = new StringBuilder(o.ToString());
                    oAsString.Replace(',', ' ');
                    oAsString.Replace('\n', ' ');
                    oAsString.Replace('\r', ' ');
                    oAsString.Replace('\f', ' ');
                    allData.Append(oAsString);
                    allData.Append(",");
                }
                allData.Append("\r\n");
            }
            string filename = Path.GetTempPath() + "\\full.csv";
            using (TextWriter tw = new StreamWriter(filename))
            {
                tw.Write(allData);
                tw.Close();
            }
            ExcelHelper.OpenExcel(filename);
        }

        string[] poFieldList = // start at 18
					{
						"POID>POHeaderTbl.PONumber",
						"SeqNumber",
						"POID>POHeaderTbl.PODate",
						"ItemID>ItemTbl.ItemName",
						"FinishID>FinishTbl.FinishType",
						"TreatmentID>TreatmentTbl.TreatmentType",
						"POID>POHeaderTbl.Status",
						"POID>POHeaderTbl.Terms",
						"POID>POHeaderTbl.ShipCode",
						"POID>POHeaderTbl.FOB",
						"POID>POHeaderTbl.ExchangeRate",//10
						"POID>POHeaderTbl.Comments",
						"POID>POHeaderTbl.MillConfirmationNumber",
						"POID>POHeaderTbl.MillAcknowledgeDate",
						"POID>POHeaderTbl.ExchangeDate",
						"POID>POHeaderTbl.CurrencyID>CurrencyTbl.CurrencyName",
						"POID>POHeaderTbl.InvoiceNumber",
						"POID>POHeaderTbl.InvoiceDate",
						"POID>POHeaderTbl.MillAcknowledgeDateRevised",
						"POID>POHeaderTbl.MillID>CompanyTbl.CompName",
						"POID>POHeaderTbl.MillLocationID>LocationTbl.LocName",//20
						"POID>POHeaderTbl.CustomerID>CompanyTbl.CompName",
						"POID>POHeaderTbl.CustomerLocationID>LocationTbl.LocName",
						"ItemDesc",
						"Length",
						"SizeOfItem",
						"ItemAccessCode",
						"Qty",
						"UM",
						"DateRequired",
						"AcknowledgeDate",
						"MillShipDate",
						"CancelDate",
						"CustRate",
						"CustAmount",
						"Comments"
					};
        string[] poOriginalTitles = 
				{
					"POID>POHeaderTbl.MillID>CompanyTbl.CompName",
					"POID>POHeaderTbl.MillLocationID>LocationTbl.LocName",
					"POID>POHeaderTbl.CustomerID>CompanyTbl.CompName",
					"POID>POHeaderTbl.CustomerLocationID>LocationTbl.LocName"
				};
        string[] poFriendlyTitles = 
					{
						"MillName",
						"MillLocationName",
						"CustomerName",
						"CustomerLocationName"
					};

        // export to excel-  po	
        private void menuItem14_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!CheckForDirty())
                    return;
                string friendlyConstraints;
                EMDataSet emDataSet;
                CreateLimitedViewOfDataSet(out emDataSet, out friendlyConstraints);
                if (emDataSet == null)
                    return;
                this.CreateCSVOfAllRows(poFieldList, poOriginalTitles,
                    poFriendlyTitles, emDataSet.POItemTbl.Rows);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        static private void Swap(ArrayList list, int index1, int index2)
        {
            object o1 = list[index1];
            object o2 = list[index2];
            list[index1] = o2;
            list[index2] = o1;
        }
        // export to excel - container
        private void menuItem15_Click(object sender, System.EventArgs e)
        {
            try
            {
                string friendlyConstraints;
                EMDataSet emDataSet = CreateContainerViewOfDataSet(out friendlyConstraints);
                if (emDataSet  == null)
                    return;
                using (new TurnOffConstraints(emDataSet))
                {
                using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
                {
                    AdapterHelper.FillOutConstraints(emDataSet);
                }
                AddAuxiliaryFieldInfo(emDataSet);
    
                    string[] containerFields = {
													"ContID>ContainerTbl.ContNumber",
													"ContID>ContainerTbl.ShipDate",
													"ContID>ContainerTbl.ETA",
													"ContID>ContainerTbl.Comments",
													"ContID>ContainerTbl.Status",
													"ContID>ContainerTbl.ApplyClosingToEntireContainer",
													"ContID>ContainerTbl.ContainerPickupDate",
													"ContID>ContainerTbl.ContainerPickupTerminal",
													"ContID>ContainerTbl.ContainerProofOfDelivery",
													"BundleSeqNumber",
													"EnglishShipQty",
													"MetricShipQty",
                        							"InvoiceNumber",
                                                    "MillInvoiceDate",

                                                    "EMInvoiceNumber",
													"Heat",
													"BayNumber",
													"PickupDate",
													"PickupTerminal",
													"ProofOfDelivery"
												};
                    ArrayList totalFieldList = new ArrayList();
                    foreach (string s in containerFields)
                    {
                        totalFieldList.Add(s);
                    }
                    foreach (string s in poFieldList)
                    {
                        totalFieldList.Add("POItemNumber>POItemTbl." + s);
                    }
                    string[] contOriginalTitles = (string[])poOriginalTitles.Clone();
                    for (int i = 0; i < contOriginalTitles.Length; i++)
                    {
                        contOriginalTitles[i] = "POItemNumber>POItemTbl."
                            + contOriginalTitles[i];
                    }
                    Swap(totalFieldList, 9, 0); // bundle
                    Swap(totalFieldList, 41, 1); // customer 
                    Swap(totalFieldList, 9, 2); // cont number
                    Swap(totalFieldList, 20, 3); // po#
                    Swap(totalFieldList, 45, 4); //size
                    Swap(totalFieldList, 24, 5); // Treatment
                    Swap(totalFieldList, 23, 6); // item name
                    Swap(totalFieldList, 25, 7); // Finish
                    Swap(totalFieldList, 46, 8); //iac
                    Swap(totalFieldList, 47, 9);// qty
                    Swap(totalFieldList, 48, 10);// um
                    Swap(totalFieldList, 15, 11); //heat
                    //      Swap(totalFieldList, 12, 12); //invoice
                    // 13 is invoice date
                    // 14 is em invoice number

                    Swap(totalFieldList, 47, 15); // eta
                    Swap(totalFieldList, 42, 16); // branch


                    containerFields = (string[])totalFieldList.ToArray(typeof(string));
                    this.CreateCSVOfAllRows(containerFields, contOriginalTitles, poFriendlyTitles,
                        emDataSet.ContBundleTbl.Rows);
                    emDataSet.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void CheckForChange(DataRow row, string fieldName, ref int oldID, ref bool success)
        {
            if (row.IsNull(fieldName))
            {
                success = false;
                return;
            }
            int newID = (int)row[fieldName];
            if (oldID == 0)
            {
                oldID = newID;
                return;
            }
            if (oldID != newID)
            {
                success = false;
                return;
            }
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            // Find if containers have a mill/location
            // customer location
            EMDataSet dataSet = new EMDataSet();
            dataSet.EnforceConstraints = false;
            using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
            {
                AdapterHelper.FillCompany(dataSet);
                foreach (EMDataSet.CompanyTblRow companyRow in dataSet.CompanyTbl)
                {
                    AdapterHelper.FillLocations(dataSet, companyRow.CompID);
                }
                AdapterHelper.FillAllContHeaders(dataSet, "");
                foreach (EMDataSet.ContainerTblRow contRow in dataSet.ContainerTbl)
                {
                    AdapterHelper.FillContBundle(dataSet, contRow.ContID);
                    foreach (EMDataSet.ContBundleTblRow bundleRow in dataSet.ContBundleTbl)
                    {
                        AdapterHelper.FillPOItemFromPOItemNumber(dataSet, bundleRow.POItemNumber);
                    }
                }
                ArrayList listOfPOIDs = new ArrayList();
                foreach (EMDataSet.POItemTblRow poItemRow in dataSet.POItemTbl)
                {
                    listOfPOIDs.Add(poItemRow.POID);
                }
                listOfPOIDs.Sort();
                AdapterHelper.Unique(ref listOfPOIDs);
                foreach (int poid in listOfPOIDs)
                {
                    AdapterHelper.FillPOHeader(dataSet, poid);
                }
            }

            List<string> failedContainers = new List<string>();
            foreach (EMDataSet.ContainerTblRow contRow in dataSet.ContainerTbl)
            {
                int millID = 0;
                int millLocation = 0;
                int custID = 0;
                int custLocation = 0;
                bool success = true;
                foreach (EMDataSet.ContBundleTblRow bundleRow in contRow.GetContBundleTblRows())
                {
                    EMDataSet.POHeaderTblRow header = bundleRow.POItemTblRow.POHeaderTblRow;
                    CheckForChange(header, "MillID", ref millID, ref success);
                    CheckForChange(header, "MillLocationID", ref millLocation, ref success);
                    CheckForChange(header, "CustomerID", ref custID, ref success);
                    CheckForChange(header, "CustomerLocationID", ref custLocation, ref success);
                    if (!success)
                        break;
                }
                if (!success)
                    failedContainers.Add(contRow.ContNumber);
            }
            MessageBox.Show(failedContainers.ToString());




        }

        private void monthlyExcel_Click(object sender, EventArgs e)
        {
            try
            {
                EMDataSet emDataSet;
                string friendlyConstraints;
                CreateLimitedViewOfDataSet(out emDataSet, out friendlyConstraints);
                if (emDataSet == null)
                    return;
                foreach (EMDataSet.POItemTblRow row in emDataSet.POItemTbl)
                {
                    if (row.IsItemIDNull())
                        row.Delete();
                }
                emDataSet.POItemTbl.AcceptChanges();
                ExcelHelper.ShowCustomerLog(emDataSet.POItemTbl.Rows);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void completedPOs_Click(object sender, EventArgs e)
        {
            try
            {
                EMDataSet emDataSet;
                string friendlyConstraints;
                CreateLimitedViewOfDataSet(out emDataSet, out friendlyConstraints);
                foreach (EMDataSet.POHeaderTblRow headerRow in emDataSet.POHeaderTbl)
                {
                    bool hasQty = false;
                    EMDataSet.POItemTblRow[] itemRows = headerRow.GetPOItemTblRows();
                    foreach (EMDataSet.POItemTblRow itemRow in itemRows)
                    {
                        if (itemRow.IsQtyNull() || itemRow.Qty == 0)
                        {
                            itemRow.Delete();
                        }
                        else
                        {
                            hasQty = true;
                        }
                    }
                    if (hasQty == false)
                        headerRow.Delete();
                }
                emDataSet.AcceptChanges();
                using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
                using (new TurnOffConstraints(emDataSet))
                {
                    foreach (EMDataSet.POItemTblRow row in emDataSet.POItemTbl)
                    {
                        AdapterHelper.FillContBundleFromPOItemNumber(emDataSet, row.POItemNumber);
                    }
                    AdapterHelper.FillOutConstraints(emDataSet);
                }

                new ShowCompletedPODlg(emDataSet, friendlyConstraints).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // po items not in containers
        private void menuItem21_Click(object sender, EventArgs e)
        {
            EMDataSet emDataSet;
            string friendlyConstraints;
            CreateLimitedViewOfDataSet(out emDataSet, out friendlyConstraints);
            if (emDataSet == null)
                return;
            using (new OpenConnection(IsWrite.No, AdapterHelper.Connection))
            using (new TurnOffConstraints(emDataSet))
            {
                   foreach (EMDataSet.POItemTblRow row in emDataSet.POItemTbl)
                    {
                        AdapterHelper.FillContBundleFromPOItemNumber(emDataSet, row.POItemNumber);
                    }
                    AdapterHelper.FillOutConstraints(emDataSet);
            }
            emDataSet.POItemTbl.Columns.Add("ContQty", typeof(decimal));
            foreach (EMDataSet.ContBundleTblRow row in emDataSet.ContBundleTbl)
            {
                if (row.ContainerTblRow.Status == "Cancelled")
                    continue;
                EMDataSet.POItemTblRow itemRow = emDataSet.POItemTbl.FindByPOItemNumber(row.POItemNumber);
                if (row.IsMetricShipQtyNull() || row.IsEnglishShipQtyNull())
                    continue;
                decimal contQty = DataInterface.IsMetric(itemRow)?row.MetricShipQty:row.EnglishShipQty;

                decimal existingQty = itemRow.IsNull("ContQty")?0:(decimal)itemRow["ContQty"];
                existingQty += contQty;
                itemRow["ContQty"] = existingQty;
            }
            foreach (EMDataSet.POItemTblRow row in emDataSet.POItemTbl)
            {
                if (row.POHeaderTblRow.IsCancelDateNull() == false ||
                    row.IsQtyNull() || row.Qty == 0 || row.IsCancelDateNull() == false)
                {
                    row.Delete();
                    continue;
                }
                if (row.IsNull("ContQty"))
                    row["ContQty"] = (decimal)0;
                decimal diff = row.Qty - (decimal)row["ContQty"];
                if (diff < 0)
                {
                    row.Delete();
                    continue;
                }
                if ((diff / row.Qty) < (decimal)0.10)
                {
                    row.Delete();
                    continue; 
                }

            }

            string[] fieldNames = new string[]{
            "POID>POHeaderTbl.PONumber",
			"POID>POHeaderTbl.PODate",
            "POID>POHeaderTbl.VendEMail",
            "POID>POHeaderTbl.ShipToEMail",
            "ItemNameObsolete",
            "SizeOfItem",
            "Length",
            "Qty",
            "ContQty",
            "=RC[-2]-RC[-1]",
            "POID>POHeaderTbl.ExchangeRate",
            "CustRate",
            "=RC[-1]*RC[-3]",
            "=RC[-1]*RC[-3]*.03",
            };
            string[] titles = new string[]{
                "PONumber","PODate",
                "Mill","Customer",
                "ItemName","Size","Length","Qty","ContainerQty","Remaining","ExchangeRate","CustRate",
                "Total","Commission"
            };
            string[] types = new string[]
                {"String","DateTime",
                 "String","String",
                 "String","String","String","Number","Number","Formula","Number","Number",
                 "Formula","Formula"
               };
            EMXMLOutput.WriteXMLOfAllRows("PO:Invoice Report", 
                fieldNames, fieldNames, titles, types, emDataSet.POItemTbl.Rows);
        }


   





    }
}
