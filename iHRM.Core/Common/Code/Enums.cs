using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Common.Code
{
    public class Enums
    {
        public enum eFunction { Custom = 0, Find = 1, New = 2, Edit = 4, Delete = 8, Import = 16, Export = 32, Print = 64, Choose = 128, Save = 256, Exit = 512 }
        
        public enum eStatus { None = 0, KichHoat = 1, KhongKichHoat = 2 }
        public static Dictionary<eStatus, string> eStatus_Alias = new Dictionary<eStatus, string>()
        {
            {eStatus.KichHoat, "Kích hoạt" },
            {eStatus.KhongKichHoat, "Không kích hoạt" }
          
        };
        
        public enum eTTLoaiQuetThe { None = 0, VaoKhongRa = 1, RaKhongVao = 2, NhieuLanVaoRA = 3, MotLanVaoRa = 4, All = 5 }
        public static Dictionary<eTTLoaiQuetThe, string> eTTLoaiQuetThe_Alias = new Dictionary<eTTLoaiQuetThe, string>()
        {
            {eTTLoaiQuetThe.None, "Không quẹt" },
            {eTTLoaiQuetThe.VaoKhongRa, "Vào - không ra" },
            {eTTLoaiQuetThe.RaKhongVao, "Ra - Không vào" },
            {eTTLoaiQuetThe.NhieuLanVaoRA, "Nhiều lần vào - ra" },
            {eTTLoaiQuetThe.MotLanVaoRa, "Một lần Vào -Ra" },
            {eTTLoaiQuetThe.All, "Tất cả" },

          
        };


        //Please do not change,,, it fixed in sql statement
        /// <summary>
        /// Các lý do xin nghỉ
        /// </summary>
        public enum eLyDoNghi
        {
            NghiPhepNam = 4,
            KetHon = 5,
            MaChay = 6,
            CheDo = 8,

            KhongLuong = 11,
            Om = 12,
            Khac = 13,
            VangMat = 14,
            ThaiSan = 15
        }
        public static Dictionary<int, string> LyDoNghi_CodeAlias = new Dictionary<int, string>()
        {
            { (int)eLyDoNghi.NghiPhepNam, "AL" }, //ldNghiPhepNam
            { (int)eLyDoNghi.KetHon, "WL" }, //ldKetHon
            { (int)eLyDoNghi.MaChay, "FL" }, //ldMaChay
            { (int)eLyDoNghi.CheDo, "CĐ" }, //ldCheDo

            { (int)eLyDoNghi.KhongLuong, "LWP"}, //không lương
            { (int)eLyDoNghi.Om, "SL" }, //ốm
            { (int)eLyDoNghi.Khac, "#"  }, //khác
            { (int)eLyDoNghi.VangMat, "VM" }, //vắng mặt
            { (int)eLyDoNghi.ThaiSan, "ML" }  //thai sản
        };
    }
}