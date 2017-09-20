namespace iHRM.Win.Frm.Employee
{
    partial class InTheNhanVien
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
            this.btnInThe = new DevExpress.XtraEditors.SimpleButton();
            this.grcEmployee = new DevExpress.XtraGrid.GridControl();
            this.grvEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkEmp = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colEmpID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupInHoSo = new DevExpress.XtraEditors.GroupControl();
            this.pnBienBanCC = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ngayLapBB = new DevExpress.XtraEditors.DateEdit();
            this.ngayViPham = new DevExpress.XtraEditors.DateEdit();
            this.rdGroupInHD = new DevExpress.XtraEditors.RadioGroup();
            this.memoMaNV = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInHoSo)).BeginInit();
            this.groupInHoSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnBienBanCC)).BeginInit();
            this.pnBienBanCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngayLapBB.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayLapBB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayViPham.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayViPham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdGroupInHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMaNV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInThe
            // 
            this.btnInThe.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInThe.Appearance.Options.UseFont = true;
            this.btnInThe.Image = global::iHRM.Win.Properties.Resources.btnPrint_Image;
            this.btnInThe.Location = new System.Drawing.Point(0, 54);
            this.btnInThe.Name = "btnInThe";
            this.btnInThe.Size = new System.Drawing.Size(160, 35);
            this.btnInThe.TabIndex = 1;
            this.btnInThe.Text = "In thẻ";
            this.btnInThe.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // grcEmployee
            // 
            this.grcEmployee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grcEmployee.Location = new System.Drawing.Point(0, 114);
            this.grcEmployee.MainView = this.grvEmployee;
            this.grcEmployee.Name = "grcEmployee";
            this.grcEmployee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkEmp});
            this.grcEmployee.Size = new System.Drawing.Size(904, 375);
            this.grcEmployee.TabIndex = 3;
            this.grcEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployee});
            // 
            // grvEmployee
            // 
            this.grvEmployee.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvEmployee.Appearance.Row.Options.UseFont = true;
            this.grvEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheck,
            this.colEmpID,
            this.colName,
            this.colBoPhan,
            this.colCMND,
            this.colNgayVao,
            this.colNgaySinh});
            this.grvEmployee.GridControl = this.grcEmployee;
            this.grvEmployee.Name = "grvEmployee";
            this.grvEmployee.OptionsView.ShowAutoFilterRow = true;
            this.grvEmployee.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.grvEmployee.OptionsView.ShowGroupPanel = false;
            // 
            // colCheck
            // 
            this.colCheck.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colCheck.AppearanceCell.Options.UseFont = true;
            this.colCheck.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCheck.AppearanceHeader.Options.UseFont = true;
            this.colCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCheck.Caption = "Chọn";
            this.colCheck.ColumnEdit = this.chkEmp;
            this.colCheck.FieldName = "chkEmp";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 0;
            this.colCheck.Width = 41;
            // 
            // chkEmp
            // 
            this.chkEmp.AutoHeight = false;
            this.chkEmp.Name = "chkEmp";
            // 
            // colEmpID
            // 
            this.colEmpID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colEmpID.AppearanceCell.Options.UseFont = true;
            this.colEmpID.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEmpID.AppearanceHeader.Options.UseFont = true;
            this.colEmpID.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmpID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmpID.Caption = "Mã NV";
            this.colEmpID.FieldName = "EmployeeID";
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.OptionsColumn.AllowEdit = false;
            this.colEmpID.Visible = true;
            this.colEmpID.VisibleIndex = 1;
            this.colEmpID.Width = 65;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colName.AppearanceCell.Options.UseFont = true;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Họ Tên";
            this.colName.FieldName = "EmployeeName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 151;
            // 
            // colBoPhan
            // 
            this.colBoPhan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colBoPhan.AppearanceCell.Options.UseFont = true;
            this.colBoPhan.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colBoPhan.AppearanceHeader.Options.UseFont = true;
            this.colBoPhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colBoPhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBoPhan.Caption = "Bộ Phận";
            this.colBoPhan.FieldName = "DepName";
            this.colBoPhan.Name = "colBoPhan";
            this.colBoPhan.OptionsColumn.AllowEdit = false;
            this.colBoPhan.Visible = true;
            this.colBoPhan.VisibleIndex = 6;
            this.colBoPhan.Width = 330;
            // 
            // colCMND
            // 
            this.colCMND.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colCMND.AppearanceCell.Options.UseFont = true;
            this.colCMND.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCMND.AppearanceHeader.Options.UseFont = true;
            this.colCMND.AppearanceHeader.Options.UseTextOptions = true;
            this.colCMND.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCMND.Caption = "Số CMND";
            this.colCMND.FieldName = "IDCard";
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsColumn.AllowEdit = false;
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 3;
            this.colCMND.Width = 83;
            // 
            // colNgayVao
            // 
            this.colNgayVao.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgayVao.AppearanceCell.Options.UseFont = true;
            this.colNgayVao.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNgayVao.AppearanceHeader.Options.UseFont = true;
            this.colNgayVao.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayVao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVao.Caption = "Ngày vào";
            this.colNgayVao.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayVao.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayVao.FieldName = "AppliedDate";
            this.colNgayVao.Name = "colNgayVao";
            this.colNgayVao.OptionsColumn.AllowEdit = false;
            this.colNgayVao.Visible = true;
            this.colNgayVao.VisibleIndex = 5;
            this.colNgayVao.Width = 76;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.colNgaySinh.AppearanceCell.Options.UseFont = true;
            this.colNgaySinh.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNgaySinh.AppearanceHeader.Options.UseFont = true;
            this.colNgaySinh.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgaySinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgaySinh.Caption = "Ngày sinh";
            this.colNgaySinh.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgaySinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgaySinh.FieldName = "Birthday";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.OptionsColumn.AllowEdit = false;
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 4;
            this.colNgaySinh.Width = 74;
            // 
            // groupInHoSo
            // 
            this.groupInHoSo.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInHoSo.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupInHoSo.AppearanceCaption.Options.UseFont = true;
            this.groupInHoSo.AppearanceCaption.Options.UseForeColor = true;
            this.groupInHoSo.Controls.Add(this.memoMaNV);
            this.groupInHoSo.Controls.Add(this.pnBienBanCC);
            this.groupInHoSo.Controls.Add(this.btnInThe);
            this.groupInHoSo.Controls.Add(this.rdGroupInHD);
            this.groupInHoSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupInHoSo.Location = new System.Drawing.Point(0, 0);
            this.groupInHoSo.Name = "groupInHoSo";
            this.groupInHoSo.Size = new System.Drawing.Size(904, 116);
            this.groupInHoSo.TabIndex = 4;
            this.groupInHoSo.Text = "In thẻ công nhân viên";
            // 
            // pnBienBanCC
            // 
            this.pnBienBanCC.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnBienBanCC.Controls.Add(this.labelControl2);
            this.pnBienBanCC.Controls.Add(this.labelControl1);
            this.pnBienBanCC.Controls.Add(this.ngayLapBB);
            this.pnBienBanCC.Controls.Add(this.ngayViPham);
            this.pnBienBanCC.Location = new System.Drawing.Point(161, 35);
            this.pnBienBanCC.Name = "pnBienBanCC";
            this.pnBienBanCC.Size = new System.Drawing.Size(202, 71);
            this.pnBienBanCC.TabIndex = 4;
            this.pnBienBanCC.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(2, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 15);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Ngày lập biên bản:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(2, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 15);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Ngày vi phạm:";
            // 
            // ngayLapBB
            // 
            this.ngayLapBB.EditValue = null;
            this.ngayLapBB.Location = new System.Drawing.Point(95, 28);
            this.ngayLapBB.Name = "ngayLapBB";
            this.ngayLapBB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayLapBB.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayLapBB.Size = new System.Drawing.Size(100, 20);
            this.ngayLapBB.TabIndex = 1;
            // 
            // ngayViPham
            // 
            this.ngayViPham.EditValue = null;
            this.ngayViPham.Location = new System.Drawing.Point(95, 6);
            this.ngayViPham.Name = "ngayViPham";
            this.ngayViPham.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayViPham.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngayViPham.Size = new System.Drawing.Size(100, 20);
            this.ngayViPham.TabIndex = 0;
            // 
            // rdGroupInHD
            // 
            this.rdGroupInHD.EditValue = 0;
            this.rdGroupInHD.Location = new System.Drawing.Point(161, 35);
            this.rdGroupInHD.Name = "rdGroupInHD";
            this.rdGroupInHD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdGroupInHD.Properties.Appearance.Options.UseFont = true;
            this.rdGroupInHD.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "In hợp đồng công nhân thử việc"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "In hợp đồng nhân viên thử việc"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "In hợp đồng công nhân 1 năm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "In hợp đồng nhân viên 1 năm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "In hợp đồng công nhân vô thời hạn"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "In hợp đồng nhân viên vô thời hạn")});
            this.rdGroupInHD.Size = new System.Drawing.Size(420, 71);
            this.rdGroupInHD.TabIndex = 3;
            this.rdGroupInHD.Visible = false;
            // 
            // memoMaNV
            // 
            this.memoMaNV.Location = new System.Drawing.Point(587, 23);
            this.memoMaNV.Name = "memoMaNV";
            this.memoMaNV.Size = new System.Drawing.Size(317, 92);
            this.memoMaNV.TabIndex = 5;
            // 
            // InTheNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 489);
            this.Controls.Add(this.groupInHoSo);
            this.Controls.Add(this.grcEmployee);
            this.Name = "InTheNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In thẻ nhân viên";
            this.Load += new System.EventHandler(this.InCustomPhieuLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInHoSo)).EndInit();
            this.groupInHoSo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnBienBanCC)).EndInit();
            this.pnBienBanCC.ResumeLayout(false);
            this.pnBienBanCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngayLapBB.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayLapBB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayViPham.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngayViPham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdGroupInHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMaNV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnInThe;
        private DevExpress.XtraGrid.GridControl grcEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEmp;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBoPhan;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVao;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraEditors.GroupControl groupInHoSo;
        private DevExpress.XtraEditors.RadioGroup rdGroupInHD;
        private DevExpress.XtraEditors.PanelControl pnBienBanCC;
        private DevExpress.XtraEditors.DateEdit ngayLapBB;
        private DevExpress.XtraEditors.DateEdit ngayViPham;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoMaNV;
    }
}