using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.Core.Business;
using Ext.Net;
using System.IO;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel.Account
{
    public partial class Function : BackEndPageBase
    {
        dcDatabaseDataContext db;

        //protected override void initRight()
        //{
        //    adm_FuncID = 16;
        //    adm_RequiredAdmin = true;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);

            if (!IsPostBack)
            {
                LoadData();
                LoadAsemplyTree();
                KTNHOMQUYEN();

                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        #region"Kiểm tra nhóm quyền"
        private void KTNHOMQUYEN()
        {
            if (!LoginHelper.user.isAdmin)
            {
                txtSearch.Visible = btnSearch.Visible = HasRight(Enums.eFunction.Choose);
                btnAdd.Visible = HasRight(Enums.eFunction.New);
                btnOk.Visible = HasRight(Enums.eFunction.Save);
            }
        }
        #endregion

        #region LoadAsemplyTree
        void LoadAsemplyTree()
        {
            Ext.Net.TreeNode root = new Ext.Net.TreeNode("", "Control Panel", Icon.Folder);
            Ext.Net.TreeNode cpanel = new Ext.Net.TreeNode("/CPanel", "CPanel", Icon.Folder);
            LoadAsemplyNode(cpanel);
            root.Nodes.Add(cpanel);

            treeAsemplyPath.Root.Clear();
            treeAsemplyPath.Root.Add(root);
            treeAsemplyPath.RootVisible = true;
            root.Expanded = true;
            cpanel.Expanded = true;
        }

        void LoadAsemplyNode(Ext.Net.TreeNode node)
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~" + node.NodeID));

            foreach (var item in di.GetDirectories())
            {
                Ext.Net.TreeNode n = new Ext.Net.TreeNode(node.NodeID + "/" + item.Name, item.Name, Icon.Folder);
                LoadAsemplyNode(n);
                node.Nodes.Add(n);
            }

            foreach (var item in di.GetFiles("*.aspx"))
            {
                Ext.Net.TreeNode n = new Ext.Net.TreeNode(node.NodeID + "/" + item.Name, item.Name, Icon.Page);
                node.Nodes.Add(n);
            }

        }

        #endregion

        #region sub
        void LoadData()
        {
            var item = db.w5sysFunctions.SingleOrDefault(i => i.id == const1.functionRootID);
            Ext.Net.TreeNode n = getNodebyFunction(item);
            LoadTreeNode(item.id, n);

            TreeFunc.Root.Clear();
            TreeFunc.Root.Add(n);
            TreeFunc.RootVisible = true;
            TreeFunc.ExpandAll();
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
            return new Ext.Net.TreeNode(f.id.ToString(), Core.Business.Logic.AccessRight.Function.GetFunctionHtmlCaption(f), Icon.None);
        }

        [DirectMethod]
        public string RefreshTree()
        {
            var item = db.w5sysFunctions.SingleOrDefault(i => i.id == const1.functionRootID);
            Ext.Net.TreeNode n = getNodebyFunction(item);
            LoadTreeNode(item.id, n);

            Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            nc.Add(n);
            return nc.ToJson();
        }

        [DirectMethod]
        public string AddNode2SelectedNode(long newNodeId)
        {
            var item = db.w5sysFunctions.FirstOrDefault(i => i.id == newNodeId);
            Ext.Net.TreeNode n = getNodebyFunction(item);
            n.Leaf = true;

            Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            nc.Add(n);
            return nc.ToJson();
        }

        [DirectMethod]
        public string SearchTree(string key)
        {
            var lst = db.w5sysFunctions.Where(i => i.code.IndexOf(key) >= 0 || i.caption.IndexOf(key) >= 0);
            Ext.Net.TreeNode n = new Ext.Net.TreeNode("", "Search items", Icon.None);
            n.Nodes.AddRange(lst.Select(i => getNodebyFunction(i)));

            Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            nc.Add(n);
            return nc.ToJson();
        }

        [DirectMethod]
        public string PasteFunc(long copyID, long cutID, long toID)
        {
            var fromFunc = db.w5sysFunctions.SingleOrDefault(i => i.id == (cutID > 0 ? cutID : copyID));
            Ext.Net.TreeNode n;

            if (cutID > 0)
            {
                fromFunc.parentId = toID;
                db.SubmitChanges();
                n = getNodebyFunction(fromFunc);
            }
            else
            {
                var newFunc = new w5sysFunction();
                newFunc.icon = fromFunc.icon;
                newFunc.asemblyPath = fromFunc.asemblyPath;
                newFunc.caption = fromFunc.caption;
                newFunc.code = fromFunc.code;
                newFunc.order1 = fromFunc.order1;
                newFunc.status = fromFunc.status;
                //newFunc.sys_locked = fromFunc.sys_locked;
                newFunc.type = fromFunc.type;
                newFunc.parentId = toID;

                db.w5sysFunctions.InsertOnSubmit(newFunc);
                db.SubmitChanges();
                n = getNodebyFunction(newFunc);
            }

            n.Leaf = true;
            Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            nc.Add(n);
            return nc.ToJson();
        }

        #endregion

        #region event
        protected void btnAdd_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            if (rsm == null || rsm.SelectedNode == null)
            {
                Tools.messageConfirmErr("Chọn chức năng cần thêm!");
                return;
            }

            formCT.Reset();
            txtCode.Disabled = txtAsemblyPath.Disabled = false;

            hId.Value = "0";
            //txtCode.Text = iHRM.Core.Business.Logic.AllLogic.GenNextMa("w5sysFunction", "code", "f", false);
            hParent.Value = rsm.SelectedNode.NodeID;
            lblParent.Html = rsm.SelectedNode.Text;

            btnClear.Hidden = false;
            wEditor.Show();
            txtCaption.Focus(true, 300);
        }
        protected void btnEdit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            long idd = 0;
            if (rsm == null || rsm.SelectedNode == null || !long.TryParse(rsm.SelectedNode.NodeID, out idd))
            {
                Tools.messageConfirmErr("Chọn chức năng cần sửa!");
                return;
            }

            var f = db.w5sysFunctions.SingleOrDefault(i => i.id == idd);

            txtCode.Disabled = txtAsemblyPath.Disabled = f.sys_locked;

            hId.Value = f.id;
            if (f.w5sysFunction1 == null)
            {
                Tools.messageConfirmErr("Không tìm thấy chức năng!");
                return;
            }

            hParent.Value = f.w5sysFunction1.id;
            lblParent.Html = Core.Business.Logic.AccessRight.Function.GetFunctionHtmlCaption(f.w5sysFunction1);
            txtCode.Text = f.code;
            txtCaption.Text = f.caption;
            txtCaption_EN.Text = f.caption_EN;
            txtAsemblyPath.Text = f.asemblyPath;
            txtAsemblyInherits.Text = f.asemblyInherits;
            txtOrder.Value = f.order1;

            btnClear.Hidden = true;
            wEditor.Show();

            if (txtCode.Disabled)
                txtCaption.Focus(true, 300);
            else
                txtCode.Focus(true, 300);
        }
        protected void btnDel_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            long idd = 0;
            if (rsm == null || rsm.SelectedNode == null || !long.TryParse(rsm.SelectedNode.NodeID, out idd))
            {
                Tools.messageConfirmErr("Chọn chức năng cần xóa!");
                return;
            }

            var f = db.w5sysFunctions.SingleOrDefault(i => i.id == idd);

            if (f == null || f.sys_locked)
            {
                Tools.messageConfirmErr("Chức năng được khóa bởi hệ thống. không được xóa");
                return;
            }
            
            var item = db.w5sysFunctions.SingleOrDefault(i => i.id == idd);
            if (XoaFunction(item))
            {
                Tools.messageConfirmSuccess("Xóa thành công");
                X.AddScript("TreeFunc.getSelectionModel().getSelectedNode().remove();");
            }
            else
            {
                Tools.messageConfirmErr("Trong quá trình xóa bị lỗi, vui lòng thử lại...");
            }
        }

        private bool XoaFunction(w5sysFunction item)
        {
            if (item != null)
            {
                while (true)
                {
                    var i = item.w5sysFunctions.FirstOrDefault();
                    if (i == null)
                        break;

                    XoaFunction(i);
                }

                db.w5sysRules.DeleteAllOnSubmit(item.w5sysRules);
                db.SubmitChanges();

                db.w5sysFunctions.DeleteOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        void GetFormValues(w5sysFunction f)
        {
            if (!f.sys_locked)
            {
                f.asemblyPath = txtAsemblyPath.Text;
                f.code = txtCode.Text;
            }
            f.asemblyInherits = txtAsemblyInherits.Text;
            f.caption = txtCaption.Text;
            f.caption_EN = txtCaption_EN.Text;
            f.order1 = (int)((double?)txtOrder.Value ?? 0);
            f.icon = ImageUploader1.ToBase64();
        }

        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {
            long idd = 0;

            if (hId.Value.ToString() == "0") //add
            {
                try
                {
                    w5sysFunction f = new w5sysFunction();
                    if (!long.TryParse(hParent.Value.ToString(), out idd))
                    {
                        Tools.messageConfirmErr("Chọn danh mục cha");
                        return;
                    }
                    f.parentId = idd;
                    f.status = 1;
                    GetFormValues(f);

                    db.w5sysFunctions.InsertOnSubmit(f);
                    db.SubmitChanges();

                    Tools.messageConfirmSuccess("Thêm thành công");
                    //X.AddScript("refreshTree();");
                    X.AddScript("AddNode2SelectedNode('" + f.id + "');");

                    formCT.Reset();
                }
                catch
                {
                    Tools.messageConfirmErr("Lỗi trong quá trình thêm, vui lòng thử lại...");
                }
            }
            else //edit
            {
                if (!long.TryParse(hId.Value.ToString(), out idd))
                {
                    Tools.messageConfirmErr("Chưa chọn chức năng cần sửa...");
                    return;
                }

                var f = db.w5sysFunctions.SingleOrDefault(i => i.id == idd);

                try
                {
                    GetFormValues(f);
                    db.SubmitChanges();

                    Tools.messageConfirmSuccess("Cập nhật thành công");
                    //X.AddScript("refreshTree();");
                    X.AddScript(string.Format("TreeFunc.getSelectionModel().getSelectedNode().setText(\"{0}\");", Core.Business.Logic.AccessRight.Function.GetFunctionHtmlCaption(f)));

                    wEditor.Hide();
                }
                catch
                {
                    Tools.messageConfirmErr("Lỗi trong quá trình sửa, vui lòng thử lại...");
                }
            }
        }
        #endregion







    }
}