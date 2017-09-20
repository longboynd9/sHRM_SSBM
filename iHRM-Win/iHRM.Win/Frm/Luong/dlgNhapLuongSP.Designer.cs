namespace iHRM.Win.Frm.Luong
{
    partial class dlgNhapLuongSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgNhapLuongSP));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateThang = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLuongSP = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenNV = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Size = new System.Drawing.Size(508, 70);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(422, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "  Đăng ký";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.labelControl3.Location = new System.Drawing.Point(53, 131);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Tháng:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dateThang
            // 
            this.dateThang.EditValue = null;
            this.dateThang.Location = new System.Drawing.Point(150, 127);
            this.dateThang.Name = "dateThang";
            this.dateThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dateThang.Properties.Appearance.Options.UseFont = true;
            this.dateThang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dateThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateThang.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dateThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateThang.Properties.EditFormat.FormatString = "MM/yyyy";
            this.dateThang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateThang.Properties.Mask.EditMask = "";
            this.dateThang.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateThang.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
            this.dateThang.Size = new System.Drawing.Size(117, 28);
            this.dateThang.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.labelControl4.Location = new System.Drawing.Point(53, 164);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 19);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Lương SP:";
            // 
            // txtLuongSP
            // 
            this.txtLuongSP.Location = new System.Drawing.Point(150, 161);
            this.txtLuongSP.Name = "txtLuongSP";
            this.txtLuongSP.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongSP.Properties.Appearance.Options.UseFont = true;
            this.txtLuongSP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtLuongSP.Properties.Mask.EditMask = "n0";
            this.txtLuongSP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLuongSP.Size = new System.Drawing.Size(117, 28);
            this.txtLuongSP.TabIndex = 10;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(150, 93);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMaNV.Size = new System.Drawing.Size(83, 28);
            this.txtMaNV.TabIndex = 12;
            this.txtMaNV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaNV_KeyDown);
            this.txtMaNV.Leave += new System.EventHandler(this.txtMaNV_Leave);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.labelControl5.Location = new System.Drawing.Point(53, 97);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 19);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Mã NV:";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(237, 93);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Properties.Appearance.Options.UseFont = true;
            this.txtTenNV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTenNV.Size = new System.Drawing.Size(184, 28);
            this.txtTenNV.TabIndex = 10;
            // 
            // dlgNhapLuongSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 336);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.txtLuongSP);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dateThang);
            this.Form_Description = "Nhập lương sản phẩm cho nhân viên";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Nhập lương sản phẩm";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgNhapLuongSP";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Controls.SetChildIndex(this.dateThang, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.txtLuongSP, 0);
            this.Controls.SetChildIndex(this.txtTenNV, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.txtMaNV, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.DateEdit dateThang;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLuongSP;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtTenNV;
    }
}