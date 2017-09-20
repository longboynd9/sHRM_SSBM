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
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;

namespace iHRM.WebPC.Cpanel.QuetThe
{
    public partial class DKCaLam : BackEndPageBase
    {
        Core.Business.Logic.ChamCong.calam logic = new Core.Business.Logic.ChamCong.calam();
        Core.Controller.QuetThe.DkCalam controller = new Core.Controller.QuetThe.DkCalam();
        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                txtTuNgay.SelectedDate = Core.Controller.QuetThe.Helper.GetStartDateSalaryCycle;
                txtDenNgay.SelectedDate = txtTuNgay.SelectedDate.AddMonths(1).AddDays(-1);

                //LoadData();
                LoadTree();

                StoInGroup1.DataSource = db.tblEmp_Group1s;
                StoInGroup1.DataBind();

                stoCaLam.DataSource = logic.GetAllCaLam();
                stoCaLam.DataBind();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            Store1.DataSource = logic.GetDataDangKyCaLam(
                txtSearchKey.Text == "" ? null : txtSearchKey.Text,
                txtTuNgay.IsEmpty ? null : (DateTime?)txtTuNgay.Value,
                txtDenNgay.IsEmpty ? null : (DateTime?)txtDenNgay.Value,
                txtDeptCodeSearch.Text
            );
            Store1.DataBind();
        }
        #region load tree
        void LoadTree()
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
            var lst2 = dt.Where(i => i.DepParent == parentid);
            node.Leaf = (lst2 == null || lst2.Count() == 0);
            foreach (var item in lst2)
            {
                Ext.Net.TreeNode n = getNodebyFunction(item);
                LoadTreeNode(item.DepID, n, dt);

                node.Nodes.Add(n);
            }
        }
        private Ext.Net.TreeNode getNodebyFunction(tblRef_Department f)
        {
            if (f == null)
                return null;
            return new Ext.Net.TreeNode(f.DepID, GetFunctionHtmlCaption(f), Icon.None);
        }
        private string GetFunctionHtmlCaption(tblRef_Department f)
        {
            if (f == null)
                return "";
            return string.Format("<span class='nodecode'>[{0}]</span> <span class='nodecaption'>{1}</span>", f.DepID, f.DepName);
        }
        #endregion
        protected void grd_OnCommand(object sender, DirectEventArgs e)
        {
            try
            {
                Guid commandId = new Guid(e.ExtraParams["id"]);
                string commandName = e.ExtraParams["command"];

                switch (commandName)
                {
                    case "Delete":
                        DeleteRecord(commandId);
                        LoadData();
                        break;
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }

        private void DeleteRecord(Guid commandId)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            var emp = db.tbKetQuaQuetThes.SingleOrDefault(i => i.id == commandId);

            if (emp != null)
            {
                db.tbKetQuaQuetThes.DeleteOnSubmit(emp);
                db.SubmitChanges();
            }
        }

        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            var lr = controller.DkCaNhan(txtNhanVien.Text, txtTuNgay2.SelectedDate, txtDenNgay2.SelectedDate, new Guid(cmbCaLam.Value as string), chkRegSunday.Checked);
            if (lr.status == Core.Controller.LogicResultStatus.fail)
            {
                Tools.messageConfirmErr(lr.msg);
            }
            else
            {
                Tools.messageConfirmSuccess(lr.msg, Lng.QuetThe_DKCaLam.msg_2 + " (" + lr.data + ")");
                txtNhanVien.Text = txtNhanVien2.Text = "";
                txtNhanVien.IndicatorIcon = Icon.Information;
            }
        }
        protected void btnDangKyNhom1_DirectClick(object sender, DirectEventArgs e)
        {
            var lr = controller.DkNhom1(Convert.ToInt32(cmbNhom1.Value), dateTuNgay3.SelectedDate, dateDenNgay3.SelectedDate, new Guid(cmbCaLam3.Value as string), chkRegSunday3.Checked);
            if (lr.status == Core.Controller.LogicResultStatus.fail)
            {
                Tools.messageConfirmErr(lr.msg);
            }
            else
            {
                Tools.messageConfirmSuccess(lr.msg, Lng.QuetThe_DKCaLam.msg_2 + " (" + lr.data + ")");
            }
        }
        protected void btnDangKyTapThe_DirectClick(object sender, DirectEventArgs e)
        {
            var lr = controller.DkTapThe(txtMaTo.Text == "<<ROOT>>" ? null : txtMaTo.Text, dateTuNgay.SelectedDate, dateDenNgay.SelectedDate, new Guid(cmbCaLam2.Value as string), chkRegSunday3.Checked);
            if (lr.status == Core.Controller.LogicResultStatus.fail)
            {
                Tools.messageConfirmErr(lr.msg);
            }
            else
            {
                Tools.messageConfirmSuccess(lr.msg, Lng.QuetThe_DKCaLam.msg_2 + " (" + lr.data + ")");
                txtMaTo.Text = txtTo.Text = "";
            }
        }
        
        protected void btnSearch_DirectClick(object sender, DirectEventArgs e)
        {
            LoadData();
        }

        protected void btnChon_DirectClick(object sender, EventArgs e)
        {
            DefaultSelectionModel rsm = TreeFunc.SelectionModel.Primary as DefaultSelectionModel;
            if (rsm == null || rsm.SelectedNode == null)
            {
                Tools.messageConfirmErr(Lng.common_msg.Please_Choose_Data);
                return;
            }
            //var f = db.tblRef_Departments.SingleOrDefault(i => i.DepID == rsm.SelectedNode.NodeID);
            //if (f == null)
            //{
            //    Tools.messageConfirmErr(Lng.common_msg.RecordNotFound);
            //    return;
            //}
            //if (f.tblRef_Departments != null && f.tblRef_Departments.Count > 0)
            //{
            //    Tools.messageConfirmErr(Lng.Category_Department.Do_Not_Access_Root);
            //    return;
            //}

            if ((ChooseDep_showFor.Value as string) == "Search")
            {
                txtDeptCodeSearch.Value = rsm.SelectedNode.NodeID;
                txtDeptNameSearch.Html = rsm.SelectedNode.Text;
            }
            else
            {
                txtMaTo.Value = rsm.SelectedNode.NodeID;
                txtTo.Html = rsm.SelectedNode.Text;
            }
            ChooseDep.Hidden = true;
        }
        protected void btnFindMaVN_DirectClick(object sender, DirectEventArgs e)
        {
            var dr = logic.checkNV(txtNhanVien.Text);
            if (dr == null)
            {
                txtNhanVien.IndicatorIcon = Icon.Error;
                txtNhanVien.IndicatorTip = Lng.QuetThe_DKCaLam.msg_3;
                txtNhanVien2.Text = "";
            }
            else
            {
                txtNhanVien.IndicatorIcon = Icon.Tick;
                txtNhanVien.IndicatorTip = "";
                txtNhanVien.Text = DbHelper.DrGetString(dr, "EmployeeID");
                txtNhanVien2.Text = string.Format("{0} [{1}]", DbHelper.DrGet(dr, "EmployeeName"), DbHelper.DrGet(dr, "IDCard"));

                if (string.IsNullOrWhiteSpace(DbHelper.DrGetString(dr, "ContractID")))
                    Tools.messageConfirmErr("Nhân viên chưa có hợp đồng chính thức");
                
            }
        }

        protected void btnTim_TapThe(object sender, DirectEventArgs e)
        {
            var dr = logic.checkPB(txtMaTo.Text);
            if (dr == null)
            {
                txtTo.Text = "";
                ChooseDep.Show();
                ChooseDep_showFor.Value = "Reg";
            }
            else
            {
                txtTo.Text = string.Format("{0}", DbHelper.DrGet(dr, "DepName"));
            }
        }

        protected void btnTim2_TapThe(object sender, DirectEventArgs e)
        {
            var dr = logic.checkPB(txtDeptCodeSearch.Text);
            if (dr == null)
            {
                txtDeptNameSearch.Text = "";
                ChooseDep.Show();
                ChooseDep_showFor.Value = "Search";
            }
            else
            {
                txtDeptNameSearch.Text = string.Format("{0}", DbHelper.DrGet(dr, "DepName"));
            }
        }

    }
}