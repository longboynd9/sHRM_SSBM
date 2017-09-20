using iHRM.Core.Business;
using iHRM.Core.Business.Logic.Luong;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using iHRM.Win.ExtClass;
using System.Windows.Forms;
using iHRM.Win.ExtClass.Luong;


namespace iHRM.Win.Frm.Luong
{
    public partial class dlgChiTietTangCa : dlgCustomBase
    {
        public string empID { get; set; }
        public DateTime tuNgay { get; set; }
        public DateTime denNgay { get; set; }

        public dlgChiTietTangCa()
        {
            InitializeComponent();
        }

        private void dlgReportMonth_Load(object sender, EventArgs e)
        {
            frmBase.LoadGrvLayout_custom(grv, "Luong.dlgChiTietTangCa");
            LoadData();
        }

        public void LoadData()
        {
            this.Form_Title = Lng.Luong_ReportMonth.title3 + empID;

            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadDataByProc(ds, ds.p_tinhLuong_GetAllKetQuaQuetThe.TableName, "p_tinhLuong_GetAllKetQuaQuetThe",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("empID", empID)
            );
            Provider.LoadData(ds, ds.tbCaLam_TinhTangCa.TableName);

            Provider.LoadDataByProc(ds, ds.tblEmpSalary.TableName, "p_tinhLuong_GetLuongCoBan",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("ngay", typeof(DateTime)),
                new DataColumn("TT"),
                new DataColumn("tgTinhTangCa", typeof(double)),
                new DataColumn("tienTangCa", typeof(double))
            });
            TinhLuongHelper hp = new TinhLuongHelper(ds, tuNgay, denNgay, empID);
            foreach (dsTinhLuong.p_tinhLuong_GetAllKetQuaQuetTheRow kq in ds.p_tinhLuong_GetAllKetQuaQuetThe)
            {
                var r = dt.NewRow();
                hp.Set_KQQT(kq);

                r["ngay"] = kq.ngay;
                r["TT"] = Core.Controller.QuetThe.Helper.GetTrangThai(kq);
                r["tgTinhTangCa"] = kq["tgTinhTangCa"] != DBNull.Value ? Convert.ToDouble(kq["tgTinhTangCa"]) : 0;
                r["tienTangCa"] = hp.TinhTienTangCa();

                dt.Rows.Add(r);
            }

            grd.DataSource = dt;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmBase.ExportGrid(grd);
        }
        
        private void dlgReportMonth_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBase.SaveGrvLayout_custom(grv, "Luong.dlgChiTietTangCa");
        }

        private void dlgReportMonth_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            this.Hide();
        }

        private void grv_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                var r = e.Row as DataRowView;
                if (r == null)
                    return;

                //if (e.Column == gridColumn13)
                //{
                //    if ((r["isLocked"] as bool?) == true)
                //        e.Value = Properties.Resources.ico20_lock;
                //    else
                //        e.Value = null;
                //}
            }
        }
        
    }
}
