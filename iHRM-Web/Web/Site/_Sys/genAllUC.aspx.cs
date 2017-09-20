using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site._Sys
{
    public partial class genAllUC : System.Web.UI.Page
    {
        protected string Gen()
        {
            if (string.IsNullOrWhiteSpace(Request["path"]))
                return "";

            System.Web.UI.UserControl uu = (System.Web.UI.UserControl)this.LoadControl("~/" + Request["path"].Replace("!", "/"));

            Type type = uu.GetType();
            foreach (string k in Request.Form.AllKeys)
            {
                if (k != "path")
                {
                    PropertyInfo prop = type.GetProperty(k);
                    if (prop != null)
                        prop.SetValue(uu, Request[k], null);
                }
            }

            var sb = new System.Text.StringBuilder();
            var h = new System.Web.UI.HtmlTextWriter(new System.IO.StringWriter(sb));
            uu.RenderControl(h);
            return sb.ToString();
        }
    }
}