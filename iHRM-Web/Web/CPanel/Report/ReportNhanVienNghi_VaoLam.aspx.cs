using ePowerPortal_Core.Web;
using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Classes;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Cpanel.Report
{
    public partial class ReportNhanVienNghi_VaoLam : BackEndPageBase
    {
        static Int32 total = 0;
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        global::iHRM.WebPC.Code.Tools Tools = new global::iHRM.WebPC.Code.Tools();
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                DateTime date = DateTime.Now;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                txtDate.SelectedDate = firstDayOfMonth;
                todate.SelectedDate = lastDayOfMonth;
                LoadData();
                hdhidde.Value = "";
                Lng.Web_Language.Lng_SetControlTexts(this);
                var store = this.SelectBoxSearch.GetStore();
                store.DataSource = new object[]{ 
                                        new object[]{"tatca", "Tìm kiếm tất cả"},
                                        new object[]{"nghilam", "Tìm kiếm NV nghỉ làm"},
                                        new object[]{"vaolam", "Tìm kiếm NV vào làm"}
                                   };
                store.DataBind();
            }
            CultureInfo ci = new CultureInfo("en-US");
        }
        protected void sto1_SubmitData(object sender, StoreSubmitDataEventArgs e)
        {
            ExportExcel4extGridOnSubmitData(e.Xml);
        }
        protected void Search(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day = txtDate.SelectedDate;
            DateTime todates = todate.SelectedDate;
            var data = new DataTable();
            if (day != null && todates != null)
            {
                string fieldSearch = SelectBoxSearch.Value.ToString();
                string strGioiTinh = cboGioiTinh.Value.ToString();
                data = logic.GetReportNhanVien(day, todates, DepID, fieldSearch, strGioiTinh);
                if (data.Rows.Count > 0)
                {
                    Store1.DataSource = data.AsEnumerable().OrderBy(p => p["DepName"]).CopyToDataTable();
                }
                else
                {
                    Store1.DataSource = data;
                }
                Store1.DataBind();
            }
            AspNetCache.SetCache(string.Format("ReportNguoiNghi_VaoLam{0}_{1}", day, todates), data);
        }
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            DateTime day = txtDate.SelectedDate;
            DateTime todates = todate.SelectedDate;
            DataTable tbl = (DataTable)AspNetCache.GetCache(string.Format("ReportNguoiNghi_VaoLam{0}_{1}", day, todates));
            if (tbl != null)
            {
                xuatexcel(tbl.AsEnumerable().OrderBy(p => p["DepName"]).CopyToDataTable(), "TempNguoiNghi_VaoLam.xlsx", 7, 1);
            }
        }
        public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        {
            try
            {
                FileInfo fileTemp = null;
                int _irow = 0;
                string EXCEL_FILE = strFileExcel;
                string strTemplateFilePath = ResolveUrl("~/") + "Temp/" + EXCEL_FILE;
                string strAttach = "";
                string strGioitinh = "";
                if (cboGioiTinh.Value.ToString() != "tatca")
                {
                    strGioitinh = cboGioiTinh.Value.ToString();
                }
                if (SelectBoxSearch.Value.ToString() == "nghilam")
                {
                    strAttach = string.Format("Bao_Cao_NV_nghi_lam_{0}_{1}_{2}_{3}.xlsx", strGioitinh, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                }
                else if (SelectBoxSearch.Value.ToString() == "vaolam")
                    strAttach = string.Format("Bao_Cao_NV_vao_lam_{0}_{1}_{2}_{3}.xlsx", strGioitinh, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                else
                    strAttach = string.Format("Bao_Cao_NV_{0}_{1}_{2}_{3}.xlsx", strGioitinh, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                fileTemp = new FileInfo(Server.MapPath(strTemplateFilePath));
                if (dsData.Rows.Count > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        using (ExcelPackage xlPackage = new ExcelPackage(fileTemp, true))
                        {
                            ExcelWorksheet worksheet = null;
                            if (xlPackage.Workbook.Worksheets.Count > 0)
                            {
                                worksheet = xlPackage.Workbook.Worksheets[1];
                            }
                            if (SelectBoxSearch.Value.ToString() == "nghilam")
                            {
                                worksheet.Cells[2, 1].Value = "DANH SÁCH NHÂN VIÊN NGHỈ LÀM";
                            }
                            else if (SelectBoxSearch.Value.ToString() == "vaolam")
                            {
                                worksheet.Cells[2, 1].Value = "DANH SÁCH NHÂN VIÊN VÀO LÀM";
                            }
                            else
                            {
                                worksheet.Cells[2, 1].Value = "DANH SÁCH NHÂN VIÊN";
                            }
                            worksheet.Cells[3, 1].Value = string.Format("Từ ngày:{0:dd/MM/yyyy} Đến ngày:{1:dd/MM/yyyy}", txtDate.SelectedDate, todate.SelectedDate);
                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    worksheet.Cells[iStartRow + _irow, iStartCol].Value = _index;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 3].Value = _dr["EmployeeName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 5].Value = _dr["IDCard"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 6].Value = _dr["CardID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 7].Value = _dr["SexID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 8].Value = _dr["EmployeeID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 9].Value = _dr["DepName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 10].Value = _dr["PosName"].ToString();
                                    try
                                    {
                                        string AppliedDate = Convert.ToDateTime(_dr["Birthday"].ToString()).ToString("dd/MM/yyyy");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 4].Value = AppliedDate;
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 4].Value = _dr["Birthday"].ToString();
                                    }
                                    try
                                    {
                                        string AppliedDate = Convert.ToDateTime(_dr["AppliedDate"].ToString()).ToString("dd/MM/yyyy");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = AppliedDate;
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = _dr["AppliedDate"].ToString();
                                    }
                                    try
                                    {
                                        string LeftDate = Convert.ToDateTime(_dr["LeftDate"].ToString()).ToString("dd/MM/yyyy");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 12].Value = LeftDate;
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 12].Value = _dr["LeftDate"].ToString();
                                    }
                                    for (int i = 0; i <= 12; i++)
                                    {
                                        var cell = worksheet.Cells[iStartRow + _irow, iStartCol];
                                        var borders = worksheet.Cells[iStartRow + _irow, iStartCol + i].Style.Border;
                                        borders.Bottom.Style = borders.Left.Style = borders.Right.Style = ExcelBorderStyle.Thin;
                                    }
                                    _index++;
                                    _irow++;
                                }
                                worksheet.View.PageLayoutView = false;
                                //worksheet.Cells.AutoFitColumns();
                                xlPackage.SaveAs(stream);
                                Byte[] bytearray = stream.ToArray();
                                stream.Flush();
                                stream.Close();
                                this.Response.ClearHeaders();
                                this.Response.Clear();
                                this.Response.ContentType = "application/vnd.ms-excel";
                                this.Response.AddHeader("content-disposition", "attachment;filename=" + strAttach);
                                this.Response.AddHeader("Content-Length", bytearray.Length.ToString());
                                this.Response.ContentType = "application/octet-stream";
                                this.Response.BinaryWrite(bytearray);
                                this.Response.End();
                            }
                            catch (Exception e)
                            {
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    //Tool.message_HRM("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
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
            try
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
            catch (Exception)
            {


            }
            //hId.Value = f.DepID;
            //hParent.Value = f.DepParent;
            //lblParent.Html = GetFunctionHtmlCaption(f.tblRef_Department1);
            //FormSetDataContext(formCT, f); //formCT.SetValues(f);
            //txtCode.Disabled = true;

            //btnClear.Hidden = true;
            //wEditor.Show();

            //if (txtCode.Disabled)
            //    txtCaption.Focus(true, 300);
            //else
            //    txtCode.Focus(true, 300);
        }
        #endregion
    }
}