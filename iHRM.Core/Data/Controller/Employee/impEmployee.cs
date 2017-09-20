using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.Controller.Employee
{
    public class cMapping
    {
        public string c1 { get; set; }
        public string c1Text { get; set; }
        public string c2 { get; set; }
        public char dataType { get; set; }
    }

    public class impEmployee
    {
        #region cMapping
        public static List<cMapping> lstEmpMapping = new List<cMapping>()
            {
                new cMapping { c1 = "EmployeeID",                  c1Text = "ID",                      dataType = 's' },
                new cMapping { c1 = "EmployeeCode",                  c1Text = "Mã NV",                   dataType = 's' },
                new cMapping { c1 = "FirstName",                  c1Text = "First Name",                   dataType = 's' },
                new cMapping { c1 = "LastName",                  c1Text = "Last Name",                   dataType = 's' },
                new cMapping { c1 = "EmployeeName",               c1Text = "Họ và tên",               dataType = 's' },
                new cMapping { c1 = "CardID",               c1Text = "MÃ THẺ QUẸT",             dataType = 's' },
                new cMapping { c1 = "EmpTypeName",          c1Text = "Emp Type Name",             dataType = 's' },
                new cMapping { c1 = "EmpTypeDate",           c1Text = "Emp Type Date",               dataType = 'd' },
                new cMapping { c1 = "ContractTypeName",              c1Text = "Loại hợp đồng",                  dataType = 's' },
                new cMapping { c1 = "ContractDate",           c1Text = "Ngày hợp đồng",               dataType = 'd' },
                new cMapping { c1 = "AppliedDate",              c1Text = "Ngày gia nhập",                  dataType = 'd' },
                new cMapping { c1 = "LeftDate",           c1Text = "Ngày rời cty",               dataType = 'd' },
                new cMapping { c1 = "LeftTypeName",              c1Text = "Loại rời đi",                  dataType = 's' },
                new cMapping { c1 = "ReasonForLeft",           c1Text = "Lý do rời đi",               dataType = 's' },
                new cMapping { c1 = "Email",              c1Text = "Email",                  dataType = 's' },
                new cMapping { c1 = "Notes",           c1Text = "Ghi chú",               dataType = 's' },
                new cMapping { c1 = "Address",              c1Text = "Địa chỉ",                  dataType = 's' },
                new cMapping { c1 = "Phone",           c1Text = "Điện thoại",               dataType = 's' },
                new cMapping { c1 = "Mobile",           c1Text = "Di động",               dataType = 's' },
                new cMapping { c1 = "BankAccount",           c1Text = "Tài khoản NH",               dataType = 's' },
                new cMapping { c1 = "BankName",           c1Text = "Ngân hàng",               dataType = 's' },
                new cMapping { c1 = "RegionName",           c1Text = "RegionName",               dataType = 's' },
                new cMapping { c1 = "SectionName",           c1Text = "SectionName",               dataType = 's' },
                new cMapping { c1 = "ParentDepName",           c1Text = "Khối (nhóm phòng ban)",               dataType = 's' },
                new cMapping { c1 = "DepName",           c1Text = "Phòng ban",               dataType = 's' },
                new cMapping { c1 = "PosName",           c1Text = "Vị trí",               dataType = 's' },
                new cMapping { c1 = "NotesPos",           c1Text = "Gi chú chức vụ",               dataType = 's' },
                new cMapping { c1 = "BasicSalary",           c1Text = "Lương cơ bản",               dataType = 'f' },
                new cMapping { c1 = "RegularAllowance",           c1Text = "Phụ cấp thường xuyên",               dataType = 'f' },
                new cMapping { c1 = "SalaryTypeName",           c1Text = "SalaryTypeName",               dataType = 's' },
                new cMapping { c1 = "Birthday",           c1Text = "Birthday",               dataType = 'd' },
                new cMapping { c1 = "SexID",           c1Text = "Giới tính",               dataType = 's' },
                new cMapping { c1 = "IDCard",           c1Text = "Số CMND",               dataType = 's' },
                new cMapping { c1 = "IssuePlace",           c1Text = "Nơi cấp cmnd",               dataType = 's' },
                new cMapping { c1 = "IssueDate",           c1Text = "Ngày cấp cmnd",               dataType = 'd' },
                new cMapping { c1 = "NativeCountry",           c1Text = "Quê quán",               dataType = 's' },
                new cMapping { c1 = "PermanentAddress",           c1Text = "Địa chỉ thường trú",               dataType = 's' },
                new cMapping { c1 = "NationalityName",           c1Text = "Quốc tịch",               dataType = 's' },
                new cMapping { c1 = "MaritalStatusName",           c1Text = "Tình trạng hôn nhân",               dataType = 's' },
                new cMapping { c1 = "ReligionName",           c1Text = "Tôn giáo",               dataType = 's' },
                new cMapping { c1 = "SINo",           c1Text = "Sô sổ BHXH",               dataType = 's' },
                new cMapping { c1 = "SIFrom_MY",           c1Text = "Dâu đóng BHXH",               dataType = 'd' },
                new cMapping { c1 = "SIDate",           c1Text = "Ngày cấp BHXH",               dataType = 'd' },
                new cMapping { c1 = "SINo_DateChange",           c1Text = "Ngày đổi BHXH",               dataType = 'd' },
                new cMapping { c1 = "SIPlace",           c1Text = "Nơi cấp BHXH",               dataType = 's' },
                new cMapping { c1 = "HINo",           c1Text = "Số sổ BHYT",               dataType = 's' },
                new cMapping { c1 = "HIDate",           c1Text = "Ngày cấp BHYT",               dataType = 'd' },
                new cMapping { c1 = "HIFrom_MY",           c1Text = "Ngày bắt đầu",               dataType = 'd' },
                new cMapping { c1 = "HIPlace",           c1Text = "nơi cấp",               dataType = 's' },
                new cMapping { c1 = "ContractTypeID1",           c1Text = "Loại Hợp đồng đào tạo",               dataType = 's' },
                new cMapping { c1 = "BeginDate1",           c1Text = "Ngày bắt đầu hợp đồng đào tạo",               dataType = 'd' },
                new cMapping { c1 = "EndDate1",           c1Text = "Ngày kết thúc hợp đồng đào tạo",               dataType = 'd' },
                new cMapping { c1 = "ContractID1",           c1Text = "Mã hợp đồng đào tạo",               dataType = 's' },
                new cMapping { c1 = "luongcoban1",           c1Text = "Lương đào tạo",               dataType = 'f' },
                new cMapping { c1 = "phucap1",           c1Text = "Phụ cấp khác đào tạo",               dataType = 'f' },
                new cMapping { c1 = "ContractTypeID2",           c1Text = "Loại hợp đồng thử việc",               dataType = 's' },
                new cMapping { c1 = "BeginDate2",           c1Text = "Ngày bắt đầu hợp đồng thử việc",               dataType = 'd' },
                new cMapping { c1 = "EndDate2",           c1Text = "Ngày kết thúc hợp đồng thử việc",               dataType = 'd' },
                new cMapping { c1 = "ContractID2",           c1Text = "Mã hợp đồng thử việc",               dataType = 's' },
                new cMapping { c1 = "luongcoban2",           c1Text = "Lương thử việc",               dataType = 'f' },
                new cMapping { c1 = "phucap2",           c1Text = "Phụ cấp khác thử việc",               dataType = 'f' },
                new cMapping { c1 = "ContractTypeID3",           c1Text = "Loại hợp đồng chính thức",               dataType = 's' },
                new cMapping { c1 = "BeginDate3",           c1Text = "Ngày bắt đầu hợp đồng chính thức",               dataType = 'd' },
                new cMapping { c1 = "EndDate3",           c1Text = "Ngày kết thúc hợp đồng chính thức",               dataType = 'd' },
                new cMapping { c1 = "ContractID3",           c1Text = "Mã hợp đồng Chính thức",               dataType = 's' },
                new cMapping { c1 = "luongcoban3",           c1Text = "Lương chính thức",               dataType = 'f' },
                new cMapping { c1 = "phucap3",           c1Text = "Phụ cấp khác chính thức",               dataType = 'f' },
                new cMapping { c1 = "AnnualLeave",           c1Text = "Số ngày nghỉ phép",               dataType = 'f' },
                new cMapping { c1 = "InGroupName",           c1Text = "Nhóm",               dataType = 's' },
                new cMapping { c1 = "BankNameAcount",           c1Text = "Tên tài khoản",               dataType = 's' }
            };
        #endregion

        public static List<cMapping> listSTKNganHang = new List<cMapping>(){
            new cMapping { c1 = "EmployeeID",       c1Text = "Mã NV",                   dataType = 's' },
            new cMapping { c1 = "BankAccount",        c1Text = "Số TK",                   dataType = 's' },
            new cMapping { c1 = "BankNameAcount",     c1Text = "Tên tài khoản",           dataType = 's' },
            new cMapping { c1 = "BankName",           c1Text = "Ngân hàng",               dataType = 's' }
        };

    }
}
