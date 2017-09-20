
namespace iHRM.Win.Frm.AccessRight
{
    partial class frmRoles
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonPanel1 = new iHRM.Win.UC.ButtonPanel(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.buttonPanel2 = new iHRM.Win.UC.ButtonPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grd);
            this.splitContainerControl1.Panel1.Controls.Add(this.buttonPanel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.treeList1);
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonPanel2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1110, 398);
            this.splitContainerControl1.SplitterPosition = 249;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd.Location = new System.Drawing.Point(0, 42);
            this.grd.MainView = this.grv;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(249, 356);
            this.grd.TabIndex = 2;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            // 
            // grv
            // 
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grv.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsDetail.EnableMasterViewMode = false;
            this.grv.OptionsDetail.ShowDetailTabs = false;
            this.grv.OptionsView.ShowDetailButtons = false;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grv_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 65;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nhóm";
            this.gridColumn2.FieldName = "caption";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 166;
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
            this.buttonPanel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPanel1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.buttonPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.showButtonChoose = false;
            this.buttonPanel1.showButtonDelete = true;
            this.buttonPanel1.showButtonEdit = true;
            this.buttonPanel1.showButtonExit = false;
            this.buttonPanel1.showButtonExport = false;
            this.buttonPanel1.showButtonFind = false;
            this.buttonPanel1.showButtonImport = false;
            this.buttonPanel1.showButtonNew = true;
            this.buttonPanel1.showButtonPrint = false;
            this.buttonPanel1.showButtonSave = false;
            this.buttonPanel1.ShowStyle = iHRM.Win.UC.ButtonPanel.eShowStyle.Custom;
            this.buttonPanel1.Size = new System.Drawing.Size(249, 42);
            this.buttonPanel1.TabIndex = 0;
            this.buttonPanel1.Text = "buttonPanel1";
            this.buttonPanel1.TextAndImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPanel1.useButtonChoose = false;
            this.buttonPanel1.useButtonDelete = true;
            this.buttonPanel1.useButtonEdit = true;
            this.buttonPanel1.useButtonExit = false;
            this.buttonPanel1.useButtonExport = false;
            this.buttonPanel1.useButtonFind = false;
            this.buttonPanel1.useButtonImport = false;
            this.buttonPanel1.useButtonNew = true;
            this.buttonPanel1.useButtonPrint = false;
            this.buttonPanel1.useButtonSave = false;
            this.buttonPanel1.OnNew += new System.EventHandler(this.buttonPanel1_OnNew);
            this.buttonPanel1.OnEdit += new System.EventHandler(this.buttonPanel1_OnEdit);
            this.buttonPanel1.OnDelete += new System.EventHandler(this.buttonPanel1_OnDelete);
            // 
            // treeList1
            // 
            this.treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList1.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.Row.Options.UseFont = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeList1.KeyFieldName = "id";
            this.treeList1.Location = new System.Drawing.Point(0, 42);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.EnableFiltering = true;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.ParentFieldName = "parentID";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.treeList1.Size = new System.Drawing.Size(856, 356);
            this.treeList1.TabIndex = 2;
            this.treeList1.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanging);
            this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.treeListColumn2.AppearanceCell.Options.UseFont = true;
            this.treeListColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.treeListColumn2.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn2.Caption = "Chức năng";
            this.treeListColumn2.FieldName = "funcName";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            this.treeListColumn2.Width = 755;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.Caption = "Rules";
            this.treeListColumn1.ColumnEdit = this.repositoryItemCalcEdit1;
            this.treeListColumn1.FieldName = "rule";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.FixedWidth = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 1;
            this.treeListColumn1.Width = 83;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // buttonPanel2
            // 
            this.buttonPanel2.BackColor = System.Drawing.Color.Transparent;
            this.buttonPanel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.buttonPanel2.enableButtonChoose = true;
            this.buttonPanel2.enableButtonDelete = true;
            this.buttonPanel2.enableButtonEdit = true;
            this.buttonPanel2.enableButtonExit = true;
            this.buttonPanel2.enableButtonExport = true;
            this.buttonPanel2.enableButtonFind = true;
            this.buttonPanel2.enableButtonImport = true;
            this.buttonPanel2.enableButtonNew = true;
            this.buttonPanel2.enableButtonPrint = true;
            this.buttonPanel2.enableButtonSave = true;
            this.buttonPanel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPanel2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.buttonPanel2.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel2.Name = "buttonPanel2";
            this.buttonPanel2.showButtonChoose = false;
            this.buttonPanel2.showButtonDelete = false;
            this.buttonPanel2.showButtonEdit = false;
            this.buttonPanel2.showButtonExit = false;
            this.buttonPanel2.showButtonExport = false;
            this.buttonPanel2.showButtonFind = false;
            this.buttonPanel2.showButtonImport = false;
            this.buttonPanel2.showButtonNew = false;
            this.buttonPanel2.showButtonPrint = false;
            this.buttonPanel2.showButtonSave = true;
            this.buttonPanel2.ShowStyle = iHRM.Win.UC.ButtonPanel.eShowStyle.Custom;
            this.buttonPanel2.Size = new System.Drawing.Size(856, 42);
            this.buttonPanel2.TabIndex = 1;
            this.buttonPanel2.Text = "buttonPanel2";
            this.buttonPanel2.TextAndImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPanel2.useButtonChoose = false;
            this.buttonPanel2.useButtonDelete = false;
            this.buttonPanel2.useButtonEdit = false;
            this.buttonPanel2.useButtonExit = false;
            this.buttonPanel2.useButtonExport = false;
            this.buttonPanel2.useButtonFind = false;
            this.buttonPanel2.useButtonImport = false;
            this.buttonPanel2.useButtonNew = false;
            this.buttonPanel2.useButtonPrint = false;
            this.buttonPanel2.useButtonSave = true;
            this.buttonPanel2.OnSave += new System.EventHandler(this.buttonPanel2_OnSave);
            // 
            // frmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 398);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmRoles";
            this.Text = "Nhóm quyền";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private UC.ButtonPanel buttonPanel1;
        private UC.ButtonPanel buttonPanel2;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
    }
}