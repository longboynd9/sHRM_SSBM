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
    public partial class ReportNhanVienHetHanThaiSan : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();

        public ReportNhanVienHetHanThaiSan()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int soNgay = Convert.ToInt16(txtSoNgay.Text);
                DateTime ngayTimKiem = dateTimKiem.DateTime.Date;
                mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
                dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
                dw_it.OnDoing = (s,ev) => //hàm lấy dữ liệu chạy ngầm
                {
                    var data = new DataTable();
                    data = logic.GetReportNVHetHanNghiThaiSan(ngayTimKiem, "", soNgay);
                    if (data.Rows.Count > 0)
                    {
                        dw_it.bw.ReportProgress(1, data.AsEnumerable().OrderBy(p => p["DepName"]).CopyToDataTable());
                    }
                    else
                    {
                        dw_it.bw.ReportProgress(-1, "Không có dữ liệu");
                        dw_it.bw.ReportProgress(1, data);
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
            catch (Exception)
            {
                GUIHelper.MessageError("Nhập sai ngày!");
            }

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
            dateTimKiem.DateTime = DateTime.Now.Date;
        }
    }
}
