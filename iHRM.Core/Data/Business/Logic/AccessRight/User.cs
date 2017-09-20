using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.AccessRight
{
    public class User : LogicBase
    {
        public User() : base(iHRM.Core.Business.TableConst.tbUser.TableName) { }

        public DataTable GetAll(long? idRole = null)
        {
            return Provider.ExecuteDataTable("p_w5sysUser_GetAll",
                new SqlParameter("idRole", idRole)
            );
        }
    }
}
