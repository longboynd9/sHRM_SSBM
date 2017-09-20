namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    partial class dlgDangKyCaMacDinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDangKyCaMacDinh));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCaLam = new DevExpress.XtraEditors.LookUpEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtHsLuong = new DevExpress.XtraEditors.CalcEdit();
            this.chkIsSunday = new DevExpress.XtraEditors.CheckEdit();
            this.ucChonDoiTuong1 = new iHRM.Win.UC.ucChonDoiTuong();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaLam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHsLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSunday.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Size = new System.Drawing.Size(652, 70);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(566, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 35);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "  Đăng ký";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Location = new System.Drawing.Point(70, 265);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "HS lương";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl5.Location = new System.Drawing.Point(70, 231);
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
            this.txtCaLam.Location = new System.Drawing.Point(167, 228);
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
            this.txtCaLam.Size = new System.Drawing.Size(405, 26);
            this.txtCaLam.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtHsLuong
            // 
            this.txtHsLuong.Location = new System.Drawing.Point(167, 262);
            this.txtHsLuong.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtHsLuong.Name = "txtHsLuong";
            this.txtHsLuong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtHsLuong.Properties.Appearance.Options.UseFont = true;
            this.txtHsLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHsLuong.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtHsLuong.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtHsLuong.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtHsLuong.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtHsLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtHsLuong.Size = new System.Drawing.Size(144, 26);
            this.txtHsLuong.TabIndex = 6;
            // 
            // chkIsSunday
            // 
            this.chkIsSunday.Location = new System.Drawing.Point(333, 261);
            this.chkIsSunday.Name = "chkIsSunday";
            this.chkIsSunday.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkIsSunday.Properties.Appearance.Options.UseFont = true;
            this.chkIsSunday.Properties.Caption = "là chủ nhật";
            this.chkIsSunday.Size = new System.Drawing.Size(143, 23);
            this.chkIsSunday.TabIndex = 7;
            // 
            // ucChonDoiTuong1
            // 
            this.ucChonDoiTuong1.Location = new System.Drawing.Point(48, 109);
            this.ucChonDoiTuong1.Name = "ucChonDoiTuong1";
            this.ucChonDoiTuong1.SelectedIndex = 0;
            this.ucChonDoiTuong1.SelectedValue = "";
            this.ucChonDoiTuong1.Size = new System.Drawing.Size(554, 94);
            this.ucChonDoiTuong1.TabIndex = 8;
            // 
            // dlgDangKyCaMacDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 364);
            this.Controls.Add(this.ucChonDoiTuong1);
            this.Controls.Add(this.chkIsSunday);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtCaLam);
            this.Controls.Add(this.txtHsLuong);
            this.Form_Description = "Thiết lập ca làm việc mặc định cho công nhân\r\nNếu ngày nào không được đăng ký ca " +
    "làm sẽ lấy ca mặc định này";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Đăng ký ca làm mặc định";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDangKyCaMacDinh";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgDangKyCaLam_FormClosing);
            this.Load += new System.EventHandler(this.dlgDangKyCaLam_Load);
            this.Controls.SetChildIndex(this.txtHsLuong, 0);
            this.Controls.SetChildIndex(this.txtCaLam, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.chkIsSunday, 0);
            this.Controls.SetChildIndex(this.ucChonDoiTuong1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaLam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHsLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSunday.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit txtCaLam;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.CalcEdit txtHsLuong;
        private DevExpress.XtraEditors.CheckEdit chkIsSunday;
        private UC.ucChonDoiTuong ucChonDoiTuong1;
    }
}