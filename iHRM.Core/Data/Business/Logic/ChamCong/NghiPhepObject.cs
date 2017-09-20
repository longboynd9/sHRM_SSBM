using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class NghiPhepObject
    {
        public Int32 pk_iNghiPhepID;
        public DateTime dTuNgay;
        public DateTime dDenNgay;
        public string sGhiChu;
        public DateTime dNgayTao;
        public Int32 fk_iNhanVienID;
        public Int32 fk_iLoaiNgayCongID;
        public NghiPhepObject(DataRow dr)
        {
            pk_iNghiPhepID = (Int32)dr["pk_iNghiPhepID"];
            dTuNgay = (DateTime)dr["dTuNgay"];
            dDenNgay = (DateTime)dr["dDenNgay"];
            sGhiChu = dr["sGhiChu"] as string;
            dNgayTao = (DateTime)dr["dNgayTao"];
            fk_iNhanVienID = (Int32)dr["fk_iNhanVienID"];
            fk_iLoaiNgayCongID = (Int32)dr["fk_iLoaiNgayCongID"];
        }
    }
}