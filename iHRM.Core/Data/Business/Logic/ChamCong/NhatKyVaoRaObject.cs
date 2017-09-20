using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class NhatKyVaoRaObject
    {
        public int pk_iNhatKyVaoRaID;
        public DateTime dNgay;
        public DateTime tGio;
        public int iTrangThai;
        public int fk_iNhanVienID{set; get;}
        public int fk_iThietBiID;
        public NhatKyVaoRaObject(DataRow dr)
        {
            pk_iNhatKyVaoRaID = dr["iTrangThai"] == DBNull.Value ? 0 : Convert.ToInt32(dr["pk_iNhatKyVaoRaID"]);
            dNgay = ((DateTime)dr["dThoiGian"]).Date;
            tGio = (DateTime)dr["dThoiGian"];

            iTrangThai = dr["iTrangThai"] == DBNull.Value ? 0 : Convert.ToInt32(dr["iTrangThai"]);
            fk_iNhanVienID = dr["iTrangThai"] == DBNull.Value ? 0 : Convert.ToInt32(dr["fk_iNhanVienID"]);
            fk_iThietBiID = dr["iTrangThai"] == DBNull.Value ? 0 : Convert.ToInt32(dr["fk_iThietBiID"]);
        }
    }
}