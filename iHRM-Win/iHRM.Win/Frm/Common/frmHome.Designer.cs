namespace iHRM.Win.Frm.Common
{
    partial class frmHome
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.linkLbNghiThaiSan = new System.Windows.Forms.LinkLabel();
            this.lbNghiThaiSan = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lbKoDiLam = new DevExpress.XtraEditors.LabelControl();
            this.lbLinkKhongDiLam = new System.Windows.Forms.LinkLabel();
            this.lbHetHanHD = new DevExpress.XtraEditors.LabelControl();
            this.linkLbHetHanHD = new System.Windows.Forms.LinkLabel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(297, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(439, 355);
            this.groupControl1.TabIndex = 1;
            // 
            // linkLbNghiThaiSan
            // 
            this.linkLbNghiThaiSan.AutoSize = true;
            this.linkLbNghiThaiSan.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLbNghiThaiSan.Location = new System.Drawing.Point(251, 58);
            this.linkLbNghiThaiSan.Name = "linkLbNghiThaiSan";
            this.linkLbNghiThaiSan.Size = new System.Drawing.Size(35, 18);
            this.linkLbNghiThaiSan.TabIndex = 2;
            this.linkLbNghiThaiSan.TabStop = true;
            this.linkLbNghiThaiSan.Text = "xem";
            this.linkLbNghiThaiSan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLbNghiThaiSan_LinkClicked);
            // 
            // lbNghiThaiSan
            // 
            this.lbNghiThaiSan.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbNghiThaiSan.Location = new System.Drawing.Point(4, 62);
            this.lbNghiThaiSan.Name = "lbNghiThaiSan";
            this.lbNghiThaiSan.Size = new System.Drawing.Size(231, 15);
            this.lbNghiThaiSan.TabIndex = 3;
            this.lbNghiThaiSan.Text = "BC NV hết hạn thai sản(7 ngày). Loading...";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.lbKoDiLam);
            this.groupControl2.Controls.Add(this.lbLinkKhongDiLam);
            this.groupControl2.Controls.Add(this.lbHetHanHD);
            this.groupControl2.Controls.Add(this.linkLbHetHanHD);
            this.groupControl2.Controls.Add(this.lbNghiThaiSan);
            this.groupControl2.Controls.Add(this.linkLbNghiThaiSan);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(295, 355);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Thông báo";
            // 
            // lbKoDiLam
            // 
            this.lbKoDiLam.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbKoDiLam.Location = new System.Drawing.Point(3, 89);
            this.lbKoDiLam.Name = "lbKoDiLam";
            this.lbKoDiLam.Size = new System.Drawing.Size(235, 15);
            this.lbKoDiLam.TabIndex = 7;
            this.lbKoDiLam.Text = "BC NV không đi làm >= 14 ngày. Loading...";
            // 
            // lbLinkKhongDiLam
            // 
            this.lbLinkKhongDiLam.AutoSize = true;
            this.lbLinkKhongDiLam.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLinkKhongDiLam.Location = new System.Drawing.Point(250, 86);
            this.lbLinkKhongDiLam.Name = "lbLinkKhongDiLam";
            this.lbLinkKhongDiLam.Size = new System.Drawing.Size(35, 18);
            this.lbLinkKhongDiLam.TabIndex = 6;
            this.lbLinkKhongDiLam.TabStop = true;
            this.lbLinkKhongDiLam.Text = "xem";
            this.lbLinkKhongDiLam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbLinkKhongDiLam_LinkClicked);
            // 
            // lbHetHanHD
            // 
            this.lbHetHanHD.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbHetHanHD.Location = new System.Drawing.Point(4, 34);
            this.lbHetHanHD.Name = "lbHetHanHD";
            this.lbHetHanHD.Size = new System.Drawing.Size(193, 15);
            this.lbHetHanHD.TabIndex = 5;
            this.lbHetHanHD.Text = "BC NV hết hạn hợp đồng. Loading...";
            // 
            // linkLbHetHanHD
            // 
            this.linkLbHetHanHD.AutoSize = true;
            this.linkLbHetHanHD.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLbHetHanHD.Location = new System.Drawing.Point(251, 31);
            this.linkLbHetHanHD.Name = "linkLbHetHanHD";
            this.linkLbHetHanHD.Size = new System.Drawing.Size(35, 18);
            this.linkLbHetHanHD.TabIndex = 4;
            this.linkLbHetHanHD.TabStop = true;
            this.linkLbHetHanHD.Text = "xem";
            this.linkLbHetHanHD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLbHetHanHD_LinkClicked);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(738, 359);
            this.panelControl1.TabIndex = 5;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 359);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHome";
            this.Text = "Trang chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHome_FormClosing);
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.LinkLabel linkLbNghiThaiSan;
        private DevExpress.XtraEditors.LabelControl lbNghiThaiSan;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.LinkLabel linkLbHetHanHD;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbHetHanHD;
        private DevExpress.XtraEditors.LabelControl lbKoDiLam;
        private System.Windows.Forms.LinkLabel lbLinkKhongDiLam;
    }
}