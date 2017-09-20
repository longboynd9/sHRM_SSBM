using iHRM.Core.Business;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.AccessRight;

namespace iHRM.WebPC.Cpanel.Account
{
    public partial class Role1 : BackEndPageBase
    {
        //protected override void initRight()
        //{
        //    adm_FuncID = 17;
        //    adm_RequiredAdmin = true;
        //}

        dcDatabaseDataContext db;
        Core.Business.Logic.AccessRight.Role logic = new Role();

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);

            if (!IsPostBack)
            {
                KTNHOMQUYEN();
                //LoadPreData();
                LoadData();
                LoadFuncTree();
            }
        }
        #region"Kiểm tra nhóm quyền"
        private void KTNHOMQUYEN()
        {
            if (!LoginHelper.user.isAdmin)
            {
                btnAdd.Visible = HasRight(Enums.eFunction.New);
                btnDel.Visible = HasRight(Enums.eFunction.Delete);
                btnSave.Visible = HasRight(Enums.eFunction.Save);
                btnEdit.Visible = HasRight(Enums.eFunction.Edit);
            }
        }
        #endregion
        #region sub
        void LoadPreData()
        {
            foreach (Enums.eFunction e in Enum.GetValues(typeof(Enums.eFunction)))
            {
                if ((int)e == 0)
                    continue;

                grdRule.ColumnModel.Columns.Add(new Ext.Net.CheckColumn()
                {
                    Header = e.ToString(),
                    DataIndex = e.ToString(),
                    ColumnID = ((int)e).ToString(),
                    Width = 50,

                    //Renderer = new Renderer() { Fn = "hasFunction" },
                    Editable = true
                });

                stoRule.Reader[0].Fields.Add(new Ext.Net.RecordField()
                {
                    Name = e.ToString()
                });
            }
        }

        void LoadData()
        {
            stoRole.DataSource = db.w5sysRoles;
            stoRole.DataBind();
        }

        #endregion

        #region event
        protected void btnAdd_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            formCT.Reset();
            hId.Value = "0";
            btnClear.Hidden = false;
            wEditor.Show();
            wEditor.Title = "Thêm mới nhóm quyền";
        }
        protected void btnEdit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            RowSelectionModel rsm = grdRoles.SelectionModel.Primary as RowSelectionModel;
            long idd = 0;
            if (rsm == null || rsm.SelectedRow == null || !long.TryParse(rsm.SelectedRecordID, out idd))
            {
                Tools.messageConfirmErr("Chọn nhóm quyền!");
                return;
            }

            w5sysRole r = db.w5sysRoles.SingleOrDefault(i => i.id == idd);
            if (r == null)
            {
                Tools.messageConfirmErr("Nhóm quyền không tồn tại!!!");
                return;
            }

            hId.Value = r.id;
            txtCode.Text = r.code;
            txtCaption.Text = r.caption;
            txtDesc.Text = r.description;
            btnClear.Hidden = true;
            wEditor.Show();
            wEditor.Title = "Sửa nhóm quyền: " + r.caption;
        }
        protected void btnDel_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            RowSelectionModel rsm = grdRoles.SelectionModel.Primary as RowSelectionModel;
            long idd = 0;
            if (rsm == null || rsm.SelectedRow == null || !long.TryParse(rsm.SelectedRecordID, out idd))
            {
                Tools.messageConfirmErr("Chọn nhóm quyền khi trước khi xóa!");
                return;
            }


            w5sysRole r = db.w5sysRoles.SingleOrDefault(i => i.id == idd);
            try
            {
                using (var ts = new TransactionScope())
                {
                    db.w5sysRules.DeleteAllOnSubmit(r.w5sysRules);
                    db.SubmitChanges();

                    db.w5sysRoles.DeleteOnSubmit(r);
                    db.SubmitChanges();

                    ts.Complete();
                }

                Tools.messageConfirmSuccess("Xóa thành công");
                LoadData();

                stoRule.DataSource = new List<object>();
                stoRule.DataBind();
            }
            catch (Exception ex)
            {
                Tools.messageConfirmErr("Xóa không thành công do nhóm quyền có chứa dữ liệu người dùng");
            }
        }

        void getFormValue(w5sysRole r)
        {
            r.caption = txtCaption.Text;
            r.code = txtCode.Text;
            r.description = txtDesc.Text;
        }

        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {
            long idd = 0;

            if (hId.Value.ToString() == "0") //add
            {
                try
                {
                    w5sysRole r = new w5sysRole();
                    getFormValue(r);
                    r.status = 1;
                    db.w5sysRoles.InsertOnSubmit(r);
                    db.SubmitChanges();

                    RowSelectionModel rsm = grdRoles.SelectionModel.Primary as RowSelectionModel;
                    string oldid = rsm.SelectedRecordID;
                    Tools.messageConfirmSuccess("Thêm thành công");
                    LoadData();

                    rsm.SelectedRecordID = oldid;
                    rsm.UpdateSelection();
                    formCT.Reset();
                }
                catch (Exception ex)
                {
                    Tools.messageEx(ex, "Có lỗi trong quá trình thêm,vui lòng thử lại...");
                }
            }
            else //edit
            {
                if (!long.TryParse(hId.Value.ToString(), out idd))
                {
                    Tools.messageConfirmErr("Vui lòng chọn nhóm quyền...");
                    return;
                }

                try
                {
                    var r = db.w5sysRoles.SingleOrDefault(i => i.id == idd);
                    getFormValue(r);
                    db.SubmitChanges();

                    RowSelectionModel rsm = grdRoles.SelectionModel.Primary as RowSelectionModel;
                    string oldid = rsm.SelectedRecordID;
                    Tools.messageConfirmSuccess("Thêm thành công");
                    LoadData();

                    rsm.SelectedRecordID = oldid;
                    rsm.UpdateSelection();

                    wEditor.Hide();
                }
                catch (Exception ex)
                {
                    Tools.messageEx(ex, "Có lỗi trong quá trình thử, vui lòng thử lại...");
                }
            }
        }



        protected void stoRule_SubmitData(object sender, StoreSubmitDataEventArgs e)
        {
            try
            {
                long idd;
                RowSelectionModel rsm = grdRoles.SelectionModel.Primary as RowSelectionModel;
                if (rsm == null || rsm.SelectedRow == null)
                {
                    Tools.messageConfirmErr("Chọn nhóm quyền!");
                    return;
                }
                if (!long.TryParse(rsm.SelectedRecordID, out idd))
                {
                    Tools.messageConfirmErr("Chọn nhóm quyền!");
                    return;
                }

                List<w5sysRule> rules = new List<w5sysRule>();
                foreach (XmlNode node in e.Xml.FirstChild)
                {
                    w5sysRule f = new w5sysRule();
                    f.functionID = long.Parse(node.SelectSingleNode("id").InnerText);
                    f.roleID = idd;
                    f.rules = long.Parse(node.SelectSingleNode("rule").InnerText);
                    f.status = 1;

                    rules.Add(f);
                }

                try
                {
                    using (var ts = new TransactionScope())
                    {
                        w5sysRole r = db.w5sysRoles.SingleOrDefault(i => i.id == idd);
                        if (r == null)
                            throw new Exception("Record not found");

                        db.w5sysRules.DeleteAllOnSubmit(r.w5sysRules);
                        db.SubmitChanges();

                        db.w5sysRules.InsertAllOnSubmit(rules);
                        db.SubmitChanges();

                        ts.Complete();
                    }

                    Tools.messageConfirmSuccess("Cập nhật thành công!");
                    //X.AddScript("stoRule.commitChanges();");
                    X.AddScript("stoRule.rejectChanges(); stoRule.reload(); ");
                    return;
                }
                catch (Exception ex)
                {
                    Tools.messageEx(ex, "Có lỗi trong quá trình lưu dữ liệu, vui lòng thử lại...");
                    return;
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }

        #endregion

        #region grid event

        protected void grdRoles_OnClick(object sender, DirectEventArgs e)
        {
            stoRule_RefreshData(null, null);
        }

        #endregion

        protected void stoRule_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            try
            {
                long idd = 0;
                RowSelectionModel rsm = grdRoles.GetSelectionModel() as RowSelectionModel;
                if (rsm.SelectedRow != null)
                    long.TryParse(rsm.SelectedRecordID, out idd);

                if (idd == 0)
                {
                    Tools.messageConfirmErr("Chọn nhóm quyền...");
                    return;
                }

                using (var db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString))
                {
                    var lst = db.w5sysRules.Where(i => i.roleID == idd);
                    var data = logic.BuildTreeFunction(lst, 0);
                    stoRule.DataSource = data;
                    stoRule.DataBind();
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }



        protected void btnDelFunc_DirectClick(object sender, DirectEventArgs e)
        {

        }

        protected void btnAddFunc_DirectClick(object sender, DirectEventArgs e)
        {

        }


        void LoadFuncTree()
        {
            var item = db.w5sysFunctions.SingleOrDefault(i => i.id == const1.functionRootID);
            Ext.Net.TreeNode n = getNodebyFunction(item);
            LoadTreeNode(item.id, n);

            TreeFunc.Root.Clear();
            TreeFunc.Root.Add(n);
            n.Expanded = true;
        }
        void LoadTreeNode(long? parentid, Ext.Net.TreeNode node)
        {
            var lst2 = db.w5sysFunctions.Where(i => i.parentId == parentid).OrderBy(i => i.order1);
            node.Leaf = (lst2 == null || lst2.Count() == 0);
            foreach (var item in lst2)
            {
                Ext.Net.TreeNode n = getNodebyFunction(item);
                LoadTreeNode(item.id, n);

                node.Nodes.Add(n);
            }
        }
        Ext.Net.TreeNode getNodebyFunction(w5sysFunction f)
        {
            return new Ext.Net.TreeNode(f.id.ToString(), string.Format("{0} [{1}]", f.code, f.caption), Icon.None);
        }
    }
}