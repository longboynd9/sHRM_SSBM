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
    public partial class User : BackEndPageBase
    {
        //protected override void initRight()
        //{
        //    adm_FuncID = 19;
        //    adm_RequiredAdmin = true;
        //}

        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack)
            {
                KTNHOMQUYEN();
                LoadPreData();
                LoadData();
            }
        }

        #region"Kiểm tra nhóm quyền"
        private void KTNHOMQUYEN()
        {
            if (!LoginHelper.user.isAdmin)
            {
                txtSearch.Visible = btnSearch.Visible = HasRight(Enums.eFunction.Choose);
                btnAdd.Visible = HasRight(Enums.eFunction.New);
                //grp.ColumnModel.SetHidden(5, true);
                //if (!HasRight(Enums.eFunction.Delete))
                //    (grp.ColumnModel.Columns[5] as ImageCommandColumn).Commands.RemoveAt(1);
                //if (!HasRight(Enums.eFunction.Edit))
                //    (grp.ColumnModel.Columns[5] as ImageCommandColumn).Commands.RemoveAt(0);

                //làm cách trên ko ổn định nếu thêm sửa xóa cột thì die
                var c = grp.ColumnModel.Columns.AsEnumerable().SingleOrDefault(i => i.ColumnID == "commandbutton");
                if (c != null && c is ImageCommandColumn)
                {
                    ImageCommandColumn imgCmd = (c as ImageCommandColumn);
                    if (!HasRight(Enums.eFunction.Delete))
                        imgCmd.Commands.Remove(imgCmd.Commands.AsEnumerable().SingleOrDefault(i => i.CommandName == "Delete"));
                    if (!HasRight(Enums.eFunction.Edit))
                        imgCmd.Commands.Remove(imgCmd.Commands.AsEnumerable().SingleOrDefault(i => i.CommandName == "Edit"));
                }
            }
        }
        #endregion
        
        void LoadPreData()
        {
            stoRoles.DataSource = db.w5sysRoles.OrderByDescending(c => c.id);
            stoRoles.DataBind();
        }

        void LoadData(string filter = "")
        {
            Store1.DataSource = db.w5sysUsers.Where(i => string.IsNullOrWhiteSpace(filter) || i.caption.Contains(filter) || i.loginID.Contains(filter) || i.description.Contains(filter) || i.w5sysRole.caption.Contains(filter)).OrderBy(c => c.loginID);
            Store1.DataBind();
        }
        protected void Store1_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// sự kiện command trong gridpanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCommand(object sender, DirectEventArgs e)
        {
            
            try
            {
                string commandId = e.ExtraParams["id"];
                string commandName = e.ExtraParams["command123"];

                switch (commandName)
                {
                    case "Edit":
                        EditRecord(commandId);
                        break;
                    case "Delete":
                        DeleteRecord(commandId);
                        break;
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }

        void EditRecord(string id)
        {
            w5sysUser item = db.w5sysUsers.SingleOrDefault(i => i.id.ToString().Equals(id));
            if (item == null)
            {
                Tools.message(Lng.common_msg.RecordNotFound);
                return;
            }
            else
            {
                hId.Value = item.id;
                //formCT.SetValues(item);
                txtLoginID.Text = item.loginID;
                string pw = "";
                for (int i = 0; i < item.loginPW.Length; i++)
                    pw += "*";
                txtLoginPW.Text = pw;
                txtCaption.Text = item.caption;
                //item.linkID;
                if (item.isAdmin == true)
                {
                    chkIsAdmin.Show();
                    chkIsAdmin.Checked = item.isAdmin;
                }
                else
                    chkIsAdmin.Hide();
                cmbRole.Value = item.roleID;
                txtDescription.Text = item.description;
                txtEmail.Text = item.Email;
                btnClear.Hidden = true;
                chkChangePW.Checked = chkChangePW_text.Hidden = chkChangePW.Hidden = false;

                wEditor.Show();
                wEditor.Icon = Icon.User;
                wEditor.SetTitle("Chỉnh sửa người dùng " + item.caption);
            }
        }
        void DeleteRecord(string id)
        {
            try
            {
                w5sysUser item = db.w5sysUsers.SingleOrDefault(i => i.id.ToString().Equals(id));
                if (item.isAdmin) {
                    Tools.messageConfirmErr("Tài khoản này là quản trị viên không được xóa");
                    return;
                }
                db.w5sysUsers.DeleteOnSubmit(item);
                db.SubmitChanges();

                Tools.messageConfirmSuccess(Lng.common_msg.Delete_Success);
                //LoadData();
                X.AddScript("Store1.remove(Store1.getById('" + item.id + "'));");
            }
            catch (Exception ex)
            {
                Tools.messageConfirmErr("Tài khoản người dùng này đã có dữ liệu trên hệ thống. Không được xóa");
                return;
            }
        }

        /// <summary>
        /// Double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnDblClick(object sender, DirectEventArgs e)
        {
            try
            {
                EditRecord(e.ExtraParams["id"]);
            }
            catch (Exception ex)
            {
                if (globall.indebug)
                    throw;

                Tools.messageConfirmErr(string.Format(Lng.common_msg.Error_While_Exec, ex.Message));
                return;
            }
        }

        protected void btnAdd_DirectClick(object sender, DirectEventArgs e)
        {
            hId.Value = "";
            formCT.Reset();
            btnClear.Hidden = false;
            chkChangePW.Checked = chkChangePW_text.Hidden = chkChangePW.Hidden = true;

            wEditor.Show();
            wEditor.Icon = Icon.Add;
            wEditor.SetTitle("Thêm người dùng");
        }

        protected void btnSearch_DirectClick(object sender, DirectEventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim(' ', '\t');
            LoadData(txtSearch.Text);
        }

        void getFormValue(w5sysUser u)
        {
            u.loginID = txtLoginID.Text;
            if (chkChangePW.Checked)
                u.loginPW = txtLoginPW.Text;
            //u.linkID = cmbDV.Value as string;
            u.caption = txtCaption.Text;
            //if (LoginHelper.user.isAdmin)
            //    u.isAdmin = chkIsAdmin.Checked;

            u.roleID = Convert.ToInt64(cmbRole.Value);
            u.description = txtDescription.Text;
            u.Email = txtEmail.Text;
        }
        
        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hId.Value as string))
                {
                    if (string.IsNullOrWhiteSpace(txtLoginID.Text) || string.IsNullOrWhiteSpace(txtLoginPW.Text) || txtEmail.Text=="" || txtCaption.Text=="")
                    {
                        Tools.messageConfirmErr("Chưa điền tên đăng nhập hoặc mật khẩu hoặc tên hiển thị hoặc email");
                        return;
                    }
                    var check = db.w5sysUsers.SingleOrDefault(c => c.loginID == txtLoginID.Text);
                    if (check != null)
                    {
                        Tools.messageConfirmErr("Tên đăng nhập này đã được sử dụng");
                        return;
                    }
                    var checkemail = db.w5sysUsers.SingleOrDefault(c => c.Email == txtEmail.Text);
                    if (checkemail != null)
                    {
                        Tools.messageConfirmErr("Email này đã được sử dụng");
                        return;
                    }

                   

                    w5sysUser u = new w5sysUser();
                    getFormValue(u);
                    db.w5sysUsers.InsertOnSubmit(u);
                    db.SubmitChanges();

                    Tools.messageConfirmSuccess(Lng.common_msg.Add_Success);
                    formCT.Reset();
                    LoadData();
                    //Store1.AddScript("{0}.insertRecord(0, {1}); {0}.commitChanges();", Store1.ClientID, JSON.Serialize(u));
                }
                else
                {
                    w5sysUser u = db.w5sysUsers.SingleOrDefault(i => i.id.ToString().Equals(hId.Value.ToString()));
                    if (u == null)
                    {
                        Tools.messageConfirmErr(Lng.common_msg.RecordNotFound);
                        return;
                    }


                    var check = db.w5sysUsers.SingleOrDefault(c => c.loginID == txtLoginID.Text && c.loginID != u.loginID);
                    if (check != null)
                    {
                        Tools.messageConfirmErr("Tên đăng nhập này đã được sử dụng");
                        return;
                    }
                    var checkemail = db.w5sysUsers.SingleOrDefault(c => c.Email == txtEmail.Text && c.Email != u.Email);
                    if (checkemail != null)
                    {
                        Tools.messageConfirmErr("Email này đã được sử dụng");
                        return;
                    }
                    getFormValue(u);
                    db.SubmitChanges();

                    Tools.messageConfirmSuccess(Lng.common_msg.Edit_Success);
                    wEditor.Hidden = true;
                    LoadData();
                    //X.AddScript(string.Format("Store1_UpdateRecord('{0}', '{1}');", hId.Value, JSON.Serialize(u)));
                }
            }
            catch (Exception ex)
            {
                Tools.messageConfirmErr(string.Format(Lng.common_msg.Error_While_Exec, ex));
            }
        }

        protected void txtLoginID_Validation(object sender, RemoteValidationEventArgs e)
        {
            string value = ((TextField)sender).Text.Trim(' ', '\t', '\r', '\n');

            e.Success = true;
            if (string.IsNullOrWhiteSpace(value) || db.w5sysUsers.FirstOrDefault(i => i.loginID.ToString().Equals(value) && (string.IsNullOrWhiteSpace(hId.Value as string) || i.loginID != value)) != null)
            {
                e.Success = false;
                e.ErrorMessage = string.Format(Lng.common_msg.Record_Duplicate, "Login ID", txtLoginID.Text);
            }
        }
    }
}