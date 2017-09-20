using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.Site
{
    public partial class contact : global::iHRM.WebPC.Base.FrontEndPageBase
    {
        protected override string PageView() { return "contact"; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Parser.Parse("load_lng", DisplayLanguage == eLanguage.EN ? "" : ("_" + DisplayLanguage));

            string msg1 = "";
            if (Request["submit1"] != null)
            {
                string temp = "<b>Your Name:</b> {{YourName}}<br /><b>Your Email:</b> {{YourEmail}}<br /><b>Subject:</b> {{Subject}}<br /><b>Message:</b><br />{{Message}}";
                try
                {
                    temp = System.IO.File.ReadAllText(Server.MapPath("~/HtmlModule/contact2emailTemplate.html"), System.Text.Encoding.UTF8);
                }
                catch { }

                try
                {
                    temp = temp.Replace("{{ContactName}}", Request["ContactName"]);
                    temp = temp.Replace("{{ContactEmail}}", Request["ContactEmail"]);
                    temp = temp.Replace("{{Subject}}", Request["Subject"]);
                    temp = temp.Replace("{{Message}}", Request["Message"]);

                    //iHRM.Core.Business.Logic.sys.sysPa logicPa = new iHRM.Core.Business.Logic.sys.sysPa();
                    //iHRM.WebPC.Code.SendMailHelper sm = new iHRM.WebPC.Code.SendMailHelper();
                    //if (sm.sendMailTo(logicPa.Get("contact2email-acc"), "Contact in lawfirmelite", temp))
                    //    msg1 = "Send success";
                    //else
                    //    msg1 = "Send fail";
                }
                catch(Exception ex)
                {
                    Parser.Parse("msg1", ex.Message);
                }
            }
            Parser.Parse("msg1", msg1);
        }
    }
}