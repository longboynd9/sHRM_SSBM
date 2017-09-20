using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.Core.Business;
using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel.Account
{
    public partial class User2Roles : BackEndPageBase
    {
        //protected override void initRight()
        //{
        //    adm_FuncID = 18;
        //    adm_RequiredAdmin = true;
        //}

        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
           
            if (!IsPostBack)
            {
                KTNHOMQUYEN();
                LoadData();
            }
        }
        #region"Kiểm tra nhóm quyền"
        private void KTNHOMQUYEN()
        {
            if (!LoginHelper.user.isAdmin)
            {
                btnAdd.Visible = HasRight(Enums.eFunction.New);
                btnDel.Visible = HasRight(Enums.eFunction.Delete);
            }
        }
        #endregion
        #region sub
        void LoadData()
        {
            stoRole.DataSource = db.w5sysRoles;
            stoRole.DataBind();
        }

        void LoadAddUserData()
        {
            try
            {
                long idd = 0;
                RowSelectionModel rsm = grdRoles.GetSelectionModel() as RowSelectionModel;
                if (rsm.SelectedRow == null || !long.TryParse(rsm.SelectedRecordID, out idd))
                {
                    Tools.messageConfirmErr("Bạn cần chọn một người dùng để thêm vào nhóm quyền...");
                    return;
                }

                using (var db = new dcDatabaseDataContext((string)global::iHRM.Core.Business.Provider.ConnectionString))
                {

                    var lst = db.w5sysUsers.Where(i => (i.roleID == null || i.roleID != idd) && i.w5sysRole == null).Select(i => new
                    {
                        id = i.id,
                        loginid = i.loginID,
                        caption = i.caption,
                        role = (i.w5sysRole == null ? "-" : i.w5sysRole.caption)
                    });
                    stoAddUser.DataSource = lst;
                    stoAddUser.DataBind();
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }
        #endregion

        #region event
        protected void btnAdd_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            long idd = 0;
            RowSelectionModel rsm1 = grdRoles.GetSelectionModel() as RowSelectionModel;
            if (rsm1.SelectedRow == null || !long.TryParse(rsm1.SelectedRecordID, out idd))
            {
                Tools.messageConfirmErr("Bạn cần chọn nhóm quyền trước khi thêm người dùng...");
                return;
            }
            LoadAddUserData();
            wEditor.Show();
        }
        protected void btnDel_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            CheckboxSelectionModel rsm = grdUser.SelectionModel.Primary as CheckboxSelectionModel;
            if (rsm == null || rsm.SelectedRows.Count == 0)
            {
                Tools.messageConfirmErr("Bạn cần chọn một người dùng để xóa!");
                return;
            }

            using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
            {
                try
                {
                    var lstid = rsm.SelectedRows.Select(i => i.RecordID);
                    var lst = db.w5sysUsers.Where(i => lstid.Contains(i.id.ToString()));
                    foreach (var i in lst)
                        i.roleID = null;
                    db.SubmitChanges();

                    stoUser_RefreshData(null, null);
                    Tools.messageConfirmSuccess("Xóa người dùng thành công");
                }
                catch (Exception ex)
                {
                    Tools.messageEx(ex);
                }
            }
        }

        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {
            long idd = 0;
            RowSelectionModel rsm1 = grdRoles.GetSelectionModel() as RowSelectionModel;
            if (rsm1.SelectedRow == null || !long.TryParse(rsm1.SelectedRecordID, out idd))
            {
                Tools.messageConfirmErr("Bạn cần chọn nhóm quyền trước khi thêm người dùng...");
                return;
            }

            CheckboxSelectionModel rsm = grd_addUser.SelectionModel.Primary as CheckboxSelectionModel;
            if (rsm == null || rsm.SelectedRows.Count == 0)
            {
                Tools.messageConfirmErr("Bạn cần chọn người dùng để thêm vào nhóm quyền...!");
                return;
            }

            using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
            {
                try
                {
                    var lstid = rsm.SelectedRows.Select(i => i.RecordID);
                    var lst = db.w5sysUsers.Where(i => lstid.Contains(i.id.ToString()));
                    foreach (var i in lst)
                        i.roleID = idd;
                    db.SubmitChanges();

                    stoUser_RefreshData(null, null);
                    Tools.messageConfirmSuccess("Thêm tài khoản người dùng vào nhóm quyền thành công");
                    wEditor.Hide();
                }
                catch (Exception ex)
                {
                    Tools.messageEx(ex);
                }
            }
        }

        #endregion

        protected void stoRole_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            LoadData();
        }

        protected void stoUser_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            try
            {
                long idd = 0;
                RowSelectionModel rsm = grdRoles.GetSelectionModel() as RowSelectionModel;
                if (rsm.SelectedRow == null || !long.TryParse(rsm.SelectedRecordID, out idd))
                {
                    Tools.messageConfirmErr("Bạn chưa chọn nhóm quyền...");
                    return;
                }

                using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
                {
                    var lst = db.w5sysUsers.Where(i => i.roleID == idd);
                    stoUser.DataSource = lst;
                    stoUser.DataBind();
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }
    }
}