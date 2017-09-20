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
    public partial class ReportChiTietVaoRaThang : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        public ReportChiTietVaoRaThang()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime day;
            DateTime todates;
            var dt = new DataTable();
            day = chonKyLuong1.TuNgay;
            todates = chonKyLuong1.DenNgay;

            dt = logic.GetReportquetTheMonth(day, todates, chonPhongBan1.SelectedValue, txtEmpID.Text != "" ? txtEmpID.Text : null);
            dt.Columns.Add("TT");
            dt.Columns.Add("tgTangCa", typeof(double));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["ngay"] != null && dr["ngay"].ToString() != "")
                    {
                        dr["ngay"] = Convert.ToDateTime(dr["ngay"].ToString()).ToShortDateString();
                    }
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
                GUIHelper.Notifications("Không có dữ liệu");
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
            chonKyLuong1.TuNgay = chonKyLuong1.DenNgay = DateTime.Now.Date;
        }
        private string GetTrangThai(DataRow dr, int type = 1)
        {
            return Core.Controller.QuetThe.Helper.GetTrangThai(dr);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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
            DateTime day;
            DateTime todates;
            var dtData = new DataTable();
            day = chonKyLuong1.TuNgay;
            todates = chonKyLuong1.DenNgay;

            dtData = logic.GetReportquetTheMonth(day, todates, chonPhongBan1.SelectedValue, txtEmpID.Text != "" ? txtEmpID.Text : null);
            dtData.Columns.Add("TT");
            dtData.Columns.Add("tgTangCa", typeof(double));
            dtData.Columns.Add("tgQuetDen1", typeof(string));
            dtData.Columns.Add("tgQuetVe1", typeof(string));
            if (dtData.Rows.Count > 0)
            {
                foreach (DataRow dr in dtData.Rows)
                {
                    if (dr["ngay"] != null && dr["ngay"].ToString() != "")
                    {
                        dr["ngay"] = Convert.ToDateTime(dr["ngay"].ToString()).ToShortDateString();
                    }
                    dr["TT"] = GetTrangThai(dr, 2);
                    if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                        dr["tgDiMuon"] = 0;
                    if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                    {
                        dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                        dr["tgVeSom"] = 0;
                    }
                    if (dr["tgQuetDen"] != DBNull.Value && dr["tgQuetDen"].ToString() != "")
                        dr["tgQuetDen1"] = dr["tgQuetDen"].ToString().Substring(0, 5); 
                    if (dr["tgQuetVe"] != DBNull.Value && dr["tgQuetVe"].ToString() != "")
                        dr["tgQuetVe1"] = dr["tgQuetVe"].ToString().Substring(0, 5); 
                }
                ExcelTemplate.GenExcel ge = new ExcelTemplate.GenExcel();
                ExcelExportHelper ex = new ExcelExportHelper("Report/ReportChiTietVaoRaThang.xls");
                ex.WriteToCell("A2", "TÌNH HÌNH QUẸT THẺ NGÀY " + chonKyLuong1.TuNgay.Date.ToString("dd/MM"));

                ex.FillDataTable(dtData);
                ex.RendAndFlush("ReportChiTietVaoRaThang_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
            }
            else
                GUIHelper.Notifications("Không có dữ liệu");
            #endregion


        }

    }
}
