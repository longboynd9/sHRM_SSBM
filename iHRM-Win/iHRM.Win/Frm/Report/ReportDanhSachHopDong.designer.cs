namespace iHRM.Win.Frm.Report
{
    partial class ReportDanhSachHopDong
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
            this.label = new DevExpress.XtraEditors.PanelControl();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.lookupHopDong = new DevExpress.XtraEditors.LookUpEdit();
            this.grcBaoCaoDSHopDong = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeginDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.label)).BeginInit();
            this.label.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupHopDong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoDSHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Controls.Add(this.chonKyLuong1);
            this.label.Controls.Add(this.toolStrip1);
            this.label.Controls.Add(this.labelControl1);
            this.label.Controls.Add(this.ucChonDoiTuong_DS1);
            this.label.Controls.Add(this.lookupHopDong);
            this.label.Dock = System.Windows.Forms.DockStyle.Left;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(323, 484);
            this.label.TabIndex = 1;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2017, 9, 16, 0, 0, 0, 0);
            this.chonKyLuong1.isReadOnlyDenNgay = false;
            this.chonKyLuong1.isReadOnlyTuNgay = false;
            this.chonKyLuong1.isThang = false;
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(5, 32);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(159, 96);
            this.chonKyLuong1.TabIndex = 9;
            this.chonKyLuong1.TuNgay = new System.DateTime(2017, 8, 17, 0, 0, 0, 0);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(319, 26);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFind.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::iHRM.Win.Properties.Resources.btnFind_Image;
            this.btnFind.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(85, 23);
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Location = new System.Drawing.Point(5, 133);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 17);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Loại hợp đồng";
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(4, 188);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(313, 145);
            this.ucChonDoiTuong_DS1.TabIndex = 4;
            // 
            // lookupHopDong
            // 
            this.lookupHopDong.Location = new System.Drawing.Point(4, 156);
            this.lookupHopDong.Name = "lookupHopDong";
            this.lookupHopDong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupHopDong.Properties.Appearance.Options.UseFont = true;
            this.lookupHopDong.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookupHopDong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupHopDong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractTypeID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ContractTypeName", 70, "Loại hợp đồng")});
            this.lookupHopDong.Properties.DisplayMember = "ContractTypeName";
            this.lookupHopDong.Properties.NullText = "";
            this.lookupHopDong.Properties.ValueMember = "ContractTypeID";
            this.lookupHopDong.Size = new System.Drawing.Size(313, 26);
            this.lookupHopDong.TabIndex = 2;
            // 
            // grcBaoCaoDSHopDong
            // 
            this.grcBaoCaoDSHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcBaoCaoDSHopDong.Location = new System.Drawing.Point(323, 25);
            this.grcBaoCaoDSHopDong.MainView = this.grv;
            this.grcBaoCaoDSHopDong.Name = "grcBaoCaoDSHopDong";
            this.grcBaoCaoDSHopDong.Size = new System.Drawing.Size(1039, 459);
            this.grcBaoCaoDSHopDong.TabIndex = 0;
            this.grcBaoCaoDSHopDong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.ColumnPanelRowHeight = 25;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.gridColumn1,
            this.gridColumn2,
            this.colBeginDate,
            this.colEndDate,
            this.colContractTypeName,
            this.gridColumn3,
            this.gridColumn4});
            this.grv.GridControl = this.grcBaoCaoDSHopDong;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsBehavior.ReadOnly = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "Mã NV";
            this.colID.FieldName = "EmployeeID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 99;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên nhân viên";
            this.gridColumn1.FieldName = "EmployeeName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 182;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Phòng ban";
            this.gridColumn2.FieldName = "DepName_Final";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 211;
            // 
            // colBeginDate
            // 
            this.colBeginDate.AppearanceCell.Options.UseTextOptions = true;
            this.colBeginDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBeginDate.Caption = "Ngày bắt đầu";
            this.colBeginDate.FieldName = "BeginDate";
            this.colBeginDate.Name = "colBeginDate";
            this.colBeginDate.Visible = true;
            this.colBeginDate.VisibleIndex = 4;
            this.colBeginDate.Width = 111;
            // 
            // colEndDate
            // 
            this.colEndDate.AppearanceCell.Options.UseTextOptions = true;
            this.colEndDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndDate.Caption = "Ngày kết thúc";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 5;
            this.colEndDate.Width = 116;
            // 
            // colContractTypeName
            // 
            this.colContractTypeName.Caption = "Loại hợp đồng";
            this.colContractTypeName.FieldName = "ContractTypeName";
            this.colContractTypeName.Name = "colContractTypeName";
            this.colContractTypeName.Visible = true;
            this.colContractTypeName.VisibleIndex = 3;
            this.colContractTypeName.Width = 134;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(323, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1039, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = global::iHRM.Win.Properties.Resources.exxcel;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton2.Text = "Excel";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Lương cơ bản";
            this.gridColumn3.DisplayFormat.FormatString = "n0";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "BasicSalary";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 98;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Phụ cấp";
            this.gridColumn4.DisplayFormat.FormatString = "n0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "BasicSalary_Ins";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 91;
            // 
            // ReportDanhSachHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 484);
            this.Controls.Add(this.grcBaoCaoDSHopDong);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label);
            this.Name = "ReportDanhSachHopDong";
            this.Text = "Báo cáo danh sách hợp đồng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaoCaoDSHopDong_FormClosed);
            this.Load += new System.EventHandler(this.BaoCaoDSHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.label)).EndInit();
            this.label.ResumeLayout(false);
            this.label.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupHopDong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBaoCaoDSHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl label;
        private DevExpress.XtraEditors.LookUpEdit lookupHopDong;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private DevExpress.XtraGrid.GridControl grcBaoCaoDSHopDong;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colContractTypeName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private UC.ChonKyLuong chonKyLuong1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}