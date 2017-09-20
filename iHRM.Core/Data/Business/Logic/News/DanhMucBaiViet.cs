using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.News
{
    public class DanhMucBaiViet : LogicBase
    {
        public DanhMucBaiViet() : base(iHRM.Core.Business.TableConst.tbDanhMucBaiViet.TableName) { }

        public DataTable GetMainMenu()
        {
            return Provider.ExecuteDataTable("p_tbDanhMucBaiViet_GetMainMenu");
        }
    }
}
