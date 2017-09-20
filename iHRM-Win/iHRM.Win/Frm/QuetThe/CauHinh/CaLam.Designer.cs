namespace iHRM.Win.Frm.QuetThe.CauHinh
{
    partial class CaLam
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
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonPanel1 = new iHRM.Win.UC.ButtonPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 44);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(762, 312);
            this.grd.TabIndex = 1;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grv_FocusedRowChanged);
            this.grv.DoubleClick += new System.EventHandler(this.buttonPanel1_OnEdit);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Ca làm";
            this.gridColumn1.FieldName = "ten";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 198;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Từ giờ";
            this.gridColumn2.DisplayFormat.FormatString = "{0:HH:mm}";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "tuGio";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 63;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số tiếng";
            this.gridColumn3.DisplayFormat.FormatString = "HH:mm";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "denGio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 82;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Số tiếng tính ca";
            this.gridColumn4.DisplayFormat.FormatString = "#,0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "soTiengTinhCa";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 96;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TC trách nhiệm";
            this.gridColumn5.DisplayFormat.FormatString = "#,0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "soTiengTangCaTrachNhiem";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 142;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số tiếng tính tăng ca";
            this.gridColumn6.DisplayFormat.FormatString = "#,0";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "soTiengTinhTangCa";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 128;
            // 
            // buttonPanel1
            // 
            this.buttonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonPanel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.buttonPanel1.enableButtonChoose = true;
            this.buttonPanel1.enableButtonDelete = true;
            this.buttonPanel1.enableButtonEdit = true;
            this.buttonPanel1.enableButtonExit = true;
            this.buttonPanel1.enableButtonExport = true;
            this.buttonPanel1.enableButtonFind = true;
            this.buttonPanel1.enableButtonImport = true;
            this.buttonPanel1.enableButtonNew = true;
            this.buttonPanel1.enableButtonPrint = true;
            this.buttonPanel1.enableButtonSave = true;
            this.buttonPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonPanel1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.buttonPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.showButtonChoose = false;
            this.buttonPanel1.showButtonDelete = true;
            this.buttonPanel1.showButtonEdit = true;
            this.buttonPanel1.showButtonExit = true;
            this.buttonPanel1.showButtonExport = false;
            this.buttonPanel1.showButtonFind = true;
            this.buttonPanel1.showButtonImport = false;
            this.buttonPanel1.showButtonNew = true;
            this.buttonPanel1.showButtonPrint = false;
            this.buttonPanel1.showButtonSave = false;
            this.buttonPanel1.ShowStyle = iHRM.Win.UC.ButtonPanel.eShowStyle.Custom;
            this.buttonPanel1.Size = new System.Drawing.Size(762, 44);
            this.buttonPanel1.TabIndex = 0;
            this.buttonPanel1.Text = "buttonPanel1";
            this.buttonPanel1.TextAndImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPanel1.useButtonChoose = false;
            this.buttonPanel1.useButtonDelete = true;
            this.buttonPanel1.useButtonEdit = true;
            this.buttonPanel1.useButtonExit = true;
            this.buttonPanel1.useButtonExport = false;
            this.buttonPanel1.useButtonFind = true;
            this.buttonPanel1.useButtonImport = false;
            this.buttonPanel1.useButtonNew = true;
            this.buttonPanel1.useButtonPrint = false;
            this.buttonPanel1.useButtonSave = false;
            this.buttonPanel1.OnFind += new System.EventHandler(this.buttonPanel1_OnFind);
            this.buttonPanel1.OnNew += new System.EventHandler(this.buttonPanel1_OnNew);
            this.buttonPanel1.OnEdit += new System.EventHandler(this.buttonPanel1_OnEdit);
            this.buttonPanel1.OnDelete += new System.EventHandler(this.buttonPanel1_OnDelete);
            // 
            // CaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 356);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.buttonPanel1);
            this.Name = "CaLam";
            this.Text = "CaLam";
            this.Load += new System.EventHandler(this.CaLam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC.ButtonPanel buttonPanel1;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}