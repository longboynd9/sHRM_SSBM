using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHRM.WebPC.HtmlModule
{
    public class HtmlModuleRender
    {
        public static string Gen(string htmlid, string fileName)
        {
            if (!fileName.EndsWith(".html"))
                fileName += ".html";

            return string.Format("<script>$('#{0}').load('/HtmlModule/{1}');</script>", htmlid, fileName);
        }
    }
}