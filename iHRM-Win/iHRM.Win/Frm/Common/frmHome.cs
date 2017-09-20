using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Common
{
    public partial class frmHome : Form
    {
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            //bắt buộc phải load dữ liệu async, có thể add nhiều task

            Timer t1 = new Timer();
            t1.Interval = 2000;
            t1.Tick += (s1, e1) =>
            {
                t1.Stop();

                #region task 1: load nhân viên hết hạn hợp đồng

                mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
                dw_it.Caption = "Đang tải dữ liệu nhân viên hết hạn hợp đồng...";
                dw_it.OnDoing = (s,ev) =>
                {
                    int a = logic.GetReportNVSapHetHopDong_Count(DateTime.Now.Date, null, true);
                    dw_it.bw.ReportProgress(1, a);

                    // Báo cáo nhân viên nghỉ thai sản
                    dw_it.bw.ReportProgress(-1, "Đang tải dữ liệu nhân viên hết hạn nghỉ thai sản...");
                    a = logic.GetReportNVHetHanNghiThaiSan_Count(DateTime.Now, null);
                    dw_it.bw.ReportProgress(2, a);

                    // Báo cáo nhân viên nghỉ quá 14 ngày
                    dw_it.bw.ReportProgress(-1, "Đang tải dữ liệu nhân viên nghỉ quá 14 ngày...");
                    a = logic.GetReportNVKoDiLamLonHon14_Count(DateTime.Now.Date.AddDays(-16),DateTime.Now.Date);
                    dw_it.bw.ReportProgress(3, a);
                };
                dw_it.OnProcessing = (ps, data) =>
                {
                    if (data.ProgressPercentage == 1)
                    {
                        lbHetHanHD.Text = "1. Có " + data + " nhân viên sắp hết hạn hợp đồng.";
                    }
                    else if (data.ProgressPercentage == 2)
                    {
                        lbNghiThaiSan.Text = "2. Có " + data + " nhân viên sắp hết hạn nghỉ thai sản.";
                    }
                    else if (data.ProgressPercentage == 3)
                    {
                        lbKoDiLam.Text = "3. Có " + data + " nhân viên không đi làm >= 14 ngày.";
                    }
                };
                main.Instance.DoworkItem_Reg(dw_it);
                #endregion
            };
            t1.Start();
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                Application.Exit();
            }
        }


        void ShowForm(string frmName)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) =>
            {
                var frm = mainBase.CreateFormByName(frmName);
                dw_it.bw.ReportProgress(1, frm);
            };
            dw_it.OnProcessing = (ps, data) =>
            {
                var frm = data as Form;
                frm.ControlBox = false;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                groupControl1.Text = frm.Text;
                groupControl1.Controls.Clear();
                groupControl1.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                frm.Show();
            };

            main.Instance.DoworkItem_Reg(dw_it);
        }

        private void linkLbNghiThaiSan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowForm("iHRM.Win.Frm.Report.ReportNhanVienHetHanThaiSan");
        }
        private void linkLbHetHanHD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowForm("iHRM.Win.Frm.Report.ReportHopDongHetHan");
        }

        private void lbLinkKhongDiLam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowForm("iHRM.Win.Frm.Report.ReportNhanVienKoDiLamLonHon14");
        }

    }
}
