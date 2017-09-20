using ePowerPortal_Core.Web;
using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Classes;
using iHRM.WebPC.Code; 
using iHRM.Common.Code;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Cpanel.Report
{
    public partial class NgayCongTangCaThang : BackEndPageBase
    {
        static Int32 total = 0;
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        iHRM.Core.Controller.Report.GetData controller = new iHRM.Core.Controller.Report.GetData();
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
            }
            CultureInfo ci = new CultureInfo("en-US");

        }
        protected void sto1_SubmitData(object sender, StoreSubmitDataEventArgs e)
        {
            ExportExcel4extGridOnSubmitData(e.Xml);
        }

        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            Store1.DataSource = controller.GetDataReportMonthExcel(txtSearch.Text, DepID, txtDate.SelectedDate, todate.SelectedDate);
            Store1.DataBind();
        }
        protected void Search(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            Store1.DataSource = controller.GetDataReportMonthExcel(txtSearch.Text, DepID, txtDate.SelectedDate, todate.SelectedDate );
            Store1.DataBind();
        }
        
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DataTable tbl = controller.GetDataReportMonthExcel(txtSearch.Text, DepID, txtDate.SelectedDate, todate.SelectedDate);
            if (tbl != null)
            {
                var dt2 = ExcelExportHelper.CreateGroupInDT(tbl, "DepName", "STT");
                xuatexcel(dt2, "BaoCaoThang.xlsx", 7, 1);
            }
            else
            {
                Tools.message("Không có dữ liệu!");
            }
        }
        public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        {
            try
            {
                string tenPB = "";
                FileInfo fileTemp = null;
                int _irow = 0;
                int _indexcol = 0;
                string EXCEL_FILE = strFileExcel;
                string strTemplateFilePath = ResolveUrl("~/") + "Temp/" + EXCEL_FILE;
                string strAttach = "Bao_Cao_Cham_cong_Hang_thang" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx";
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
                            //  worksheet.Cells[7, 2].Value = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                            //  worksheet.Cells[8, 2].Value = Convert.ToDateTime(dtangay.Value).Day + "/" + Convert.ToDateTime(dtangay.Value).Month + "/" + Convert.ToDateTime(dtangay.Value).Year + "  " + cboFromHour.SelectedItem.Value + ":" + cboFromPhut.SelectedItem.Value + ":00"; ;
                            //  worksheet.Cells[9, 2].Value = Convert.ToDateTime(dtToDate.Value).Day + "/" + Convert.ToDateTime(dtToDate.Value).Month + "/" + Convert.ToDateTime(dtToDate.Value).Year + "  " + cbotoHour.SelectedItem.Value + ":" + cboToPhut.SelectedItem.Value + ":00";
                            worksheet.Cells[3, 1].Value = "Từ ngày:" + txtDate.SelectedDate.ToString("dd/MM/yyyy") + " Đến ngày:" + todate.SelectedDate.ToString("dd/MM/yyyy");
                            worksheet.Cells["Z5"].Value = "Tháng " + txtDate.SelectedDate.Month;
                            worksheet.Cells["J5"].Value = "Tháng " + todate.SelectedDate.Month;
                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    if (_dr["DepName"].ToString() != "")
                                    {
                                        tenPB = _dr["DepName"].ToString();
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 1].Value = _dr["DepName"].ToString();
                                        // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
                                        for (int i = 0; i <= 48; i++)
                                        {
                                            var cell = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i];
                                            var border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
                                            var fill = cell.Style.Fill;
                                           // fill.PatternType = ExcelFillStyle.Solid;
                                           // fill.BackgroundColor.SetColor(System.Drawing.Color.YellowGreen);
                                          //  fill.BackgroundColor.SetColor(
                                            //border.Left.Style = border.Right.Style = border.Bottom.Style = ExcelBorderStyle.Thin;
                                        }
                                        _irow++;
                                    }
                                    else
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Value = _index;
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 3].Value = _dr["tenNV"].ToString();
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].Value = _dr["EmployeeID"].ToString();
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = _dr["PosName"].ToString();
                                        try
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = Convert.ToDateTime(_dr["AppliedDate"]);
                                        }
                                        catch (Exception)
                                        {
                                             worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = _dr["AppliedDate"].ToString();
                                        }
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Value = _dr["IDCard"].ToString();
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value = tenPB;
                                        worksheet.Cells[iStartRow + _irow + 1, iStartCol + _indexcol + 8].Value = tenPB;
                                        // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
                                        for (int i = 1; i <= 31; i++)
                                        {
                                            try
                                            {
                                                double hNgayCong = Convert.ToDouble(_dr["D" + i].ToString());
                                                worksheet.Cells[iStartRow + _irow, (iStartCol + _indexcol + 8) + i].Value = hNgayCong;
                                            }
                                            catch (Exception)
                                            {
                                                worksheet.Cells[iStartRow + _irow, (iStartCol + _indexcol + 8) + i].Value = _dr["D" + i].ToString();
                                            }

                                            try
                                            {
                                                double hTangCa = Convert.ToDouble(_dr["T" + i].ToString());
                                                worksheet.Cells[iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i].Value = hTangCa;
                                            }
                                            catch (Exception)
                                            {
                                                worksheet.Cells[iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i].Value = _dr["T" + i].ToString();
                                            }
                                            //worksheet.Cells[iStartRow + _irow, (iStartCol + _indexcol + 8) + i].Value = _dr["D" + i].ToString();
                                            //worksheet.Cells[iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i].Value = _dr["T" + i].ToString();
                                        }
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 40].Value = Convert.ToDouble(_dr["DChuNhat"].ToString() != "" ? _dr["DChuNhat"].ToString() : "0");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 41].Value = Convert.ToDouble(_dr["NghiLe"].ToString() != "" ? _dr["NghiLe"].ToString() : "0");
                                        // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 41].Value = _dr["DChuNhat"].ToString();
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 42].Value = Convert.ToDouble(_dr["NghiKhongPhep"].ToString() != "" ? _dr["NghiKhongPhep"].ToString() : "0");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 43].Value = Convert.ToDouble(_dr["NghiPhepNam"].ToString() != "" ? _dr["NghiPhepNam"].ToString() : "0");
                                        // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 44].Value = _dr["NghiOm"];
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 44].Value = Convert.ToDouble(_dr["NghiKhongLuongVM"].ToString() != "" ? _dr["NghiKhongLuongVM"].ToString() : "0");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 45].Value = Convert.ToDouble(_dr["NghiThaiSan"].ToString() != "" ? _dr["NghiThaiSan"].ToString() : "0");

                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 46].Value = Convert.ToDouble(_dr["NghiCheDo"].ToString() != "" ? _dr["NghiCheDo"].ToString() : "0");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 47].Value = Convert.ToDouble(_dr["NghiKhac"].ToString() != "" ? _dr["NghiKhac"].ToString() : "0");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 48].Value = Convert.ToDouble(_dr["SoNgayCong"].ToString() != "" ? _dr["SoNgayCong"].ToString() : "0");
                                        worksheet.Cells[iStartRow + _irow + 1, iStartCol + _indexcol + 48].Value = Convert.ToDouble(_dr["TangCa"].ToString() != "" ? _dr["TangCa"].ToString() : "0");
                                        for (int i = 0; i <= 49; i++)
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
                                        _irow = _irow + 2;
                                        _index++;
                                    }
                                }
                                worksheet.View.PageLayoutView = false;
                                worksheet.View.PageBreakView = true;
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
                    List<tblRef_Department> child = (from c in db.tblRef_Departments where c.DepParent == f.DepID select c).ToList<tblRef_Department>();
                    if (child != null)
                    {
                        if (child.Count > 0)
                        {
                            string list = "";
                            foreach (tblRef_Department item in child)
                            {
                                list += item.DepID + ",";
                            }
                            hdhidde.SetValue(list);
                        }
                        else
                        {
                            hdhidde.SetValue(f.DepID);
                        }
                    }
                    else
                    {
                        hdhidde.SetValue(f.DepID);
                    }
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