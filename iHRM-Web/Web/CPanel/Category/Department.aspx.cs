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
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel.Category
{
    public partial class Department : BackEndPageBase
    {
        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);

            if (!IsPostBack)
            {
                LoadData();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        #region sub
        void LoadData()
        {
            var cty = db.tblRef_Companies.FirstOrDefault();
            var dt = db.tblRef_Departments.ToList();
            Ext.Net.TreeNode n = new Ext.Net.TreeNode("<<ROOT>>",
                string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName,
                Icon.None
            );

            cmbParent.Items.Clear();
            cmbParent.Items.Add(new Ext.Net.ListItem(n.Text, "<<ROOT>>"));
            LoadTreeNode(null, n, dt, "---");

            TreeFunc.Root.Clear();
            TreeFunc.Root.Add(n);
            n.Expanded = true;
        }
        void LoadTreeNode(string parentid, Ext.Net.TreeNode node, List<tblRef_Department> dt, string space)
        {
            var lst2 = dt.Where(i => i.DepParent == parentid).OrderBy(i => i.OrderNo);
            node.Leaf = (lst2 == null || lst2.Count() == 0);
            foreach (var item in lst2)
            {
                Ext.Net.TreeNode n = getNodebyFunction(item);
                cmbParent.Items.Add(new Ext.Net.ListItem(n.Text, item.DepID));
                LoadTreeNode(item.DepID, n, dt, space + "---");

                node.Nodes.Add(n);
            }
        }
        Ext.Net.TreeNode getNodebyFunction(tblRef_Department f)
        {
            if (f == null)
                return null;
            return new Ext.Net.TreeNode(f.DepID, GetFunctionHtmlCaption(f), Icon.None);
        }
        private string GetFunctionHtmlCaption(tblRef_Department f)
        {
            if (f == null)
            {
                var cty = db.tblRef_Companies.FirstOrDefault();
                return string.Format("<span class='nodecode'>{0}</span> <span class='nodecaption'>[{1}]</span>",
                    string.IsNullOrWhiteSpace(cty.CompanyID) ? "SS" : cty.CompanyID,
                    string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName
                );
            }

            return string.Format("<span class='nodecode'>{0}</span> <span class='nodecaption'>[{1}]</span>", f.DepID, f.DepName);
        }



        [DirectMethod]
        public string RefreshTree()
        {
            var cty = db.tblRef_Companies.FirstOrDefault();
            var dt = db.tblRef_Departments.ToList();

            Ext.Net.TreeNode n = new Ext.Net.TreeNode(string.IsNullOrWhiteSpace(cty.CompanyID) ? "SS" : cty.CompanyID,
                string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName,
                Icon.None
            );
            LoadTreeNode(null, n, dt, "---");

            var root = new Ext.Net.TreeNode();
            root.Nodes.Add(n);
            return root.Nodes.ToJson();
        }

        [DirectMethod]
        public string AddNode2SelectedNode(string newNodeId)
        {
            if (newNodeId == null)
                return "";

            var item = db.tblRef_Departments.SingleOrDefault(i => i.DepID == newNodeId);
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
        public string PasteFunc(string copyID, string cutID, string toID)
        {
            var fromDep = db.tblRef_Departments.SingleOrDefault(i => i.DepID == (string.IsNullOrWhiteSpace(copyID) ? cutID : copyID));

            tblRef_Department newDep = new tblRef_Department();
            newDep.DepID = fromDep.DepID + "_2";
            newDep.DepKey = fromDep.DepKey;
            newDep.DepName = fromDep.DepName;
            newDep.DepName_Eng = fromDep.DepName_Eng;
            newDep.DepParent = toID;
            newDep.DepTypeID = fromDep.DepTypeID;
            newDep.Direct = fromDep.Direct;
            newDep.Notes = fromDep.Notes;
            newDep.BasicWD = fromDep.BasicWD;
            newDep.OrderNo = fromDep.OrderNo;
            newDep.CenterCode = fromDep.CenterCode;
            newDep.MealSection = fromDep.MealSection;
            newDep.Rpt_Dep = fromDep.Rpt_Dep;
            newDep.Rpt_Line = fromDep.Rpt_Line;
            newDep.Rpt_Group = fromDep.Rpt_Group;

            db.tblRef_Departments.InsertOnSubmit(newDep);
            db.SubmitChanges();

            Ext.Net.TreeNode n = getNodebyFunction(newDep);
            n.Leaf = true;
            Ext.Net.TreeNodeCollection nc = new Ext.Net.TreeNodeCollection();
            nc.Add(n);
            return nc.ToJson();
        }

        #endregion

        protected void btnAdd_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            formCT.Reset();
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            if (rsm == null || rsm.SelectedNode == null)
            {
                //Tools.messageConfirmErr(Lng.common_msg.Please_Choose_Data);
                //return;
            }
            else
            {
                cmbParent.Value = rsm.SelectedNode.NodeID;
            }

            hId.Value = "";
            txtCode.Disabled = false;

            btnClear.Hidden = false;
            wEditor.Show();
            txtCode.Focus(true, 300);
        }
        protected void btnEdit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            if (rsm == null || rsm.SelectedNode == null)
            {
                Tools.messageConfirmErr(Lng.common_msg.Please_Choose_Data);
                return;
            }
            var f = db.tblRef_Departments.SingleOrDefault(i => i.DepID == rsm.SelectedNode.NodeID);
            if (f == null)
            {
                Tools.messageConfirmErr(Lng.Category_Department.Do_Not_Access_Root);
                return;
            }

            hId.Value = f.DepID;
            //hParent.Value = f.DepParent;
            //lblParent.Html = GetFunctionHtmlCaption(f.tblRef_Department1);
            FormSetDataContext(formCT, f); //formCT.SetValues(f);
            txtCode.Disabled = true;

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
            if (rsm == null || rsm.SelectedNode == null)
            {
                Tools.messageConfirmErr(Lng.common_msg.Please_Choose_Data);
                return;
            }

            var f = db.tblRef_Departments.SingleOrDefault(i => i.DepID == rsm.SelectedNode.NodeID);

            try
            {
                db.tblRef_Departments.DeleteOnSubmit(f);
                db.SubmitChanges();

                Tools.message(Lng.common_msg.Delete_Success);
                X.AddScript("TreeFunc.getSelectionModel().getSelectedNode().remove();");
            }
            catch
            {
                Tools.message(Lng.common_msg.Error_While_Exec);
            }
        }

        protected void btnOk_DirectClick(object sender, DirectEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hId.Value as string)) //add
            {
                if (string.IsNullOrWhiteSpace(cmbParent.Value as string))
                {
                    Tools.messageConfirmErr(Lng.common_msg.Please_Choose_Data);
                    return;
                }

                try
                {
                    tblRef_Department r = new tblRef_Department();
                    FormGetDataContext(formCT, r);
                    r.DepParent = (cmbParent.Value as string) == "<<ROOT>>" ? null : cmbParent.Value as string;
                    db.tblRef_Departments.InsertOnSubmit(r);
                    db.SubmitChanges();

                    Tools.messageConfirmSuccess(Lng.common_msg.Add_Success);
                    //X.AddScript("refreshTree();");
                    //X.AddScript("AddNode2SelectedNode('" + r["idDanhMucBV"] + "');");

                    formCT.Reset();
                }
                catch
                {
                    Tools.messageConfirmErr(Lng.common_msg.Error_While_Exec);
                }
            }
            else
            {
                try
                {
                    var r = db.tblRef_Departments.SingleOrDefault(i => i.DepID == hId.Value.ToString());
                    FormGetDataContext(formCT, r);
                    db.SubmitChanges();

                    Tools.messageConfirmSuccess(Lng.common_msg.Edit_Success);
                    //X.AddScript("refreshTree();");
                    //X.AddScript("AddNode2SelectedNode('" + r["idDanhMucBV"] + "');");

                    formCT.Reset();
                }
                catch
                {
                    Tools.messageConfirmErr(Lng.common_msg.Error_While_Exec);
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