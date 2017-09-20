namespace iHRM.Win.UC
{
    partial class ucProgress
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progrBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.mmResult = new DevExpress.XtraEditors.MemoEdit();
            this.lbStatus = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.progrBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progrBar
            // 
            this.progrBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progrBar.Location = new System.Drawing.Point(0, 14);
            this.progrBar.Name = "progrBar";
            this.progrBar.Size = new System.Drawing.Size(392, 14);
            this.progrBar.TabIndex = 0;
            // 
            // mmResult
            // 
            this.mmResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmResult.Location = new System.Drawing.Point(0, 28);
            this.mmResult.Name = "mmResult";
            this.mmResult.Size = new System.Drawing.Size(392, 114);
            this.mmResult.TabIndex = 1;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(0, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(109, 14);
            this.lbStatus.TabIndex = 2;
            this.lbStatus.Text = "Đang đăng ký 30/100";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.progrBar);
            this.panelControl1.Controls.Add(this.lbStatus);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(392, 28);
            this.panelControl1.TabIndex = 3;
            // 
            // ucProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mmResult);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucProgress";
            this.Size = new System.Drawing.Size(392, 142);
            ((System.ComponentModel.ISupportInitialize)(this.progrBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl progrBar;
        private DevExpress.XtraEditors.MemoEdit mmResult;
        private System.Windows.Forms.Label lbStatus;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
