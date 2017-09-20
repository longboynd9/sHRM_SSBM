using iHRM.Common.DungChung;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
using iHRM.Win.ExtClass.Luong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class ReportMonth : frmBase
    {
        TinhLuong logic = new TinhLuong();
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        //dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        Common.dlgChonDoiTuong chonDT = new Common.dlgChonDoiTuong();
        Frm.QuetThe.dlgReportMonth dlgCTNgayCong = new Frm.QuetThe.dlgReportMonth();
        dlgChiTietTangCa dlgCTTangCa = new dlgChiTietTangCa();
        dlgChiTietPhuCap dlgCTPhuCap = new dlgChiTietPhuCap();
        dlgChiTietTienThuong dlgCTTienThuong = new dlgChiTietTienThuong();

        public ReportMonth()
        {
            InitializeComponent();
        }

        private void frmDangKyCaLam_Load(object sender, EventArgs e)
        {
            dlgCTNgayCong.Owner = this;
            dlgCTTangCa.Owner = this;
            dlgCTPhuCap.Owner = this;
            LoadGrvLayout(grv);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //btnFind.Enabled = false;
            
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu đăng ký ca làm...";
            dw_it.OnDoing = (s,ev) =>
            {
                DataTable dtData;
                DateTime cMonth = new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, 1);
                //int soNgayCongThang = TinhLuongHelper.DemNgayCong();
                if (chonDT.SelectedIndex == 1)
                {
                    dtData = logic.GetBangLuong_1dong_ByEmp(cMonth, chonDT.SelectedValue, chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }
                else if (chonDT.SelectedIndex == 3)
                {
                    dtData = logic.GetBangLuong_1dong_ByGroup1(cMonth, Convert.ToInt32(chonDT.SelectedValue), chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }
                else
                {
                    dtData = logic.GetBangLuong_1dong(cMonth, chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, chonDT.SelectedValue, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }             
                dw_it.bw.ReportProgress(1, dtData);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                var dtData = data.UserState as DataTable;
                if (dtData == null || dtData.Rows.Count == 0)
                {
                    GUIHelper.Notifications(Lng.Luong_ReportMonth.msg_1, this.Text, GUIHelper.NotifiType.comment);
                }
                grd.DataSource = dtData;
                btnFind.Enabled = true;
            };
            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void frmDangKyCaLam_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }

        private string getMonthName(int numMonth)
        {
            string strMonth = "";
            //List<int> _lMonth = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<string> _lMonthName = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            strMonth = _lMonthName[numMonth - 1];
            return strMonth;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //ExportGrid(grd);

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))
                    System.IO.File.Delete(sd.FileName);
            }
            catch(Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);
                return;
            }
            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel();

            ge.OnDoing += (dw_it) =>
            {
                dw_it.ReportProgress(-1, "Xuất excel bảng lương");

                #region get data
                dw_it.ReportProgress(-2, "Đang tải dữ liệu...");
                DataTable dtData;
                DateTime cMonth = new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, 1);
                if (chonDT.SelectedIndex == 1)
                {
                    dtData = logic.GetBangLuongChiTiet_WithEmp(cMonth, chonDT.SelectedValue, chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }
                else if (chonDT.SelectedIndex == 3)
                {
                    dtData = logic.GetBangLuongChiTiet_WithGroup1(cMonth, Convert.ToInt32(chonDT.SelectedValue), chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }
                else
                {
                    dtData = logic.GetBangLuongChiTiet(cMonth, chonDT.SelectedValue, chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }
                
                if (dtData == null || dtData.Rows.Count == 0)
                {
                    dw_it.ReportProgress(1);
                    return;
                }

                //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
                #endregion

                #region export
                dw_it.ReportProgress(-2, "Ghi ra excel...");

                ExcelExportHelper ex = new ExcelExportHelper("Luong/monthlySalary.xls");
                ex.WriteToCell("A1", db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().KeywordVN.ToUpper());
                ex.WriteToCell("A3", string.Format("BẢNG THANH TOÁN TIỀN LƯƠNG THÁNG {0} NĂM {1}", chonKyLuong1.DenNgay.Month, chonKyLuong1.DenNgay.Year));
                ex.WriteToCell("A4", string.Format("SALARY IN {0} {1}", getMonthName(chonKyLuong1.DenNgay.Month).ToUpper(), chonKyLuong1.DenNgay.Year));
                ex.WriteToCell("A6", string.Format("Cycle Salary: {0:dd/MM/yyyy} ~ {1:dd/MM/yyyy}", chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));

                dtData.Columns.Add("laBangLuongCu2", typeof(string));
                foreach (DataRow dr in dtData.Rows)
                {
                    dr["tgTangCa_cn"] = ((dr["tgTangCa_cn"] as double?) ?? 0) + ((dr["ngaycong_cn"] as double?) ?? 0);
                    dr["tienTangCa_cn"] = ((dr["tienTangCa_cn"] as double?) ?? 0) + ((dr["tienNC_cn"] as double?) ?? 0);

                    //double tongPhuCapKhac = 0;
                    //double tongKhauTru = 0;
                    //for (int i = 1; i < 21; i++)
                    //{
                    //    double pc = ((dr["PC" + i] as double?) ?? 0);
                    //    if (pc > 0)
                    //        tongPhuCapKhac += pc;
                    //    else
                    //        tongKhauTru += pc;
                    //}
                    //dr["tongPhuCapKhac"] = tongPhuCapKhac;
                    //dr["tongKhauTru"] = tongKhauTru;

                    dr["laBangLuongCu2"] = (DbHelper.DrGetBoolean(dr, "laBangLuongCu") == true ? "cũ" : "");
                }

                ex.FillDataTable(dtData);
                ex.RendAndFlush("BangLuongChiTiet_"+ DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                dw_it.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications(Lng.Luong_ReportMonth.msg_1 + chonKyLuong1.TuNgay.Month + Lng.Luong_ReportMonth.nam + chonKyLuong1.TuNgay.Year, this.Text, GUIHelper.NotifiType.comment);
                }
                else if (ps == 2)
                {
                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName, UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }
        
        private void txtDoiTuong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (chonDT.ShowDialog() == DialogResult.OK)
                txtDoiTuong.Text = chonDT.SelectedText;
        }
        private void btnCtCong_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r != null)
            {
                dlgCTNgayCong.empID = DbHelper.DrGetString(r, "empoyeeID");
                dlgCTNgayCong.tuNgay = chonKyLuong1.TuNgay;
                dlgCTNgayCong.denNgay = chonKyLuong1.DenNgay;

                dlgCTNgayCong.Show();
                dlgCTNgayCong.LoadData();
            }
        }
        private void btnCtTC_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r != null)
            {
                dlgCTTangCa.empID = DbHelper.DrGetString(r, "empoyeeID");
                dlgCTTangCa.tuNgay = chonKyLuong1.TuNgay;
                dlgCTTangCa.denNgay = chonKyLuong1.DenNgay;

                dlgCTTangCa.Show();
                dlgCTTangCa.LoadData();
            }
        }
        private void btnCtPhuCap_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r != null)
            {
                dlgCTPhuCap.empID = DbHelper.DrGetString(r, "empoyeeID");
                dlgCTPhuCap.tuNgay = chonKyLuong1.TuNgay;

                dlgCTPhuCap.Show();
                dlgCTPhuCap.LoadData();
            }
        }

        private void btnCtTienThuong_Click(object sender, EventArgs e)
        {
            var r = grv.GetFocusedDataRow();
            if (r != null)
            {
                dlgCTTienThuong.empID = DbHelper.DrGetString(r, "empoyeeID");
                dlgCTTienThuong.tuNgay = chonKyLuong1.TuNgay;

                dlgCTTienThuong.Show();
                dlgCTTienThuong.LoadData();
            }
        }
        private void btnPrintf_Click(object sender, EventArgs e)
        {
            Core.Controller.Luong.InPhieuLuong controller = new Core.Controller.Luong.InPhieuLuong();

            var dtData = controller.GetData(new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, 1),
                Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay),
                chonDT.SelectedIndex == 1 ? chonDT.SelectedValue : "",
                chonDT.SelectedIndex == 3 ? Convert.ToInt32(chonDT.SelectedValue) : 0,
                chonDT.SelectedIndex == 2 ? chonDT.SelectedValue : "",
                chonKyLuong1.TuNgay,
                chonKyLuong1.DenNgay
            );

            var rp = new InPhieuLuong();
            string tenCty = db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().TitleEN;
            string strPhieuLuong = string.Format("PHIẾU LƯƠNG THÁNG {0}", chonKyLuong1.DenNgay.ToString("MM/yyyy"));
            string strChuKyLuong = string.Format("CHU KỲ LƯƠNG: {0} ~ {1}", chonKyLuong1.TuNgay.ToString("dd/MM/yyyy"), chonKyLuong1.DenNgay.ToString("dd/MM/yyyy"));
            rp.setTitle(tenCty, strPhieuLuong, strChuKyLuong);
            rp.DataBinding(dtData);
            ReportViewer rv = new ReportViewer();
            rv.ViewReport(rp);
        }

        private void tooltripInCustom_Click(object sender, EventArgs e)
        {
            new InCustomPhieuLuong().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //ExportGrid(grd);

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))
                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception ex)
            {
                GUIHelper.MessageError(ex.Message, this.Text);
                return;
            }

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel();
            ge.OnDoing += (bw) =>
            {
                bw.ReportProgress(-1, "Xuất excel bảng lương");

                #region get data
                bw.ReportProgress(-2, "Đang tải dữ liệu...");
                DataTable dtData;
                DateTime cMonth = new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, 1);
                if (chonDT.SelectedIndex == 1)
                {
                    dtData = logic.GetBangLuongChiTiet_1dong_WithEmp(cMonth, chonDT.SelectedValue, chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }
                else if (chonDT.SelectedIndex == 3)
                {
                    dtData = logic.GetBangLuongChiTiet_1dong_WithGroup1(cMonth, Convert.ToInt32(chonDT.SelectedValue), chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }
                else
                {
                    dtData = logic.GetBangLuongChiTiet_1dong(cMonth, chonDT.SelectedValue, chonKyLuong1.TuNgay.Date, chonKyLuong1.DenNgay.Date, Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                }

                if (dtData == null || dtData.Rows.Count == 0)
                {
                    bw.ReportProgress(1);
                    return;
                }

                //var dt2 = ExcelExportHelper.CreateGroupInDT(dt, "DepName", "STT");
                #endregion

                #region export
                bw.ReportProgress(-2, "Ghi ra excel...");

                ExcelExportHelper ex = new ExcelExportHelper("Luong/monthlySalary_1dong.xls");
                ex.WriteToCell("A2", db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().KeywordVN.ToUpper());
                ex.WriteToCell("A4", string.Format("BẢNG LƯƠNG THÁNG {0}/{1}", chonKyLuong1.DenNgay.Month, chonKyLuong1.DenNgay.Year));
                ex.WriteToCell("A5", string.Format("SALARY IN {0}/{1}", chonKyLuong1.DenNgay.Month, chonKyLuong1.DenNgay.Year));
                ex.WriteToCell("A6", string.Format("Chu kỳ lương (Cycle Salary) : {0:dd/MM/yyyy} ~ {1:dd/MM/yyyy}", chonKyLuong1.TuNgay, chonKyLuong1.DenNgay));
                dtData.Columns.Add("tongTienTangCa_cn", typeof(double));
                foreach (DataRow dr in dtData.Rows)
                {
                    dr["tongTienTangCa_cn"] = ((dr["tongTienTangCa_cn_Total"] as double?) ?? 0) + ((dr["tongTienNC_cn_Total"] as double?) ?? 0);
                }

                ex.FillDataTable(dtData);
                ex.RendAndFlush("BangLuongChiTiet_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                bw.ReportProgress(2);
                #endregion
            };

            ge.OnReport += (ps, obj) =>
            {
                if (ps == 1)
                {
                    GUIHelper.Notifications(Lng.Luong_ReportMonth.msg_1 + chonKyLuong1.TuNgay.Month + Lng.Luong_ReportMonth.nam + chonKyLuong1.TuNgay.Year, this.Text, GUIHelper.NotifiType.comment);
                }
                else if (ps == 2)
                {
                    var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
                    c.AlertClick += (s1, e1) =>
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sd.FileName,
                            UseShellExecute = true
                        });
                    };
                }
            };

            ge.Show(this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Core.Controller.Luong.InPhieuLuong controller = new Core.Controller.Luong.InPhieuLuong();

            var dtData = controller.GetData_1dong(new DateTime(chonKyLuong1.TuNgay.Year, chonKyLuong1.TuNgay.Month, 1),
                Ham.DemNgayCong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay),
                chonDT.SelectedIndex == 1 ? chonDT.SelectedValue : "",
                chonDT.SelectedIndex == 3 ? Convert.ToInt32(chonDT.SelectedValue) : 0,
                chonDT.SelectedIndex == 2 ? chonDT.SelectedValue : "",
                chonKyLuong1.TuNgay,
                chonKyLuong1.DenNgay
            );
            if (Interface_Company.companyName =="YSC")
            {
                foreach (DataRow item in dtData.Rows)
                {
                    if (item["luongSP"] != DBNull.Value && item["luongSP"].ToString() != "0")
                    {
                        item["tgTangCa_bt_Cu"] = 0;
                        item["tgTangCa_bt"] = 0;
                        item["tienTangCa_bt_Cu"] = 0;
                        item["tienTangCa_bt"] = 0;
                        item["tongLuongTG"] = 0;
                    }
                }
            }
            var rp = new InPhieuLuong_1dong();
            string tenCty = db.w5Systems.Where(p => p.Ma == "TitlePhieuLuong").FirstOrDefault().TitleEN;
            string strPhieuLuong = string.Format("PHIẾU LƯƠNG THÁNG {0}", chonKyLuong1.DenNgay.ToString("MM/yyyy"));
            string strChuKyLuong = string.Format("CHU KỲ LƯƠNG: {0} ~ {1}", chonKyLuong1.TuNgay.ToString("dd/MM/yyyy"), chonKyLuong1.DenNgay.ToString("dd/MM/yyyy"));
            rp.setTitle(tenCty, strPhieuLuong, strChuKyLuong);
            rp.DataBinding(dtData);
            ReportViewer rv = new ReportViewer();
            rv.ViewReport(rp);
        }
    }
}
