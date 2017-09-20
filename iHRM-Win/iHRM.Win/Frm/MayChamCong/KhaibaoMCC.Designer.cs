namespace iHRM.Win.Frm.MayChamCong
{
    partial class KhaibaoMCC
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
            this.grcKhaibaoMCC = new DevExpress.XtraGrid.GridControl();
            this.grvKhaibaoMCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.menuSave_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh_LuongCB = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcKhaibaoMCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKhaibaoMCC)).BeginInit();
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
            this.groupControl1.Controls.Add(this.grcKhaibaoMCC);
            this.groupControl1.Controls.Add(this.menuStrip3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(925, 423);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách máy chấm công";
            // 
            // grcKhaibaoMCC
            // 
            this.grcKhaibaoMCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcKhaibaoMCC.Location = new System.Drawing.Point(2, 56);
            this.grcKhaibaoMCC.MainView = this.grvKhaibaoMCC;
            this.grcKhaibaoMCC.Name = "grcKhaibaoMCC";
            this.grcKhaibaoMCC.Size = new System.Drawing.Size(921, 365);
            this.grcKhaibaoMCC.TabIndex = 4;
            this.grcKhaibaoMCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKhaibaoMCC});
            // 
            // grvKhaibaoMCC
            // 
            this.grvKhaibaoMCC.ColumnPanelRowHeight = 30;
            this.grvKhaibaoMCC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grvKhaibaoMCC.GridControl = this.grcKhaibaoMCC;
            this.grvKhaibaoMCC.Name = "grvKhaibaoMCC";
            this.grvKhaibaoMCC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grvKhaibaoMCC.OptionsView.ShowAutoFilterRow = true;
            this.grvKhaibaoMCC.OptionsView.ShowGroupPanel = false;
            this.grvKhaibaoMCC.RowHeight = 26;
            this.grvKhaibaoMCC.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grvKhaibaoMCC_InitNewRow_1);
            this.grvKhaibaoMCC.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvKhaiBaoMCC_CustomUnboundColumnData);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
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
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Số máy";
            this.gridColumn2.FieldName = "soMay";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên máy";
            this.gridColumn3.FieldName = "tenMay";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Địa chỉ IP";
            this.gridColumn4.FieldName = "diaChiIP";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Port";
            this.gridColumn5.FieldName = "port";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
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
            this.panelControl1.Size = new System.Drawing.Size(925, 423);
            this.panelControl1.TabIndex = 1;
            // 
            // KhaibaoMCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 423);
            this.Controls.Add(this.panelControl1);
            this.Name = "KhaibaoMCC";
            this.Text = "Khai báo máy chấm công";
            this.Load += new System.EventHandler(this.KhaibaoMCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcKhaibaoMCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKhaibaoMCC)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grcKhaibaoMCC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKhaibaoMCC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}