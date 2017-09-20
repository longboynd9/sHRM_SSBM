namespace iHRM.Win.Frm.Common
{
    partial class dlgChonDoiTuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChonDoiTuong));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.chonPhongBan1 = new iHRM.Win.UC.ChonPhongBan();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.txtTenNV = new DevExpress.XtraEditors.LookUpEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnChoose_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(551, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Chọn";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textEdit2
            // 
            this.textEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit2.Location = new System.Drawing.Point(167, 195);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.textEdit2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.textEdit2.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEdit2.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.textEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEdit2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("gName", 220, "Nhóm")});
            this.textEdit2.Properties.DisplayMember = "gName";
            this.textEdit2.Properties.NullText = "";
            this.textEdit2.Properties.PopupSizeable = false;
            this.textEdit2.Properties.ValueMember = "id";
            this.textEdit2.Size = new System.Drawing.Size(390, 26);
            this.textEdit2.TabIndex = 6;
            this.textEdit2.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = null;
            this.checkEdit1.Location = new System.Drawing.Point(49, 128);
            this.checkEdit1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit1.Properties.Caption = "Nhân viên";
            this.checkEdit1.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit1.Properties.RadioGroupIndex = 1;
            this.checkEdit1.Size = new System.Drawing.Size(112, 23);
            this.checkEdit1.TabIndex = 6;
            this.checkEdit1.TabStop = false;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNV.Location = new System.Drawing.Point(167, 127);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Size = new System.Drawing.Size(122, 26);
            this.txtMaNV.TabIndex = 6;
            this.txtMaNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaNV_KeyDown);
            // 
            // checkEdit2
            // 
            this.checkEdit2.EditValue = null;
            this.checkEdit2.Location = new System.Drawing.Point(49, 162);
            this.checkEdit2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit2.Properties.Caption = "Phòng ban";
            this.checkEdit2.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit2.Properties.RadioGroupIndex = 1;
            this.checkEdit2.Size = new System.Drawing.Size(112, 23);
            this.checkEdit2.TabIndex = 6;
            this.checkEdit2.TabStop = false;
            // 
            // chonPhongBan1
            // 
            this.chonPhongBan1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.chonPhongBan1.Location = new System.Drawing.Point(167, 161);
            this.chonPhongBan1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chonPhongBan1.Name = "chonPhongBan1";
            this.chonPhongBan1.SelectedValue = null;
            this.chonPhongBan1.Size = new System.Drawing.Size(390, 28);
            this.chonPhongBan1.TabIndex = 7;
            this.chonPhongBan1.OnSelected += new System.EventHandler(this.chonPhongBan1_OnSelected);
            // 
            // checkEdit3
            // 
            this.checkEdit3.EditValue = null;
            this.checkEdit3.Location = new System.Drawing.Point(49, 196);
            this.checkEdit3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.checkEdit3.Properties.Appearance.Options.UseFont = true;
            this.checkEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit3.Properties.Caption = "Nhóm NV 1";
            this.checkEdit3.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
            this.checkEdit3.Properties.RadioGroupIndex = 1;
            this.checkEdit3.Size = new System.Drawing.Size(112, 23);
            this.checkEdit3.TabIndex = 6;
            this.checkEdit3.TabStop = false;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNV.Location = new System.Drawing.Point(295, 127);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Properties.Appearance.Options.UseFont = true;
            this.txtTenNV.Properties.NullText = "";
            this.txtTenNV.Properties.PopupSizeable = false;
            this.txtTenNV.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtTenNV.Size = new System.Drawing.Size(262, 26);
            this.txtTenNV.TabIndex = 6;
            this.txtTenNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUpEdit1_KeyDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::iHRM.Win.Properties.Resources.info;
            this.pictureEdit1.Location = new System.Drawing.Point(559, 127);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Size = new System.Drawing.Size(27, 26);
            this.pictureEdit1.TabIndex = 8;
            this.pictureEdit1.ToolTip = "ấn [Enter] để tìm kiếm";
            this.pictureEdit1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.pictureEdit1.ToolTipTitle = "Cách nhập liệu";
            // 
            // dlgChonDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 296);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.chonPhongBan1);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.txtMaNV);
            this.Form_Description = "Chọn đối tượng muốn đăng ký";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_ImageBg = ((System.Drawing.Image)(resources.GetObject("$this.Form_ImageBg")));
            this.Form_Title = "Chọn đối tượng";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgChonDoiTuong";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgChonDoiTuong_FormClosing);
            this.Load += new System.EventHandler(this.dlgChonDoiTuong_Load);
            this.Controls.SetChildIndex(this.txtMaNV, 0);
            this.Controls.SetChildIndex(this.checkEdit1, 0);
            this.Controls.SetChildIndex(this.checkEdit2, 0);
            this.Controls.SetChildIndex(this.checkEdit3, 0);
            this.Controls.SetChildIndex(this.textEdit2, 0);
            this.Controls.SetChildIndex(this.txtTenNV, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chonPhongBan1, 0);
            this.Controls.SetChildIndex(this.pictureEdit1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit textEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private UC.ChonPhongBan chonPhongBan1;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.LookUpEdit txtTenNV;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}