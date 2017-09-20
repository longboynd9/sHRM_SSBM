using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using Ext.Net;
using System.IO;
using iHRM.Core.Business.Logic;
using System.Data;
using System.Xml;
using iHRM.WebPC.Classes;
using System.Text;
using System.Data.SqlClient;
using iHRM.Core.Business;
using System.Globalization;
using iHRM.Core.Business.Logic.ChamCong;
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel.QuetThe
{
    public partial class AnalyzeData : BackEndPageBase
    {
        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);

            if (!IsPostBack)
            {
                txtDate1.SelectedDate = DateTime.Now;
                txtDate2.SelectedDate = DateTime.Now;

                Lng.Web_Language.Lng_SetControlTexts(this);
            }

            StoInGroup1.DataSource = db.tblEmp_Group1s;
            StoInGroup1.DataBind();

            LoadTreeData();

            btnChotCong.Enabled = btnBoChotCong.Enabled = LoginHelper.user.isAdmin;
            btnChotCong.Visible = btnBoChotCong.Visible = LoginHelper.user.isAdmin;
        }

        #region treeview
        void LoadTreeData()
        {
            var cty = db.tblRef_Companies.FirstOrDefault();
            var dt = db.tblRef_Departments.ToList();
            Ext.Net.TreeNode n = new Ext.Net.TreeNode("<<ROOT>>",
                string.IsNullOrWhiteSpace(cty.CompanyName) ? "Smart Shirts" : cty.CompanyName,
                Ext.Net.Icon.None
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
            return new Ext.Net.TreeNode(f.DepID, GetFunctionHtmlCaption(f), Ext.Net.Icon.None);
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
            h_depSelected.SetValue("");
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
                h_depSelected.SetValue(f.DepID);
                h_name_depSelected.SetValue(f.DepName);
            }
        }
        #endregion
        
        protected void btnExecute_Click(object sender, EventArgs e)
        {
            iHRM.Win.ExtClass.QuetThe.XuLyDuLieu controller = new iHRM.Win.ExtClass.QuetThe.XuLyDuLieu(LoginHelper.user);
            StringBuilder log = new StringBuilder();

            controller.lp.OnOutMessage += (msg) => { log.AppendLine(msg); };
            controller.doAnalyza(txtDate1.SelectedDate
                , txtDate2.SelectedDate.AddDays(1)
                , txtMaNVSearch.Text.Trim(' ', '\r', '\n', '\t')
                , h_depSelected.Value as string
                , cmbNhom1.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbNhom1.Value)
                , chkNotOverideModified.Checked
            );

            txtLog.Text = log.ToString();
        }

        #region chot cong

        protected void btnChotCong_DirectClick(object sender, DirectEventArgs e)
        {
            ChotBangCong(true);
        }

        protected void btnBoChotCong_DirectClick(object sender, DirectEventArgs e)
        {
            ChotBangCong(false);
        }

        private void ChotBangCong(bool isLock)
        {
            analyze logic = new analyze();

            DateTime tuNgay = txtDate1.SelectedDate;
            DateTime denNgay = txtDate2.SelectedDate.AddDays(1);
            string empID = txtMaNVSearch.Text.Trim(' ', '\r', '\n', '\t');
            int ii = 0;

            if (!string.IsNullOrWhiteSpace(empID))
            {
                ii = logic.ChotBangCong_WithEmp(tuNgay, denNgay, empID, isLock);
                txtLog.AppendLine(string.Format("Chốt bảng công (EmpID: {1}) hoàn tất ({0} bản ghi) ", ii, empID));
            }
            else if (!string.IsNullOrWhiteSpace(h_depSelected.Value as string))
            {
                ii = logic.ChotBangCong_WithDept(tuNgay, denNgay, h_depSelected.Value as string, isLock);
                txtLog.AppendLine(string.Format("Chốt bảng công (Dept: {1}) hoàn tất ({0} bản ghi) ", ii, h_depSelected.Value));
            }
            else if (cmbNhom1.SelectedIndex > -1)
            {
                ii = logic.ChotBangCong_WithGroup1(tuNgay, denNgay, Convert.ToInt32(cmbNhom1.Value), isLock);
                txtLog.AppendLine(string.Format("Chốt bảng công (Group1: {1}) hoàn tất ({0} bản ghi) ", ii, cmbNhom1.SelectedItem.Text));
            }
            else
            {
                ii = logic.ChotBangCong(tuNgay, denNgay, isLock);
                txtLog.AppendLine(string.Format("Chốt bảng công hoàn tất ({0} bản ghi) ", ii));
            }
        }

        #endregion
    }
}