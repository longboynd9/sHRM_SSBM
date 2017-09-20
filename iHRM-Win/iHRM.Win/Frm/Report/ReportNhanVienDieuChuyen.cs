using DevExpress.XtraBars.Alerter;
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
    public partial class ReportNhanVienDieuChuyen : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        global::iHRM.Core.Business.Logic.Report.BaoCao logic = new global::iHRM.Core.Business.Logic.Report.BaoCao();
        iHRM.Core.Controller.Report.GetData control = new Core.Controller.Report.GetData();
        public ReportNhanVienDieuChuyen()
        {
            InitializeComponent();
            //dateNgay.DateTime = DateTime.Now.Date;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            #region
            //mainBase.Dowork_Item dw_it = new mainBase.Dowork_Item();
            //dw_it.Caption = "Đang tải dữ liệu ..."; //text hiện ở status
            //dw_it.OnDoing = (s,ev) => //hàm lấy dữ liệu chạy ngầm
            //{
            //    string DepID = control.getPhongBan(chonPhongBan1.SelectedValue, db);
            //    DateTime day = dateNgay.DateTime;
            //    var data = new DataTable();
            //    if (day != null)
            //    {
            //        data = logic.GetReportNVSapHetHopDong(day, DepID, chkHdCuoi.Checked);
            //        if (data.Rows.Count > 0)
            //        {
            //            dw_it.bw.ReportProgress(1, data.AsEnumerable().OrderBy(p => p["DepName"]).CopyToDataTable());
            //        }
            //        else
            //        {
            //            dw_it.bw.ReportProgress(-1, "Không có dữ liệu");
            //            dw_it.bw.ReportProgress(1, data);
            //        }
            //    }

            //};
            //dw_it.OnProcessing = (ps, data) => //hàm report //khi lấy đc dữ liệu sẽ đẩy về đây xử lý //có thể đẩy về nhiều lần từ doing
            //{
            //    switch (data.ProgressPercentage)
            //    {
            //        case 1:
            //            grd.DataSource = data;
            //            break;
            //    }
            //};
            //main.Instance.DoworkItem_Reg(dw_it);
            #endregion
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable data = logic.GetReportNVThayDoiMucLuong(chonKyLuong1.TuNgay, chonKyLuong1.DenNgay, chonPhongBan1.SelectedValue == null ? "" : chonPhongBan1.SelectedValue);
            DataTable dtData = new DataTable();
            dtData.Columns.AddRange(("EmployeeID,EmployeeName,DepName,IDCard"
            + ",PosName1,ContractCode1,PosName2,ContractCode2"
            + ",PosName3,ContractCode3,PosName4,ContractCode4"
            + ",PosName5,ContractCode5,PosName6,ContractCode6"
            + ",PosName7,ContractCode7,PosName8,ContractCode8"
            ).Split(',').Select(p => new DataColumn(p)).ToArray());
            dtData.Columns.AddRange(("DateChange1,BeginDate1,EndDate1,DateChange2,BeginDate2,EndDate2"
            + ",DateChange3,BeginDate3,EndDate3,DateChange4,BeginDate4,EndDate4"
            + ",DateChange5,BeginDate5,EndDate5,DateChange6,BeginDate6,EndDate6"
            + ",DateChange7,BeginDate7,EndDate7,DateChange8,BeginDate8,EndDate8"
            ).Split(',').Select(p => new DataColumn(p, typeof(DateTime))).ToArray());
            dtData.Columns.AddRange(("BasicSalary1,BasicSalary_Ins1,BasicSalary2,BasicSalary_Ins2"
            + ",BasicSalary3,BasicSalary_Ins3,BasicSalary4,BasicSalary_Ins4"
            + ",BasicSalary5,BasicSalary_Ins5,BasicSalary6,BasicSalary_Ins6,"
            + ",BasicSalary7,BasicSalary_Ins7,BasicSalary8,BasicSalary_Ins8"
            ).Split(',').Select(p => new DataColumn(p, typeof(double))).ToArray());
            int demChange = 1;
            foreach (DataRow item in data.Rows)
            {
                if (dtData.Select("EmployeeID = '" + item["EmployeeID"].ToString() + "'").ToList().Count() == 0)
                {
                    demChange = 1;
                    DataRow row = dtData.NewRow();
                    row["EmployeeID"] = item["EmployeeID"];
                    row["EmployeeName"] = item["EmployeeName"];
                    row["DepName"] = item["DepName"];
                    row["IDCard"] = item["IDCard"];
                    row["DateChange" + demChange] = item["DateChange"];
                    if (item["BeginDate"].ToString() != "")
                    {
                        row["BeginDate" + demChange] = item["BeginDate"];
                    }
                    if (item["EndDate"].ToString() != "")
                    {
                        row["EndDate" + demChange] = item["EndDate"];
                    }
                    if (item["BasicSalary"].ToString() != "")
                    {
                        row["BasicSalary" + demChange] = item["BasicSalary"];
                    }
                    if (item["BasicSalary_Ins"].ToString() != "")
                    {
                        row["BasicSalary_Ins" + demChange] = item["BasicSalary_Ins"];
                    }
                    row["PosName" + demChange] = item["PosName"];
                    row["ContractCode" + demChange] = item["ContractCode"];
                    dtData.Rows.Add(row);
                }
                else
                {
                    demChange++;
                    DataRow row = dtData.Select("EmployeeID = '" + item["EmployeeID"].ToString() + "'").First();
                    row["DateChange" + demChange] = item["DateChange"];
                    if (item["BeginDate"].ToString() != "")
                    {
                        row["BeginDate" + demChange] = item["BeginDate"];
                    }
                    if (item["EndDate"].ToString() != "")
                    {
                        row["EndDate" + demChange] = item["EndDate"];
                    }
                    if (item["BasicSalary"].ToString() != "")
                    {
                        row["BasicSalary" + demChange] = item["BasicSalary"];
                    }
                    if (item["BasicSalary_Ins"].ToString() != "")
                    {
                        row["BasicSalary_Ins" + demChange] = item["BasicSalary_Ins"];
                    }
                    row["PosName" + demChange] = item["PosName"];
                    row["ContractCode" + demChange] = item["ContractCode"];
                }
            }
            if (dtData.Rows.Count > 0)
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
                ExcelExportHelper ex = new ExcelExportHelper("Report/Report_NVDieuChuyen.xls");
                ex.WriteToCell("A5", "Từ ngày" + chonKyLuong1.TuNgay.Date.ToString("dd/MM/yyyy") + " đến ngày " + chonKyLuong1.DenNgay.Date.ToString("dd/MM/yyyy"));

                ex.FillDataTable(dtData);
                ex.RendAndFlush("ReportNVDieuChuyen_" + DbHelper.DrGetString(LoginHelper.Dept, "code"), sd.FileName);
                var c = GUIHelper.Notifications("Xuất thành công, Click để mở", this.Text, GUIHelper.NotifiType.tick);
                c.AlertClick += (s1, e1) =>
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = sd.FileName,
                        UseShellExecute = true
                    });
                };
            }
        }
    }
}
