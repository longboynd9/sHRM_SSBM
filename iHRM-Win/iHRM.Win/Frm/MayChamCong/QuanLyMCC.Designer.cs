namespace iHRM.Win.Frm.MayChamCong
{
    partial class QuanLyMCC
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
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.radioMCC = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookupMayChamCong = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnXoaDuLieuQuetThe = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestartMCC = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearAdmin = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetDeviceTime = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetDeviceInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetSerialNumber = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetProductCode = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioMCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupMayChamCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl7
            // 
            this.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl7.Controls.Add(this.radioMCC);
            this.panelControl7.Controls.Add(this.labelControl1);
            this.panelControl7.Controls.Add(this.lookupMayChamCong);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl7.Location = new System.Drawing.Point(0, 0);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(722, 78);
            this.panelControl7.TabIndex = 8;
            // 
            // radioMCC
            // 
            this.radioMCC.EditValue = ((short)(0));
            this.radioMCC.Location = new System.Drawing.Point(3, 6);
            this.radioMCC.Name = "radioMCC";
            this.radioMCC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.radioMCC.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Theo máy chọn"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Tất cả các máy")});
            this.radioMCC.Size = new System.Drawing.Size(322, 31);
            this.radioMCC.TabIndex = 2;
            this.radioMCC.SelectedIndexChanged += new System.EventHandler(this.radioMCC_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(7, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn máy:";
            // 
            // lookupMayChamCong
            // 
            this.lookupMayChamCong.Location = new System.Drawing.Point(81, 44);
            this.lookupMayChamCong.Name = "lookupMayChamCong";
            this.lookupMayChamCong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupMayChamCong.Properties.Appearance.Options.UseFont = true;
            this.lookupMayChamCong.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupMayChamCong.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lookupMayChamCong.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookupMayChamCong.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lookupMayChamCong.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lookupMayChamCong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupMayChamCong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenMay", 85, "Máy chấm công"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("diaChiIP", 40, "Địa Chỉ IP"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "Name13", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("soMay", "Name14", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("port", "Port")});
            this.lookupMayChamCong.Properties.DisplayMember = "tenMay";
            this.lookupMayChamCong.Properties.EditValueChangedDelay = 1;
            this.lookupMayChamCong.Properties.NullText = "";
            this.lookupMayChamCong.Properties.PopupFormMinSize = new System.Drawing.Size(250, 0);
            this.lookupMayChamCong.Properties.ValueMember = "id";
            this.lookupMayChamCong.Size = new System.Drawing.Size(244, 24);
            this.lookupMayChamCong.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGetProductCode);
            this.panelControl1.Controls.Add(this.btnGetSerialNumber);
            this.panelControl1.Controls.Add(this.btnGetDeviceInfo);
            this.panelControl1.Controls.Add(this.btnGetDeviceTime);
            this.panelControl1.Controls.Add(this.btnClearAdmin);
            this.panelControl1.Controls.Add(this.btnRestartMCC);
            this.panelControl1.Controls.Add(this.btnXoaDuLieuQuetThe);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 78);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(722, 313);
            this.panelControl1.TabIndex = 9;
            // 
            // btnXoaDuLieuQuetThe
            // 
            this.btnXoaDuLieuQuetThe.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnXoaDuLieuQuetThe.Appearance.Options.UseFont = true;
            this.btnXoaDuLieuQuetThe.Location = new System.Drawing.Point(5, 6);
            this.btnXoaDuLieuQuetThe.Name = "btnXoaDuLieuQuetThe";
            this.btnXoaDuLieuQuetThe.Size = new System.Drawing.Size(130, 26);
            this.btnXoaDuLieuQuetThe.TabIndex = 0;
            this.btnXoaDuLieuQuetThe.Text = "Xóa dữ liệu quẹt thẻ";
            // 
            // btnRestartMCC
            // 
            this.btnRestartMCC.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRestartMCC.Appearance.Options.UseFont = true;
            this.btnRestartMCC.Location = new System.Drawing.Point(5, 38);
            this.btnRestartMCC.Name = "btnRestartMCC";
            this.btnRestartMCC.Size = new System.Drawing.Size(115, 26);
            this.btnRestartMCC.TabIndex = 0;
            this.btnRestartMCC.Text = "Restart MCC";
            // 
            // btnClearAdmin
            // 
            this.btnClearAdmin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClearAdmin.Appearance.Options.UseFont = true;
            this.btnClearAdmin.Location = new System.Drawing.Point(7, 79);
            this.btnClearAdmin.Name = "btnClearAdmin";
            this.btnClearAdmin.Size = new System.Drawing.Size(130, 26);
            this.btnClearAdmin.TabIndex = 0;
            this.btnClearAdmin.Text = "Clear administrator";
            // 
            // btnGetDeviceTime
            // 
            this.btnGetDeviceTime.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGetDeviceTime.Appearance.Options.UseFont = true;
            this.btnGetDeviceTime.Location = new System.Drawing.Point(7, 111);
            this.btnGetDeviceTime.Name = "btnGetDeviceTime";
            this.btnGetDeviceTime.Size = new System.Drawing.Size(130, 26);
            this.btnGetDeviceTime.TabIndex = 1;
            this.btnGetDeviceTime.Text = "Get device time";
            // 
            // btnGetDeviceInfo
            // 
            this.btnGetDeviceInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGetDeviceInfo.Appearance.Options.UseFont = true;
            this.btnGetDeviceInfo.Location = new System.Drawing.Point(7, 143);
            this.btnGetDeviceInfo.Name = "btnGetDeviceInfo";
            this.btnGetDeviceInfo.Size = new System.Drawing.Size(130, 26);
            this.btnGetDeviceInfo.TabIndex = 1;
            this.btnGetDeviceInfo.Text = "Get device info";
            // 
            // btnGetSerialNumber
            // 
            this.btnGetSerialNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGetSerialNumber.Appearance.Options.UseFont = true;
            this.btnGetSerialNumber.Location = new System.Drawing.Point(7, 175);
            this.btnGetSerialNumber.Name = "btnGetSerialNumber";
            this.btnGetSerialNumber.Size = new System.Drawing.Size(130, 26);
            this.btnGetSerialNumber.TabIndex = 1;
            this.btnGetSerialNumber.Text = "Get serial number";
            // 
            // btnGetProductCode
            // 
            this.btnGetProductCode.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGetProductCode.Appearance.Options.UseFont = true;
            this.btnGetProductCode.Location = new System.Drawing.Point(7, 207);
            this.btnGetProductCode.Name = "btnGetProductCode";
            this.btnGetProductCode.Size = new System.Drawing.Size(130, 26);
            this.btnGetProductCode.TabIndex = 1;
            this.btnGetProductCode.Text = "Get product code";
            // 
            // QuanLyMCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 391);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl7);
            this.Name = "QuanLyMCC";
            this.Text = "Quản lý máy chấm công";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            this.panelControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioMCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupMayChamCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl7;
        private DevExpress.XtraEditors.RadioGroup radioMCC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookupMayChamCong;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnXoaDuLieuQuetThe;
        private DevExpress.XtraEditors.SimpleButton btnRestartMCC;
        private DevExpress.XtraEditors.SimpleButton btnClearAdmin;
        private DevExpress.XtraEditors.SimpleButton btnGetSerialNumber;
        private DevExpress.XtraEditors.SimpleButton btnGetDeviceInfo;
        private DevExpress.XtraEditors.SimpleButton btnGetDeviceTime;
        private DevExpress.XtraEditors.SimpleButton btnGetProductCode;
    }
}