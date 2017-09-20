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
    public partial class rep_InHopDongThuViec_VP : DevExpress.XtraReports.UI.XtraReport
    {
        dcDatabaseDataContext db = new dcDatabaseDataContext(Provider.ConnectionString);
        public rep_InHopDongThuViec_VP()
        {
            InitializeComponent();
            var hdld = db.tblHopDongLaoDongs.First();
            if (hdld != null)
            {
                paramtenGD.Value = hdld.tenGiamDoc;
                paramQuocTichGD.Value = hdld.QuocTichGiamDoc;
                paramChucVuGD.Value = hdld.ChucVuGD;
                paramDaiDien.Value = hdld.tenCongTy;
                paramtenCongTy.Value = hdld.tenCongTy.ToUpper();
                paramSDTCongTy.Value = hdld.SDT;
                paramDiaChiCongTy.Value = hdld.DiaChiCongTy;
                paramMaHD.Value = "/"+hdld.MaHopDong;
                paramDiaDiem.Value = hdld.DiaDiemLamViec;

                paramDiaDiem_Eng.Value = hdld.DiaDiemLamViec_Eng;
                paramtenGD_Eng.Value = hdld.tenGiamDoc_Eng;
                paramQuocTichGD_Eng.Value = hdld.QuocTichGiamDoc_Eng;
                paramChucVuGD_Eng.Value = hdld.ChucVuGD_Eng;
                paramDaiDien_Eng.Value = hdld.tenCongTy_Eng;
                paramDiaChiCongTy_Eng.Value = hdld.DiaChiCongTy_Eng;
            }
        }

        public DataTable addData(DataTable data, string loaihopdong)
        {
            foreach (DataRow row in data.Rows)
            {
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
                            row["RegularAllowance"] = empSal.BasicSalary_Ins;
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
            lbMaNV2.DataBindings.Add("Text", bindingSource1, "EmployeeID");
            lbNgay.DataBindings.Add("Text", bindingSource1, "TuNgay", "{0:dd/MM/yyyy}");
            lbNhanVien.DataBindings.Add("Text", bindingSource1, "EmployeeName");
            lbNhanVien_Eng.DataBindings.Add("Text", bindingSource1, "EmployeeName");

            lbQuocTich.DataBindings.Add("Text", bindingSource1, "NationalityName");
            lbQuocTich_Eng.DataBindings.Add("Text", bindingSource1, "NationalityName");

            lbNgaySinh.DataBindings.Add("Text", bindingSource1, "Birthday", "{0:dd/MM/yyyy}");
            lbNgaySinh_Eng.DataBindings.Add("Text", bindingSource1, "Birthday", "{0:dd/MM/yyyy}");
            lbDiaChiThuongTru.DataBindings.Add("Text", bindingSource1, "PermanentAddress");
            lbDiaChiThuongTru_Eng.DataBindings.Add("Text", bindingSource1, "PermanentAddress");
            lbCMND.DataBindings.Add("Text", bindingSource1, "IDCard");
            lbCMND_Eng.DataBindings.Add("Text", bindingSource1, "IDCard");
            lbNoiCap.DataBindings.Add("Text", bindingSource1, "IssuePlace");
            lbNoiCap_Eng.DataBindings.Add("Text", bindingSource1, "IssuePlace");
            lbCapNgay.DataBindings.Add("Text", bindingSource1, "IssueDate", "{0:dd/MM/yyyy}");
            lbCapNgay_Eng.DataBindings.Add("Text", bindingSource1, "IssueDate", "{0:dd/MM/yyyy}");
            
            //Điều 1:
            lbTuNgay.DataBindings.Add("Text", bindingSource1, "TuNgay");
            lbDenNgay.DataBindings.Add("Text", bindingSource1, "DenNgay");
            lbChucDanh.DataBindings.Add("Text", bindingSource1, "PosName");
            lbNgheNghiep.DataBindings.Add("Text", bindingSource1, "PosName");
            lbNgheNghiep_Eng.DataBindings.Add("Text", bindingSource1, "PosName_Eng");
            lbBoPhan.DataBindings.Add("Text", bindingSource1, "DepName");

            lbTuNgay_Eng.DataBindings.Add("Text", bindingSource1, "TuNgay");
            lbDenNgay_Eng.DataBindings.Add("Text", bindingSource1, "DenNgay");
            lbChucDanh_Eng.DataBindings.Add("Text", bindingSource1, "PosName_Eng");
            lbBoPhan_Eng.DataBindings.Add("Text", bindingSource1, "DepName_Eng");
            lbLuong.DataBindings.Add("Text", bindingSource1, "BasicSalary", "{0:0,#}");
            lbLuong_Eng.DataBindings.Add("Text", bindingSource1, "BasicSalary", "{0:0,#}");
            lbPhuCap.DataBindings.Add("Text", bindingSource1, "RegularAllowance", "{0:0,#}");
            lbPhuCap_Eng.DataBindings.Add("Text", bindingSource1, "RegularAllowance", "{0:0,#}");
        }

    }
}
