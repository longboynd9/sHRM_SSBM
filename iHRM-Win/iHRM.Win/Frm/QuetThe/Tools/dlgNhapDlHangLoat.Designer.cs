namespace iHRM.Win.Frm.QuetThe.Tools
{
    partial class dlgNhapDlHangLoat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgNhapDlHangLoat));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.txtDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.chkNoData = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtTuGio_Start = new DevExpress.XtraEditors.TimeSpanEdit();
            this.txtDenGio_Start = new DevExpress.XtraEditors.TimeSpanEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtTuGio_End = new DevExpress.XtraEditors.TimeSpanEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtDenGio_End = new DevExpress.XtraEditors.TimeSpanEdit();
            this.ucChonDoiTuong_DS1 = new iHRM.Win.UC.ucChonDoiTuong_DS();
            this.ucProgress1 = new iHRM.Win.UC.ucProgress();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuGio_Start.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenGio_Start.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuGio_End.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenGio_End.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Size = new System.Drawing.Size(634, 70);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(536, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "  Đăng ký";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.labelControl3.Location = new System.Drawing.Point(53, 236);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Từ ngày:";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.EditValue = null;
            this.txtTuNgay.Location = new System.Drawing.Point(186, 233);
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
            this.txtTuNgay.Size = new System.Drawing.Size(111, 26);
            this.txtTuNgay.TabIndex = 6;
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.EditValue = null;
            this.txtDenNgay.Location = new System.Drawing.Point(461, 233);
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
            this.txtDenNgay.Size = new System.Drawing.Size(113, 26);
            this.txtDenNgay.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.labelControl4.Location = new System.Drawing.Point(337, 237);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 19);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Tới ngày:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.labelControl6.Location = new System.Drawing.Point(54, 337);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 19);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Edit data:";
            // 
            // chkNoData
            // 
            this.chkNoData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNoData.EditValue = null;
            this.chkNoData.Location = new System.Drawing.Point(186, 335);
            this.chkNoData.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.chkNoData.Name = "chkNoData";
            this.chkNoData.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.chkNoData.Properties.Appearance.Options.UseFont = true;
            this.chkNoData.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.chkNoData.Properties.Caption = "Only no data";
            this.chkNoData.Size = new System.Drawing.Size(111, 23);
            this.chkNoData.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.labelControl5.Location = new System.Drawing.Point(53, 304);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(117, 19);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "TG quẹt ra_Start:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.labelControl7.Location = new System.Drawing.Point(53, 268);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(127, 19);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "TG quẹt vào_Start:";
            // 
            // txtTuGio_Start
            // 
            this.txtTuGio_Start.EditValue = System.TimeSpan.Parse("00:00:00");
            this.txtTuGio_Start.Location = new System.Drawing.Point(186, 265);
            this.txtTuGio_Start.Name = "txtTuGio_Start";
            this.txtTuGio_Start.Properties.AllowEditDays = false;
            this.txtTuGio_Start.Properties.AllowEditSeconds = false;
            this.txtTuGio_Start.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTuGio_Start.Properties.Appearance.Options.UseFont = true;
            this.txtTuGio_Start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuGio_Start.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTuGio_Start.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtTuGio_Start.Properties.Mask.EditMask = "HH:mm";
            this.txtTuGio_Start.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTuGio_Start.Size = new System.Drawing.Size(111, 28);
            this.txtTuGio_Start.TabIndex = 9;
            // 
            // txtDenGio_Start
            // 
            this.txtDenGio_Start.EditValue = System.TimeSpan.Parse("00:00:00");
            this.txtDenGio_Start.Location = new System.Drawing.Point(186, 299);
            this.txtDenGio_Start.Name = "txtDenGio_Start";
            this.txtDenGio_Start.Properties.AllowEditDays = false;
            this.txtDenGio_Start.Properties.AllowEditSeconds = false;
            this.txtDenGio_Start.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDenGio_Start.Properties.Appearance.Options.UseFont = true;
            this.txtDenGio_Start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenGio_Start.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenGio_Start.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDenGio_Start.Properties.Mask.EditMask = "HH:mm";
            this.txtDenGio_Start.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDenGio_Start.Size = new System.Drawing.Size(111, 28);
            this.txtDenGio_Start.TabIndex = 10;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.labelControl8.Location = new System.Drawing.Point(337, 270);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(121, 19);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "TG quẹt vào_End:";
            // 
            // txtTuGio_End
            // 
            this.txtTuGio_End.EditValue = System.TimeSpan.Parse("00:00:00");
            this.txtTuGio_End.Location = new System.Drawing.Point(461, 265);
            this.txtTuGio_End.Name = "txtTuGio_End";
            this.txtTuGio_End.Properties.AllowEditDays = false;
            this.txtTuGio_End.Properties.AllowEditSeconds = false;
            this.txtTuGio_End.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTuGio_End.Properties.Appearance.Options.UseFont = true;
            this.txtTuGio_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuGio_End.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTuGio_End.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtTuGio_End.Properties.Mask.EditMask = "HH:mm";
            this.txtTuGio_End.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTuGio_End.Size = new System.Drawing.Size(113, 28);
            this.txtTuGio_End.TabIndex = 13;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.labelControl9.Location = new System.Drawing.Point(337, 304);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(111, 19);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "TG quẹt ra_End:";
            // 
            // txtDenGio_End
            // 
            this.txtDenGio_End.EditValue = System.TimeSpan.Parse("00:00:00");
            this.txtDenGio_End.Location = new System.Drawing.Point(461, 299);
            this.txtDenGio_End.Name = "txtDenGio_End";
            this.txtDenGio_End.Properties.AllowEditDays = false;
            this.txtDenGio_End.Properties.AllowEditSeconds = false;
            this.txtDenGio_End.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDenGio_End.Properties.Appearance.Options.UseFont = true;
            this.txtDenGio_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenGio_End.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenGio_End.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDenGio_End.Properties.Mask.EditMask = "HH:mm";
            this.txtDenGio_End.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDenGio_End.Size = new System.Drawing.Size(113, 28);
            this.txtDenGio_End.TabIndex = 15;
            // 
            // ucChonDoiTuong_DS1
            // 
            this.ucChonDoiTuong_DS1.Location = new System.Drawing.Point(23, 80);
            this.ucChonDoiTuong_DS1.Name = "ucChonDoiTuong_DS1";
            this.ucChonDoiTuong_DS1.radioSelected = 0;
            this.ucChonDoiTuong_DS1.Size = new System.Drawing.Size(591, 145);
            this.ucChonDoiTuong_DS1.TabIndex = 17;
            // 
            // ucProgress1
            // 
            this.ucProgress1.CurrentValue = 0;
            this.ucProgress1.Location = new System.Drawing.Point(23, 364);
            this.ucProgress1.Message = "";
            this.ucProgress1.Name = "ucProgress1";
            this.ucProgress1.Size = new System.Drawing.Size(591, 190);
            this.ucProgress1.Status = "Đang đăng ký 30/100";
            this.ucProgress1.TabIndex = 18;
            // 
            // dlgNhapDlHangLoat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 566);
            this.Controls.Add(this.ucProgress1);
            this.Controls.Add(this.ucChonDoiTuong_DS1);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtDenGio_End);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtTuGio_End);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtTuGio_Start);
            this.Controls.Add(this.txtDenGio_Start);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.chkNoData);
            this.Form_Description = "Cho phép nhập dữ liệu quẹt thẻ hàng loạt random cho nhân viên. ";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Nhập dữ liệu hàng loạt";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgNhapDlHangLoat";
            this.ShowIcon = false;
            this.Text = "Nhập dữ liệu hàng loạt random";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Load += new System.EventHandler(this.dlgDangKyCaLam_Load);
            this.Controls.SetChildIndex(this.chkNoData, 0);
            this.Controls.SetChildIndex(this.txtTuNgay, 0);
            this.Controls.SetChildIndex(this.txtDenNgay, 0);
            this.Controls.SetChildIndex(this.labelControl6, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.txtDenGio_Start, 0);
            this.Controls.SetChildIndex(this.txtTuGio_Start, 0);
            this.Controls.SetChildIndex(this.labelControl7, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.txtTuGio_End, 0);
            this.Controls.SetChildIndex(this.labelControl8, 0);
            this.Controls.SetChildIndex(this.txtDenGio_End, 0);
            this.Controls.SetChildIndex(this.labelControl9, 0);
            this.Controls.SetChildIndex(this.ucChonDoiTuong_DS1, 0);
            this.Controls.SetChildIndex(this.ucProgress1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuGio_Start.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenGio_Start.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuGio_End.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenGio_End.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit txtTuNgay;
        private DevExpress.XtraEditors.DateEdit txtDenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckEdit chkNoData;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TimeSpanEdit txtTuGio_Start;
        private DevExpress.XtraEditors.TimeSpanEdit txtDenGio_Start;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TimeSpanEdit txtTuGio_End;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TimeSpanEdit txtDenGio_End;
        private UC.ucChonDoiTuong_DS ucChonDoiTuong_DS1;
        private UC.ucProgress ucProgress1;
    }
}