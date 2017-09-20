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
    public partial class ReportNhanVienDuoi18Tuoi : BackEndPageBase
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
                txtDate.SelectedDate = firstDayOfMonth;
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
        protected void Search(object sender, DirectEventArgs e)
        {
            string DepID = null;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "")
                DepID = hdhidde.Value.ToString();
            DateTime day = txtDate.SelectedDate;
            var data = new DataTable();
            if (day != null)
            {
                data = logic.GetReportNVDuoi18Tuoi(day, DepID);
                Store1.DataSource = data.AsEnumerable().OrderBy(p => p["DepName"]).CopyToDataTable();
                Store1.DataBind();
            }
            AspNetCache.SetCache("Report_NV_Duoi18Tuoi_" + day, data);
        }
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            DateTime day = txtDate.SelectedDate;
            DataTable tbl = (DataTable)AspNetCache.GetCache("Report_NV_Duoi18Tuoi_" + day);
            if (tbl != null)
            {
                //var dt2 = ExcelExportHelper.CreateGroupInDT(tbl, "DepName", "STT");
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
                string strAttach = "Report_NV_Duoi18Tuoi" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx";
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
                            worksheet.Cells[2, 1].Value = "DANH SÁCH NHÂN VIÊN DƯỚI 18 TUỔI";
                            worksheet.Cells[3, 1].Value = "Ngày:" + txtDate.SelectedDate.ToString("dd/MM/yyyy");
                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    worksheet.Cells[iStartRow + _irow, iStartCol].Value = _index;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 3].Value = _dr["EmployeeName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 5].Value = _dr["IDCard"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 6].Value = _dr["CardID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 7].Value = _dr["EmployeeID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 8].Value = _dr["DepName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 9].Value = _dr["PosName"].ToString();
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
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 10].Value = AppliedDate;
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 10].Value = _dr["AppliedDate"].ToString();
                                    }
                                    try
                                    {
                                        string LeftDate = Convert.ToDateTime(_dr["LeftDate"].ToString()).ToString("dd/MM/yyyy");
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = LeftDate;
                                    }
                                    catch (Exception)
                                    {
                                        worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = _dr["LeftDate"].ToString();
                                    }
                                    for (int i = 0; i <= 11; i++)
                                    {
                                        var cell = worksheet.Cells[iStartRow + _irow, iStartCol];
                                        var borders = worksheet.Cells[iStartRow + _irow, iStartCol + i].Style.Border;
                                        borders.Bottom.Style = borders.Left.Style = borders.Right.Style = ExcelBorderStyle.Thin;
                                    }
                                    _index++;
                                    _irow++;
                                }
                                worksheet.View.PageLayoutView = false;
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