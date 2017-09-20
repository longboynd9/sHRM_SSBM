using iHRM.Core.Business;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm
{
    public partial class lstBase_grdEdit : frmBase
    {
        protected LstData lstData = new LstData();
        public LstData LstData
        {
            get { return lstData; }
            set { lstData = value; }
        }

        DataTable dtData;

        public lstBase_grdEdit()
        {
            InitializeComponent();
        }

        private void frmBaseList_grdEdit_Load(object sender, EventArgs e)
        {
            this.Text = lstData.FormCaption;

            foreach (var it in lstData.GrdColumns)
            {
                DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

                gridColumn1.Caption = it.Caption;
                gridColumn1.FieldName = it.DataIndex;
                gridColumn1.Visible = it.Visible;
                gridColumn1.VisibleIndex = grv.Columns.Count;
                if (it.Width > 0)
                    gridColumn1.Width = it.Width;

                grv.Columns.Add(gridColumn1);
            }

            var gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn4.Caption = "Xóa";
            gridColumn4.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            gridColumn4.OptionsColumn.FixedWidth = true;
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = grv.Columns.Count;
            grv.Columns.Add(gridColumn4);

            LoadGrvLayout(grv, lstData.TableName);
            buttonPanel1_OnFind(null, null);
            grd.DataSource = dtData;
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            dtData = Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM [{0}]", lstData.TableName));
        }
        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            var rows = grv.GetSelectedRows().Select(i => grv.GetDataRow(i)).ToList();
            for (int i = rows.Count - 1; i >= 0; i--)
                rows[i].Delete();
        }
        private void buttonPanel1_OnSave(object sender, EventArgs e)
        {
            try
            {
                Provider.UpdateData(dtData, lstData.TableName);
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        protected virtual void OnInitNewRow(ref DataRow r) { }

        private void grv_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var dr = grv.GetDataRow(e.RowHandle);
            if (dr != null)
                OnInitNewRow(ref dr);
        }
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            var it = grv.GetFocusedDataRow() as DataRow;
            if (it != null)
                it.Delete();
        }

        private void frmBaseList_grdEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv, lstData.TableName);
        }
    }
}
