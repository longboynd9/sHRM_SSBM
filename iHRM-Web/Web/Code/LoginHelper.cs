using iHRM.Core.Business.DbObject;
using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace iHRM.WebPC.Code
{
    public class LoginHelper
    {
        public static DataRow Dept { get; set; } 

        public static bool isLogin
        {
            get { return HttpContext.Current.Session["LoginHelper_loginuUser"] != null; }
        }

        public static string dbUsed
        {
            get { return HttpContext.Current.Session["LoginHelper_dbUsed"] as string; }
            set { HttpContext.Current.Session["LoginHelper_dbUsed"] = value; }
        }

        public static w5sysUser user
        {
            get { return HttpContext.Current.Session["LoginHelper_loginuUser"] as w5sysUser; }
        }

        public static long getRightAccess(long function)
        {
            try
            {
                var r = user.w5sysRole.w5sysRules.SingleOrDefault(i => i.functionID == function);
                return r.rules;
            }
            catch
            {
                return 0;
            }

        }

        public static bool loginin(string id, string pw)
        {
            var db = new dcDatabaseDataContext(Provider.ConnectionString);
            w5sysUser u = db.w5sysUsers.SingleOrDefault(i => i.loginID == id && i.loginPW == pw);
            if (u == null)
                return false;

            try
            {
                if (u.w5sysRole != null)
                {
                    int ii = u.w5sysRole.w5sysRules.Count;
                    ii = u.w5sysRole.w5sysRules.Count;
                    ii = u.w5sysRole.w5sysRules.Select(i => i.w5sysFunction.parentId).Count();
                }
            }
            catch { }

            HttpContext.Current.Session["LoginHelper_loginuUser"] = u;
            return true;
        }

        public static void logout()
        {
            HttpContext.Current.Session["LoginHelper_loginuUser"] = null;
        }
        
    }
}
