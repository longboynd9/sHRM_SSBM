using iHRM.Core.Business;
using iHRM.Core.Business.DbObject;
using iHRM.Win.Cls;
using iHRM.Win.ExtClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iHRM.Win
{
    public class LoginHelper
    {
        public static dcDatabaseDataContext db;
        public static Interface_Company Context;
        private static w5sysUser u = null;
        public static w5sysUser user
        {
            get
            {
                if (u != null)
                    return u;

                var uu = new w5sysUser();
                uu.caption = "TK Khách";
                return uu;
            }
            set
            {
                u = value;
            }
        }
        public static DataRow Dept { get; set; }

        public static bool isLogin
        {
            get { return u != null; }
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
            db = new dcDatabaseDataContext(Provider.ConnectionString);
            u = db.w5sysUsers.SingleOrDefault(i => i.loginID == id && i.loginPW == pw);
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
                Context = new Interface_Company();
            }
            catch { }

            return true;
        }

        public static void logout()
        {
            u = null;
        }
    }
}
