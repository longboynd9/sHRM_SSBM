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
    public partial class ReportNhanVienNghiPhepNam : BackEndPageBase
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
            var dt = new DataTable();
            dt = logic.GetReportThongKePhepNam(DepID);
            var dt2 = (from table in dt.AsEnumerable()
                       group new { table } by new
                       {
                           EmployeeID = table["EmployeeID"].ToString(),
                           PosName = table["PosName"].ToString(),
                           Birthday = (table["Birthday"] != null && table["Birthday"].ToString() != "") ? ((DateTime)table["Birthday"]).ToString("dd/MM/yyyy") : "",
                           CardID = table["CardID"].ToString(),
                           IDCard = table["IDCard"].ToString(),
                           AppliedDate = (table["AppliedDate"] != null && table["AppliedDate"].ToString() != "") ? ((DateTime)table["AppliedDate"]).ToString("dd/MM/yyyy") : "",
                           LeftDate = (table["LeftDate"] != null && table["LeftDate"].ToString() != "") ? ((DateTime)table["LeftDate"]).ToString("dd/MM/yyyy") : "",
                           DepName = table["DepName"].ToString(),
                           AnnualLeave = (double)table["AnnualLeave"],
                           EmployeeName = table["EmployeeName"].ToString(),
                       } into kq
                       select new
                       {
                           kq.Key.EmployeeID,
                           kq.Key.PosName,
                           kq.Key.Birthday,
                           kq.Key.CardID,
                           kq.Key.IDCard,
                           kq.Key.AppliedDate,
                           kq.Key.LeftDate,
                           kq.Key.DepName,
                           kq.Key.AnnualLeave,
                           EmployeeName = kq.Key.EmployeeName,
                           t1 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 1).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t2 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 2).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t3 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 3).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t4 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 4).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t5 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 5).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t6 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 6).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t7 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 7).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t8 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 8).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t9 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 9).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t10 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 10).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t11 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 11).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           t12 = kq.Where(p => p.table.Field<DateTime>("ngay").Month == 12).Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           sophepdasudung = kq.Sum(p => p.table.Field<double>("hourLeave")).ToString("0.00"),
                           sophepconlai = kq.Key.AnnualLeave.ToString("0.00"),
                           tongsophep = (kq.Key.AnnualLeave + kq.Sum(p => p.table.Field<double>("hourLeave"))).ToString("0.00")
                       }).AsEnumerable();
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("EmployeeID");
            dtResult.Columns.Add("PosName");
            dtResult.Columns.Add("Birthday");
            dtResult.Columns.Add("CardID");
            dtResult.Columns.Add("IDCard");
            dtResult.Columns.Add("AppliedDate");
            dtResult.Columns.Add("LeftDate");
            dtResult.Columns.Add("DepName");
            dtResult.Columns.Add("AnnualLeave");
            dtResult.Columns.Add("EmployeeName");
            dtResult.Columns.Add("t1");
            dtResult.Columns.Add("t2");
            dtResult.Columns.Add("t3");
            dtResult.Columns.Add("t4");
            dtResult.Columns.Add("t5");
            dtResult.Columns.Add("t6");
            dtResult.Columns.Add("t7");
            dtResult.Columns.Add("t8");
            dtResult.Columns.Add("t9");
            dtResult.Columns.Add("t10");
            dtResult.Columns.Add("t11");
            dtResult.Columns.Add("t12");
            dtResult.Columns.Add("sophepdasudung");
            dtResult.Columns.Add("sophepconlai");
            dtResult.Columns.Add("tongsophep");
            foreach (var item in dt2.AsEnumerable())
            {
                DataRow newRow = dtResult.NewRow();
                newRow["EmployeeID"] = item.EmployeeID;
                newRow["PosName"]= item.PosName;
                newRow["Birthday"]= item.Birthday;
                newRow["CardID"]= item.CardID;
                newRow["IDCard"]= item.IDCard;
                newRow["AppliedDate"]= item.AppliedDate;
                newRow["LeftDate"]= item.LeftDate;
                newRow["DepName"]= item.DepName;
                newRow["AnnualLeave"]= item.AnnualLeave;
                newRow["EmployeeName"]= item.EmployeeID;
                newRow["t1"]= item.t1;
                newRow["t2"]= item.t2;
                newRow["t3"]= item.t3;
                newRow["t4"]= item.t4;
                newRow["t5"]= item.t5;
                newRow["t6"]= item.t6;
                newRow["t7"]= item.t7;
                newRow["t8"]= item.t8;
                newRow["t9"]= item.t9;
                newRow["t10"]= item.t10;
                newRow["t11"]= item.t11;
                newRow["t12"]= item.t12;
                newRow["sophepdasudung"]= item.sophepdasudung;
                newRow["sophepconlai"]= item.sophepconlai;
                newRow["tongsophep"]= item.tongsophep;
                dtResult.Rows.Add(newRow);
            }
            Store1.DataSource = dtResult;
            Store1.DataBind();
            AspNetCache.SetCache(string.Format("ReportThongKeNghiPhepNam_{0}_{1}_{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year), dtResult);
        }
        protected void btnExcel_DirectClick(object sender, DirectEventArgs e)
        {
            var tbl = (DataTable)AspNetCache.GetCache(string.Format("ReportThongKeNghiPhepNam_{0}_{1}_{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
            if (tbl != null)
            {
                xuatexcel(tbl, "TempNhanVienNghiPhepNam.xlsx", 7, 1);
            }
        }
        public void addTongPhep(tblEmployee nv, int songayphep1nam)
        {
            DateTime tgtinhpheptu = DateTime.Now;
            DateTime tgtinhphepden = DateTime.Now;
            if (nv.LeftDate != null && nv.LeftDate.ToString() != "")
            {
                tgtinhphepden = nv.LeftDate.Value;
            }
            else
            {
                tgtinhphepden = new DateTime(DateTime.Now.Year, 12, 31);
            }
            if (nv.AppliedDate != null && nv.AppliedDate.ToString() != "")
            {
                tgtinhpheptu = nv.AppliedDate.Value;
            }
            else
            {
                tgtinhpheptu = new DateTime(DateTime.Now.Year, 1, 1);
            }
            double songay = 0;
            songay += (DateTime.DaysInMonth(tgtinhpheptu.Year, tgtinhpheptu.Month) - tgtinhpheptu.Day - 1) / DateTime.DaysInMonth(tgtinhpheptu.Year, tgtinhpheptu.Month);
            songay += tgtinhphepden.Month - tgtinhpheptu.Month - 1;
            songay += tgtinhphepden.Day / DateTime.DaysInMonth(tgtinhpheptu.Year, tgtinhpheptu.Month);
            nv.AnnualLeave = songayphep1nam / 12 * songay;
        }
        public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        {
            try
            {
                FileInfo fileTemp = null;
                int _irow = 0;
                string EXCEL_FILE = strFileExcel;
                string strTemplateFilePath = ResolveUrl("~/") + "Temp/" + EXCEL_FILE;
                string strAttach = "Bao_Cao_Phep_Nam_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx";
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
                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    worksheet.Cells[iStartRow + _irow, iStartCol].Value = _index;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 1].Value = _dr["EmployeeName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 2].Value = _dr["Birthday"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 3].Value = _dr["IDCard"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 4].Value = _dr["CardID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 5].Value = _dr["EmployeeID"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 6].Value = _dr["DepName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 7].Value = _dr["PosName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 8].Value = _dr["AppliedDate"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 9].Value = _dr["LeftDate"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 10].Value = _dr["tongsophep"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = _dr["t1"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 12].Value = _dr["t2"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 13].Value = _dr["t3"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 14].Value = _dr["t4"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 15].Value = _dr["t5"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 16].Value = _dr["t6"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 17].Value = _dr["t7"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 18].Value = _dr["t8"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 19].Value = _dr["t9"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 20].Value = _dr["t10"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 21].Value = _dr["t11"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 22].Value = _dr["t12"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 23].Value = _dr["sophepdasudung"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + 24].Value = _dr["sophepconlai"].ToString();
                                    for (int i = 0; i <= 24; i++)
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