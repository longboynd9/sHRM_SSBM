namespace iHRM.Win.Frm.Employee
{
    partial class InGiayTo
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
            this.btnInThe = new DevExpress.XtraEditors.SimpleButton();
            this.groupInHoSo = new DevExpress.XtraEditors.GroupControl();
            this.listBoxGiayTo = new DevExpress.XtraEditors.ListBoxControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSoTo = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupInHoSo)).BeginInit();
            this.groupInHoSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxGiayTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSoTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInThe
            // 
            this.btnInThe.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInThe.Appearance.Options.UseFont = true;
            this.btnInThe.Image = global::iHRM.Win.Properties.Resources.btnPrint_Image;
            this.btnInThe.Location = new System.Drawing.Point(209, 85);
            this.btnInThe.Name = "btnInThe";
            this.btnInThe.Size = new System.Drawing.Size(160, 35);
            this.btnInThe.TabIndex = 1;
            this.btnInThe.Text = "In thẻ";
            this.btnInThe.Click += new System.EventHandler(this.btnInThe_Click);
            // 
            // groupInHoSo
            // 
            this.groupInHoSo.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInHoSo.AppearanceCaption.ForeColor = System.Drawing.Color.Green;
            this.groupInHoSo.AppearanceCaption.Options.UseFont = true;
            this.groupInHoSo.AppearanceCaption.Options.UseForeColor = true;
            this.groupInHoSo.Controls.Add(this.cbSoTo);
            this.groupInHoSo.Controls.Add(this.listBoxGiayTo);
            this.groupInHoSo.Controls.Add(this.label1);
            this.groupInHoSo.Controls.Add(this.btnInThe);
            this.groupInHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupInHoSo.Location = new System.Drawing.Point(0, 0);
            this.groupInHoSo.Name = "groupInHoSo";
            this.groupInHoSo.Size = new System.Drawing.Size(581, 381);
            this.groupInHoSo.TabIndex = 4;
            this.groupInHoSo.Text = "In giấy tờ làm việc";
            // 
            // listBoxGiayTo
            // 
            this.listBoxGiayTo.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGiayTo.Appearance.Options.UseFont = true;
            this.listBoxGiayTo.Location = new System.Drawing.Point(16, 77);
            this.listBoxGiayTo.Name = "listBoxGiayTo";
            this.listBoxGiayTo.Size = new System.Drawing.Size(160, 259);
            this.listBoxGiayTo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số tờ:";
            // 
            // cbSoTo
            // 
            this.cbSoTo.Location = new System.Drawing.Point(65, 45);
            this.cbSoTo.Name = "cbSoTo";
            this.cbSoTo.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSoTo.Properties.Appearance.Options.UseFont = true;
            this.cbSoTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cbSoTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSoTo.Size = new System.Drawing.Size(111, 28);
            this.cbSoTo.TabIndex = 6;
            // 
            // InGiayTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 381);
            this.Controls.Add(this.groupInHoSo);
            this.Name = "InGiayTo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In giấy tờ";
            this.Load += new System.EventHandler(this.InGiayTo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupInHoSo)).EndInit();
            this.groupInHoSo.ResumeLayout(false);
            this.groupInHoSo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxGiayTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSoTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnInThe;
        private DevExpress.XtraEditors.GroupControl groupInHoSo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ListBoxControl listBoxGiayTo;
        private DevExpress.XtraEditors.ComboBoxEdit cbSoTo;
    }
}