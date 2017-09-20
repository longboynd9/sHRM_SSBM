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

namespace iHRM.Win.Frm.Category
{
    public partial class Department : frmBase
    {
        DataTable Data;
        DataRow CRow;

        dlgDepartment _dlgEditor = null;
        dlgDepartment dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgDepartment();
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

        public Department()
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
            CacheDataTable.ResetCacheOnTable(TableConst.tblRef_Department.TableName);
            Data = CacheDataTable.GetCacheDataTable(TableConst.tblRef_Department.TableName);
            treeList1.DataSource = Data;
        }
        private void buttonPanel1_OnNew(object sender, EventArgs e)
        {
            dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
            DataRow dr = Data.NewRow();
            var dt = db.tblRef_Departments.OrderByDescending(p => Convert.ToInt16(p.DepID)).FirstOrDefault();
            if (dt != null)
            {
                dr["DepID"] = Convert.ToInt16(dt.DepID) + 1;
            }
            else
            {
                dr["DepID"] = 1;
            }
            var r = treeList1.GetDataRecordByNode(treeList1.FocusedNode) as DataRowView;
            dr["DepParent"] = r == null ? null : r.Row["DepID"];
            if (r != null)
            {
                if (r.Row["DepTypeID"] != null)
                {
                    dr["DepTypeID"] = r == null ? null : (Convert.ToInt16(r.Row["DepTypeID"]) + 1).ToString();
                }
            }
            else
            {
                dr["DepTypeID"] = 0;
                dr["Path"] = dr["DepID"] +"/";
            }

            dlgEditor.MyValue = null;
            dlgEditor.MyValue = dr;
            dlgEditor.setReadonlyControl(true);
            dlgEditor.Show();
        }
        private void buttonPanel1_OnEdit(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRow;
            dlgEditor.setReadonlyControl(true);
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
            var it = db.tblRef_Departments.SingleOrDefault(i => i.DepID == DbHelper.DrGetString(CRow, TableConst.tblRef_Department.DepID));

            if (it != null)
            {
                try
                {
                    if (!GUIHelper.ConfirmBox("Bạn chắc chắn muốn xóa ?"))
                        return;

                    db.tblRef_Departments.DeleteOnSubmit(it);
                    db.SubmitChanges();

                    Data.Rows.Remove(CRow);
                    treeList1_FocusedNodeChanged(null, null);
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.DelSuccess);
                }
                catch (Exception ex)
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
                var dep2 = db.tblRef_Departments.SingleOrDefault(i => i.DepID == (dlgEditor.myID as string));
                if (dep2 == null)
                {
                    var dep = new tblRef_Department();
                    SetDataContextFromDataRow(dep, dlgEditor.MyValue);
                    dep.DepParent = CRow == null ? null : DbHelper.DrGetString(CRow, TableConst.tblRef_Department.DepID);
                    db.tblRef_Departments.InsertOnSubmit(dep);
                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    Data.Rows.Add(dlgEditor.MyValue);
                }
                else
                {
                    var dep = db.tblRef_Departments.SingleOrDefault(i => i.DepID == (dlgEditor.myID as string));
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
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }
    }
}
