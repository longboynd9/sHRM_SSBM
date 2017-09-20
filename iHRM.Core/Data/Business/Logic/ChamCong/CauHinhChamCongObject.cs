using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class CauHinhChamCongObject
    {
        public Int32 pk_iCauHinhChamCongID;
        public String sTenCauHinhChamCong;
        public Int32 iSoPhut;
        public Int32 iLoai;
        public float fSoLuongTru;
        public Int32 iLoaiTru;
        public Int64 fk_iDonViID;
        public CauHinhChamCongObject(DataRow dr)
        {
            pk_iCauHinhChamCongID = (Int32)dr["pk_iCauHinhChamCongID"];
            sTenCauHinhChamCong = (string)dr["pk_iCauHinhChamCongID"];
            iSoPhut = (Int32)dr["dNgay"];
            iLoai = (Int32)dr["iLoai"];
            fSoLuongTru = (float)dr["fSoLuongTru"];
            iLoaiTru = (Int32)dr["iLoaiTru"];
            fk_iDonViID = (Int64)dr["fk_iNhanVienID"];

        }
    }
}