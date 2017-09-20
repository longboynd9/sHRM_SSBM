namespace iHRM.Win.UC
{
    partial class ChonKyLuong
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
            this.components = new System.ComponentModel.Container();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.txtDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.linkLBKyLuong = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thángHiệnTạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tháng1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tháng12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(1, 0);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 17);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Từ ngày:";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTuNgay.EditValue = null;
            this.txtTuNgay.Location = new System.Drawing.Point(0, 19);
            this.txtTuNgay.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtTuNgay.Properties.Appearance.Options.UseFont = true;
            this.txtTuNgay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.txtTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTuNgay.Size = new System.Drawing.Size(153, 26);
            this.txtTuNgay.TabIndex = 6;
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenNgay.EditValue = null;
            this.txtDenNgay.Location = new System.Drawing.Point(0, 70);
            this.txtDenNgay.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtDenNgay.Properties.Appearance.Options.UseFont = true;
            this.txtDenNgay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.Mask.EditMask = "[0123][0-9]/[01][0-9]/[0-2][0-9][0-9][0-9]";
            this.txtDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDenNgay.Size = new System.Drawing.Size(153, 26);
            this.txtDenNgay.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(1, 51);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 17);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Đến ngày:";
            // 
            // linkLBKyLuong
            // 
            this.linkLBKyLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLBKyLuong.AutoSize = true;
            this.linkLBKyLuong.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLBKyLuong.Location = new System.Drawing.Point(76, -1);
            this.linkLBKyLuong.Name = "linkLBKyLuong";
            this.linkLBKyLuong.Size = new System.Drawing.Size(80, 19);
            this.linkLBKyLuong.TabIndex = 7;
            this.linkLBKyLuong.TabStop = true;
            this.linkLBKyLuong.Text = "Kỳ Lương";
            this.linkLBKyLuong.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thángHiệnTạiToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tháng1ToolStripMenuItem,
            this.tháng2ToolStripMenuItem,
            this.tháng3ToolStripMenuItem,
            this.tháng4ToolStripMenuItem,
            this.tháng5ToolStripMenuItem,
            this.tháng6ToolStripMenuItem,
            this.tháng7ToolStripMenuItem,
            this.tháng8ToolStripMenuItem,
            this.tháng9ToolStripMenuItem,
            this.tháng10ToolStripMenuItem,
            this.tháng11ToolStripMenuItem,
            this.tháng12ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 296);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // thángHiệnTạiToolStripMenuItem
            // 
            this.thángHiệnTạiToolStripMenuItem.Name = "thángHiệnTạiToolStripMenuItem";
            this.thángHiệnTạiToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.thángHiệnTạiToolStripMenuItem.Text = "Tháng hiện tại";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // tháng1ToolStripMenuItem
            // 
            this.tháng1ToolStripMenuItem.Name = "tháng1ToolStripMenuItem";
            this.tháng1ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng1ToolStripMenuItem.Text = "Tháng 1";
            // 
            // tháng2ToolStripMenuItem
            // 
            this.tháng2ToolStripMenuItem.Name = "tháng2ToolStripMenuItem";
            this.tháng2ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng2ToolStripMenuItem.Text = "Tháng 2";
            // 
            // tháng3ToolStripMenuItem
            // 
            this.tháng3ToolStripMenuItem.Name = "tháng3ToolStripMenuItem";
            this.tháng3ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng3ToolStripMenuItem.Text = "Tháng 3";
            // 
            // tháng4ToolStripMenuItem
            // 
            this.tháng4ToolStripMenuItem.Name = "tháng4ToolStripMenuItem";
            this.tháng4ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng4ToolStripMenuItem.Text = "Tháng 4";
            // 
            // tháng5ToolStripMenuItem
            // 
            this.tháng5ToolStripMenuItem.Name = "tháng5ToolStripMenuItem";
            this.tháng5ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng5ToolStripMenuItem.Text = "Tháng 5";
            // 
            // tháng6ToolStripMenuItem
            // 
            this.tháng6ToolStripMenuItem.Name = "tháng6ToolStripMenuItem";
            this.tháng6ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng6ToolStripMenuItem.Text = "Tháng 6";
            // 
            // tháng7ToolStripMenuItem
            // 
            this.tháng7ToolStripMenuItem.Name = "tháng7ToolStripMenuItem";
            this.tháng7ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng7ToolStripMenuItem.Text = "Tháng 7";
            // 
            // tháng8ToolStripMenuItem
            // 
            this.tháng8ToolStripMenuItem.Name = "tháng8ToolStripMenuItem";
            this.tháng8ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng8ToolStripMenuItem.Text = "Tháng 8";
            // 
            // tháng9ToolStripMenuItem
            // 
            this.tháng9ToolStripMenuItem.Name = "tháng9ToolStripMenuItem";
            this.tháng9ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng9ToolStripMenuItem.Text = "Tháng 9";
            // 
            // tháng10ToolStripMenuItem
            // 
            this.tháng10ToolStripMenuItem.Name = "tháng10ToolStripMenuItem";
            this.tháng10ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng10ToolStripMenuItem.Text = "Tháng 10";
            // 
            // tháng11ToolStripMenuItem
            // 
            this.tháng11ToolStripMenuItem.Name = "tháng11ToolStripMenuItem";
            this.tháng11ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng11ToolStripMenuItem.Text = "Tháng 11";
            // 
            // tháng12ToolStripMenuItem
            // 
            this.tháng12ToolStripMenuItem.Name = "tháng12ToolStripMenuItem";
            this.tháng12ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tháng12ToolStripMenuItem.Text = "Tháng 12";
            // 
            // ChonKyLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLBKyLuong);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTuNgay);
            this.Name = "ChonKyLuong";
            this.Size = new System.Drawing.Size(153, 99);
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtTuNgay;
        private DevExpress.XtraEditors.DateEdit txtDenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.LinkLabel linkLBKyLuong;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thángHiệnTạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tháng12ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}
