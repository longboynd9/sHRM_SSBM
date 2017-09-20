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
    public partial class ReportNhanVienVangMat : BackEndPageBase
    {
        static Int32 total = 0;
        global::iHRM.Core.Controller.Report.GetData controller = new global::iHRM.Core.Controller.Report.GetData();
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
                                        new object[]{100, "Tất cả"},
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.NghiPhepNam, "Nghỉ phép năm"},
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.KetHon, "Nghỉ kết hôn"}, 
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.MaChay, "Nghỉ ma chay"},
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.CheDo, "Nghỉ chế độ"},

                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.KhongLuong, "Nghỉ không lương"},
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.Om, "Nghỉ ốm"},
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.Khac, "Nghỉ khác"},
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.VangMat, "Nghỉ vắng mặt không lương"},
                                        new object[]{(int)iHRM.Common.Code.Enums.eLyDoNghi.ThaiSan, "Nghỉ thai sản"}
                                   };
                store.DataBind();

            }
            CultureInfo ci = new CultureInfo("en-US");
        }
        //public enum eLyDoNghi
        //{
        //    NghiPhepNam = 4,
        //    KetHon = 5,
        //    MaChay = 6,
        //    CheDo = 8,

        //    KhongLuong = 11,
        //    Om = 12,
        //    Khac = 13,
        //    VangMat = 14,
        //    ThaiSan = 15
        //}
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
                int fieldSearch = Convert.ToInt16(SelectBoxSearch.Value);
                data = controller.GetReportNhanVienVangMat(day, todates, fieldSearch, DepID);
                Store1.DataSource = data;
                Store1.DataBind();
            }
            AspNetCache.SetCache("ReportNhanVienVangMat_" + day + "_" + todates, data);
        }
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            DateTime day = txtDate.SelectedDate;
            DateTime todates = todate.SelectedDate;
            DataTable tbl = (DataTable)AspNetCache.GetCache("ReportNhanVienVangMat_" + day + "_" + todates);
            if (tbl != null)
            {
                xuatexcel(tbl, "TempNhanVienVangMat.xlsx", 7, 1);
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
                string strAttach = "Bao_Cao_NV_vang_mat_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx";
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

                                //<ext:Column Header="Mã NV" DataIndex="EmployeeID" Width="70"></ext:Column>
                                //<ext:Column ColumnID="EmployeeName" Header="Tên NV" DataIndex="EmployeeName" Width="150" Align="Left" />
                                //<ext:DateColumn Header="Ngày sinh" DataIndex="Birthday" Width="70" Format="dd/MM/yyyy"></ext:DateColumn>
                                //<ext:Column Header="Số CMND" DataIndex="IDCard" Width="70"></ext:Column>
                                //<ext:Column Header="Mã thẻ chấm công" DataIndex="CardID" Width="100"></ext:Column>
                                //<ext:Column Header="#Report_NgayCongTangCaThang.chucvu" DataIndex="PosName" Width="150"></ext:Column>
                                //<ext:Column Header="Phòng Ban" DataIndex="DepName" Width="200"></ext:Column>
                                //<ext:DateColumn Header="Ngày" DataIndex="ngay" Width="100" Format="dd/MM/yyyy"></ext:DateColumn>
                                //<ext:Column Header="Loại nghỉ" DataIndex="loainghi" Width="100"></ext:Column>
                                //<ext:Column Header="Số ngày" DataIndex="songay" Width="50"></ext:Column>
                                //<ext:Column Header="Ghi chú" DataIndex="ghiChu" Width="150"></ext:Column>
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    worksheet.Cells[iStartRow + _irow, iStartCol].Value = _index;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 3].Value = _dr["EmployeeName"].ToString();
                                    try
                                    {
                                        string AppliedDate = Convert.ToDateTime(_dr["Birthday"].ToString()).ToString("dd/MM/yyyy");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 4].Value = AppliedDate;
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 4].Value = _dr["Birthday"].ToString();
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 5].Value = _dr["IDCard"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 6].Value = _dr["CardID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 7].Value = _dr["EmployeeID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 8].Value = _dr["DepName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 9].Value = _dr["PosName"].ToString();
                                    try
                                    {
                                        string AppliedDate = Convert.ToDateTime(_dr["ngay"].ToString()).ToString("dd/MM/yyyy");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 10].Value = AppliedDate;
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 10].Value = _dr["ngay"].ToString();
                                    }

                                    worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = _dr["lydo"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 12].Value = _dr["songay"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 13].Value = _dr["ghiChu"].ToString();
                                    for (int i = 0; i <= 13; i++)
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