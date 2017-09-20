using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site._Sys
{
    public partial class GetUserControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request["key"];
            if (string.IsNullOrWhiteSpace(key))
            {
                if (Request["path"] != null)
                {
                    string q = "";
                    foreach (string k in Request.Form.AllKeys)
                    {
                        if (k != "path")
                            q += "," + k + "=" + Request.Form[k];
                    }
                    if (q != "")
                        q = "(" + q.Substring(1) + ")";

                    key = Request["path"] + q;
                }
            }
            if (string.IsNullOrWhiteSpace(key))
                return;

            key = key.Replace("!", "/");
            Response.Write(global::iHRM.WebPC.Base.FrontEndPageBase.GenUserControl(key));
        }
    }
}