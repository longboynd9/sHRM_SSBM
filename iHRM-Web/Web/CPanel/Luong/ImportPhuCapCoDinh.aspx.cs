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
    public partial class ImportPhuCapCoDinh : BackEndPageBase
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

                var lstMapping = new List<Core.Controller.Employee.cMapping>();
                lstMapping.Add(new Core.Controller.Employee.cMapping() { c1 = "EmployeeID", c1Text = Lng.Luong_ImportPhuCapCoDinh.maNV, dataType = 's' });
                lstMapping.Add(new Core.Controller.Employee.cMapping() { c1 = "pc_XangXe", c1Text = Lng.Luong_ImportPhuCapCoDinh.pcXangXe, dataType = 'f' });
                lstMapping.Add(new Core.Controller.Employee.cMapping() { c1 = "pc_ConTho", c1Text = Lng.Luong_ImportPhuCapCoDinh.pcConTho, dataType = 'f' });
                stoMapping.DataSource = lstMapping;
                stoMapping.DataBind();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            var lst = db.tbPhuCapCoDinhs.Select(i => i);
            if (!string.IsNullOrWhiteSpace(txtSearchKey.Text))
                lst = lst.Where(i => i.employeeID.IndexOf(txtSearchKey.Text) >= 0);

            //if (!string.IsNullOrWhiteSpace(txtDeptCodeSearch.Text))
            //    lst = lst.Where(i => i.tblEmployee.DepID == txtDeptCodeSearch.Text);

            //Store1.DataSource = lst.Select(i => new {
            //    i.employeeID, i.tblEmployee.EmployeeName, i.pc_XangXe, i.pc_ConTho
            //});
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
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == commandId);

            if (emp != null)
            {
                db.tblEmployees.DeleteOnSubmit(emp);
                db.SubmitChanges();
            }
        }



        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                var ret = logic.InsertPcCoDinh(txtNhanVien.Text, Convert.ToDouble(txtPcXangXe.Value), Convert.ToDouble(txtPcConTho.Value));

                Tools.message(Lng.Luong_ImportPhuCapCoDinh.msg_js4 + " (" + ret + ")");
                txtNhanVien.Text = txtNhanVien2.Text = "";
                txtNhanVien.IndicatorIcon = Icon.Information;
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
                int rowAffect = logic.InsertPcCoDinh_ByDept(txtMaTo.Text, Convert.ToDouble(txtPcXangXe2.Value), Convert.ToDouble(txtPcConTho2.Value));
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

                var p = db.tbPhuCapCoDinhs.FirstOrDefault(i => i.employeeID == txtNhanVien.Text);
                if (p != null)
                {
                    txtPcXangXe.Value = p.pc_XangXe;
                    txtPcConTho.Value = p.pc_ConTho;
                }
            }
        }

        protected void btnTim_TapThe(object sender, DirectEventArgs e)
        {
            var dr = logicCL.checkPB(txtMaTo.Text);
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
            var dr = logicCL.checkPB(txtDeptCodeSearch.Text);
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

















        //-------------------up laod excel
        protected void txtUploadExcel_DirectUp(object sender, DirectEventArgs e)
        {
            if (txtUploadExcel.HasFile)
            {

                string p = Server.MapPath("~/Cpanel/Luong/Tempory/ImportPCCD.xls");

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
                                p = Server.MapPath("~/Cpanel/Luong/Tempory/ImportPCCD" + new Random().Next() + ".xls");
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
            var dt = excel.GetAllAvalidData();
            List<object> lst = new List<object>() { new { c1 = "", c1Text = "-- None --" } };
            foreach (DataColumn dc in dt.Columns)
                lst.Add(new { c1 = dc.ColumnName, c1Text = dc.ColumnName });
            stoColMapping.DataSource = lst;
            stoColMapping.DataBind();

            h_FileAttacked.Value = p;
            wMapping.Show();
        }

        protected void btnExecImport_DirectClick(object sender, DirectEventArgs e)
        {
            string map = h_MappingString.Value as string;
            if (string.IsNullOrWhiteSpace(map))
            {
                Tools.message("Chọn mapping...");
                return;
            }
            if (string.IsNullOrWhiteSpace(h_FileAttacked.Value as string))
            {
                Tools.message("Chọn fiel import...");
                return;
            }

            List<Core.Controller.Employee.cMapping> colMapping = new List<Core.Controller.Employee.cMapping>();
            foreach (string s in map.Split(','))
            {
                if (string.IsNullOrWhiteSpace(s))
                    continue;

                int i = s.IndexOf(':');
                if (i == -1)
                    continue;

                colMapping.Add(new Core.Controller.Employee.cMapping() { c1 = s.Substring(0, i), c2 = s.Substring(i + 1) });
            }
            var cmEmpID = colMapping.SingleOrDefault(i => i.c1 == "EmployeeID");
            if (cmEmpID == null)
            {
                Tools.message("Mapping thiếu EmployeeID");
                return;
            }
            var cmPCXX = colMapping.SingleOrDefault(i => i.c1 == "pc_XangXe");
            var cmPCCT = colMapping.SingleOrDefault(i => i.c1 == "pc_ConTho");

            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(Server.MapPath("~/Cpanel/Luong/Tempory/" + h_FileAttacked.Value));
            var dt = excel.GetAllAvalidData();
            try
            {
                int NumberOfRowAffected = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    NumberOfRowAffected += logic.InsertPcCoDinh(dr[cmEmpID.c2].ToString().Trim(), 
                        cmPCXX == null ? 0 : Convert.ToDouble(dr[cmPCXX.c2]),
                        cmPCCT == null ? 0 : Convert.ToDouble(dr[cmPCCT.c2])
                    );
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