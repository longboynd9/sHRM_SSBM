using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Code;
using OfficeOpenXml;

namespace iHRM.WebPC.Cpanel.Report
{
    public partial class reportchunhat : BackEndPageBase
    {
        static Int32 total = 0;
        iHRM.Core.Business.Logic.Report.BaoCao logic = new iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.WebPC.Code.Tools Tools = new iHRM.WebPC.Code.Tools();
        iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
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
        protected void Search(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day;
            DateTime todates;
            DataTable data = new DataTable();
            if (txtDate.SelectedDate != null && todate.SelectedDate != null)
            {
                day = txtDate.SelectedDate;
                todates = todate.SelectedDate;
                data = logic.GetReportChuhat(day, todates, txtma.Text != "" ? txtma.Text : null, DepID);
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        Store1.DataSource = data;
                        Store1.DataBind();
                    }
                }

            }
        }
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day;
            DateTime todates;
            DataTable data = new DataTable();
            if (txtDate.SelectedDate != null && todate.SelectedDate != null)
            {
                day = txtDate.SelectedDate;
                todates = todate.SelectedDate;
                data = logic.GetReportChuhat(day, todates, txtma.Text != "" ? txtma.Text : null, DepID);
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        xuatexcel(data, "DanhsachChuNhat.xlsx", 7, 1);
                    }
                }

                else
                {
                    Tools.message("Hết thời gian lưu cache. Hãy thực hiện lại thao tác tìm kiếm");
                }
            }


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
                string strAttach = "Bao_Cao_nhan_vien_OT" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx";
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
                            worksheet.Cells[3, 1].Value = "Từ ngày:" + txtDate.SelectedDate.ToString("dd/MM/yyyy") + " Đến ngày:" + todate.SelectedDate.ToString("dd/MM/yyyy");
                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Value = _index;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 3].Value = _dr["EmployeeID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].Value = _dr["EmployeeName"].ToString();
                                    try
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = _dr["Birthday"] == DBNull.Value ? "" : _dr["Birthday"].ToString();
                                    }
                                    catch
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = "";

                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = _dr["IDCard"].ToString();
                                    try
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Value = _dr["CardID"].ToString();
                                    }
                                    catch (Exception)
                                    {

                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Value = "";
                                    }

                                    try
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value = _dr["PosName"] == DBNull.Value ? "" : _dr["PosName"].ToString();

                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value = "";
                                    }

                                    try
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 9].Value = Convert.ToDateTime(_dr["AppliedDate"]);
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 9].Value = _dr["AppliedDate"].ToString();
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 10].Value = _dr["DepName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 11].Value = _dr["ngay"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 12].Value = Math.Round(Convert.ToDouble(_dr["tong"].ToString()), 2);
                                    try
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 13].Value = _dr["tgQuetDen"] == DBNull.Value ? "" : _dr["tgQuetDen"].ToString();
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 13].Value = "";
                                    }
                                    try
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 14].Value = _dr["tgQuetVe"] == DBNull.Value ? "" : _dr["tgQuetVe"].ToString();
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 14].Value = "";
                                    }
                                    for (int i = 1; i <= 14; i++)
                                    {
                                    }
                                    _irow = _irow + 2;
                                    _index++;
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

        }
        #endregion
    }
}