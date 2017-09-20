using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iHRM.Core.Business.Logic.Luong;
using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using iHRM.Win.Frm.Employee;
using iHRM.Win.ExtClass.Contract;

namespace iHRM.Win.Frm.Employee
{
    public partial class InTheNhanVien : frmBase
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        DataTable Data = new DataTable();

        string actionPrint = "";
        public InTheNhanVien(string strPrint)
        {
            actionPrint = strPrint;
            InitializeComponent();

            if (strPrint == "the")
            {
                pnBienBanCC.Visible = false;
                this.Text = "In thẻ nhân viên";
                btnInThe.Text = "In thẻ";
            }
            if (strPrint == "hoso")
            {
                pnBienBanCC.Visible = false;
                this.Text = "In hồ sơ nhân viên";
                btnInThe.Text = "In hồ sơ";
            }
            if (strPrint == "hopdong")
            {
                rdGroupInHD.Visible = true;
                pnBienBanCC.Visible = false;
                this.Text = "In hợp đồng nhân viên";
                btnInThe.Text = "In hợp đồng";
            }
            if (strPrint == "thucanhcao")
            {
                ngayViPham.DateTime = ngayLapBB.DateTime = DateTime.Now;
                pnBienBanCC.Visible = true;
                rdGroupInHD.Visible = false;
                this.Text = "Thư cảnh cáo";
                btnInThe.Text = "In thư cảnh cáo";
            }
        }
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            // In thẻ : "the". In hồ sơ "hoso"
            List<string> _lEmpID = new List<string>();
            if (memoMaNV.Text != "")
            {
                _lEmpID = memoMaNV.Text.Split(',').ToList();
            }
            else
                _lEmpID = getEmpID();

            if (actionPrint == "the")
            {

                var dt_In = from emp in _lEmpID
                            join dt in Data.AsEnumerable() on emp.ToString() equals dt["EmployeeID"].ToString()
                            select new {
                                EmployeeID = dt["EmployeeID"],
                                EmployeeName = dt["EmployeeName"].ToString().ToUpper(),
                                EmpTypeName = dt["EmpTypeName"].ToString(),
                                DepName = dt["DepName"].ToString(),
                                LineName = dt["LineName"].ToString(),
                                AppliedDate = dt["AppliedDate"],
                                IDCard = dt["IDCard"].ToString()
                            };
                var rp = new iHRM.Win.ExtClass.rep_InTheNhanVien();
                rp.DataBindings(dt_In);
                ReportViewer rv = new ReportViewer();
                rv.ViewReport(rp);
            }
            if (actionPrint == "thucanhcao")
            {
                var dt_In = from emp in _lEmpID
                            join dt in Data.AsEnumerable() on emp.ToString() equals dt["EmployeeID"].ToString()
                            select dt;
                var rp = new iHRM.Win.ExtClass.Contract.ThuCanhCao();
                rp.paramNgayViPham.Value = ngayViPham.DateTime.ToString("dd/MM/yyyy");
                rp.paramNgayLapBB.Value = ngayLapBB.DateTime.ToString("dd/MM/yyyy");
                rp.BindingData(dt_In.CopyToDataTable());
                ReportViewer rv = new ReportViewer();
                rv.ViewReport(rp);
            }
            if (actionPrint == "quyetdinhthoiviec")
            {
                var dt_In = from emp in _lEmpID
                            join dt in Data.AsEnumerable() on emp.ToString() equals dt["EmployeeID"].ToString()
                            select dt;
                var rp = new iHRM.Win.ExtClass.General.QuyetDinhThoiViec();
                int manv = 0;
                foreach (DataRow row in dt_In)
                {
                    try
                    {
                        DateTime LeftDate = Convert.ToDateTime(row["LeftDate"]);
                        DateTime thongtinngay = Convert.ToDateTime(row["LeftDate"]).AddMonths(-1);
                        row["thongtinngay"] = string.Format("Nam Định, Ngày {0:00} tháng {1:00} năm {2:0000}", LeftDate.Day, LeftDate.Month, LeftDate.Year);
                        row["ngaytheodon"] = string.Format("{0:dd/MM/yyyy}", thongtinngay);
                        if (row["LeftDateReg"] != null  && row["LeftDateReg"].ToString() != null)
                        {
                            row["ngaytheodonYSS"] = string.Format("{0:dd/MM/yyyy}", row["LeftDateReg"]);
                        }
                        manv = Convert.ToInt32(row["EmployeeID"]);
                        row["SoQDNV"] = string.Format("Số: {0:00}/QĐNV-HRD", manv);
                    }
                    catch (Exception)
                    {
                    }
                }
                rp.DataBindings(dt_In.CopyToDataTable());
                ReportViewer rv = new ReportViewer();
                rv.ViewReport(rp);
            }
            if (actionPrint == "hoso")
            {
                var dt_In = from emp in _lEmpID
                            join dt in Data.AsEnumerable() on emp.ToString() equals dt["EmployeeID"].ToString()
                            select new
                            {
                                EmployeeID = dt["EmployeeID"],
                                EmployeeName = dt["EmployeeName"],
                                SexID = dt["SexID"],
                                Birthday = dt["Birthday"],
                                NativeCountry = dt["NativeCountry"],
                                IDCard = dt["IDCard"],
                                IssueDate = dt["IssueDate"],
                                IssuePlace = dt["IssuePlace"],
                                PermanentAddress = dt["PermanentAddress"],
                                Address = dt["Address"],
                                Phone = dt["Phone"],
                                MaritalStatusName = dt["MaritalStatusName"],
                                numChild = dt["numChild"],
                                EducationType = dt["EducationType"],
                                SINo = dt["SINo"],
                                SIDate = dt["SIDate"],
                                DepName = dt["DepName"],
                                SectionName = dt["SectionName"],
                                AppliedDate = dt["AppliedDate"],
                                PosName = dt["PosName"],
                                ContractDate = dt["ContractDate"],
                                BasicSalary = dt["BasicSalary"],
                                RegularAllowance = dt["RegularAllowance"]
                            };
                var rp = new rep_ThongTinNhanVien();
                rp.DataBindings(dt_In);
                ReportViewer rv = new ReportViewer();
                rv.ViewReport(rp);
            }
            if (actionPrint == "hopdong")
            {
                DataTable dt_In = new DataTable();
                dt_In = Data.Clone();
                foreach (string empID in _lEmpID)
                {
                    var a = Data.Select("EmployeeID = '" + empID + "'");
                    if (a.Count() > 0)
                    {
                        DataRow row = a.First();
                        dt_In.ImportRow(row);
                    }

                }
                if (rdGroupInHD.EditValue.ToString() == "0")
                {
                    var rp = new rep_InHopDongThuViec_CN();
                    dt_In = rp.addData(dt_In, rdGroupInHD.EditValue.ToString());
                    rp.BindingData(dt_In);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                else if (rdGroupInHD.EditValue.ToString() == "1")
                {
                    var rp = new rep_InHopDongThuViec_VP();
                    dt_In = rp.addData(dt_In, rdGroupInHD.EditValue.ToString());
                    rp.BindingData(dt_In);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                else if (rdGroupInHD.EditValue.ToString() == "2")
                {
                    var rp = new rep_InHopDong1nam_CN();
                    dt_In = rp.addData(dt_In, rdGroupInHD.EditValue.ToString());
                    rp.BindingData(dt_In);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                else if (rdGroupInHD.EditValue.ToString() == "3")
                {
                    var rp = new rep_InHopDong1nam_VP();
                    dt_In = rp.addData(dt_In, rdGroupInHD.EditValue.ToString());
                    rp.BindingData(dt_In);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                else if (rdGroupInHD.EditValue.ToString() == "4")
                {
                    var rp = new rep_InHopDongVoThoiHan_CN();
                    dt_In = rp.addData(dt_In, rdGroupInHD.EditValue.ToString());
                    rp.BindingData(dt_In);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
                else if (rdGroupInHD.EditValue.ToString() == "5")
                {
                    var rp = new rep_InHopDongVoThoiHan_VP();
                    dt_In = rp.addData(dt_In, rdGroupInHD.EditValue.ToString());
                    rp.BindingData(dt_In);
                    ReportViewer rv = new ReportViewer();
                    rv.ViewReport(rp);
                }
            }
        }

        private List<string> getEmpID()
        {
            List<string> _lEmpID = new List<string>();
            for (int i = 0; i < grvEmployee.RowCount; i++)
            {
                if (grvEmployee.GetRowCellValue(i, colCheck).ToString() == "True")
                {
                    _lEmpID.Add(grvEmployee.GetRowCellValue(i, colEmpID).ToString());
                }
            }
            return _lEmpID;
        }
        private void InCustomPhieuLuong_Load(object sender, EventArgs e)
        {
            //LoadGrvLayout(grvEmployee);
            List<Employee> _lObject = new List<Employee>();
            if (actionPrint == "the")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT e.EmployeeID,e.EmployeeName, e.PosName,e.AppliedDate,e.Birthday, e.IDCard, e.DepName,e.LineName,e.TeamName,EmpTypeName"
               + " FROM dbo.tblEmployee e where ISNULL(e.LeftDate,'') = '' "
               );
            }
            if (actionPrint == "thucanhcao")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT e.EmployeeID,e.EmployeeName, e.AppliedDate,e.Birthday, e.IDCard, e.DepName,e.LineName,e.TeamName,EmpTypeName"
               + " FROM dbo.tblEmployee e where ISNULL(e.LeftDate,'') = '' "
               );
            }
            if (actionPrint == "hoso")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL("SELECT * FROM dbo.tblEmployee");
            }
            if (actionPrint == "hopdong")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT * FROM dbo.tblEmployee"
                );
                Data.Columns.Add("TuNgay");
                Data.Columns.Add("DenNgay");
                Data.Columns.Add("TgTu");
                Data.Columns.Add("TgDen");
            }
            if (actionPrint == "quyetdinhthoiviec")
            {
                Data = iHRM.Core.Business.Provider.ExecuteDataTableReader_SQL(
                 "SELECT * FROM dbo.tblEmployee e where ISNULL(e.LeftDate,'') <> ''"
                );
                Data.Columns.Add("ngaytheodon");
                Data.Columns.Add("thongtinngay");
                Data.Columns.Add("ngaytheodonYSS");
                Data.Columns.Add("SoQDNV");
            }
            foreach (DataRow row in Data.Rows)
            {
                Employee newEmp = new Employee();
                newEmp.chkEmp = false;
                newEmp.EmployeeID = row["EmployeeID"].ToString();
                newEmp.EmployeeName = row["EmployeeName"].ToString();
                newEmp.IDCard = row["IDCard"].ToString();
                newEmp.DepName = row["DepName"].ToString();
                newEmp.AppliedDate = row["AppliedDate"] as DateTime?;
                newEmp.Birthday = row["Birthday"] as DateTime?;
                _lObject.Add(newEmp);
            }
            grcEmployee.DataSource = _lObject;
        }
        private class Employee
        {
            public bool chkEmp { get; set; }
            public string EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string IDCard { get; set; }
            public string DepName { get; set; }
            public DateTime? AppliedDate { get; set; }
            public DateTime? Birthday { get; set; }
        }
        //private void InCustomPhieuLuong_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //SaveGrvLayout(grvEmployee);
        //}
    }
}