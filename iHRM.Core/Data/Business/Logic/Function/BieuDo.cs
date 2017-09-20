using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Function
{
    public class BieuDo
    {
        public DataTable BieuDo_DoanhSoBanHang(int timer = 1, Guid? idKho = null)
        {
            return Provider.ExecuteDataTableReader("BieuDo_DoanhSoBanHang",
                new SqlParameter("timer", timer),
                new SqlParameter("idKho", idKho)
            );
        }

        public DataTable BieuDo_SanPhamBanChay(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            return Provider.ExecuteDataTableReader("BieuDo_SanPhamBanChay",
                new SqlParameter("tuNgay", tuNgay),
                new SqlParameter("denNgay", denNgay)
            );
        }

    }
}
