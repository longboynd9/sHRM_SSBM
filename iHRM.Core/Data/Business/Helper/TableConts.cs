
namespace iHRM.Core.Business
{
    public class TableConst
    {
        public class w5sysRole
        {
            public static string TableName = "w5sysRole";
            public const string id = "id"; public const string code = "code"; public const string caption = "caption"; public const string description = "description"; public const string status = "status";
        }

        public class tblRef_LanguageLevel
        {
            public static string TableName = "tblRef_LanguageLevel";
            public const string LangLevelID = "LangLevelID"; public const string LangLevelName = "LangLevelName";
        }

        public class tblRef_LanguageSkill
        {
            public static string TableName = "tblRef_LanguageSkill";
            public const string LangSkill = "LangSkill"; public const string LangSkillName = "LangSkillName";
        }

        public class tblEmpAllowanceFix
        {
            public static string TableName = "tblEmpAllowanceFix";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string DateChange = "DateChange"; public const string AllowanceID = "AllowanceID"; public const string Amount = "Amount"; public const string Notes = "Notes"; public const string CurrType = "CurrType";
        }

        public class tblRef_Education
        {
            public static string TableName = "tblRef_Education";
            public const string EducationID = "EducationID"; public const string EducationType = "EducationType";
        }

        public class tbDangKyVangMat
        {
            public static string TableName = "tbDangKyVangMat";
            public const string id = "id"; public const string idKetQuaQuetThe = "idKetQuaQuetThe"; public const string ngay = "ngay"; public const string tuGio = "tuGio"; public const string denGio = "denGio"; public const string lydo = "lydo"; public const string ghiChu = "ghiChu"; public const string nghiCaNgay = "nghiCaNgay"; public const string EmployeeID = "EmployeeID"; public const string coHuongLuong = "coHuongLuong"; public const string hourLeave = "hourLeave"; public const string soTiengTinhCa = "soTiengTinhCa"; public const string coTinhChuyenCan = "coTinhChuyenCan";
        }

        public class tblRef_Qualification
        {
            public static string TableName = "tblRef_Qualification";
            public const string QualificationID = "QualificationID"; public const string QualificationName = "QualificationName";
        }

        public class tblRef_Relation
        {
            public static string TableName = "tblRef_Relation";
            public const string RelationID = "RelationID"; public const string RelationName = "RelationName";
        }

        public class w5NguoiDung
        {
            public static string TableName = "w5NguoiDung";
            public const string id = "id"; public const string TenDangNhap = "TenDangNhap"; public const string MatKhauDangNhap = "MatKhauDangNhap"; public const string TaiKhoanGoogle = "TaiKhoanGoogle"; public const string TaiKhoanFacebook = "TaiKhoanFacebook"; public const string Ten = "Ten"; public const string Ten_en = "Ten_en"; public const string AnhDaiDien = "AnhDaiDien"; public const string DiaChi = "DiaChi"; public const string DiaChi_en = "DiaChi_en"; public const string email = "email"; public const string NgaySinh = "NgaySinh"; public const string GioiTinh = "GioiTinh"; public const string SDT = "SDT"; public const string NguoiGioiThieu = "NguoiGioiThieu"; public const string GhiChu = "GhiChu"; public const string TrangThai = "TrangThai"; public const string Quyen = "Quyen"; public const string GiftCard = "GiftCard"; public const string SoTienTrongCard = "SoTienTrongCard"; public const string NgayDangKy = "NgayDangKy"; public const string website = "website"; public const string TinhTP = "TinhTP"; public const string QuanHuyen = "QuanHuyen";
        }

        public class tblRef_StatusEmployee
        {
            public static string TableName = "tblRef_StatusEmployee";
            public const string StatusID = "StatusID"; public const string StatusName = "StatusName";
        }

        public class tblRef_Company
        {
            public static string TableName = "tblRef_Company";
            public const string CompanyID = "CompanyID"; public const string CompKey = "CompKey"; public const string CompKey_Prin = "CompKey_Prin"; public const string CompanyName = "CompanyName"; public const string TransName = "TransName"; public const string CompanyCode = "CompanyCode"; public const string Address = "Address"; public const string Phone = "Phone"; public const string Fax = "Fax"; public const string VATCode = "VATCode"; public const string BankAccount = "BankAccount"; public const string BankAccount_USD = "BankAccount_USD"; public const string BankName = "BankName"; public const string Accountant = "Accountant"; public const string Director = "Director"; public const string Nationality_Director = "Nationality_Director"; public const string PreparedBy = "PreparedBy"; public const string PreparedBy_Payroll = "PreparedBy_Payroll"; public const string PreparedBy_Insurance = "PreparedBy_Insurance"; public const string PreparedBy_Attendance = "PreparedBy_Attendance"; public const string CheckedBy = "CheckedBy"; public const string CheckedBy2 = "CheckedBy2"; public const string President = "President"; public const string ManageLevel = "ManageLevel"; public const string FileNo = "FileNo"; public const string KCBNo = "KCBNo";
        }

        public class tbKetQuaQuetThe
        {
            public static string TableName = "tbKetQuaQuetThe";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string Emp_LeftDate = "Emp_LeftDate"; public const string CardID = "CardID"; public const string ngay = "ngay"; public const string idCaLam = "idCaLam"; public const string tgQuetDen = "tgQuetDen"; public const string tgQuetVe = "tgQuetVe"; public const string tgQuetDen_old = "tgQuetDen_old"; public const string tgQuetVe_old = "tgQuetVe_old"; public const string tgDiMuon = "tgDiMuon"; public const string tgVeSom = "tgVeSom"; public const string tgTinhTangCa = "tgTinhTangCa"; public const string dkLamThem = "dkLamThem"; public const string heSoLuong = "heSoLuong"; public const string kqNgayCong = "kqNgayCong"; public const string status = "status"; public const string tt_ok = "tt_ok"; public const string tt_leTet = "tt_leTet"; public const string tt_diMuonVeSom = "tt_diMuonVeSom"; public const string tt_nghiPhep = "tt_nghiPhep"; public const string tt_coQuetTay = "tt_coQuetTay"; public const string tt_nghiPhep_Alias = "tt_nghiPhep_Alias"; public const string tt_chuNhat = "tt_chuNhat"; public const string tt_error = "tt_error"; public const string modifyDate = "modifyDate"; public const string modifyBy = "modifyBy"; public const string analyzeDate = "analyzeDate"; public const string analyzeBy = "analyzeBy"; public const string isLocked = "isLocked";
        }

        public class tblRef_Department
        {
            public static string TableName = "tblRef_Department";
            public const string DepID = "DepID"; public const string DepKey = "DepKey"; public const string DepName = "DepName"; public const string DepName_Eng = "DepName_Eng"; public const string DepParent = "DepParent"; public const string DepTypeID = "DepTypeID"; public const string Direct = "Direct"; public const string Notes = "Notes"; public const string BasicWD = "BasicWD"; public const string OrderNo = "OrderNo"; public const string CenterCode = "CenterCode"; public const string MealSection = "MealSection"; public const string Rpt_Dep = "Rpt_Dep"; public const string Rpt_Line = "Rpt_Line"; public const string Rpt_Group = "Rpt_Group"; public const string Path = "Path";
        }

        public class tblEmployee
        {
            public static string TableName = "tblEmployee";
            public const string EmployeeID = "EmployeeID"; public const string EmployeeCode = "EmployeeCode"; public const string FirstName = "FirstName"; public const string LastName = "LastName"; public const string EmployeeName = "EmployeeName"; public const string CardID = "CardID"; public const string EmpTypeID = "EmpTypeID"; public const string EmpTypeName = "EmpTypeName"; public const string EmployedDate = "EmployedDate"; public const string ContractTypeName = "ContractTypeName"; public const string ContractDate = "ContractDate"; public const string TempMonth = "TempMonth"; public const string TempEndDate = "TempEndDate"; public const string SI = "SI"; public const string SINo = "SINo"; public const string SIDate = "SIDate"; public const string SIFrom_MY = "SIFrom_MY"; public const string SIPlace = "SIPlace"; public const string IssuedSI = "IssuedSI"; public const string ReserveSIBook = "ReserveSIBook"; public const string SITo_MY = "SITo_MY"; public const string Reason_Reserve = "Reason_Reserve"; public const string TransferToPlace = "TransferToPlace"; public const string TransferSIBook = "TransferSIBook"; public const string SINo_Old = "SINo_Old"; public const string SINo_DateChange = "SINo_DateChange"; public const string HI = "HI"; public const string HINo = "HINo"; public const string HIDate = "HIDate"; public const string HIIssueAt = "HIIssueAt"; public const string HIFrom_MY = "HIFrom_MY"; public const string HIPlace = "HIPlace"; public const string Labor = "Labor"; public const string LaborNo = "LaborNo"; public const string LaborDate = "LaborDate"; public const string LaborPlace = "LaborPlace"; public const string TradeUnionMember = "TradeUnionMember"; public const string TradeUnionDate = "TradeUnionDate"; public const string TradeUnionFee = "TradeUnionFee"; public const string SubmitDate = "SubmitDate"; public const string LeftDate = "LeftDate"; public const string LeftTypeID = "LeftTypeID"; public const string LeftTypeName = "LeftTypeName"; public const string ReasonForLeft = "ReasonForLeft"; public const string DecisionNo = "DecisionNo"; public const string TransferReportNo = "TransferReportNo"; public const string FinalPaymentDate = "FinalPaymentDate"; public const string Email = "Email"; public const string Notes = "Notes"; public const string BankAccount = "BankAccount"; public const string BankID = "BankID"; public const string RegionID = "RegionID"; public const string RegionName = "RegionName"; public const string SubRegionID = "SubRegionID"; public const string SubRegionName = "SubRegionName"; public const string CompanyID = "CompanyID"; public const string CompanyName = "CompanyName"; public const string SectionID = "SectionID"; public const string SectionName = "SectionName"; public const string LineID = "LineID"; public const string LineName = "LineName"; public const string DepID = "DepID"; public const string DepName = "DepName"; public const string TeamID = "TeamID"; public const string TeamName = "TeamName"; public const string PartID = "PartID"; public const string PartName = "PartName"; public const string PosID = "PosID"; public const string PosName = "PosName"; public const string BasicSalary = "BasicSalary"; public const string SalLevelID = "SalLevelID"; public const string SalaryTypeName = "SalaryTypeName"; public const string BasicSalaryUSD = "BasicSalaryUSD"; public const string RegularAllowance = "RegularAllowance"; public const string RegularAllowanceUSD = "RegularAllowanceUSD"; public const string WD = "WD"; public const string AppliedDate = "AppliedDate"; public const string Heath_Date = "Heath_Date"; public const string Heath_Reult = "Heath_Reult"; public const string OT = "OT"; public const string OldEmployeeID = "OldEmployeeID"; public const string IsForeigner = "IsForeigner"; public const string HasATMCard = "HasATMCard"; public const string HasFinalPayment = "HasFinalPayment"; public const string BankAccount_USD = "BankAccount_USD"; public const string IsMaternity = "IsMaternity"; public const string FinalPaymentMonth = "FinalPaymentMonth"; public const string FinalPaymentYear = "FinalPaymentYear"; public const string LastPayrollMonth = "LastPayrollMonth"; public const string LastPayrollYear = "LastPayrollYear"; public const string StatusID = "StatusID"; public const string Birthday = "Birthday"; public const string MaritalStatusID = "MaritalStatusID"; public const string SexID = "SexID"; public const string IDCard = "IDCard"; public const string IssuePlace = "IssuePlace"; public const string Address = "Address"; public const string Phone = "Phone"; public const string IssueDate = "IssueDate"; public const string EmployeeName_Eng = "EmployeeName_Eng"; public const string PITCode = "PITCode"; public const string IsNotOT = "IsNotOT"; public const string LeftDateReg = "LeftDateReg"; public const string RaceName = "RaceName"; public const string Mobile = "Mobile"; public const string NativeCountry = "NativeCountry"; public const string NationalityName = "NationalityName"; public const string MaritalStatusName = "MaritalStatusName"; public const string ReligionName = "ReligionName"; public const string NameSearch = "NameSearch"; public const string LinkImage = "LinkImage"; public const string AnnualLeave = "AnnualLeave"; public const string coBH = "coBH"; public const string coBH_ngay = "coBH_ngay"; public const string PermanentAddress = "PermanentAddress"; public const string InGroup1 = "InGroup1"; public const string BankName = "BankName"; public const string BankNameAcount = "BankNameAcount"; public const string ContractTypeID = "ContractTypeID"; public const string ContractID = "ContractID"; public const string EducationID = "EducationID"; public const string EducationType = "EducationType"; public const string NationalityID = "NationalityID"; public const string mailCongTy = "mailCongTy"; public const string mailNgoai = "mailNgoai"; public const string dis = "dis"; public const string statePushServer = "statePushServer"; public const string SoNguoiPhuThuoc = "SoNguoiPhuThuoc"; 
        }

        public class tbCatDefine
        {
            public static string TableName = "tbCatDefine";
            public const string id = "id"; public const string tableName = "tableName"; public const string caption = "caption"; public const string idColumnName = "idColumnName"; public const string columnIdEditType = "columnIdEditType"; public const string autoExpanColumnName = "autoExpanColumnName"; public const string inGroup = "inGroup"; public const string sortIdx = "sortIdx";
        }

        public class w5sysParameter
        {
            public static string TableName = "w5sysParameter";
            public const string id = "id"; public const string code = "code"; public const string caption = "caption"; public const string value = "value"; public const string visible = "visible";
        }

        public class tbNhanVien
        {
            public static string TableName = "tbNhanVien";
            public const string idNV = "idNV"; public const string idCuaHang = "idCuaHang"; public const string maNV = "maNV"; public const string ho = "ho"; public const string ten = "ten"; public const string tendaydu = "tendaydu"; public const string ten_khongdau = "ten_khongdau"; public const string logo = "logo"; public const string gioiTinh = "gioiTinh"; public const string diaChi = "diaChi"; public const string dienThoai = "dienThoai"; public const string email = "email"; public const string ngaySinh = "ngaySinh"; public const string ghiChu = "ghiChu"; public const string status = "status"; public const string quyenTrenKho = "quyenTrenKho";
        }

        public class tbDuLieuQuetThe
        {
            public static string TableName = "tbDuLieuQuetThe";
            public const string thoigian = "thoigian"; public const string maThe = "maThe"; public const string soMay = "soMay"; public const string maMay = "maMay";
        }

        public class tblRef_Position
        {
            public static string TableName = "tblRef_Position";
            public const string PosID = "PosID"; public const string PosName = "PosName"; public const string WDInMonth = "WDInMonth"; public const string PosName_VN = "PosName_VN"; public const string RankID = "RankID"; public const string OrderNo = "OrderNo"; public const string Advance_Percent = "Advance_Percent"; public const string DescriptionJob = "DescriptionJob"; public const string IsNotOT = "IsNotOT";
        }

        public class tbKho
        {
            public static string TableName = "tbKho";
            public const string idKho = "idKho"; public const string maKho = "maKho"; public const string tenKho = "tenKho"; public const string logo = "logo"; public const string nguoiDaiDien = "nguoiDaiDien"; public const string diachi = "diachi"; public const string dienthoai = "dienthoai"; public const string ghichu = "ghichu";
        }

        public class tblRef_Title
        {
            public static string TableName = "tblRef_Title";
            public const string TitleID = "TitleID"; public const string TitleName = "TitleName"; public const string Notes = "Notes";
        }

        public class tbLyDoVangMat
        {
            public static string TableName = "tbLyDoVangMat";
            public const string id = "id"; public const string lydo = "lydo";
        }

        public class w5sysRule
        {
            public static string TableName = "w5sysRule";
            public const string roleID = "roleID"; public const string functionID = "functionID"; public const string rules = "rules"; public const string status = "status";
        }

        public class w5DanhMuc
        {
            public static string TableName = "w5DanhMuc";
            public const string id = "id"; public const string sysCode = "sysCode"; public const string DanhMucChaID = "DanhMucChaID"; public const string Ma = "Ma"; public const string Ten = "Ten"; public const string Ten_en = "Ten_en"; public const string AnhDaiDien = "AnhDaiDien"; public const string STT = "STT"; public const string GhiChu = "GhiChu"; public const string Link = "Link"; public const string TrangThai = "TrangThai"; public const string DaKhoa = "DaKhoa"; public const string DuongDan = "DuongDan"; public const string laDacBiet = "laDacBiet"; public const string Vitri = "Vitri";
        }

        public class tbNgayNghiPhepNam
        {
            public static string TableName = "tbNgayNghiPhepNam";
            public const string id = "id"; public const string ngay = "ngay"; public const string thang = "thang"; public const string nam = "nam"; public const string ten = "ten";
        }

        public class tblEmp_Group1
        {
            public static string TableName = "tblEmp_Group1";
            public const string id = "id"; public const string gName = "gName";
        }

        public class w5System
        {
            public static string TableName = "w5System";
            public const string id = "id"; public const string Ma = "Ma"; public const string TitleVN = "TitleVN"; public const string TitleEN = "TitleEN"; public const string KeywordVN = "KeywordVN"; public const string KeywordEN = "KeywordEN"; public const string DescriptionVN = "DescriptionVN"; public const string DescriptionEN = "DescriptionEN";
        }

        public class tbBangLuongCalc
        {
            public static string TableName = "tbBangLuongCalc";
            public const string id = "id"; public const string fieldName = "fieldName"; public const string caption = "caption"; public const string expression = "expression";
        }

        public class tblRef_ContractType
        {
            public static string TableName = "tblRef_ContractType";
            public const string ContractTypeID = "ContractTypeID"; public const string ContractTypeName = "ContractTypeName"; public const string MonthNumber = "MonthNumber"; public const string ContractName_VN = "ContractName_VN";
        }

        public class w5sysEmail
        {
            public static string TableName = "w5sysEmail";
            public const string Mail_ID = "Mail_ID"; public const string SMTPServer = "SMTPServer"; public const string SMTPServerPort = "SMTPServerPort"; public const string SMTPServerName = "SMTPServerName"; public const string SMTPServerPassword = "SMTPServerPassword"; public const string ListMail = "ListMail";
        }

        public class tbDkCaMacDinh
        {
            public static string TableName = "tbDkCaMacDinh";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string CardID = "CardID"; public const string idCaLam = "idCaLam"; public const string heSoLuong = "heSoLuong"; public const string chuNhat = "chuNhat";
        }

        public class tblRef_Allowance
        {
            public static string TableName = "tblRef_Allowance";
            public const string AllowanceID = "AllowanceID"; public const string AllowanceName = "AllowanceName"; public const string Regular = "Regular"; public const string IncomeTax = "IncomeTax"; public const string AllowanceName_VN = "AllowanceName_VN"; public const string NotInPayroll = "NotInPayroll";
        }

        public class w5sysUser
        {
            public static string TableName = "w5sysUser";
            public const string id = "id"; public const string linkID = "linkID"; public const string roleID = "roleID"; public const string loginID = "loginID"; public const string loginPW = "loginPW"; public const string caption = "caption"; public const string avatar = "avatar"; public const string description = "description"; public const string firstLogin = "firstLogin"; public const string isAdmin = "isAdmin"; public const string status = "status"; public const string Email = "Email"; public const string loginCode = "loginCode";
        }

        public class tbBangLuongThang
        {
            public static string TableName = "tbBangLuongThang";
            public const string id = "id"; public const string thang = "thang"; public const string empoyeeID = "empoyeeID"; public const string luongCB = "luongCB"; public const string luongPC = "luongPC"; public const string ngaycong_bt = "ngaycong_bt"; public const string ngaycong_phep = "ngaycong_phep"; public const string ngaycong_lt = "ngaycong_lt"; public const string ngaycong_cn = "ngaycong_cn"; public const string tongNgayCong = "tongNgayCong"; public const string tienNC_bt = "tienNC_bt"; public const string tienNC_phep = "tienNC_phep"; public const string tienNC_lt = "tienNC_lt"; public const string tienNC_cn = "tienNC_cn"; public const string tienNgayCong = "tienNgayCong"; public const string tgTangCa_bt = "tgTangCa_bt"; public const string tgTangCa_cn = "tgTangCa_cn"; public const string tgTangCa_lt = "tgTangCa_lt"; public const string tongThoiGianTangCa = "tongThoiGianTangCa"; public const string tienTangCa_bt = "tienTangCa_bt"; public const string tienTangCa_cn = "tienTangCa_cn"; public const string tienTangCa_lt = "tienTangCa_lt"; public const string tienTangCa = "tienTangCa"; public const string Calc1 = "Calc1"; public const string Calc2 = "Calc2"; public const string Calc3 = "Calc3"; public const string Calc4 = "Calc4"; public const string Calc5 = "Calc5"; public const string Calc6 = "Calc6"; public const string Calc7 = "Calc7"; public const string Calc8 = "Calc8"; public const string Calc9 = "Calc9"; public const string Calc10 = "Calc10"; public const string Calc11 = "Calc11"; public const string Calc12 = "Calc12"; public const string Calc13 = "Calc13"; public const string Calc14 = "Calc14"; public const string Calc15 = "Calc15"; public const string Calc16 = "Calc16"; public const string Calc17 = "Calc17"; public const string Calc18 = "Calc18"; public const string Calc19 = "Calc19"; public const string Calc20 = "Calc20"; public const string tongThuongCalc = "tongThuongCalc"; public const string PC1 = "PC1"; public const string PC2 = "PC2"; public const string PC3 = "PC3"; public const string PC4 = "PC4"; public const string PC5 = "PC5"; public const string PC6 = "PC6"; public const string PC7 = "PC7"; public const string PC8 = "PC8"; public const string PC9 = "PC9"; public const string PC10 = "PC10"; public const string PC11 = "PC11"; public const string PC12 = "PC12"; public const string PC13 = "PC13"; public const string PC14 = "PC14"; public const string PC15 = "PC15"; public const string PC16 = "PC16"; public const string PC17 = "PC17"; public const string PC18 = "PC18"; public const string PC19 = "PC19"; public const string PC20 = "PC20"; public const string tongPhuCapKhac = "tongPhuCapKhac"; public const string tongLuong = "tongLuong"; public const string BH105 = "BH105"; public const string khoanTruKhac = "khoanTruKhac"; public const string tamUngLuong = "tamUngLuong"; public const string tongKhauTru = "tongKhauTru"; public const string actualBankTransfer = "actualBankTransfer"; public const string approved = "approved"; public const string luongSP = "luongSP"; public const string luongTangCaSP = "luongTangCaSP"; public const string luongSP_tong = "luongSP_tong"; public const string luongThoiGian = "luongThoiGian"; public const string laBangLuongCu = "laBangLuongCu"; public const string ngaycong_phepNam = "ngaycong_phepNam"; public const string tienNC_phepNam = "tienNC_phepNam"; public const string tongTgTangCa_cn_gio = "tongTgTangCa_cn_gio"; public const string analyzeDate = "analyzeDate"; public const string analyzeBy = "analyzeBy"; public const string isLocked = "isLocked"; public const string isLuongSP = "isLuongSP"; public const string phiCongDoan = "phiCongDoan";
        }

        public class tblRef_Discipline
        {
            public static string TableName = "tblRef_Discipline";
            public const string DisciplineID = "DisciplineID"; public const string DisciplineForm = "DisciplineForm";
        }

        public class tbCaLam_TinhTangCa
        {
            public static string TableName = "tbCaLam_TinhTangCa";
            public const string id = "id"; public const string idCaLamViec = "idCaLamViec"; public const string idx = "idx"; public const string thoiGian = "thoiGian"; public const string heSoLuong = "heSoLuong";
        }

        public class tbCatDefineColumn
        {
            public static string TableName = "tbCatDefineColumn";
            public const string id = "id"; public const string catDefID = "catDefID"; public const string columnName = "columnName"; public const string caption = "caption"; public const string dataType = "dataType"; public const string sortIdx = "sortIdx"; public const string width = "width"; public const string dataLength = "dataLength"; public const string dataIsNullable = "dataIsNullable"; public const string dataSource = "dataSource";
        }

        public class tbLoaiNgayLamThem
        {
            public static string TableName = "tbLoaiNgayLamThem";
            public const string id = "id"; public const string tenLoai = "tenLoai"; public const string heSoLuong = "heSoLuong";
        }

        public class tblEmpHIPlace
        {
            public static string TableName = "tblEmpHIPlace";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string DateChange = "DateChange"; public const string FromM = "FromM"; public const string FromY = "FromY"; public const string HIPlace = "HIPlace"; public const string Notes = "Notes";
        }

        public class tblRef_LeaveType
        {
            public static string TableName = "tblRef_LeaveType";
            public const string LeaveID = "LeaveID"; public const string LeaveType = "LeaveType"; public const string SalaryRate = "SalaryRate"; public const string IsBasicSal = "IsBasicSal"; public const string IsInsurance = "IsInsurance"; public const string IsSick = "IsSick"; public const string IsAttendance = "IsAttendance";
        }

        public class w5sysFunction
        {
            public static string TableName = "w5sysFunction";
            public const string id = "id"; public const string sysCode = "sysCode"; public const string parentId = "parentId"; public const string code = "code"; public const string caption = "caption"; public const string caption_EN = "caption_EN"; public const string asemblyPath = "asemblyPath"; public const string asemblyInherits = "asemblyInherits"; public const string icon = "icon"; public const string type = "type"; public const string order1 = "order1"; public const string sys_locked = "sys_locked"; public const string status = "status"; public const string modal = "modal";
        }

        public class tblRef_LeftType
        {
            public static string TableName = "tblRef_LeftType";
            public const string LeftTypeID = "LeftTypeID"; public const string LeftTypeName = "LeftTypeName"; public const string Pension = "Pension";
        }

        public class tblRef_HIPlace
        {
            public static string TableName = "tblRef_HIPlace";
            public const string KeyID = "KeyID"; public const string HIPlace = "HIPlace"; public const string Notes = "Notes"; public const string HIPlaceID = "HIPlaceID";
        }

        public class tblEmpType
        {
            public static string TableName = "tblEmpType";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string DateChange = "DateChange"; public const string EmpTypeID = "EmpTypeID"; public const string Notes = "Notes";
        }

        public class tblHoliday
        {
            public static string TableName = "tblHoliday";
            public const string Dating = "Dating"; public const string SalaryRate = "SalaryRate"; public const string Notes = "Notes";
        }

        public class tblRef_EmployeeType
        {
            public static string TableName = "tblRef_EmployeeType";
            public const string EmpTypeID = "EmpTypeID"; public const string EmpTypeName = "EmpTypeName";
        }

        public class tbCaLamViec
        {
            public static string TableName = "tbCaLamViec";
            public const string id = "id"; public const string ten = "ten"; public const string tuGio = "tuGio"; public const string denGio = "denGio"; public const string caDem = "caDem"; public const string tgQuetTruoc_Vao = "tgQuetTruoc_Vao"; public const string tgQuetSau_Vao = "tgQuetSau_Vao"; public const string tgQuetTruoc_Ra = "tgQuetTruoc_Ra"; public const string tgQuetSau_Ra = "tgQuetSau_Ra"; public const string soTiengTinhCa = "soTiengTinhCa"; public const string soTiengTangCaTrachNhiem = "soTiengTangCaTrachNhiem"; public const string soTiengTinhTangCa = "soTiengTinhTangCa"; public const string caSang_tuGio = "caSang_tuGio"; public const string caSang_denGio = "caSang_denGio"; public const string caChieu_tuGio = "caChieu_tuGio"; public const string caChieu_denGio = "caChieu_denGio";
        }

        public class tblRef_Reason
        {
            public static string TableName = "tblRef_Reason";
            public const string ReasonID = "ReasonID"; public const string ReasonName = "ReasonName"; public const string ReasonName_VN = "ReasonName_VN"; public const string IncomeTax = "IncomeTax";
        }

        public class tblEmpDep
        {
            public static string TableName = "tblEmpDep";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string DateChange = "DateChange"; public const string DepID = "DepID"; public const string LineID = "LineID"; public const string SectionID = "SectionID"; public const string TeamID = "TeamID"; public const string PartID = "PartID"; public const string Notes = "Notes"; public const string Rpt_Dep = "Rpt_Dep"; public const string Rpt_Line = "Rpt_Line"; public const string Rpt_Group = "Rpt_Group";
        }

        public class tblTetBonus_Date
        {
            public static string TableName = "tblTetBonus_Date";
            public const string YearID = "YearID"; public const string DateID = "DateID"; public const string Notes = "Notes";
        }

        public class tblRef_EvaluationType
        {
            public static string TableName = "tblRef_EvaluationType";
            public const string EvaluationTypeID = "EvaluationTypeID"; public const string EvaluationTypeName = "EvaluationTypeName"; public const string Coefficient = "Coefficient"; public const string Notes = "Notes";
        }

        public class tbCty
        {
            public static string TableName = "tbCty";
            public const string ma = "ma"; public const string ten = "ten"; public const string diachi = "diachi"; public const string dienthoai = "dienthoai"; public const string logo = "logo"; public const string ghichu = "ghichu";
        }

        public class tblRef_Bank
        {
            public static string TableName = "tblRef_Bank";
            public const string BankID = "BankID"; public const string BankName = "BankName"; public const string BankGroupID = "BankGroupID";
        }

        public class tblEmpSalary
        {
            public static string TableName = "tblEmpSalary";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string DateChange = "DateChange"; public const string PosID = "PosID"; public const string SalLevelID = "SalLevelID"; public const string Coefficient = "Coefficient"; public const string BasicSalary = "BasicSalary"; public const string CurrType = "CurrType"; public const string Notes = "Notes"; public const string BasicSalary_Ins = "BasicSalary_Ins"; public const string status = "status"; public const string statusRemark = "statusRemark"; public const string BeginDate = "BeginDate"; public const string EndDate = "EndDate"; public const string ContractCode = "ContractCode";
        }

public class tbThamSoTinhLuong
        {
            public static string TableName = "tbThamSoTinhLuong";
            public const string id = "id"; public const string thang = "thang"; public const string employeeID = "employeeID"; public const string PC1 = "PC1"; public const string PC2 = "PC2"; public const string PC3 = "PC3"; public const string PC4 = "PC4"; public const string PC5 = "PC5"; public const string PC6 = "PC6"; public const string PC7 = "PC7"; public const string PC8 = "PC8"; public const string PC9 = "PC9"; public const string PC10 = "PC10"; public const string PC11 = "PC11"; public const string PC12 = "PC12"; public const string PC13 = "PC13"; public const string PC14 = "PC14"; public const string PC15 = "PC15"; public const string PC16 = "PC16"; public const string PC17 = "PC17"; public const string PC18 = "PC18"; public const string PC19 = "PC19"; public const string PC20 = "PC20"; public const string LuongSP = "LuongSP"; public const string DataCalc1 = "DataCalc1"; public const string DataCalc2 = "DataCalc2"; public const string DataCalc3 = "DataCalc3"; public const string DataCalc4 = "DataCalc4"; public const string DataCalc5 = "DataCalc5"; public const string DataCalc6 = "DataCalc6"; public const string DataCalc7 = "DataCalc7"; public const string DataCalc8 = "DataCalc8"; public const string DataCalc9 = "DataCalc9"; public const string DataCalc10 = "DataCalc10";
        }
        public class tblEmpChild
        {
            public static string TableName = "tblEmpChild";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string ChildName = "ChildName"; public const string ChildBirthday = "ChildBirthday"; public const string ChildSex = "ChildSex"; public const string RecievedDate = "RecievedDate"; public const string Notes = "Notes";
        }
   public class tbFunction
        {
            public static string TableName = "tbFunction";
            public const string idFunction = "idFunction"; public const string parentID = "parentID"; public const string code = "code"; public const string category = "category"; public const string path = "path"; public const string caption = "caption"; public const string asemblyPath = "asemblyPath"; public const string sysLock = "sysLock"; public const string icon = "icon"; public const string showModal = "showModal"; public const string type = "type"; public const string status = "status"; public const string requireAdmin = "requireAdmin"; public const string displayOrder = "displayOrder";
        }

        public class tblRef_BankGroup
        {
            public static string TableName = "tblRef_BankGroup";
            public const string BankGroupID = "BankGroupID"; public const string BankGroupName = "BankGroupName";
        }

        public class tbChiNhanh
        {
            public static string TableName = "tbChiNhanh";
            public const string idChiNhanh = "idChiNhanh"; public const string maCN = "maCN"; public const string tenCN = "tenCN"; public const string logo = "logo"; public const string diachi = "diachi"; public const string dienthoai = "dienthoai"; public const string status = "status"; public const string ghichu = "ghichu";
        }

        public class tblRef_BasicSalary
        {
            public static string TableName = "tblRef_BasicSalary";
            public const string SalID = "SalID"; public const string BasicSalary = "BasicSalary";
        }

        public class tbCuaHang
        {
            public static string TableName = "tbCuaHang";
            public const string idCuaHang = "idCuaHang"; public const string idChiNhanh = "idChiNhanh"; public const string ma = "ma"; public const string ten = "ten"; public const string logo = "logo"; public const string diachi = "diachi"; public const string dienthoai = "dienthoai"; public const string status = "status"; public const string ghichu = "ghichu";
        }

        public class tblRef_District
        {
            public static string TableName = "tblRef_District";
            public const string DistrictID = "DistrictID"; public const string DistrictName = "DistrictName"; public const string CityID = "CityID";
        }

        public class tbRule
        {
            public static string TableName = "tbRule";
            public const string idRule = "idRule"; public const string parentID = "parentID"; public const string pathIdx = "pathIdx"; public const string path = "path"; public const string caption = "caption"; public const string rOrder = "rOrder"; public const string type = "type"; public const string idFunction = "idFunction"; public const string rView = "rView"; public const string rAdd = "rAdd"; public const string rEdit = "rEdit"; public const string rDelete = "rDelete"; public const string rPrint = "rPrint"; public const string rImport = "rImport"; public const string rExport = "rExport"; public const string rChoose = "rChoose"; public const string rCustom = "rCustom"; public const string status = "status";
        }

        public class w5Slide
        {
            public static string TableName = "w5Slide";
            public const string id = "id"; public const string DanhMucID = "DanhMucID"; public const string ten = "ten"; public const string ten_en = "ten_en"; public const string LienKet = "LienKet"; public const string Anh = "Anh"; public const string Rong = "Rong"; public const string Cao = "Cao"; public const string STT = "STT"; public const string TrangThai = "TrangThai";
        }

        public class tbSaveData
        {
            public static string TableName = "tbSaveData";
            public const string id = "id"; public const string code = "code"; public const string data = "data";
        }

        public class tblEmpContract
        {
            public static string TableName = "tblEmpContract";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string BeginDate = "BeginDate"; public const string EndDate = "EndDate"; public const string ContractID = "ContractID"; public const string ContractTypeID = "ContractTypeID"; public const string Notes = "Notes";
        }

        public class tblRef_City
        {
            public static string TableName = "tblRef_City";
            public const string CityID = "CityID"; public const string CityName = "CityName";
        }

        public class tbRole
        {
            public static string TableName = "tbRole";
            public const string idRole = "idRole"; public const string idRule = "idRule"; public const string code = "code"; public const string caption = "caption"; public const string description = "description"; public const string status = "status";
        }

        public class tblRef_Race
        {
            public static string TableName = "tblRef_Race";
            public const string RaceID = "RaceID"; public const string RaceName = "RaceName";
        }

        public class tbUser
        {
            public static string TableName = "tbUser";
            public const string idUser = "idUser"; public const string idRole = "idRole"; public const string idNhanVien = "idNhanVien"; public const string loginID = "loginID"; public const string loginPW = "loginPW"; public const string caption = "caption"; public const string description = "description"; public const string firstLogin = "firstLogin"; public const string isAdmin = "isAdmin"; public const string status = "status";
        }

        public class tblRef_Religion
        {
            public static string TableName = "tblRef_Religion";
            public const string ReligionID = "ReligionID"; public const string ReligionName = "ReligionName";
        }

        public class w5TinTuc
        {
            public static string TableName = "w5TinTuc";
            public const string id = "id"; public const string NguoiDang = "NguoiDang"; public const string NguoiDuyet = "NguoiDuyet"; public const string MucTinID = "MucTinID"; public const string DanhMucID = "DanhMucID"; public const string TenVN = "TenVN"; public const string TenEN = "TenEN"; public const string AnhDaiDienVN = "AnhDaiDienVN"; public const string AnhDaiDienEN = "AnhDaiDienEN"; public const string GioiThieuVN = "GioiThieuVN"; public const string GioiThieuEN = "GioiThieuEN"; public const string NoiDungVN = "NoiDungVN"; public const string NoiDungEN = "NoiDungEN"; public const string STT = "STT"; public const string laDacBiet = "laDacBiet"; public const string TrangThai = "TrangThai"; public const string LuotXem = "LuotXem"; public const string NgayTao = "NgayTao"; public const string NgayDuyet = "NgayDuyet";
        }

        public class tblEmpPos
        {
            public static string TableName = "tblEmpPos";
            public const string id = "id"; public const string EmployeeID = "EmployeeID"; public const string DateChange = "DateChange"; public const string PosID = "PosID"; public const string Notes = "Notes";
        }

        public class tblRef_Nationality
        {
            public static string TableName = "tblRef_Nationality";
            public const string NationalityID = "NationalityID"; public const string NationalityName = "NationalityName";
        }

        public class tbPhuCapCoDinh
        {
            public static string TableName = "tbPhuCapCoDinh";
            public const string id = "id"; public const string employeeID = "employeeID"; public const string pc_XangXe = "pc_XangXe"; public const string pc_ConTho = "pc_ConTho";
        }

        public class tblRef_MaritalStatus
        {
            public static string TableName = "tblRef_MaritalStatus";
            public const string MaritalStatusID = "MaritalStatusID"; public const string MaritalStatusName = "MaritalStatusName";
        }

        public class tblRef_Degree
        {
            public static string TableName = "tblRef_Degree";
            public const string DegreeID = "DegreeID"; public const string DegreeName = "DegreeName";
        }

        public class tbl_logXuLyDuLieu
        {
            public static string TableName = "tbl_logXuLyDuLieu";
            public const string id = "id"; public const string ngayhientai = "ngayhientai"; public const string ngaytu = "ngaytu"; public const string ngayden = "ngayden"; public const string employeeID = "employeeID"; public const string idPhongBan = "idPhongBan"; public const string tenPhongBan = "tenPhongBan"; public const string idNhom = "idNhom"; public const string tenNhom = "tenNhom"; public const string isXuLyDLGoc = "isXuLyDLGoc"; public const string loginID = "loginID"; public const string caption = "caption";
        }

        public class tblRef_Language
        {
            public static string TableName = "tblRef_Language";
            public const string LangID = "LangID"; public const string LangName = "LangName";
        }

        public class w5sysConnectionString
        {
            public static string TableName = "w5sysConnectionString";
            public const string code = "code"; public const string strcnn = "strcnn"; public const string logo = "logo"; public const string caption = "caption"; public const string caption_EN = "caption_EN";
        }

    }
}