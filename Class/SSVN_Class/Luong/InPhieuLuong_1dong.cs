using System;
using System.Linq;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iHRM.Core.Business.DbObject;
using System.Net;
using System.Collections.Specialized;
using System.IO;
namespace iHRM.Win.ExtClass.Luong
{
    public partial class InPhieuLuong_1dong : DevExpress.XtraReports.UI.XtraReport
    {
        //dcDatabaseDataContext db = new dcDatabaseDataContext(Core.Business.Provider.ConnectionString);

        public InPhieuLuong_1dong()
        {
            InitializeComponent();
        }
        public void setTitle(string strCongTy,string strPhieuLuong, string strChuKyLuong) 
        {
            xrLabel1.Text = strCongTy;
            txtTenPhieuLuong.Text = strPhieuLuong;
            txtChuKyLuong.Text = strChuKyLuong;
        }
        public void DataBinding(object dtSource)
        {
            bindingSource1.DataSource = dtSource;

            // THÔNG TIN CHUNG.
            lbHoTen.DataBindings.Add("Text", bindingSource1, "hoten");
            lbMSNV.DataBindings.Add("Text", bindingSource1, "manv");
            lbCMND.DataBindings.Add("Text", bindingSource1, "cmnd");
            lbBoPhan.DataBindings.Add("Text", bindingSource1, "phongban");
            lbNgayVao.DataBindings.Add("Text", bindingSource1, "ngayVao");
            lbLuongCu.DataBindings.Add("Text", bindingSource1, "luongCu");
            //lbPhuCapCu.DataBindings.Add("Text", bindingSource1, "luongPcCu");
            lbLuongMoi.DataBindings.Add("Text", bindingSource1, "luongMoi");
            //lbPhuCapMoi.DataBindings.Add("Text", bindingSource1, "luongPcMoi");

            // LƯƠNG NGÀY CÔNG.

            lbNgayCongCu.DataBindings.Add("Text", bindingSource1, "ngaycong_bt_Cu");
            lbNgayCongMoi.DataBindings.Add("Text", bindingSource1, "ngaycong_bt");
            lbPhepNam.DataBindings.Add("Text", bindingSource1, "ngaycong_phepNam");
            lbNghiCoLuong.DataBindings.Add("Text", bindingSource1, "ngaycong_phep");
            lbNgayLe.DataBindings.Add("Text", bindingSource1, "ngaycong_lt");

            lbNgayCongCu_TT.DataBindings.Add("Text", bindingSource1, "tienNC_bt_Cu");
            lbNgayCongMoi_TT.DataBindings.Add("Text", bindingSource1, "tienNC_bt");
            lbPhepNam_TT.DataBindings.Add("Text", bindingSource1, "tienNC_phepNam");
            lbNghiCoLuong_TT.DataBindings.Add("Text", bindingSource1, "tienNC_phep");
            lbNgayLe_TT.DataBindings.Add("Text", bindingSource1, "tienNC_lt");

            // LƯƠNG TĂNG CA.
            lbTangCaCu.DataBindings.Add("Text", bindingSource1, "tgTangCa_bt_Cu");
            lbTangCaMoi.DataBindings.Add("Text", bindingSource1, "tgTangCa_bt");
            lbTangCaCN.DataBindings.Add("Text", bindingSource1, "tongTgTangCa_cn_gio");
            lbTangCaLeTet.DataBindings.Add("Text", bindingSource1, "tgTangCa_lt");

            lbTangCaCu_TT.DataBindings.Add("Text", bindingSource1, "tienTangCa_bt_Cu");
            lbTangCaMoi_TT.DataBindings.Add("Text", bindingSource1, "tienTangCa_bt");
            lbTangCaCN_TT.DataBindings.Add("Text", bindingSource1, "tongTienTangCa_cn");
            lbTangCaLeTet_TT.DataBindings.Add("Text", bindingSource1, "tienTangCa_lt");

            // PHỤ CẤP.
            lbChuyenCan_TT.DataBindings.Add("Text", bindingSource1, "Calc1");
            lbXangXe_TT.DataBindings.Add("Text", bindingSource1, "Calc2");
            lbConTho_TT.DataBindings.Add("Text", bindingSource1, "ConTho");
            lbPhuCapTrachNhiem_TT.DataBindings.Add("Text", bindingSource1, "PhuCapTrachNhiem");
            lbKhoanThuongKhac_TT.DataBindings.Add("Text", bindingSource1, "PC3");
            lbKhoanKhac_TT.DataBindings.Add("Text", bindingSource1, "PC4");

            //lbGiaoThong_TT.DataBindings.Add("Text", bindingSource1, "PC4");

            lbTongLuong_TT.DataBindings.Add("Text", bindingSource1, "tongLuong");

            // CÁC KHOẢN KHẤU TRỪ
            lbBaoHiem_TT.DataBindings.Add("Text", bindingSource1, "BH105");
            lbKhoanTru_TT.DataBindings.Add("Text", bindingSource1, "PC5");
            lbThueTNCN_TT.DataBindings.Add("Text", bindingSource1, "ThueTNCN");
            lbPhiCongDoan_TT.DataBindings.Add("Text", bindingSource1, "phiCongDoan");

            lbTongKhauTru_TT.DataBindings.Add("Text", bindingSource1, "tongKhauTru");

            // THỰC NHẬN
            lbThucNhan_TT.DataBindings.Add("Text", bindingSource1, "actualBankTransfer");
        }
    }
}
