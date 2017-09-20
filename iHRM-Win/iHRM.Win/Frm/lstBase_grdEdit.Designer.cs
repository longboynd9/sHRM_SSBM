namespace iHRM.Win.Frm
{
    partial class lstBase_grdEdit
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
            this.buttonPanel1 = new iHRM.Win.UC.ButtonPanel(this.components);
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
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
            this.buttonPanel1.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.buttonPanel1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.buttonPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.showButtonChoose = false;
            this.buttonPanel1.showButtonDelete = true;
            this.buttonPanel1.showButtonEdit = false;
            this.buttonPanel1.showButtonExit = true;
            this.buttonPanel1.showButtonExport = false;
            this.buttonPanel1.showButtonFind = true;
            this.buttonPanel1.showButtonImport = false;
            this.buttonPanel1.showButtonNew = false;
            this.buttonPanel1.showButtonPrint = false;
            this.buttonPanel1.showButtonSave = true;
            this.buttonPanel1.ShowStyle = iHRM.Win.UC.ButtonPanel.eShowStyle.Custom;
            this.buttonPanel1.Size = new System.Drawing.Size(772, 42);
            this.buttonPanel1.TabIndex = 2;
            this.buttonPanel1.Text = "buttonPanel1";
            this.buttonPanel1.TextAndImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPanel1.useButtonChoose = false;
            this.buttonPanel1.useButtonDelete = true;
            this.buttonPanel1.useButtonEdit = false;
            this.buttonPanel1.useButtonExit = true;
            this.buttonPanel1.useButtonExport = false;
            this.buttonPanel1.useButtonFind = true;
            this.buttonPanel1.useButtonImport = false;
            this.buttonPanel1.useButtonNew = false;
            this.buttonPanel1.useButtonPrint = false;
            this.buttonPanel1.useButtonSave = true;
            this.buttonPanel1.OnFind += new System.EventHandler(this.buttonPanel1_OnFind);
            this.buttonPanel1.OnSave += new System.EventHandler(this.buttonPanel1_OnSave);
            this.buttonPanel1.OnDelete += new System.EventHandler(this.buttonPanel1_OnDelete);
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 42);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grd.Size = new System.Drawing.Size(772, 326);
            this.grd.TabIndex = 3;
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
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.NewItemRowText = "Thêm mới dữ liệu";
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsEditForm.EditFormColumnCount = 1;
            this.grv.OptionsSelection.MultiSelect = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grv.OptionsView.ShowAutoFilterRow = true;
            this.grv.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Xóa";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // lstBase_grdEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 368);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.buttonPanel1);
            this.Name = "lstBase_grdEdit";
            this.Text = "frmBaseList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBaseList_grdEdit_FormClosed);
            this.Load += new System.EventHandler(this.frmBaseList_grdEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UC.ButtonPanel buttonPanel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.GridControl grd;
    }
}