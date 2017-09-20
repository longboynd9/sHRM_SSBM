using iHRM.Core.Business;
using iHRM.Core.Business.Logic.Luong;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using iHRM.Win.Cls;

namespace iHRM.Win.Frm.Luong
{
    public partial class dlgChiTietTienThuong : dlgCustomBase
    {
        public string empID { get; set; }
        public DateTime tuNgay { get; set; }

        public dlgChiTietTienThuong()
        {
            InitializeComponent();
        }

        private void dlgReportMonth_Load(object sender, EventArgs e)
        {
            frmBase.LoadGrvLayout_custom(grv, "Luong.dlgChiTietTienThuong");
            LoadData();
        }

        public void LoadData()
        {
            //this.Form_Title = Lng.Luong_ReportMonth.title2 + empID;
            this.Form_Description = string.Format("Chi tiết các khoản thưởng trong tháng {0:MM/yyyy} của nhân viên {1}", tuNgay, empID);

            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadData(ds, ds.tbBangLuongCalc.TableName);
            Provider.LoadDataByProc(ds, ds.tbBangLuongThang.TableName, "p_tinhLuong_GetBangLuongByEmp",
                new SqlParameter("thang", new DateTime(tuNgay.Year, tuNgay.Month, 1)),
                new SqlParameter("empID", empID)
            );

            if (ds.tbBangLuongThang.Rows.Count == 0)
            {
                GUIHelper.Notifications_msg(GUIHelper.Notifications_msgType.RecordNotFound);
                return;
            }

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("PC"),
                new DataColumn("TT", typeof(float))
            });

            var bl = ds.tbBangLuongThang[0];
            foreach(var dr in ds.tbBangLuongCalc)
            {
                var r = dt.NewRow();
                r["PC"] = dr.caption;
                r["TT"] = bl[dr.fieldName];
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
            frmBase.SaveGrvLayout_custom(grv, "Luong.dlgChiTietTienThuong");
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
