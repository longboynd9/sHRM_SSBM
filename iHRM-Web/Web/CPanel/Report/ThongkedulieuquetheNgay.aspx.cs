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
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace iHRM.WebPC.Cpanel.Report
{
    public partial class ThongkedulieuquetheNgay : BackEndPageBase
    {
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadData();
                // LoadDataquetthe();
                //  LoadNextData();
                hdhidde.Value = "";

                txtDate.SelectedDate = DateTime.Now;
                txtoday.SelectedValue = DateTime.Now;
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }
        protected void Search(object sender, Ext.Net.DirectEventArgs e)
        {
            LoadDataquetthe();
        }

        public void LoadDataquetthe()
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day;
            DateTime today;
            var dt = new DataTable();
            if (txtDate.SelectedDate != null && txtoday.SelectedDate != null)
            {
                day = txtDate.SelectedDate;
                today = txtoday.SelectedDate;
                dt = logic.GetReportQuetTheByDate(day, today, DepID, txtSearch.Text != "" ? txtSearch.Text : null);
                dt.Columns.Add("TT");
                dt.Columns.Add("tgTangCa", typeof(double));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["TT"] = GetTrangThai(dr);
                    if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                        dr["tgDiMuon"] = 0;
                    if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                    {
                        dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                        dr["tgVeSom"] = 0;
                    }
                }
                DataTable tbl = dt.Clone();

                if (cboloai.SelectedItem.Value == "0")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] == null || p["tgQuetDen"].ToString() == "") && (p["tgQuetVe"] == null || p["tgQuetVe"].ToString() == ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (cboloai.SelectedItem.Value == "1")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "") && (p["tgQuetVe"] == null || p["tgQuetVe"].ToString() == ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (cboloai.SelectedItem.Value == "2")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] == null || p["tgQuetDen"].ToString() == "") && (p["tgQuetVe"] != null && p["tgQuetVe"].ToString() != ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (cboloai.SelectedItem.Value == "4")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "") && (p["tgQuetVe"] != null && p["tgQuetVe"].ToString() != ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                    
                }
                else if (cboloai.SelectedItem.Value == "5")
                {
                    try
                    {
                        tbl = dt.Select().CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    } 
                }
                else if (cboloai.SelectedItem.Value == "6")
                {
                    try
                    {
                        tbl = dt.Select().Where(p => p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "").CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    } 
                }
                if (tbl != null)
                {
                    if (tbl.Rows.Count > 0)
                    {
                        tbl = tbl.Select("", "EmployeeName,ngay ASC").CopyToDataTable();
                        Store1.DataSource = tbl;
                        Store1.DataBind();
                        AspNetCache.SetCacheWithTime("TempThongkequetthe", tbl, 1200);
                    }
                    else
                    {
                        Tools.message("Không có dữ liệu");
                        Store1.DataSource = tbl;
                        Store1.DataBind();
                        return;
                    }
                }

            }
            else
            {
                Tools.message("Bạn chưa chọn ngày");
                return;
                // dt = logic.GetReportQuetTheByDate(null, DepID);
            }



        }
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day;
            DateTime today;
            var dt = new DataTable();
            if (txtDate.SelectedDate != null && txtoday.SelectedDate != null)
            {
                day = txtDate.SelectedDate;
                today = txtoday.SelectedDate;
                dt = logic.GetReportQuetTheByDate(day, today, DepID, txtSearch.Text != "" ? txtSearch.Text : null);
                dt.Columns.Add("TT");
                dt.Columns.Add("tgTangCa", typeof(double));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["TT"] = GetTrangThai(dr);
                    if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                        dr["tgDiMuon"] = 0;
                    if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                    {
                        dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                        dr["tgVeSom"] = 0;
                    }
                }
                DataTable tbl = dt.Clone();

                if (cboloai.SelectedItem.Value == "0")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] == null || p["tgQuetDen"].ToString() == "") && (p["tgQuetVe"] == null || p["tgQuetVe"].ToString() == ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (cboloai.SelectedItem.Value == "1")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "") && (p["tgQuetVe"] == null || p["tgQuetVe"].ToString() == ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (cboloai.SelectedItem.Value == "2")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] == null || p["tgQuetDen"].ToString() == "") && (p["tgQuetVe"] != null && p["tgQuetVe"].ToString() != ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (cboloai.SelectedItem.Value == "4")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "") && (p["tgQuetVe"] != null && p["tgQuetVe"].ToString() != ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }

                }
                else if (cboloai.SelectedItem.Value == "5")
                {
                    try
                    {
                        tbl = dt.Select().CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (cboloai.SelectedItem.Value == "6")
                {
                    try
                    {
                        tbl = dt.Select().Where(p => p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "").CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                if (tbl != null)
                {
                    if (tbl.Rows.Count > 0)
                    {
                        Store1.DataSource = tbl;
                        Store1.DataBind();
                        //var dt2 = ExcelExportHelper.CreateGroupInDT(tbl, "DepName", "STT");
                        //  var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
                        xuatexcel(tbl.Select("", "DepName,EmployeeName,ngay ASC").CopyToDataTable(), "TempThongkequetthe.xlsx", 10, 1);
                    }
                    else
                    {
                        Tools.message("Không có dữ liệu");
                        Store1.DataSource = null;
                        Store1.DataBind();
                        return;
                    }
                }

            }
            else
            {
                Tools.message("Bạn chưa chọn ngày");
                return;
                // dt = logic.GetReportQuetTheByDate(null, DepID);
            }



            // BangLuongChiTiet_recalc(dt);

        }

        public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        {
            try
            {

                FileInfo fileTemp = null;
                int _irow = 0;
                int _indexcol = 0;
                string EXCEL_FILE = strFileExcel;
                string strTemplateFilePath = ResolveUrl("~/") + "Temp/" + EXCEL_FILE;
                string strAttach = string.Format("Bao_Cao_thống_kê_dữ_liệu_quẹt_thẻ{0}_{1}_{2}.xlsx", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                fileTemp = new FileInfo(Server.MapPath(strTemplateFilePath));
                string manvChange = "";
                int countMaNV = 1;
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
                            string donvi = "";


                            donvi = "";
                            //  worksheet.Cells[7, 2].Value = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                            //  worksheet.Cells[8, 2].Value = Convert.ToDateTime(dtangay.Value).Day + "/" + Convert.ToDateTime(dtangay.Value).Month + "/" + Convert.ToDateTime(dtangay.Value).Year + "  " + cboFromHour.SelectedItem.Value + ":" + cboFromPhut.SelectedItem.Value + ":00"; ;
                            //  worksheet.Cells[9, 2].Value = Convert.ToDateTime(dtToDate.Value).Day + "/" + Convert.ToDateTime(dtToDate.Value).Month + "/" + Convert.ToDateTime(dtToDate.Value).Year + "  " + cbotoHour.SelectedItem.Value + ":" + cboToPhut.SelectedItem.Value + ":00";
                            worksheet.Cells[5, 1].Value = "Từ ngày:" + txtDate.SelectedDate.ToString("dd/MM/yyyy") + " Đến ngày: " + txtoday.SelectedDate.ToString("dd/MM/yyyy");
                            string depName = "";
                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    if (depName != _dr["DepName"].ToString())
                                    {
                                        depName = _dr["DepName"].ToString();
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 1].Value = _dr["DepName"].ToString();
                                        // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
                                        for (int i = 0; i <= 13; i++)
                                        {
                                            var cell = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i];
                                            var border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
                                            var fill = cell.Style.Fill;
                                           //fill.PatternType = ExcelFillStyle.Solid;
                                            border.Left.Style = border.Right.Style = border.Bottom.Style = ExcelBorderStyle.Thin;
                                        }
                                        _irow++;
                                    }

                                    if (manvChange != _dr["EmployeeCode"].ToString())
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Value = countMaNV;
                                        manvChange = _dr["EmployeeCode"].ToString();
                                        countMaNV++;
                                    }
                                    else
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Value = "";
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 3].Value = _dr["EmployeeName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Value = _dr["IDCard"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].Value = _dr["EmployeeCode"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = _dr["PosName"].ToString();
                                    if (_dr["AppliedDate"] != null && _dr["AppliedDate"].ToString() != "")
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = Convert.ToDateTime(_dr["AppliedDate"].ToString());
                                    }
                                    else
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = _dr["AppliedDate"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value = _dr["DepName"].ToString();
                                    if (_dr["ngay"] != null && _dr["ngay"].ToString() != "")
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 9].Value = Convert.ToDateTime(_dr["ngay"].ToString());
                                    }
                                    TimeSpan giovao,giora;
                                    if (_dr["tgQuetDen"] != null && _dr["tgQuetDen"].ToString() != "")
                                    {
                                        TimeSpan.TryParse(_dr["tgQuetDen"].ToString(), out giovao);
                                        if (giovao != null || giovao.ToString() != "")
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 10].Value = giovao;
                                        }
                                        else
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 10].Value = _dr["tgQuetDen"].ToString();
                                        }
                                    }
                                    if (_dr["tgQuetVe"] != null && _dr["tgQuetVe"].ToString() != "")
                                    {
                                        TimeSpan.TryParse(_dr["tgQuetVe"].ToString(), out giora);
                                        if (giora != null || giora.ToString() != "")
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 11].Value = giora;
                                        }
                                        else
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 11].Value = _dr["tgQuetVe"].ToString();
                                        }
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 12].Value = _dr["ten"];

                                    for (int i = 0; i <= 13; i++)
                                    {
                                        var cells = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol];
                                        var borders = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
                                        var borderschil = worksheet.Cells[iStartRow + _irow + 1, iStartCol + _indexcol + i].Style.Border;
                                        if ((iStartCol + _indexcol + i) < 2 || (iStartCol + _indexcol + i) > 3)
                                        {
                                            borders.Left.Style = borders.Right.Style = ExcelBorderStyle.Thin;

                                            borderschil.Bottom.Style = borderschil.Left.Style = borderschil.Right.Style = ExcelBorderStyle.Thin;
                                            borderschil.Top.Style = ExcelBorderStyle.Dotted;
                                        }
                                        else
                                        {
                                            borderschil.Bottom.Style = ExcelBorderStyle.Thin;
                                            borderschil.Top.Style = ExcelBorderStyle.Dotted;
                                        }
                                    }
                                    _irow++;
                                    _index++;
                                }
                                worksheet.View.PageLayoutView = false;
                                //  worksheet.Cells.AutoFitColumns();
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
                    //  Tool.message_HRM("Không có dữ liệu");
                }
            }
            catch (Exception)
            {
            }
        }
        protected void sto1_SubmitData(object sender, StoreSubmitDataEventArgs e)
        {
            ExportExcel4extGridOnSubmitData(e.Xml);
        }
        private string GetTrangThai(DataRow dr, int type = 1)
        {
            return Core.Controller.QuetThe.Helper.GetTrangThai(dr);
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