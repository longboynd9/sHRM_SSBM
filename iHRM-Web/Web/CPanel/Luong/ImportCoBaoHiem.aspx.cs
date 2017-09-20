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
using iHRM.WebPC.Classes;

namespace iHRM.WebPC.Cpanel.Luong
{
    public partial class ImportCoBaoHiem : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.Luong.TinhLuong logic = new global::iHRM.Core.Business.Logic.Luong.TinhLuong();
        global::iHRM.Core.Business.Logic.ChamCong.calam logicCL = new global::iHRM.Core.Business.Logic.ChamCong.calam();

        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                //LoadData();
                LoadTree();

                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            var lst = db.tblEmployees.Where(i => i.coBH == true);
            if (!string.IsNullOrWhiteSpace(txtSearchKey.Text))
                lst = lst.Where(i => i.EmployeeID.IndexOf(txtSearchKey.Text) >= 0);

            Store1.DataSource = lst.Select(i => new { EmployeeID = i.EmployeeID, coBH_ngay = i.coBH_ngay });
            Store1.DataBind();
        }

        #region for tree dep
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
                string commandId = e.ExtraParams["id"];
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

        private void DeleteRecord(string commandId)
        {
            var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == commandId);

            if (emp != null)
            {
                emp.coBH = false;
                db.SubmitChanges();
            }
        }



        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == txtNhanVien.Text);
                if (emp != null)
                {
                    emp.coBH = true;
                    emp.coBH_ngay = txtDateStart.SelectedDate;
                    db.SubmitChanges();

                    Tools.message(Lng.Luong_ImportPhuCapCoDinh.msg_js4);
                    txtNhanVien.Text = txtNhanVien2.Text = "";
                    txtNhanVien.IndicatorIcon = Icon.Information;
                }
                else
                {
                    Tools.message(Lng.common_msg.RecordNotFound);
                }
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
                int rowAffect = logic.InsertCoHh_withDep(txtMaTo.Text, txtDateStart2.SelectedDate);
                Tools.message(string.Format(Lng.Luong_ImportPhuCapCoDinh.msg_js4 + " ({0})", rowAffect));
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
            var dr = logicCL.checkNV(txtNhanVien.Text);
            if (dr == null)
            {
                txtNhanVien.IndicatorIcon = Icon.Error;
                txtNhanVien.IndicatorTip = Lng.Luong_ImportPhuCapCoDinh.msg_js5;
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
            var dr = logicCL.checkPB(txtMaTo.Text);
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
















        //-------------------up laod excel
        protected void txtUploadExcel_DirectUp(object sender, DirectEventArgs e)
        {
            if (txtUploadExcel.HasFile)
            {

                string p = Server.MapPath("~/Cpanel/Luong/Tempory/ImportCoBH.xls");

                try
                {
                    if (File.Exists(p))
                    {
                        try
                        {
                            File.Delete(p);
                        }
                        catch
                        {
                            do
                            {
                                p = Server.MapPath("~/Cpanel/Luong/Tempory/ImportCoBH" + new Random().Next() + ".xls");
                            }
                            while (File.Exists(p));
                        }
                    }

                    //if (txtUpFile.PostedFile.ContentType.ToLower() != "application/vnd.ms-excel")
                    if (!txtUploadExcel.FileName.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Tools.message("Bạn cần nhập file excel (.xls)");
                        return;
                    }
                    txtUploadExcel.PostedFile.SaveAs(p);
                }
                catch
                {
                    Tools.message("Có lỗi khi lưu file excel");
                    return;
                }

                try
                {
                    doExe(Path.GetFileName(p));
                }
                catch (Exception ex)
                {
                    Tools.messageConfirmErr(ex.Message);
                    return;
                }
            }
        }
        private void doExe(string p)
        {
            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(Server.MapPath("~/Cpanel/Luong/Tempory/" + p));
            Provider.ExecuteNonQuery_SQL("UPDATE dbo.tblEmployee SET coBH = 0");
            var dt = excel.GetAllAvalidData();
            try
            {
                int NumberOfRowAffected = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    //NumberOfRowAffected += logic.InsertCoHh_withDep(dr[0].ToString().Trim(), WebHelper.DbGetDate(dr, dt.Columns[1].ColumnName));

                    var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == dr[0].ToString().Trim());
                    if (emp != null)
                    {
                        emp.coBH = true;
                        emp.coBH_ngay = WebHelper.DbGetDate(dr, dt.Columns[1].ColumnName);
                        db.SubmitChanges();

                        NumberOfRowAffected += 1;
                    }
                }

                Tools.messageConfirmSuccess("Import thành công (" + NumberOfRowAffected + ")");
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex, "Import fail");
            }
        }

    }
}