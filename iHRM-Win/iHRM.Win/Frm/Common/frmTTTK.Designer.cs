namespace iHRM.Win.Frm.Common
{
    partial class frmTTTK
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
            this.materialLabel1 = new System.Windows.Forms.Label();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.materialLabel3 = new System.Windows.Forms.Label();
            this.materialLabel4 = new System.Windows.Forms.Label();
            this.materialFlatButton1 = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtNewPW2 = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPW = new DevExpress.XtraEditors.TextEdit();
            this.txtOldPW = new DevExpress.XtraEditors.TextEdit();
            this.txtCaption = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPW2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(26, 42);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 20);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Tên gọi:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(26, 78);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(64, 20);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "MK cũ:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(26, 114);
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(75, 20);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "MK mới:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(26, 150);
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(82, 20);
            this.materialLabel4.TabIndex = 1;
            this.materialLabel4.Text = "Xác nhận:";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialFlatButton1.Location = new System.Drawing.Point(226, 201);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Size = new System.Drawing.Size(107, 39);
            this.materialFlatButton1.TabIndex = 2;
            this.materialFlatButton1.Text = "Xác nhận";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupControl1.Controls.Add(this.txtNewPW2);
            this.groupControl1.Controls.Add(this.txtNewPW);
            this.groupControl1.Controls.Add(this.txtOldPW);
            this.groupControl1.Controls.Add(this.txtCaption);
            this.groupControl1.Controls.Add(this.materialFlatButton1);
            this.groupControl1.Controls.Add(this.materialLabel4);
            this.groupControl1.Controls.Add(this.materialLabel3);
            this.groupControl1.Controls.Add(this.materialLabel2);
            this.groupControl1.Controls.Add(this.materialLabel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(359, 255);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Thông tin tài khoản";
            // 
            // txtNewPW2
            // 
            this.txtNewPW2.Location = new System.Drawing.Point(139, 147);
            this.txtNewPW2.Name = "txtNewPW2";
            this.txtNewPW2.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPW2.Properties.Appearance.Options.UseFont = true;
            this.txtNewPW2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtNewPW2.Size = new System.Drawing.Size(194, 26);
            this.txtNewPW2.TabIndex = 6;
            // 
            // txtNewPW
            // 
            this.txtNewPW.Location = new System.Drawing.Point(139, 111);
            this.txtNewPW.Name = "txtNewPW";
            this.txtNewPW.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPW.Properties.Appearance.Options.UseFont = true;
            this.txtNewPW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtNewPW.Size = new System.Drawing.Size(194, 26);
            this.txtNewPW.TabIndex = 5;
            // 
            // txtOldPW
            // 
            this.txtOldPW.Location = new System.Drawing.Point(139, 75);
            this.txtOldPW.Name = "txtOldPW";
            this.txtOldPW.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPW.Properties.Appearance.Options.UseFont = true;
            this.txtOldPW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtOldPW.Size = new System.Drawing.Size(194, 26);
            this.txtOldPW.TabIndex = 4;
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(139, 39);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaption.Properties.Appearance.Options.UseFont = true;
            this.txtCaption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtCaption.Size = new System.Drawing.Size(194, 26);
            this.txtCaption.TabIndex = 3;
            // 
            // frmTTTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 255);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTTTK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.frmTTTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPW2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label materialLabel1;
        private System.Windows.Forms.Label materialLabel2;
        private System.Windows.Forms.Label materialLabel3;
        private System.Windows.Forms.Label materialLabel4;
        private System.Windows.Forms.Button materialFlatButton1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtNewPW2;
        private DevExpress.XtraEditors.TextEdit txtNewPW;
        private DevExpress.XtraEditors.TextEdit txtOldPW;
        private DevExpress.XtraEditors.TextEdit txtCaption;
    }
}