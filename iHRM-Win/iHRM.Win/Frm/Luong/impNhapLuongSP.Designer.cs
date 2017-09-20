namespace iHRM.Win.Frm.Luong
{
    partial class impNhapLuongSP
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtThang = new DevExpress.XtraEditors.DateEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.txtThang);
            this.panel1.Size = new System.Drawing.Size(645, 65);
            this.panel1.Controls.SetChildIndex(this.txtThang, 0);
            this.panel1.Controls.SetChildIndex(this.labelControl3, 0);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelControl3.Location = new System.Drawing.Point(366, 12);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Tháng";
            // 
            // txtThang
            // 
            this.txtThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThang.EditValue = null;
            this.txtThang.Location = new System.Drawing.Point(366, 31);
            this.txtThang.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtThang.Name = "txtThang";
            this.txtThang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtThang.Properties.Appearance.Options.UseFont = true;
            this.txtThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtThang.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.txtThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtThang.Properties.EditFormat.FormatString = "MM/yyyy";
            this.txtThang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtThang.Properties.Mask.EditMask = "";
            this.txtThang.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtThang.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtThang.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.txtThang.Size = new System.Drawing.Size(84, 26);
            this.txtThang.TabIndex = 8;
            // 
            // impNhapLuongSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 356);
            this.Form_Description = "Nhập lương sản phẩm cho nhân viên";
            this.Form_Title = "Import lương sản phẩm";
            this.Name = "impNhapLuongSP";
            this.Text = "Import lương SP";
            this.Load += new System.EventHandler(this.impThamSoTinhLuong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit txtThang;
    }
}