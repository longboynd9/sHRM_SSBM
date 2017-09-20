using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.News
{
    public class BaiViet_Front 
    {
        public DataRow GetBvByCategoryCode(string code)
        {
            return Provider.ExecuteDataRow("p_BaiViet_Front_GetBvByCategoryCode", new SqlParameter("catCode", code));
        }
        public DataTable GetAllService()
        {
            return Provider.ExecuteDataTableReader("p_BaiViet_Front_GetAllService");
        }
        public DataTable GetTopBV(int top = 4)
        {
            return Provider.ExecuteDataTableReader("p_BaiViet_Front_GetTopBV", new SqlParameter("top", top));
        }

        public DataRow GetDmByIdx(int idx)
        {
            return Provider.ExecuteDataRow("p_BaiViet_Front_GetDmByIdx", new SqlParameter("idx", idx));
        }
        public DataTable GetSubDm(Guid? parentID)
        {
            return Provider.ExecuteDataTableReader("p_BaiViet_Front_GetSubDm", new SqlParameter("parentID", parentID));
        }

        public DataTable GetBvInDm(Guid? idDanhMuc, int p = 1, int psize = 10)
        {
            return Provider.ExecuteDataTableReader("p_BaiViet_Front_GetBvInDm", 
                new SqlParameter("idDanhMuc", idDanhMuc),
                new SqlParameter("p", p),
                new SqlParameter("psize", psize)
            );
        }

        public DataTable Search(string keyword)
        {
            return Provider.ExecuteDataTableReader("p_BaiViet_Front_Search",
                new SqlParameter("keyword", keyword)
            );
        }

        public DataTable Slide_GetSlide(string category)
        {
            return Provider.ExecuteDataTableReader("p_Slide_GetSlide",
                new SqlParameter("category", category)
            );
        }
    }
}
