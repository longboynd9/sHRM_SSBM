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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ePowerPortal_Core.Web;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;

namespace iHRM.WebPC.Cpanel.Employee
{
    public partial class Search : BackEndPageBase
    {
        global::iHRM.Core.Business.DbObject.dcDatabaseDataContext db;
        global::iHRM.Core.Business.Logic.Employee.Emp logic = new global::iHRM.Core.Business.Logic.Employee.Emp();

        static Int32 total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);

            if (!IsPostBack && !X.IsAjaxRequest)
            {
                LoadData();
                //  LoadNextData();
                Lng.Web_Language.Lng_SetControlTexts(this);
            }
        }
        private void LoadNextData()
        {


            //  stoEmpDep.DataSource = db.tblRef_Departments;
            // stoEmpDep.DataBind();


        }
        protected void grd_OnCommand(object sender, DirectEventArgs e)
        {
            try
            {
                string commandId = e.ExtraParams["id"];
                string commandName = e.ExtraParams["command"];

                switch (commandName)
                {
                    case "Delete":
                        DeleteRecord(commandId);
                        X.AddScript("Store1.remove(GridPanel1.selModel.getSelected());");
                        break;
                }
            }
            catch
            {
                if (globall.indebug)
                    throw;
            }
        }
        /// <summary>
        /// Row double click danh sách nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SwitchToUserDetail(object sender, DirectEventArgs e)
        {
            string commandId = e.ExtraParams["id"];
            X.Js.Call("OpenEditor", commandId, Lng.Employee_Search.msg_js + commandId);
        }
        private void DeleteRecord(string commandId)
        {
            var db = new global::iHRM.Core.Business.DbObject.dcDatabaseDataContext(global::iHRM.Core.Business.Provider.ConnectionString);
            var emp = db.tblEmployees.SingleOrDefault(i => i.EmployeeID == commandId);
            if (emp != null)
            {
                db.tblEmployees.DeleteOnSubmit(emp);
                db.SubmitChanges();
            }
        }

        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            logic.VirtualPaging.PageSize = e.Limit;
            logic.VirtualPaging.Page = (int)(e.Start / e.Limit) + 1;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "" && hdhidde.Value.ToString() != "-")
            {
                Store1.DataSource = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text), new System.Data.SqlClient.SqlParameter("phongban", hdhidde.Value));
            }
               
            else
                Store1.DataSource = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text));
            Store1.DataBind();

            e.Total = logic.VirtualPaging.RecordCount;
            (Store1.Proxy[0] as PageProxy).Total = logic.VirtualPaging.RecordCount;
            total = e.Total;
        }
        protected void sto1_SubmitData(object sender, StoreSubmitDataEventArgs e)
        {
            ExportExcel4extGridOnSubmitData(e.Xml);
        }
        protected void SearchNhanVien(object sender, DirectEventArgs e)
        {
            //DataTable tbl = (DataTable)AspNetCache.GetCache("reportDSNhanVien");
            //if (tbl != null)
            //{
            //    xuatexcel(tbl, "TempNhanVien.xlsx", 1, 1);

            //}
            //else
            //{
            DataTable tbl = new DataTable();
                logic.VirtualPaging.PageSize = total;
                logic.VirtualPaging.Page = 1;
            if (hdhidde.Value != null && hdhidde.Value.ToString() != "" && hdhidde.Value.ToString() != "-")
            {
                tbl = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text), new System.Data.SqlClient.SqlParameter("phongban", hdhidde.Value));
            }

            else
                tbl = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text));
           

          //  tbl = logic.GetAll(new System.Data.SqlClient.SqlParameter("SearchKey", txtSearchKey.Text));
                AspNetCache.SetCache("reportDSNhanVien", tbl);
                xuatexcel(tbl, "TempNhanVien.xlsx", 1, 1);
            //}


        }

        public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        {
            try
            {
                FileInfo fileTemp = null;
                int _irow = 1;
                int _indexcol = 0;
                string EXCEL_FILE = strFileExcel;
                string strTemplateFilePath = ResolveUrl("~/") + "Temp/" + EXCEL_FILE;
                string strAttach = "Danh_Nhan_vien_" + LoginHelper.dbUsed +"_"+ DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".xlsx";
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
                            string donvi = "";


                            donvi = "";
                            //  worksheet.Cells[7, 2].Value = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                            //  worksheet.Cells[8, 2].Value = Convert.ToDateTime(dtangay.Value).Day + "/" + Convert.ToDateTime(dtangay.Value).Month + "/" + Convert.ToDateTime(dtangay.Value).Year + "  " + cboFromHour.SelectedItem.Value + ":" + cboFromPhut.SelectedItem.Value + ":00"; ;
                            //  worksheet.Cells[9, 2].Value = Convert.ToDateTime(dtToDate.Value).Day + "/" + Convert.ToDateTime(dtToDate.Value).Month + "/" + Convert.ToDateTime(dtToDate.Value).Year + "  " + cbotoHour.SelectedItem.Value + ":" + cboToPhut.SelectedItem.Value + ":00";

                            try
                            {
                                int _index = 1;
                                foreach (DataRow _dr in dsData.Rows)
                                {
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol].Value = _index;
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 1].Value = _dr["EmployeeCode"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 2].Value = _dr["FirstName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 3].Value = _dr["LastName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].Value = _dr["EmployeeName"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = _dr["BankAccount"].ToString();//biến số
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Value = _dr["DepName"].ToString();//bat dau hanh trinh

                                    // worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Value = TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Value = _dr["CardID"].ToString();//thoi gian lai xe
                                    if (!String.IsNullOrEmpty(_dr["AppliedDate"].ToString()))
                                    {
                                        try
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value = Convert.ToDateTime(_dr["AppliedDate"].ToString());
                                        }
                                        catch (Exception)
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 8].Value =_dr["AppliedDate"];// nhien lieu
                                        }
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 9].Value = _dr["IDCard"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 10].Value = _dr["IssuePlace"].ToString();
                                    if (!String.IsNullOrEmpty(_dr["IssueDate"].ToString()))
                                    {
                                        try
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 11].Value = Convert.ToDateTime(_dr["IssueDate"].ToString());
                                        }
                                        catch (Exception)
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 11].Value = _dr["IssueDate"];// nhien lieu
                                        }
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 12].Value = _dr["PermanentAddress"].ToString();
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 13].Value = _dr["SexID"];// nhien lieu
                                    if (!String.IsNullOrEmpty(_dr["Birthday"].ToString()))
                                    {
                                        try
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 14].Value = Convert.ToDateTime(_dr["Birthday"].ToString());

                                        }
                                        catch (Exception)
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 14].Value =_dr["Birthday"];// nhien lieu
                                        }
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 15].Value = _dr["Phone"];// nhien lieu
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 16].Value = _dr["NativeCountry"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 17].Value = _dr["Address"];// nhien lieu
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 18].Value = _dr["NationalityName"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 19].Value = _dr["BasicSalary"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 20].Value = _dr["RegularAllowance"];
                                    if (!String.IsNullOrEmpty(_dr["leftdate"].ToString()))
                                    {
                                        try
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 21].Value = Convert.ToDateTime(_dr["leftdate"].ToString());
                                        }
                                        catch (Exception  e)
                                        {
                                            worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 21].Value = _dr["leftdate"];// nhien lieu
                                        }
                                    }
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 22].Value = _dr["gName"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 23].Value = _dr["AnnualLeave"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 24].Value = _dr["PosName"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 25].Value = _dr["LeftTypeName"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 26].Value = _dr["BankNameAcount"];
                                    worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 27].Value = _dr["BankName"];
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
                                    //worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 4].AutoFitColumns();
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 5].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 6].Style.Border;
                                    border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                                    border = worksheet.Cells[iStartRow + _irow, iStartCol + _indexcol + 7].Style.Border;
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