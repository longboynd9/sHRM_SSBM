using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class frmFunctions :  frmBase
    {
        DataTable Data;
        DataRow CRow;

        dlgFunctions _dlgEditor = null;
        dlgFunctions dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgFunctions();
                    dlgEditor.Owner = this;
                    dlgEditor.OnSave += dlgEditor_OnSave;
                }
                return _dlgEditor;
            }
            set
            {
                _dlgEditor = value;
            }
        }

        public frmFunctions()
        {
            InitializeComponent();
        }
        private void Department_Load(object sender, EventArgs e)
        {
            buttonPanel1_OnFind(null, null);
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var r = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as DataRowView;
            CRow = r == null ? null : r.Row;
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            CacheDataTable.ResetCacheOnTable("w5sysFunction");
            Data = CacheDataTable.GetCacheDataTable("w5sysFunction");
            treeList1.DataSource = Data;
        }
        private void buttonPanel1_OnNew(object sender, EventArgs e)
        {
            DataRow dr = Data.NewRow();
            dr["code"] = "";
            dr["sys_locked"] = false;
            dr["status"] = true;
            var r = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as DataRowView;
            if (r != null)
            {
                if (r.Row["id"] != null)
                {
                    dr["parentId"] = r == null ? null : r.Row["id"];
                }
            }
            else
            {
                dr["parentId"] = null;
            }
            dlgEditor.MyValue = dr;
            dlgEditor.Show();
        }
        private void buttonPanel1_OnEdit(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRow;
            dlgEditor.Show();
        }
        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            if (CRow == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var it = db.w5sysFunctions.SingleOrDefault(i => i.id == DbHelper.DrGetLong(CRow, "id"));

            if (it != null)
            {
                try
                {
                    if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa ?"))
                        return;
                    
                    db.w5sysFunctions.DeleteOnSubmit(it);
                    db.SubmitChanges();

                    Data.Rows.Remove(CRow);
                    treeList1_FocusedNodeChanged(null, null);
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                }
                catch(Exception ex)
                {
                    win_globall.ExecCatch(ex);
                }
            }
            else
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
            }
        }

        private void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                if (dlgEditor.myID == null || db.w5sysFunctions.Where(p => p.id == Convert.ToInt64(dlgEditor.myID)).FirstOrDefault() == null)
                {
                    var dep = new w5sysFunction();
                    SetDataContextFromDataRow(dep, dlgEditor.MyValue);
                    dep.parentId = CRow == null ? null : (long?)DbHelper.DrGetLong(CRow, "id");
                    db.w5sysFunctions.InsertOnSubmit(dep);
                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    Data.Rows.Add(dlgEditor.MyValue);
                }
                else
                {
                    var dep = db.w5sysFunctions.SingleOrDefault(i => i.id == (dlgEditor.myID as long?));
                    if (dep == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }
                    SetDataContextFromDataRow(dep, dlgEditor.MyValue);
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
            }
            catch(Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
    }
}
