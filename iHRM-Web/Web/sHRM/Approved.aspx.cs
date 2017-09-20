using Ext.Net;
using iHRM.Core.Business.DbObject;
using iHRM.WebPC.Code; using iHRM.Common.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iHRM.WebPC.sHRM
{
    public partial class Approved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!LoginHelper.isLogin)
                Response.Redirect("/Cpanel/Login.aspx?ref=" + Server.UrlDecode(Request.Url.ToString()));

            if (!IsPostBack && !X.IsAjaxRequest)
            {
                //load top menu                
                stoTopMenu.DataSource = LoginHelper.user.w5sysRole.w5sysRules
                    .Where(i => i.w5sysFunction.parentId == const1.approvedRootTreeID)
                    .OrderBy(i => i.w5sysFunction.order1)
                    .Select(i => new
                    {
                        name = Lng.Web_Language.CurrentLng == "vi" ? i.w5sysFunction.caption : i.w5sysFunction.caption_EN,
                        url = i.w5sysFunction.asemblyPath,
                        fid = i.functionID
                    });
                stoTopMenu.DataBind();

                btnUser.Text = LoginHelper.user.caption;

                if (Lng.Web_Language.CurrentLng == "vi")
                {
                    statusbar1_lng.Icon = Icon.FlagVn;
                    statusbar1_lng.Text = "Tiếng việt";
                    tenDoanhNghiep.Html = "Chi nhánh: <b>" + System.Configuration.ConfigurationManager.AppSettings["SS_Dep"] + "</b>";
                }
                else
                {
                    statusbar1_lng.Icon = Icon.FlagUs;
                    statusbar1_lng.Text = "English";
                    tenDoanhNghiep.Html = "Dempartment: <b>" + System.Configuration.ConfigurationManager.AppSettings["SS_Dep_EN"] + "</b>";
                }
                statusbar1_ip.Text = GetClientIP();
                statusbar1_db.Text = LoginHelper.dbUsed;

                Lng.Web_Language.Lng_SetControlTexts(this);
                meSetLanguage();

                if (Request["f"] != null)
                    X.AddScript("setTimeout('showMenu(" + Request["f"] + ")', 1000)");
            }
        }
        private void meSetLanguage()
        {
            if (Lng.Web_Language.CurrentLng == "en")
            {
                //wEx.Html = "<p>Error has throw<br />Please contact adminitrator...</p><div id='wEx_msg' style='display: none'></div>";
                lblTerms.Text = "Terms";
                lblPrivacy.Text = "Privacy";
                sHRM_logo.Src = "/sHRM/Styles/img/Quantri_EN.png";
                wLng.Title = "Language";
            }
        }

        protected void btnLogout_Click(object sender, DirectEventArgs e)
        {
            LoginHelper.logout();
            Response.Redirect("/Cpanel/Login.aspx");
        }

        protected void wLng_DirectClick(object sender, DirectEventArgs e)
        {
            var btn = sender as Ext.Net.Button;
            Lng.Web_Language.Load(btn.CommandArgument);

            statusbar1_lng.Text = btn.Text;
            statusbar1_lng.Icon = btn.Icon;
            wLng.Hide();
            Response.Redirect("/sHRM/Approved.aspx");
        }

        public static string GetClientIP()
        {
            string ip = "";
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
                ip = ipList.Split(',')[0];

            if (string.IsNullOrWhiteSpace(ip))
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrWhiteSpace(ip))
                ip = HttpContext.Current.Request.UserHostAddress;

            return ip;
        }

    }
}