namespace iHRM.Win.Frm.AccessRight
{
    partial class dlgUser2Role
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgUser2Role));
            this.grd2 = new DevExpress.XtraGrid.GridControl();
            this.grv2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Size = new System.Drawing.Size(628, 70);
            this.panel1.Controls.SetChildIndex(this.btnSave, 0);
            // 
            // grd2
            // 
            this.grd2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd2.Location = new System.Drawing.Point(0, 70);
            this.grd2.MainView = this.grv2;
            this.grd2.Name = "grd2";
            this.grd2.Size = new System.Drawing.Size(628, 292);
            this.grd2.TabIndex = 4;
            this.grd2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv2});
            // 
            // grv2
            // 
            this.grv2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.grv2.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv2.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.grv2.Appearance.Row.Options.UseFont = true;
            this.grv2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn6});
            this.grv2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv2.GridControl = this.grd2;
            this.grv2.Name = "grv2";
            this.grv2.OptionsBehavior.Editable = false;
            this.grv2.OptionsCustomization.AllowFilter = false;
            this.grv2.OptionsDetail.EnableMasterViewMode = false;
            this.grv2.OptionsDetail.ShowDetailTabs = false;
            this.grv2.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.grv2.OptionsSelection.MultiSelect = true;
            this.grv2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grv2.OptionsView.ShowAutoFilterRow = true;
            this.grv2.OptionsView.ShowDetailButtons = false;
            this.grv2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên đăng nhập";
            this.gridColumn3.FieldName = "loginID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 133;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tên hiển thị";
            this.gridColumn4.FieldName = "caption";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 156;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nhóm quyền";
            this.gridColumn1.FieldName = "roleCaption";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 156;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ghi chú";
            this.gridColumn6.FieldName = "description";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 216;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::iHRM.Win.Properties.Resources.btnSave_Image;
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(537, 36);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Lưu lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dlgUser2Role
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 362);
            this.Controls.Add(this.grd2);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Form_Description = "Chọn các nhân viên cho nhóm quyền ";
            this.Form_Image = ((System.Drawing.Image)(resources.GetObject("$this.Form_Image")));
            this.Form_Title = "Gán nhóm quyền cho nhân viên";
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlgUser2Role";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgUser2Role_FormClosing);
            this.Load += new System.EventHandler(this.dlgUser2Role_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grd2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grd2;
        private DevExpress.XtraGrid.Views.Grid.GridView grv2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}