using iHRM.Core.Business;
using iHRM.Core.Business.Logic.Luong;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace iHRM.Win.Frm.Luong
{
    public partial class dlgChiTietPhuCap : dlgCustomBase
    {
        public string empID { get; set; }
        public DateTime tuNgay { get; set; }

        public dlgChiTietPhuCap()
        {
            InitializeComponent();
        }

        private void dlgReportMonth_Load(object sender, EventArgs e)
        {
            frmBase.LoadGrvLayout_custom(grv, "Luong.dlgChiTietPhuCap");
            LoadData();
        }

        public void LoadData()
        {
            this.Form_Title = Lng.Luong_ReportMonth.title2 + empID;
            this.Form_Description = string.Format("Chi tiết các phụ cấp trong tháng {0:MM/yyyy} của nhân viên {1}", tuNgay, empID);

            dsTinhLuong ds = new dsTinhLuong();
            Provider.LoadData(ds, ds.tblRef_Allowance.TableName);
            Provider.LoadDataByProc(ds, ds.tbThamSoTinhLuong.TableName, "p_tinhLuong_GetThamSoTinhLuong",
                new SqlParameter("thang", new DateTime(tuNgay.Year, tuNgay.Month, 1)),
                new SqlParameter("empID", empID)
            );

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("PC"),
                new DataColumn("TT", typeof(float))
            });

            var ts = ds.tbThamSoTinhLuong.FirstOrDefault(i => i.employeeID == empID);
            if (ts != null)
            {
                for (int i = 1; i < 11; i++)
                {
                    var r = dt.NewRow();
                    var a = ds.tblRef_Allowance.FirstOrDefault(it => it.AllowanceID == "PC" + i);
                    if (a != null)
                        r["PC"] = a.AllowanceName;

                    if (ts["PC" + i] != DBNull.Value && Convert.ToDouble(ts["PC" + i]) > 0)
                    {
                        r["TT"] = ts["PC" + i];
                        dt.Rows.Add(r);
                    }
                }
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
            frmBase.SaveGrvLayout_custom(grv, "Luong.dlgChiTietPhuCap");
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
