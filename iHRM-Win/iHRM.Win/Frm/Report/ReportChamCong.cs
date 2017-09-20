using iHRM.Core.Business;
using iHRM.Core.i_Report;
using iHRM.Win.Cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Report
{
    public partial class ReportChamCong : frmBase
    {
        iHRM.Core.Controller.Report.GetData controller = new Core.Controller.Report.GetData();
        public ReportChamCong()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }
        DataTable dt = new DataTable();
        private void btnFind_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            dw_it.OnDoing = (s,ev) => //hàm lấy dữ liệu chạy ngầm
            {
                dt = controller.getDataReportChamCong(
                            textEdit1.Text.Trim() == "" ? null : textEdit1.Text.Trim(),
                            (chonPhongBan1.SelectedValue == null || chonPhongBan1.SelectedValue.ToString() == "") ? null : chonPhongBan1.SelectedValue.ToString(),
                            chonKyLuong1.TuNgay, chonKyLuong1.DenNgay
                         );
                dw_it.bw.ReportProgress(1, dt);
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Excel 2007|*.xls";
            if (sd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                if (System.IO.File.Exists(sd.FileName))
                    System.IO.File.Delete(sd.FileName);
            }
            catch (Exception exc)
            {
                GUIHelper.MessageError(exc.Message, this.Text);
                return;
            }

            ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel();
            ExcelExportHelper ex = new ExcelExportHelper("Report/BaoCaoChamCongTongHopTrongThang.xls");
            ex.WriteToCell("A3", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));

            ex.FillDataTable(dt);
            ex.RendAndFlush("BaoCaoChamCongTongHopTrongThang_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
    }
}
