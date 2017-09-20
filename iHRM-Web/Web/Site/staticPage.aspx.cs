using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site
{
    public partial class staticPage : global::iHRM.WebPC.Base.FrontEndPageBase
    {
        protected override string PageView() { return "staticPage"; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Parser.Parse("staticPage_html", global::iHRM.WebPC.HtmlModule.HtmlModuleRender.Gen("staticPage_content", Request["page"]));
        }
    }
}