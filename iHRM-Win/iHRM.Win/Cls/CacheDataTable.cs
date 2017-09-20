using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Win.Cls
{
    public class CacheDataTable
    {
        public static DataSet ds = new DataSet();

        public static DataTable GetCacheDataTable(string TableName)
        {
            if (!ds.Tables.Contains(TableName))
            {
                var dt = Core.Business.Provider.ExecuteDataTableReader_SQL(string.Format("SELECT * FROM [{0}]", TableName));
                dt.TableName = TableName;
                ds.Tables.Add(dt);
            }

            return ds.Tables[TableName];
        }

        public static void ResetCacheOnTable(string TableName)
        {
            if (ds.Tables.Contains(TableName))
                ds.Tables.Remove(TableName);
        }

        static DataTable dtLyDoVangMat_coHL = null;
        public static DataTable DtLyDoVangMat_coHL
        {
            get
            {
                if (dtLyDoVangMat_coHL == null)
                {
                    dtLyDoVangMat_coHL = new DataTable();
                    dtLyDoVangMat_coHL.Columns.Add("id", typeof(int));
                    dtLyDoVangMat_coHL.Columns.Add("ten", typeof(string));
                    var dr1 = dtLyDoVangMat_coHL.NewRow(); dr1["id"] = (int)Enums.eLyDoNghi.NghiPhepNam; dr1["ten"] = Lng.QuetThe_DKVangMat.ldNghiPhepNam; dtLyDoVangMat_coHL.Rows.Add(dr1);
                    var dr2 = dtLyDoVangMat_coHL.NewRow(); dr2["id"] = (int)Enums.eLyDoNghi.KetHon; dr2["ten"] = Lng.QuetThe_DKVangMat.ldKetHon; dtLyDoVangMat_coHL.Rows.Add(dr2);
                    var dr3 = dtLyDoVangMat_coHL.NewRow(); dr3["id"] = (int)Enums.eLyDoNghi.MaChay; dr3["ten"] = Lng.QuetThe_DKVangMat.ldMaChay; dtLyDoVangMat_coHL.Rows.Add(dr3);
                    var dr4 = dtLyDoVangMat_coHL.NewRow(); dr4["id"] = (int)Enums.eLyDoNghi.CheDo; dr4["ten"] = Lng.QuetThe_DKVangMat.ldCheDo; dtLyDoVangMat_coHL.Rows.Add(dr4);
                }

                return dtLyDoVangMat_coHL;
            }
        }
        static DataTable dtLyDoVangMat_koHL = null;
        public static DataTable DtLyDoVangMat_koHL
        {
            get
            {
                if (dtLyDoVangMat_koHL == null)
                {
                    dtLyDoVangMat_koHL = new DataTable();
                    dtLyDoVangMat_koHL.Columns.Add("id", typeof(int));
                    dtLyDoVangMat_koHL.Columns.Add("ten", typeof(string));
                    var dr1 = dtLyDoVangMat_koHL.NewRow(); dr1["id"] = (int)Enums.eLyDoNghi.VangMat; dr1["ten"] = Lng.QuetThe_DKVangMat.ldVangMat; dtLyDoVangMat_koHL.Rows.Add(dr1);
                    var dr2 = dtLyDoVangMat_koHL.NewRow(); dr2["id"] = (int)Enums.eLyDoNghi.ThaiSan; dr2["ten"] = Lng.QuetThe_DKVangMat.ldThaiSan; dtLyDoVangMat_koHL.Rows.Add(dr2);
                    var dr3 = dtLyDoVangMat_koHL.NewRow(); dr3["id"] = (int)Enums.eLyDoNghi.Om; dr3["ten"] = Lng.QuetThe_DKNghiKhongLuong.ldNghiOm; dtLyDoVangMat_koHL.Rows.Add(dr3);
                    var dr4 = dtLyDoVangMat_koHL.NewRow(); dr4["id"] = (int)Enums.eLyDoNghi.KhongLuong; dr4["ten"] = Lng.QuetThe_DKNghiKhongLuong.ldNghiKoLuong; dtLyDoVangMat_koHL.Rows.Add(dr4);
                    var dr5 = dtLyDoVangMat_koHL.NewRow(); dr5["id"] = (int)Enums.eLyDoNghi.Khac; dr5["ten"] = Lng.QuetThe_DKNghiKhongLuong.ldKhac; dtLyDoVangMat_koHL.Rows.Add(dr5);
                }

                return dtLyDoVangMat_koHL;
            }
        }
    }
}
