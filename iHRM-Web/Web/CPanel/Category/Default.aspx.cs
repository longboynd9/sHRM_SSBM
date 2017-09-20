using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using iHRM.Core.Business;
using System.Data;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class Default : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.News.DanhMucBaiViet Logic = new global::iHRM.Core.Business.Logic.News.DanhMucBaiViet();

        protected void Page_Load(object sender, EventArgs e)
        {
            //kiem tra quyen admin
            //LoginHelper.user.isAdmin

            //kiem tra quyen them sua..
            //HasRight(Enums.eFunction.Delete)

            if (!IsPostBack)
            {
                cbostatus.Items.AddRange(Enums.eStatus_Alias.Select(i => new Ext.Net.ListItem(i.Value, ((int)i.Key).ToString())));
                //chkvitri.Items.AddRange(Enums.eViTriHienThiAlias.Select(i => new Ext.Net.ListItem(i.Value, ((int)i.Key).ToString())));
                cbostatus.SelectedItem.Value = Convert.ToString((int)Enums.eStatus.KichHoat);
                LoadData();
                Lng.Language.Lng_SetControlTexts(this);
            }
        }

        #region sub
        void LoadData()
        {
            var dt = Logic.GetAll();
            var itemR = dt.Select("parentID is NULL").FirstOrDefault();
            Ext.Net.TreeNode n = getNodebyFunction(itemR);
            LoadTreeNode(DbHelper.DrGetGuid(itemR, "idDanhMucBV"), n, dt);

            TreeFunc.Root.Clear();
            TreeFunc.Root.Add(n);
            TreeFunc.ExpandAll();
        }
        void LoadTreeNode(Guid? parentid, Ext.Net.TreeNode node, DataTable dt)
        {
            var lst2 = dt.Select("parentID='" + parentid + "'").OrderBy(i => i["displayOrder"]);
            node.Leaf = (lst2 == null || lst2.Count() == 0);
            foreach (var item in lst2)
            {
                Ext.Net.TreeNode n = getNodebyFunction(item);
                LoadTreeNode(DbHelper.DrGetGuid(item, "idDanhMucBV"), n, dt);

                node.Nodes.Add(n);
            }
        }
        Ext.Net.TreeNode getNodebyFunction(DataRow f)
        {
            if (f == null)
                return null;
            return new Ext.Net.TreeNode(DbHelper.DrGetString(f, "idDanhMucBV"), GetFunctionHtmlCaption(f), Icon.None);
        }
        private string GetFunctionHtmlCaption(DataRow f)
        {
            return string.Format("<span class='nodecode dmgoc{2}'>{0}</span> <span class='nodecaption'>[{1}]</span>", f["ma"], f["ten"], f["laDmGoc"]);
        }

        [DirectMethod]
        public string RefreshTree()
        {
            var dt = Logic.GetAll();
            var itemR = dt.Select("parentID is NULL").FirstOrDefault();
            Ext.Net.TreeNode n = getNodebyFunction(itemR);
            LoadTreeNode(DbHelper.DrGetGuid(itemR, "idDanhMucBV"), n, dt);

            var root = new Ext.Net.TreeNode();
            root.Nodes.Add(n);
            return root.Nodes.ToJson();
        }

        [DirectMethod]
        public string AddNode2SelectedNode(Guid? newNodeId)
        {
            if (newNodeId == null)
                return "";

            var item = Logic.GetById(newNodeId.Value);
            Ext.Net.TreeNode n = getNodebyFunction(item);
            n.Leaf = true;

            Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            nc.Add(n);
            return nc.ToJson();
        }

        [DirectMethod]
        public string SearchTree(string key)
        {
            //var lst = db.w5DanhMucs.Where(i => i.Ma.Contains(key) || i.Ten.Contains(key)).ToList();
            //Ext.Net.TreeNode n = new Ext.Net.TreeNode("", "Search items", Icon.None);
            //n.Nodes.AddRange(lst.Select(i => getNodebyFunction(i)));

            //Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            //nc.Add(n);
            //return nc.ToJson();

            return "";
        }

        [DirectMethod]
        public string PasteFunc(Guid? copyID, Guid? cutID, Guid? toID)
        {
            var fromFunc = Logic.GetById(copyID == null ? cutID.Value : copyID.Value);
            Ext.Net.TreeNode n;

            if (copyID != null)
                fromFunc["idDanhMucBV"] = DBNull.Value;

            fromFunc["parentID"] = toID;
            Logic.InsertOrUpdate(fromFunc);
            n = getNodebyFunction(fromFunc);

            n.Leaf = true;
            Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            nc.Add(n);
            return nc.ToJson();
        }

        #endregion

        protected void btnAdd_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            if (rsm == null || rsm.SelectedNode == null)
            {
                Tools.messageConfirmErr(Lng.Category_Default.msg_2);
                return;
            }
            formCT.Reset();

            hId.Value = "";
            hParent.Value = rsm.SelectedNode.NodeID;
            cbostatus.SelectedItem.Value = Convert.ToInt32(Enums.eStatus.KichHoat).ToString();
            lblParent.Html = rsm.SelectedNode.Text;

            lnkSeoData.Disabled = lnkBaiViet.Disabled = true;
            lnkSeoData.Text = lnkBaiViet.Text = "-";
            lnkSeoData.NavigateUrl = lnkBaiViet.NavigateUrl = "#";

            btnClear.Hidden = false;
            wEditor.Show();
            txtCode.Focus(true, 300);
        }
        protected void btnEdit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            Guid idd;
            if (rsm == null || rsm.SelectedNode == null || !Guid.TryParse(rsm.SelectedNode.NodeID, out idd))
            {
                Tools.messageConfirmErr(Lng.Category_Default.msg_3);
                return;
            }
            var f = Logic.GetById(idd);

            hId.Value = f["idDanhMucBV"];
            if (DbHelper.DrGet(f, "parentID") == null)
            {
                Tools.messageConfirmErr("Do not access root!");
                return;
            }

            hParent.Value = f["parentID"];
            lblParent.Html = GetFunctionHtmlCaption(Logic.GetById((Guid)f["parentID"]));

            txtCode.Text = DbHelper.DrGetString(f, "ma");
            txtCaption.Text = DbHelper.DrGetString(f, "ten");
            txtCaption_EN.Text = DbHelper.DrGetString(f, "ten_EN");
            txtCaption_KR.Text = DbHelper.DrGetString(f, "ten_KR");
            txtlink.Text = DbHelper.DrGetString(f, "link");
            txtOrder.Value = DbHelper.DrGet(f, "displayOrder");
            cbostatus.Value = DbHelper.DrGet(f, "status");

            lnkSeoData.Disabled = lnkBaiViet.Disabled = false;
            lnkSeoData.Text = DbHelper.DrGet(f, "SEOData") == null ? Lng.Category_Default.taomoi : Lng.Category_Default.chinhsua;
            lnkBaiViet.Text = DbHelper.DrGet(f, "idBaiViet") == null ? Lng.Category_Default.taomoi : Lng.Category_Default.chinhsua;
            lnkSeoData.NavigateUrl = string.Format("javascript:OpenSeoEditor('{0}', '{1}')", DbHelper.DrGet(f, "SEOData"), DbHelper.DrGet(f, "idDanhMucBV"));
            lnkBaiViet.NavigateUrl = string.Format("javascript:OpenBvEditor('{0}', '{1}')", DbHelper.DrGet(f, "idBaiViet"), DbHelper.DrGet(f, "idDanhMucBV"));

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
            Guid idd;
            if (rsm == null || rsm.SelectedNode == null || !Guid.TryParse(rsm.SelectedNode.NodeID, out idd))
            {
                Tools.messageConfirmErr(Lng.Category_Default.msg_4);
                return;
            }

            var f = Logic.GetById(idd);
            if (DbHelper.DrGetBoolean(f, "laDmGoc") == true)
            {
                Tools.messageConfirmErr(Lng.Category_Default.msg_5);
                return;
            }

            try
            {
                if (Logic.Delete(f))
                {
                    Tools.message(Lng.common_msg.Delete_Success);
                    X.AddScript("TreeFunc.getSelectionModel().getSelectedNode().remove();");
                }
                else
                {
                    Tools.message(Lng.common_msg.Delete_Fail);
                }
            }
            catch
            {
                Tools.message(Lng.Category_Default.msg_6);
            }
        }

        void getEditorValue(DataRow f)
        {
            f["ma"] = txtCode.Text;
            f["ten"] = txtCaption.Text;
            f["ten_EN"] = txtCaption_EN.Text;
            f["ten_KR"] = txtCaption_KR.Text;
            f["link"] = txtlink.Text;
            f["displayOrder"] = txtOrder.Value ?? 0;
            f["status"] = cbostatus.Value;

        }

        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hId.Value as string)) //add
            {
                Guid pid;
                if (!Guid.TryParse(hParent.Value.ToString(), out pid))
                {
                    Tools.messageConfirmErr(Lng.Category_Default.msg_7);
                    return;
                }

                try
                {
                    DataRow r = global::iHRM.Core.Business.Logic.AllLogic.GetSchema("tbDanhMucBaiViet").NewRow();
                    getEditorValue(r);
                    r["parentID"] = pid;
                    r["laDmGoc"] = false;
                    r["idDanhMucBV"] = Logic.InsertOrUpdate(r);
                    if (DbHelper.DrGet(r, "idDanhMucBV") != null)
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Add_Success);
                        //X.AddScript("refreshTree();");
                        //X.AddScript("AddNode2SelectedNode('" + r["idDanhMucBV"] + "');");

                        formCT.Reset();
                    }
                    else
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Add_Fail);
                    }
                }
                catch
                {
                    Tools.messageConfirmErr(Lng.Category_Default.msg_6);
                }
            }
            else
            {
                Guid pid;
                if (!Guid.TryParse(hId.Value.ToString(), out pid))
                {
                    Tools.messageConfirmErr(Lng.Category_Default.msg_3);
                    return;
                }

                try
                {
                    DataRow r = Logic.GetById(pid);
                    getEditorValue(r);
                    r["idDanhMucBV"] = pid;
                    r["idDanhMucBV"] = Logic.InsertOrUpdate(r);
                    if (DbHelper.DrGet(r, "idDanhMucBV") != null)
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Edit_Success);
                        //X.AddScript("refreshTree();");
                        //X.AddScript("AddNode2SelectedNode('" + r["idDanhMucBV"] + "');");

                        formCT.Reset();
                    }
                    else
                    {
                        Tools.messageConfirmSuccess(Lng.common_msg.Edit_Fail);
                    }
                }
                catch
                {
                    Tools.messageConfirmErr(Lng.Category_Default.msg_6);
                }
            }
        }

        protected void Button2_DirectClick(object sender, DirectEventArgs e)
        {
            formCT.Reset();
            wEditor.Hide();
        }

    }
}