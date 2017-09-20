using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace iHRM.Core.Business.Logic.AccessRight
{
    public class Function : LogicBase
    {
        public Function() : base(iHRM.Core.Business.TableConst.tbFunction.TableName) { }

        public DataTable GetAll(bool? requiredAdmin = null)
        {
            return Provider.ExecuteDataTable("p_tbFunction_GetAll",
                new SqlParameter("requiredAdmin", requiredAdmin)
            );
        }

        public DataTable GetAll_lite(bool? requiredAdmin = null)
        {
            return Provider.ExecuteDataTable("p_tbFunction_GetAll_lite",
                new SqlParameter("requiredAdmin", requiredAdmin)
            );
        }

        public static string GetFunctionHtmlCaption(DbObject.w5sysFunction f, int lv = 0, eLanguage CurrentLng = eLanguage.VN, int flatForm = 0)
        {
            if (flatForm == 0)
                return string.Format("<span class='spacelv{2}'></span><span class='nodeid'>[{3}]</span><span class='nodecode'>{0}</span> <span class='nodecaption'>[{1}]</span>", f.code, CurrentLng == eLanguage.VN ? f.caption : f.caption_EN, lv, f.id);
            return string.Format("[{3} {0}] {1}", f.code, CurrentLng == eLanguage.VN ? f.caption : f.caption_EN, lv, f.id);
        }
    }
}
