using iHRM.Core.i_Report;
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
using iHRM.Win.Cls;
using iHRM.Core.Business;
using iHRM.Win.ExtClass;

namespace iHRM.Win.Frm.Report
{
    public partial class NgayCongTangCaThang : frmBase
    {
        iHRM.Core.Business.DbObject.dcDatabaseDataContext db = new Core.Business.DbObject.dcDatabaseDataContext(Provider.ConnectionString);
        iHRM.Core.Controller.Report.GetData controller = new Core.Controller.Report.GetData();
        public NgayCongTangCaThang()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
                //try
                //{
                var dt = controller.GetDataReportMonthForm(ucChonDoiTuong1.SelectedIndex.ToString(), ucChonDoiTuong1.SelectedValue, chonKyLuong1.TuNgay, chonKyLuong1.DenNgay);
                dw_it.bw.ReportProgress(1, dt);
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}

            };
            dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grd.DataSource = data.UserState;
                        btnFind.Enabled = true;
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            btnExcel.Enabled = false;
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu..."; //text hiện ở status
            dw_it.OnDoing = (s, ev) => //hàm lấy dữ liệu chạy ngầm
            {
                var dt = controller.GetDataReportMonthExcel(ucChonDoiTuong1.SelectedIndex.ToString(), ucChonDoiTuong1.SelectedValue, chonKyLuong1.TuNgay, chonKyLuong1.DenNgay);
                if (dt == null || dt.Rows.Count == 0)
                {
                    dw_it.bw.ReportProgress(-1, "Không có dữ liệu");
                    return;
                }

                dw_it.bw.ReportProgress(-1, "Nhóm dữ liệu...");
                var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");

                dw_it.bw.ReportProgress(-1, "Đang chuẩn bị dữ liệu...");
                var ex = xuatexcel(dt2, "Cong\\BaoCaoThang", 6, 0, chonKyLuong1.TuNgay, chonKyLuong1.DenNgay, dw_it.bw);
                dw_it.bw.ReportProgress(1, ex);
            };
            dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        var ex = data.UserState as ExcelExportHelper;

                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel|*.xlsx";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            ex.Save(saveFileDialog1.FileName);
                        }
                        btnExcel.Enabled = true;
                        break;
                }
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        public ExcelExportHelper xuatexcel(DataTable dtData, string strFileExcel, int iStartRow, int iStartCol, DateTime TuNgay, DateTime DenNgay, BackgroundWorker bw)
        {
            string tenPB = "";
            int _irow = 0;
            int _indexcol = 0;

            if (dtData.Rows.Count > 0)
            {
                ExcelExportHelper ex = new ExcelExportHelper(strFileExcel);

                //  ex.WriteToCell(7, 2, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //  ex.WriteToCell(8, 2, Convert.ToDateTime(dtangay.Value).Day + "/" + Convert.ToDateTime(dtangay.Value).Month + "/" + Convert.ToDateTime(dtangay.Value).Year + "  " + cboFromHour.SelectedItem.Value + ":" + cboFromPhut.SelectedItem.Value + ":00"; ;
                //  ex.WriteToCell(9, 2, Convert.ToDateTime(dtToDate.Value).Day + "/" + Convert.ToDateTime(dtToDate.Value).Month + "/" + Convert.ToDateTime(dtToDate.Value).Year + "  " + cbotoHour.SelectedItem.Value + ":" + cboToPhut.SelectedItem.Value + ":00";
                ex.WriteToCell(2, 0, "Từ ngày:" + TuNgay.ToString("dd/MM/yyyy") + " Đến ngày:" + DenNgay.ToString("dd/MM/yyyy"));
                if (Interface_Company.companyName == "SSYT")
                {
                    ex.WriteToCell("AC5", "Tháng " + TuNgay.Month);
                    ex.WriteToCell("J5", "Tháng " + DenNgay.Month);
                }
                else
                {
                    ex.WriteToCell("Z5", "Tháng " + TuNgay.Month);
                    ex.WriteToCell("J5", "Tháng " + DenNgay.Month);
                }
                //ex.ClearPageBreak();
                //ex.setPageBreakPreview(true);
                try
                {
                    int pageBreak = 0;
                    int _index = 1;
                    foreach (DataRow _dr in dtData.Rows)
                    {
                        if (_index % 10 == 0)
                            bw.ReportProgress(-1, string.Format("Đang chuẩn bị dữ liệu ({0}/{1})", _index, dtData.Rows.Count));

                        if (_dr["DepName"].ToString() != "")
                        {
                            tenPB = _dr["DepName"].ToString();
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 1, _dr["DepName"].ToString());
                            // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 5, TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 8, tenPB);
                            ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + 1, iHRM.Common.Code.ExcelExtend.BorderPosition.Left);
                            ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + 1, iHRM.Common.Code.ExcelExtend.BorderPosition.Right);
                            for (int i = 0; i <= 49; i++)
                            {
                                //var cell = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + i];
                                //var border = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
                                //var fill = cell.Style.Fill;
                                // fill.PatternType = ExcelFillStyle.Solid;
                                // fill.BackgroundColor.SetColor(System.Drawing.Color.YellowGreen);
                                //  fill.BackgroundColor.SetColor(
                                //border.Left.Style = border.Right.Style = border.Bottom.Style = ExcelBorderStyle.Thin;
                                ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Bottom);
                            }
                            if (pageBreak >= 1)
                            {
                                ex.setHorPageBreakAtCell("AY" + (iStartRow + _irow + 1));
                            }
                            pageBreak++;
                            _irow++;
                        }
                        else
                        {
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol, _index);
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 3, _dr["tenNV"].ToString());
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 4, _dr["EmployeeID"].ToString());
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 5, _dr["PosName"].ToString());
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 6, _dr["AppliedDate"]);
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 7, _dr["IDCard"].ToString());
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 8, tenPB);
                            ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 8, tenPB);
                            // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 5, TypeHelper.ToDateTime(_dr["gps_create_date"].ToString());//ket thuc hanh trinh
                            for (int i = 1; i <= 31; i++)
                            {
                                //try
                                //{
                                //    ex.WriteToCell(iStartRow + _irow, (iStartCol + _indexcol + 8) + i, Convert.ToDouble(_dr["D" + i]).ToString());
                                //}
                                //catch (Exception)
                                //{
                                //    ex.WriteToCell(iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i, _dr["D" + i]);                                    
                                //}
                                //try
                                //{
                                //    ex.WriteToCell(iStartRow + _irow, (iStartCol + _indexcol + 8) + i, Convert.ToDouble(_dr["T" + i]).ToString());
                                //}
                                //catch (Exception)
                                //{
                                //    ex.WriteToCell(iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i, _dr["T" + i]);                      
                                //}

                                ex.WriteToCell(iStartRow + _irow, (iStartCol + _indexcol + 8) + i, _dr["D" + i].ToString());
                                ex.WriteToCell(iStartRow + _irow + 1, (iStartCol + _indexcol + 8) + i, _dr["T" + i].ToString());
                            }
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 40, Convert.ToDouble(_dr["DChuNhat"].ToString() != "" ? _dr["DChuNhat"].ToString() : "0"));
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 41, Convert.ToDouble(_dr["NghiLe"].ToString() != "" ? _dr["NghiLe"].ToString() : "0"));
                            // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 41, _dr["DChuNhat"].ToString();
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 42, Convert.ToDouble(_dr["NghiKhongPhep"].ToString() != "" ? _dr["NghiKhongPhep"].ToString() : "0"));
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 43, Convert.ToDouble(_dr["NghiPhepNam"].ToString() != "" ? _dr["NghiPhepNam"].ToString() : "0"));
                            // ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 44, _dr["NghiOm"];
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 44, Convert.ToDouble(_dr["NghiKhongLuong"].ToString() != "" ? _dr["NghiKhongLuong"].ToString() : "0"));
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 45, Convert.ToDouble(_dr["NghiThaiSan"].ToString() != "" ? _dr["NghiThaiSan"].ToString() : "0"));

                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 46, Convert.ToDouble(_dr["NghiCheDo"].ToString() != "" ? _dr["NghiCheDo"].ToString() : "0"));
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 47, Convert.ToDouble(_dr["NghiKhac"].ToString() != "" ? _dr["NghiKhac"].ToString() : "0"));
                            ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + 48, Convert.ToDouble(_dr["SoNgayCong"].ToString() != "" ? _dr["SoNgayCong"].ToString() : "0"));
                            ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 48, Convert.ToDouble(_dr["TangCa"].ToString() != "" ? _dr["TangCa"].ToString() : "0"));
                            ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 50, _dr["TeamName"].ToString());
                            ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + 51, _dr["LineName"].ToString());
                            for (int i = 0; i <= 51; i++)
                            {
                                //    var cells = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol];
                                //var borders = ex.WriteToCell(iStartRow + _irow, iStartCol + _indexcol + i].Style.Border;
                                //var borderschil = ex.WriteToCell(iStartRow + _irow + 1, iStartCol + _indexcol + i].Style.Border;
                                if ((iStartCol + _indexcol + i) < 2 || (iStartCol + _indexcol + i) > 3)
                                {
                                    ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Left);
                                    ex.SetCellBorder(iStartRow + _irow, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Right);
                                    ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Bottom);
                                    ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Left);
                                    ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Right);
                                }
                                else
                                {
                                    ex.SetCellBorder(iStartRow + _irow + 1, iStartCol + _indexcol + i, iHRM.Common.Code.ExcelExtend.BorderPosition.Bottom);
                                    //borderschil.Top.Style = ExcelBorderStyle.Dotted;
                                }
                            }
                            _irow = _irow + 2;
                            _index++;
                        }
                    }
                    ex.setHorPageBreakAtCell("AY" + (iStartRow + _irow + 1));
                    ex.setVerPageBreakAtCell("AX" + (iStartRow + _irow + 1));
                    //worksheet.View.PageLayoutView = false;
                    //ex.ActiveSheet.worksheet.View.PageBreakView = true;
                    //worksheet.Cells.AutoFitColumns();

                    //xlPackage.SaveAs(stream);
                    //Byte[] bytearray = stream.ToArray();
                    //SaveFileDialog(fileTemp.Name, bytearray);
                    //stream.Flush();
                    //stream.Close();
                    ex.ConvertStringToNumericValue();
                    return ex;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return null;
        }

        private void btnExcelIn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel|*.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                grd.ExportToXlsx(saveFileDialog1.FileName);
            }
        }
    }
}
