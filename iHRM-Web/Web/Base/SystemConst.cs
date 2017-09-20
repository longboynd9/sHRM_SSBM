using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHRM.WebPC.Base
{
    public static class SystemConst
    {
        public static string uploadFolder
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["uploadFolder"]; }
        }

        public static int danhMucBV_pageSize
        {
            get { return int.Parse(System.Configuration.ConfigurationManager.AppSettings["danhMucBV_pageSize"]); }
        }
    }
}