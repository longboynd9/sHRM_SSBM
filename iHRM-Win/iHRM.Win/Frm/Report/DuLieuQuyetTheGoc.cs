using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
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
    public partial class DuLieuQuyetTheGoc : frmBase
    {
        public DuLieuQuyetTheGoc()
        {
            InitializeComponent();
        }
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        DataTable dt = new DataTable();
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) =>
            {
                dt = Core.Business.Provider.ExecuteDataTableReader("p_chamcong_GetReportQuetTheGoc",
                    new SqlParameter("empID", textEdit1.Text.Trim()),
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("todate", new DateTime(chonKyLuong1.DenNgay.Year,chonKyLuong1.DenNgay.Month,chonKyLuong1.DenNgay.Day,23,59,59)),
                    new SqlParameter("depID", chonPhongBan1.SelectedValue)
                );
                dw_it.bw.ReportProgress(1, dt);
            };

            dw_it.OnProcessing = (ps, data) =>
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
            ExcelExportHelper ex = new ExcelExportHelper("Report/BaoCaoQuetTheGoc.xls");
            ex.WriteToCell("A3", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));

            ex.FillDataTable(dt);
            ex.RendAndFlush("BaoCaoQuetTheGoc_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
    }
}
