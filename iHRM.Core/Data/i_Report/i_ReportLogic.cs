using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.i_Report
{
    public class i_ReportLogic
    {
        public static DataTable GetData(i_ReportBase rp, SqlParameter[] pas)
        {
            return Business.Provider.ExecuteDataTableReader(rp.ProcName, pas);
        }
    }
}
