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
    public partial class ReportTotalHours : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        public ReportTotalHours()
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
                    string empID = txtEmpID.Text;
                    data = logic.GetReportTotalHours(day, todates,txtEmpID.Text, chonPhongBan1.SelectedValue);
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

            #region lấy dữ liệu
                DateTime day = chonKyLuong1.TuNgay;
                DateTime todates = chonKyLuong1.DenNgay;
                var data = new DataTable();
                if (day != null && todates != null)
                {
                    string empID = txtEmpID.Text;
                    data = logic.GetReportTotalHours(day, todates,txtEmpID.Text, chonPhongBan1.SelectedValue);
                }
                ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel();
                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportSoGioTheoNgay.xls");
                ex.WriteToCell("A6", string.Format("Từ ngày {0:dd/MM/yyyy} đến ngày {1:dd/MM/yyyy}",chonKyLuong1.TuNgay,chonKyLuong1.DenNgay));

                ex.FillDataTable(data);
                ex.RendAndFlush("ReportSoGioTheoNgay" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
            #endregion
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
    }
}
