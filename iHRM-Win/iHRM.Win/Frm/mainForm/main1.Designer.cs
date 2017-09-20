namespace iHRM.Win.Frm.mainForm
{
    partial class main1
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::iHRM.Win.Frm.Common.SplashScreen1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUser = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblDept = new DevExpress.XtraEditors.LabelControl();
            this.menuTop = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar2 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cm_User = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.bgw_doWork = new System.ComponentModel.BackgroundWorker();
            this.bgw_doProgress = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuTop)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.cm_User.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.btnUser);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.lblDept);
            this.panel1.Controls.Add(this.menuTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 70);
            this.panel1.TabIndex = 0;
            // 
            // btnUser
            // 
            this.btnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.btnUser.LinkColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(975, 34);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(175, 31);
            this.btnUser.TabIndex = 0;
            this.btnUser.TabStop = true;
            this.btnUser.Text = "linkLabel1";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUser_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.Image")));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(1127, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 16);
            this.labelControl1.TabIndex = 3;
            // 
            // lblDept
            // 
            this.lblDept.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblDept.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDept.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblDept.Location = new System.Drawing.Point(218, 4);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(141, 24);
            this.lblDept.TabIndex = 3;
            this.lblDept.Text = "SMART SHIRTS";
            // 
            // menuTop
            // 
            this.menuTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuTop.AppearanceItem.Hovered.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuTop.AppearanceItem.Hovered.Options.UseFont = true;
            this.menuTop.AppearanceItem.Normal.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuTop.AppearanceItem.Normal.Options.UseFont = true;
            this.menuTop.AppearanceItem.Pressed.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuTop.AppearanceItem.Pressed.Options.UseFont = true;
            this.menuTop.AppearanceItem.Selected.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuTop.AppearanceItem.Selected.ForeColor = System.Drawing.Color.Red;
            this.menuTop.AppearanceItem.Selected.Options.UseFont = true;
            this.menuTop.AppearanceItem.Selected.Options.UseForeColor = true;
            this.menuTop.AutoSize = false;
            this.menuTop.BackColor = System.Drawing.Color.Transparent;
            this.menuTop.CustomizationButtonVisibility = DevExpress.XtraBars.Navigation.CustomizationButtonVisibility.Hidden;
            this.menuTop.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuTop.Location = new System.Drawing.Point(199, 34);
            this.menuTop.Name = "menuTop";
            this.menuTop.Size = new System.Drawing.Size(779, 31);
            this.menuTop.TabIndex = 1;
            this.menuTop.ItemClick += new DevExpress.XtraBars.Navigation.NavigationBarItemClickEventHandler(this.menuTop_ItemClick);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar2,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1162, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(53, 21);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(779, 21);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripProgressBar2
            // 
            this.toolStripProgressBar2.MarqueeAnimationSpeed = 30;
            this.toolStripProgressBar2.Name = "toolStripProgressBar2";
            this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 21);
            this.toolStripProgressBar2.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 21);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(22, 21);
            this.toolStripStatusLabel8.Visible = false;
            this.toolStripStatusLabel8.Click += new System.EventHandler(this.toolStripStatusLabel8_Click);
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel7.Margin = new System.Windows.Forms.Padding(5, 3, 3, 2);
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(4, 21);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::iHRM.Win.Properties.Resources.vn;
            this.toolStripStatusLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(93, 21);
            this.toolStripStatusLabel3.Text = "Tiếng việt";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel4.Image")));
            this.toolStripStatusLabel4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(55, 21);
            this.toolStripStatusLabel4.Text = "v1.0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel5.Image")));
            this.toolStripStatusLabel5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(76, 21);
            this.toolStripStatusLabel5.Text = "KR-Lap";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel6.Image")));
            this.toolStripStatusLabel6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(79, 21);
            this.toolStripStatusLabel6.Text = "Dev_SV";
            // 
            // cm_User
            // 
            this.cm_User.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.cm_User.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.cm_User.Name = "cm_User";
            this.cm_User.Size = new System.Drawing.Size(289, 72);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Image = global::iHRM.Win.Properties.Resources.ico20_info;
            this.thôngTinTàiKhoảnToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thôngTinTàiKhoảnToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "&Thông Tin Tài Khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng &Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // treeList1
            // 
            this.treeList1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeList1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.treeList1.KeyFieldName = "id";
            this.treeList1.Location = new System.Drawing.Point(0, 70);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.ParentFieldName = "parentId";
            this.treeList1.Size = new System.Drawing.Size(211, 444);
            this.treeList1.TabIndex = 10;
            this.treeList1.DoubleClick += new System.EventHandler(this.treeList1_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "caption";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(211, 70);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 444);
            this.splitterControl1.TabIndex = 11;
            this.splitterControl1.TabStop = false;
            // 
            // bgw_doWork
            // 
            this.bgw_doWork.WorkerReportsProgress = true;
            this.bgw_doWork.WorkerSupportsCancellation = true;
            this.bgw_doWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_doWork_DoWork);
            this.bgw_doWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_doWork_ProgressChanged);
            this.bgw_doWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_doWork_RunWorkerCompleted);
            // 
            // bgw_doProgress
            // 
            this.bgw_doProgress.WorkerReportsProgress = true;
            this.bgw_doProgress.WorkerSupportsCancellation = true;
            this.bgw_doProgress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_doProgress_DoWork);
            this.bgw_doProgress.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_doProgress_ProgressChanged);
            this.bgw_doProgress.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_doProgress_RunWorkerCompleted);
            // 
            // main1
            // 
            this.ClientSize = new System.Drawing.Size(1162, 540);
            this.ControlBox = false;
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.Name = "main1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuTop)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cm_User.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Navigation.OfficeNavigationBar menuTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl lblDept;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.LinkLabel btnUser;
        private System.Windows.Forms.ContextMenuStrip cm_User;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.ComponentModel.BackgroundWorker bgw_doWork;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.ComponentModel.BackgroundWorker bgw_doProgress;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar2;
    }
}

