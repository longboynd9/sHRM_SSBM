namespace iHRM.Win.Frm.QuetThe
{
    partial class XuLyDuLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XuLyDuLieu));
            this.btnDoImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.prg = new DevExpress.XtraEditors.ProgressBarControl();
            this.bsMapping = new System.Windows.Forms.BindingSource(this.components);
            this.bgw_import = new System.ComponentModel.BackgroundWorker();
            this.txtDoiTuong = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.txtTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoiTuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoImport);
            this.panel1.Size = new System.Drawing.Size(704, 70);
            this.panel1.Controls.SetChildIndex(this.btnDoImport, 0);
            // 
            // btnDoImport
            // 
            this.btnDoImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoImport.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnDoImport.Appearance.Options.UseFont = true;
            this.btnDoImport.Image = global::iHRM.Win.Properties.Resources.play;
            this.btnDoImport.Location = new System.Drawing.Point(587, 32);
            this.btnDoImport.Name = "btnDoImport";
            this.btnDoImport.Size = new System.Drawing.Size(105, 33);
            this.btnDoImport.TabIndex = 0;
            this.btnDoImport.Text = "Analyze";
            this.btnDoImport.Click += new System.EventHandler(this.btnDoImport_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(12, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "labelControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(57, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đối tượng";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.richTextBox1);
            this.panelControl1.Location = new System.Drawing.Point(61, 207);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(588, 150);
            this.panelControl1.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(584, 146);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // prg
            // 
            this.prg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prg.Location = new System.Drawing.Point(61, 183);
            this.prg.Name = "prg";
            this.prg.Size = new System.Drawing.Size(588, 18);
            this.prg.TabIndex = 14;
            // 
            // bgw_import
            // 
            this.bgw_import.WorkerReportsProgress = true;
            this.bgw_import.WorkerSupportsCancellation = true;
            this.bgw_import.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_import_DoWork);
            this.bgw_import.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_import_ProgressChanged);
            this.bgw_import.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_import_RunWorkerCompleted);
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoiTuong.Location = new System.Drawing.Point(145, 147);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtDoiTuong.Properties.Appearance.Options.UseFont = true;
            this.txtDoiTuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDoiTuong.Properties.ReadOnly = true;
            this.txtDoiTuong.Size = new System.Drawing.Size(317, 30);
            this.txtDoiTuong.TabIndex = 4;
            this.txtDoiTuong.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtDoiTuong_ButtonClick);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl4.Location = new System.Drawing.Point(268, 118);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 19);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Tới ngày";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Location = new System.Drawing.Point(63, 118);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 19);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Từ ngày";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.EditValue = null;
            this.txtDenNgay.Location = new System.Drawing.Point(345, 115);
            this.txtDenNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDenNgay.Properties.Appearance.Options.UseFont = true;
            this.txtDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDenNgay.Properties.Mask.EditMask = "";
            this.txtDenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDenNgay.Size = new System.Drawing.Size(117, 26);
            this.txtDenNgay.TabIndex = 1;
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.EditValue = null;
            this.txtTuNgay.Location = new System.Drawing.Point(145, 115);
            this.txtTuNgay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTuNgay.Properties.Appearance.Options.UseFont = true;
            this.txtTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtTuNgay.Properties.Mask.EditMask = "";
            this.txtTuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtTuNgay.Size = new System.Drawing.Size(117, 26);
            this.txtTuNgay.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(468, 114);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(73, 27);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Lock";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(547, 114);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(100, 27);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Un-Lock";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkEdit1.Location = new System.Drawing.Point(468, 151);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "Đưa về dữ liệu GỐC";
            this.checkEdit1.Size = new System.Drawing.Size(179, 23);
            this.checkEdit1.TabIndex = 5;
            // 
            // XuLyDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 397);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prg);
            this.Controls.Add(this.txtDoiTuong);
            this.Controls.Add(this.panelControl1);
            this.Form_Description = "Hành động này sẽ phân tích tất cả dữ liệu quẹt thẻ đã được import\r\nvà thực hiện c" +
    "ập nhật tính công cho nhân viên làm ca.";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Xử lý dữ liệu quẹt thẻ";
            this.Name = "XuLyDuLieu";
            this.Text = "Xử lý dữ liệu quẹt thẻ";
            this.Load += new System.EventHandler(this.XuLyDuLieu_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.txtDoiTuong, 0);
            this.Controls.SetChildIndex(this.prg, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.txtTuNgay, 0);
            this.Controls.SetChildIndex(this.txtDenNgay, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.Controls.SetChildIndex(this.simpleButton2, 0);
            this.Controls.SetChildIndex(this.checkEdit1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoiTuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnDoImport;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.ProgressBarControl prg;
        private System.Windows.Forms.BindingSource bsMapping;
        private System.ComponentModel.BackgroundWorker bgw_import;
        private DevExpress.XtraEditors.ButtonEdit txtDoiTuong;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit txtDenNgay;
        private DevExpress.XtraEditors.DateEdit txtTuNgay;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}