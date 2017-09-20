using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using System.Linq;
using System.Data;

namespace iHRM.Win.ExtClass.Contract
{
    public partial class rep_InHopDong1nam_VP : DevExpress.XtraReports.UI.XtraReport
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public rep_InHopDong1nam_VP()
        {
            InitializeComponent();
            var hdld = db.tblHopDongLaoDongs.First();
            if (hdld != null)
            {
                paramtenGD.Value = hdld.tenGiamDoc;
                paramQuocTichGD.Value = hdld.QuocTichGiamDoc;
                paramChucVuGD.Value = hdld.ChucVuGD;
                paramDaiDien.Value = hdld.tenCongTy;
                paramSDTCongTy.Value = hdld.SDT;
                paramtenCongTy.Value = hdld.tenCongTy.ToUpper();
                paramDiaChiCongTy.Value = hdld.DiaChiCongTy;
                paramMaHD.Value = "/"+hdld.MaHopDong;
                paramNgaySinh.Value = hdld.NgaySinhGD;
                paramHoChieu.Value = hdld.HoChieuGD;
            }
        }
        public DataTable addData(DataTable data, string loaihopdong)
        {
            foreach (DataRow row in data.Rows)
            {
                string depID = row["DepID"].ToString();
                string depParent = db.tblRef_Departments.Where(p => p.DepID == depID).First().DepParent;
                if (db.tblRef_Departments.Where(p => p.DepID == depParent).First().DepName == "Khối văn phòng / Office")
                {
                    row["TgTu"] = "08:00 AM";
                    row["TgDen"] = "05:00 PM";
                }
                else
                {
                    row["TgTu"] = "07:30 AM";
                    row["TgDen"] = "04:30 PM";
                }
                if (row != null)
                {
                    string loaiHD = "";
                    tblEmpContract empCT = null;
                    if (loaihopdong == "0" || loaihopdong == "1")
                    {
                        loaiHD = "TV";
                        empCT = db.tblEmpContracts.Where(p => p.EmployeeID == row["EmployeeID"].ToString()
                                                        && p.ContractID != null && p.ContractID.Length > 2
                                                        && p.ContractID.Substring(0, 2).ToUpper() == "TV"
                                                   ).OrderByDescending(p => p.BeginDate).FirstOrDefault();
                    }
                    if (loaihopdong == "2" || loaihopdong == "3")
                    {
                        loaiHD = "CT";
                        empCT = db.tblEmpContracts.Where(p => p.EmployeeID == row["EmployeeID"].ToString()
                                                        && p.ContractID != null && p.ContractID.Length > 2
                                                        && p.ContractID.Substring(0, 2).ToUpper() == "CT"
                                                        && p.ContractTypeID == "05"
                                                   ).OrderByDescending(p => p.BeginDate).FirstOrDefault();
                    }

                    if (loaihopdong == "4" || loaihopdong == "5")
                    {
                        loaiHD = "CT";
                        empCT = db.tblEmpContracts.Where(p => p.EmployeeID == row["EmployeeID"].ToString()
                                                        && p.ContractID != null && p.ContractID.Length > 2
                                                        && p.ContractID.Substring(0, 2).ToUpper() == "CT"
                                                        && p.ContractTypeID == "14"
                                                   ).OrderByDescending(p => p.BeginDate).FirstOrDefault();
                    }
                    if (empCT != null)
                    {
                        row["TuNgay"] = empCT.BeginDate.ToString("dd/MM/yyyy");
                        row["DenNgay"] = empCT.EndDate.Value.ToString("dd/MM/yyyy");
                        tblEmpSalary empSal = db.tblEmpSalaries.Where(p => p.EmployeeID == row["EmployeeID"].ToString()
                                                                    && p.DateChange >= empCT.BeginDate
                                                                    && p.DateChange <= empCT.EndDate
                                                                    && p.ContractCode != null && p.ContractCode != ""
                                                                    && p.ContractCode.Length > 2
                                                                    && p.ContractCode.Substring(0, 2).ToUpper() == loaiHD
                                                                    ).OrderBy(p => p.DateChange).FirstOrDefault();
                        if (empSal != null)
	                    {
                            row["BasicSalary"] = empSal.BasicSalary;
	                    }
                    }
                }
            }
            return data;
        }
        public void BindingData(object dt) 
        {
            bindingSource1.DataSource = dt;

            lbMaNV.DataBindings.Add("Text", bindingSource1, "EmployeeID");
            lbNgay.DataBindings.Add("Text", bindingSource1, "TuNgay");
            lbNhanVien.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            lbQuocTichNV.DataBindings.Add("Text", bindingSource1, "NationalityName");
            lbNgaySinh.DataBindings.Add("Text", bindingSource1, "Birthday", "{0:dd/MM/yyyy}");
            lbDiaChiThuongTru.DataBindings.Add("Text", bindingSource1, "PermanentAddress");
            lbCMND.DataBindings.Add("Text", bindingSource1, "IDCard");
            lbNoiCap.DataBindings.Add("Text", bindingSource1, "IssuePlace");
            lbNgayCap.DataBindings.Add("Text", bindingSource1, "IssueDate", "{0:dd/MM/yyyy}");
            
            //Điều 1:
            lbTuNgay.DataBindings.Add("Text", bindingSource1, "TuNgay");
            lbDenNgay.DataBindings.Add("Text", bindingSource1, "DenNgay");
            lbChucDanh.DataBindings.Add("Text", bindingSource1, "PosName");
            lbBoPhan.DataBindings.Add("Text", bindingSource1, "DepName");
            //Điều 2:
            lbTuGio.DataBindings.Add("Text", bindingSource1, "TgTu");
            lbDenGio.DataBindings.Add("Text", bindingSource1, "TgDen");

            lbMucLuong.DataBindings.Add("Text", bindingSource1, "BasicSalary","{0:0,#}");
        }
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sexEmp = this.GetCurrentColumnValue("SexID").ToString();
            if (sexEmp == "Nam")
            {
                lbNu.Visible = true;
                lbNam.Visible = false;
            }
            if (sexEmp == "Nữ")
            {
                lbNu.Visible = false;
                lbNam.Visible = true;
            }
        }

    }
}
