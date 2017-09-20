namespace iHRM.Win.Frm.Common
{
    partial class frmInputKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputKey));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnActive = new DevExpress.XtraEditors.SimpleButton();
            this.txtIDCPU = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(55, 107);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ID Computer:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(55, 145);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Enter key:";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.txtKey.Location = new System.Drawing.Point(169, 141);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(229, 27);
            this.txtKey.TabIndex = 1;
            // 
            // btnActive
            // 
            this.btnActive.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActive.Appearance.Options.UseFont = true;
            this.btnActive.Location = new System.Drawing.Point(55, 180);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(343, 32);
            this.btnActive.TabIndex = 2;
            this.btnActive.Text = "Active";
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // txtIDCPU
            // 
            this.txtIDCPU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDCPU.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.txtIDCPU.Location = new System.Drawing.Point(169, 106);
            this.txtIDCPU.Name = "txtIDCPU";
            this.txtIDCPU.ReadOnly = true;
            this.txtIDCPU.Size = new System.Drawing.Size(229, 20);
            this.txtIDCPU.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.ContentImage = global::iHRM.Win.Properties.Resources.LogoLogin;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(452, 100);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmInputKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 220);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.txtIDCPU);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInputKey";
            this.Text = "Active sHRM";
            this.Load += new System.EventHandler(this.frmInputKey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtKey;
        private DevExpress.XtraEditors.SimpleButton btnActive;
        private System.Windows.Forms.TextBox txtIDCPU;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}