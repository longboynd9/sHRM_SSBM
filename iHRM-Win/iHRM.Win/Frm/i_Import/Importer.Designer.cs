namespace iHRM.Win.Frm.i_Import
{
    partial class Importer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Importer));
            this.btnDoImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.prg = new DevExpress.XtraEditors.ProgressBarControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemLookupEdit_CotNhapExcel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bsMapping = new System.Windows.Forms.BindingSource(this.components);
            this.bgw_import = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLookupEdit_CotNhapExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoImport);
            this.panel1.Size = new System.Drawing.Size(609, 65);
            this.panel1.Controls.SetChildIndex(this.btnDoImport, 0);
            // 
            // btnDoImport
            // 
            this.btnDoImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoImport.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDoImport.Appearance.Options.UseFont = true;
            this.btnDoImport.Image = global::iHRM.Win.Properties.Resources.play;
            this.btnDoImport.Location = new System.Drawing.Point(502, 26);
            this.btnDoImport.Name = "btnDoImport";
            this.btnDoImport.Size = new System.Drawing.Size(104, 33);
            this.btnDoImport.TabIndex = 0;
            this.btnDoImport.Text = "Do import";
            this.btnDoImport.Click += new System.EventHandler(this.btnDoImport_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(12, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "labelControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "File import:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(99, 32);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtFilePath.Properties.Appearance.Options.UseFont = true;
            this.txtFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFilePath.Size = new System.Drawing.Size(440, 30);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilePath_ButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.richTextBox1);
            this.panelControl1.Location = new System.Drawing.Point(17, 88);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(583, 160);
            this.panelControl1.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(579, 156);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // prg
            // 
            this.prg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prg.Location = new System.Drawing.Point(17, 69);
            this.prg.Name = "prg";
            this.prg.Size = new System.Drawing.Size(583, 18);
            this.prg.TabIndex = 14;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 65);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(609, 291);
            this.xtraTabControl1.TabIndex = 15;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F);
            this.xtraTabPage1.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage1.Controls.Add(this.btnAnalyze);
            this.xtraTabPage1.Controls.Add(this.label1);
            this.xtraTabPage1.Controls.Add(this.prg);
            this.xtraTabPage1.Controls.Add(this.txtFilePath);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(603, 251);
            this.xtraTabPage1.Text = "File import";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalyze.Location = new System.Drawing.Point(541, 32);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(62, 30);
            this.btnAnalyze.TabIndex = 15;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.Analyze_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F);
            this.xtraTabPage2.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage2.Controls.Add(this.grd);
            this.xtraTabPage2.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageEnabled = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(603, 251);
            this.xtraTabPage2.Text = "Mapping";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemLookupEdit_CotNhapExcel});
            this.grd.Size = new System.Drawing.Size(603, 251);
            this.grd.TabIndex = 3;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grv.Appearance.EvenRow.Options.UseBackColor = true;
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grv.Appearance.OddRow.BorderColor = System.Drawing.Color.White;
            this.grv.Appearance.OddRow.Options.UseBackColor = true;
            this.grv.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grv.Appearance.Row.Options.UseBorderColor = true;
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grv.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grv.Appearance.SelectedRow.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.EnableAppearanceEvenRow = true;
            this.grv.OptionsView.EnableAppearanceOddRow = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "Dữ liệu vào";
            this.gridColumn1.FieldName = "c1Text";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 188;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Cột nhập excel";
            this.gridColumn2.ColumnEdit = this.repItemLookupEdit_CotNhapExcel;
            this.gridColumn2.FieldName = "c2";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 209;
            // 
            // repItemLookupEdit_CotNhapExcel
            // 
            this.repItemLookupEdit_CotNhapExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.repItemLookupEdit_CotNhapExcel.Appearance.Options.UseFont = true;
            this.repItemLookupEdit_CotNhapExcel.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9F);
            this.repItemLookupEdit_CotNhapExcel.AppearanceDropDown.Options.UseFont = true;
            this.repItemLookupEdit_CotNhapExcel.AppearanceDropDownHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.repItemLookupEdit_CotNhapExcel.AppearanceDropDownHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.repItemLookupEdit_CotNhapExcel.AppearanceDropDownHeader.Options.UseFont = true;
            this.repItemLookupEdit_CotNhapExcel.AutoHeight = false;
            this.repItemLookupEdit_CotNhapExcel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemLookupEdit_CotNhapExcel.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", 220, "Cột")});
            this.repItemLookupEdit_CotNhapExcel.DataSource = this.bsMapping;
            this.repItemLookupEdit_CotNhapExcel.DisplayMember = "ten";
            this.repItemLookupEdit_CotNhapExcel.Name = "repItemLookupEdit_CotNhapExcel";
            this.repItemLookupEdit_CotNhapExcel.NullText = "";
            this.repItemLookupEdit_CotNhapExcel.ValueMember = "ten";
            // 
            // bgw_import
            // 
            this.bgw_import.WorkerReportsProgress = true;
            this.bgw_import.WorkerSupportsCancellation = true;
            this.bgw_import.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_import_DoWork);
            this.bgw_import.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_import_ProgressChanged);
            this.bgw_import.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_import_RunWorkerCompleted);
            // 
            // Importer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 356);
            this.Controls.Add(this.xtraTabControl1);
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Name = "Importer";
            this.Load += new System.EventHandler(this.Importer_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemLookupEdit_CotNhapExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMapping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnDoImport;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit txtFilePath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.ProgressBarControl prg;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.BindingSource bsMapping;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemLookupEdit_CotNhapExcel;
        private System.ComponentModel.BackgroundWorker bgw_import;
        private System.Windows.Forms.Button btnAnalyze;
    }
}