namespace iHRM.Win.Frm.QuetThe
{
    partial class dlgDangKyLamThem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDangKyLamThem));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.txtDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCaLam = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.chkRegSunday = new DevExpress.XtraEditors.CheckEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtLyDoLamThem = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtHSL = new DevExpress.XtraEditors.CalcEdit();
            this.ucChonDoiTuong1 = new iHRM.Win.UC.ucChonDoiTuong();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaLam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRegSunday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDoLamThem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHSL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(551, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "  Đăng ký";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Location = new System.Drawing.Point(82, 210);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Từ ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.EditValue = null;
            this.txtTuNgay.Location = new System.Drawing.Point(179, 207);
            this.txtTuNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTuNgay.Properties.Appearance.Options.UseFont = true;
            this.txtTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.Mask.EditMask = "";
            this.txtTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtTuNgay.Size = new System.Drawing.Size(144, 26);
            this.txtTuNgay.TabIndex = 6;
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.EditValue = null;
            this.txtDenNgay.Location = new System.Drawing.Point(425, 207);
            this.txtDenNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDenNgay.Properties.Appearance.Options.UseFont = true;
            this.txtDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.Mask.EditMask = "";
            this.txtDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDenNgay.Size = new System.Drawing.Size(144, 26);
            this.txtDenNgay.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Location = new System.Drawing.Point(357, 210);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 19);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Tới ngày";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Location = new System.Drawing.Point(82, 244);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 19);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Ca làm";
            // 
            // txtCaLam
            // 
            this.txtCaLam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaLam.Location = new System.Drawing.Point(179, 241);
            this.txtCaLam.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtCaLam.Name = "txtCaLam";
            this.txtCaLam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCaLam.Properties.Appearance.Options.UseFont = true;
            this.txtCaLam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCaLam.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ten", 220, "Ca làm")});
            this.txtCaLam.Properties.DisplayMember = "ten";
            this.txtCaLam.Properties.NullText = "";
            this.txtCaLam.Properties.PopupSizeable = false;
            this.txtCaLam.Properties.ValueMember = "id";
            this.txtCaLam.Size = new System.Drawing.Size(390, 26);
            this.txtCaLam.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl6.Location = new System.Drawing.Point(82, 311);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(82, 19);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Reg sunday";
            // 
            // chkRegSunday
            // 
            this.chkRegSunday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRegSunday.EditValue = null;
            this.chkRegSunday.Location = new System.Drawing.Point(179, 308);
            this.chkRegSunday.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chkRegSunday.Name = "chkRegSunday";
            this.chkRegSunday.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkRegSunday.Properties.Appearance.Options.UseFont = true;
            this.chkRegSunday.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkRegSunday.Properties.Caption = "200% salary";
            this.chkRegSunday.Size = new System.Drawing.Size(144, 23);
            this.chkRegSunday.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtLyDoLamThem
            // 
            this.txtLyDoLamThem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLyDoLamThem.Location = new System.Drawing.Point(179, 274);
            this.txtLyDoLamThem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtLyDoLamThem.Name = "txtLyDoLamThem";
            this.txtLyDoLamThem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLyDoLamThem.Properties.Appearance.Options.UseFont = true;
            this.txtLyDoLamThem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLyDoLamThem.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenLoai", 220, "Lý do"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("heSoLuong", 55, "HSL")});
            this.txtLyDoLamThem.Properties.DisplayMember = "tenLoai";
            this.txtLyDoLamThem.Properties.NullText = "";
            this.txtLyDoLamThem.Properties.PopupSizeable = false;
            this.txtLyDoLamThem.Properties.ValueMember = "id";
            this.txtLyDoLamThem.Size = new System.Drawing.Size(144, 26);
            this.txtLyDoLamThem.TabIndex = 6;
            this.txtLyDoLamThem.EditValueChanged += new System.EventHandler(this.txtLyDoLamThem_EditValueChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl7.Location = new System.Drawing.Point(82, 277);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(39, 19);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "Lý do";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl8.Location = new System.Drawing.Point(333, 277);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(86, 19);
            this.labelControl8.TabIndex = 5;
            this.labelControl8.Text = "Hệ số lương";
            // 
            // txtHSL
            // 
            this.txtHSL.Location = new System.Drawing.Point(425, 274);
            this.txtHSL.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtHSL.Name = "txtHSL";
            this.txtHSL.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtHSL.Properties.Appearance.Options.UseFont = true;
            this.txtHSL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHSL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtHSL.Size = new System.Drawing.Size(144, 26);
            this.txtHSL.TabIndex = 6;
            // 
            // ucChonDoiTuong1
            // 
            this.ucChonDoiTuong1.Location = new System.Drawing.Point(61, 105);
            this.ucChonDoiTuong1.Name = "ucChonDoiTuong1";
            this.ucChonDoiTuong1.SelectedIndex = 0;
            this.ucChonDoiTuong1.SelectedValue = "";
            this.ucChonDoiTuong1.Size = new System.Drawing.Size(537, 94);
            this.ucChonDoiTuong1.TabIndex = 7;
            // 
            // dlgDangKyLamThem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 424);
            this.Controls.Add(this.ucChonDoiTuong1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.txtLyDoLamThem);
            this.Controls.Add(this.txtCaLam);
            this.Controls.Add(this.chkRegSunday);
            this.Controls.Add(this.txtHSL);
            this.Form_Description = "Thiết lập ca làm việc trong những ngày làm thêm";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Đăng ký làm thêm";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDangKyLamThem";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Load += new System.EventHandler(this.dlgDangKyCaLam_Load);
            this.Controls.SetChildIndex(this.txtHSL, 0);
            this.Controls.SetChildIndex(this.chkRegSunday, 0);
            this.Controls.SetChildIndex(this.txtCaLam, 0);
            this.Controls.SetChildIndex(this.txtLyDoLamThem, 0);
            this.Controls.SetChildIndex(this.txtTuNgay, 0);
            this.Controls.SetChildIndex(this.txtDenNgay, 0);
            this.Controls.SetChildIndex(this.labelControl6, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.labelControl7, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.labelControl8, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.ucChonDoiTuong1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaLam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRegSunday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDoLamThem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHSL.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit txtTuNgay;
        private DevExpress.XtraEditors.DateEdit txtDenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit txtCaLam;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit chkRegSunday;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit txtLyDoLamThem;
        private DevExpress.XtraEditors.CalcEdit txtHSL;
        private UC.ucChonDoiTuong ucChonDoiTuong1;
    }
}