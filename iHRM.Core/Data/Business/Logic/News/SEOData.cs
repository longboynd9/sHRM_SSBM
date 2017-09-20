using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.News
{
    public class SEOData : LogicBase
    {
        public SEOData() : base(iHRM.Core.Business.TableConst.tbSEOData.TableName) { }

        public Guid? CreateNew()
        {
            return Provider.ExecuteScalar("p_tbSEOData_CreateNew") as Guid?;
        }
        public int UpdateSEO4DanhMucBaiViet(Guid idDanhMucBV, Guid idSEOData)
        {
            return Provider.ExecNoneQuery("p_tbSEOData_UpdateSEO4DanhMucBaiViet",
                new SqlParameter("idDanhMucBV", idDanhMucBV),
                new SqlParameter("idSEOData", idSEOData)
            );
        }

        public DataRow NewRow()
        {
            return Provider.ExecuteDataTable("p_tbSEOData_GetByID", new SqlParameter("id", null)).NewRow();
        }
    }
}
