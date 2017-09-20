using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.ChamCong
{
    public class import
    {
        public int importtttt(DataTable dt)
        {
            var pa = new SqlParameter("data", SqlDbType.Structured);
            pa.TypeName = "t_tbDuLieuQuetThe";
            pa.Value = dt;

            return Provider.ExecNoneQuery("p_duLieuQuetThe_Import", pa);
        }
        public int imporNew(DataTable dt)
        {
            var pa = new SqlParameter("data", SqlDbType.Structured);
            pa.TypeName = "t_tbDuLieuvaora2";
            pa.Value = dt;

            return Provider.ExecNoneQuery("p_duLieuQuetThe_Import_hrm2", pa);
        } 
        public DataTable GetThietBi(string ime)
        {
            return Provider.ExecuteDataTableReader("GetThietbiByImage", new SqlParameter("ime", ime));
          
        }
        public int import_NhatKyVaoRa(DataTable dt)
        {
            var pa = new SqlParameter("data", SqlDbType.Structured);
            pa.TypeName = "t_NhatKyVaoRa";
            pa.Value = dt;

            return Provider.ExecNoneQuery("p_NhatKyVaoRa_Import", pa);
        }
    }
}
