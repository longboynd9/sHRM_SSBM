using System;
using System.Configuration;
using System.Web.Routing;

namespace iHRM.WebPC
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Register the default hubs route: ~/signalr
            RouteTable.Routes.MapHubs();

            Core.Business.Provider.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //load ngon ngu
            //eLanguage a = eLanguage.EN;
            //Enum.TryParse<eLanguage>(iHRM.WebPC.Classes.Helper.Cookies.ReadCookie("_DisplayLanguage"), out a);
            //Base.PageBase.DisplayLanguage = a;

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}