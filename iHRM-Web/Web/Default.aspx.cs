using System;
using System.Data;
using iHRM.WebPC.Base;
using iHRM.WebPC.Classes;

namespace iHRM.WebPC
{
    public partial class Default : FrontEndPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request["ExtenAction"]))
            {
                try
                {
                    switch (Request["ExtenAction"])
                    {
                        case "ResetCache":
                            CacheMng.Clear();
                            Response.Write("ResetCache complete");
                            break;
                        case "ResetConnection":
                            Core.Business.Provider.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                            Response.Write("Source cnn = " + Core.Business.Provider.ConnectionString);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

                Response.End();
                return;
            }

            if (!IsPostBack)
            {
            }
        }

        protected override string PageView() { return "index"; }
    }
}