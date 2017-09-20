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
    public partial class frmUser2Role : frmBase
    {
        Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        Core.Business.Logic.AccessRight.Role logicR = new Core.Business.Logic.AccessRight.Role();
        Core.Business.Logic.AccessRight.User logicU = new User();

        DataTable DataRoles;
        DataRow CRowRoles;

        dlgUser2Role dlgAddUser;

        public frmUser2Role()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            DataRoles = CacheDataTable.GetCacheDataTable("w5sysRole");
            grd.DataSource = DataRoles;

            LoadGrvLayout(grv);
            LoadGrvLayout(grv2, "g2");
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
            SaveGrvLayout(grv2, "g2");
        }

        private void grv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CRowRoles = grv.GetFocusedDataRow();
            buttonPanel2_OnFind(null, null);
        }

        #region control nhom quyen

        dlgRoles _dlgEditor = null;
        dlgRoles dlgEditor
        {
            get
            {
                if (_dlgEditor == null)
                {
                    _dlgEditor = new dlgRoles();
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
                    w5sysRole r = new w5sysRole();
                    SetDataContextFromDataRow(r, dlgEditor.MyValue);
                    r.status = 1;
                    db.w5sysRoles.InsertOnSubmit(r);
                    db.SubmitChanges();

                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.AddSuccess);
                    DataRoles.Rows.Add(dlgEditor.MyValue);
                }
                else
                {
                    var r = db.w5sysRoles.SingleOrDefault(i => i.id == (long)dlgEditor.myID);
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
                    w5sysRole r1 = db.w5sysRoles.SingleOrDefault(i => i.id == (long)CRowRoles["id"]);
                    if (r1 == null)
                    {
                        GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                        return;
                    }

                    db.w5sysRules.DeleteAllOnSubmit(r1.w5sysRules);
                    db.SubmitChanges();

                    db.w5sysRoles.DeleteOnSubmit(r1);
                    db.SubmitChanges();
                    
                    ts.Complete();
                }

                CRowRoles.Delete();
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                return;
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, "Xóa nhóm quyền không thành công");
                return;
            }

        }

        #endregion

        private void buttonPanel2_OnFind(object sender, EventArgs e)
        {
            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu nhân viên theo nhóm quyền...";
            dw_it.OnDoing = (s, ev) =>
            {
                var data = logicU.GetAll((long)CRowRoles["id"]);
                dw_it.bw.ReportProgress(1, data);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                grd2.DataSource = data.UserState;
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }
        
        private void buttonPanel2_OnNew(object sender, EventArgs e)
        {
            if (dlgAddUser == null)
            {
                dlgAddUser = new dlgUser2Role();
            }

            if (CRowRoles == null)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.PleaseChooseRecord);
                return;
            }

            List<long> lstSelected = new List<long>();
            var dt = grd2.DataSource as DataTable;
            if (dt != null)
                lstSelected.AddRange(dt.Select().Select(i => (long)i["id"]));
            dlgAddUser.SelectedID = lstSelected;

            if (dlgAddUser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var db1 = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
                    foreach (var uID in dlgAddUser.SelectedID)
                    {
                        var u = db1.w5sysUsers.SingleOrDefault(i => i.id == uID);
                        if (u != null)
                            u.roleID = (long)CRowRoles["id"];
                    }
                    db1.SubmitChanges();
                    GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.SaveSuccess);
                }
                catch(Exception ex)
                {
                    GUIHelper.MessageBox(ex.Message, "Lưu không thành công");
                }
            }
        }
    }
}
