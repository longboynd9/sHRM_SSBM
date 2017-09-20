using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Common
{
    public class login
    {
        public DataTable GetAllConnection()
        {
            return Provider.ExecuteDataTable("p_Login_GetAllConnection");
        }
    }
}
