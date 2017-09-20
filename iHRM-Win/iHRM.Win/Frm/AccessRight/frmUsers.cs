using iHRM.Core.i_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iHRM.Win.Cls;
using iHRM.Core.Business;
using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.AccessRight;

namespace iHRM.Win.Frm.AccessRight
{
    public partial class frmUsers : frmBase
    {
        Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        Core.Business.Logic.AccessRight.User logic = new User();

        DataTable DataRoles;
        DataRow CRowRoles;

        public frmUsers()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            buttonPanel1_OnFind(null, null);
        }

        private void buttonPanel1_OnFind(object sender, EventArgs e)
        {
            DataRoles = logic.GetAll();
            grd.DataSource = DataRoles;
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CRowRoles = grv.GetFocusedDataRow();
            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
        }
        
        dlgUsers _dlgEditor = null;
        dlgUsers dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgUsers();
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

        private void dlgEditor_OnSave(object sender, EventArgs e)
        {
            try
            {
                var db = new dcDatabaseDataContext(Provider.ConnectionString);
                if (dlgEditor.CustomFormAction == 0)
                {
                    w5sysUser r = new w5sysUser();
                    SetDataContextFromDataRow(r, dlgEditor.MyValue);
                    r.status = 1;
                    db.w5sysUsers.InsertOnSubmit(r);
                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    DataRoles.Rows.Add(dlgEditor.MyValue);
                }
                else
                {
                    var r = db.w5sysUsers.SingleOrDefault(i => i.id == (long)dlgEditor.myID);
                    if (r == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }

                    SetDataContextFromDataRow(r, dlgEditor.MyValue);
                    db.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.EditSuccess);
                }
            }
            catch (Exception ex)
            {
                win_globall.ExecCatch(ex);
            }
        }

        private void buttonPanel1_OnNew(object sender, EventArgs e)
        {
            dlgEditor.MyValue = DataRoles.NewRow();
            dlgEditor.CustomFormAction = 0;
            dlgEditor.Show();
        }

        private void buttonPanel1_OnEdit(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRowRoles;
            dlgEditor.CustomFormAction = 1;
            dlgEditor.Show();
        }

        private void buttonPanel1_OnDelete(object sender, EventArgs e)
        {
            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }
            
            try
            {
                using (var ts = new System.Transactions.TransactionScope())
                {
                    w5sysUser r1 = db.w5sysUsers.SingleOrDefault(i => i.id == (long)CRowRoles["id"]);
                    if (r1 == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }

                    //db.w5sysRules.DeleteAllOnSubmit(r1.w5sysRules);
                    //db.SubmitChanges();

                    db.w5sysUsers.DeleteOnSubmit(r1);
                    db.SubmitChanges();
                    
                    ts.Complete();

                    DataRoles.Rows.Remove(CRowRoles);
                    grv_FocusedRowChanged(null, null);
                }

                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                return;
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, "Xóa nhóm quyền không thành công");
                return;
            }

        }

        private void grv_DoubleClick(object sender, EventArgs e)
        {
            dlgEditor.MyValue = CRowRoles;
            dlgEditor.CustomFormAction = 1;
            dlgEditor.Show();
        }
    }
}
