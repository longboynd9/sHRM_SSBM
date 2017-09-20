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
    public partial class ReportNhanVienVangMat : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        global::iHRM.Core.Controller.Report.GetData controller = new global::iHRM.Core.Controller.Report.GetData();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        public ReportNhanVienVangMat()
        {
            InitializeComponent();
            object a = new object[]{ 
                                        new { value = 100, text = "Tất cả"},
                                        new { value = (int)iHRM.Common.Code.Enums.eLyDoNghi.NghiPhepNam, text = "Nghỉ phép năm"},
                                        new { value =(int)iHRM.Common.Code.Enums.eLyDoNghi.KetHon,text =  "Nghỉ kết hôn"}, 
                                        new { value =(int)iHRM.Common.Code.Enums.eLyDoNghi.MaChay,text =  "Nghỉ ma chay"},
                                        new {value =(int)iHRM.Common.Code.Enums.eLyDoNghi.CheDo,text = "Nghỉ chế độ"},

                                        new {value =(int)iHRM.Common.Code.Enums.eLyDoNghi.KhongLuong,text = "Nghỉ không lương"},
                                        new {value =(int)iHRM.Common.Code.Enums.eLyDoNghi.Om, text ="Nghỉ ốm"},
                                        new {value =(int)iHRM.Common.Code.Enums.eLyDoNghi.Khac,text = "Nghỉ khác"},
                                        new {value =(int)iHRM.Common.Code.Enums.eLyDoNghi.VangMat,text = "Nghỉ vắng mặt không lương"},
                                        new {value =(int)iHRM.Common.Code.Enums.eLyDoNghi.ThaiSan,text = "Nghỉ thai sản"}
                                   };
            lookupTimKiem.Properties.DataSource = a;
            lookupTimKiem.Properties.ValueMember = "value";
            lookupTimKiem.Properties.DisplayMember = "text";
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
                    int fieldSearch = Convert.ToInt16(lookupTimKiem.EditValue);
                    data = controller.GetReportNhanVienVangMat(day, todates, fieldSearch, chonPhongBan1.SelectedValue);
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
            ExportGrid(grd);
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
