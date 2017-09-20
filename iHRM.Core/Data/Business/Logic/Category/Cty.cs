using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Category
{
    public class Cty : LogicBase
    {
        public Cty() : base(iHRM.Core.Business.TableConst.tbCty.TableName) { }

        public DataRow Get()
        {
            return Provider.ExecuteDataRow("p_tbCty_Get");
        }
    }
}
