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
    public partial class ThongkedulieuquetheNgay : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        public ThongkedulieuquetheNgay()
        {
            InitializeComponent();
            List<Loai> _lLoai = new List<Loai>();
            _lLoai.Add(new Loai { loai = "No In - no Out", value = 0 });
            _lLoai.Add(new Loai { loai = "In - no Out", value = 1 });
            _lLoai.Add(new Loai { loai = "No In - Out", value = 2 });
            _lLoai.Add(new Loai { loai = "punching card = 2", value = 4 });
            _lLoai.Add(new Loai { loai = "In - All out", value = 6 });
            _lLoai.Add(new Loai { loai = "All of in out", value = 5 });
            lookupLoai.Properties.DataSource = _lLoai;
            lookupLoai.Properties.DisplayMember = "loai";
            lookupLoai.Properties.ValueMember = "value";
        }


        DataTable dt = new DataTable();
        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime day;
            DateTime today;
            dt = new DataTable();
            if (chonKyLuong1.TuNgay != null && chonKyLuong1.DenNgay != null)
            {
                day = chonKyLuong1.TuNgay;
                today = chonKyLuong1.DenNgay;
                dt = logic.GetReportQuetTheByDate(day, today, chonPhongBan1.SelectedValue, txtEmpID.Text != "" ? txtEmpID.Text : null);
                dt.Columns.Add("TT");
                dt.Columns.Add("tgTangCa", typeof(double));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["TT"] = GetTrangThai(dr);
                    if (dr["tgDiMuon"] != DBNull.Value && Convert.ToInt32(dr["tgDiMuon"]) < 0)
                        dr["tgDiMuon"] = 0;
                    if (dr["tgVeSom"] != DBNull.Value && Convert.ToInt32(dr["tgVeSom"]) < 0)
                    {
                        dr["tgTangCa"] = -1 * Convert.ToInt32(dr["tgVeSom"]);
                        dr["tgVeSom"] = 0;
                    }
                }
                DataTable tbl = dt.Clone();

                if (lookupLoai.EditValue.ToString() == "0")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] == null || p["tgQuetDen"].ToString() == "") && (p["tgQuetVe"] == null || p["tgQuetVe"].ToString() == ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (lookupLoai.EditValue.ToString() == "1")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "") && (p["tgQuetVe"] == null || p["tgQuetVe"].ToString() == ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (lookupLoai.EditValue.ToString() == "2")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] == null || p["tgQuetDen"].ToString() == "") && (p["tgQuetVe"] != null && p["tgQuetVe"].ToString() != ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (lookupLoai.EditValue.ToString() == "4")
                {
                    try
                    {
                        tbl = dt.Select()
                          .Where(p => (p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "") && (p["tgQuetVe"] != null && p["tgQuetVe"].ToString() != ""))
                          .CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }

                }
                else if (lookupLoai.EditValue.ToString() == "5")
                {
                    try
                    {
                        tbl = dt.Select().CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (lookupLoai.EditValue.ToString() == "6")
                {
                    try
                    {
                        tbl = dt.Select().Where(p => p["tgQuetDen"] != null && p["tgQuetDen"].ToString() != "").CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }
                }
                if (tbl != null)
                {
                    if (tbl.Rows.Count > 0)
                    {
                        tbl = tbl.Select("", "EmployeeName,ngay ASC").CopyToDataTable();
                        grd.DataSource = tbl;
                    }
                    else
                    {
                        GUIHelper.Notifications("Không có dữ liệu");
                        grd.DataSource = tbl;
                        return;
                    }
                }

            }
            else
            {
                GUIHelper.MessageError("Bạn chưa chọn ngày");
                return;
                // dt = logic.GetReportQuetTheByDate(null, DepID);
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

        private class Loai
        {
            public string loai { get; set; }
            public int value { get; set; }
        }
    }
}
