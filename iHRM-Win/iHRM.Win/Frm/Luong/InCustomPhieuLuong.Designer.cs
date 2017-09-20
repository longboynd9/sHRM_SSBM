namespace iHRM.Win.Frm.Luong
{
    partial class InCustomPhieuLuong
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
            this.btnInPhieu = new DevExpress.XtraEditors.SimpleButton();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
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
            this.textStrNhanVien = new System.Windows.Forms.RichTextBox();
            this.btnInPhieu1Dong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnInPhieu.Appearance.Options.UseFont = true;
            this.btnInPhieu.Location = new System.Drawing.Point(195, 12);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(148, 35);
            this.btnInPhieu.TabIndex = 1;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2016, 10, 16, 0, 0, 0, 0);
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(0, 0);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(189, 99);
            this.chonKyLuong1.TabIndex = 2;
            this.chonKyLuong1.TuNgay = new System.DateTime(2016, 9, 17, 0, 0, 0, 0);
            // 
            // grcEmployee
            // 
            this.grcEmployee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grcEmployee.Location = new System.Drawing.Point(0, 96);
            this.grcEmployee.MainView = this.grvEmployee;
            this.grcEmployee.Name = "grcEmployee";
            this.grcEmployee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkEmp});
            this.grcEmployee.Size = new System.Drawing.Size(904, 393);
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
            this.colCheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
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
            this.colEmpID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
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
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
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
            this.colBoPhan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
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
            this.colCMND.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
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
            this.colNgayVao.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
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
            this.colNgaySinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // textStrNhanVien
            // 
            this.textStrNhanVien.Location = new System.Drawing.Point(365, 0);
            this.textStrNhanVien.Name = "textStrNhanVien";
            this.textStrNhanVien.Size = new System.Drawing.Size(539, 96);
            this.textStrNhanVien.TabIndex = 4;
            this.textStrNhanVien.Text = "";
            // 
            // btnInPhieu1Dong
            // 
            this.btnInPhieu1Dong.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnInPhieu1Dong.Appearance.Options.UseFont = true;
            this.btnInPhieu1Dong.Location = new System.Drawing.Point(195, 53);
            this.btnInPhieu1Dong.Name = "btnInPhieu1Dong";
            this.btnInPhieu1Dong.Size = new System.Drawing.Size(148, 35);
            this.btnInPhieu1Dong.TabIndex = 1;
            this.btnInPhieu1Dong.Text = "In phiếu 1 dòng";
            this.btnInPhieu1Dong.Click += new System.EventHandler(this.btnInPhieu1Dong_Click);
            // 
            // InCustomPhieuLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 489);
            this.Controls.Add(this.textStrNhanVien);
            this.Controls.Add(this.grcEmployee);
            this.Controls.Add(this.chonKyLuong1);
            this.Controls.Add(this.btnInPhieu1Dong);
            this.Controls.Add(this.btnInPhieu);
            this.Name = "InCustomPhieuLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InCustomPhieuLuong";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InCustomPhieuLuong_FormClosed);
            this.Load += new System.EventHandler(this.InCustomPhieuLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnInPhieu;
        private UC.ChonKyLuong chonKyLuong1;
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
        private System.Windows.Forms.RichTextBox textStrNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnInPhieu1Dong;
    }
}