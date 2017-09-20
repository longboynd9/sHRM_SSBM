using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.i_Report;
using iHRM.Win.Cls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Report
{
    public partial class rptOT6H : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        public rptOT6H()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            dw_it.OnDoing = (s,ev) => //hàm lấy dữ liệu chạy ngầm
            {
                DateTime day = chonKyLuong1.TuNgay;
                DateTime todates = chonKyLuong1.DenNgay;
                var data = new DataTable();
                if (day != null && todates != null)
                {
                    data = logic.GetReportTangCa6H(day, todates, txtEmpID.Text != "" ? txtEmpID.Text : null, chonPhongBan1.SelectedValue);
                    if (data.Rows.Count > 0)
                    {
                        dw_it.bw.ReportProgress(1, data.AsEnumerable().OrderBy(p => p["DepName"]).CopyToDataTable());
                    }
                    else
                    {
                        dw_it.bw.ReportProgress(-1, "Không có dữ liệu");
                        dw_it.bw.ReportProgress(1, data);
                    }
                }
                
            };
            dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grd.DataSource = data.UserState;
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }
        private string GetTrangThai(DataRow dr, int type = 1)
        {
            return Core.Controller.QuetThe.Helper.GetTrangThai(dr);
        }
        private class TimKiem
        {
            public string text { get; set; }
            public string value { get; set; }
        }
        //public void xuatexcel(DataTable dsData, string strFileExcel, int iStartRow, int iStartCol)
        //{
        //    try
        //    {
        //        FileInfo fileTemp = null;
        //        int _irow = 0;
        //        string EXCEL_FILE = strFileExcel;
        //        string strTemplateFilePath = "Temp\\" + EXCEL_FILE;
        //        string strAttach = "";
        //        string strGioitinh = "";
        //        if (lookupGioiTinh.EditValue.ToString() != "tatca")
        //        {
        //            strGioitinh = lookupGioiTinh.EditValue.ToString();
        //        }
        //        if (lookupTimKiem.EditValue.ToString() == "nghilam")
        //        {
        //            strAttach = string.Format("Bao_Cao_NV_nghi_lam_{0}_{1}_{2}_{3}.xlsx", strGioitinh, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        //        }
        //        else if (lookupTimKiem.EditValue.ToString() == "vaolam")
        //            strAttach = string.Format("Bao_Cao_NV_vao_lam_{0}_{1}_{2}_{3}.xlsx", strGioitinh, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        //        else
        //            strAttach = string.Format("Bao_Cao_NV_{0}_{1}_{2}_{3}.xlsx", strGioitinh, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        //        fileTemp = new FileInfo(Path.Combine(win_globall.apppath, strTemplateFilePath));
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
        //                    if (lookupTimKiem.EditValue.ToString() == "nghilam")
        //                    {
        //                        worksheet.Cells[2, 1].Value = "DANH SÁCH NHÂN VIÊN NGHỈ LÀM";
        //                    }
        //                    else if (lookupTimKiem.EditValue.ToString() == "vaolam")
        //                    {
        //                        worksheet.Cells[2, 1].Value = "DANH SÁCH NHÂN VIÊN VÀO LÀM";
        //                    }
        //                    else
        //                    {
        //                        worksheet.Cells[2, 1].Value = "DANH SÁCH NHÂN VIÊN";
        //                    }
        //                    worksheet.Cells[3, 1].Value = string.Format("Từ ngày:{0:dd/MM/yyyy} Đến ngày:{1:dd/MM/yyyy}", chonKyLuong1.TuNgay, chonKyLuong1.DenNgay);
        //                    try
        //                    {
        //                        int _index = 1;
        //                        foreach (DataRow _dr in dsData.Rows)
        //                        {
        //                            worksheet.Cells[iStartRow + _irow, iStartCol].Value = _index;
        //                            worksheet.Cells[iStartRow + _irow, iStartCol + 3].Value = _dr["EmployeeName"].ToString();
        //                            worksheet.Cells[iStartRow + _irow, iStartCol + 5].Value = _dr["IDCard"].ToString();
        //                            worksheet.Cells[iStartRow + _irow, iStartCol + 6].Value = _dr["CardID"].ToString();
        //                            worksheet.Cells[iStartRow + _irow, iStartCol + 7].Value = _dr["SexID"].ToString();
        //                            worksheet.Cells[iStartRow + _irow, iStartCol + 8].Value = _dr["EmployeeID"].ToString();
        //                            worksheet.Cells[iStartRow + _irow, iStartCol + 9].Value = _dr["DepName"].ToString();
        //                            worksheet.Cells[iStartRow + _irow, iStartCol + 10].Value = _dr["PosName"].ToString();
        //                            try
        //                            {
        //                                string AppliedDate = Convert.ToDateTime(_dr["Birthday"].ToString()).ToString("dd/MM/yyyy");
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + 4].Value = AppliedDate;
        //                            }
        //                            catch (Exception)
        //                            {
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + 4].Value = _dr["Birthday"].ToString();
        //                            }
        //                            try
        //                            {
        //                                string AppliedDate = Convert.ToDateTime(_dr["AppliedDate"].ToString()).ToString("dd/MM/yyyy");
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = AppliedDate;
        //                            }
        //                            catch (Exception)
        //                            {
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + 11].Value = _dr["AppliedDate"].ToString();
        //                            }
        //                            try
        //                            {
        //                                string LeftDate = Convert.ToDateTime(_dr["LeftDate"].ToString()).ToString("dd/MM/yyyy");
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + 12].Value = LeftDate;
        //                            }
        //                            catch (Exception)
        //                            {
        //                                worksheet.Cells[iStartRow + _irow, iStartCol + 12].Value = _dr["LeftDate"].ToString();
        //                            }
        //                            for (int i = 0; i <= 12; i++)
        //                            {
        //                                var cell = worksheet.Cells[iStartRow + _irow, iStartCol];
        //                                var borders = worksheet.Cells[iStartRow + _irow, iStartCol + i].Style.Border;
        //                                borders.Bottom.Style = borders.Left.Style = borders.Right.Style = ExcelBorderStyle.Thin;
        //                            }
        //                            _index++;
        //                            _irow++;
        //                        }
        //                        worksheet.View.PageLayoutView = false;
        //                        //worksheet.Cells.AutoFitColumns();
        //                        xlPackage.SaveAs(stream);
        //                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        //                        saveFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        //                        saveFileDialog1.FilterIndex = 2;
        //                        saveFileDialog1.RestoreDirectory = true;
        //                        stream.CopyTo(File.Create("C:\\abcd.xlsx"));
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
        //            //Tool.message_HRM("Không có dữ liệu");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        GUIHelper.Notifications(ex.Message, type: GUIHelper.NotifiType.error);
        //    }
        //}
    
    }
}
