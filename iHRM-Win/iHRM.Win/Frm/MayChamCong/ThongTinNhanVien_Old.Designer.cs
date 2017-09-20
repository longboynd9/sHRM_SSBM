namespace iHRM.Win.Frm.MayChamCong
{
    partial class ThongTinNhanVien_Old
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grcTTNV = new DevExpress.XtraGrid.GridControl();
            this.grvTTNV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnSoTheQuet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnMaThesHRM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.menuSave_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTTNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTTNV)).BeginInit();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.grcTTNV);
            this.groupControl1.Controls.Add(this.menuStrip3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(925, 454);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách nhân viên";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.labelControl1.LineColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(694, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(227, 16);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Loại nhân viên. 0:User.  3: Administrator";
            // 
            // grcTTNV
            // 
            this.grcTTNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTTNV.Location = new System.Drawing.Point(2, 56);
            this.grcTTNV.MainView = this.grvTTNV;
            this.grcTTNV.Name = "grcTTNV";
            this.grcTTNV.Size = new System.Drawing.Size(921, 396);
            this.grcTTNV.TabIndex = 4;
            this.grcTTNV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTTNV});
            // 
            // grvTTNV
            // 
            this.grvTTNV.ColumnPanelRowHeight = 30;
            this.grvTTNV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.columnSoTheQuet,
            this.columnMaThesHRM,
            this.gridColumn2});
            this.grvTTNV.GridControl = this.grcTTNV;
            this.grvTTNV.Name = "grvTTNV";
            this.grvTTNV.NewItemRowText = "Nhập nhân viên mới";
            this.grvTTNV.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvTTNV.OptionsView.RowAutoHeight = true;
            this.grvTTNV.OptionsView.ShowAutoFilterRow = true;
            this.grvTTNV.OptionsView.ShowGroupPanel = false;
            this.grvTTNV.RowHeight = 26;
            this.grvTTNV.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvKhaibaoMCC_InitNewRow_1);
            this.grvTTNV.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTTNV_CellValueChanged);
            this.grvTTNV.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvKhaiBaoMCC_CustomUnboundColumnData);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsColumn.TabStop = false;
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Mã Chấm Công";
            this.gridColumn3.FieldName = "maChamCong";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Tên Chấm Công";
            this.gridColumn4.FieldName = "tenChamCong";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 150;
            // 
            // columnSoTheQuet
            // 
            this.columnSoTheQuet.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.columnSoTheQuet.AppearanceCell.Options.UseFont = true;
            this.columnSoTheQuet.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.columnSoTheQuet.AppearanceHeader.Options.UseFont = true;
            this.columnSoTheQuet.AppearanceHeader.Options.UseTextOptions = true;
            this.columnSoTheQuet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnSoTheQuet.Caption = "Số Thẻ ( Thẻ Quẹt)";
            this.columnSoTheQuet.FieldName = "maThe";
            this.columnSoTheQuet.Name = "columnSoTheQuet";
            this.columnSoTheQuet.Visible = true;
            this.columnSoTheQuet.VisibleIndex = 4;
            this.columnSoTheQuet.Width = 150;
            // 
            // columnMaThesHRM
            // 
            this.columnMaThesHRM.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.columnMaThesHRM.AppearanceCell.Options.UseFont = true;
            this.columnMaThesHRM.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.columnMaThesHRM.AppearanceHeader.Options.UseFont = true;
            this.columnMaThesHRM.AppearanceHeader.Options.UseTextOptions = true;
            this.columnMaThesHRM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.columnMaThesHRM.Caption = "Mã Thẻ sHRM";
            this.columnMaThesHRM.FieldName = "maThesHRM";
            this.columnMaThesHRM.Name = "columnMaThesHRM";
            this.columnMaThesHRM.Visible = true;
            this.columnMaThesHRM.VisibleIndex = 5;
            this.columnMaThesHRM.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Loại nhân viên";
            this.gridColumn2.FieldName = "loaiNhanVien";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 105;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave_LuongCB,
            this.menuDelete_LuongCB,
            this.menuRefresh_LuongCB});
            this.menuStrip3.Location = new System.Drawing.Point(2, 27);
            this.menuStrip3.MinimumSize = new System.Drawing.Size(0, 29);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip3.Size = new System.Drawing.Size(921, 29);
            this.menuStrip3.TabIndex = 3;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // menuSave_LuongCB
            // 
            this.menuSave_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuSave_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnExit_Image;
            this.menuSave_LuongCB.Name = "menuSave_LuongCB";
            this.menuSave_LuongCB.Size = new System.Drawing.Size(63, 25);
            this.menuSave_LuongCB.Text = "Save";
            this.menuSave_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuSave_LuongCB.Click += new System.EventHandler(this.menuSave_LuongCB_Click);
            // 
            // menuDelete_LuongCB
            // 
            this.menuDelete_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuDelete_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnDelete_Image;
            this.menuDelete_LuongCB.Name = "menuDelete_LuongCB";
            this.menuDelete_LuongCB.Size = new System.Drawing.Size(71, 25);
            this.menuDelete_LuongCB.Text = "Delete";
            this.menuDelete_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuDelete_LuongCB.Click += new System.EventHandler(this.menuDelete_LuongCB_Click);
            // 
            // menuRefresh_LuongCB
            // 
            this.menuRefresh_LuongCB.Font = new System.Drawing.Font("Times New Roman", 10.25F);
            this.menuRefresh_LuongCB.Image = global::iHRM.Win.Properties.Resources.btnRefresh_Image;
            this.menuRefresh_LuongCB.Name = "menuRefresh_LuongCB";
            this.menuRefresh_LuongCB.Size = new System.Drawing.Size(80, 25);
            this.menuRefresh_LuongCB.Text = "Refresh";
            this.menuRefresh_LuongCB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menuRefresh_LuongCB.Click += new System.EventHandler(this.menuRefresh_LuongCB_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(925, 454);
            this.panelControl1.TabIndex = 1;
            // 
            // ThongTinNhanVien_Old
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 454);
            this.Controls.Add(this.panelControl1);
            this.Name = "ThongTinNhanVien_Old";
            this.Text = "Danh sách thông tin nhân viên";
            this.Load += new System.EventHandler(this.KhaibaoMCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTTNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTTNV)).EndInit();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem menuSave_LuongCB;
        private System.Windows.Forms.ToolStripMenuItem menuDelete_LuongCB;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh_LuongCB;
        private DevExpress.XtraGrid.GridControl grcTTNV;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTTNV;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn columnSoTheQuet;
        private DevExpress.XtraGrid.Columns.GridColumn columnMaThesHRM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}