using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.AccessRight
{
    public class CLogin
    {
        public int CreateWaitLogin(Guid code)
        {
            return Provider.ExecNoneQuery("p_CLogin_createWaitLogin",
                new SqlParameter("code", code)
            );
        }

        public int DeleteWaitLogin(Guid code)
        {
            return Provider.ExecNoneQuery("p_CLogin_deleteWaitLogin",
                new SqlParameter("code", code)
            );
        }

        public DataRow GetWaitLogin(Guid code)
        {
            return Provider.ExecuteDataRow("p_CLogin_getWaitLogin",
                new SqlParameter("code", code)
            );
        }
    }
}
