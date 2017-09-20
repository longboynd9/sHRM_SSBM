namespace iHRM.Win.Frm.PushDataToServer
{
    partial class frmPushDataToServer
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkCong = new DevExpress.XtraEditors.CheckEdit();
            this.chkLuong = new DevExpress.XtraEditors.CheckEdit();
            this.btnPushToYSS = new DevExpress.XtraEditors.SimpleButton();
            this.ucProgress1 = new iHRM.Win.UC.ucProgress();
            this.chonKyLuong1 = new iHRM.Win.UC.ChonKyLuong();
            this.chkThongTinNhanVien = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThongTinNhanVien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chonKyLuong1);
            this.panelControl1.Controls.Add(this.btnPushToYSS);
            this.panelControl1.Controls.Add(this.chkLuong);
            this.panelControl1.Controls.Add(this.chkThongTinNhanVien);
            this.panelControl1.Controls.Add(this.chkCong);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(816, 124);
            this.panelControl1.TabIndex = 2;
            // 
            // chkCong
            // 
            this.chkCong.EditValue = true;
            this.chkCong.Location = new System.Drawing.Point(165, 49);
            this.chkCong.Name = "chkCong";
            this.chkCong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCong.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkCong.Properties.Appearance.Options.UseFont = true;
            this.chkCong.Properties.Appearance.Options.UseForeColor = true;
            this.chkCong.Properties.Caption = "Dữ liệu Công";
            this.chkCong.Size = new System.Drawing.Size(116, 23);
            this.chkCong.TabIndex = 2;
            // 
            // chkLuong
            // 
            this.chkLuong.Location = new System.Drawing.Point(165, 78);
            this.chkLuong.Name = "chkLuong";
            this.chkLuong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLuong.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkLuong.Properties.Appearance.Options.UseFont = true;
            this.chkLuong.Properties.Appearance.Options.UseForeColor = true;
            this.chkLuong.Properties.Caption = "Dữ liệu Lương";
            this.chkLuong.Size = new System.Drawing.Size(116, 23);
            this.chkLuong.TabIndex = 2;
            // 
            // btnPushToYSS
            // 
            this.btnPushToYSS.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPushToYSS.Appearance.Options.UseFont = true;
            this.btnPushToYSS.Image = global::iHRM.Win.Properties.Resources.play;
            this.btnPushToYSS.Location = new System.Drawing.Point(389, 45);
            this.btnPushToYSS.Name = "btnPushToYSS";
            this.btnPushToYSS.Size = new System.Drawing.Size(129, 31);
            this.btnPushToYSS.TabIndex = 3;
            this.btnPushToYSS.Text = "Push to YSS";
            this.btnPushToYSS.Click += new System.EventHandler(this.btnPushToYSS_Click);
            // 
            // ucProgress1
            // 
            this.ucProgress1.CurrentValue = 0;
            this.ucProgress1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProgress1.Location = new System.Drawing.Point(0, 124);
            this.ucProgress1.Message = "";
            this.ucProgress1.Name = "ucProgress1";
            this.ucProgress1.Size = new System.Drawing.Size(816, 413);
            this.ucProgress1.Status = "Đang đăng ký 30/100";
            this.ucProgress1.TabIndex = 0;
            // 
            // chonKyLuong1
            // 
            this.chonKyLuong1.DenNgay = new System.DateTime(2017, 1, 16, 0, 0, 0, 0);
            this.chonKyLuong1.isVisibleKyLuong = true;
            this.chonKyLuong1.Location = new System.Drawing.Point(6, 6);
            this.chonKyLuong1.Name = "chonKyLuong1";
            this.chonKyLuong1.Size = new System.Drawing.Size(153, 99);
            this.chonKyLuong1.TabIndex = 4;
            this.chonKyLuong1.TuNgay = new System.DateTime(2016, 12, 17, 0, 0, 0, 0);
            // 
            // chkThongTinNhanVien
            // 
            this.chkThongTinNhanVien.Location = new System.Drawing.Point(165, 20);
            this.chkThongTinNhanVien.Name = "chkThongTinNhanVien";
            this.chkThongTinNhanVien.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThongTinNhanVien.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkThongTinNhanVien.Properties.Appearance.Options.UseFont = true;
            this.chkThongTinNhanVien.Properties.Appearance.Options.UseForeColor = true;
            this.chkThongTinNhanVien.Properties.Caption = "Thông tin nhân viên";
            this.chkThongTinNhanVien.Size = new System.Drawing.Size(145, 23);
            this.chkThongTinNhanVien.TabIndex = 2;
            // 
            // frmPushDataToServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 537);
            this.Controls.Add(this.ucProgress1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmPushDataToServer";
            this.Text = "Đẩy dữ liệu tới YSS";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkThongTinNhanVien.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UC.ucProgress ucProgress1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkLuong;
        private DevExpress.XtraEditors.CheckEdit chkCong;
        private DevExpress.XtraEditors.SimpleButton btnPushToYSS;
        private UC.ChonKyLuong chonKyLuong1;
        private DevExpress.XtraEditors.CheckEdit chkThongTinNhanVien;
    }
}