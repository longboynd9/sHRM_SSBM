using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using iHRM.WebPC.Code; using iHRM.Common.Code;

namespace iHRM.WebPC.Cpanel.Admin
{
    public partial class SystemTools : Page
    {
        //protected override void initRight()
        //{
        //    adm_FuncID = 55;
        //    adm_RequiredAdmin = true;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnSaveLng_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                Lng.Web_Language.Save();
                Tools.message(Lng.common_msg.Save_Success);
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
        }

        protected void btnGenLngJs_DirectClick(object sender, DirectEventArgs e)
        {
            try
            {
                Lng.Web_Language.SaveJs();
                Tools.message(Lng.common_msg.Save_Success + " (" + Lng.Web_Language.CurrentLng + ")");
            }
            catch (Exception ex)
            {
                Tools.messageEx(ex);
            }
        }

    }
}