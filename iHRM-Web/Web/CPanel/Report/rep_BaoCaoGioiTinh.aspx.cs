using Ext.Net;
using iHRM.WebPC.Business;
using iHRM.WebPC.Business.DbObject;
using iHRM.WebPC.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Cpanel.Report
{
    public partial class rep_BaoCaoGioiTinh : System.Web.UI.Page
    {
        iHRM.WebPC.Business.Logic.Report.BaoCao logic = new iHRM.WebPC.Business.Logic.Report.BaoCao();
        Business.DbObject.dcDatabaseDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            LoadData();
        }
        void LoadData()
        {
            var cty = db.tblRef_Companies.FirstOrDefault();
            var dt = db.tblRef_Departments.ToList();
            Ext.Net.TreeNode n = new Ext.Net.TreeNode("<<ROOT>>",
                string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName,
                Icon.None
            );

            LoadTreeNode(null, n, dt);

            treePB.Root.Clear();
            treePB.Root.Add(n);
            n.Expanded = true;
        }
        void LoadTreeNode(string parentid, Ext.Net.TreeNode node, List<tblRef_Department> dt)
        {
            var lst2 = dt.Where(i => i.DepParent == parentid).OrderBy(i => i.OrderNo);
            node.Leaf = (lst2 == null || lst2.Count() == 0);
            foreach (var item in lst2)
            {
                Ext.Net.TreeNode n = getNodebyFunction(item);
                LoadTreeNode(item.DepID, n, dt);

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

        protected void btnChoose_PB_DblClick(object sender, Ext.Net.DirectEventArgs e)
        {
            hdhidde.SetValue("");
            DefaultSelectionModel rsm = treePB.SelectionModel.Primary as DefaultSelectionModel;
            if (rsm == null || rsm.SelectedNode == null)
            {
                Tools.messageConfirmErr(Lng.common_msg.Please_Choose_Data);
            }
            tblRef_Department f = db.tblRef_Departments.SingleOrDefault(p => p.DepID == rsm.SelectedNode.NodeID);
            if (f == null)
            {
                Tools.messageConfirmErr(Lng.Category_Department.Do_Not_Access_Root);
                return;
            }
            else
            {
                dropdownPB.SetValue(f.DepName, f.DepID);
                var _lPB = db.tblRef_Departments.Where(p => p.DepID == f.DepID || p.DepParent == f.DepID).ToList();
                string listPB = "";
                foreach (var item in _lPB)
                {
                    listPB += item.DepID + ",";
                }
                hdhidde.SetValue(listPB);
            }
        }

        protected void btnSearch_Click(object sender, DirectEventArgs e)
        {
            
        }
    }
}