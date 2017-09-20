using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using Ext.Net;
using System.Data;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;

namespace iHRM.WebPC.Cpanel.QuetThe.QTTools
{
    public partial class SuaQuetThe : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.ChamCong.calam CaLogic = new global::iHRM.Core.Business.Logic.ChamCong.calam();
        global::iHRM.Core.Business.Logic.ChamCong.QTTools logic = new global::iHRM.Core.Business.Logic.ChamCong.QTTools();
        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadTree();

                StoInGroup1.DataSource = db.tblEmp_Group1s;
                StoInGroup1.DataBind();

                Lng.Web_Language.Lng_SetControlTexts(this);
            }
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

        protected void settotalNgayNghi(object sender, DirectEventArgs e)
        {
            DateTime tungayDK = txtNgayDK.SelectedDate;
            DateTime denngayDK = txtDenNgayDK.SelectedDate;
            txttotalNgayNghi.Text = ((denngayDK - tungayDK).TotalDays + 1).ToString();
        }

        int regNV(string maNV, DateTime ngay1, DateTime denNgay, TimeSpan tugio, TimeSpan dengio, bool OnlyNoData)
        {
            try
            {
                var nv = db.tblEmployees.SingleOrDefault(p => p.EmployeeID == maNV);
                if (nv == null)
                {
                    txtLog.AppendLine("Không tìm thấy nhân viên [" + maNV + "]!");
                    return 0;
                }

                int day = Convert.ToInt32((denNgay - ngay1).TotalDays);
                int totalRecord = 0;

                //đăng ký từng ngày
                for (int i = 0; i <= day; i++)
                {
                    DateTime ngay = ngay1.AddDays(i);

                    var ketQuaQT = db.tbKetQuaQuetThes.SingleOrDefault(p => p.EmployeeID == maNV && p.ngay == ngay);
                    if (ketQuaQT != null) // Nếu đã đăng ký ca làm
                    {
                        totalRecord += iHRM.Win.ExtClass.QuetThe.QuetThe.SetTimeQT(ketQuaQT.id, tugio, dengio, OnlyNoData, userLoginin:LoginHelper.user);
                    }
                    else
                    {
                        txtLog.AppendLine(string.Format("Ngày {0:dd/MM/yyyy} Chưa đăng ký ca làm! cho nhân viên {1}", ngay, maNV));
                    }
                }

                txtLog.AppendLine(Lng.QuetThe_DKVangMat.msg_2 + " (" + totalRecord + ")");
                return totalRecord;
            }
            catch (Exception ex)
            {
                txtLog.AppendLine(ex.Message);
                return -1;
            }
        }

		protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            var totalRecord = regNV(txtNhanVien.Text,
                txtNgayDK.SelectedDate,
                txtDenNgayDK.IsEmpty ? txtNgayDK.SelectedDate : txtDenNgayDK.SelectedDate,
                txtTuGio.IsEmpty ? new TimeSpan() : txtTuGio.SelectedTime,
                txtDenGio.IsEmpty ? new TimeSpan() : txtDenGio.SelectedTime,
                chkOnlyNoData.Checked
            );

            txtNhanVien.Text = txtNhanVien2.Text = "";
            txtNhanVien.IndicatorIcon = Icon.Information;
        }

        protected void btnDangKyTapThe_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                var lNv = db.tblEmployees.Where(p => p.DepID == txtMaTo.Text).Select(i => i.EmployeeID).ToList();
                int totalRecord = 0;

                foreach (var item in lNv)
                {
                    totalRecord += regNV(item,
                        txtNgayDK2.SelectedDate,
                        txtDenNgayDK2.IsEmpty ? txtNgayDK2.SelectedDate : txtDenNgayDK2.SelectedDate,
                        txtTuGio2.IsEmpty ? new TimeSpan() : txtTuGio2.SelectedTime,
                        txtDenGio2.IsEmpty ? new TimeSpan() : txtDenGio2.SelectedTime,
                        chkOnlyNoData2.Checked
                    );
                }

                txtMaTo.Text = txtTo.Text = "";
                txtMaTo.IndicatorIcon = Icon.Information;
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
                var lNv = db.tblEmployees.Where(p => p.InGroup1 == Convert.ToInt32(cmbNhom1.Value)).Select(i => i.EmployeeID).ToList();

                foreach (var item in lNv)
                {
                    regNV(item,
                        txtNgayDK3.SelectedDate,
                        txtDenNgayDK3.IsEmpty ? txtNgayDK3.SelectedDate : txtDenNgayDK3.SelectedDate,
                        txtTuGio3.IsEmpty ? new TimeSpan() : txtTuGio3.SelectedTime,
                        txtDenGio3.IsEmpty ? new TimeSpan() : txtDenGio3.SelectedTime,
                        chkOnlyNoData3.Checked
                    );
                }

                cmbNhom1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
        }

        protected void btnChon_DirectClick(object sender, EventArgs e)
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
                Tools.messageConfirmErr(Lng.common_msg.RecordNotFound);
                return;
            }
            if (f.tblRef_Departments != null && f.tblRef_Departments.Count > 0)
            {
                Tools.messageConfirmErr(Lng.Category_Department.Do_Not_Access_Root);
                return;
            }

            txtMaTo.Value = f.DepID;
            txtTo.Value = f.DepName;
            ChooseDep.Hidden = true;
        }
        protected void btnFindMaVN_DirectClick(object sender, DirectEventArgs e)
        {
            var dr = CaLogic.checkNV(txtNhanVien.Text);
            if (dr == null)
            {
                txtNhanVien.IndicatorIcon = Icon.Error;
                txtNhanVien.IndicatorTip = Lng.QuetThe_DKVangMat.msg_3;
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
            var dr = CaLogic.checkPB(txtMaTo.Text);
            if (dr == null)
            {
                txtTo.Text = "";
                ChooseDep.Show();
            }
            else
            {
                txtTo.Text = string.Format("{0}", DbHelper.DrGet(dr, "DepName"));
            }
        }

        protected void txtNgayDK_DirectSelect(object sender, DirectEventArgs e)
        {
            try
            {
                var it = db.tbKetQuaQuetThes.SingleOrDefault(i => i.EmployeeID == txtNhanVien.Text && i.ngay == txtNgayDK.SelectedDate.Date);
                if (it != null)
                {
                    txtTuGio.Value = it.tbCaLamViec.tuGio;
                    txtDenGio.Value = it.tbCaLamViec.tuGio.Add(it.tbCaLamViec.denGio);
                }
            }
            catch { }
            txtDenNgayDK.SelectedDate = txtNgayDK.SelectedDate;
        }

    }
}