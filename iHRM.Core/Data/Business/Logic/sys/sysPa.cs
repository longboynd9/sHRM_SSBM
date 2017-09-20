using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.sys
{
    public class sysPa
    {
        public DataTable GetAll()
        {
            return Provider.ExecuteDataTableReader("p_SysPa_GetAll");
        }

        public bool Update(int id, string value)
        {
            return Provider.ExecNoneQuery("p_SysPa_Update",
                new SqlParameter("id", id),
                new SqlParameter("Value", value)
            ) > 0;
        }
        public string Get(string code)
        {
            return Provider.ExecuteScalar("p_SysPa_Get",
                new SqlParameter("Code", code)
            ) as string;
        }
    }
}
