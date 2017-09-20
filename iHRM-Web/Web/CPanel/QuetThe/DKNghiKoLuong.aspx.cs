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
    public partial class DKNghiKoLuong : BackEndPageBase
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

                stoLyDo.DataSource = new object[]
                {
                    new object[] { (int)Enums.eLyDoNghi.VangMat, Lng.QuetThe_DKVangMat.ldVangMat },
                    new object[] { (int)Enums.eLyDoNghi.ThaiSan, Lng.QuetThe_DKVangMat.ldThaiSan  },
                    new object[] { (int)Enums.eLyDoNghi.Om, Lng.QuetThe_DKNghiKhongLuong.ldNghiOm },
                    new object[] { (int)Enums.eLyDoNghi.KhongLuong, Lng.QuetThe_DKNghiKhongLuong.ldNghiKoLuong},
                    new object[] { (int)Enums.eLyDoNghi.Khac, Lng.QuetThe_DKNghiKhongLuong.ldKhac }
                };
                stoLyDo.DataBind();

                StoInGroup1.DataSource = db.tblEmp_Group1s;
                StoInGroup1.DataBind();

                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            Store1.DataSource = logic.GetDataDangKyVangMat(txtSearchKey.Text == "" ? null : txtSearchKey.Text,
                txtTuNgay.IsEmpty ? null : (DateTime?)txtTuNgay.Value,
                txtDenNgay.IsEmpty ? null : (DateTime?)txtDenNgay.Value,
                0
            );
            Store1.DataBind();
        }
        protected void settotalNgayNghi(object sender, DirectEventArgs e)
        {
            DateTime tungayDK = txtNgayDK.SelectedDate;
            DateTime denngayDK = txtDenNgayDK.SelectedDate;
            txttotalNgayNghi.Text = ((denngayDK - tungayDK).TotalDays + 1).ToString();
        }
        #region treee
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
            var vm = db.tbDangKyVangMats.SingleOrDefault(i => i.id == commandId);
            if (vm != null)
            {
                db.tbDangKyVangMats.DeleteOnSubmit(vm);
                db.SubmitChanges();
            }
            else
            {
                Tools.message(Lng.common_msg.RecordNotFound);
            }
        }

        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                DateTime ngay1 = txtNgayDK.SelectedDate;
                DateTime denNgay = txtDenNgayDK.IsEmpty ? txtNgayDK.SelectedDate : txtDenNgayDK.SelectedDate;
                int caXinNghi = Convert.ToInt32(cmbXinNghi.Value);

                int totalRecord = 0;
                string message = "";
                int day = Convert.ToInt32((denNgay - ngay1).TotalDays);
                for (int i = 0; i <= day; i++)
                {
                    DateTime ngay = ngay1.AddDays(i);

                    var ret = logic.DangKyVangMat2(txtNhanVien.Text,
                        ngay,
                        caXinNghi,
                        Convert.ToInt32(cmbLyDo.Value),
                        txtGhiChu.Text,
                        0,
                            coTinhChuyenCan: chkTinhChuyenCan.Checked
                    );
                    totalRecord += ret.ReturnValue;
                    message += ret.Message;
                }
                if (totalRecord > 0)
                {
                    Tools.message(Lng.QuetThe_DKVangMat.msg_2);
                    txtNhanVien.Text = txtNhanVien2.Text = "";
                    txtNhanVien.IndicatorIcon = Icon.Information;
                }
                else
                {
                    Tools.messageConfirmErr(message);
                }
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
                int rowAffect = 0;
                var lNv = db.tblEmployees.Where(p => p.InGroup1 == Convert.ToInt32(cmbNhom1.Value)).Select(i => i.EmployeeID).ToList();

                DateTime ngay1 = txtNgayDK3.SelectedDate;
                DateTime denNgay = txtDenNgayDK3.IsEmpty ? txtNgayDK3.SelectedDate : txtDenNgayDK3.SelectedDate;
                int caXinNghi = Convert.ToInt32(cmbXinNghi3.Value);

                int day = Convert.ToInt32((denNgay - ngay1).TotalDays);
                for (int i = 0; i <= day; i++)
                {
                    DateTime ngay = ngay1.AddDays(i);

                    foreach (var item in lNv)
                        rowAffect += logic.DangKyVangMat2(item,
                            ngay,
                            caXinNghi,
                            Convert.ToInt32(cmbLyDo3.Value),
                            txtGhiChu3.Text,
                            0,
                            coTinhChuyenCan: chkTinhChuyenCan3.Checked
                        ).ReturnValue == 1 ? 1 : 0;
                }

                Tools.message(string.Format(Lng.QuetThe_DKVangMat.msg_2 + " ({0})", rowAffect));
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
                int rowAffect = 0;
                var lNv = db.tblEmployees.Where(p => p.DepID == txtMaTo.Text).Select(i => i.EmployeeID).ToList();
                
                DateTime ngay1 = txtNgayDK2.SelectedDate;
                DateTime denNgay = txtDenNgayDK2.IsEmpty ? txtNgayDK2.SelectedDate : txtDenNgayDK2.SelectedDate;
                int caXinNghi = Convert.ToInt32(cmbXinNghi2.Value);

                int day = Convert.ToInt32((denNgay - ngay1).TotalDays);
                for (int i = 0; i <= day; i++)
                {
                    DateTime ngay = ngay1.AddDays(i);

                    foreach (var item in lNv)
                        rowAffect += logic.DangKyVangMat2(item,
                            ngay,
                            caXinNghi,
                            Convert.ToInt32(cmbLyDo2.Value),
                            txtGhiChu2.Text,
                            0,
                            coTinhChuyenCan: chkTinhChuyenCan2.Checked
                        ).ReturnValue == 1 ? 1 : 0;
                }
                Tools.message(string.Format(Lng.QuetThe_DKNghiKhongLuong.msg_2 + " ({0})", rowAffect));
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
            var dr = logic.checkNV(txtNhanVien.Text);
            if (dr == null)
            {
                txtNhanVien.IndicatorIcon = Icon.Error;
                txtNhanVien.IndicatorTip = Lng.QuetThe_DKNghiKhongLuong.msg_3;
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
            }
            else
            {
                txtTo.Text = string.Format("{0}", DbHelper.DrGet(dr, "DepName"));
            }
        }

        protected void txtNgayDK_DirectSelect(object sender, DirectEventArgs e)
        {
            txtDenNgayDK.SelectedDate = txtNgayDK.SelectedDate;
        }

    }
}