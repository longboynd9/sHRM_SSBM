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
    public partial class ImportLuongSP : BackEndPageBase
    {
        Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();
        Core.Business.Logic.ChamCong.calam logicCL = new Core.Business.Logic.ChamCong.calam();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                //LoadData();
                LoadTree();
                var lstMapping = new List<Core.Controller.Employee.cMapping>();
                lstMapping.Add(new Core.Controller.Employee.cMapping()
                {
                    c1 = "EmployeeID",
                    c1Text = Lng.Luong_ImportTsTinhLuong.maNV,
                    dataType = 's'
                });
                lstMapping.Add(new Core.Controller.Employee.cMapping()
                {
                    c1 = "LuongSP",
                    c1Text = Lng.Luong_ImportTsTinhLuong.maNV,
                    dataType = 'f'
                });
                stoMapping.DataSource = lstMapping;
                stoMapping.DataBind();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }

        void LoadData()
        {
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var lst = db.tbThamSoTinhLuongs.Where(i => i.thang == txtThang.SelectedDate);
            if (!string.IsNullOrWhiteSpace(txtSearchKey.Text))
                lst = lst.Where(i => i.employeeID.IndexOf(txtSearchKey.Text) >= 0);

            Store1.DataSource = lst.ToList();
            Store1.DataBind();
        }
        
        #region for tree dep
        void LoadTree()
        {
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
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
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var emp = db.tbThamSoTinhLuongs.SingleOrDefault(i => i.id == commandId);

            if (emp != null)
            {
                db.tbThamSoTinhLuongs.DeleteOnSubmit(emp);
                db.SubmitChanges();
            }
        }



        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                DataTable dtLuongSP = new DataTable("dtLuongSP");
                dtLuongSP.Columns.AddRange(new DataColumn[]{
                    new DataColumn("employeeID"),
                    new DataColumn("LuongSP", typeof(double))
                });
                var dr = dtLuongSP.NewRow();
                dr["employeeID"] = txtNhanVien.Text;
                dr["LuongSP"] = txtLuongSP.Value;
                dtLuongSP.Rows.Add(dr);

                var ret = logic.ImportLuongSp(txtThangImport.SelectedDate, dtLuongSP);

                Tools.message(string.Format(Lng.Luong_ImportTsTinhLuong.msg_js5 + " ({0})", ret.NumberOfRowAffected));
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
                var ret = logic.ImportLuongSp_WithDep(txtMaTo.Text, txtThangImport2.SelectedDate, Convert.ToDouble(txtLuongSP2.Value));

                Tools.message(string.Format(Lng.Luong_ImportTsTinhLuong.msg_js5 + "({0})", ret.NumberOfRowAffected));
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

            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            var f = db.tblRef_Departments.SingleOrDefault(i => i.DepID == rsm.SelectedNode.NodeID);
            if (f == null)
            {
                Tools.messageConfirmErr(Lng.common_msg.RecordNotFound);
                return;
            }
            //if (f.tblRef_Departments != null && f.tblRef_Departments.Count > 0)
            //{
            //    Tools.messageConfirmErr(Lng.Category_Department.Do_Not_Access_Root);
            //    return;
            //}

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
                txtNhanVien.IndicatorTip = Lng.Luong_ImportTsTinhLuong.msg_js6;
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



        #region  up load excel
        protected void txtUploadExcel_DirectUp(object sender, DirectEventArgs e)
        {
            if (txtUploadExcel.HasFile)
            {

                string p = Server.MapPath("~/Cpanel/Luong/Tempory/Import.xls");
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
                                p = Server.MapPath("~/Cpanel/Luong/Tempory/Import" + new Random().Next() + ".xls");
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
            //if (txtThangImportExcel.IsEmpty)
            //{
            //    Tools.message("Chọn tháng import...");
            //    return;
            //}

            string map = h_MappingString.Value as string;
            if (string.IsNullOrWhiteSpace(map))
            {
                Tools.message("Chọn mapping...");
                return;
            }
            if (string.IsNullOrWhiteSpace(h_FileAttacked.Value as string))
            {
                Tools.message("Chọn file import...");
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
            var cmLuongSP = colMapping.SingleOrDefault(i => i.c1 == "LuongSP");
            if (cmEmpID == null || cmLuongSP == null)
            {
                Tools.message("Mapping thiếu EmployeeID hoặc LuongSP");
                return;
            }

            DataTable dtLuongSP = new DataTable("dtLuongSP4Import");
            dtLuongSP.Columns.AddRange(new DataColumn[]{
                new DataColumn("employeeID"),
                new DataColumn("LuongSP", typeof(double))
            });



            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(Server.MapPath("~/Cpanel/Luong/Tempory/" + h_FileAttacked.Value));
            var dt = excel.GetAllAvalidData();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var r = dtLuongSP.NewRow();

                    r["employeeID"] = Core.Controller.Import.ImportHelper.MakeSureString(dr[cmEmpID.c2]);
                    r["LuongSP"] = Core.Controller.Import.ImportHelper.MakeSureFloat(dr[cmLuongSP.c2]);

                    dtLuongSP.Rows.Add(r);
                }

                var ret = logic.ImportLuongSp(txtThangImportExcel.SelectedDate, dtLuongSP);
                if (ret.NumberOfRowAffected >= dtLuongSP.Rows.Count)
                {
                    Tools.messageConfirmSuccess(string.Format("Import thành công ({0})<br />{1}", ret.NumberOfRowAffected
                        , string.IsNullOrWhiteSpace(ret.Message) ? "": ("With msg: " + ret.Message)
                    ));
                }
                else
                {
                    Tools.messageConfirmErr(string.Format("Import thành công ({0})<br />{1}<br />{2}", ret.NumberOfRowAffected
                        , string.IsNullOrWhiteSpace(ret.Message) ? "" : ("With msg: " + ret.Message)
                        , (ret.Data == null || ret.Data.Rows.Count == 0) ? "" : ("Error in empID: " + string.Join(", ", ret.Data.Select().Select(i => i[0])))
                    ));
                }
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex, "Import fail");
            }
        }

        #endregion

        protected void ExportTsTinhLuong_DirectClick(object sender, DirectEventArgs e)
        {
            if (txtThang.SelectedDate != null)
            {
                //DataTable dtTsTinhLuong = logic.GetTsTinhLuong(txtThang.SelectedDate);
                //ExcelExportHelper ex = new ExcelExportHelper("Luong/Temp_tsTinhLuong.xls");
                //ex.WriteToCell("A2", "CÁC KHOẢN PHỤ CẤP THÁNG " + txtThang.SelectedDate.ToString("MM/yyyy"));
                //ex.FillDataTable(dtTsTinhLuong);
                //ex.RendAndFlush("BangPhuCap");
            }
            else
            {
                Tools.messageConfirmSuccess("Bạn chưa chọn tháng!");
                txtThang.Focus();
            }
            
        }

    }
}