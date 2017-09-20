namespace iHRM.Win.Frm.Employee
{
    partial class NhapLuongNhanVien
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
            this.memoMaNhanVien = new DevExpress.XtraEditors.MemoEdit();
            this.txtLuongCB = new DevExpress.XtraEditors.TextEdit();
            this.txtPhuCap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnAddLuongCB = new DevExpress.XtraEditors.SimpleButton();
            this.rdLoaiKyHD = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.memoSucess = new DevExpress.XtraEditors.MemoEdit();
            this.memoFailed = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoMaNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhuCap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLoaiKyHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoSucess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoFailed.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoMaNhanVien
            // 
            this.memoMaNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.memoMaNhanVien.EditValue = "";
            this.memoMaNhanVien.Location = new System.Drawing.Point(0, 0);
            this.memoMaNhanVien.Name = "memoMaNhanVien";
            this.memoMaNhanVien.Size = new System.Drawing.Size(879, 115);
            this.memoMaNhanVien.TabIndex = 0;
            // 
            // txtLuongCB
            // 
            this.txtLuongCB.Location = new System.Drawing.Point(105, 248);
            this.txtLuongCB.Name = "txtLuongCB";
            this.txtLuongCB.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLuongCB.Properties.Appearance.Options.UseFont = true;
            this.txtLuongCB.Size = new System.Drawing.Size(100, 22);
            this.txtLuongCB.TabIndex = 1;
            // 
            // txtPhuCap
            // 
            this.txtPhuCap.Location = new System.Drawing.Point(270, 248);
            this.txtPhuCap.Name = "txtPhuCap";
            this.txtPhuCap.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPhuCap.Properties.Appearance.Options.UseFont = true;
            this.txtPhuCap.Size = new System.Drawing.Size(100, 22);
            this.txtPhuCap.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(9, 251);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Lương cơ bản:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(210, 251);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Phụ cấp:";
            // 
            // btnAddLuongCB
            // 
            this.btnAddLuongCB.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLuongCB.Appearance.Options.UseFont = true;
            this.btnAddLuongCB.Location = new System.Drawing.Point(105, 365);
            this.btnAddLuongCB.Name = "btnAddLuongCB";
            this.btnAddLuongCB.Size = new System.Drawing.Size(91, 29);
            this.btnAddLuongCB.TabIndex = 5;
            this.btnAddLuongCB.Text = "Thực hiện";
            this.btnAddLuongCB.Click += new System.EventHandler(this.btnAddLuongCB_Click);
            // 
            // rdLoaiKyHD
            // 
            this.rdLoaiKyHD.EditValue = ((short)(0));
            this.rdLoaiKyHD.Location = new System.Drawing.Point(105, 276);
            this.rdLoaiKyHD.Name = "rdLoaiKyHD";
            this.rdLoaiKyHD.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.rdLoaiKyHD.Properties.Appearance.Options.UseFont = true;
            this.rdLoaiKyHD.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Ký hợp đồng Duy Minh / Việt Nam"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Ký hợp đồng Bảo Minh")});
            this.rdLoaiKyHD.Size = new System.Drawing.Size(265, 47);
            this.rdLoaiKyHD.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Location = new System.Drawing.Point(9, 280);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 17);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Loại ký HĐ:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(240, 365);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(91, 29);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Test";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // memoSucess
            // 
            this.memoSucess.EditValue = "";
            this.memoSucess.Location = new System.Drawing.Point(0, 115);
            this.memoSucess.Name = "memoSucess";
            this.memoSucess.Size = new System.Drawing.Size(434, 129);
            this.memoSucess.TabIndex = 9;
            // 
            // memoFailed
            // 
            this.memoFailed.EditValue = "";
            this.memoFailed.Location = new System.Drawing.Point(433, 115);
            this.memoFailed.Name = "memoFailed";
            this.memoFailed.Size = new System.Drawing.Size(446, 129);
            this.memoFailed.TabIndex = 10;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(422, 251);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(121, 29);
            this.simpleButton2.TabIndex = 11;
            this.simpleButton2.Text = "Mới 20-01-2016";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // NhapLuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 417);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.memoFailed);
            this.Controls.Add(this.memoSucess);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.rdLoaiKyHD);
            this.Controls.Add(this.btnAddLuongCB);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPhuCap);
            this.Controls.Add(this.txtLuongCB);
            this.Controls.Add(this.memoMaNhanVien);
            this.Name = "NhapLuongNhanVien";
            this.Text = "NhapLuongNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.memoMaNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongCB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhuCap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLoaiKyHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoSucess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoFailed.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoMaNhanVien;
        private DevExpress.XtraEditors.TextEdit txtLuongCB;
        private DevExpress.XtraEditors.TextEdit txtPhuCap;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddLuongCB;
        private DevExpress.XtraEditors.RadioGroup rdLoaiKyHD;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.MemoEdit memoSucess;
        private DevExpress.XtraEditors.MemoEdit memoFailed;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;

    }
}