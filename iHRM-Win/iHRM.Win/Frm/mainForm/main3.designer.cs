namespace iHRM.Win.Frm.mainForm
{
    partial class main3
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::iHRM.Win.Frm.Common.SplashScreen1), true, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main3));
            this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.bgw_doWork = new System.ComponentModel.BackgroundWorker();
            this.bgw_doProgress = new System.ComponentModel.BackgroundWorker();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem7 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem9 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem10 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem11 = new DevExpress.XtraBars.BarStaticItem();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemProgressBar2
            // 
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabbedMdiManager1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Name = "navBarGroup1";
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
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel1.ID = new System.Guid("ef0dd844-84a8-43cd-881b-908a10fe2bf2");
            this.dockPanel1.Location = new System.Drawing.Point(0, 22);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 340);
            this.dockPanel1.Text = "Các chức năng";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treeList1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 313);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.treeList1.KeyFieldName = "id";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsLayout.AddNewColumns = false;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.ParentFieldName = "parentId";
            this.treeList1.Size = new System.Drawing.Size(192, 313);
            this.treeList1.TabIndex = 12;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
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
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4,
            this.bar5});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.barEditItem1,
            this.barStaticItem3,
            this.barStaticItem5,
            this.barStaticItem7,
            this.barStaticItem9,
            this.barStaticItem10,
            this.barStaticItem11,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barEditItem3,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem10});
            this.barManager1.MainMenu = this.bar5;
            this.barManager1.MaxItemId = 26;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMarqueeProgressBar1});
            this.barManager1.StatusBar = this.bar4;
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 5";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem5, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem7, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem10),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem11)});
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Custom 5";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.AccessibleName = "toolStripStatusLabel1";
            this.barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem1.Caption = "Ready";
            this.barStaticItem1.Hint = null;
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItem1
            // 
            this.barEditItem1.AccessibleName = "toolStripProgressBar2";
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.Edit = this.repositoryItemProgressBar2;
            this.barEditItem1.EditValue = 0;
            this.barEditItem1.Hint = null;
            this.barEditItem1.Id = 2;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barEditItem1.Width = 75;
            // 
            // barEditItem3
            // 
            this.barEditItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem3.Caption = "barEditItem3";
            this.barEditItem3.Edit = this.repositoryItemMarqueeProgressBar1;
            this.barEditItem3.Id = 17;
            this.barEditItem3.Name = "barEditItem3";
            this.barEditItem3.Width = 36;
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.AccessibleName = "toolStripStatusLabel8";
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem3.Caption = "[ x ]";
            this.barStaticItem3.Hint = null;
            this.barStaticItem3.Id = 4;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barStaticItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStaticItem3_ItemClick);
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.AccessibleName = "toolStripStatusLabel10";
            this.barStaticItem5.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem5.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem5.Glyph")));
            this.barStaticItem5.Hint = null;
            this.barStaticItem5.Id = 6;
            this.barStaticItem5.Name = "barStaticItem5";
            this.barStaticItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barStaticItem5.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStaticItem5_ItemClick);
            // 
            // barStaticItem7
            // 
            this.barStaticItem7.AccessibleName = "toolStripStatusLabel3";
            this.barStaticItem7.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem7.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem7.Caption = "Tiếng việt";
            this.barStaticItem7.Glyph = global::iHRM.Win.Properties.Resources.vn;
            this.barStaticItem7.Hint = null;
            this.barStaticItem7.Id = 8;
            this.barStaticItem7.Name = "barStaticItem7";
            this.barStaticItem7.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barStaticItem7.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem9
            // 
            this.barStaticItem9.AccessibleName = "toolStripStatusLabel4";
            this.barStaticItem9.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem9.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem9.Caption = "v1.0";
            this.barStaticItem9.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem9.Glyph")));
            this.barStaticItem9.Hint = null;
            this.barStaticItem9.Id = 10;
            this.barStaticItem9.Name = "barStaticItem9";
            this.barStaticItem9.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barStaticItem9.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem10
            // 
            this.barStaticItem10.AccessibleName = "toolStripStatusLabel5";
            this.barStaticItem10.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem10.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem10.Caption = "KR-Lap";
            this.barStaticItem10.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem10.Glyph")));
            this.barStaticItem10.Hint = null;
            this.barStaticItem10.Id = 11;
            this.barStaticItem10.Name = "barStaticItem10";
            this.barStaticItem10.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barStaticItem10.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem11
            // 
            this.barStaticItem11.AccessibleName = "toolStripStatusLabel6";
            this.barStaticItem11.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem11.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem11.Caption = "Dev_SV";
            this.barStaticItem11.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem11.Glyph")));
            this.barStaticItem11.Hint = null;
            this.barStaticItem11.Id = 12;
            this.barStaticItem11.Name = "barStaticItem11";
            this.barStaticItem11.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barStaticItem11.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar5
            // 
            this.bar5.BarName = "Custom 6";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.bar5.OptionsBar.AllowQuickCustomization = false;
            this.bar5.OptionsBar.DrawDragBorder = false;
            this.bar5.OptionsBar.MultiLine = true;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Custom 6";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.AccessibleName = "accountToolStripMenuItem";
            this.barButtonItem3.ActAsDropDown = true;
            this.barButtonItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem3.Caption = "Account";
            this.barButtonItem3.DropDownControl = this.popupMenu1;
            this.barButtonItem3.Hint = null;
            this.barButtonItem3.Id = 15;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.AccessibleName = "thôngTinTàiKhoảnToolStripMenuItem1";
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barButtonItem1.Caption = "Thông tin tài khoản";
            this.barButtonItem1.Glyph = global::iHRM.Win.Properties.Resources.ico20_info;
            this.barButtonItem1.Hint = null;
            this.barButtonItem1.Id = 13;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Đổi tài khoản";
            this.barButtonItem8.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.Glyph")));
            this.barButtonItem8.Id = 21;
            this.barButtonItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.LargeGlyph")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.AccessibleName = "đăngXuấtToolStripMenuItem1";
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barButtonItem2.Caption = "Thoát";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Hint = null;
            this.barButtonItem2.Id = 14;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(921, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 362);
            this.barDockControlBottom.Size = new System.Drawing.Size(921, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 340);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(921, 22);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 340);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Nhập";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 16;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Xuất";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 18;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Thu";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 19;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Chi";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 20;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Tìm kiếm";
            this.barButtonItem10.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.Glyph")));
            this.barButtonItem10.Id = 23;
            this.barButtonItem10.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem10.LargeGlyph")));
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // main3
            // 
            this.ClientSize = new System.Drawing.Size(921, 389);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "main3";
            this.Text = "sHRM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private System.ComponentModel.BackgroundWorker bgw_doWork;
        private System.ComponentModel.BackgroundWorker bgw_doProgress;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItem7;
        private DevExpress.XtraBars.BarStaticItem barStaticItem9;
        private DevExpress.XtraBars.BarStaticItem barStaticItem10;
        private DevExpress.XtraBars.BarStaticItem barStaticItem11;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
    }
}

