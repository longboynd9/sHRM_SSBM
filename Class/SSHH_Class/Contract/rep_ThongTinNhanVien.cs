using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iHRM.Core.Business.DbObject;
using System.Collections.Generic;
using iHRM.Core.Business;
using System.Data.Linq;
using System.Linq;

namespace iHRM.Win.ExtClass.Contract
{
    public partial class rep_ThongTinNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        Table<tblEmpSalary> dtEmpSalary;
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public rep_ThongTinNhanVien()
        {
            InitializeComponent();
            dtEmpSalary = db.tblEmpSalaries;
            var hdld = db.tblHopDongLaoDongs.First();
            if (hdld != null)
            {
                paramTenCongTy.Value = hdld.tenCongTy.ToUpper();
            }
        }
        public void DataBindings(object dataSource)
        {
            // Thông tin cá nhân
            lbEmpID.DataBindings.Add("Text", null, "EmployeeID");
            colHoTen.DataBindings.Add("Text", null, "EmployeeName");
            colGioiTinh.DataBindings.Add("Text", null, "SexID");
            colNgaySinh.DataBindings.Add("Text", null, "Birthday").FormatString = "{0:dd/MM/yyyy}";
            colNoiSinh.DataBindings.Add("Text", null, "NativeCountry");
            //colDanToc.DataBindings.Add("Text", null, "EmployeeName");
            colCMND.DataBindings.Add("Text", null, "IDCard");
            colNgayCap.DataBindings.Add("Text", null, "IssueDate").FormatString = "{0:dd/MM/yyyy}";
            colNoiCap.DataBindings.Add("Text", null, "IssuePlace");
            colDCThuongTru.DataBindings.Add("Text", null, "PermanentAddress");
            colDCTamTru.DataBindings.Add("Text", null, "Address");

            colDienThoai.DataBindings.Add("Text", null, "Phone");
            //colNguoiLienLacKC.DataBindings.Add("Text", null, "EmployeeName");
            colTinhTrangHonNhan.DataBindings.Add("Text", null, "MaritalStatusName");
            colSoConHienCo.DataBindings.Add("Text", null, "numChild").FormatString = "{0:#,0}";
            colTrinhDoHocVan.DataBindings.Add("Text", null, "EducationType");
            colSoBHXH.DataBindings.Add("Text", null, "SINo");
            colNgayDangKyBHXH.DataBindings.Add("Text", null, "SIDate").FormatString = "{0:dd/MM/yyyy}";
            // Phân công công tác
            colPhongBan.DataBindings.Add("Text", null, "DepName");
            colNgayVao.DataBindings.Add("Text", null, "AppliedDate").FormatString = "{0:dd/MM/yyyy}";
            colSection.DataBindings.Add("Text", null, "SectionName");
            colChucVu.DataBindings.Add("Text", null, "PosName");
            colNgayKyHĐ.DataBindings.Add("Text", null, "ContractDate").FormatString = "{0:dd/MM/yyyy}";
            colLuongCB.DataBindings.Add("Text", null, "BasicSalary").FormatString = "{0:#,0}";
            //colPhuCapTayNghe.DataBindings.Add("Text", null, "EmployeeName").FormatString = "#,0";
            colPhuCap.DataBindings.Add("Text", null, "RegularAllowance").FormatString = "{0:#,0}";

            colDateChange_PB.DataBindings.Add("Text", null, "DateChange").FormatString = "{0:dd/MM/yyyy}";
            colPhongBan_PB.DataBindings.Add("Text", null, "DepName");
            colGhiChu_PB.DataBindings.Add("Text", null, "Notes");

            colDateChange_QT.DataBindings.Add("Text", null, "DateChange").FormatString = "{0:dd/MM/yyyy}";
            colChucDanh_QT.DataBindings.Add("Text", null, "PosName");
            colLuongCB_QT.DataBindings.Add("Text", null, "BasicSalary").FormatString = "{0:#,0}";
            colPhuCap_QT.DataBindings.Add("Text", null, "BasicSalary_Ins").FormatString = "{0:#,0}";
            colTuNgay_QT.DataBindings.Add("Text", null, "BeginDate").FormatString = "{0:dd/MM/yyyy}";
            colDenNgay_QT.DataBindings.Add("Text", null, "EndDate").FormatString = "{0:dd/MM/yyyy}";
            colLyDo_QT.DataBindings.Add("Text", null, "Notes");

            

            bindingSource1.DataSource = dataSource;
        }
        public void BindingsQuaTrinh(object dtSource)
        {
            // Quá trình làm việc
            bindingSource2.DataSource = dtSource;
        }
        public void BindingsQuaTrinh_PB(object dtSource)
        {
            // Quá trình phòng ban làm việc
            bindingSource3.DataSource = dtSource;
        }
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DetailBand detailBand = (DetailBand)sender;
            string empID = detailBand.Report.GetCurrentColumnValue("EmployeeID").ToString();
            if (empID != "")
            {
                var a = dtEmpSalary.Where(p => p.EmployeeID == empID).Join(db.tblRef_Positions, p1 => p1.PosID, p2 => p2.PosID, (p1, p2) => new
                {
                    p1.PosID,
                    p2.PosName,
                    p1.Notes,
                    p1.BasicSalary,
                    p1.BasicSalary_Ins,
                    p1.BeginDate,
                    p1.EndDate,
                    p1.EmployeeID,
                    p1.DateChange
                }).OrderBy(p => p.DateChange);
                //.Where(p => p.EmployeeID == empID).OrderBy(p => p.DateChange);
                BindingsQuaTrinh(a);
                var b = (from ed in db.tblEmpDeps.Where(p => p.EmployeeID == empID)
                         join dp in db.tblRef_Departments on ed.DepID equals dp.DepID
                         select new
                         {
                             ed.DepID,
                             ed.Notes,
                             dp.DepName,
                             ed.DateChange
                         }).ToList().OrderBy(p=>p.DateChange);
                BindingsQuaTrinh_PB(b);
            }
            //if ((currentPage + 1) % RowsPerPage == 0)
            //    (sender as DetailBand).PageBreak = PageBreak.AfterBand;
            //else
            //    (sender as DetailBand).PageBreak = PageBreak.None;
        }

    }
}
