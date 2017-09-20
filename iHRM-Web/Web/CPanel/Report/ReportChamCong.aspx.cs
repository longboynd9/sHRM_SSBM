using Ext.Net;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Code;
using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHRM.Core.Business.Logic;
using ePowerPortal_Core.Web;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;
namespace iHRM.WebPC.Cpanel.Report
{
    public partial class ReportChamCong : BackEndPageBase
    {

        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        iHRM.Core.Controller.Report.GetData controller = new iHRM.Core.Controller.Report.GetData();
        static Int32 total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
            if (!IsPostBack && !X.IsAjaxRequest)
            {
                hdhidde.Value = "";
                Lng.Web_Language.Lng_SetControlTexts(this);
                txtDate.SelectedValue = DateTime.Now;
                txttodate.SelectedValue = DateTime.Now;
                Lng.Web_Language.Lng_SetControlTexts(this);
                LoadData();
            }
        }
        protected void Search(object sender, Ext.Net.DirectEventArgs e)
        {
            DataTable tbl = LoadDataChamCong();
            if (tbl.Rows.Count > 0)
            {
                Store1.DataSource = tbl;
                Store1.DataBind();
            }
            else
            {
                Tools.message(Lng.Report_ReportChamCong.msg_1);
            }
        }
        protected void btnexcel(object sender, Ext.Net.DirectEventArgs e)
        {
            DataTable tbl = (DataTable)AspNetCache.GetCache("reportChamCongHangThang");
            if (tbl != null)
            {
                xuatexcel(tbl, "TempReportChamCongThang.xlsx", 1, 1);
            }
            else
            {
                DataTable data = LoadDataChamCong();
                if (data.Rows.Count > 0)
                {
                    AspNetCache.SetCache("reportChamCongHangThang", data);
                    xuatexcel(tbl, "TempReportChamCongThang.xlsx", 1, 1);
                }
                else
                {
                    Tools.message(Lng.Report_ReportChamCong.msg_1);
                }
            }
        }
        public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        {
            try
            {
                FileInfo fileTemp = null;
                int _irow = 4;
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
                            string a = "Từ ngày:" + txtDate.SelectedDate.ToString("dd/MM/yyyy");

                            worksheet.Cells[2, 2].Value = "Từ ngày:" + txtDate.SelectedDate.ToString("dd/MM/yyyy") + "Đến ngày:" + txttodate.SelectedDate.ToString("dd/MM/yyyy");
                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {

                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Value = _index;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 1].Value = _dr["EmployeeID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 2].Value = _dr["tenNV"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 3].Value = _dr["DepName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].Value = _dr["NgayCong"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = _dr["NghiLe"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = _dr["NghiPhepNam"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Value = _dr["NghiCoLuong"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value = _dr["NghiKhongLuong"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 9].Value = _dr["TangCa"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 10].Value = _dr["ChuNhat"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 10].Value = _dr["TangCaLe"];

                                    var cell = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol];
                                    var border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 1].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 2].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 3].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].AutoFitColumns();
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 9].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 10].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
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

        private DataTable LoadDataChamCong()
        {
            DataTable tbl = new DataTable();
            if (txtDate.SelectedDate != null && txttodate.SelectedDate != null)
            {
                string EmpID = null, DepID = null;
                if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                    DepID = hdhidde.Value.ToString();
                if (txtSearch.Text != "")
                    EmpID = txtSearch.Text;
                tbl = controller.getDataReportChamCong(EmpID, DepID, txtDate.SelectedDate, txttodate.SelectedDate);
            }
            else
                Tools.message(Lng.Report_ReportChamCong.msg_2);
            return tbl;
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
        //protected void btnFindMaVN_DirectClick(object sender, DirectEventArgs e)
        //{
        //    var dr = logicca.checkNV(txtNhanVien.Text);
        //    if (dr == null)
        //    {
        //        txtNhanVien.IndicatorIcon = Icon.Error;
        //        txtNhanVien.IndicatorTip = "Không tìm thấy thông tin của nhân viên";
        //        txtNhanVien2.Text = "";
        //    }
        //    else
        //    {
        //        txtNhanVien.IndicatorIcon = Icon.Tick;
        //        txtNhanVien.IndicatorTip = "";
        //        txtNhanVien2.Text = string.Format("{0} - {1:dd/MM/yyyy}", DbHelper.DrGet(dr, "EmployeeName"), DbHelper.DrGet(dr, "Birthday"));
        //    }
        //}
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
        #endregion
    }
}