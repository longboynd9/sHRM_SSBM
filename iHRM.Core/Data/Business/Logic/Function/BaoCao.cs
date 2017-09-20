using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Function
{
    public class BaoCao
    {
        public DataTable BaoCao_DoanhThu(DateTime? tuNgay = null, DateTime? denNgay = null, Guid? idKho = null, bool hasRight = false)
        {
            return Provider.ExecuteDataTableReader("BaoCao_DoanhThu",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("idKho", idKho),
                new SqlParameter("hasRight", hasRight)
            );
        }

        public DataTable BaoCao_ChuyenKho(DateTime? tuNgay = null, DateTime? denNgay = null, Guid? idKho = null, bool hasRight = false)
        {
            return Provider.ExecuteDataTableReader("BaoCao_ChuyenKho",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("idKho", idKho),
                new SqlParameter("hasRight", hasRight)
            );
        }

        public DataTable BaoCao_NhapKho(DateTime? tuNgay = null, DateTime? denNgay = null, string SearchKey = "", Guid? idKho = null, bool hasRight = false)
        {
            return Provider.ExecuteDataTableReader("BaoCao_NhapKho",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("SearchKey", SearchKey),
                new SqlParameter("idKho", idKho),
                new SqlParameter("hasRight", hasRight)
            );
        }

        public DataTable BaoCao_XuatKho(DateTime? tuNgay = null, DateTime? denNgay = null, string SearchKey = "", Guid? idKho = null, bool hasRight = false)
        {
            return Provider.ExecuteDataTableReader("BaoCao_XuatKho",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("SearchKey", SearchKey),
                new SqlParameter("idKho", idKho),
                new SqlParameter("hasRight", hasRight)
            );
        }

        public DataTable BaoCao_TonKho(string SearchKey = "", Guid? idKho = null, bool hasRight = false)
        {
            return Provider.ExecuteDataTableReader("BaoCao_TonKHo", 
                new SqlParameter("SearchKey", SearchKey),
                new SqlParameter("idKho", idKho),
                new SqlParameter("hasRight", hasRight)
            );
        }

        public DataTable BaoCao_NhapXuatTon(DateTime? tuNgay = null, DateTime? denNgay = null, string SearchKey = "", Guid? idKho = null, bool hasRight = false)
        {
            return Provider.ExecuteDataTableReader("BaoCao_NhapXuatTon",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("SearchKey", SearchKey),
                new SqlParameter("idKho", idKho),
                new SqlParameter("hasRight", hasRight)
            );
        }

        public DataTable BaoCao_TongHop(DateTime? tuNgay = null, DateTime? denNgay = null, string SearchKey = "", Guid? idKho = null, bool hasRight = false)
        {
            return Provider.ExecuteDataTableReader("BaoCao_TongHop",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay),
                new SqlParameter("SearchKey", SearchKey),
                new SqlParameter("idKho", idKho),
                new SqlParameter("hasRight", hasRight)
            );
        }

    }
}
