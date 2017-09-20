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
    public partial class DKLamThem : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.ChamCong.calam logic = new global::iHRM.Core.Business.Logic.ChamCong.calam();
        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                //LoadData();
                LoadTree();

                StoInGroup1.DataSource = db.tblEmp_Group1s;
                StoInGroup1.DataBind();

                stoLoaiNgay.DataSource = db.tbLoaiNgayLamThems;
                stoLoaiNgay.DataBind();

                stoCaLam.DataSource = logic.GetAllCaLam();
                stoCaLam.DataBind();
                
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            Store1.DataSource = logic.GetDataDangKyLamThem(
                txtSearchKey.Text == "" ? null : txtSearchKey.Text,
                txtTuNgay.IsEmpty ? null : (DateTime?)txtTuNgay.Value,
                txtDenNgay.IsEmpty ? null : (DateTime?)txtDenNgay.Value,
                txtDeptCodeSearch.Text
            );
            Store1.DataBind();
        }

        #region tree
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
            try
            {
                logic.DangKyCaLam(txtNhanVien.Text,
                    txtNgayDK.SelectedDate,
                    new Guid(cmbCaLam.Value.ToString()),
                    int.Parse(cmbLoaiNgay.Value.ToString()),
                    int.Parse(txtHsLuong.Text)
                );

                Tools.message(Lng.QuetThe_DKLamThem.msg_2);
                txtNhanVien.Text = txtNhanVien2.Text = "";
                txtNhanVien.IndicatorIcon = Icon.Information;
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
        }

        protected void btnDangKyNhom1_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                Guid calam = new Guid(cmbCaLam3.Value.ToString());
                var lNv = db.tblEmployees.Where(p => p.InGroup1 == Convert.ToInt32(cmbNhom1.Value)).Select(i => i.EmployeeID).ToList();

                int rowAffect = 0; string msg = "";
                foreach (var item in lNv)
                {
                    var ii = logic.DangKyCaLam(item,
                        txtNgayDK3.SelectedDate,
                        calam,
                        int.Parse(cmbLoaiNgay3.Value.ToString()),
                        int.Parse(txtHsLuong3.Text)
                    );

                    rowAffect += ii.NumberOfRowAffected < 0 ? 0 : ii.NumberOfRowAffected;
                    msg += string.IsNullOrWhiteSpace(ii.Message) ? "" : string.Format("NV {0}: {1}<br />", item, ii.Message);
                }

                Tools.messageConfirmSuccess(msg, string.Format(Lng.QuetThe_DKLamThem.msg_2 + " ({0})", rowAffect));
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
        }

        protected void btnDangKyTapThe_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                Guid calam = new Guid(cmbCaLam2.Value.ToString());
                var lNv = db.tblEmployees.Where(p => p.DepID == txtMaTo.Text).Select(i => i.EmployeeID).ToList();

                int rowAffect = 0; string msg = "";
                foreach (var item in lNv)
                {
                    var ii = logic.DangKyCaLam(item,
                        txtNgayDK2.SelectedDate,
                        calam,
                        int.Parse(cmbLoaiNgay2.Value.ToString()),
                        int.Parse(txtHsLuong2.Text)
                    );

                    rowAffect += ii.NumberOfRowAffected < 0 ? 0 : ii.NumberOfRowAffected;
                    msg += string.IsNullOrWhiteSpace(ii.Message) ? "" : string.Format("NV {0}: {1}<br />", item, ii.Message);
                }

                Tools.messageConfirmSuccess(msg, string.Format(Lng.QuetThe_DKLamThem.msg_2 + " ({0})", rowAffect));
                txtMaTo.Text = txtTo.Text = "";
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
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
                txtNhanVien.IndicatorTip = Lng.QuetThe_DKLamThem.msg_3;
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