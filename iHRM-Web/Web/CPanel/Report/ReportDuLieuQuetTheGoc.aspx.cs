using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePowerPortal_Core.Web;
using iHRM.WebPC.Classes;
using OfficeOpenXml.Style;
using System.IO;
using OfficeOpenXml;

namespace iHRM.WebPC.Cpanel.Report
{
    public partial class ReportDuLieuQuetTheGoc : BackEndPageBase
    {
        static Int32 total = 0;
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
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
                // LoadDataquetthe();
                //  LoadNextData();
                hdhidde.Value = "";
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
            CultureInfo ci = new CultureInfo("en-US");

        }
        protected void btnSearch_click(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day;
            DateTime todates;
            var dt = new DataTable();
            if (txtDate.SelectedDate != null && todate.SelectedDate != null)
            {
                day = txtDate.SelectedDate;
                todates = todate.SelectedDate.AddHours(23).AddMinutes(59).AddSeconds(59).AddTicks(99);
                dt = logic.GetReportquetTheGoc(day, todates, DepID, txtSearch.Text != "" ? txtSearch.Text : null);
                AspNetCache.SetCache("reportGioCongGioTangCa" + day + "_" + todates,dt);
                Store1.DataSource = dt;
                Store1.DataBind();
            }
            // Store1.DataSource = logic.GetReportquetTheMonth(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text), new System.Data.SqlClient.SqlParameter("phongban", hdhidde.Value));
            else
            {
                DateTime date = DateTime.Now;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                dt = logic.GetReportquetTheGoc(firstDayOfMonth, lastDayOfMonth, DepID, txtSearch.Text != "" ? txtSearch.Text : null);
                AspNetCache.SetCache("reportGioCongGioTangCa" + firstDayOfMonth + "_" + lastDayOfMonth, dt);
                Store1.DataSource = dt;
                Store1.DataBind();
            }
        }
        #region xuat excel
        //protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        //{
        //    DateTime day = txtDate.SelectedDate;
        //    DateTime todates = todate.SelectedDate;
        //    DataTable tbl = (DataTable)AspNetCache.GetCache("reportGioCongGioTangCa" + day + "_" + todates);
        //    if (tbl != null)
        //    {
        //        var dt2 = ExcelExportHelper.CreateGroupInDT(tbl, "DepName", "STT");
        //        //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
        //        xuatexcel(dt2, "Tempchitietvaorathang.xlsx", 9, 1);
        //    }
        //    else
        //    {
        //        string DepID = null;
        //        if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
        //            DepID = hdhidde.Value.ToString();
   
        //        var dt = new DataTable();
        //        if (txtDate.SelectedDate != null && todate.SelectedDate != null)
        //        {
        //            day = txtDate.SelectedDate;
        //            todates = todate.SelectedDate;

        //            dt = logic.GetReportquetTheMonth(day, todates, DepID, txtSearch.Text != "" ? txtSearch.Text : null);
        //            Store1.DataSource = dt;
        //            if(dt!=null)
        //            {
        //                var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
        //                //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
        //                xuatexcel(dt2, "Tempchitietvaorathang.xlsx", 9, 1);
        //            }
        //        }
        //        // Store1.DataSource = logic.GetReportquetTheMonth(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text), new System.Data.SqlClient.SqlParameter("phongban", hdhidde.Value));
        //        else
        //        {
        //            DateTime date = DateTime.Now;
        //            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        //            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        //            dt = logic.GetReportquetTheMonth(firstDayOfMonth, lastDayOfMonth, DepID, txtSearch.Text != "" ? txtSearch.Text : null);
        //            dt.Columns.Add("TT");
        //            dt.Columns.Add("tgTangCa", typeof(double));
        //            Store1.DataSource = dt;
        //            if(dt!=null)
        //            {
        //                var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
        //                //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
        //                xuatexcel(dt2, "Tempchitietvaorathang.xlsx", 9, 1);
        //            }
        //        }
        //    }

        //    //BangLuongChiTiet_recalc(dt);

        //}
        //public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        //{
        //    try
        //    {

        //        FileInfo fileTemp = null;
        //        int _irow = 0;
        //        int _indexcol = 0;
        //        string EXCEL_FILE = strFileExcel;
        //        string strTemplateFilePath = ResolveUrl("~/") + "Temp/" + EXCEL_FILE;
        //        string strAttach = string.Format("Bao_Cao_thống_kê_dữ_liệu_quẹt_thẻ{0}_{1}_{2}.xlsx", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        //        fileTemp = new FileInfo(Server.MapPath(strTemplateFilePath));
        //        if (dsData.Rows.Count > 0)
        //        {
        //            using (var stream = new MemoryStream())
        //            {
        //                using (ExcelPackage xlPackage = new ExcelPackage(fileTemp, true))
        //                {
        //                    ExcelWorksheet worksheet = null;
        //                    if (xlPackage.Workbook.Worksheets.Count > 0)
        //                    {
        //                        worksheet = xlPackage.Workbook.Worksheets[1];
        //                    }
        //                    string donvi = "";


        //                    donvi = "";
        //                    //  worksheet.Cells[7, 2].Value = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        //                    //  worksheet.Cells[8, 2].Value = Convert.ToDateTime(dtangay.Value).Day + "/" + Convert.ToDateTime(dtangay.Value).Month + "/" + Convert.ToDateTime(dtangay.Value).Year + "  " + cboFromHour.SelectedItem.Value + ":" + cboFromPhut.SelectedItem.Value + ":00"; ;
        //                    //  worksheet.Cells[9, 2].Value = Convert.ToDateTime(dtToDate.Value).Day + "/" + Convert.ToDateTime(dtToDate.Value).Month + "/" + Convert.ToDateTime(dtToDate.Value).Year + "  " + cbotoHour.SelectedItem.Value + ":" + cboToPhut.SelectedItem.Value + ":00";
        //                    worksheet.Cells[5, 1].Value = "Ngày:" + txtDate.SelectedDate.ToString("dd/MM/yyyy");

        //                    try
        //                    {
        //                        int _index = 1;
        //                        foreach (DataRow _dr in dsData.Rows)
        //                        {

        //                            if (_dr["DepName"].ToString() != "")
        //                            {

        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 1].Value = _dr["DepName"].ToString();
        //                                // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
        //                                for (int i = 0; i <= 16; i++)
        //                                {

        //                                    var cell = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i];
        //                                    var border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
        //                                    var fill = cell.Style.Fill;
        //                                    fill.PatternType = ExcelFillStyle.Solid;
        //                                    fill.BackgroundColor.SetColor(System.Drawing.Color.YellowGreen);
        //                                    border.Left.Style = border.Right.Style = border.Bottom.Style = ExcelBorderStyle.Thin;
        //                                }
        //                                _irow++;

        //                            }
        //                            else
        //                            {
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Value = _index;
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 3].Value = _dr["EmployeeName"].ToString();
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].Value = _dr["EmployeeCode"].ToString();
        //                               // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = _dr["PosName"].ToString();
        //                                if (_dr["AppliedDate"] != null && _dr["AppliedDate"].ToString() != "")
        //                                {
        //                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = Convert.ToDateTime(_dr["AppliedDate"].ToString()).ToShortDateString();
        //                                }
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Value = _dr["IDCard"].ToString();
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value = _dr["PosName"].ToString();
        //                                if (_dr["ngay"] != null && _dr["ngay"].ToString() != "")
        //                                {
        //                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol +10].Value = Convert.ToDateTime(_dr["ngay"].ToString()).ToShortDateString();
        //                                }
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 11].Value = _dr["tgQuetDen"].ToString();
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 12].Value = _dr["tgDiMuon"]==DBNull.Value?"0": _dr["tgDiMuon"];
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 13].Value = _dr["tgQuetVe"].ToString();
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 14].Value = _dr["tgVeSom"]==DBNull.Value?"0": _dr["tgVeSom"].ToString();
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 15].Value = _dr["tgTinhTangCa"]==DBNull.Value?"0": _dr["tgTinhTangCa"]+"H";
                                        
                                        
        //                                for (int i = 0; i <= 16; i++)
        //                                {
        //                                    var cells = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol];
        //                                    var borders = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
        //                                    var borderschil = worksheet.Cells[iStartRow + _irow + 1, iStartCol + _indexcol + i].Style.Border;
        //                                    if ((iStartCol + _indexcol + i) < 2 || (iStartCol + _indexcol + i) > 3)
        //                                    {
        //                                        borders.Left.Style = borders.Right.Style = ExcelBorderStyle.Thin;

        //                                        borderschil.Bottom.Style = borderschil.Left.Style = borderschil.Right.Style = ExcelBorderStyle.Thin;
        //                                        borderschil.Top.Style = ExcelBorderStyle.Dotted;
        //                                    }
        //                                    else
        //                                    {
        //                                        borderschil.Bottom.Style = ExcelBorderStyle.Thin;
        //                                        borderschil.Top.Style = ExcelBorderStyle.Dotted;
        //                                    }
        //                                }
        //                                _irow++;
        //                                _index++;
        //                            }
        //                        }
        //                        worksheet.View.PageLayoutView = false;
        //                        //  worksheet.Cells.AutoFitColumns();
        //                        xlPackage.SaveAs(stream);
        //                        Byte[] bytearray = stream.ToArray();
        //                        stream.Flush();
        //                        stream.Close();
        //                        this.Response.ClearHeaders();
        //                        this.Response.Clear();
        //                        this.Response.ContentType = "application/vnd.ms-excel";
        //                        this.Response.AddHeader("content-disposition", "attachment;filename=" + strAttach);
        //                        this.Response.AddHeader("Content-Length", bytearray.Length.ToString());
        //                        this.Response.ContentType = "application/octet-stream";
        //                        this.Response.BinaryWrite(bytearray);
        //                        this.Response.End();
        //                    }
        //                    catch (Exception e)
        //                    {

        //                        throw;
        //                    }


        //                }
        //            }
        //        }
        //        else
        //        {
        //            //  Tool.message_HRM("Không có dữ liệu");
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        #endregion
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
        #endregion
    }
}