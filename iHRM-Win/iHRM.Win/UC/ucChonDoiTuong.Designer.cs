namespace iHRM.Win.UC
{
    partial class ucChonDoiTuong
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
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.txtTenNV = new DevExpress.XtraEditors.LookUpEdit();
            this.textEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.chonPhongBan1.Location = new System.Drawing.Point(93, 59);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(247, 28);
            this.chonPhongBan1.TabIndex = 15;
            this.chonPhongBan1.OnSelected += new System.EventHandler(this.chonPhongBan1_OnSelected);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNV.Location = new System.Drawing.Point(158, 1);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtTenNV.Properties.Appearance.Options.UseFont = true;
            this.txtTenNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTenNV.Properties.NullText = "";
            this.txtTenNV.Properties.PopupSizeable = false;
            this.txtTenNV.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtTenNV.Size = new System.Drawing.Size(154, 26);
            this.txtTenNV.TabIndex = 9;
            this.txtTenNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUpEdit1_KeyDown);
            // 
            // textEdit2
            // 
            this.textEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit2.Location = new System.Drawing.Point(93, 30);
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
            this.textEdit2.Size = new System.Drawing.Size(247, 26);
            this.textEdit2.TabIndex = 10;
            this.textEdit2.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            // 
            // checkEdit3
            // 
            this.checkEdit3.EditValue = null;
            this.checkEdit3.Location = new System.Drawing.Point(0, 31);
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
            this.checkEdit2.Location = new System.Drawing.Point(0, 60);
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
            this.checkEdit1.Location = new System.Drawing.Point(0, 3);
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
            this.txtMaNV.Location = new System.Drawing.Point(93, 1);
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
            this.pictureEdit1.Location = new System.Drawing.Point(313, 1);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Size = new System.Drawing.Size(27, 26);
            this.pictureEdit1.TabIndex = 16;
            this.pictureEdit1.ToolTip = "ấn [Enter] để tìm kiếm";
            this.pictureEdit1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.pictureEdit1.ToolTipTitle = "Cách nhập liệu";
            // 
            // ucChonDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.chonPhongBan1);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.txtMaNV);
            this.Name = "ucChonDoiTuong";
            this.Size = new System.Drawing.Size(350, 95);
            this.Load += new System.EventHandler(this.ucChonDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
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
    }
}
