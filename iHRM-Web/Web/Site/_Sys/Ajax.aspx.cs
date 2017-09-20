using iHRM.WebPC.Base;
using iHRM.WebPC.Classes.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site._Sys
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.Form["a"];
            if (!string.IsNullOrWhiteSpace(action))
            {
                Response.Clear();

                switch (action)
                {
                    case "ChangeLanguage":
                        ChangeLanguage();
                        break;
                }
                                
                Response.End();
            }
        }

        void ChangeLanguage()
        {
            try
            {
                eLanguage a = eLanguage.EN;
                if (Enum.IsDefined(typeof(eLanguage), Request["lng"]))
                    a = (eLanguage)Enum.Parse(typeof(eLanguage), Request["lng"]);
                FrontEndPageBase.DisplayLanguage = a;

                WriteResult(1, a.ToString());
            }
            catch (Exception ex)
            {
                WriteResult(0, ex.Message);
            }
        }

        void WriteResult(int stt, string msg, string data = "")
        {
            Response.Write(string.Format("{{ stt: {0}, msg: '{1}', data: {2} }}", stt, EscapeString(msg), string.IsNullOrWhiteSpace(data) ? "''" : data));
        }
        string EscapeString(string s)
        {
            return s.Replace("'", "\'").Replace("\r", "").Replace("\n", "\\n\\");
        }

    }
}