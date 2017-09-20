using iHRM.Core.i_Report;
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
    public partial class BaoCaoMucTuoi : frmBase
    {
        public BaoCaoMucTuoi()
        {
            InitializeComponent();
        }
        private void Viewer_Load(object sender, EventArgs e)
        {
            LoadGrvLayout(grv);
            dateMocThoiGian.DateTime = DateTime.Now;
        }

        int fromAge, toAge;
        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            fromAge = Convert.ToInt16(txtMucTuoi.Text.Split('-')[0]);
            toAge = Convert.ToInt16(txtMucTuoi.Text.Split('-')[1]);
            mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            dw_it.Caption = "Đang tải dữ liệu...";
            dw_it.OnDoing = (s,ev) =>
            {
                var vp_RecordCount = new SqlParameter("vp_RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var dt = Core.Business.Provider.ExecuteDataTableReader("p_GetReportMucTuoi",
                    new SqlParameter("vp_PageSize", pageNavigator1.PageSize),
                    new SqlParameter("vp_CurrentPage", pageNavigator1.CurrentPage),
                    vp_RecordCount,
                    new SqlParameter("fromAge", fromAge),
                    new SqlParameter("toAge", toAge),
                    new SqlParameter("mocThoiGian", dateMocThoiGian.DateTime),
                    new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
                    new SqlParameter("denNgay", chonKyLuong1.DenNgay),
                    new SqlParameter("depID", chonPhongBan1.SelectedValue)
                );

                dw_it.bw.ReportProgress(1, dt);
                dw_it.bw.ReportProgress(2, vp_RecordCount.Value);
                dw_it.bw.ReportProgress(3, (int)vp_RecordCount.Value);
                dw_it.bw.ReportProgress(4, vp_RecordCount.SqlValue);

            };
            dw_it.OnProcessing = (ps, data) =>
            {
                switch (data.ProgressPercentage)
                {
                    case 1:
                        grd.DataSource = data.UserState;
                        btnFind.Enabled = true;
                        break;
                    case 3:
                        pageNavigator1.RecordCount = (int)data.UserState;
                        break;
                }
            }; //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing

            main.Instance.DoworkItem_Reg(dw_it);
        }

        //void OnDoing1(BackgroundWorker bw)
        //{
        //    var vp_RecordCount = new SqlParameter("vp_RecordCount", SqlDbType.Int) { Direction = ParameterDirection.Output };
        //    var dt = Core.Business.Provider.ExecuteDataTableReader("p_GetReportMucTuoi",
        //        new SqlParameter("vp_PageSize", pageNavigator1.PageSize),
        //        new SqlParameter("vp_CurrentPage", pageNavigator1.CurrentPage),
        //        vp_RecordCount,
        //        new SqlParameter("fromAge", fromAge),
        //        new SqlParameter("toAge", toAge),
        //        new SqlParameter("mocThoiGian", dateMocThoiGian.DateTime),
        //        new SqlParameter("tuNgay", chonKyLuong1.TuNgay),
        //        new SqlParameter("denNgay", chonKyLuong1.DenNgay),
        //        new SqlParameter("depID", chonPhongBan1.SelectedValue)
        //    );

        //    dw_it.bw.ReportProgress(1, dt);
        //    dw_it.bw.ReportProgress(2, vp_RecordCount.Value);
        //    dw_it.bw.ReportProgress(3, (int)vp_RecordCount.Value);
        //    dw_it.bw.ReportProgress(4, vp_RecordCount.SqlValue);
        //}

        //private void OnReport1(int ps, object data)
        //{
        //    switch (data.ProgressPercentage)
        //    {
        //        case 1:
        //            grd.DataSource = data;
        //            btnFind.Enabled = true;
        //            break;
        //        case 3:
        //            pageNavigator1.RecordCount = (int)data;
        //            break;
        //    }
        //}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportGrid(grd);
        }

        private void Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveGrvLayout(grv);
        }
    }
}
