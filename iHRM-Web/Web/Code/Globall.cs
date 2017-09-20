using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHRM.WebPC.Code
{
    //ducnm - 24/04/2013
    /// <summary>
    /// các hằng số linh tinh
    /// </summary>
    public class web_globall
    {
        public static string uploadFolder
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["uploadFolder"]; }
        }
    }

}