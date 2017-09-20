namespace iHRM.Win.UC
{
    partial class ucChonDoiTuong_DS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTenNV = new DevExpress.XtraEditors.LookUpEdit();
            this.textEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelCheck = new DevExpress.XtraEditors.PanelControl();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.panelDanhSach = new DevExpress.XtraEditors.PanelControl();
            this.mmMaNV = new DevExpress.XtraEditors.MemoEdit();
            this.rdLoaiDK = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheck)).BeginInit();
            this.panelCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelDanhSach)).BeginInit();
            this.panelDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLoaiDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNV.Location = new System.Drawing.Point(163, 5);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtTenNV.Properties.Appearance.Options.UseFont = true;
            this.txtTenNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTenNV.Properties.NullText = "";
            this.txtTenNV.Properties.PopupSizeable = false;
            this.txtTenNV.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtTenNV.Size = new System.Drawing.Size(82, 26);
            this.txtTenNV.TabIndex = 9;
            // 
            // textEdit2
            // 
            this.textEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit2.Location = new System.Drawing.Point(98, 67);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEdit2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.textEdit2.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEdit2.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.textEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.textEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEdit2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("gName", 220, "Nhóm")});
            this.textEdit2.Properties.DisplayMember = "gName";
            this.textEdit2.Properties.NullText = "";
            this.textEdit2.Properties.PopupSizeable = false;
            this.textEdit2.Properties.ValueMember = "id";
            this.textEdit2.Size = new System.Drawing.Size(181, 26);
            this.textEdit2.TabIndex = 10;
            this.textEdit2.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            // 
            // checkEdit3
            // 
            this.checkEdit3.EditValue = null;
            this.checkEdit3.Location = new System.Drawing.Point(5, 68);
            this.checkEdit3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.checkEdit3.Properties.Appearance.Options.UseFont = true;
            this.checkEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit3.Properties.Caption = "Nhóm NV:";
            this.checkEdit3.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit3.Properties.RadioGroupIndex = 1;
            this.checkEdit3.Size = new System.Drawing.Size(90, 22);
            this.checkEdit3.TabIndex = 11;
            this.checkEdit3.TabStop = false;
            // 
            // checkEdit2
            // 
            this.checkEdit2.EditValue = null;
            this.checkEdit2.Location = new System.Drawing.Point(5, 37);
            this.checkEdit2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit2.Properties.Caption = "Phòng ban:";
            this.checkEdit2.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit2.Properties.RadioGroupIndex = 1;
            this.checkEdit2.Size = new System.Drawing.Size(90, 22);
            this.checkEdit2.TabIndex = 12;
            this.checkEdit2.TabStop = false;
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = null;
            this.checkEdit1.Location = new System.Drawing.Point(5, 7);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit1.Properties.Caption = "Nhân viên:";
            this.checkEdit1.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit1.Properties.RadioGroupIndex = 1;
            this.checkEdit1.Size = new System.Drawing.Size(88, 22);
            this.checkEdit1.TabIndex = 13;
            this.checkEdit1.TabStop = false;
            // 
            // txtMaNV
            // 
            this.txtMaNV.EditValue = "";
            this.txtMaNV.Location = new System.Drawing.Point(98, 5);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMaNV.Size = new System.Drawing.Size(62, 26);
            this.txtMaNV.TabIndex = 14;
            this.txtMaNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaNV_KeyDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit1.EditValue = global::iHRM.Win.Properties.Resources.info;
            this.pictureEdit1.Location = new System.Drawing.Point(247, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Size = new System.Drawing.Size(32, 26);
            this.pictureEdit1.TabIndex = 16;
            this.pictureEdit1.ToolTip = "ấn [Enter] để tìm kiếm";
            this.pictureEdit1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.pictureEdit1.ToolTipTitle = "Cách nhập liệu";
            // 
            // panelCheck
            // 
            this.panelCheck.Controls.Add(this.checkEdit1);
            this.panelCheck.Controls.Add(this.pictureEdit1);
            this.panelCheck.Controls.Add(this.txtMaNV);
            this.panelCheck.Controls.Add(this.chonPhongBan1);
            this.panelCheck.Controls.Add(this.checkEdit2);
            this.panelCheck.Controls.Add(this.txtTenNV);
            this.panelCheck.Controls.Add(this.checkEdit3);
            this.panelCheck.Controls.Add(this.textEdit2);
            this.panelCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCheck.Location = new System.Drawing.Point(0, 35);
            this.panelCheck.Name = "panelCheck";
            this.panelCheck.Size = new System.Drawing.Size(286, 110);
            this.panelCheck.TabIndex = 17;
            this.panelCheck.Visible = false;
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.chonPhongBan1.Location = new System.Drawing.Point(98, 36);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(181, 28);
            this.chonPhongBan1.TabIndex = 15;
            this.chonPhongBan1.OnSelected += new System.EventHandler(this.chonPhongBan1_OnSelected);
            // 
            // panelDanhSach
            // 
            this.panelDanhSach.Controls.Add(this.mmMaNV);
            this.panelDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDanhSach.Location = new System.Drawing.Point(0, 35);
            this.panelDanhSach.Name = "panelDanhSach";
            this.panelDanhSach.Size = new System.Drawing.Size(286, 110);
            this.panelDanhSach.TabIndex = 26;
            // 
            // mmMaNV
            // 
            this.mmMaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmMaNV.Location = new System.Drawing.Point(2, 2);
            this.mmMaNV.Name = "mmMaNV";
            this.mmMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmMaNV.Properties.Appearance.Options.UseFont = true;
            this.mmMaNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.mmMaNV.Size = new System.Drawing.Size(282, 106);
            this.mmMaNV.TabIndex = 21;
            // 
            // rdLoaiDK
            // 
            this.rdLoaiDK.EditValue = ((short)(0));
            this.rdLoaiDK.Location = new System.Drawing.Point(79, 5);
            this.rdLoaiDK.Name = "rdLoaiDK";
            this.rdLoaiDK.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLoaiDK.Properties.Appearance.Options.UseFont = true;
            this.rdLoaiDK.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.rdLoaiDK.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Loại danh sách"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Loại Check")});
            this.rdLoaiDK.Size = new System.Drawing.Size(202, 23);
            this.rdLoaiDK.TabIndex = 24;
            this.rdLoaiDK.SelectedIndexChanged += new System.EventHandler(this.rdLoaiDK_SelectedIndexChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Location = new System.Drawing.Point(1, 8);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 17);
            this.labelControl7.TabIndex = 23;
            this.labelControl7.Text = "DS mã NV:";
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.rdLoaiDK);
            this.panelTitle.Controls.Add(this.labelControl7);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(286, 35);
            this.panelTitle.TabIndex = 25;
            // 
            // ucChonDoiTuong_DS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDanhSach);
            this.Controls.Add(this.panelCheck);
            this.Controls.Add(this.panelTitle);
            this.Name = "ucChonDoiTuong_DS";
            this.Size = new System.Drawing.Size(286, 145);
            this.Load += new System.EventHandler(this.ucChonDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCheck)).EndInit();
            this.panelCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelDanhSach)).EndInit();
            this.panelDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mmMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLoaiDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.LookUpEdit txtTenNV;
        private DevExpress.XtraEditors.LookUpEdit textEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.PanelControl panelCheck;
        private DevExpress.XtraEditors.RadioGroup rdLoaiDK;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PanelControl panelTitle;
        private DevExpress.XtraEditors.PanelControl panelDanhSach;
        private DevExpress.XtraEditors.MemoEdit mmMaNV;
    }
}
