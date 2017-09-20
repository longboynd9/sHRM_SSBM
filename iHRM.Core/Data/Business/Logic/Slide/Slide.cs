using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.Slide
{
    public class Slide : LogicBase
    {
        public Slide() : base("tbSlide") { }

        public DataTable GetCategory()
        {
            return Provider.ExecuteDataTableReader("p_Slide_GetCategory");
        }
    }
}
