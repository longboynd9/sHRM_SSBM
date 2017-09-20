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
    public partial class report_quetthengay : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        public report_quetthengay()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime day;
            DateTime today;
            dt = new DataTable();
            if (chonKyLuong1.TuNgay != null && chonKyLuong1.DenNgay != null)
            {
                day = chonKyLuong1.TuNgay.Date;
                today = chonKyLuong1.DenNgay.Date;
                dt = logic.GetReportQuetTheByDate(day, today, chonPhongBan1.SelectedValue, txtEmpID.Text != "" ? txtEmpID.Text : null);
                dt.Columns.Add("TT");
                dt.Columns.Add("tgTangCa", typeof(double));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["TT"] = GetTrangThai(dr, 2);
                    if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                        dr["tgDiMuon"] = 0;
                    if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                    {
                        dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                        dr["tgVeSom"] = 0;
                    }
                }
                grd.DataSource = dt;
            }
            else
            {
                GUIHelper.MessageError(Lng.report_quetthengay.msg_1);
                return;
            }
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
            ExcelExportHelper ex = new ExcelExportHelper("Report/BaoCaoQuetTheTheoNgay.xls");
            ex.WriteToCell("A3", "Từ ngày " + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));

            ex.FillDataTable(dt);
            ex.RendAndFlush("BaoCaoQuetTheTheoNgay_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            chonKyLuong1.TuNgay = chonKyLuong1.DenNgay = DateTime.Now.Date;
        }
        private string GetTrangThai(DataRow dr, int type = 1)
        {
            return Core.Controller.QuetThe.Helper.GetTrangThai(dr);
        }
    }
}
