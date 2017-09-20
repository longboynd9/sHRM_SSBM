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
    public partial class ImportTsTinhLuong : BackEndPageBase
    {
        Core.Business.Logic.Luong.TinhLuong logic = new Core.Business.Logic.Luong.TinhLuong();
        Core.Business.Logic.ChamCong.calam logicCL = new Core.Business.Logic.ChamCong.calam();

        dcDatabaseDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                //LoadData();
                LoadTree();
                LoadAllowance();

                var lstMapping = db.tblRef_Allowances.Select(i => new Core.Controller.Employee.cMapping()
                {
                    c1 = i.AllowanceID,
                    c1Text = i.AllowanceName,
                    dataType = 'f'
                }).ToList();
                lstMapping.Insert(0, new Core.Controller.Employee.cMapping()
                {
                    c1 = "EmployeeID",
                    c1Text = Lng.Luong_ImportTsTinhLuong.maNV,
                    dataType = 's'
                });
                stoMapping.DataSource = lstMapping;
                stoMapping.DataBind();
                Lng.Web_Language.Lng_SetControlTexts(this);

                txtThang.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            }

            var jr = Store1.Reader[0] as JsonReader;
            foreach (var it in db.tblRef_Allowances.Select(i => new RecordField(i.AllowanceID, RecordFieldType.Float)))
                jr.Fields.Add(it);
        }

        void LoadData()
        {
            var lst = db.tbThamSoTinhLuongs.Where(i => i.thang == txtThang.SelectedDate);
            if (!string.IsNullOrWhiteSpace(txtSearchKey.Text))
                lst = lst.Where(i => i.employeeID.IndexOf(txtSearchKey.Text) >= 0);

            Store1.DataSource = lst.ToList();
            Store1.DataBind();
        }

        private void LoadAllowance()
        {
            stoPK.DataSource = db.tblRef_Allowances.Select(i => new
            {
                AllowanceID = i.AllowanceID,
                AllowanceName = i.AllowanceName,
                value = 0
            });
            stoPK.DataBind();
            
            foreach (var c in db.tblRef_Allowances.Select(i => new NumberColumn()
            {
                Header = i.AllowanceName,
                DataIndex = i.AllowanceID,
                Format = "0,0"
            }))
            {
                GridPanel1.ColumnModel.Columns.Insert(2, c);
            }
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
                Guid commandId = new Guid(e.ExtraParams["id"]);
                string commandName = e.ExtraParams["command"];

                switch (commandName)
                {
                    case "Delete":
                        DeleteRecord(commandId);
                        LoadData();
                        break;
                    case "Edit":
                        EditRecord(commandId);
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
            var emp = db.tbThamSoTinhLuongs.SingleOrDefault(i => i.id == commandId);

            if (emp != null)
            {
                db.tbThamSoTinhLuongs.DeleteOnSubmit(emp);
                db.SubmitChanges();
            }
        }

        private void EditRecord(Guid commandId)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            var emp = db.tbThamSoTinhLuongs.SingleOrDefault(i => i.id == commandId);

            if (emp != null)
            {
                txtNhanVien.Text = emp.employeeID;
                txtThangImport.Value = emp.thang;

                var lst = db.tblRef_Allowances.ToList();
                var lst2 = lst.Select(i => new
                {
                    AllowanceID = i.AllowanceID,
                    AllowanceName = i.AllowanceName,
                    value = PropertyExtension1.GetPropValue(emp, i.AllowanceID)
                }).ToList();
                
                stoPK.DataSource = lst2;
                stoPK.DataBind();

                editor.Show();
            }
        }



        protected void btnDangKy_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                DataTable dtAllowance = GetAllowanceSubmit();
                if (dtAllowance.Rows.Count == 0)
                {
                    Tools.message(Lng.Luong_ImportTsTinhLuong.msg_js4);
                    return;
                }
                dtAllowance.Rows[0]["employeeID"] = txtNhanVien.Text;
                
                var ret = logic.ImportAllowance(txtThangImport.SelectedDate, dtAllowance);

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
                DataTable dtAllowance = GetAllowanceSubmit();
                if (dtAllowance.Rows.Count == 0)
                {
                    Tools.message(Lng.Luong_ImportTsTinhLuong.msg_js4);
                    return;
                }

                var ret = logic.ImportAllowance_WithDep(txtMaTo.Text, txtThangImport2.SelectedDate, dtAllowance);

                Tools.message(string.Format(Lng.Luong_ImportTsTinhLuong.msg_js5 + "({0})", ret.NumberOfRowAffected));
                txtMaTo.Text = txtTo.Text = "";
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
        }

        DataTable GetAllowanceSubmit()
        {
            string s = h_Allowance.Value.ToString();
            if (s.EndsWith("|"))
                s = s.Substring(0, s.Length - 1);

            DataTable dtAllowance4Import = new DataTable("dtAllowance4Import");
            dtAllowance4Import.Columns.AddRange(new DataColumn[]{
                new DataColumn("employeeID"),
                new DataColumn("PC1", typeof(double)),
                new DataColumn("PC2", typeof(double)),
                new DataColumn("PC3", typeof(double)),
                new DataColumn("PC4", typeof(double)),
                new DataColumn("PC5", typeof(double)),
                new DataColumn("PC6", typeof(double)),
                new DataColumn("PC7", typeof(double)),
                new DataColumn("PC8", typeof(double)),
                new DataColumn("PC9", typeof(double)),
                new DataColumn("PC10", typeof(double)),
                new DataColumn("PC11", typeof(double)),
                new DataColumn("PC12", typeof(double)),
                new DataColumn("PC13", typeof(double)),
                new DataColumn("PC14", typeof(double)),
                new DataColumn("PC15", typeof(double)),
                new DataColumn("PC16", typeof(double)),
                new DataColumn("PC17", typeof(double)),
                new DataColumn("PC18", typeof(double)),
                new DataColumn("PC19", typeof(double)),
                new DataColumn("PC20", typeof(double))
            });

            DataRow dr = dtAllowance4Import.NewRow();
            for (int i = 1; i < 21; i++)
                dr["PC" + i] = 0;

            foreach (string s1 in s.Split('|'))
            {
                string[] a = s1.Split('~');
                if (a.Length == 3)
                    dr[a[0]] = double.Parse(a[2]);
            }

            dtAllowance4Import.Rows.Add(dr);
            return dtAllowance4Import;
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
            if (cmEmpID == null)
            {
                Tools.message("Mapping thiếu EmployeeID");
                return;
            }
            colMapping.Remove(cmEmpID);

            DataTable dtAllowance4Import = new DataTable("dtAllowance4Import");
            dtAllowance4Import.Columns.AddRange(new DataColumn[]{
                new DataColumn("employeeID"),
                new DataColumn("PC1", typeof(double)),
                new DataColumn("PC2", typeof(double)),
                new DataColumn("PC3", typeof(double)),
                new DataColumn("PC4", typeof(double)),
                new DataColumn("PC5", typeof(double)),
                new DataColumn("PC6", typeof(double)),
                new DataColumn("PC7", typeof(double)),
                new DataColumn("PC8", typeof(double)),
                new DataColumn("PC9", typeof(double)),
                new DataColumn("PC10", typeof(double)),
                new DataColumn("PC11", typeof(double)),
                new DataColumn("PC12", typeof(double)),
                new DataColumn("PC13", typeof(double)),
                new DataColumn("PC14", typeof(double)),
                new DataColumn("PC15", typeof(double)),
                new DataColumn("PC16", typeof(double)),
                new DataColumn("PC17", typeof(double)),
                new DataColumn("PC18", typeof(double)),
                new DataColumn("PC19", typeof(double)),
                new DataColumn("PC20", typeof(double))
            });



            ExcelExtend excel = new ExcelExtend();
            excel.OpenFile(Server.MapPath("~/Cpanel/Luong/Tempory/" + h_FileAttacked.Value));
            var dt = excel.GetAllAvalidData();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var r = dtAllowance4Import.NewRow();
                    for (int i = 1; i < 21; i++)
                        r["PC" + i] = 0;

                    r["employeeID"] = Core.Controller.Import.ImportHelper.MakeSureString(dr[cmEmpID.c2]);
                    foreach (var c in colMapping)
                        r[c.c1] = dr[c.c2];

                    dtAllowance4Import.Rows.Add(r);
                }

                var ret = logic.ImportAllowance(txtThangImportExcel.SelectedDate, dtAllowance4Import);
                Tools.messageConfirmSuccess("Import thành công (" + ret.NumberOfRowAffected + ")");
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