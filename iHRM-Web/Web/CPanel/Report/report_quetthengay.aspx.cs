using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Cpanel.Report
{
    public partial class report_quetthengay : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadData();
                //LoadDataquetthe();
                //LoadNextData();
                hdhidde.Value = "";
                Lng.Web_Language.Lng_SetControlTexts(this);
                txtDate.SelectedValue = DateTime.Now;
                txtoday.SelectedValue = DateTime.Now;
            }
        }
        protected void Search(object sender, Ext.Net.DirectEventArgs e)
        {
            LoadDataquetthe();
        }
        public void LoadDataquetthe()
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day;
            DateTime today;
            var dt = new DataTable();
            if (txtDate.SelectedDate != null && txtoday.SelectedDate != null)
            {
                day = txtDate.SelectedDate;
                today = txtoday.SelectedDate;
                dt = logic.GetReportQuetTheByDate(day, today, DepID, txtSearch.Text != "" ? txtSearch.Text : null);
                dt.Columns.Add("TT");
                dt.Columns.Add("tgTangCa", typeof(double));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["TT"] = GetTrangThai(dr, 2);
                    if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                        dr["tgDiMuon"] = 0;
                    if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                    {
                        dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                        dr["tgVeSom"] = 0;
                    }
                }
                Store1.DataSource = dt;
                Store1.DataBind();
            }
            else
            {
                Tools.message(Lng.report_quetthengay.msg_1);
                return;
                // dt = logic.GetReportQuetTheByDate(null, DepID);
            }



        }
        protected void sto1_SubmitData(object sender, StoreSubmitDataEventArgs e)
        {
            ExportExcel4extGridOnSubmitData(e.Xml);
        }
        private string GetTrangThai(DataRow dr, int type = 1)
        {
            return Core.Controller.QuetThe.Helper.GetTrangThai(dr);
        }
        #region treeview
        void LoadData()
        {
            var cty = db.tblRef_Companies.FirstOrDefault();
            var dt = db.tblRef_Departments.ToList();
            Ext.Net.TreeNode n = new Ext.Net.TreeNode("<<ROOT>>",
                string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName,
                Icon.None
            );

            LoadTreeNode(null, n, dt);

            TreeFunc.Root.Clear();
            TreeFunc.Root.Add(n);
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
        protected void btnEdit_DirectClick(object sender, Ext.Net.DirectEventArgs e)
        {
            hdhidde.SetValue("");
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
            else
            {
                cbophong.SetValue(f.DepName, f.DepID);
                hdhidde.SetValue(f.DepID);
            }
        }
        #endregion
    }
}