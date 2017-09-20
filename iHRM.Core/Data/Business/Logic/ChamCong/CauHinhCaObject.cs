using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class CauHinhCaObject
    {
        public Int32 pk_iCauHinhCaID;
        public string sTenCauHinhCa;
        public Boolean bKichHoat;
        public Int32 iThu;
        public Int32 iNgay;
        public Int32 iThang;
        public Int32 iNam;
        public Int32 iGioLamBatDau;
        public Int32 iGioLamKetThuc;
        public Int32 iPhutLamBatDau;
        public Int32 iPhutLamKetThuc;
        public Int32 fk_iLoaiNgayCongID;
        public Int64 fk_iDonViID;
        public CauHinhCaObject(DataRow dr)
        {
            pk_iCauHinhCaID = (Int32)dr["pk_iCauHinhCaID"];
            sTenCauHinhCa = dr["sTenCauHinhCa"] as string;
            bKichHoat = (Boolean)dr["bKichHoat"];
            iThu =(Int32) dr["iThu"];
            iNgay = (Int32)dr["iNgay"];
            iThang = (Int32)dr["iThang"];
            iNam = (Int32)dr["iNam"];
            iGioLamBatDau = (Int32)dr["iGioLamBatDau"];
            iGioLamKetThuc = (Int32)dr["iGioLamKetThuc"];
            iPhutLamBatDau = (Int32)dr["iPhutLamBatDau"];
            iPhutLamKetThuc = (Int32)dr["iPhutLamKetThuc"];
            fk_iLoaiNgayCongID = (Int32)dr["fk_iLoaiNgayCongID"];
            fk_iDonViID = (Int32)dr["fk_iDonViID"];
        }
    }
}