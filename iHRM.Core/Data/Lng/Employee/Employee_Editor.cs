using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHRM.Lng
{
    public class Employee_Editor
    {
        public static string msg_js2 = "Xin vui lòng điền đủ dữ liệu";
        public static string dong = "Đóng";
        public static string title_thongtinchung = "Thông tin chung";
        public static string maNV = "Mã NV <span class='red'>*</span>";
        public static string maNVcu = "Mã NV cũ";
        public static string ho = "Họ:  <span class='red'>*</span>";
        public static string ten = "Tên: ";
        public static string hoten = "Họ và tên <span class='red'>*</span>";
        public static string tinhtrang = "Tình trạng";
        public static string tinhtrangGD = "Tình trạng GĐ";
        public static string gioitinh = "Giới tính";
        public static string chon = "..Chọn..";
        public static string cardID = "Số thẻ";
        public static string ngayvaolam = "Ngày vào làm";
        public static string dienthoai = "Số ĐT";
        public static string ngaysinh = "Ngày sinh";
        public static string save = "Lưu";

        public static string title_cmnd = "Chứng minh nhân dân";
        public static string cmnd = "Số CMND";
        public static string ngaycap = "Ngày cấp";
        public static string noicap = "Nơi cấp";
        public static string diachi = "Địa chỉ";

        public static string ngay_tgCD = "Tham gia CĐ, Ngày";
        public static string phi_CD = "Phí CĐ: ";
        public static string soTK = "Số TK ngân hàng";
        public static string ngaykyHD = "Ngày ký HĐ: ";
        public static string taiNH = "Tại ngân hàng";
        public static string ngaynopHS = "Ngày Nộp HS:";
        public static string KoTinhTangCa = "Ko tính tiền tăng ca";
        public static string luongcoban = "Lương cơ bản";
        public static string phucapTX = "Phụ cấp TX:";

        public static string bhld = "Bảo hiểm - Sổ lao động";
        public static string bhxh = "Bảo hiểm xã hội";
        public static string chuyenden = "Chuyển đến";
        public static string soBHXHcu = "Số BHXH cũ";
        public static string sosoBH = "Số sổ BH";
        public static string daudongBH = "Dấu đóng BH";
        public static string dacapsoBH = "Đã cấp sổ BH";
        public static string ngaydoi = "Ngày đổi";

        public static string chuyendi = "Chuyển đi";
        public static string ngaychuyen = "Ngày chuyển";
        public static string lydo = "Lý do";
        public static string title_BHYT = "Bảo hiểm Y tế";
        public static string dadangky = "Đã đăng ký";
        public static string soso = "Số sổ";
        public static string batdau = "Bắt đầu";

        public static string title_DangKyKCB = "Nơi đăng ký khám chữa bệnh";
        public static string ngay = "Ngày";
        public static string noidangky = "Nơi đăng ký";
        public static string ghichu = "Ghi chú";

        public static string ngaynopdon = "Ngày nộp đon";
        //Sổ lao động
        public static string title_SoLaoDong = "Sổ lao động";
        public static string titleThoiviec = "Thôi việc";
        public static string daThoiViec = "Đã thôi việc";
        public static string ngaythoiviec = "Ngày thôi việc";
        public static string quyetdinhso = "Quyết định số";
        public static string huongtrocap = "Hưởng trợ cấp";
        public static string thangtinhluongcuoi = "Tháng tính lương cuối";
        public static string namtraluongcuoi = "Năm trả lương cuối cùng";
        public static string lydothoiviec = "Lý do thôi việc";
        public static string ngaytraluongcuoi = "Ngày trả lương cuối";

        //Thông tin khác.

        public static string title_ThongTinKhac = "Thông tin khác";
        public static string loaiNV = "Loại Nhân Viên";
        public static string phongban = "Phòng ban";
        public static string chucdanh = "Chức danh";
        public static string capbac = "Cấp bậc";
        public static string phucap = "Phụ cấp";
        public static string phucaphangthang = "Phụ cấp hàng tháng";

        public static string thang = "Tháng:   ";
        public static string chonPB = "Chọn phòng ban...";
        public static string dsPB = "Danh sách phòng ban";
        public static string tooltip = "Xem bảng lương của tháng và năm đã chọn";
        public static string bangluongCT = "Bảng lương chi tiết";



        public static string idCard = "CMND";
        public static string ngayvao = "Ngày vào";
        public static string luongCB = "Lương cơ bản";
        public static string luongPC = "Lương phụ cấp";
        public static string ngaycong = "Ngày công";
        public static string tiencong = "Tiền công";
        public static string chitiet = "Chi tiết";

        public static string tongTGTC = "Tổng tg tăng ca";
        public static string TienTangCa = "Tiền tăng ca";
        public static string phucapKhac = "Phụ cấp khác";
        public static string tongluong = "Tổng Lương";
        public static string inphieu = "In phiếu";
        public static string xuatEx = "Xuất Excel";

        public static string grd_Status = "TT";

        public static string tgDiMuon = "TG đi muộn";
        public static string tgVeSom = "TG về sớm";
        public static string hsLuong = "HS lương";
        public static string trangthai = "Trạng thái";
        public static string tangca = "Tăng ca";

        public static string sotien = "Số tiền";
        public static string hopdong = "Hợp đồng";
        public static string mahopdong = "Mã hợp đồng";
        public static string loaihopdong = "Loại hợp đồng";
        public static string tungay = "Từ ngày";
        public static string denngay = "Đến ngày";
        public static string chucvu = "Chức vụ";
        public static string Begindate = "Ngày bắt đầu";
        public static string Enddate = "Ngày kết thúc";


        public static string phieuluong = "Phiếu lương";
        public static string phieuluongthang = "Phiếu lương tháng ";
        public static string inphieuluong = "In phiếu lương";
        public static string nam1 = " năm ";

        public static string msg_1 = "Mã nhân viên đã được sử dụng!";
        public static string title = "Chi tiết ngày công NV ";
        public static string title3 = "Chi tiết tính tăng ca NV ";
        public static string title2 = "Chi tiết tính phụ cấp NV ";

        public static string khoanphucap = "Khoản phụ cấp";
        public static string chukyluong = "Chu kỳ lương";
        public static string bangluongthang = "BẢNG LƯƠNG THÁNG ";
        public static string sendingmail = "Đang gửi mail...";




    }
}